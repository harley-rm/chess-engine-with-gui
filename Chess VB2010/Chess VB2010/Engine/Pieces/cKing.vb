<Serializable()>
Public Class cKing
    Inherits cPiece

    Private _hasMoved As Boolean = False

    Public Function getHasMoved() As Boolean
        Return Me._hasMoved
    End Function
    Public Sub setHasMoved(VALUE As Boolean)
        Me._hasMoved = VALUE
    End Sub

    Public Sub New(ALLIANCE As Alliance, COORDINATE As Byte)
        MyBase.New(ALLIANCE, COORDINATE)
        Me._title = Chessman.King
        Me._value = 100000
    End Sub

    Public Overrides Function getChar() As Char
        If Me._alliance = Alliance.White Then
            Return CChar("K")
        Else
            Return CChar("k")
        End If
    End Function

    Public Overrides Function getPseudoLegalMoves(BOARD As cBoard) As sMove()
        Dim possibleMoveOffsets As SByte() = {-9, -8, -7, -1, 1, 7, 8, 9}
        Dim legalMoves() As sMove = Nothing
        Dim counter As Integer = 0
        For i = 0 To UBound(possibleMoveOffsets)
            Dim targetCoord As Integer = Me._coordinate + possibleMoveOffsets(i)
            If isValidTile(targetCoord, Me._coordinate, possibleMoveOffsets(i)) Then
                If Not BOARD.getTile(CByte(targetCoord)).getOccupied Then
                    ReDim Preserve legalMoves(counter)
                    legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoord))
                    counter += 1
                Else
                    'HANDLES CAPTURING
                    If BOARD.getTile(CByte(targetCoord)).getPiece.getAlliance <> Me._alliance Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoord))
                        counter += 1
                    End If
                End If
            End If
        Next
        If Not _hasMoved AndAlso Not BOARD.isInCheck(Me._alliance) Then
            'CASTLING STUFF
            Dim allowShort As Boolean = True
            Dim allowLong As Boolean = True
            Dim moveSet As sMove()
            Dim longCoords As Byte()
            Dim shortCoords As Byte()
            If Me._alliance = Alliance.White Then
                longCoords = {59, 58}
                shortCoords = {61, 62}
                moveSet = BOARD.getPseudoLegalMoves(Alliance.Black)
            Else
                longCoords = {2, 3}
                shortCoords = {5, 6}
                moveSet = BOARD.getPseudoLegalMoves(Alliance.White)
            End If

            'checks to see that the tiles are not occupied
            For Each move As Byte In longCoords
                If BOARD.getTile(move).getOccupied Then allowLong = False
            Next
            For Each move As Byte In shortCoords
                If BOARD.getTile(move).getOccupied Then allowShort = False
            Next

            'checks to see if a tile the king will move through will put it in check
            If moveSet IsNot Nothing Then
                For Each move As sMove In moveSet
                    If longCoords.Contains(move.dest) Then
                        allowLong = False
                    ElseIf shortCoords.Contains(move.dest) Then
                        allowShort = False
                    End If
                Next
            End If


            Select Case Me._alliance
                Case Alliance.Black
                    If allowShort Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, 6)
                        counter += 1
                    End If
                    If allowLong Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, 2)
                        counter += 1
                    End If
                Case Alliance.White
                    If allowShort Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, 62)
                        counter += 1
                    End If
                    If allowLong Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, 58)
                        counter += 1
                    End If
            End Select

        End If
        Return legalMoves
    End Function

    Private Function isValidTile(TARGET_COORDIANTE As Integer, OG_COORDINATE As Byte, OFFSET As Integer) As Boolean
        Dim ogCol As Integer = (OG_COORDINATE Mod 8 + 1)
        Select Case ogCol
            Case 1
                If OFFSET = -9 Or OFFSET = -1 Or OFFSET = 7 Then Return False
            Case 8
                If OFFSET = 9 Or OFFSET = 1 Or OFFSET = -7 Then Return False
        End Select
        If TARGET_COORDIANTE >= 0 And TARGET_COORDIANTE <= 63 Then
            Return True
        End If
        Return False
    End Function
End Class

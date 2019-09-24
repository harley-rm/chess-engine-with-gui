<Serializable()>
Public Class cPawn
    Inherits cPiece

    Public Sub New(ALLIANCE As Alliance, COORDINATE As Byte)
        MyBase.New(ALLIANCE, COORDINATE)
        Me._title = Chessman.Pawn
        Me._value = 100
    End Sub

    Public Overrides Function get_char() As Char
        If Me._alliance = Alliance.White Then
            Return CChar("P")
        Else
            Return CChar("p")
        End If
    End Function

    Public Overrides Function calc_pseudo(BOARD As cBoard) As sMove()
        Dim possibleMoveOffsets() As Integer = {7, 8, 9}
        Dim multiplier As Integer
        Dim legalMoves() As sMove = Nothing
        Dim counter As Integer = 0
        If Me._alliance = Alliance.White Then multiplier = -1 Else multiplier = 1
        For i = 0 To UBound(possibleMoveOffsets)
            Dim targetCoordinate As Integer = Me._coordinate + possibleMoveOffsets(i) * multiplier
            If is_valid_tile(targetCoordinate, Me._coordinate, (possibleMoveOffsets(i) * multiplier)) Then
                'HANDLES CAPTURE MOVES
                If possibleMoveOffsets(i) = 7 Or possibleMoveOffsets(i) = 9 Then
                    If BOARD.getTile(CByte(targetCoordinate)).is_occupied AndAlso
                        BOARD.getTile(CByte(targetCoordinate)).get_piece.get_alliance <> Me._alliance Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoordinate))
                        counter += 1
                    ElseIf BOARD.getTile(CByte(targetCoordinate)).get_coordinate = BOARD.getEnPassent Then
                        'HANDLES CAPTURING EN PASSENT
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoordinate))
                        counter += 1
                    End If
                Else
                    'HANDLES FORWARDS MOVES
                    If Not BOARD.getTile(CByte(targetCoordinate)).is_occupied Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoordinate))
                        counter += 1
                        'HANDLES THRUSTING
                        targetCoordinate = targetCoordinate + (8 * multiplier)
                        If is_valid_tile(targetCoordinate, Me._coordinate, 16 * multiplier) Then
                            If ((Me._coordinate \ 8 + 1) = 7 AndAlso Me._alliance = Alliance.White AndAlso Not BOARD.getTile(CByte(targetCoordinate)).is_occupied) _
                            Or ((Me._coordinate \ 8 + 1) = 2 AndAlso Me._alliance = Alliance.Black AndAlso Not BOARD.getTile(CByte(targetCoordinate)).is_occupied) Then
                                ReDim Preserve legalMoves(counter)
                                legalMoves(counter) = New sMove(Me._coordinate, CByte((targetCoordinate)))
                                counter += 1
                            End If
                        End If
                    End If
                End If
            End If
        Next
        Return legalMoves
    End Function

    Public Function is_valid_tile(TARGET_COORDIANTE As Integer, OG_COORDINATE As Byte, OFFSET As Integer) As Boolean
        Dim ogCol As Integer = (OG_COORDINATE Mod 8 + 1)
        Select Case ogCol
            Case 1
                If OFFSET = -9 Or OFFSET = 7 Then Return False
            Case 8
                If OFFSET = 9 Or OFFSET = -7 Then Return False
        End Select
        If TARGET_COORDIANTE >= 0 And TARGET_COORDIANTE <= 63 Then
            Return True
        End If
        Return False
    End Function
End Class

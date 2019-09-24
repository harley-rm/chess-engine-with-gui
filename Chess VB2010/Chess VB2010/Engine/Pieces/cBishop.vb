<Serializable()>
Public Class cBishop
    Inherits cPiece

    Public Sub New(ALLIANCE As Alliance, COORDINATE As Byte)
        MyBase.New(ALLIANCE, COORDINATE)
        Me._title = Chessman.Bishop
        Me._value = 315
    End Sub

    Public Overrides Function get_char() As Char
        If Me._alliance = Alliance.White Then
            Return CChar("B")
        Else
            Return CChar("b")
        End If
    End Function

    Public Overrides Function calc_pseudo(BOARD As cBoard) As sMove()
        Dim possibleMoveOffsets As SByte() = {-9, -7, 7, 9}
        Dim legalMoves() As sMove = Nothing
        Dim counter As Integer = 0
        For i = 0 To UBound(possibleMoveOffsets)
            Dim targetCoord As Integer = Me._coordinate + possibleMoveOffsets(i)
            While is_valid_tile(targetCoord, CByte(targetCoord - possibleMoveOffsets(i)), possibleMoveOffsets(i))
                If BOARD.getTile(CByte(targetCoord)).is_occupied Then
                    If BOARD.getTile(CByte(targetCoord)).get_piece.get_alliance <> Me._alliance Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoord))
                        counter += 1
                    End If
                    Exit While
                Else
                    ReDim Preserve legalMoves(counter)
                    legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoord))
                    counter += 1
                End If
                targetCoord += possibleMoveOffsets(i)
            End While
        Next
        Return legalMoves
    End Function

    Public Function is_valid_tile(TARGET_COORDIANTE As Integer, OG_COORDINATE As Byte, OFFSET As Integer) As Boolean
        Dim ogCol As Integer = (OG_COORDINATE Mod 8 + 1)
        Select Case ogCol
            Case 1
                If OFFSET = -9 Or OFFSET = 7 Then Return False
            Case 8
                If OFFSET = -7 Or OFFSET = 9 Then Return False
        End Select
        If TARGET_COORDIANTE >= 0 And TARGET_COORDIANTE <= 63 Then
            Return True
        End If
        Return False
    End Function
End Class

<Serializable()>
Public Class cKnight
    Inherits cPiece

    Public Sub New(ALLIANCE As Alliance, COORDINATE As Byte)
        MyBase.New(ALLIANCE, COORDINATE)
        Me._title = Chessman.Knight
        Me._value = 300
    End Sub

    Public Overrides Function get_char() As Char
        If Me._alliance = Alliance.White Then
            Return CChar("N")
        Else
            Return CChar("n")
        End If
    End Function

    Public Overrides Function calc_pseudo(BOARD As cBoard) As sMove()
        Dim offsets As SByte() = {-17, -15, -10, -6, 6, 10, 15, 17}
        Dim pseudoLegalMoves() As sMove = Nothing
        Dim counter As Integer = 0

        For Each offset As SByte In offsets
            Dim targetCoord As Integer = Me._coordinate + offset
            If is_valid_tile(targetCoord) Then
                If Not BOARD.getTile(CByte(targetCoord)).is_occupied Then
                    ReDim Preserve pseudoLegalMoves(counter)
                    pseudoLegalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoord))
                    counter += 1
                Else
                    If BOARD.getTile(CByte(targetCoord)).get_piece.get_alliance <> Me._alliance Then
                        ReDim Preserve pseudoLegalMoves(counter)
                        pseudoLegalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoord))
                        counter += 1
                    End If
                End If
            End If
        Next
        Return pseudoLegalMoves
    End Function

    Public Function is_valid_tile(TARGET_COORDINATE As Integer) As Boolean
        If TARGET_COORDINATE <= 63 And TARGET_COORDINATE >= 0 Then
            If Not Math.Abs((Me._coordinate Mod 8 + 1) - (TARGET_COORDINATE Mod 8 + 1)) > 2 Then
                Return True
            End If
        End If
        Return False
    End Function

End Class

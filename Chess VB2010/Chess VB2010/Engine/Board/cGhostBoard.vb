Public Class cGhostBoard
    Private _move As sMove
    Private _board As cBoard
    Private _legal As Boolean

    Public Function is_legal() As Boolean
        Return Me._legal
    End Function
    Public Function get_board() As cBoard
        Return Me._board
    End Function

    Public Sub New(OG_BOARD As cBoard, MOVE As sMove)
        Me._move = MOVE
        Me._board = OG_BOARD.getDeepClone(Of cBoard)(OG_BOARD)
        Me._board.MakeMove(MOVE, True)
        Me._legal = calc_legality()
    End Sub

    Public Function calc_legality() As Boolean
        With (Me._board)
            If .isInCheck(Alliance.White) AndAlso .getWhoseTurn = Alliance.Black Then
                Return False
            End If
            If .isInCheck(Alliance.Black) AndAlso .getWhoseTurn = Alliance.White Then
                Return False
            End If
        End With
        Return True
    End Function

End Class

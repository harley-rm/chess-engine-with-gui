Public Class cGhostBoard
    Private _move As sMove
    Private _transition As cBoard
    Private _isLegal As Boolean

    Public Function isLegal() As Boolean
        Return Me._isLegal
    End Function
    Public Function getBoard() As cBoard
        Return Me._transition
    End Function

    Public Sub New(OG_BOARD As cBoard, MOVE As sMove)
        Me._move = MOVE
        Me._transition = OG_BOARD.getDeepClone(Of cBoard)(OG_BOARD)
        Me._transition.MakeMove(MOVE, True)
        Me._isLegal = calculateIsBoardLegal()
    End Sub

    Public Function calculateIsBoardLegal() As Boolean
        With (Me._transition)
            If .isInCheck(Alliance.White) AndAlso .getWhosTurn = Alliance.Black Then
                Return False
            End If
            If .isInCheck(Alliance.Black) AndAlso .getWhosTurn = Alliance.White Then
                Return False
            End If
        End With
        Return True
    End Function

End Class

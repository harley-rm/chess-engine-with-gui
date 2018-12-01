Public Class cGame

    Private _board As cBoard
    Private _whiteClock As cClock
    Private _blackClock As cClock

    Public boardList As LinkedList(Of cBoard)

    Public WithEvents _gameGUI As cGameGUI

    Public Function getGameGUI() As cGameGUI
        Return Me._gameGUI
    End Function

    Public Function getBoard() As cBoard
        Return Me._board
    End Function

    Public Sub New(TARGET As Form, SETTINGS As sSettings)
        Me._board = New cBoard
        Me.boardList = New LinkedList(Of cBoard)
        Me.boardList.AddLast(Me._board.getDeepClone(Of cBoard)(Me._board))
        Me._gameGUI = New cGameGUI(TARGET, Me, SETTINGS)
    End Sub

    Public Sub UndoMove()
        If boardList.Last.Previous IsNot Nothing Then
            Me._board = Me._board.getDeepClone(Of cBoard)(boardList.Last.Previous.Value)
            boardList.RemoveLast()
            Me._gameGUI.getBoardGUI.setBoard(Me._board)
            Me._gameGUI.getMoveList.ClearAndUpdate()
        End If
    End Sub

End Class

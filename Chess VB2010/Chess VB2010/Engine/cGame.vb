<Serializable()>
Public Class cGame

    Private WithEvents _board As cBoard

    Private WithEvents _whiteClock As cClock
    Private WithEvents _blackClock As cClock

    Private _user1 As cAccount
    Private _user2 As cAccount

    Private _gameOver As Boolean

    Public boardList As LinkedList(Of cBoard)

    Public WithEvents _gameGUI As cGameGUI

#Region "Mutators & Accessors"
    Public Function get_gui() As cGameGUI
        Return Me._gameGUI
    End Function

    Public Function get_board() As cBoard
        Return Me._board
    End Function

    Public Function get_user1() As cAccount
        Return Me._user1
    End Function
    Public Sub set_user1(ByRef val As cAccount)
        Me._user1 = val
    End Sub

    Public Function get_user2() As cAccount
        Return Me._user2
    End Function
    Public Sub set_user2(ByRef val As cAccount)
        Me._user2 = val
    End Sub
#End Region

    Public Sub New(TARGET As Form, SETTINGS As sSettings)
        Me._board = New cBoard
        Me.boardList = New LinkedList(Of cBoard)
        Me.boardList.AddLast(Me._board.getDeepClone(Of cBoard)(Me._board))
        Me._gameGUI = New cGameGUI(TARGET, Me, SETTINGS)
    End Sub

    Public Sub setup_online()
        Me._whiteClock = Nothing : Me._blackClock = Nothing
    End Sub

    Public Sub setup_clock(seconds As Integer, Optional increment As Integer = 0)
        Me._whiteClock = New cClock(Me, seconds, increment)
        Me._blackClock = New cClock(Me, seconds, increment)
    End Sub

    Public Sub undo_move()
        If boardList.Last.Previous IsNot Nothing Then
            Me._board = Me._board.getDeepClone(Of cBoard)(boardList.Last.Previous.Value)
            boardList.RemoveLast()
            Me._gameGUI.getBoardGUI.set_board(Me._board)
            Me._gameGUI.getMoveList.ClearAndUpdate(Me._board)
        End If
    End Sub

End Class

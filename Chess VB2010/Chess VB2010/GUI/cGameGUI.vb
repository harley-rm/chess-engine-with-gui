<Serializable()>
Public Class cGameGUI
    Inherits Panel

    Private _game As cGame

    Private _boardGUI As cBoardGUI
    Private _whiteClockGUI As cClockGUI
    Private _blackClockGUI As cClockGUI
    Public WithEvents _moveListGUI As cCustomMoveList

    Private _wrapper As cBoardWrapper

    Public Function getMoveList() As cCustomMoveList
        Return Me._moveListGUI
    End Function
    Public Function getBoardGUI() As cBoardGUI
        Return Me._boardGUI
    End Function
    Public Function getBoardWrapper() As cBoardWrapper
        Return Me._wrapper
    End Function

    Public Sub New(TARGET As Form, GAME As cGame, SETTINGS As sSettings)
        TARGET.Controls.Add(Me)
        Me._game = GAME

        Me.Location = New Point(5, 90)
        Me.Size = New Size(TARGET.Size.Width - 10, (TARGET.Height - 90 - 30))

        Me._boardGUI = New cBoardGUI(Me._game, Me._game.get_board, CInt(Me.Height) - 30, SETTINGS, Me)
        Me.Controls.Add(Me._boardGUI)

        Me._moveListGUI = New cCustomMoveList(Me, Color.FromArgb(27, 27, 27), Color.FromArgb(-1842205), Color.FromArgb(40, 40, 40))
        Me.Controls.Add(Me._moveListGUI)

        Me._boardGUI.Location = New Point(CInt((Me.Width - (Me._boardGUI.Width + Me._moveListGUI.Width + 10)) / 2), 0)
        Me._moveListGUI.Location = New Point(Me._boardGUI.Location.X + Me._boardGUI.Width + 10, 0)

        Me._wrapper = New cBoardWrapper(Me) 'autmatically adds to game gui in constructor.

    End Sub

    Public Sub ResizeComponents(NEW_FORM_SIZE As Size)
        Me.Size = New Size(NEW_FORM_SIZE.Width - 10, (NEW_FORM_SIZE.Height - 90 - 30))

        Dim ls As Color = Me._boardGUI.get_light_colour
        Dim ds As Color = Me._boardGUI.get_dark_colour

        Me._boardGUI.Dispose()
        Me._boardGUI = New cBoardGUI(Me._game, Me._game.get_board, CInt(Me.Height) - 30, InterfaceForm.settings, Me)
        Me.Controls.Add(Me._boardGUI)

        'centered
        'Me._boardGUI.Location = New Point(20, 0)
        'Me._moveListGUI.Location = New Point(20 + Me._boardGUI.Width + 10, 0)

        Me._moveListGUI.ResizeAll()

        Me._boardGUI.Location = New Point(CInt((Me.Width - (Me._boardGUI.Width + Me._moveListGUI.Width + 10)) / 2), 0)
        Me._moveListGUI.Location = New Point(Me._boardGUI.Location.X + Me._boardGUI.Width + 10, 0)

        Me._wrapper.Resize()

    End Sub

End Class

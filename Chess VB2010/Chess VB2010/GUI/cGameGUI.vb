Public Class cGameGUI
    Inherits Panel

    Private _game As cGame

    Private _boardGUI As cBoardGUI
    Private _whiteClockGUI As cClockGUI
    Private _blackClockGUI As cClockGUI
    Private _moveListGUI As cMoveListGUI

    Public Function getMoveList() As cMoveListGUI
        Return Me._moveListGUI
    End Function
    Public Function getBoardGUI() As cBoardGUI
        Return Me._boardGUI
    End Function

    Public Sub New(TARGET As Form, GAME As cGame, SETTINGS As sSettings)
        TARGET.Controls.Add(Me)
        Me._game = GAME

        Me.Location = New Point(5, 90)
        Me.Size = New Size(TARGET.Size.Width - 10, (TARGET.Height - 90 - 40))

        Me._boardGUI = New cBoardGUI(Me._game, Me._game.getBoard, CInt(Me.Height) - 10, SETTINGS, Me)
        Me.Controls.Add(Me._boardGUI)

        Me._moveListGUI = New cMoveListGUI(Me._game, Me._game.getBoard, CInt(Me._boardGUI.Height / 2))
        Me.Controls.Add(Me._moveListGUI)


        Me._boardGUI.Location = New Point(CInt((Me.Width - (Me._boardGUI.Width + Me._moveListGUI.Width + 10)) / 2), 0)
        Me._moveListGUI.Location = New Point(Me._boardGUI.Location.X + Me._boardGUI.Width + 10, 0)

    End Sub

    Public Sub ResizeComponents(NEW_FORM_SIZE As Size)
        Me.Size = New Size(NEW_FORM_SIZE.Width - 10, (NEW_FORM_SIZE.Height - 90 - 40))

        Dim ls As Color = Me._boardGUI.getLightColor
        Dim ds As Color = Me._boardGUI.getDarkColor

        Me._boardGUI.Dispose()
        Me._boardGUI = New cBoardGUI(Me._game, Me._game.getBoard, CInt(Me.Height) - 10, InterfaceForm.settings, Me)
        Me.Controls.Add(Me._boardGUI)

        'centered
        'Me._boardGUI.Location = New Point(20, 0)
        'Me._moveListGUI.Location = New Point(20 + Me._boardGUI.Width + 10, 0)

        Me._moveListGUI.ResizeAll(CInt(Me._boardGUI.Height / 2))

        Me._boardGUI.Location = New Point(CInt((Me.Width - (Me._boardGUI.Width + Me._moveListGUI.Width + 10)) / 2), 0)
        Me._moveListGUI.Location = New Point(Me._boardGUI.Location.X + Me._boardGUI.Width + 10, 0)

    End Sub

End Class

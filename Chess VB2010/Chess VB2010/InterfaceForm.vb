Option Strict On
Public Class InterfaceForm

    Public chess As cGame
    Public WithEvents gui_panel As cGameGUI
    Public min_size As Size = Me.Size
    Public settings As sSettings

    Public state As interface_state

    Public WithEvents main_account As cAccount
    Public WithEvents secondary_account As cAccount 'the account object used by player2 if a local game is being played, otherwise is set to null.

    Public main_account_window As cAccountWindow
    Public secondary_account_window As cAccountWindow

    Private media As media_controller

    Public Function get_game_gui() As cGameGUI
        Return Me.gui_panel
    End Function

#Region "UI"

#Region "Events"
    ''general ui interaction''
    Private Sub FormDoubleClick(sender As Object, e As EventArgs) Handles TitleStripPanel.DoubleClick, MyBase.DoubleClick, TitleLabel.DoubleClick, gui_panel.DoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            Me.nwseResizeButton.Hide()
            Me.hrzResizeButton.Hide()
            Me.vrtResizeButton.Hide()
        Else
            Me.WindowState = FormWindowState.Normal
            Me.nwseResizeButton.Show()
            Me.hrzResizeButton.Show()
            Me.vrtResizeButton.Show()
        End If
    End Sub

    ''drag-drop functionality''
    Private _xStart As Integer
    Private _yStart As Integer
    Private Sub FormMouseDown(sender As Object, e As MouseEventArgs) Handles TitleStripPanel.MouseDown, MyBase.MouseDown, TitleLabel.MouseDown, gui_panel.MouseDown
        _xStart = e.X : _yStart = e.Y
    End Sub
    Private Sub FormDragDrop(sender As Object, e As MouseEventArgs) Handles TitleStripPanel.MouseMove, MyBase.MouseMove, TitleLabel.MouseMove, gui_panel.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location = New Point(Me.Left + e.X - _xStart, Me.Top + e.Y - _yStart)
        End If
    End Sub

    ''title-strip panel''
    Private Sub MinMaxClose(sender As Object, e As EventArgs) Handles MinimizeButton.Click, MaximizeButton.Click, CloseButton.Click
        If sender Is MinimizeButton Then
            Me.WindowState = FormWindowState.Minimized
        ElseIf sender Is MaximizeButton Then
            If Me.WindowState = FormWindowState.Normal Then Me.WindowState = FormWindowState.Maximized Else Me.WindowState = FormWindowState.Normal
        ElseIf sender Is CloseButton Then
            Me.Close()
        End If
    End Sub

    ''menu-strip panel / poas''
    Private Sub ButtonMouseEnter(sender As Object, e As EventArgs) Handles PlayButton.MouseEnter, OnlineButton.MouseEnter, AnalysisButton.MouseEnter, SettingsButton.MouseEnter
        CType(sender, Label).BackColor = Color.FromArgb(60, 60, 60)
    End Sub
    Private Sub ButtonMouseLeave(sender As Object, e As EventArgs) Handles PlayButton.MouseLeave, OnlineButton.MouseLeave, AnalysisButton.MouseLeave, SettingsButton.MouseLeave
        CType(sender, Label).BackColor = MenuStripPanel.BackColor
    End Sub

    Private Sub MenuCollapseButtonClick(sender As Object, e As EventArgs) Handles MenuCollapseButton.Click
        If MenuStripPanel.Visible Then
            MenuStripPanel.Hide()
            MenuCollapseButton.Location = New Point(CInt(MenuCollapseButton.Width / 2), MenuCollapseButton.Location.Y)
            MenuCollapseButton.BackgroundImage = My.Resources.arrow_right
        Else
            MenuStripPanel.Show()
            MenuCollapseButton.Location = New Point(CInt(MenuStripPanel.Location.X - MenuCollapseButton.Width - 6), MenuCollapseButton.Location.Y)
            MenuCollapseButton.BackgroundImage = My.Resources.arrow_left
        End If
    End Sub

#Region "Resizing"
    'NWSE Resize
    Private _ogFormSize As Size
    Private _nwseXStart As Integer
    Private _nwseYStart As Integer
    Private _resizeInProgress As Boolean
    Private Sub nwseMouseDown(sender As Object, e As MouseEventArgs) Handles nwseResizeButton.MouseDown
        If e.Button = MouseButtons.Left Then
            _ogFormSize = Me.Size
            _nwseXStart = e.X : _nwseYStart = e.Y
            _resizeInProgress = True
        End If
    End Sub
    Private Sub nwseResize(sender As Object, e As MouseEventArgs) Handles nwseResizeButton.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim newSize As Size = New Size(_ogFormSize.Width + e.X - _nwseXStart, _ogFormSize.Height + e.Y - _nwseYStart)
            If newSize.Width >= min_size.Width AndAlso newSize.Height >= min_size.Height Then
                Me.Size = newSize

            End If
        End If
    End Sub
    Private Sub nwseMouseUp(sender As Object, e As MouseEventArgs) Handles nwseResizeButton.MouseUp
        nwseResizeButton.Location = New Point(Me.Width - nwseResizeButton.Width, Me.Height - nwseResizeButton.Height)
        _resizeInProgress = False
        e_form_resize(Me, New EventArgs)
    End Sub

    'vrt resize
    Private _vrtYStart As Integer
    Private Sub vrtMouseDown(sender As Object, e As MouseEventArgs) Handles vrtResizeButton.MouseDown
        If e.Button = MouseButtons.Left Then
            _ogFormSize = Me.Size
            _vrtYStart = e.Y
            _resizeInProgress = True
        End If
    End Sub
    Private Sub vrtResize(sender As Object, e As MouseEventArgs) Handles vrtResizeButton.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim newSize As Size = New Size(_ogFormSize.Width, _ogFormSize.Height + e.Y - _vrtYStart)
            If newSize.Width >= min_size.Width AndAlso newSize.Height >= min_size.Height Then Me.Size = newSize
        End If
    End Sub
    Private Sub vrtMouseUp(sender As Object, e As MouseEventArgs) Handles vrtResizeButton.MouseUp
        vrtResizeButton.Location = New Point(0, Me.Height - vrtResizeButton.Height)
        _resizeInProgress = False
        e_form_resize(Me, New EventArgs)
    End Sub

    'hrz resize
    Private _hrzXStart As Integer
    Private Sub hrzMouseDown(sender As Object, e As MouseEventArgs) Handles hrzResizeButton.MouseDown
        If e.Button = MouseButtons.Left Then
            _ogFormSize = Me.Size
            _hrzXStart = e.X
            _resizeInProgress = True
        End If
    End Sub
    Private Sub hrzResize(sender As Object, e As MouseEventArgs) Handles hrzResizeButton.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim newSize As Size = New Size(_ogFormSize.Width + e.X - Me._hrzXStart, _ogFormSize.Height)
            If newSize.Width >= min_size.Width AndAlso newSize.Height >= min_size.Height Then Me.Size = newSize
        End If
    End Sub

    Private Sub hrzMouseUp(sender As Object, e As MouseEventArgs) Handles hrzResizeButton.MouseUp
        hrzResizeButton.Location = New Point(Me.Width - hrzResizeButton.Width, 0)
        _resizeInProgress = False
        e_form_resize(Me, New EventArgs)
    End Sub
#End Region

#End Region

#End Region

#Region "Board, move-list, chat etc"

    Private Sub e_form_load(sender As Object, e As EventArgs) Handles MyBase.Load
        settings.load()
        Me.state = interface_state.single_player
        chess = New cGame(Me, settings)
        gui_panel = chess.get_gui
        Me.min_size = Me.Size
        settings.enact(Me, gui_panel)
        media = New media_controller(Me.select_button, Me.start_stop_button, Me.skip_button, Me.prev_button)
        cAccount.initialize_account_management()
    End Sub

    Private Sub e_form_resize(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If chess IsNot Nothing AndAlso Not _resizeInProgress AndAlso Me.WindowState <> WindowState.Minimized Then
            chess.get_gui.ResizeComponents(Me.Size)
            Me.TitleStripPanel.BringToFront()
            Me.nwseResizeButton.Location = New Point(Me.Width - Me.nwseResizeButton.Width, Me.Height - Me.nwseResizeButton.Height)

            Me.vrtResizeButton.Size = New Size(Me.Width - nwseResizeButton.Width, vrtResizeButton.Height)
            Me.vrtResizeButton.Location = New Point(0, Me.Height - Me.vrtResizeButton.Height)

            Me.hrzResizeButton.Size = New Size(hrzResizeButton.Width, Me.Height - nwseResizeButton.Height)
            Me.hrzResizeButton.Location = New Point(Me.Width - Me.hrzResizeButton.Width, 0)

            If Me.main_account_window IsNot Nothing Then
                Me.main_account_window.Size = New Size(Me.gui_panel.getBoardGUI.Location.X - 10, CInt(Me.gui_panel.getBoardGUI.Height / 8))
                Me.main_account_window.Location = New Point(5, Me.gui_panel.getBoardGUI.Location.Y)
            End If
        End If
    End Sub


    Private Sub e_newgame_click(sender As Object, e As EventArgs) Handles NewGameButton.Click
        Dim x As DialogResult = MessageBox.Show("Are you sure you want to start a new game?", "?", MessageBoxButtons.YesNo)
        If x = DialogResult.Yes Then
            Me.start_new_game()
        End If
    End Sub

    Public Sub start_new_game()
        Me.Controls.Remove(chess._gameGUI)
        chess = Nothing
        chess = New cGame(Me, Me.settings)
        Me.gui_panel = Me.chess.get_gui
        Me.settings.enact(Me, Me.gui_panel)
    End Sub

    Private Sub e_undo_click(sender As Object, e As EventArgs) Handles UndoMoveButton.Click
        Dim x As DialogResult = MessageBox.Show("Are you sure you want to undo your move?", "?", MessageBoxButtons.YesNo)
        If x = DialogResult.Yes Then
            Me.chess.undo_move()
            Me.gui_panel = Me.chess.get_gui
        End If
    End Sub

    Private Sub e_geteval_click(sender As Object, e As MouseEventArgs) Handles ShowEngineEvalButton.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MsgBox(New sEval(Me.chess.get_board).toString)
        Else
            MsgBox(Minimax.calc_best_move(1, Me.chess.get_board).ToString(Me.chess.get_board))
        End If
    End Sub

    Private Sub e_flipboard_click(sender As Object, e As EventArgs) Handles FlipBoardButton.Click
        Me.chess._gameGUI.getBoardGUI.flip_board()
    End Sub

    Private Sub e_settings_click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        SettingsForm.ShowDialog()
    End Sub

#End Region

    Private Sub e_form_previewkeydown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        Dim moveListAcceptedKeys() As Keys = {Keys.Left, Keys.Down, Keys.Up, Keys.Right}
        If moveListAcceptedKeys.Contains(e.KeyCode) Then
            Me.chess.get_gui.getMoveList.e_previewkeydown(sender, e)
        End If
    End Sub

    Private Sub e_login_click(sender As Object, e As EventArgs) Handles login_out_label.Click
        LoginForm.ShowDialog()
    End Sub

    Private Sub e_signup_click(sender As Object, e As EventArgs) Handles sign_up_label.Click
        SignupForm.ShowDialog()
    End Sub

    Public Sub e_login_successful(sender As cAccount)
        Me.main_account = sender
        Me.main_account_window = New cAccountWindow(sender)
        Me.gui_panel.Controls.Add(Me.main_account_window)
        Me.main_account_window.Size = New Size(Me.gui_panel.getBoardGUI.Location.X - 10, 45)
        Me.main_account_window.Location = New Point(5, Me.gui_panel.getBoardGUI.Location.Y)
        Me.login_out_label.Hide()
        Me.sign_up_label.Hide()
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        Dim a As OpenFileDialog = New OpenFileDialog
        a.Filter = "PGN (.pgn)|*.pgn"
        a.ShowDialog()
    End Sub

End Class

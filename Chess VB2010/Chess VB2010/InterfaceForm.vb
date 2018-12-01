Option Strict On
Public Class InterfaceForm

    Public chess As cGame
    Public WithEvents guiPanel As cGameGUI
    Public minSize As Size = Me.Size
    Public settings As sSettings

    Public Function getGameGUI() As cGameGUI
        Return Me.guiPanel
    End Function

#Region "UI"

#Region "Events"
    ''general ui interaction''
    Private Sub FormDoubleClick(sender As Object, e As EventArgs) Handles TitleStripPanel.DoubleClick, MyBase.DoubleClick, TitleLabel.DoubleClick, guiPanel.DoubleClick
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
    Private Sub FormMouseDown(sender As Object, e As MouseEventArgs) Handles TitleStripPanel.MouseDown, MyBase.MouseDown, TitleLabel.MouseDown, guiPanel.MouseDown
        _xStart = e.X : _yStart = e.Y
    End Sub
    Private Sub FormDragDrop(sender As Object, e As MouseEventArgs) Handles TitleStripPanel.MouseMove, MyBase.MouseMove, TitleLabel.MouseMove, guiPanel.MouseMove
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
            If newSize.Width >= minSize.Width AndAlso newSize.Height >= minSize.Height Then
                Me.Size = newSize

            End If
        End If
    End Sub
    Private Sub nwseMouseUp(sender As Object, e As MouseEventArgs) Handles nwseResizeButton.MouseUp
        nwseResizeButton.Location = New Point(Me.Width - nwseResizeButton.Width, Me.Height - nwseResizeButton.Height)
        _resizeInProgress = False
        FormResize(Me, New EventArgs)
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
            If newSize.Width >= minSize.Width AndAlso newSize.Height >= minSize.Height Then Me.Size = newSize
        End If
    End Sub
    Private Sub vrtMouseUp(sender As Object, e As MouseEventArgs) Handles vrtResizeButton.MouseUp
        vrtResizeButton.Location = New Point(0, Me.Height - vrtResizeButton.Height)
        _resizeInProgress = False
        FormResize(Me, New EventArgs)
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
            If newSize.Width >= minSize.Width AndAlso newSize.Height >= minSize.Height Then Me.Size = newSize
        End If
    End Sub
    Private Sub hrzMouseUp(sender As Object, e As MouseEventArgs) Handles hrzResizeButton.MouseUp
        hrzResizeButton.Location = New Point(Me.Width - hrzResizeButton.Width, 0)
        _resizeInProgress = False
        FormResize(Me, New EventArgs)
    End Sub
#End Region

#End Region

#End Region

#Region "Board, move-list, chat etc"

    Private Sub FormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        settings.Load()
        chess = New cGame(Me, settings)
        guiPanel = chess.getGameGUI
        Me.minSize = Me.Size
        settings.PutInEffect(Me, guiPanel)
    End Sub

    Private Sub FormResize(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If chess IsNot Nothing AndAlso Not _resizeInProgress Then
            chess.getGameGUI.ResizeComponents(Me.Size)
            Me.TitleStripPanel.BringToFront()
            Me.nwseResizeButton.Location = New Point(Me.Width - Me.nwseResizeButton.Width, Me.Height - Me.nwseResizeButton.Height)

            Me.vrtResizeButton.Size = New Size(Me.Width - nwseResizeButton.Width, vrtResizeButton.Height)
            Me.vrtResizeButton.Location = New Point(0, Me.Height - Me.vrtResizeButton.Height)

            Me.hrzResizeButton.Size = New Size(hrzResizeButton.Width, Me.Height - nwseResizeButton.Height)
            Me.hrzResizeButton.Location = New Point(Me.Width - Me.hrzResizeButton.Width, 0)
        End If
    End Sub


    Private Sub NewGame(sender As Object, e As EventArgs) Handles NewGameButton.Click
        Dim x As DialogResult = MessageBox.Show("Are you sure you want to start a new game?", "?", MessageBoxButtons.YesNo)
        If x = DialogResult.Yes Then
            Me.Controls.Remove(chess._gameGUI)
            chess = Nothing
            chess = New cGame(Me, Me.settings)
            Me.guiPanel = Me.chess.getGameGUI
            Me.settings.PutInEffect(Me, Me.guiPanel)
        End If
    End Sub

    Private Sub UndoMove(sender As Object, e As EventArgs) Handles UndoMoveButton.Click
        Dim x As DialogResult = MessageBox.Show("Are you sure you want to undo your move?", "?", MessageBoxButtons.YesNo)
        If x = DialogResult.Yes Then
            Me.chess.UndoMove()
            Me.guiPanel = Me.chess.getGameGUI
        End If
    End Sub

    Private Sub GetEvaluation(sender As Object, e As MouseEventArgs) Handles ShowEngineEvalButton.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MsgBox(New sEval(Me.chess.getBoard).toString)
        Else
            MsgBox(Minimax.getBestMove(2, Me.chess.getBoard).ToString(Me.chess.getBoard))
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles FlipBoardButton.Click
        Me.chess._gameGUI.getBoardGUI.FlipBoard()
    End Sub

    Private Sub SettingsButtonClick(sender As Object, e As EventArgs) Handles SettingsButton.Click
        SettingsForm.Show()
    End Sub

#End Region

End Class

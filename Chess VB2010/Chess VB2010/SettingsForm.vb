Public Class SettingsForm

    Private _settings As sSettings

    Public Sub FormLoad(SENDER As Object, E As EventArgs) Handles MyBase.Load
        _settings.load()

        lPanel.BackColor = _settings.lightSquare
        dPanel.BackColor = _settings.darkSquare
        showLegalCB.Checked = _settings.showLegalMoves
        cheatsCB.Checked = _settings.enableCheats
        nightModeCB.Checked = _settings.nightMode

    End Sub

    ''drag-drop functionality''
    Private _xStart As Integer
    Private _yStart As Integer
    Private Sub FormMouseDown(sender As Object, e As MouseEventArgs) Handles TitleStripPanel.MouseDown, MyBase.MouseDown
        _xStart = e.X : _yStart = e.Y
    End Sub
    Private Sub FormDragDrop(sender As Object, e As MouseEventArgs) Handles TitleStripPanel.MouseMove, MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location = New Point(Me.Left + e.X - _xStart, Me.Top + e.Y - _yStart)
        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        _settings.lightSquare = lPanel.BackColor
        _settings.darkSquare = dPanel.BackColor
        _settings.showLegalMoves = showLegalCB.Checked
        _settings.enableCheats = cheatsCB.Checked
        _settings.nightMode = nightModeCB.Checked
        _settings.enact(InterfaceForm, InterfaceForm.gui_panel)
        _settings.save()
        Me.Close()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub lightSquareClick(sender As Object, e As EventArgs) Handles lPanel.Click
        Dim x As New ColorDialog
        x.CustomColors = New Integer() {}
        x.ShowDialog()
        lPanel.BackColor = x.Color
        Dim intl As Integer() = x.CustomColors
    End Sub

    Private Sub darkSquareClick(sender As Object, e As EventArgs) Handles dPanel.Click
        Dim x As New ColorDialog
        x.CustomColors = New Integer() {15866945}
        x.ShowDialog()
        dPanel.BackColor = x.Color
        Dim intl As Integer() = x.CustomColors
    End Sub

End Class
Public Class SignupForm
    Private WithEvents dp As cAccountDisplayPicture

#Region "drag-drop"
    ''drag-drop functionality''
    Private _xStart As Integer
    Private _yStart As Integer
    Private Sub e_form_mousedown(sender As Object, e As MouseEventArgs) Handles TitleStripPanel.MouseDown, MyBase.MouseDown, TitleLabel.MouseDown
        _xStart = e.X : _yStart = e.Y
    End Sub
    Private Sub e_form_dragdrop(sender As Object, e As MouseEventArgs) Handles TitleStripPanel.MouseMove, MyBase.MouseMove, TitleLabel.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location = New Point(Me.Left + e.X - _xStart, Me.Top + e.Y - _yStart)
        End If
    End Sub
#End Region

    Private Sub e_closebutton_click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub e_load(sender As Object, e As EventArgs) Handles MyBase.Load
        dp = New cAccountDisplayPicture
        Me.Controls.Add(dp)
        dp.Size = New Size(100, 100)
        dp.Location = New Point(CInt((Me.Width / 2) - 50), 40)
        dp.Cursor = Cursors.Hand
        Me.DialogResult = DialogResult.None
    End Sub

    Private Sub e_dp_clicked(sender As Object, e As MouseEventArgs) Handles dp.MouseClick
        If (e.Button = MouseButtons.Left) Then
            Using dialog As OpenFileDialog = New OpenFileDialog
                dialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*"
                If (dialog.ShowDialog = DialogResult.OK) Then
                    Dim path As String = dialog.FileName
                    If (IO.File.Exists(path)) Then
                        Try
                            Dim b As Bitmap = New Bitmap(path)
                            Me.dp.Image = b
                        Catch ex As Exception
                            MsgBox("Image could not be loaded, please try a different image.")
                        End Try
                    End If
                End If
            End Using
        ElseIf (e.Button = MouseButtons.Right) Then
            Me.dp.reset_image()
        End If
    End Sub

    Private Function valid_username() As Boolean
        If Me.username_textbox.Text.Length > 3 AndAlso Me.username_textbox.Text.Length < 21 Then
            Return True
        End If
        Return False
    End Function
    Private Function valid_password() As Boolean
        If password_textbox.Text.Length > 4 AndAlso password_textbox.Text.Length < 21 Then
            If password_textbox.Text = password_confirm_textbox.Text Then
                Return True
            Else
                Return False
            End If
        End If
        Return False
    End Function

    Private Sub e_signup_click(sender As Object, e As EventArgs) Handles create_button.Click
        Dim errormsg As String = Nothing
        If valid_username() AndAlso valid_password() Then
            Dim uname As String = Me.username_textbox.Text : Dim phash As String = cAccount.hash_pword(Me.password_textbox.Text)
            Dim elo As Integer = CInt(Me.elo_nud.Value) : Dim pic As Bitmap = New Bitmap(Me.dp.Image)
            cAccount.generate_account(uname, phash, elo, pic)
            Me.DialogResult = DialogResult.Yes
            Me.Close()
            Me.Dispose()
        ElseIf Not valid_password Then
            MsgBox("Your passwords don't match! Please re-enter them.")
        Else
            MsgBox("ERROR:" & vbCrLf & "Please ensure your password is between 5-20 characters, and your username is between 4-20 characters.")
        End If
    End Sub

    Private Sub e_keydown(sender As Object, e As KeyEventArgs) Handles password_textbox.KeyDown, username_textbox.KeyDown, elo_nud.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e_signup_click(create_button, Nothing)
        End If
    End Sub

End Class
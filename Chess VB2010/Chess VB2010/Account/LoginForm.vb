Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Public Class LoginForm

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

    Private Sub e_closebutton_click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub e_loginbutton_click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim username As String = Me.usernameTextbox.Text
        Dim password As String = Me.passwordTextbox.Text
        Dim pSource As String = cAccount.hash_pword(password)

        Dim response As Tuple(Of cAccount.login_response, cAccount) = cAccount.login(username, pSource)
        If response.Item1 = cAccount.login_response.valid Then

        End If
        Select Case response.Item1
            Case cAccount.login_response.valid
                InterfaceForm.e_login_successful(response.Item2)
                Me.Close()
                Me.Dispose()
            Case cAccount.login_response.username_invalid
                MessageBox.Show("Username is invalid. Please try again.", "Invalid login:")
            Case cAccount.login_response.password_invalid
                MessageBox.Show("Password is invalid. Please try again", "Invalid login:")
        End Select
    End Sub


End Class
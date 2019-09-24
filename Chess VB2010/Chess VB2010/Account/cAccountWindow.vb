Public Class cAccountWindow
    Inherits Panel

    Private _account As cAccount

    Private _dp As cAccountDisplayPicture
    Private _nameplate As Label
    Private _eloplate As Label

    Private Event account_changed As EventHandler

#Region "Mutators & Accessors"
    Public Sub set_account(ByRef val As cAccount)
        Me._account = val
        RaiseEvent account_changed(Me, Nothing)
    End Sub
#End Region

    Public Sub New(a As cAccount)
        Me._account = a
        Me.BackColor = Color.FromArgb(40, 40, 40)
        Me.init_components()
    End Sub

    Private Sub init_components()
        Me._dp = New cAccountDisplayPicture : Me._nameplate = New Label : Me._eloplate = New Label
        Me._dp.Image = Me._account.get_avi
        Me._nameplate.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold) : Me._nameplate.ForeColor = Color.White
        Me._eloplate.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold) : Me._eloplate.ForeColor = Color.White
        Me._nameplate.AutoSize = True : Me._eloplate.AutoSize = True
        Me.Controls.Add(Me._dp) : Me.Controls.Add(Me._nameplate) : Me.Controls.Add(Me._eloplate)
        Me._nameplate.Text = Me._account.get_username()
        Me._eloplate.Text = Me._account.get_elo.ToString & "  (" & Me._account.get_wins().ToString & "-" & Me._account.get_draws().ToString & "-" & Me._account.get_losses.ToString & ")"
    End Sub

    Private Sub e_account_changed(sender As Object, e As EventArgs) Handles Me.account_changed
        Me._dp.Image = Me._account.get_avi : Me._nameplate.Text = Me._account.get_username
        Me._eloplate.Text = Me._account.get_elo.ToString & Me._account.get_wins().ToString & "-" & Me._account.get_draws().ToString & "-" & Me._account.get_losses.ToString
    End Sub

    Private Sub e_resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim max As Integer : If Me.Width > Me.Height Then max = Me.Height Else max = Me.Width
        Me._dp.Size = New Size(max - 3, max - 3) : Me._nameplate.Location = New Point(max + 5, 8)
        Me._eloplate.Location = New Point(max + 5, Me._eloplate.Height + Me._nameplate.Height)
    End Sub

End Class
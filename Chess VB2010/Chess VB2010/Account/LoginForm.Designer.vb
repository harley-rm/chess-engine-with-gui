<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TitleStripPanel = New System.Windows.Forms.Panel()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.MenuStripPanel = New System.Windows.Forms.Panel()
        Me.CloseButton = New System.Windows.Forms.Label()
        Me.LoginButton = New System.Windows.Forms.Label()
        Me.usernameLbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.usernameTextbox = New System.Windows.Forms.TextBox()
        Me.passwordTextbox = New System.Windows.Forms.TextBox()
        Me.TitleStripPanel.SuspendLayout()
        Me.MenuStripPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleStripPanel
        '
        Me.TitleStripPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleStripPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TitleStripPanel.Controls.Add(Me.TitleLabel)
        Me.TitleStripPanel.Location = New System.Drawing.Point(-1, -2)
        Me.TitleStripPanel.Name = "TitleStripPanel"
        Me.TitleStripPanel.Size = New System.Drawing.Size(647, 31)
        Me.TitleStripPanel.TabIndex = 3
        '
        'TitleLabel
        '
        Me.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.TitleLabel.Location = New System.Drawing.Point(295, 2)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(57, 26)
        Me.TitleLabel.TabIndex = 3
        Me.TitleLabel.Text = "login"
        '
        'MenuStripPanel
        '
        Me.MenuStripPanel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MenuStripPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.MenuStripPanel.Controls.Add(Me.CloseButton)
        Me.MenuStripPanel.Controls.Add(Me.LoginButton)
        Me.MenuStripPanel.Location = New System.Drawing.Point(266, 207)
        Me.MenuStripPanel.Name = "MenuStripPanel"
        Me.MenuStripPanel.Size = New System.Drawing.Size(114, 24)
        Me.MenuStripPanel.TabIndex = 4
        '
        'CloseButton
        '
        Me.CloseButton.AutoSize = True
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseButton.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.CloseButton.Location = New System.Drawing.Point(56, 2)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(54, 19)
        Me.CloseButton.TabIndex = 3
        Me.CloseButton.Text = "Cancel"
        '
        'LoginButton
        '
        Me.LoginButton.AutoSize = True
        Me.LoginButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoginButton.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.LoginButton.Location = New System.Drawing.Point(3, 2)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(47, 19)
        Me.LoginButton.TabIndex = 0
        Me.LoginButton.Text = "Login"
        '
        'usernameLbl
        '
        Me.usernameLbl.AutoSize = True
        Me.usernameLbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.usernameLbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.usernameLbl.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usernameLbl.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.usernameLbl.Location = New System.Drawing.Point(174, 85)
        Me.usernameLbl.Name = "usernameLbl"
        Me.usernameLbl.Size = New System.Drawing.Size(77, 19)
        Me.usernameLbl.TabIndex = 4
        Me.usernameLbl.Text = "username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Location = New System.Drawing.Point(174, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "password"
        '
        'usernameTextbox
        '
        Me.usernameTextbox.Location = New System.Drawing.Point(258, 84)
        Me.usernameTextbox.Name = "usernameTextbox"
        Me.usernameTextbox.Size = New System.Drawing.Size(215, 20)
        Me.usernameTextbox.TabIndex = 6
        '
        'passwordTextbox
        '
        Me.passwordTextbox.Location = New System.Drawing.Point(258, 122)
        Me.passwordTextbox.Name = "passwordTextbox"
        Me.passwordTextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordTextbox.Size = New System.Drawing.Size(215, 20)
        Me.passwordTextbox.TabIndex = 7
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(646, 245)
        Me.Controls.Add(Me.passwordTextbox)
        Me.Controls.Add(Me.usernameTextbox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.usernameLbl)
        Me.Controls.Add(Me.MenuStripPanel)
        Me.Controls.Add(Me.TitleStripPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LoginForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LoginForm"
        Me.TitleStripPanel.ResumeLayout(False)
        Me.TitleStripPanel.PerformLayout()
        Me.MenuStripPanel.ResumeLayout(False)
        Me.MenuStripPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TitleStripPanel As Panel
    Friend WithEvents TitleLabel As Label
    Friend WithEvents MenuStripPanel As Panel
    Friend WithEvents CloseButton As Label
    Friend WithEvents LoginButton As Label
    Friend WithEvents usernameLbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents usernameTextbox As TextBox
    Friend WithEvents passwordTextbox As TextBox
End Class

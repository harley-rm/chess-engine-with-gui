<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignupForm
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
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.TitleStripPanel = New System.Windows.Forms.Panel()
        Me.password_textbox = New System.Windows.Forms.TextBox()
        Me.username_textbox = New System.Windows.Forms.TextBox()
        Me.passwordLbl = New System.Windows.Forms.Label()
        Me.usernameLbl = New System.Windows.Forms.Label()
        Me.MenuStripPanel = New System.Windows.Forms.Panel()
        Me.CloseButton = New System.Windows.Forms.Label()
        Me.create_button = New System.Windows.Forms.Label()
        Me.eloLbl = New System.Windows.Forms.Label()
        Me.elo_nud = New System.Windows.Forms.NumericUpDown()
        Me.password_confirm_textbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TitleStripPanel.SuspendLayout()
        Me.MenuStripPanel.SuspendLayout()
        CType(Me.elo_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitleLabel
        '
        Me.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.TitleLabel.Location = New System.Drawing.Point(291, 2)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(73, 26)
        Me.TitleLabel.TabIndex = 3
        Me.TitleLabel.Text = "signup"
        '
        'TitleStripPanel
        '
        Me.TitleStripPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleStripPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TitleStripPanel.Controls.Add(Me.TitleLabel)
        Me.TitleStripPanel.Location = New System.Drawing.Point(-5, -1)
        Me.TitleStripPanel.Name = "TitleStripPanel"
        Me.TitleStripPanel.Size = New System.Drawing.Size(654, 31)
        Me.TitleStripPanel.TabIndex = 4
        '
        'password_textbox
        '
        Me.password_textbox.Location = New System.Drawing.Point(258, 193)
        Me.password_textbox.Name = "password_textbox"
        Me.password_textbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password_textbox.Size = New System.Drawing.Size(215, 20)
        Me.password_textbox.TabIndex = 11
        '
        'username_textbox
        '
        Me.username_textbox.Location = New System.Drawing.Point(258, 156)
        Me.username_textbox.Name = "username_textbox"
        Me.username_textbox.Size = New System.Drawing.Size(215, 20)
        Me.username_textbox.TabIndex = 10
        '
        'passwordLbl
        '
        Me.passwordLbl.AutoSize = True
        Me.passwordLbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.passwordLbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.passwordLbl.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordLbl.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.passwordLbl.Location = New System.Drawing.Point(174, 193)
        Me.passwordLbl.Name = "passwordLbl"
        Me.passwordLbl.Size = New System.Drawing.Size(75, 19)
        Me.passwordLbl.TabIndex = 9
        Me.passwordLbl.Text = "password"
        '
        'usernameLbl
        '
        Me.usernameLbl.AutoSize = True
        Me.usernameLbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.usernameLbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.usernameLbl.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usernameLbl.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.usernameLbl.Location = New System.Drawing.Point(174, 157)
        Me.usernameLbl.Name = "usernameLbl"
        Me.usernameLbl.Size = New System.Drawing.Size(77, 19)
        Me.usernameLbl.TabIndex = 8
        Me.usernameLbl.Text = "username"
        '
        'MenuStripPanel
        '
        Me.MenuStripPanel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MenuStripPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.MenuStripPanel.Controls.Add(Me.CloseButton)
        Me.MenuStripPanel.Controls.Add(Me.create_button)
        Me.MenuStripPanel.Location = New System.Drawing.Point(264, 303)
        Me.MenuStripPanel.Name = "MenuStripPanel"
        Me.MenuStripPanel.Size = New System.Drawing.Size(119, 24)
        Me.MenuStripPanel.TabIndex = 12
        '
        'CloseButton
        '
        Me.CloseButton.AutoSize = True
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseButton.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.CloseButton.Location = New System.Drawing.Point(59, 2)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(54, 19)
        Me.CloseButton.TabIndex = 3
        Me.CloseButton.Text = "Cancel"
        '
        'create_button
        '
        Me.create_button.AutoSize = True
        Me.create_button.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.create_button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.create_button.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.create_button.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.create_button.Location = New System.Drawing.Point(3, 2)
        Me.create_button.Name = "create_button"
        Me.create_button.Size = New System.Drawing.Size(54, 19)
        Me.create_button.TabIndex = 0
        Me.create_button.Text = "Create"
        '
        'eloLbl
        '
        Me.eloLbl.AutoSize = True
        Me.eloLbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.eloLbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.eloLbl.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eloLbl.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.eloLbl.Location = New System.Drawing.Point(213, 261)
        Me.eloLbl.Name = "eloLbl"
        Me.eloLbl.Size = New System.Drawing.Size(36, 19)
        Me.eloLbl.TabIndex = 13
        Me.eloLbl.Text = "ELO"
        '
        'elo_nud
        '
        Me.elo_nud.Location = New System.Drawing.Point(258, 260)
        Me.elo_nud.Maximum = New Decimal(New Integer() {3500, 0, 0, 0})
        Me.elo_nud.Minimum = New Decimal(New Integer() {800, 0, 0, 0})
        Me.elo_nud.Name = "elo_nud"
        Me.elo_nud.Size = New System.Drawing.Size(215, 20)
        Me.elo_nud.TabIndex = 16
        Me.elo_nud.Value = New Decimal(New Integer() {800, 0, 0, 0})
        '
        'password_confirm_textbox
        '
        Me.password_confirm_textbox.Location = New System.Drawing.Point(258, 221)
        Me.password_confirm_textbox.Name = "password_confirm_textbox"
        Me.password_confirm_textbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password_confirm_textbox.Size = New System.Drawing.Size(215, 20)
        Me.password_confirm_textbox.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Location = New System.Drawing.Point(187, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "confirm"
        '
        'SignupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(646, 342)
        Me.Controls.Add(Me.password_confirm_textbox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.elo_nud)
        Me.Controls.Add(Me.eloLbl)
        Me.Controls.Add(Me.MenuStripPanel)
        Me.Controls.Add(Me.password_textbox)
        Me.Controls.Add(Me.username_textbox)
        Me.Controls.Add(Me.passwordLbl)
        Me.Controls.Add(Me.usernameLbl)
        Me.Controls.Add(Me.TitleStripPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SignupForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TitleStripPanel.ResumeLayout(False)
        Me.TitleStripPanel.PerformLayout()
        Me.MenuStripPanel.ResumeLayout(False)
        Me.MenuStripPanel.PerformLayout()
        CType(Me.elo_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TitleLabel As Label
    Friend WithEvents TitleStripPanel As Panel
    Friend WithEvents password_textbox As TextBox
    Friend WithEvents username_textbox As TextBox
    Friend WithEvents passwordLbl As Label
    Friend WithEvents usernameLbl As Label
    Friend WithEvents MenuStripPanel As Panel
    Friend WithEvents CloseButton As Label
    Friend WithEvents create_button As Label
    Friend WithEvents eloLbl As Label
    Friend WithEvents elo_nud As NumericUpDown
    Friend WithEvents password_confirm_textbox As TextBox
    Friend WithEvents Label1 As Label
End Class

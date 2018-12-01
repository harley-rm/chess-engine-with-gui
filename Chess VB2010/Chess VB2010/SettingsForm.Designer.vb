<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.TitleStripPanel = New System.Windows.Forms.Panel()
        Me.MenuStripPanel = New System.Windows.Forms.Panel()
        Me.CloseButton = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lPanel = New System.Windows.Forms.Panel()
        Me.dPanel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.showLegalCB = New System.Windows.Forms.CheckBox()
        Me.cheatsCB = New System.Windows.Forms.CheckBox()
        Me.nightModeCB = New System.Windows.Forms.CheckBox()
        Me.TitleStripPanel.SuspendLayout()
        Me.MenuStripPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleLabel
        '
        Me.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.TitleLabel.Location = New System.Drawing.Point(135, 2)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(83, 26)
        Me.TitleLabel.TabIndex = 3
        Me.TitleLabel.Text = "settings"
        '
        'TitleStripPanel
        '
        Me.TitleStripPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleStripPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TitleStripPanel.Controls.Add(Me.TitleLabel)
        Me.TitleStripPanel.Location = New System.Drawing.Point(-2, -1)
        Me.TitleStripPanel.Name = "TitleStripPanel"
        Me.TitleStripPanel.Size = New System.Drawing.Size(353, 31)
        Me.TitleStripPanel.TabIndex = 2
        '
        'MenuStripPanel
        '
        Me.MenuStripPanel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MenuStripPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.MenuStripPanel.Controls.Add(Me.CloseButton)
        Me.MenuStripPanel.Controls.Add(Me.SaveButton)
        Me.MenuStripPanel.Location = New System.Drawing.Point(126, 385)
        Me.MenuStripPanel.Name = "MenuStripPanel"
        Me.MenuStripPanel.Size = New System.Drawing.Size(98, 24)
        Me.MenuStripPanel.TabIndex = 3
        '
        'CloseButton
        '
        Me.CloseButton.AutoSize = True
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseButton.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.CloseButton.Location = New System.Drawing.Point(49, 2)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(46, 19)
        Me.CloseButton.TabIndex = 3
        Me.CloseButton.Text = "Close"
        '
        'SaveButton
        '
        Me.SaveButton.AutoSize = True
        Me.SaveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveButton.Font = New System.Drawing.Font("Open Sans SemiBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.SaveButton.Location = New System.Drawing.Point(3, 2)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(40, 19)
        Me.SaveButton.TabIndex = 0
        Me.SaveButton.Text = "Save"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "tiles:"
        '
        'lPanel
        '
        Me.lPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lPanel.Location = New System.Drawing.Point(113, 63)
        Me.lPanel.Name = "lPanel"
        Me.lPanel.Size = New System.Drawing.Size(80, 26)
        Me.lPanel.TabIndex = 5
        '
        'dPanel
        '
        Me.dPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dPanel.Location = New System.Drawing.Point(241, 63)
        Me.dPanel.Name = "dPanel"
        Me.dPanel.Size = New System.Drawing.Size(80, 26)
        Me.dPanel.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(77, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 26)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "(L)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(202, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 26)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "(D)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(12, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 26)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "show legal:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(12, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 26)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "cheats:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Open Sans SemiBold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(12, 257)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 26)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "night mode:"
        '
        'showLegalCB
        '
        Me.showLegalCB.AutoSize = True
        Me.showLegalCB.Location = New System.Drawing.Point(132, 147)
        Me.showLegalCB.Name = "showLegalCB"
        Me.showLegalCB.Size = New System.Drawing.Size(15, 14)
        Me.showLegalCB.TabIndex = 12
        Me.showLegalCB.UseVisualStyleBackColor = True
        '
        'cheatsCB
        '
        Me.cheatsCB.AutoSize = True
        Me.cheatsCB.Location = New System.Drawing.Point(94, 205)
        Me.cheatsCB.Name = "cheatsCB"
        Me.cheatsCB.Size = New System.Drawing.Size(15, 14)
        Me.cheatsCB.TabIndex = 13
        Me.cheatsCB.UseVisualStyleBackColor = True
        '
        'nightModeCB
        '
        Me.nightModeCB.AutoSize = True
        Me.nightModeCB.Location = New System.Drawing.Point(140, 266)
        Me.nightModeCB.Name = "nightModeCB"
        Me.nightModeCB.Size = New System.Drawing.Size(15, 14)
        Me.nightModeCB.TabIndex = 14
        Me.nightModeCB.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(350, 421)
        Me.Controls.Add(Me.nightModeCB)
        Me.Controls.Add(Me.cheatsCB)
        Me.Controls.Add(Me.showLegalCB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dPanel)
        Me.Controls.Add(Me.lPanel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStripPanel)
        Me.Controls.Add(Me.TitleStripPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TopMost = True
        Me.TitleStripPanel.ResumeLayout(False)
        Me.TitleStripPanel.PerformLayout()
        Me.MenuStripPanel.ResumeLayout(False)
        Me.MenuStripPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TitleLabel As Label
    Friend WithEvents TitleStripPanel As Panel
    Friend WithEvents MenuStripPanel As Panel
    Friend WithEvents CloseButton As Label
    Friend WithEvents SaveButton As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lPanel As Panel
    Friend WithEvents dPanel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents showLegalCB As CheckBox
    Friend WithEvents cheatsCB As CheckBox
    Friend WithEvents nightModeCB As CheckBox
End Class

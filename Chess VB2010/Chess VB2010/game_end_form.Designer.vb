<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class game_end_form
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
        Me.announce_label = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.new_game_label = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'announce_label
        '
        Me.announce_label.AutoSize = True
        Me.announce_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.announce_label.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.announce_label.Location = New System.Drawing.Point(59, 25)
        Me.announce_label.Name = "announce_label"
        Me.announce_label.Size = New System.Drawing.Size(117, 24)
        Me.announce_label.TabIndex = 0
        Me.announce_label.Text = "White wins!"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Panel1.Controls.Add(Me.new_game_label)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Location = New System.Drawing.Point(61, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(113, 29)
        Me.Panel1.TabIndex = 1
        '
        'new_game_label
        '
        Me.new_game_label.AutoSize = True
        Me.new_game_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.new_game_label.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.new_game_label.Location = New System.Drawing.Point(11, 3)
        Me.new_game_label.Name = "new_game_label"
        Me.new_game_label.Size = New System.Drawing.Size(90, 20)
        Me.new_game_label.TabIndex = 1
        Me.new_game_label.Text = "new game"
        '
        'game_end_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(234, 120)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.announce_label)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "game_end_form"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "NewGameForm"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents announce_label As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents new_game_label As Label
End Class

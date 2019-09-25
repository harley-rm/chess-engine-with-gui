<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InterfaceForm
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
        Me.TitleStripPanel = New System.Windows.Forms.Panel()
        Me.sign_up_label = New System.Windows.Forms.Label()
        Me.login_out_label = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.PictureBox()
        Me.MaximizeButton = New System.Windows.Forms.PictureBox()
        Me.MinimizeButton = New System.Windows.Forms.PictureBox()
        Me.MenuStripPanel = New System.Windows.Forms.Panel()
        Me.SettingsButton = New System.Windows.Forms.Label()
        Me.AnalysisButton = New System.Windows.Forms.Label()
        Me.OnlineButton = New System.Windows.Forms.Label()
        Me.PlayButton = New System.Windows.Forms.Label()
        Me.nwseResizeButton = New System.Windows.Forms.Panel()
        Me.hrzResizeButton = New System.Windows.Forms.Panel()
        Me.vrtResizeButton = New System.Windows.Forms.Panel()
        Me.FlipBoardButton = New System.Windows.Forms.PictureBox()
        Me.ShowEngineEvalButton = New System.Windows.Forms.PictureBox()
        Me.UndoMoveButton = New System.Windows.Forms.PictureBox()
        Me.NewGameButton = New System.Windows.Forms.PictureBox()
        Me.MenuCollapseButton = New System.Windows.Forms.Panel()
        Me.TitleStripPanel.SuspendLayout()
        CType(Me.CloseButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaximizeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimizeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStripPanel.SuspendLayout()
        CType(Me.FlipBoardButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShowEngineEvalButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UndoMoveButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewGameButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitleStripPanel
        '
        Me.TitleStripPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleStripPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TitleStripPanel.Controls.Add(Me.sign_up_label)
        Me.TitleStripPanel.Controls.Add(Me.login_out_label)
        Me.TitleStripPanel.Controls.Add(Me.TitleLabel)
        Me.TitleStripPanel.Controls.Add(Me.CloseButton)
        Me.TitleStripPanel.Controls.Add(Me.MaximizeButton)
        Me.TitleStripPanel.Controls.Add(Me.MinimizeButton)
        Me.TitleStripPanel.Location = New System.Drawing.Point(-8, -2)
        Me.TitleStripPanel.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TitleStripPanel.Name = "TitleStripPanel"
        Me.TitleStripPanel.Size = New System.Drawing.Size(1978, 60)
        Me.TitleStripPanel.TabIndex = 1
        '
        'sign_up_label
        '
        Me.sign_up_label.AutoSize = True
        Me.sign_up_label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.sign_up_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sign_up_label.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.sign_up_label.Location = New System.Drawing.Point(16, 19)
        Me.sign_up_label.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.sign_up_label.Name = "sign_up_label"
        Me.sign_up_label.Size = New System.Drawing.Size(98, 26)
        Me.sign_up_label.TabIndex = 5
        Me.sign_up_label.Text = "Sign-Up"
        '
        'login_out_label
        '
        Me.login_out_label.AutoSize = True
        Me.login_out_label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.login_out_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.login_out_label.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.login_out_label.Location = New System.Drawing.Point(128, 19)
        Me.login_out_label.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.login_out_label.Name = "login_out_label"
        Me.login_out_label.Size = New System.Drawing.Size(77, 26)
        Me.login_out_label.TabIndex = 4
        Me.login_out_label.Text = "Log in"
        '
        'TitleLabel
        '
        Me.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.TitleLabel.Location = New System.Drawing.Point(910, 8)
        Me.TitleLabel.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(124, 44)
        Me.TitleLabel.TabIndex = 3
        Me.TitleLabel.Text = "chess"
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseButton.Image = Global.chess.My.Resources.Resources.close_window
        Me.CloseButton.Location = New System.Drawing.Point(1896, 6)
        Me.CloseButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(46, 44)
        Me.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CloseButton.TabIndex = 2
        Me.CloseButton.TabStop = False
        '
        'MaximizeButton
        '
        Me.MaximizeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaximizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MaximizeButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MaximizeButton.Image = Global.chess.My.Resources.Resources.maximize_window
        Me.MaximizeButton.Location = New System.Drawing.Point(1840, 6)
        Me.MaximizeButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MaximizeButton.Name = "MaximizeButton"
        Me.MaximizeButton.Size = New System.Drawing.Size(46, 44)
        Me.MaximizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MaximizeButton.TabIndex = 1
        Me.MaximizeButton.TabStop = False
        '
        'MinimizeButton
        '
        Me.MinimizeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MinimizeButton.Image = Global.chess.My.Resources.Resources.minimize_window
        Me.MinimizeButton.Location = New System.Drawing.Point(1784, 6)
        Me.MinimizeButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MinimizeButton.Name = "MinimizeButton"
        Me.MinimizeButton.Size = New System.Drawing.Size(46, 44)
        Me.MinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MinimizeButton.TabIndex = 0
        Me.MinimizeButton.TabStop = False
        '
        'MenuStripPanel
        '
        Me.MenuStripPanel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MenuStripPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.MenuStripPanel.Controls.Add(Me.SettingsButton)
        Me.MenuStripPanel.Controls.Add(Me.AnalysisButton)
        Me.MenuStripPanel.Controls.Add(Me.OnlineButton)
        Me.MenuStripPanel.Controls.Add(Me.PlayButton)
        Me.MenuStripPanel.Location = New System.Drawing.Point(734, 77)
        Me.MenuStripPanel.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MenuStripPanel.Name = "MenuStripPanel"
        Me.MenuStripPanel.Size = New System.Drawing.Size(492, 46)
        Me.MenuStripPanel.TabIndex = 2
        '
        'SettingsButton
        '
        Me.SettingsButton.AutoSize = True
        Me.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SettingsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.SettingsButton.Location = New System.Drawing.Point(356, 8)
        Me.SettingsButton.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(121, 31)
        Me.SettingsButton.TabIndex = 3
        Me.SettingsButton.Text = "Settings"
        '
        'AnalysisButton
        '
        Me.AnalysisButton.AutoSize = True
        Me.AnalysisButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AnalysisButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnalysisButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.AnalysisButton.Location = New System.Drawing.Point(214, 8)
        Me.AnalysisButton.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.AnalysisButton.Name = "AnalysisButton"
        Me.AnalysisButton.Size = New System.Drawing.Size(124, 31)
        Me.AnalysisButton.TabIndex = 2
        Me.AnalysisButton.Text = "Analysis"
        '
        'OnlineButton
        '
        Me.OnlineButton.AutoSize = True
        Me.OnlineButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OnlineButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OnlineButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.OnlineButton.Location = New System.Drawing.Point(94, 8)
        Me.OnlineButton.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.OnlineButton.Name = "OnlineButton"
        Me.OnlineButton.Size = New System.Drawing.Size(98, 31)
        Me.OnlineButton.TabIndex = 1
        Me.OnlineButton.Text = "Online"
        '
        'PlayButton
        '
        Me.PlayButton.AutoSize = True
        Me.PlayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PlayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.PlayButton.Location = New System.Drawing.Point(6, 8)
        Me.PlayButton.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(71, 31)
        Me.PlayButton.TabIndex = 0
        Me.PlayButton.Text = "Play"
        '
        'nwseResizeButton
        '
        Me.nwseResizeButton.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.nwseResizeButton.Location = New System.Drawing.Point(1942, 1067)
        Me.nwseResizeButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.nwseResizeButton.Name = "nwseResizeButton"
        Me.nwseResizeButton.Size = New System.Drawing.Size(22, 23)
        Me.nwseResizeButton.TabIndex = 4
        '
        'hrzResizeButton
        '
        Me.hrzResizeButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.hrzResizeButton.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.hrzResizeButton.Location = New System.Drawing.Point(1942, 60)
        Me.hrzResizeButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.hrzResizeButton.Name = "hrzResizeButton"
        Me.hrzResizeButton.Size = New System.Drawing.Size(22, 1006)
        Me.hrzResizeButton.TabIndex = 5
        '
        'vrtResizeButton
        '
        Me.vrtResizeButton.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.vrtResizeButton.Location = New System.Drawing.Point(-8, 1067)
        Me.vrtResizeButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.vrtResizeButton.Name = "vrtResizeButton"
        Me.vrtResizeButton.Size = New System.Drawing.Size(1946, 23)
        Me.vrtResizeButton.TabIndex = 5
        '
        'FlipBoardButton
        '
        Me.FlipBoardButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlipBoardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.FlipBoardButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlipBoardButton.Image = Global.chess.My.Resources.Resources.flip_board
        Me.FlipBoardButton.Location = New System.Drawing.Point(1658, 81)
        Me.FlipBoardButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.FlipBoardButton.Name = "FlipBoardButton"
        Me.FlipBoardButton.Size = New System.Drawing.Size(46, 44)
        Me.FlipBoardButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FlipBoardButton.TabIndex = 7
        Me.FlipBoardButton.TabStop = False
        '
        'ShowEngineEvalButton
        '
        Me.ShowEngineEvalButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShowEngineEvalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ShowEngineEvalButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ShowEngineEvalButton.Image = Global.chess.My.Resources.Resources.show_engine_move
        Me.ShowEngineEvalButton.Location = New System.Drawing.Point(1876, 81)
        Me.ShowEngineEvalButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ShowEngineEvalButton.Name = "ShowEngineEvalButton"
        Me.ShowEngineEvalButton.Size = New System.Drawing.Size(46, 44)
        Me.ShowEngineEvalButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ShowEngineEvalButton.TabIndex = 6
        Me.ShowEngineEvalButton.TabStop = False
        '
        'UndoMoveButton
        '
        Me.UndoMoveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UndoMoveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.UndoMoveButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UndoMoveButton.Image = Global.chess.My.Resources.Resources.undo_move
        Me.UndoMoveButton.Location = New System.Drawing.Point(1798, 81)
        Me.UndoMoveButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.UndoMoveButton.Name = "UndoMoveButton"
        Me.UndoMoveButton.Size = New System.Drawing.Size(46, 44)
        Me.UndoMoveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.UndoMoveButton.TabIndex = 5
        Me.UndoMoveButton.TabStop = False
        '
        'NewGameButton
        '
        Me.NewGameButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NewGameButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NewGameButton.Image = Global.chess.My.Resources.Resources.new_game
        Me.NewGameButton.Location = New System.Drawing.Point(1736, 81)
        Me.NewGameButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.NewGameButton.Name = "NewGameButton"
        Me.NewGameButton.Size = New System.Drawing.Size(46, 44)
        Me.NewGameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.NewGameButton.TabIndex = 4
        Me.NewGameButton.TabStop = False
        '
        'MenuCollapseButton
        '
        Me.MenuCollapseButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MenuCollapseButton.BackgroundImage = Global.chess.My.Resources.Resources.arrow_left
        Me.MenuCollapseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuCollapseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MenuCollapseButton.Location = New System.Drawing.Point(674, 77)
        Me.MenuCollapseButton.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MenuCollapseButton.Name = "MenuCollapseButton"
        Me.MenuCollapseButton.Size = New System.Drawing.Size(48, 46)
        Me.MenuCollapseButton.TabIndex = 3
        '
        'InterfaceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1962, 1088)
        Me.Controls.Add(Me.FlipBoardButton)
        Me.Controls.Add(Me.ShowEngineEvalButton)
        Me.Controls.Add(Me.UndoMoveButton)
        Me.Controls.Add(Me.vrtResizeButton)
        Me.Controls.Add(Me.NewGameButton)
        Me.Controls.Add(Me.hrzResizeButton)
        Me.Controls.Add(Me.nwseResizeButton)
        Me.Controls.Add(Me.MenuCollapseButton)
        Me.Controls.Add(Me.MenuStripPanel)
        Me.Controls.Add(Me.TitleStripPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "InterfaceForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "litchess"
        Me.TitleStripPanel.ResumeLayout(False)
        Me.TitleStripPanel.PerformLayout()
        CType(Me.CloseButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaximizeButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimizeButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStripPanel.ResumeLayout(False)
        Me.MenuStripPanel.PerformLayout()
        CType(Me.FlipBoardButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShowEngineEvalButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UndoMoveButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewGameButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MinimizeButton As PictureBox
    Friend WithEvents TitleStripPanel As Panel
    Friend WithEvents TitleLabel As Label
    Friend WithEvents CloseButton As PictureBox
    Friend WithEvents MaximizeButton As PictureBox
    Friend WithEvents MenuStripPanel As Panel
    Friend WithEvents SettingsButton As Label
    Friend WithEvents AnalysisButton As Label
    Friend WithEvents OnlineButton As Label
    Friend WithEvents PlayButton As Label
    Friend WithEvents MenuCollapseButton As Panel
    Friend WithEvents nwseResizeButton As Panel
    Friend WithEvents hrzResizeButton As Panel
    Friend WithEvents vrtResizeButton As Panel
    Friend WithEvents ShowEngineEvalButton As PictureBox
    Friend WithEvents UndoMoveButton As PictureBox
    Friend WithEvents NewGameButton As PictureBox
    Friend WithEvents FlipBoardButton As PictureBox
    Friend WithEvents login_out_label As Label
    Friend WithEvents sign_up_label As Label
End Class

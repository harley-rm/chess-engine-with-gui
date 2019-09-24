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
        Me.media_controls_panel = New System.Windows.Forms.Panel()
        Me.select_button = New System.Windows.Forms.Button()
        Me.skip_button = New System.Windows.Forms.PictureBox()
        Me.start_stop_button = New System.Windows.Forms.PictureBox()
        Me.prev_button = New System.Windows.Forms.PictureBox()
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
        Me.media_controls_panel.SuspendLayout()
        CType(Me.skip_button, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.start_stop_button, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.prev_button, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TitleStripPanel.Location = New System.Drawing.Point(-4, -1)
        Me.TitleStripPanel.Name = "TitleStripPanel"
        Me.TitleStripPanel.Size = New System.Drawing.Size(989, 31)
        Me.TitleStripPanel.TabIndex = 1
        '
        'sign_up_label
        '
        Me.sign_up_label.AutoSize = True
        Me.sign_up_label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.sign_up_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sign_up_label.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.sign_up_label.Location = New System.Drawing.Point(8, 10)
        Me.sign_up_label.Name = "sign_up_label"
        Me.sign_up_label.Size = New System.Drawing.Size(52, 13)
        Me.sign_up_label.TabIndex = 5
        Me.sign_up_label.Text = "Sign-Up"
        '
        'login_out_label
        '
        Me.login_out_label.AutoSize = True
        Me.login_out_label.Cursor = System.Windows.Forms.Cursors.Hand
        Me.login_out_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.login_out_label.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.login_out_label.Location = New System.Drawing.Point(64, 10)
        Me.login_out_label.Name = "login_out_label"
        Me.login_out_label.Size = New System.Drawing.Size(42, 13)
        Me.login_out_label.TabIndex = 4
        Me.login_out_label.Text = "Log in"
        '
        'TitleLabel
        '
        Me.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.TitleLabel.Location = New System.Drawing.Point(455, 4)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(65, 24)
        Me.TitleLabel.TabIndex = 3
        Me.TitleLabel.Text = "chess"
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseButton.Image = Global.chess.My.Resources.Resources.close_window
        Me.CloseButton.Location = New System.Drawing.Point(954, 3)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(23, 23)
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
        Me.MaximizeButton.Location = New System.Drawing.Point(926, 3)
        Me.MaximizeButton.Name = "MaximizeButton"
        Me.MaximizeButton.Size = New System.Drawing.Size(23, 23)
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
        Me.MinimizeButton.Location = New System.Drawing.Point(898, 3)
        Me.MinimizeButton.Name = "MinimizeButton"
        Me.MinimizeButton.Size = New System.Drawing.Size(23, 23)
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
        Me.MenuStripPanel.Location = New System.Drawing.Point(367, 40)
        Me.MenuStripPanel.Name = "MenuStripPanel"
        Me.MenuStripPanel.Size = New System.Drawing.Size(246, 24)
        Me.MenuStripPanel.TabIndex = 2
        '
        'SettingsButton
        '
        Me.SettingsButton.AutoSize = True
        Me.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SettingsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.SettingsButton.Location = New System.Drawing.Point(178, 4)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(67, 17)
        Me.SettingsButton.TabIndex = 3
        Me.SettingsButton.Text = "Settings"
        '
        'AnalysisButton
        '
        Me.AnalysisButton.AutoSize = True
        Me.AnalysisButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AnalysisButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnalysisButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.AnalysisButton.Location = New System.Drawing.Point(107, 4)
        Me.AnalysisButton.Name = "AnalysisButton"
        Me.AnalysisButton.Size = New System.Drawing.Size(68, 17)
        Me.AnalysisButton.TabIndex = 2
        Me.AnalysisButton.Text = "Analysis"
        '
        'OnlineButton
        '
        Me.OnlineButton.AutoSize = True
        Me.OnlineButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OnlineButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OnlineButton.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.OnlineButton.Location = New System.Drawing.Point(47, 4)
        Me.OnlineButton.Name = "OnlineButton"
        Me.OnlineButton.Size = New System.Drawing.Size(55, 17)
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
        Me.PlayButton.Location = New System.Drawing.Point(3, 4)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(39, 17)
        Me.PlayButton.TabIndex = 0
        Me.PlayButton.Text = "Play"
        '
        'nwseResizeButton
        '
        Me.nwseResizeButton.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.nwseResizeButton.Location = New System.Drawing.Point(971, 555)
        Me.nwseResizeButton.Name = "nwseResizeButton"
        Me.nwseResizeButton.Size = New System.Drawing.Size(11, 12)
        Me.nwseResizeButton.TabIndex = 4
        '
        'hrzResizeButton
        '
        Me.hrzResizeButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.hrzResizeButton.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.hrzResizeButton.Location = New System.Drawing.Point(971, 31)
        Me.hrzResizeButton.Name = "hrzResizeButton"
        Me.hrzResizeButton.Size = New System.Drawing.Size(11, 523)
        Me.hrzResizeButton.TabIndex = 5
        '
        'vrtResizeButton
        '
        Me.vrtResizeButton.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.vrtResizeButton.Location = New System.Drawing.Point(-4, 555)
        Me.vrtResizeButton.Name = "vrtResizeButton"
        Me.vrtResizeButton.Size = New System.Drawing.Size(973, 12)
        Me.vrtResizeButton.TabIndex = 5
        '
        'media_controls_panel
        '
        Me.media_controls_panel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.media_controls_panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.media_controls_panel.Controls.Add(Me.select_button)
        Me.media_controls_panel.Controls.Add(Me.skip_button)
        Me.media_controls_panel.Controls.Add(Me.start_stop_button)
        Me.media_controls_panel.Controls.Add(Me.prev_button)
        Me.media_controls_panel.Location = New System.Drawing.Point(841, 71)
        Me.media_controls_panel.Name = "media_controls_panel"
        Me.media_controls_panel.Size = New System.Drawing.Size(99, 57)
        Me.media_controls_panel.TabIndex = 8
        Me.media_controls_panel.Visible = False
        '
        'select_button
        '
        Me.select_button.Location = New System.Drawing.Point(3, 4)
        Me.select_button.Name = "select_button"
        Me.select_button.Size = New System.Drawing.Size(92, 20)
        Me.select_button.TabIndex = 3
        Me.select_button.Text = "select playlist"
        Me.select_button.UseVisualStyleBackColor = True
        '
        'skip_button
        '
        Me.skip_button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.skip_button.Image = Global.chess.My.Resources.Resources.skip
        Me.skip_button.Location = New System.Drawing.Point(69, 29)
        Me.skip_button.Name = "skip_button"
        Me.skip_button.Size = New System.Drawing.Size(27, 23)
        Me.skip_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.skip_button.TabIndex = 2
        Me.skip_button.TabStop = False
        '
        'start_stop_button
        '
        Me.start_stop_button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.start_stop_button.Image = Global.chess.My.Resources.Resources.play
        Me.start_stop_button.Location = New System.Drawing.Point(36, 29)
        Me.start_stop_button.Name = "start_stop_button"
        Me.start_stop_button.Size = New System.Drawing.Size(27, 23)
        Me.start_stop_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.start_stop_button.TabIndex = 1
        Me.start_stop_button.TabStop = False
        '
        'prev_button
        '
        Me.prev_button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.prev_button.Image = Global.chess.My.Resources.Resources.previous
        Me.prev_button.Location = New System.Drawing.Point(3, 29)
        Me.prev_button.Name = "prev_button"
        Me.prev_button.Size = New System.Drawing.Size(27, 23)
        Me.prev_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.prev_button.TabIndex = 0
        Me.prev_button.TabStop = False
        '
        'FlipBoardButton
        '
        Me.FlipBoardButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlipBoardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.FlipBoardButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlipBoardButton.Image = Global.chess.My.Resources.Resources.flip_board
        Me.FlipBoardButton.Location = New System.Drawing.Point(824, 42)
        Me.FlipBoardButton.Name = "FlipBoardButton"
        Me.FlipBoardButton.Size = New System.Drawing.Size(23, 23)
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
        Me.ShowEngineEvalButton.Location = New System.Drawing.Point(938, 42)
        Me.ShowEngineEvalButton.Name = "ShowEngineEvalButton"
        Me.ShowEngineEvalButton.Size = New System.Drawing.Size(23, 23)
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
        Me.UndoMoveButton.Location = New System.Drawing.Point(899, 42)
        Me.UndoMoveButton.Name = "UndoMoveButton"
        Me.UndoMoveButton.Size = New System.Drawing.Size(23, 23)
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
        Me.NewGameButton.Location = New System.Drawing.Point(863, 42)
        Me.NewGameButton.Name = "NewGameButton"
        Me.NewGameButton.Size = New System.Drawing.Size(23, 23)
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
        Me.MenuCollapseButton.Location = New System.Drawing.Point(337, 40)
        Me.MenuCollapseButton.Name = "MenuCollapseButton"
        Me.MenuCollapseButton.Size = New System.Drawing.Size(24, 24)
        Me.MenuCollapseButton.TabIndex = 3
        '
        'InterfaceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(981, 566)
        Me.Controls.Add(Me.media_controls_panel)
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
        Me.media_controls_panel.ResumeLayout(False)
        CType(Me.skip_button, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.start_stop_button, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.prev_button, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents media_controls_panel As Panel
    Friend WithEvents prev_button As PictureBox
    Friend WithEvents start_stop_button As PictureBox
    Friend WithEvents skip_button As PictureBox
    Friend WithEvents select_button As Button
End Class

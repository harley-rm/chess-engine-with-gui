Public Structure sSettings
    Public lightSquare As Color
    Public darkSquare As Color
    Public showLegalMoves As Boolean
    Public enableCheats As Boolean
    Public nightMode As Boolean

    Public Shared Sub GenerateDefaultFile()
        Try
            Dim w As New System.IO.BinaryWriter(System.IO.File.Open(System.AppDomain.CurrentDomain.BaseDirectory & "\settings.ini", IO.FileMode.CreateNew))   'open or create the .ini file

            w.Write(CByte(255)) : w.Write(CByte(255)) : w.Write(CByte(255))     'RGB, lightsquare (off-white)
            w.Write(CByte(10)) : w.Write(CByte(10)) : w.Write(CByte(10))  'RGB, darksquare  (black)

            w.Write(True)   'show legal
            w.Write(True)   'enable cheats  
            w.Write(True)   'night mode

            w.Close()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub PutInEffect(FORM As InterfaceForm, GAME_GUI As cGameGUI)
        With (FORM)

            If Not (enableCheats) Then
                .UndoMoveButton.Hide()
                .ShowEngineEvalButton.Hide()
                .FlipBoardButton.Location = New Point(FORM.Width - 82, 42)
                .NewGameButton.Location = New Point(FORM.Width - 43, 42)
            Else
                .UndoMoveButton.Show()
                .ShowEngineEvalButton.Show()
                .FlipBoardButton.Location = New Point(FORM.Width - 157, 42)
                .NewGameButton.Location = New Point(FORM.Width - 118, 42)
            End If

            If Not (nightMode) Then
                .BackColor = Color.FromArgb(238, 233, 233)
                .vrtResizeButton.BackColor = Color.FromArgb(238, 233, 233)
                .hrzResizeButton.BackColor = Color.FromArgb(238, 233, 233)
            Else
                .BackColor = Color.FromArgb(27, 27, 27)
                .vrtResizeButton.BackColor = Color.FromArgb(27, 27, 27)
                .hrzResizeButton.BackColor = Color.FromArgb(27, 27, 27)
            End If

            If Not (showLegalMoves) Then
                GAME_GUI.getBoardGUI.setShowLegalMoves(False)
            Else
                GAME_GUI.getBoardGUI.setShowLegalMoves(True)
            End If

            GAME_GUI.getBoardGUI.setLightColor(Me.lightSquare)
            GAME_GUI.getBoardGUI.setDarkColor(Me.darkSquare)

            GAME_GUI.getBoardGUI.UpdateGraphics()
        End With
    End Sub

    Public Sub Load()

        If Not System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\settings.ini") Then
            sSettings.GenerateDefaultFile()
        End If

        Dim r As New System.IO.BinaryReader(System.IO.File.Open(System.AppDomain.CurrentDomain.BaseDirectory & "\settings.ini", IO.FileMode.Open))

        ' If r.BaseStream.Length <> 9 Then Throw New Exception("Settings.ini file not found.")

        Dim cR, cG, cB As Byte
        cR = r.ReadByte : cG = r.ReadByte : cB = r.ReadByte  'reads lights colour
        Me.lightSquare = Color.FromArgb(cR, cG, cB)
        cR = r.ReadByte : cG = r.ReadByte : cB = r.ReadByte  'reads dark colour
        Me.darkSquare = Color.FromArgb(cR, cG, cB)

        Me.showLegalMoves = r.ReadBoolean
        Me.enableCheats = r.ReadBoolean
        Me.nightMode = r.ReadBoolean

        r.Close()
    End Sub

    Public Sub Save()

        Dim w As New System.IO.BinaryWriter(System.IO.File.Open(System.AppDomain.CurrentDomain.BaseDirectory & "\settings.ini", IO.FileMode.OpenOrCreate))   'open or create the .ini file

        With Me.lightSquare
            w.Write(.R) : w.Write(.G) : w.Write(.B)
        End With
        With Me.darkSquare
            w.Write(.R) : w.Write(.G) : w.Write(.B)
        End With

        w.Write(showLegalMoves)
        w.Write(enableCheats)
        w.Write(nightMode)

        w.Close()
        InterfaceForm.settings.Load()
    End Sub

End Structure
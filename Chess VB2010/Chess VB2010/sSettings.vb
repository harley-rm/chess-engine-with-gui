Public Structure sSettings
    Public lightSquare As Color
    Public darkSquare As Color
    Public showLegalMoves As Boolean
    Public enableCheats As Boolean
    Public nightMode As Boolean


    ''' <summary>
    ''' Generates a template settings.ini file for the user in the expected file path.
    ''' </summary>
    ''' <remarks>Can be used by choice or if a file is not found.</remarks>
    Public Shared Sub gen_default_file()
        'this is only ever called if there is not a file found in the given file path. Therefore, in the following coding, we assume that the file does not already exist.
        Try
            Dim w As New System.IO.BinaryWriter(System.IO.File.Open(System.AppDomain.CurrentDomain.BaseDirectory & "\settings.ini", IO.FileMode.CreateNew))

            w.Write(CByte(255)) : w.Write(CByte(255)) : w.Write(CByte(255))     'RGB, lightsquare (off-white)
            w.Write(CByte(10)) : w.Write(CByte(10)) : w.Write(CByte(10))  'RGB, darksquare  (black)

            w.Write(False)   'do not show legal
            w.Write(True)   'enable cheats  
            w.Write(True)   'night mode

            w.Close()
        Catch ex As Exception
            MsgBox("EXCEPTION: " & ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' Carries out the neccessary changes on the targets based on the instances current members.
    ''' </summary>
    ''' <param name="FORM">The target form to make the changes to.</param>
    ''' <param name="GAME_GUI">The target game_gui to make the changes to.</param>
    ''' <remarks></remarks>
    Public Sub enact(FORM As InterfaceForm, GAME_GUI As cGameGUI)
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
                GAME_GUI.getBoardGUI.set_show_legal(False)
            Else
                GAME_GUI.getBoardGUI.set_show_legal(True)
            End If

            GAME_GUI.getBoardGUI.set_light_colour(Me.lightSquare)
            GAME_GUI.getBoardGUI.set_dark_colour(Me.darkSquare)

            GAME_GUI.getBoardGUI.update_graphics()
        End With
    End Sub

    Public Sub load()

        If Not System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\settings.ini") Then
            sSettings.gen_default_file()
        End If

        Dim r As New System.IO.BinaryReader(System.IO.File.Open(System.AppDomain.CurrentDomain.BaseDirectory & "\settings.ini", IO.FileMode.Open))

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

    Public Sub save()

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
        InterfaceForm.settings.load()
    End Sub

End Structure
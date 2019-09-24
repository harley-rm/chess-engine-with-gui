Public Class media_controller

    Private WithEvents _select_songs_button As Button

    Private WithEvents _start_stop_button As PictureBox
    Private WithEvents _skip_button As PictureBox
    Private WithEvents _previous_button As PictureBox

    Public playing_index As Integer
    Public playing As Boolean
    Public songs As List(Of String)

    Public Sub New([select] As Button, ss As PictureBox, skip As PictureBox, prev As PictureBox)
        Me.playing_index = 0
        Me.playing = False
        Me.songs = New List(Of String)
        Me._select_songs_button = [select] : Me._start_stop_button = ss : Me._skip_button = skip : Me._previous_button = prev
    End Sub

    Private Sub select_songs() Handles _select_songs_button.Click
        Dim d As OpenFileDialog = New OpenFileDialog
        d.Multiselect = True
        d.Filter = ".wav|*.wav"
        d.ShowDialog()
        For Each s As String In d.FileNames
            songs.Add(s)
        Next
        d.Dispose()
    End Sub

    Private Sub start_stop() Handles _start_stop_button.Click
        If Not (Me.playing) Then
            Me._start_stop_button.Image = My.Resources.pause
            If Me.songs.Count <> 0 Then
                If Me.playing = True Then My.Computer.Audio.Stop()
                Me.playing_index = 0
                Me.playing = True
                My.Computer.Audio.Play(Me.songs(Me.playing_index))
            End If
        Else
            Me._start_stop_button.Image = My.Resources.play
            Me.playing = False
            Me.playing_index = 0
            My.Computer.Audio.Stop()
        End If
    End Sub

    Private Sub skip_song() Handles _skip_button.Click
        If Me.songs.Count <> 0 Then
            If Me.playing Then
                My.Computer.Audio.Stop()
            End If

            If Me.playing_index = Me.songs.Count - 1 Then
                Me.playing_index = 0
            Else
                Me.playing_index += 1
            End If
            My.Computer.Audio.Play(songs(Me.playing_index))
        End If
    End Sub

    Private Sub previous_song() Handles _previous_button.Click
        If Me.songs.Count <> 0 Then
            If Me.playing Then
                My.Computer.Audio.Stop()
            End If
            If Me.playing_index = 0 Then
                Me.playing_index = Me.songs.Count - 1
            Else
                Me.playing_index -= 1
            End If
            My.Computer.Audio.Play(songs(Me.playing_index))
        End If
    End Sub

End Class

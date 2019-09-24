<Serializable()>
Public Class cClockGUI
    Inherits Panel

    Private _clock As cClock
    Private _label As Label

    Public Sub New(c As cClock)
        Me._clock = c
        Me.init_componenets()
    End Sub

    Private Sub init_componenets()
        Me._label = New Label : Me.Controls.Add(Me._label)
        Me._label.Font = New Font("Microsoft Sans Serif", FontStyle.Bold)
        Me._label.AutoSize = True
    End Sub

    Public Sub update_graphics()
        If Me._clock.getCounting Then Me.BackColor = Color.Red Else Me.BackColor = Color.Green
        Me._label.Text = Me.get_time_string
    End Sub

    Private Function get_time_string() As String
        Dim minutes As Integer : Dim seconds As Integer
        minutes = CInt(CLng(Me._clock.getTime) \ 60)
        seconds = CInt(Int(Me._clock.getTime Mod 60))
        Dim mString As String : Dim sString As String
        If minutes < 10 Then
            mString = "0" & minutes.ToString
        ElseIf minutes = 0 Then
            mString = "00"
        Else
            mString = minutes.ToString
        End If
        If seconds < 10 Then
            sString = "0" & seconds.ToString
        ElseIf seconds = 0 Then
            sString = "00"
        Else
            sString = seconds.ToString
        End If
        Return mString & ":" & sString
    End Function

End Class

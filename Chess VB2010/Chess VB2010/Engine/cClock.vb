Public Class cClock
    Public countThread As System.Threading.Thread
    Public _time As Double 'in seconds.
    Public _increment As Integer 'in seconds.
    Private _counting As Boolean

    ''' <summary>
    ''' Instantiates a new clock with time given in seconds and optionally increment in seconds.
    ''' </summary>
    ''' <param name="TIME"></param>
    ''' <param name="INCREMENT"></param>
    Public Sub New(TIME As Integer, Optional INCREMENT As Integer = 0)
        Me._time = TIME : Me._increment = INCREMENT
        _counting = False
    End Sub

    ''' <summary>
    ''' Toggles the state of the clock, if the clock is set to counting then it is paused, and vice-versa.
    ''' </summary>
    Public Sub ToggleCounter()
        If _counting Then
            countThread.Abort()
            countThread = Nothing
            Me._time += _increment
        Else
            countThread = New System.Threading.Thread(AddressOf Count)
            countThread.Start()
        End If
    End Sub

    Private Sub Count()
        Do Until countThread.ThreadState = ThreadState.Terminated
            Threading.Thread.Sleep(100)
            Me._time -= 0.1
        Loop
    End Sub

End Class

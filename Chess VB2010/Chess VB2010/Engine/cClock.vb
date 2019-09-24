Imports System.Threading
<Serializable()>
Public Class cClock
    Public Event time_up(sender As cClock)

    Public game As cGame
    Public count_thread As Thread
    Public _time As Double 'in seconds.
    Public _increment As Integer 'in seconds.
    Private _counting As Boolean

#Region "Mutators and Acessors"

    Public Function getCounting() As Boolean
        Return Me._counting
    End Function

    Public Function getTime() As Double
        Return Me._time
    End Function

    Public Function getIncrement() As Integer
        Return Me._increment
    End Function

#End Region

    ''' <summary>
    ''' Instantiates a new clock with time given in seconds and optionally increment in seconds.
    ''' </summary>
    ''' <param name="TIME"></param>
    ''' <param name="INCREMENT"></param>
    Public Sub New(g As cGame, TIME As Integer, Optional INCREMENT As Integer = 0)
        Me.game = g : Me._time = TIME : Me._increment = INCREMENT
        _counting = False
    End Sub

    ''' <summary>
    ''' Toggles the state of the clock, if the clock is set to counting then it is paused, and vice-versa.
    ''' </summary>
    Public Sub toggle()
        If _counting Then
            count_thread.Abort()
            count_thread = Nothing
            Me._time += _increment
        Else
            count_thread = New System.Threading.Thread(AddressOf count)
            count_thread.Start()
        End If
    End Sub

    Private Sub count()
        Do Until count_thread.ThreadState = ThreadState.Suspended Or count_thread.ThreadState = ThreadState.Aborted
            Threading.Thread.Sleep(500)
            Me._time -= 0.5
            If Me._time < 0 Then
                Me._counting = False
                RaiseEvent time_up(Me)
            End If
        Loop
    End Sub

End Class

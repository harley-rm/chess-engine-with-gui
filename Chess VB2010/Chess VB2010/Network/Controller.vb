Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class Controller
    Public Event on_recieve(sender As Controller, data As Stream)

    Private _ip As IPAddress '= IPAddress.Parse("192.168.0.22")
    Private _port As Integer
    Private _server As TcpListener

    Private _listener_thread As Thread
    Private _is_listening As Boolean

    Private _client As TcpClient
    Private _client_data As StreamReader

    Public Sub New(Optional i As String = "192.168.0.22", Optional p As Integer = 64583)
        With (Me)
            ._ip = IPAddress.Parse(i) : ._port = p
        End With
        Me._is_listening = True
        Me._server = New TcpListener(Me._ip, Me._port)
        Me._server.Start()

        Me._listener_thread = New Thread(New ThreadStart(AddressOf Listening))
        Me._listener_thread.Start()
    End Sub

    Private Sub Listening()
        Do While Me._is_listening
            If Me._server.Pending Then
                Me._client = Me._server.AcceptTcpClient
                Me._client_data = New StreamReader(Me._client.GetStream)
            End If
            Try
                RaiseEvent on_recieve(Me, Me._client_data.BaseStream)
            Catch ex As Exception
            End Try
            Thread.Sleep(30) 'reduces system lag, gives up responsiveness on the connection slightly.
        Loop
    End Sub

End Class

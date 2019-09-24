Imports System.Net.Sockets
Imports System.IO

Public Class Client
    Private _client As TcpClient
    Private _data_stream As StreamWriter

    Public Sub New(host As String, port As Integer)
        Me._client = New TcpClient(host, port)
        _data_stream = New StreamWriter(Me._client.GetStream)
    End Sub

    Public Sub Send(data As Stream)
        Me._data_stream.Write(data)
        Me._data_stream.Flush()
    End Sub

End Class

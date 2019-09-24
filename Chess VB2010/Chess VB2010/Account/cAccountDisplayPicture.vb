Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class cAccountDisplayPicture
    Inherits PictureBox

    Private Sub set_default()
        Me.Image = My.Resources.default_dop
    End Sub

    Private Sub update_region()
        If (Me.Region IsNot Nothing) Then
            Me.Region.Dispose()
            Me.Region = Nothing
        End If
        Dim path As GraphicsPath = New GraphicsPath : path.Reset()
        path.AddEllipse(0, 0, Me.Width, Me.Height)
        Me.Region = New Region(path)
    End Sub

    Private Sub e_size_changed(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.update_region()
    End Sub

    Public Sub New(ByRef Optional loc As String = "")
        Me.SizeMode = PictureBoxSizeMode.StretchImage
        Me.init_image(loc)
    End Sub

    Public Sub reset_image()
        Me.set_default()
    End Sub

    Public Sub init_image(ByRef Optional loc As String = "")
        If loc = "" Then
            Me.set_default()
        Else
            If IO.File.Exists(loc) Then
                Try
                    Dim b As Bitmap = New Bitmap(loc)
                    Me.Image = b
                Catch ex As Exception
                    Me.set_default()
                    MsgBox("Image could not be loaded, please try a different image.")
                End Try
            Else
                MsgBox("File does not exist. Please try a different image.")
                Me.set_default()
            End If
        End If
    End Sub

End Class
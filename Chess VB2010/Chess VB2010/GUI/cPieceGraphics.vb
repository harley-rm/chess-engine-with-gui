Public Class cPieceGraphics
    Inherits PictureBox

    Private _bitmap As Bitmap
    Private _heldPieceSize As Integer

    Public Function getScaleFactor() As Integer
        Return Me._heldPieceSize
    End Function
    Public Sub setScaleFactor(VALUE As Integer)
        Me._heldPieceSize = VALUE
    End Sub

    Public Sub New(HELD_PIECE_SIZE As Integer)
        Me.Region = New Region
        Me._heldPieceSize = HELD_PIECE_SIZE
    End Sub

    Public Sub UpdateImage(BITMAP As Bitmap)
        Me.Location = New Point(0, 0)

        Dim b As New Bitmap(Me._heldPieceSize, Me._heldPieceSize)
        Dim g As Graphics = Graphics.FromImage(b)
        g.DrawImage(BITMAP, 0, 0, _heldPieceSize, _heldPieceSize)
        Me._bitmap = b


        Me.Size = New Size(Me._heldPieceSize, Me._heldPieceSize)
        Me.SizeMode = PictureBoxSizeMode.StretchImage
        Me.Image = Me._bitmap

        Me.Region = Me.getUpdatedRegion
    End Sub

    Private Function getUpdatedRegion() As Region
        Dim pixel As RectangleF = New Rectangle(New Point(0, 0), New Size(CInt(Me._bitmap.Height / Me.Height), CInt(Me._bitmap.Width / Me.Width)))
        Dim r As New Region
        r.MakeEmpty()
        With (_bitmap)
            For i = 0 To .Width - 1
                For j = 0 To .Height - 1
                    If _bitmap.GetPixel(i, j).A > 1 Then
                        pixel.Location = New Point(i, j)
                        r.Union(pixel)
                    End If
                Next
            Next
        End With
        Return r
    End Function

End Class

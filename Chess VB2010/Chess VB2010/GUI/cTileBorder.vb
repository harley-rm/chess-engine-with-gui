Public Class cTileBorder
    Inherits Panel

    Private _tileSize As Integer
    Private _borderColor As Color

    Public Sub New(TILE_SIZE As Integer, COLOR As Color)
        Me.Size = New Size(TILE_SIZE, TILE_SIZE)
        Me.Location = New Point(0, 0)
        Me._tileSize = tile_size
        Me.BackColor = COLOR
        Me.Region = getUpdatedRegion()
    End Sub

    Public Function getUpdatedRegion() As Region
        Dim tHorizontalBar As RectangleF = New Rectangle(New Point(0, 0), New Size(_tileSize, 2))
        Dim bHorizontalBar As RectangleF = New Rectangle(New Point(0, _tileSize - 2), New Size(_tileSize, 2))
        Dim lVertBar As RectangleF = New Rectangle(New Point(0, 0), New Size(2, _tileSize))
        Dim rVertBar As RectangleF = New Rectangle(New Point(_tileSize - 2, 0), New Size(2, _tileSize))

        Dim r As New Region
        r.MakeEmpty()
        r.Union(tHorizontalBar)
        r.Union(bHorizontalBar)
        r.Union(lVertBar)
        r.Union(rVertBar)

        Return r
    End Function

End Class

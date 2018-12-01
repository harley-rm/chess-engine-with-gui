<Serializable()>
Public Class cTile
    Private _isLightSquare As Boolean
    Private _coordinate As Byte
    Private _piece As cPiece

#Region "Mutators and Accessors"
    Public Function getOccupied() As Boolean
        If Me._piece Is Nothing Then Return False Else Return True
    End Function

    Public Function getCoordinate() As Byte
        Return Me._coordinate
    End Function

    Public Function getPiece() As cPiece
        Return Me._piece
    End Function
    Public Sub setPiece(VALUE As cPiece)
        Me._piece = VALUE
    End Sub

    Public Function getIsLightSquare() As Boolean
        Return Me._isLightSquare
    End Function
#End Region

    Public Sub New(COORDINATE As Byte, IS_LIGHT_SQUARE As Boolean)
        Me._coordinate = COORDINATE
        Me._isLightSquare = IS_LIGHT_SQUARE
    End Sub

    Public Function getFile() As Char
        Return LCase(Chr(64 + (Me._coordinate Mod 8 + 1)))
    End Function

    Public Function getRank() As Byte
        Return CByte(9 - (Me._coordinate \ 8 + 1))
    End Function

End Class

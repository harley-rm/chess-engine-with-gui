Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()>
Public MustInherit Class cPiece
    Protected _title As Chessman
    Protected _coordinate As Byte
    Protected _alliance As Alliance

    Protected _value As Integer

    Public Sub New()
    End Sub

    Public Sub New(ALLIANCE As Alliance, COORDINATE As Byte)
        With (Me)
            ._alliance = ALLIANCE
            ._coordinate = COORDINATE
        End With
    End Sub

    Public MustOverride Function get_char() As Char
    Public MustOverride Function calc_pseudo(BOARD As cBoard) As sMove()

#Region "Mutators and Accessors"
    Public Function get_title() As Chessman
        Return Me._title
    End Function

    Public Function get_coordinate() As Byte
        Return Me._coordinate
    End Function
    Public Sub set_coordinate(VALUE As Byte)
        Me._coordinate = VALUE
    End Sub

    Public Function get_alliance() As Alliance
        Return Me._alliance
    End Function

    Public Function get_value() As Integer
        Return Me._value
    End Function
#End Region

End Class

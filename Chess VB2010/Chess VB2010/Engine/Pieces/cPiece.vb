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

    Public MustOverride Function getChar() As Char
    Public MustOverride Function getPseudoLegalMoves(BOARD As cBoard) As sMove()

#Region "Mutators and Accessors"
    Public Function getTitle() As Chessman
        Return Me._title
    End Function

    Public Function getCoordinate() As Byte
        Return Me._coordinate
    End Function
    Public Overloads Sub setCoordinate(VALUE As Byte)
        Me._coordinate = VALUE
    End Sub
    Public Overloads Sub setCoordinate(VALUE As Integer)
        If VALUE < 0 Then Throw New Exception("INVALID BOARD COORDINATE")
        Me._coordinate = CByte(VALUE)
    End Sub

    Public Function getAlliance() As Alliance
        Return Me._alliance
    End Function

    Public Function getValue() As Integer
        Return Me._value
    End Function
#End Region

End Class

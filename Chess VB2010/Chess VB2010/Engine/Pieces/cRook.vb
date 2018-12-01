<Serializable()>
Public Class cRook
    Inherits cPiece

    Private _hasMoved As Boolean = False

    Public Function getHasMoved() As Boolean
        Return Me._hasMoved
    End Function
    Public Sub setHasMoved(VALUE As Boolean)
        Me._hasMoved = VALUE
    End Sub

    Public Sub New(ALLIANCE As Alliance, COORDINATE As Byte)
        MyBase.New(ALLIANCE, COORDINATE)
        Me._title = Chessman.Rook
        Me._value = 500
    End Sub

    Public Overrides Function getChar() As Char
        If Me._alliance = Alliance.White Then
            Return CChar("R")
        Else
            Return CChar("r")
        End If
    End Function

    Public Overrides Function getPseudoLegalMoves(BOARD As cBoard) As sMove()
        Dim possibleMoveOffsets As SByte() = {-8, -1, 1, 8}
        Dim legalMoves() As sMove = Nothing
        Dim counter As Integer = 0
        For i = 0 To UBound(possibleMoveOffsets)
            Dim targetCoord As Integer = Me._coordinate + possibleMoveOffsets(i)
            While isValidTile(targetCoord, CByte(targetCoord - possibleMoveOffsets(i)), possibleMoveOffsets(i))
                If BOARD.getTile(CByte(targetCoord)).getOccupied Then
                    If BOARD.getTile(CByte(targetCoord)).getPiece.getAlliance <> Me._alliance Then
                        ReDim Preserve legalMoves(counter)
                        legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoord))
                        counter += 1
                    End If
                    Exit While
                Else
                    ReDim Preserve legalMoves(counter)
                    legalMoves(counter) = New sMove(Me._coordinate, CByte(targetCoord))
                    counter += 1
                End If
                targetCoord += possibleMoveOffsets(i)
            End While
        Next
        Return legalMoves
    End Function

    Public Function isValidTile(TARGET_COORDIANTE As Integer, OG_COORDINATE As Byte, OFFSET As Integer) As Boolean
        Dim ogCol As Integer = (OG_COORDINATE Mod 8 + 1)
        Select Case ogCol
            Case 1
                If OFFSET = -1 Then Return False
            Case 8
                If OFFSET = 1 Then Return False
        End Select
        If TARGET_COORDIANTE >= 0 And TARGET_COORDIANTE <= 63 Then
            Return True
        End If
        Return False
    End Function
End Class

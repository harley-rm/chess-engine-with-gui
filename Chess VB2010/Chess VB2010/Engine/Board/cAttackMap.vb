<Serializable()>
Public Class cAttackMap
    Private _board As cBoard

    Private _attackers(63) As List(Of cPiece)   'an attacker is defined as a piece that could attack a tile, even if pinned.
    Private _whiteAttackCount(63) As Byte
    Private _blackAttackCount(63) As Byte

#Region "Mutators and Accessors"
    Public Function getAttackers() As List(Of cPiece)()
        Return Me._attackers
    End Function

    Public Function getAttackCount(ALLIANCE As Alliance)
        If ALLIANCE = Chess_VB2010.Alliance.White Then Return Me._whiteAttackCount Else Return Me._blackAttackCount
    End Function
#End Region

    Public Sub New(BOARD As cBoard)
        For i = 0 To 63
            _attackers(i) = New List(Of cPiece)
        Next

        Me._board = BOARD.getDeepClone(Of cBoard)(BOARD)
        Me.UpdateAttackersAndCounts()
    End Sub

    Public Sub UpdateMap(BOARD As cBoard)
        Me._board = Me._board.getDeepClone(Of cBoard)(BOARD)
        Me.UpdateAttackersAndCounts()
    End Sub

    Private Sub UpdateAttackersAndCounts()
        For Each piece As cPiece In Me._board.getPieces(Alliance.White)
            If piece.getPseudoLegalMoves(Me._board) IsNot Nothing Then
                For Each move As sMove In piece.getPseudoLegalMoves(Me._board)
                    Me._attackers(move.dest).Add(piece)
                    Me._whiteAttackCount(move.dest) += 1
                Next
            End If
        Next
        For Each piece As cPiece In Me._board.getPieces(Alliance.Black)
            If piece.getPseudoLegalMoves(Me._board) IsNot Nothing Then
                For Each move As sMove In piece.getPseudoLegalMoves(Me._board)
                    Me._attackers(move.dest).Add(piece)
                    Me._blackAttackCount(move.dest) += 1
                Next
            End If
        Next
    End Sub

End Class

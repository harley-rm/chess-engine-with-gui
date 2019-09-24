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

    Public Function getAttackCount(ALLIANCE As Alliance) As Byte()
        If ALLIANCE = chess.Alliance.White Then Return Me._whiteAttackCount Else Return Me._blackAttackCount
    End Function
#End Region

    Public Sub New(BOARD As cBoard)
        For i = 0 To 63
            _attackers(i) = New List(Of cPiece)
        Next

        Me._board = BOARD.getDeepClone(Of cBoard)(BOARD)
        Me.update_attackers_and_count()
    End Sub

    Public Sub update_map(BOARD As cBoard)
        Me._board = Me._board.getDeepClone(Of cBoard)(BOARD)
        Me.update_attackers_and_count()
    End Sub

    Private Sub update_attackers_and_count()
        For Each piece As cPiece In Me._board.getPieces(Alliance.White)
            If piece.calc_pseudo(Me._board) IsNot Nothing Then
                For Each move As sMove In piece.calc_pseudo(Me._board)
                    Me._attackers(move.dest).Add(piece)
                    Me._whiteAttackCount(move.dest) += CByte(1)
                Next
            End If
        Next
        For Each piece As cPiece In Me._board.getPieces(Alliance.Black)
            If piece.calc_pseudo(Me._board) IsNot Nothing Then
                For Each move As sMove In piece.calc_pseudo(Me._board)
                    Me._attackers(move.dest).Add(piece)
                    Me._blackAttackCount(move.dest) += CByte(1)
                Next
            End If
        Next
    End Sub

End Class

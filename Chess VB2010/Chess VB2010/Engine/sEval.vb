Public Structure sEval
    Private _board As cBoard
    Private _attackMap As cAttackMap

    Private _wMaterial, _bMaterial As Double
    Private _wScope, _bScope As Double
    Private _wKingSafety, _bKingSafety As Double
    Private _wHangingMaterial, _bHangingMaterial As Double

    Private _summedEval As Double 'positive values represent a white advantage, negative a black advantage and 0 indicates a draw.

    Public Function get_summed_eval() As Double
        Return Me._summedEval
    End Function

    Public Sub New(BOARD As cBoard)
        Me._board = BOARD
        Me._attackMap = New cAttackMap(Me._board)

        Me._wMaterial = eval_material(Alliance.White) : Me._wScope = eval_scope(Alliance.White) : Me._wKingSafety = eval_king_safety(Alliance.White)
        Me._bMaterial = eval_material(Alliance.Black) : Me._bScope = eval_scope(Alliance.Black) : Me._bKingSafety = eval_king_safety(Alliance.Black)
        Me._summedEval = calc_summed_eval()
    End Sub

    Public Function calc_summed_eval() As Double
        Return (Me._wMaterial + Me._wScope + Me._wKingSafety + Me._bHangingMaterial) - (Me._bMaterial + Me._bScope + Me._bKingSafety + Me._wHangingMaterial)
    End Function

#Region "Evaluation Functions"
    Private Function eval_material(ALLIANCE As Alliance) As Double
        Dim val As Integer
        For Each piece As cPiece In Me._board.getPieces(ALLIANCE)
            If Not (TypeOf piece Is cKing) Then val += piece.get_value
        Next
        Return val
    End Function

    Private Function eval_king_safety(ALLIANCE As Alliance) As Double
        Dim moves As sMove() = Me._board.getPseudoLegalMoves(ALLIANCE)
        Dim opponent As Alliance : If ALLIANCE = chess.Alliance.White Then opponent = chess.Alliance.Black Else opponent = chess.Alliance.White
        Dim kingLoc As Byte = Me._board.findKing(opponent).get_coordinate
        Dim attacks As Byte = 0
        If moves IsNot Nothing Then
            For Each move As sMove In moves
                If move.dest = kingLoc Then attacks += CByte(1)
            Next
        End If
        Return 0        ''REMOVE THIS AFTER TESTING''
        Return CDbl(0.05 * attacks)
    End Function

    Private Function eval_scope(ALLIANCE As Alliance) As Double
        Dim moves As sMove() = Me._board.getPseudoLegalMoves(ALLIANCE)
        Return CDbl(moves.Length * 0.05)
    End Function

#End Region

    Public Overrides Function toString() As String
        Dim msg As String = Nothing
        Select Case Me._summedEval
            Case Is = 0
                msg = "Draw."
            Case Is > 0
                msg = "White is winning."
            Case Is < 0
                msg = "Black is winning."
        End Select
        Return String.Concat("(W): {", "M: ", Me._wMaterial, ", S: ", Me._wScope, ", SAFE: ", Me._wKingSafety, ", HANGING: ", Me._wHangingMaterial, "}", vbCrLf, "(B): {M: ", Me._bMaterial, ", S: ", Me._bScope, ", SAFE: ", Me._bKingSafety, "HANGING: ", Me._bHangingMaterial, "}", vbCrLf, "Summed: ", Me._summedEval, vbCrLf, msg)
    End Function
   

End Structure

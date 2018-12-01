Public Structure sEval
    Private _board As cBoard
    Private _attackMap As cAttackMap

    Private _wMaterial, _bMaterial As Double
    Private _wScope, _bScope As Double
    Private _wKingSafety, _bKingSafety As Double
    Private _wHangingMaterial, _bHangingMaterial As Double

    Private _summedEval As Double 'positive values represent a white advantage, negative a black advantage and 0 indicates a draw.

    Public Function getSummedEval() As Double
        Return Me._summedEval
    End Function

    Public Sub New(BOARD As cBoard)
        Me._board = BOARD
        Me._attackMap = New cAttackMap(Me._board)

        Me._wMaterial = evalMaterial(Alliance.White) : Me._wScope = evalScope(Alliance.White) : Me._wKingSafety = evalKingSafety(Alliance.White) : Me._wHangingMaterial = evalLostPieces(Alliance.White)
        Me._bMaterial = evalMaterial(Alliance.Black) : Me._bScope = evalScope(Alliance.Black) : Me._bKingSafety = evalKingSafety(Alliance.Black) : Me._bHangingMaterial = evalLostPieces(Alliance.Black)
        Me._summedEval = calcSummedEval()
    End Sub

    Public Function calcSummedEval() As Double
        Return (Me._wMaterial + Me._wScope + Me._wKingSafety + Me._bHangingMaterial) - (Me._bMaterial + Me._bScope + Me._bKingSafety + Me._wHangingMaterial)
    End Function

#Region "Evaluation Functions"
    Private Function evalMaterial(ALLIANCE As Alliance) As Double
        Dim val As Integer
        For Each piece As cPiece In Me._board.getPieces(ALLIANCE)
            If Not (TypeOf piece Is cKing) Then  val += piece.getValue
        Next
        Return val
    End Function

    Private Function evalKingSafety(ALLIANCE As Alliance) As Double
        Dim moves As sMove() = Me._board.getPseudoLegalMoves(ALLIANCE)
        Dim opponent As Alliance : If ALLIANCE = Chess_VB2010.Alliance.White Then opponent = Chess_VB2010.Alliance.Black Else opponent = Chess_VB2010.Alliance.White
        Dim kingLoc As Byte = Me._board.findKing(opponent).getCoordinate
        Dim attacks As Byte = 0
        If moves IsNot Nothing Then
            For Each move As sMove In moves
                If move.dest = kingLoc Then attacks += 1
            Next
        End If
        Return 0        ''REMOVE THIS AFTER TESTING''
        Return CDbl(0.05 * attacks)
    End Function

    Private Function evalScope(ALLIANCE As Alliance) As Double
        Dim moves As sMove() = Me._board.getPseudoLegalMoves(ALLIANCE)
        Return CDbl(moves.Length * 0.05)
    End Function

    Private Function evalCentre(ALLIANCE As Alliance) As Double

    End Function

    Private Function evalLostPieces(ALLIANCE As Alliance) As Double
        'DEFINITION OF HANGING MATERIAL:
        ' Material is hanging if it is in a position where it is under attack by a piece of lesser value - even if it is defended.
        ' Or if it is under attack by multiple pieces whos collective value is lesser than the 
        '
        '
        '

        Dim hangingMaterial As Double

        'returns a positive value for both players,
        Return hangingMaterial
    End Function

    Private Shared Function evalPassedPawns(BOARD As cBoard, ALLIANCE As Alliance) As Double
        Return 0
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

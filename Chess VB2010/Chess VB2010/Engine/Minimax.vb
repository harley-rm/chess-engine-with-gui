Public Class Minimax

    ''' <summary>
    ''' Returns the best move as determined by looking the given number of half-plys ahead from a given position.
    ''' </summary>
    ''' <param name="BOARD">Inputs the position to begin evaluation from.</param>
    ''' <param name="DEPTH">Specifies how many half-plies forward the engine will search to generate the evaluation score. Higher depths will score as position more accurately at the expense of time.</param>
    ''' <returns></returns>
    Public Shared Function getBestMove(DEPTH As Integer, BOARD As cBoard) As sMove

        Dim highest As Double = Double.MinValue
        Dim lowest As Double = Double.MaxValue
        Dim current As Double
        Dim bestMove As sMove

        For Each move As sMove In BOARD.getLegalMoves
            Dim b As cBoard = BOARD.getDeepClone(Of cBoard)(BOARD)
            b.MakeMove(move)
            If b.getWhosTurn = Alliance.Black Then
                current = Max(DEPTH - 1, b)
                If current >= highest Then
                    bestMove = move
                    highest = current
                End If
            ElseIf b.getWhosTurn = Alliance.White Then
                current = Min(DEPTH - 1, b)
                If current <= lowest Then
                    bestMove = move
                    lowest = current
                End If
            End If
        Next

        Return bestMove
    End Function

    Private Shared Function Min(DEPTH As Integer, BOARD As cBoard) As Double
        Dim minimum As Double = Double.MaxValue
        If DEPTH = 0 Then
            Return New sEval(BOARD).getSummedEval       ''TODO: TEST
        Else
            Dim b As cBoard = BOARD.getDeepClone(Of cBoard)(BOARD)
            For Each move As sMove In BOARD.getLegalMoves
                b.MakeMove(move)
                Dim val As Double = Max(DEPTH - 1, b)
                If val >= minimum Then minimum = val
            Next
        End If
        Return minimum
    End Function
    Private Shared Function Max(DEPTH As Integer, BOARD As cBoard) As Double
        Dim maximum As Double = Double.MinValue
        If DEPTH = 0 Then
            Return New sEval(BOARD).getSummedEval
        Else
            Dim b As cBoard = BOARD.getDeepClone(Of cBoard)(BOARD)
            For Each move As sMove In BOARD.getLegalMoves
                b.MakeMove(move)
                Dim val As Double = Min(DEPTH - 1, b)
                If val <= maximum Then maximum = val
            Next
        End If
        Return maximum
    End Function

End Class

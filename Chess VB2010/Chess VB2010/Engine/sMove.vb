<Serializable()>
Public Structure sMove
    Public ogCoord As Byte
    Public dest As Byte

    Public Sub New(OG_COORD As Byte, DEST As Byte)
        Me.ogCoord = OG_COORD
        Me.dest = DEST
    End Sub

#Region "Operator Overloads"
    Public Shared Operator =(v1 As sMove, v2 As sMove) As Boolean
        If v1.dest = v2.dest And v1.ogCoord = v2.ogCoord Then Return True Else Return False
    End Operator
    Public Shared Operator <>(v1 As sMove, v2 As sMove) As Boolean
        If v1.dest = v2.dest And v1.ogCoord = v2.ogCoord Then Return False Else Return True
    End Operator
#End Region

    Public Overloads Function ToString(BOARD As cBoard) As String
        'THIS FUNCTION WILL ONLY WORK IF CALLED BEFORE THE MOVE IS MADE ON THE BOARD, AKA THE PARAMETER IS THE BOARD BEFORE THE MOVE

        Dim movingPiece As cPiece = BOARD.getTiles(Me.ogCoord).get_piece
        Dim isCapture As Boolean = BOARD.getTile(Me.dest).is_occupied
        Dim isAmbiguous As Boolean = Me.is_ambigious(BOARD, movingPiece)
        Dim castlingTiles As Byte() = {58, 62, 2, 6}
        'a move is deemed to be ambiguous if another piece of the same alliance and piece type can also move the the destination square.
        If isAmbiguous Then
            Dim cap As String
            If isCapture Then cap = "x" Else cap = Nothing
            ToString = calc_char(movingPiece, isCapture) & BOARD.getTile(movingPiece.get_coordinate).get_file & cap & BOARD.getTile(Me.dest).get_file & BOARD.getTile(Me.dest).get_rank
        Else
            If movingPiece.get_title = Chessman.Pawn AndAlso BOARD.getTile(Me.dest).get_coordinate = BOARD.getEnPassent Then  'en passent capture
                ToString = LCase(BOARD.getTile(Me.ogCoord).get_file & "x" & BOARD.getTile(Me.dest).get_file & BOARD.getTile(Me.dest).get_rank)
            ElseIf movingPiece.get_title = Chessman.Pawn AndAlso ((BOARD.getTile(Me.dest).get_coordinate \ 8 + 1 = 1) AndAlso movingPiece.get_alliance = Alliance.White) Then  'black promotion
                ToString = LCase(BOARD.getTile(Me.dest).get_file & BOARD.getTile(Me.dest).get_rank) & "=Q"
            ElseIf movingPiece.get_title = Chessman.Pawn AndAlso (BOARD.getTile(Me.dest).get_coordinate \ 8 + 1 = 8) AndAlso movingPiece.get_alliance = Alliance.Black Then    'white promotion
                ToString = LCase(BOARD.getTile(Me.dest).get_file & BOARD.getTile(Me.dest).get_rank) & "=Q"
            ElseIf movingPiece.get_title = Chessman.King AndAlso Not CType(movingPiece, cKing).get_moved AndAlso castlingTiles.Contains(Me.dest) Then        'castling
                If Me.dest = 2 Or Me.dest = 58 Then ToString = "O-O-O" Else ToString = "O-O"
            Else    'normal move66
                Dim cap As String
                If isCapture Then cap = CChar("x") Else cap = ""
                ToString = calc_char(movingPiece, isCapture) & cap & BOARD.getTile(Me.dest).get_file & BOARD.getTile(Me.dest).get_rank
            End If
        End If

        Dim t As cBoard = BOARD.getDeepClone(Of cBoard)(BOARD)
        t.MakeMove(Me)
        Dim s As GameState = t.calcBoardState()
        If s = GameState.WhiteMated Or s = GameState.BlackMated Then Return ToString & "#" 'if there was a mate then update and return the string
        If t.isInCheck(Alliance.White) Or t.isInCheck(Alliance.Black) Then Return ToString & "+" 'if the move resulted in check, then update and return the string.

        Return ToString

    End Function

    Private Function calc_char(PIECE As cPiece, IS_CAPTURE As Boolean) As String
        Select Case PIECE.get_title
            Case Chessman.Pawn
                If IS_CAPTURE Then Return LCase(Chr(64 + (PIECE.get_coordinate Mod 8 + 1)))
            Case Chessman.Knight
                Return CChar("N")
            Case Chessman.Bishop
                Return CChar("B")
            Case Chessman.Rook
                Return CChar("R")
            Case Chessman.Queen
                Return CChar("Q")
            Case Chessman.King
                Return CChar("K")
        End Select
        Return ""
    End Function

    Private Function is_ambigious(BOARD As cBoard, MOVING_PIECE As cPiece) As Boolean
        Dim alliance As Alliance = MOVING_PIECE.get_alliance
        For Each move As sMove In BOARD.getLegalMoves
            If move <> Me Then
                If BOARD.getTile(move.ogCoord).get_piece.get_alliance = alliance Then
                    If move.dest = Me.dest AndAlso BOARD.getTile(move.ogCoord).get_piece.get_title = BOARD.getTile(Me.ogCoord).get_piece.get_title Then Return True
                End If
            End If
        Next
        Return False
    End Function

#Region "Moves"
    Public Shared Sub regular(MOVE As sMove, BOARD As cBoard)
        Dim movingPiece As cPiece = BOARD.getTile(MOVE.ogCoord).get_piece        'error @ 1. e4, d5 2. exd5, c6 3. dxc6, Bd7 4. cxb7, Be6 5. bxa8=Q, Qd7 6. Qaf3
        Dim targetTile As cTile = BOARD.getTile(MOVE.dest)
        movingPiece.set_coordinate(targetTile.get_coordinate)      'update the pieces coordinate
        targetTile.set_piece(movingPiece)                         'update the tiles piece reference
        BOARD.getTiles(MOVE.ogCoord).set_piece(Nothing)           'update the og tiles piece reference
    End Sub

    Public Shared Sub enpassent(MOVE As sMove, BOARD As cBoard)
        Dim movingPiece As cPiece = BOARD.getTile(MOVE.ogCoord).get_piece
        Dim targetTile As cTile = BOARD.getTile(MOVE.dest)
        movingPiece.set_coordinate(MOVE.dest)
        targetTile.set_piece(movingPiece)
        If BOARD.getWhoseTurn = Alliance.White Then
            BOARD.getTile(CByte(MOVE.dest + 8)).set_piece(Nothing)
        Else
            BOARD.getTile(CByte(MOVE.dest - 8)).set_piece(Nothing)
        End If
        BOARD.getTile(MOVE.ogCoord).set_piece(Nothing)
    End Sub

    Public Shared Sub castle(MOVE As sMove, BOARD As cBoard)
        sMove.regular(MOVE, BOARD)
        Dim rookMove As sMove
        Select Case MOVE.dest
            Case 58
                rookMove = New sMove(56, 59)
            Case 62
                rookMove = New sMove(63, 61)
            Case 2
                rookMove = New sMove(0, 3)
            Case 6
                rookMove = New sMove(7, 5)
        End Select
        sMove.regular(rookMove, BOARD)
    End Sub

    Public Shared Sub promotion(MOVE As sMove, BOARD As cBoard)
        Dim movingPiece As cPiece = BOARD.getTile(MOVE.ogCoord).get_piece
        Dim targetTile As cTile = BOARD.getTile(MOVE.dest)
        targetTile.set_piece(New cQueen(movingPiece.get_alliance, MOVE.dest))     'puts the new queen on the board
        BOARD.getTile(MOVE.ogCoord).set_piece(Nothing)   'removes the promoting piece from the board
        BOARD.updatePieces(Alliance.White)  'updates the piece list of the board for both players.
        BOARD.updatePieces(Alliance.Black)
    End Sub
#End Region


End Structure

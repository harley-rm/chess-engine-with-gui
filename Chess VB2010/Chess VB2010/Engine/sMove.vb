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

        Dim movingPiece As cPiece = BOARD.getTiles(Me.ogCoord).getPiece
        Dim isCapture As Boolean = BOARD.getTile(Me.dest).getOccupied
        Dim isAmbiguous As Boolean = Me.isMoveAmbiguous(BOARD, movingPiece)
        Dim castlingTiles As Byte() = {58, 62, 2, 6}
        'a move is deemed to be ambiguous if another piece of the same alliance and piece type can also move the the destination square.
        If isAmbiguous Then
            Dim cap As String
            If isCapture Then cap = "x" Else cap = Nothing
            ToString = getChar(movingPiece, isCapture) & BOARD.getTile(movingPiece.getCoordinate).getFile & cap & BOARD.getTile(Me.dest).getFile & BOARD.getTile(Me.dest).getRank
        Else
            If movingPiece.getTitle = Chessman.Pawn AndAlso BOARD.getTile(Me.dest).getCoordinate = BOARD.getEnPassentCoord Then  'en passent capture
                ToString = LCase(BOARD.getTile(Me.ogCoord).getFile & "x" & BOARD.getTile(Me.dest).getFile & BOARD.getTile(Me.dest).getRank)
            ElseIf movingPiece.getTitle = Chessman.Pawn AndAlso ((BOARD.getTile(Me.dest).getCoordinate \ 8 + 1 = 1) AndAlso movingPiece.getAlliance = Alliance.White) Then  'black promotion
                ToString = LCase(BOARD.getTile(Me.dest).getFile & BOARD.getTile(Me.dest).getRank) & "=Q"
            ElseIf movingPiece.getTitle = Chessman.Pawn AndAlso (BOARD.getTile(Me.dest).getCoordinate \ 8 + 1 = 8) AndAlso movingPiece.getAlliance = Alliance.Black Then    'white promotion
                ToString = LCase(BOARD.getTile(Me.dest).getFile & BOARD.getTile(Me.dest).getRank) & "=Q"
            ElseIf movingPiece.getTitle = Chessman.King AndAlso Not CType(movingPiece, cKing).getHasMoved AndAlso castlingTiles.Contains(Me.dest) Then        'castling
                If Me.dest = 2 Or Me.dest = 58 Then ToString = "O-O-O" Else ToString = "O-O"
            Else    'normal move66
                Dim cap As String
                If isCapture Then cap = CChar("x") Else cap = ""
                ToString = getChar(movingPiece, isCapture) & cap & BOARD.getTile(Me.dest).getFile & BOARD.getTile(Me.dest).getRank
            End If
        End If

        Dim t As New cGhostBoard(BOARD, Me)
        Dim s As GameState = t.getBoard.getState
        If t.getBoard.getLegalMoves Is Nothing Then MsgBox("")
        If s = GameState.WhiteMated Or s = GameState.BlackMated Then Return ToString & "#"  'if there was a mate then update and return the string
        If t.getBoard.isInCheck(Alliance.White) Or t.getBoard.isInCheck(Alliance.Black) Then Return ToString & "+"  'if the move resulted in check, then update and return the string.

        Return ToString

    End Function

    Private Function getChar(PIECE As cPiece, IS_CAPTURE As Boolean) As String
            Select Case PIECE.getTitle
                Case Chessman.Pawn
                    If IS_CAPTURE Then Return LCase(Chr(64 + (PIECE.getCoordinate Mod 8 + 1)))
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

    Private Function isMoveAmbiguous(BOARD As cBoard, MOVING_PIECE As cPiece) As Boolean
        Dim alliance As Alliance = MOVING_PIECE.getAlliance
        For Each move As sMove In BOARD.getLegalMoves
            If move <> Me Then
                If BOARD.getTile(move.ogCoord).getPiece.getAlliance = alliance Then
                    If move.dest = Me.dest AndAlso BOARD.getTile(move.ogCoord).getPiece.getTitle = BOARD.getTile(Me.ogCoord).getPiece.getTitle Then Return True
                End If
            End If
        Next
        Return False
    End Function

#Region "Moves"
    Public Shared Sub Regular(MOVE As sMove, BOARD As cBoard)
        Dim movingPiece As cPiece = BOARD.getTile(MOVE.ogCoord).getPiece        'error @ 1. e4, d5 2. exd5, c6 3. dxc6, Bd7 4. cxb7, Be6 5. bxa8=Q, Qd7 6. Qaf3
        Dim targetTile As cTile = BOARD.getTile(MOVE.dest)
        movingPiece.setCoordinate(targetTile.getCoordinate)      'update the pieces coordinate
        targetTile.setPiece(movingPiece)                         'update the tiles piece reference
        BOARD.getTiles(MOVE.ogCoord).setPiece(Nothing)           'update the og tiles piece reference
    End Sub

        Public Shared Sub EnPassentCapture(MOVE As sMove, BOARD As cBoard)
            Dim movingPiece As cPiece = BOARD.getTile(MOVE.ogCoord).getPiece
            Dim targetTile As cTile = BOARD.getTile(MOVE.dest)
            movingPiece.setCoordinate(MOVE.dest)
            targetTile.setPiece(movingPiece)
            If BOARD.getWhosTurn = Alliance.White Then
                BOARD.getTile(CByte(MOVE.dest + 8)).setPiece(Nothing)
            Else
                BOARD.getTile(CByte(MOVE.dest - 8)).setPiece(Nothing)
            End If
            BOARD.getTile(MOVE.ogCoord).setPiece(Nothing)
        End Sub

        Public Shared Sub Castle(MOVE As sMove, BOARD As cBoard)
            sMove.Regular(MOVE, BOARD)
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
            sMove.Regular(rookMove, BOARD)
        End Sub

    Public Shared Sub Promotion(MOVE As sMove, BOARD As cBoard)
        Dim movingPiece As cPiece = BOARD.getTile(MOVE.ogCoord).getPiece
        Dim targetTile As cTile = BOARD.getTile(MOVE.dest)
        targetTile.setPiece(New cQueen(movingPiece.getAlliance, MOVE.dest))     'puts the new queen on the board
        BOARD.getTile(MOVE.ogCoord).setPiece(Nothing)   'removes the promoting piece from the board
        BOARD.updatePieces(Alliance.White)  'updates the piece list of the board for both players.
        BOARD.updatePieces(Alliance.Black)
    End Sub
#End Region


End Structure

Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()>
Public Class cBoard

    Private _tiles(63) As cTile

    Private _whitePseudoLegalMoves As sMove()
    Private _blackPseudoLegalMoves As sMove()

    Private _whitePieces As cPiece()
    Private _blackPieces As cPiece()

    Private _legalMoves As sMove()

    Private _whosTurn As Alliance
    Private _state As GameState

    Private _moveList As LinkedList(Of String)

    'MANAGEMENT
    Private _enPassentCoord As Byte
    Private _halfMoveTimer As Integer
    Private _plyCounter As Integer

#Region "Mutators and Accessors"
    Public Function getTiles() As cTile()
        Return Me._tiles
    End Function

    Public Function getTile(COORDINATE As Byte) As cTile
        Return Me._tiles(COORDINATE)
    End Function

    Public Function getWhosTurn() As Alliance
        Return Me._whosTurn
    End Function
    Public Sub setWhosTurn(VALUE As Alliance)
        Me._whosTurn = VALUE
    End Sub

    Public Function getLegalMoves() As sMove()
        Return Me._legalMoves
    End Function

    Public Function getPseudoLegalMoves(ALLIANCE As Alliance) As sMove()
        If ALLIANCE = Alliance.White Then Return Me._whitePseudoLegalMoves Else Return Me._blackPseudoLegalMoves
    End Function

    Public Function getState() As GameState
        Return Me._state
    End Function

    Public Function getEnPassentCoord() As Byte
        Return Me._enPassentCoord
    End Function

    Public Function getPieces(ALLIANCE As Alliance) As cPiece()
        If ALLIANCE = Alliance.White Then Return Me._whitePieces Else Return Me._blackPieces
    End Function
    Public Function getMoveList() As LinkedList(Of String)
        Return Me._moveList
    End Function

    Public Function getHalfPlyMoveTimer() As Integer
        Return Me._halfMoveTimer
    End Function
#End Region

#Region "Constructor"
    Public Sub New()
        Me._moveList = New LinkedList(Of String)
        Me.initializeTiles()
        Me.InitializeBoard()
        Me._whitePieces = Me.updatePieces(Alliance.White)
        Me._blackPieces = Me.updatePieces(Alliance.Black)
        Me._whitePseudoLegalMoves = Me.calculatePseudoLegalMoves(Alliance.White)
        Me._blackPseudoLegalMoves = Me.calculatePseudoLegalMoves(Alliance.Black)
        Me._legalMoves = Me.calculateLegalMoves()
    End Sub
#End Region

    Public Sub SetPosition(FEN As String)
        'Forsyth-Edwards Notation FORMAT:
        'PIECE LOCATIONS/EMPTY SQUARES : WHOS TURN : CASTLING RIGHTS : EN-PASSENT TARGET SQUARE : HALFMOVE CLOCK : FULLMOVE NUMBER
        Dim counter As Integer = 0
        For Each tile As cTile In Me._tiles
            tile.setPiece(Nothing)
        Next
        Dim endOf As Integer
        For i = 0 To FEN.Length - 1
            If FEN(i) = CChar(" ") Then
                endOf = i
                Exit For
            End If

            If FEN(i) = CChar("/") Then

            ElseIf Asc(FEN(i)) >= 48 AndAlso Asc(FEN(i)) <= 57 Then
                counter += Val(FEN(i))
            Else
                Me._tiles(counter).setPiece(generatePiece(FEN(i), CByte(counter)))
                counter += 1
            End If
        Next
        If FEN(endOf + 1) = "w" Then
            Me._whosTurn = Alliance.White
        Else
            Me._whosTurn = Alliance.Black
        End If
    End Sub
    Public Function generatePiece(C As Char, COORDINATE As Byte) As cPiece
        Dim temp As Char = C
        Dim alliance As Alliance
        If LCase(C) = temp Then alliance = Alliance.Black Else alliance = Alliance.White
        Select Case LCase(C)
            Case CChar("r")
                Return New cRook(alliance, COORDINATE)
            Case CChar("b")
                Return New cBishop(alliance, COORDINATE)
            Case CChar("q")
                Return New cQueen(alliance, COORDINATE)
            Case CChar("k")
                Return New cKing(alliance, COORDINATE)
            Case CChar("p")
                Return New cPawn(alliance, COORDINATE)
            Case CChar("n")
                Return New cKnight(alliance, COORDINATE)
        End Select
        Return Nothing
    End Function

    Public Sub initializeTiles()
        Dim count As Integer = 0
        Dim isLightSquare As Boolean = False
        For i = 0 To 63
            count += 1
            If count = 9 Then
                count = 1
            Else
                isLightSquare = Not (isLightSquare)
            End If
            Me._tiles(i) = New cTile(CByte(i), isLightSquare)
        Next
        Me._enPassentCoord = 255
    End Sub

    Public Function findKing(ALLIANCE As Alliance) As cKing
        If ALLIANCE = Alliance.White Then
            For Each piece As cPiece In Me.getPieces(Alliance.White)
                If piece.getTitle = Chessman.King Then Return CType(piece, cKing)
            Next
        Else
            For Each piece As cPiece In Me.getPieces(Alliance.Black)
                If piece.getTitle = Chessman.King Then Return CType(piece, cKing)
            Next
        End If
        Return Nothing

    End Function

    ''' <summary>
    ''' Will return an updated cPiece array of all of the pieces currently on the instance of board from which it is called.
    ''' </summary>
    ''' <param name="ALLIANCE">Alliance of the set of pieces intended to be updated.</param>
    ''' <returns>Hey</returns>
    Public Function updatePieces(ALLIANCE As Alliance) As cPiece()
        Dim temp As cPiece() = Nothing
        Dim counter As Integer = 0
        For Each t As cTile In _tiles
            If t.getOccupied AndAlso t.getPiece.getAlliance = ALLIANCE Then
                ReDim Preserve temp(counter)
                temp(counter) = t.getPiece
                counter += 1
            End If
        Next
        Return temp
    End Function

    ''' <summary>
    ''' Creates and returns a bit-wise clone of the input board, after eliminating references.
    ''' </summary>
    ''' <typeparam name="cBoard"></typeparam>
    ''' <param name="orig"></param>
    ''' <returns></returns>
    Public Function getDeepClone(Of cBoard)(ByRef orig As cBoard) As cBoard
        'SHALLOW CLONE VS DEEP CLONE
        'A shallow clone will be a bit-wise copy of an object, with all of the same values that the object had, however if there is a reference to another object in the original object, then only the reference
        '   is copied. With a deep clone, it is still a bit-wise copy of the object, however when a reference is encountered in that object, that object is cloned in order create a new clone with all of the same values
        '   as that object within the object, this allows a deep clone to be edited without affecting memory locations that may be being used by other objects that you do not intend to edit.

        'if the object is a NULL reference, then return that objects 'nothing'.
        If (Object.ReferenceEquals(orig, Nothing)) Then Return Nothing

        Dim formatter As New BinaryFormatter()
        Dim stream As New MemoryStream()

        'the serialize function will serialize the object to the inputted stream.
        formatter.Serialize(stream, orig)
        'this then sets the position within the stream "stream" to the beginning of the stream so that the entire stream can be deserialized and returned at the end of the function.
        stream.Seek(0, SeekOrigin.Begin)

        Return CType(formatter.Deserialize(stream), cBoard)
    End Function

    ''' <summary>
    ''' Updates the board to represent the standard chess starting position.
    ''' </summary>
    Private Sub InitializeBoard()
        'black major pieces
        _tiles(0).setPiece(New cRook(Alliance.Black, 0))
        _tiles(1).setPiece(New cKnight(Alliance.Black, 1))
        _tiles(2).setPiece(New cBishop(Alliance.Black, 2))
        _tiles(3).setPiece(New cQueen(Alliance.Black, 3))
        _tiles(4).setPiece(New cKing(Alliance.Black, 4))
        _tiles(5).setPiece(New cBishop(Alliance.Black, 5))
        _tiles(6).setPiece(New cKnight(Alliance.Black, 6))
        _tiles(7).setPiece(New cRook(Alliance.Black, 7))
        'black pawns
        For i = 8 To 15
            _tiles(i).setPiece(New cPawn(Alliance.Black, CByte(i)))
        Next

        'white pawns
        For i = 48 To 55
            _tiles(i).setPiece(New cPawn(Alliance.White, CByte(i)))
        Next
        'white major pieces
        _tiles(56).setPiece(New cRook(Alliance.White, 56))
        _tiles(57).setPiece(New cKnight(Alliance.White, 57))
        _tiles(58).setPiece(New cBishop(Alliance.White, 58))
        _tiles(59).setPiece(New cQueen(Alliance.White, 59))
        _tiles(60).setPiece(New cKing(Alliance.White, 60))
        _tiles(61).setPiece(New cBishop(Alliance.White, 61))
        _tiles(62).setPiece(New cKnight(Alliance.White, 62))
        _tiles(63).setPiece(New cRook(Alliance.White, 63))
    End Sub

    ''' <summary>
    ''' Returns the pseudo-legal moves of pieces of the specified alliance.
    ''' </summary>
    ''' <param name="ALLIANCE"></param>
    Private Function calculatePseudoLegalMoves(ALLIANCE As Alliance) As sMove()
        Dim pieceSet As cPiece()
        If ALLIANCE = Alliance.White Then pieceSet = Me._whitePieces Else pieceSet = Me._blackPieces
        Dim temp As sMove() = Nothing
        Dim counter As Integer = 0
        For Each piece As cPiece In pieceSet
            If piece.getPseudoLegalMoves(Me) IsNot Nothing Then
                For Each move As sMove In piece.getPseudoLegalMoves(Me)
                    ReDim Preserve temp(counter)
                    temp(counter) = move
                    counter += 1
                Next
            End If
        Next
        Return temp
    End Function

    ''' <summary>
    ''' Returns moves which are allowed by each pieces normal moves, taking pins into account.
    ''' </summary>
    Private Function calculateLegalMoves() As sMove()
        Dim moveSet As sMove()
        Dim temp As sMove() = Nothing
        Dim counter As Integer = 0
        If Me._whosTurn = Alliance.White Then moveSet = Me._whitePseudoLegalMoves Else moveSet = Me._blackPseudoLegalMoves
        For Each move As sMove In moveSet
            Dim x As New cGhostBoard(Me, move)
            If x.isLegal Then
                ReDim Preserve temp(counter)
                temp(counter) = move
                counter += 1
            End If
        Next
        Return temp
    End Function

    Public Function isInCheck(ALLIANCE As Alliance) As Boolean
        Dim moveSet As sMove()
        Dim king As cKing
        If ALLIANCE = Alliance.White Then moveSet = Me._blackPseudoLegalMoves Else moveSet = Me._whitePseudoLegalMoves
        If ALLIANCE = Alliance.White Then king = Me.findKing(Alliance.White) Else king = Me.findKing(Alliance.Black)
        If moveSet Is Nothing Then Return False 'temp
        For Each move As sMove In moveSet
            If move.dest = king.getCoordinate Then Return True
        Next
        Return False
    End Function

    Public Function isLegalMove(MOVE As sMove) As Boolean
        If Me._legalMoves.Contains(MOVE) Then Return True Else Return False
    End Function

    ''' <summary>
    ''' Updates the current instance of cBoard to reflect the move attempted, if the move is not legal, it will not be made.
    ''' </summary>
    ''' <param name="MOVE"></param>
    ''' <param name="FROM_TRANSITION"></param>
    Public Sub MakeMove(MOVE As sMove, Optional FROM_TRANSITION As Boolean = False)
        Dim movingPiece As cPiece = Me.getTile(MOVE.ogCoord).getPiece
        Dim targetTile As cTile = Me.getTile(MOVE.dest)
        Dim wasCapture As Boolean
        wasCapture = Me._tiles(MOVE.dest).getOccupied
        If FROM_TRANSITION Then
            Dim castlingTiles As Byte() = {58, 62, 2, 6}
            If movingPiece.getTitle = Chessman.Pawn AndAlso targetTile.getCoordinate = Me._enPassentCoord Then  'en passent capture
                sMove.EnPassentCapture(MOVE, Me)
            ElseIf movingPiece.getTitle = Chessman.Pawn AndAlso ((targetTile.getCoordinate \ 8 + 1 = 1) AndAlso movingPiece.getAlliance = Alliance.White) Then  'black promotion
                sMove.Promotion(MOVE, Me)
            ElseIf movingPiece.getTitle = Chessman.Pawn AndAlso (targetTile.getCoordinate \ 8 + 1 = 8) AndAlso movingPiece.getAlliance = Alliance.Black Then    'white promotion
                sMove.Promotion(MOVE, Me)
            ElseIf movingPiece.getTitle = Chessman.King AndAlso Not CType(movingPiece, cKing).getHasMoved AndAlso castlingTiles.Contains(MOVE.dest) Then        'castling
                sMove.Castle(MOVE, Me)
            Else    'normal move66
                sMove.Regular(MOVE, Me)
            End If
            If movingPiece.getTitle = Chessman.King Then CType(movingPiece, cKing).setHasMoved(True)
            Me._moveList.AddLast(MOVE.ToString)
            Me.UpdateBoardMembers(wasCapture, movingPiece, FROM_TRANSITION)
        Else
            Dim castlingTiles As Byte() = {58, 62, 2, 6}
            If Me._legalMoves.Contains(MOVE) Then

                'assume the move is added to the move list by the GUI

                If movingPiece.getTitle = Chessman.Pawn AndAlso targetTile.getCoordinate = Me._enPassentCoord Then  'en passent capture
                    Me._enPassentCoord = 255
                    sMove.EnPassentCapture(MOVE, Me)
                    wasCapture = True
                ElseIf movingPiece.getTitle = Chessman.Pawn AndAlso ((targetTile.getCoordinate \ 8 + 1 = 1) AndAlso movingPiece.getAlliance = Alliance.White) Then  'black promotion
                    sMove.Promotion(MOVE, Me)
                ElseIf movingPiece.getTitle = Chessman.Pawn AndAlso (targetTile.getCoordinate \ 8 + 1 = 8) AndAlso movingPiece.getAlliance = Alliance.Black Then    'white promotion
                    sMove.Promotion(MOVE, Me)
                ElseIf movingPiece.getTitle = Chessman.King AndAlso Not CType(movingPiece, cKing).getHasMoved AndAlso castlingTiles.Contains(MOVE.dest) Then        'castling
                    sMove.Castle(MOVE, Me)
                Else    'normal move66
                    sMove.Regular(MOVE, Me)
                End If

                'update the en-passent tile
                If movingPiece.getTitle = Chessman.Pawn Then
                    If 9 - (MOVE.ogCoord \ 8 + 1) = 2 Then
                        If MOVE.dest = MOVE.ogCoord - 16 Then
                            Me._enPassentCoord = CByte(MOVE.ogCoord - 8)
                        Else
                            Me._enPassentCoord = 255
                        End If
                    End If
                    If 9 - (MOVE.ogCoord \ 8 + 1) = 7 Then
                        If MOVE.dest = MOVE.ogCoord + 16 Then
                            Me._enPassentCoord = CByte(MOVE.ogCoord + 8)
                        Else
                            Me._enPassentCoord = 255
                        End If
                    End If
                Else
                    Me._enPassentCoord = 255
                End If

                If movingPiece.getTitle = Chessman.King Then CType(movingPiece, cKing).setHasMoved(True)

                'updates all members of the board that need to be updated after a move.
                Me.UpdateBoardMembers(wasCapture, movingPiece, FROM_TRANSITION)
            End If
        End If
    End Sub

    ''' <summary>
    ''' This updates all necessary members of board after a move is made.
    ''' </summary>
    ''' <param name="WAS_CAPTURE"></param>
    ''' <param name="MOVED_PIECE"></param>
    ''' <param name="FROM_TRANSITION"></param>
    Private Sub UpdateBoardMembers(WAS_CAPTURE As Boolean, MOVED_PIECE As cPiece, FROM_TRANSITION As Boolean)

        If WAS_CAPTURE Then
            Me._whitePieces = Me.updatePieces(Alliance.White)
            Me._blackPieces = Me.updatePieces(Alliance.Black)
            Debug.WriteLineIf(FROM_TRANSITION = False, "Move was recorded as a capture.")
        End If

        If Me._whosTurn = Alliance.White Then
            Me._whosTurn = Alliance.Black
            If Not WAS_CAPTURE AndAlso MOVED_PIECE.getTitle <> Chessman.Pawn Then _halfMoveTimer += CByte(1)
        Else
            Me._whosTurn = Alliance.White
            _plyCounter += 1
        End If

        Me._whitePseudoLegalMoves = Me.calculatePseudoLegalMoves(Alliance.White)
        Me._blackPseudoLegalMoves = Me.calculatePseudoLegalMoves(Alliance.Black)
        If Not FROM_TRANSITION Then Me._legalMoves = Me.calculateLegalMoves()
        Me._state = calculateBoardState()

        'If Not FROM_TRANSITION Then Me.ShowDebugReport()

    End Sub

    Public Function calculateBoardState() As GameState
        If Me._legalMoves Is Nothing Then
            If Me.isInCheck(Alliance.Black) Then
                Dim temp As String = Me._moveList.Last.Value
                Me._moveList.Last.Value = temp & "#"
                Return GameState.BlackMated
            ElseIf Me.isInCheck(Alliance.White) Then
                Dim temp As String = Me._moveList.Last.Value
                Me._moveList.Last.Value = temp & "#"
                Return GameState.WhiteMated
            Else
                Return GameState.Stalemate
            End If
        End If
        Return GameState.ongoing
    End Function

    Public Sub ShowDebugReport()
        Debug.WriteLine("##################################################")
        Debug.WriteLine("##################################################")
        Debug.WriteLine("##################################################")
        Debug.WriteLine("##################################################")
        Debug.WriteLine("##################################################")
        Debug.WriteLine("##################################################")
        Debug.WriteLine("")
        Debug.WriteLine("")

        Dim ctr As Integer = 1
        For i = 0 To 63
            If ctr > 8 Then
                Debug.Write(vbCrLf)
                ctr = 1
            End If
            If Me._tiles(i).getOccupied Then
                Debug.Write("[" & Me._tiles(i).getPiece.getChar & "]")
            Else
                Debug.Write("[ ]")
            End If
            ctr += 1
        Next
        Debug.Write(vbCrLf & vbCrLf)


        Debug.WriteLine("BOARD REPORT")
        Debug.WriteLine("-----------------")
        If Me._enPassentCoord <> 255 Then
            Debug.WriteLine("En-passent coordinate: " & Me._tiles(Me._enPassentCoord).getFile & Me._tiles(Me._enPassentCoord).getRank)
        Else
            Debug.WriteLine("En-passent coordinate: 255 [no en-passent]")
        End If

        If Me._legalMoves IsNot Nothing Then Debug.WriteLine("Legal move count: " & Me._legalMoves.Length)
        Debug.WriteLine("Last move: " & Me._moveList.Last.Value)
        Debug.WriteLine("Whos turn: " & Me._whosTurn)
        Debug.WriteLine("")
        Debug.WriteLine("")
    End Sub

End Class

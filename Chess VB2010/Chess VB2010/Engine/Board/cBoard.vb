Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()>
Public Class cBoard

    Private _tiles(63) As cTile

    Private _white_pseudo As sMove()
    Private _black_pseudo As sMove()

    Private _white_pieces As cPiece()
    Private _black_pieces As cPiece()

    Private _legal_moves As sMove()

    Private _whose_turn As Alliance
    Private _state As GameState

    Private _move_list As LinkedList(Of sMove)
    Private _move_list_string As LinkedList(Of String)

    'MANAGEMENT
    Private _en_passent_coord As Byte
    Private _half_move_timer As Integer
    Private _ply_counter As Integer

#Region "Mutators and Accessors"
    Public Function getTiles() As cTile()
        Return Me._tiles
    End Function

    Public Function getTile(COORDINATE As Byte) As cTile
        Return Me._tiles(COORDINATE)
    End Function

    Public Function getWhoseTurn() As Alliance
        Return Me._whose_turn
    End Function
    Public Sub setWhoseTurn(VALUE As Alliance)
        Me._whose_turn = VALUE
    End Sub

    Public Function getLegalMoves() As sMove()
        Return Me._legal_moves
    End Function

    Public Function getPseudoLegalMoves(ALLIANCE As Alliance) As sMove()
        If ALLIANCE = Alliance.White Then Return Me._white_pseudo Else Return Me._black_pseudo
    End Function

    Public Function getState() As GameState
        Return Me._state
    End Function

    Public Function getEnPassent() As Byte
        Return Me._en_passent_coord
    End Function

    Public Function getPieces(ALLIANCE As Alliance) As cPiece()
        If ALLIANCE = Alliance.White Then Return Me._white_pieces Else Return Me._black_pieces
    End Function
    Public Function getMoveListString() As LinkedList(Of String)
        Return Me._move_list_string
    End Function

    Public Function getMoveList() As LinkedList(Of sMove)
        Return Me._move_list
    End Function

    Public Function getHalfMoveTimer() As Integer
        Return Me._half_move_timer
    End Function
#End Region

#Region "Constructor"
    Public Sub New()
        Me._move_list = New LinkedList(Of sMove)
        Me._move_list_string = New LinkedList(Of String)
        Me.InitTiles()
        Me.InitBoard()
        Me._white_pieces = Me.updatePieces(Alliance.White)
        Me._black_pieces = Me.updatePieces(Alliance.Black)
        Me._white_pseudo = Me.calcPseudoLegalMoves(Alliance.White)
        Me._black_pseudo = Me.calcPseudoLegalMoves(Alliance.Black)
        Me._legal_moves = Me.calcLegalMoves()
    End Sub
#End Region

    Public Sub SetPosition(FEN As String)
        Throw New NotImplementedException
        'Forsyth-Edwards Notation FORMAT:
        'PIECE LOCATIONS/EMPTY SQUARES : WHOS TURN : CASTLING RIGHTS : EN-PASSENT TARGET SQUARE : HALFMOVE CLOCK : FULLMOVE NUMBER
        Dim counter As Integer = 0
        For Each tile As cTile In Me._tiles
            tile.set_piece(Nothing)
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
                Me._tiles(counter).set_piece(GeneratePiece(FEN(i), CByte(counter)))
                counter += 1
            End If
        Next
        If FEN(endOf + 1) = "w" Then
            Me._whose_turn = Alliance.White
        Else
            Me._whose_turn = Alliance.Black
        End If
    End Sub
    Public Function GeneratePiece(C As Char, COORDINATE As Byte) As cPiece
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
    Public Sub InitTiles()
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
        Me._en_passent_coord = 255
    End Sub
    Public Function findKing(alliance As Alliance) As cKing
        If alliance = Alliance.White Then
            For Each piece As cPiece In Me.getPieces(Alliance.White)
                If piece.get_title = Chessman.King Then Return CType(piece, cKing)
            Next
        Else
            For Each piece As cPiece In Me.getPieces(Alliance.Black)
                If piece.get_title = Chessman.King Then Return CType(piece, cKing)
            Next
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' Will return an updated cPiece array of all of the pieces currently on the instance of board from which it is called.
    ''' </summary>
    ''' <param name="alliance">Alliance of the set of pieces intended to be updated.</param>
    ''' <returns>Hey</returns>
    Public Function updatePieces(alliance As Alliance) As cPiece()
        Dim temp As cPiece() = Nothing
        Dim counter As Integer = 0
        For Each t As cTile In _tiles
            If t.is_occupied AndAlso t.get_piece.get_alliance = alliance Then
                ReDim Preserve temp(counter)
                temp(counter) = t.get_piece
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
    Private Sub InitBoard()
        'black major pieces
        _tiles(0).set_piece(New cRook(Alliance.Black, 0))
        _tiles(1).set_piece(New cKnight(Alliance.Black, 1))
        _tiles(2).set_piece(New cBishop(Alliance.Black, 2))
        _tiles(3).set_piece(New cQueen(Alliance.Black, 3))
        _tiles(4).set_piece(New cKing(Alliance.Black, 4))
        _tiles(5).set_piece(New cBishop(Alliance.Black, 5))
        _tiles(6).set_piece(New cKnight(Alliance.Black, 6))
        _tiles(7).set_piece(New cRook(Alliance.Black, 7))
        'black pawns
        For i = 8 To 15
            _tiles(i).set_piece(New cPawn(Alliance.Black, CByte(i)))
        Next

        'white pawns
        For i = 48 To 55
            _tiles(i).set_piece(New cPawn(Alliance.White, CByte(i)))
        Next
        'white major pieces
        _tiles(56).set_piece(New cRook(Alliance.White, 56))
        _tiles(57).set_piece(New cKnight(Alliance.White, 57))
        _tiles(58).set_piece(New cBishop(Alliance.White, 58))
        _tiles(59).set_piece(New cQueen(Alliance.White, 59))
        _tiles(60).set_piece(New cKing(Alliance.White, 60))
        _tiles(61).set_piece(New cBishop(Alliance.White, 61))
        _tiles(62).set_piece(New cKnight(Alliance.White, 62))
        _tiles(63).set_piece(New cRook(Alliance.White, 63))
    End Sub
    ''' <summary>
    ''' Returns the pseudo-legal moves of pieces of the specified alliance.
    ''' </summary>
    ''' <param name="alliance"></param>
    Private Function calcPseudoLegalMoves(alliance As Alliance) As sMove()
        Dim pieceSet As cPiece()
        If alliance = Alliance.White Then pieceSet = Me._white_pieces Else pieceSet = Me._black_pieces
        Dim temp As sMove() = Nothing
        Dim counter As Integer = 0
        For Each piece As cPiece In pieceSet
            If piece.calc_pseudo(Me) IsNot Nothing Then
                For Each move As sMove In piece.calc_pseudo(Me)
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
    Private Function calcLegalMoves() As sMove()
        Dim moveSet As sMove()
        Dim temp As sMove() = Nothing
        Dim counter As Integer = 0
        If Me._whose_turn = Alliance.White Then moveSet = Me._white_pseudo Else moveSet = Me._black_pseudo
        For Each move As sMove In moveSet
            Dim x As New cGhostBoard(Me, move)
            If x.is_legal Then
                ReDim Preserve temp(counter)
                temp(counter) = move
                counter += 1
            End If
        Next
        Return temp
    End Function
    Public Function isInCheck(alliance As Alliance) As Boolean
        Dim moveSet As sMove()
        Dim king As cKing
        If alliance = Alliance.White Then moveSet = Me._black_pseudo Else moveSet = Me._white_pseudo
        If alliance = Alliance.White Then king = Me.findKing(Alliance.White) Else king = Me.findKing(Alliance.Black)
        If moveSet Is Nothing Then Return False 'temp
        For Each move As sMove In moveSet
            If move.dest = king.get_coordinate Then Return True
        Next
        Return False
    End Function
    Public Function isLegalMove(move As sMove) As Boolean
        If Me._legal_moves IsNot Nothing AndAlso Me._legal_moves.Contains(move) Then Return True Else Return False
    End Function
    ''' <summary>
    ''' Updates the current instance of cBoard to reflect the move attempted, if the move is not legal, it will not be made.
    ''' </summary>
    ''' <param name="move"></param>
    ''' <param name="fromTransition"></param>
    Public Sub MakeMove(move As sMove, Optional fromTransition As Boolean = False)
        If move.ogCoord = 4 AndAlso move.dest = 2 Then MsgBox("TEST")
        Dim movingPiece As cPiece = Me.getTile(move.ogCoord).get_piece
        Dim targetTile As cTile = Me.getTile(move.dest)
        Dim wasCapture As Boolean
        wasCapture = Me._tiles(move.dest).is_occupied
        If fromTransition Then
            Dim castlingTiles As Byte() = {58, 62, 2, 6}
            If movingPiece.get_title = Chessman.Pawn AndAlso targetTile.get_coordinate = Me._en_passent_coord Then  'en passent capture
                sMove.enpassent(move, Me)
            ElseIf movingPiece.get_title = Chessman.Pawn AndAlso ((targetTile.get_coordinate \ 8 + 1 = 1) AndAlso movingPiece.get_alliance = Alliance.White) Then  'black promotion
                sMove.promotion(move, Me)
            ElseIf movingPiece.get_title = Chessman.Pawn AndAlso (targetTile.get_coordinate \ 8 + 1 = 8) AndAlso movingPiece.get_alliance = Alliance.Black Then    'white promotion
                sMove.promotion(move, Me)
            ElseIf movingPiece.get_title = Chessman.King AndAlso Not CType(movingPiece, cKing).get_moved AndAlso castlingTiles.Contains(move.dest) Then        'castling
                sMove.castle(move, Me)
            Else    'normal move66
                sMove.regular(move, Me)
            End If
            If movingPiece.get_title = Chessman.King Then CType(movingPiece, cKing).set_moved(True)
            Me._move_list_string.AddLast(move.ToString)
            Me.UpdateMembers(wasCapture, movingPiece, fromTransition)
        Else
            Dim castlingTiles As Byte() = {58, 62, 2, 6}
            If Me._legal_moves.Contains(move) Then

                'assume the move is added to the move list by the GUI

                If movingPiece.get_title = Chessman.Pawn AndAlso targetTile.get_coordinate = Me._en_passent_coord Then  'en passent capture
                    Me._en_passent_coord = 255
                    sMove.enpassent(move, Me)
                    wasCapture = True
                ElseIf movingPiece.get_title = Chessman.Pawn AndAlso ((targetTile.get_coordinate \ 8 + 1 = 1) AndAlso movingPiece.get_alliance = Alliance.White) Then  'black promotion
                    sMove.promotion(move, Me)
                ElseIf movingPiece.get_title = Chessman.Pawn AndAlso (targetTile.get_coordinate \ 8 + 1 = 8) AndAlso movingPiece.get_alliance = Alliance.Black Then    'white promotion
                    sMove.promotion(move, Me)
                ElseIf movingPiece.get_title = Chessman.King AndAlso Not CType(movingPiece, cKing).get_moved AndAlso castlingTiles.Contains(move.dest) Then        'castling
                    sMove.castle(move, Me)
                Else    'normal move66
                    sMove.regular(move, Me)
                End If

                'update the en-passent tile
                If movingPiece.get_title = Chessman.Pawn Then
                    If 9 - (move.ogCoord \ 8 + 1) = 2 Then
                        If move.dest = move.ogCoord - 16 Then
                            Me._en_passent_coord = CByte(move.ogCoord - 8)
                        Else
                            Me._en_passent_coord = 255
                        End If
                    End If
                    If 9 - (move.ogCoord \ 8 + 1) = 7 Then
                        If move.dest = move.ogCoord + 16 Then
                            Me._en_passent_coord = CByte(move.ogCoord + 8)
                        Else
                            Me._en_passent_coord = 255
                        End If
                    End If
                Else
                    Me._en_passent_coord = 255
                End If

                If movingPiece.get_title = Chessman.King Then CType(movingPiece, cKing).set_moved(True)

                If Not fromTransition Then Me._move_list.AddLast(move)

                'updates all members of the board that need to be updated after a move.
                Me.UpdateMembers(wasCapture, movingPiece, fromTransition)
            End If
        End If
    End Sub
    ''' <summary>
    ''' This updates all necessary members of board after a move is made.
    ''' </summary>
    ''' <param name="wasCapture"></param>
    ''' <param name="moved"></param>
    ''' <param name="fromTransition"></param>
    Private Sub UpdateMembers(wasCapture As Boolean, moved As cPiece, fromTransition As Boolean)

        If wasCapture Then
            Me._white_pieces = Me.updatePieces(Alliance.White)
            Me._black_pieces = Me.updatePieces(Alliance.Black)
            Debug.WriteLineIf(fromTransition = False, "Move was recorded as a capture.")
        End If

        If Me._whose_turn = Alliance.White Then
            Me._whose_turn = Alliance.Black
            If Not wasCapture AndAlso moved.get_title <> Chessman.Pawn Then _half_move_timer += CByte(1)
        Else
            Me._whose_turn = Alliance.White
            _ply_counter += 1
        End If

        Me._white_pseudo = Me.calcPseudoLegalMoves(Alliance.White)
        Me._black_pseudo = Me.calcPseudoLegalMoves(Alliance.Black)
        If Not fromTransition Then Me._legal_moves = Me.calcLegalMoves()
        Me._state = calcBoardState()

        If Not fromTransition Then Me.ShowReport()

    End Sub
    Public Function calcBoardState() As GameState
        If Me._legal_moves Is Nothing Then
            If Me.isInCheck(Alliance.Black) Then
                Dim temp As String = Me._move_list_string.Last.Value
                Me._move_list_string.Last.Value = temp & "#"
                Return GameState.BlackMated
            ElseIf Me.isInCheck(Alliance.White) Then
                Dim temp As String = Me._move_list_string.Last.Value
                Me._move_list_string.Last.Value = temp & "#"
                Return GameState.WhiteMated
            Else
                Return GameState.Stalemate
            End If
        End If
        Return GameState.ongoing
    End Function
    Public Function isOver() As Boolean
        With (Me)
            If ._state <> GameState.ongoing Then Return True Else Return False
        End With
    End Function
    Public Sub ShowReport()
        Try
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
                If Me._tiles(i).is_occupied Then
                    Debug.Write("[" & Me._tiles(i).get_piece.get_char & "]")
                Else
                    Debug.Write("[ ]")
                End If
                ctr += 1
            Next
            Debug.Write(vbCrLf & vbCrLf)

            Debug.WriteLine("BOARD REPORT")
            Debug.WriteLine("-----------------")
            If Me._en_passent_coord <> 255 Then
                Debug.WriteLine("En-passent coordinate: " & Me._tiles(Me._en_passent_coord).get_file & Me._tiles(Me._en_passent_coord).get_rank)
            Else
                Debug.WriteLine("En-passent coordinate: 255 [no en-passent]")
            End If

            If Me._legal_moves IsNot Nothing Then Debug.WriteLine("Legal move count: " & Me._legal_moves.Length)
            Debug.WriteLine("Last move: " & Me._move_list_string.Last.Value)
            Debug.WriteLine("Whos turn: " & Me._whose_turn)
            Debug.WriteLine("")
            Debug.WriteLine("")
        Catch ex As Exception

        End Try
    End Sub

End Class

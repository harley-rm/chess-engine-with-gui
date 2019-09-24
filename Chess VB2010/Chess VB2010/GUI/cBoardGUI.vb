<Serializable()>
Public Class cBoardGUI
    Inherits Panel

    Private WithEvents _game As cGame
    Private _board As cBoard
    Private _gameGUI As cGameGUI

    Private _tiles(63) As PictureBox
    Private _lightSquare As Color
    Private _darkSquare As Color

    Private _whiteBottom As Boolean

    'ui mechanics
    Private _selectedPiece As cPiece
    Private _lastMove As sMove
    Private _ogCol As Color
    Private _destCol As Color
    Private _showLegal As Boolean

    'drag drop graphics
    Private _ogTile As PictureBox
    Private _heldPiece As cPieceGraphics

    'mouse enter graphics
    Private _tileBorder As cTileBorder

    Private _showingGhostBoard As Boolean

    Public Function calc_size() As Integer
        Return CInt(Me.Size.Height / 8)
    End Function


#Region "Mutators & Accessors"
    Public Function get_light_colour() As Color
        Return Me._lightSquare
    End Function
    Public Sub set_light_colour(VALUE As Color)
        Me._lightSquare = VALUE
    End Sub

    Public Function get_dark_colour() As Color
        Return Me._darkSquare
    End Function
    Public Sub set_dark_colour(VALUE As Color)
        Me._darkSquare = VALUE
    End Sub

    Public Sub set_show_legal(VALUE As Boolean)
        Me._showLegal = VALUE
    End Sub

    Public Sub set_board(VALUE As cBoard)
        Me._board = VALUE
        Me.update_graphics()
    End Sub
    Public Function get_board() As cBoard
        Return Me._board
    End Function
#End Region

    Public Sub New(GAME As cGame, BOARD As cBoard, BOARD_DIMENSION As Integer, SETTINGS As sSettings, GAME_GUI As cGameGUI)
        Me._lightSquare = SETTINGS.lightSquare
        Me._darkSquare = SETTINGS.darkSquare
        Me._showLegal = SETTINGS.showLegalMoves

        Me._ogCol = Color.Gold
        Me._destCol = Color.Yellow

        Me._tileBorder = New cTileBorder(CInt(BOARD_DIMENSION / 8), Color.White)
        Me.Controls.Add(Me._tileBorder)
        Me._tileBorder.BringToFront()
        Me._tileBorder.Hide()

        Me._gameGUI = GAME_GUI
        Me._whiteBottom = True

        'instantiates the held piece object, for drag dropping.
        Me._heldPiece = New cPieceGraphics(CInt(BOARD_DIMENSION / 8))
        Me.Controls.Add(_heldPiece)
        With (Me._heldPiece)
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Hide()
        End With

        Me._board = BOARD
        Me._game = GAME
        Me.Size = New Size(BOARD_DIMENSION, BOARD_DIMENSION)
        Me.init_tiles(CInt(BOARD_DIMENSION / 8))
        Me.add_handlers()
        Me.update_graphics()
    End Sub

    Public Sub resize_all(NEW_TILE_SIZE As Integer)
        Me.Size = New Size(NEW_TILE_SIZE * 8, NEW_TILE_SIZE * 8)
        Dim col As Color = Me._lightSquare
        Dim x As Integer = 0
        Dim y As Integer = 0
        Me._tileBorder.Hide()

        For i = 0 To 63
            _tiles(i) = New PictureBox
            With _tiles(i)
                .Size = New Size(NEW_TILE_SIZE, NEW_TILE_SIZE)
                .Location = New Point(x, y)
                x += NEW_TILE_SIZE
                If x = 8 * NEW_TILE_SIZE Then
                    y += NEW_TILE_SIZE
                    x = 0
                End If
            End With
        Next

        Me._heldPiece.Dispose()
        Me._heldPiece = New cPieceGraphics(CInt(NEW_TILE_SIZE))

    End Sub

    Private Sub init_tiles(TILE_SIZE As Integer)
        Dim col As Color = Me._lightSquare
        Dim x As Integer = 0
        Dim y As Integer = 0

        For i = 0 To 63
            _tiles(i) = New PictureBox
            With _tiles(i)
                Me.Controls.Add(_tiles(i))
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BackgroundImageLayout = ImageLayout.Center
                .BackColor = col
                .Size = New Size(TILE_SIZE, TILE_SIZE)
                .Location = New Point(x, y)
                .Cursor = Cursors.Hand
                x += TILE_SIZE
                If x = 8 * TILE_SIZE Then
                    y += TILE_SIZE
                    x = 0
                    If col = Me._lightSquare Then col = Me._darkSquare Else col = Me._lightSquare
                End If
                If col = Me._lightSquare Then col = Me._darkSquare Else col = Me._lightSquare
            End With
        Next
    End Sub

    Private Function calc_image(ALLIANCE As Alliance, TITLE As Chessman) As Bitmap
        Select Case ALLIANCE
            Case Alliance.White
                Select Case TITLE
                    Case Chessman.Pawn
                        Return My.Resources.awP
                    Case Chessman.Knight
                        Return My.Resources.awN
                    Case Chessman.Bishop
                        Return My.Resources.awB
                    Case Chessman.Rook
                        Return My.Resources.awR
                    Case Chessman.Queen
                        Return My.Resources.awQ
                    Case Chessman.King
                        Return My.Resources.awK
                End Select
            Case Alliance.Black
                Select Case TITLE
                    Case Chessman.Pawn
                        Return My.Resources.abP
                    Case Chessman.Knight
                        Return My.Resources.abN
                    Case Chessman.Bishop
                        Return My.Resources.abB
                    Case Chessman.Rook
                        Return My.Resources.abR
                    Case Chessman.Queen
                        Return My.Resources.abQ
                    Case Chessman.King
                        Return My.Resources.abK
                End Select
        End Select
        Return Nothing
    End Function

    Public Sub update_graphics()
        If Me._board IsNot Nothing AndAlso Me._board.getMoveList.Last IsNot Nothing Then Me._lastMove = Me._board.getMoveList.Last.Value
        'update the back colour and resets the background image
        For i = 0 To 63
            If _selectedPiece IsNot Nothing AndAlso _selectedPiece.get_coordinate = i Then
                Me._tiles(i).BackColor = Color.Orange
            Else
                If Me._board.getTiles(i).get_is_lightsquare Then
                    Me._tiles(i).BackColor = _lightSquare
                Else
                    Me._tiles(i).BackColor = _darkSquare
                End If
            End If
            Me._tiles(i).BackgroundImage = Nothing
        Next
        'update the image on each tile
        For i = 0 To 63
            If Me._board.getTiles(i).is_occupied Then
                Dim x As New Bitmap(calc_image(Me._board.getTiles(i).get_piece.get_alliance, Me._board.getTiles(i).get_piece.get_title), New Size(Me._tiles(0).Height - 5, Me._tiles(0).Height - 5))
                Me._tiles(i).Image = x
            Else
                Me._tiles(i).Image = Nothing
            End If
        Next

        'update the possible moves
        If Me._selectedPiece IsNot Nothing AndAlso Me._selectedPiece.calc_pseudo(Me._board) IsNot Nothing Then
            For Each move As sMove In _selectedPiece.calc_pseudo(Me._board)
                If _board.isLegalMove(move) Then

                    If Me._showLegal Then
                        If _board.getTiles(move.dest).is_occupied Then
                            Me._tiles(move.dest).BackgroundImageLayout = ImageLayout.Stretch
                            Me._tiles(move.dest).BackgroundImage = My.Resources.attackedOccupied
                        Else
                            Me._tiles(move.dest).BackgroundImageLayout = ImageLayout.Center
                            Me._tiles(move.dest).BackgroundImage = New Bitmap(My.Resources.attacked, New Size(CInt(Me._tiles(move.dest).Size.Height / 3), CInt(Me._tiles(move.dest).Size.Width / 3)))
                        End If
                    Else
                        Me._tiles(move.dest).BackgroundImage = Nothing
                    End If

                End If
            Next
        End If

        'update check indicators
        If Me._board.isInCheck(Alliance.White) Then
            Me._tiles(Me._board.findKing(Alliance.White).get_coordinate).BackColor = Color.IndianRed
        End If
        If Me._board.isInCheck(Alliance.Black) Then
            Me._tiles(Me._board.findKing(Alliance.Black).get_coordinate).BackColor = Color.IndianRed
        End If

        'update move indicators
        If Me._lastMove <> Nothing Then
            Me._tiles(_lastMove.ogCoord).BackColor = Me._ogCol
            Me._tiles(_lastMove.dest).BackColor = Me._destCol
        End If

        With Me._board
            If .getState <> GameState.ongoing Then

                If .getState = GameState.WhiteMated Then
                    My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\checkmate.wav")
                ElseIf .getState = GameState.BlackMated Then
                    My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & "\checkmate.wav")
                End If
                game_end_form.Show()

                game_end_form.Location = New Point(CInt(PointToScreen(Me.Location).X + (Me.Width / 2) - (game_end_form.Width * 1.24)), CInt(PointToScreen(Me.Location).Y) + CInt(Me.Height / 2) - CInt(game_end_form.Height / 2))

            End If
        End With

    End Sub

    Private Sub add_handlers()
        For i = 0 To 63
            AddHandler Me._tiles(i).MouseDown, AddressOf e_mousedown
            AddHandler Me._tiles(i).MouseMove, AddressOf e_mousemove
            AddHandler Me._tiles(i).MouseUp, AddressOf e_mouseup
        Next
    End Sub

    Private Function find_tile_index(sender As Object) As Integer
        For i = 0 To 63
            If CType(sender, PictureBox) Is Me._tiles(i) Then Return i
        Next
    End Function

#Region "Handlers"

    Private Sub e_mousedown(SENDER As Object, E As MouseEventArgs)
        If E.Button = MouseButtons.Left AndAlso Not (Me._board.isOver) Then

            Me.Cursor = Cursors.SizeAll
            Me._ogTile = CType(SENDER, PictureBox)
            Dim clickedTile As cTile = Me._board.getTiles(Me.find_tile_index(SENDER))
            Dim clickedTilePB As PictureBox = CType(SENDER, PictureBox)
            If clickedTile.is_occupied AndAlso clickedTile.get_piece.get_alliance = Me._board.getWhoseTurn Then
                If Me._selectedPiece Is Nothing AndAlso clickedTile.is_occupied AndAlso clickedTile.get_piece.get_alliance = Me._board.getWhoseTurn Or Me._ogTile.Bounds.Contains(PointToClient(MousePosition)) Then
                    'if a piece hasn't already been selected and is a valid piece to move then select the clicked piece.
                    Me._selectedPiece = clickedTile.get_piece
                    Me.update_graphics()
                    With (Me._heldPiece)
                        .Show()
                        .UpdateImage(calc_image(Me._selectedPiece.get_alliance, Me._selectedPiece.get_title))
                        .Location = clickedTilePB.Location
                        .BringToFront()
                    End With
                    Me._tileBorder.Show()
                    clickedTilePB.Image = Nothing
                End If

            ElseIf _selectedPiece IsNot Nothing Then
                Dim destTile As PictureBox
                For i = 0 To UBound(Me._tiles)
                    If Me._tiles(i).Bounds.Contains(PointToClient(MousePosition)) Then destTile = Me._tiles(i)
                Next    'finds the destination button

                If destTile Is Nothing Then Throw New Exception

                Dim m As New sMove(Me._selectedPiece.get_coordinate, Me._board.getTiles(Me.find_tile_index(destTile)).get_coordinate)
                If Me._board.isLegalMove(m) Then

                    Me.move_made(m)

                Else
                    'if the move is not valid
                    Me._selectedPiece = Nothing
                    Me._ogTile = Nothing
                    Me.update_graphics()
                End If
            Else
                'if the move is not valid
                Me._selectedPiece = Nothing
                Me._ogTile = Nothing
                Me.update_graphics()
            End If


        ElseIf E.Button = MouseButtons.Right Then
            If CType(SENDER, PictureBox).BackColor = Color.Green Or CType(SENDER, PictureBox).BackColor = Color.Red Or CType(SENDER, PictureBox).BackColor = Color.Blue Then
                If Me._lastMove <> Nothing Then
                    If Me._lastMove.ogCoord = find_tile_index(SENDER) Then
                        CType(SENDER, PictureBox).BackColor = Me._ogCol
                    ElseIf Me._lastMove.dest = find_tile_index(SENDER) Then
                        CType(SENDER, PictureBox).BackColor = Me._destCol
                    Else
                        If Me._board.getTiles(Me.find_tile_index(SENDER)).get_is_lightsquare Then CType(SENDER, PictureBox).BackColor = Me._lightSquare Else CType(SENDER, PictureBox).BackColor = Me._darkSquare
                    End If
                Else
                    If Me._board.getTiles(Me.find_tile_index(SENDER)).get_is_lightsquare Then CType(SENDER, PictureBox).BackColor = Me._lightSquare Else CType(SENDER, PictureBox).BackColor = Me._darkSquare
                End If
            Else
                If My.Computer.Keyboard.AltKeyDown Then
                    CType(SENDER, PictureBox).BackColor = Color.Green
                ElseIf My.Computer.Keyboard.ShiftKeyDown Then
                    CType(SENDER, PictureBox).BackColor = Color.Blue
                Else
                    CType(SENDER, PictureBox).BackColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub e_mousemove(SENDER As Object, E As MouseEventArgs)
        If Me._selectedPiece IsNot Nothing Then
            Dim mp As Point = New Point(CInt(PointToClient(MousePosition).X - Me._heldPiece.Width / 2), CInt(PointToClient(MousePosition).Y - Me._heldPiece.Height / 2))
            If E.Button = MouseButtons.Left Then
                Me._heldPiece.Location = mp

                Dim t As PictureBox
                For Each temp As PictureBox In Me._tiles
                    If temp.Bounds.Contains(PointToClient(MousePosition)) Then
                        t = temp
                        Exit For
                    End If
                Next
                If t IsNot Nothing Then Me._tileBorder.Location = t.Location
            End If
        End If
    End Sub

    Private Sub e_mouseup(SENDER As Object, E As MouseEventArgs)
        If E.Button = MouseButtons.Left Then

            Me._tileBorder.Hide()
            Me.Refresh()
            Me._heldPiece.Hide()

            If _selectedPiece IsNot Nothing Then

                If Me._ogTile.Bounds.Contains(PointToClient(MousePosition)) Then
                    Me._ogTile.Image = New Bitmap(Me.calc_image(Me._selectedPiece.get_alliance, Me._selectedPiece.get_title), New Size(70, 70))
                Else
                    Dim destTile As PictureBox
                    For i = 0 To UBound(Me._tiles)
                        If Me._tiles(i).Bounds.Contains(PointToClient(MousePosition)) Then destTile = Me._tiles(i)
                    Next    'finds the destination button

                    Dim m As New sMove(Me._selectedPiece.get_coordinate, Me._board.getTiles(Me.find_tile_index(destTile)).get_coordinate)

                    If Me._board.isLegalMove(m) Then
                        Me.move_made(m)
                    Else
                        'if the move is not valid
                        Me._selectedPiece = Nothing
                        Me._ogTile = Nothing
                        Me.update_graphics()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub move_made(m As sMove)
        Dim wasCapture As Boolean = Me._board.getTiles(m.dest).is_occupied

        Dim whosTurn As Alliance = _board.getWhoseTurn

        Me._board.getMoveListString.AddLast(m.ToString(Me._board))
        Me._gameGUI.getMoveList.AddMove(m.ToString(Me._board), _board.getWhoseTurn)
        _board.MakeMove(m)

        Me._game.boardList.AddLast(Me._board.getDeepClone(Of cBoard)(Me._board))   'update the board list
        Me._gameGUI._moveListGUI.UpdateOpeningName()

        Me._ogTile = Nothing
        Me._selectedPiece = Nothing
        Me._lastMove = m    'updates the last move made in the game.

        Me.update_graphics()

        If whosTurn <> _board.getWhoseTurn Then  'this verifies that the move was actually played and legal
            Dim ext As String = Nothing
            If wasCapture Then ext = "\capture.wav" Else ext = "\pieceMoved.wav"
            My.Computer.Audio.Play(System.AppDomain.CurrentDomain.BaseDirectory & ext)
        End If

    End Sub

#End Region

    Public Sub flip_board()
        Me._gameGUI.getBoardWrapper.FlipRankMarkers()

        Dim xGap As Integer
        xGap = (Me._tiles(0).Location.X + Me._tiles(0).Width) - Me._tiles(1).Location.X
        Dim yGap As Integer
        yGap = (Me._tiles(0).Location.Y + Me._tiles(0).Height) - Me._tiles(8).Location.Y

        Dim x, y As Integer
        Dim [start], [end], [step] As Integer
        If Me._whiteBottom Then
            start = 63 : [end] = 0 : [step] = -1
        Else
            start = 0 : [end] = 63 : [step] = +1
        End If
        For i = [start] To [end] Step [step]
            With _tiles(i)
                .Location = New Point(x, y)
                x += Me._tiles(0).Width
                If x = 8 * Me._tiles(0).Width Then
                    y += Me._tiles(0).Width
                    x = 0
                End If
            End With
        Next
        Me.update_graphics()
        Me.Update()
        Me._whiteBottom = Not Me._whiteBottom
        Debug.WriteLine(CStr("Board flipped, whiteBottom: " & Me._whiteBottom.ToString))
    End Sub

    ''' <summary>
    ''' Will temporarily display the referenced board on the GUI until any event causes the current position to be loaded again (i.e. a move being played,
    ''' mouse down event etc).
    ''' </summary>
    ''' <param name="BOARD">Reference to the board that you would like to display.</param>
    ''' <remarks></remarks>
    Private Sub update_ghost_graphics(BOARD As cBoard)
        Me._lastMove = BOARD.getMoveList.Last.Value
        'update the back colour and resets the background image
        For i = 0 To 63
            If _selectedPiece IsNot Nothing AndAlso _selectedPiece.get_coordinate = i Then
                Me._tiles(i).BackColor = Color.Orange
            Else
                If BOARD.getTiles(i).get_is_lightsquare Then
                    Me._tiles(i).BackColor = _lightSquare
                Else
                    Me._tiles(i).BackColor = _darkSquare
                End If
            End If
            Me._tiles(i).BackgroundImage = Nothing
        Next
        'update the image on each tile
        For i = 0 To 63
            If BOARD.getTiles(i).is_occupied Then
                Dim x As New Bitmap(calc_image(BOARD.getTiles(i).get_piece.get_alliance, BOARD.getTiles(i).get_piece.get_title), New Size(Me._tiles(0).Height - 5, Me._tiles(0).Height - 5))
                Me._tiles(i).Image = x
            Else
                Me._tiles(i).Image = Nothing
            End If
        Next

        'update the possible moves
        If Me._selectedPiece IsNot Nothing AndAlso Me._selectedPiece.calc_pseudo(BOARD) IsNot Nothing Then
            For Each move As sMove In _selectedPiece.calc_pseudo(BOARD)
                If BOARD.isLegalMove(move) Then

                    If Me._showLegal Then
                        If BOARD.getTiles(move.dest).is_occupied Then
                            Me._tiles(move.dest).BackgroundImageLayout = ImageLayout.Stretch
                            Me._tiles(move.dest).BackgroundImage = My.Resources.attackedOccupied
                        Else
                            Me._tiles(move.dest).BackgroundImageLayout = ImageLayout.Center
                            Me._tiles(move.dest).BackgroundImage = New Bitmap(My.Resources.attacked, New Size(CInt(Me._tiles(move.dest).Size.Height / 3), CInt(Me._tiles(move.dest).Size.Width / 3)))
                        End If
                    Else
                        Me._tiles(move.dest).BackgroundImage = Nothing
                    End If

                End If
            Next
        End If

        'update check indicators
        If BOARD.isInCheck(Alliance.White) Then
            Me._tiles(BOARD.findKing(Alliance.White).get_coordinate).BackColor = Color.IndianRed
        End If
        If BOARD.isInCheck(Alliance.Black) Then
            Me._tiles(BOARD.findKing(Alliance.Black).get_coordinate).BackColor = Color.IndianRed
        End If

        'update move indicators
        If Me._lastMove <> Nothing Then
            Me._tiles(_lastMove.ogCoord).BackColor = Me._ogCol
            Me._tiles(_lastMove.dest).BackColor = Me._destCol
        End If

        Me._showingGhostBoard = True

    End Sub
    Public Sub show_ghost_position(moveIndex As Integer)
        Dim toShow As cBoard = Me._game.boardList(moveIndex)
        If toShow Is Me._game.boardList.Last.Value Then
            update_graphics()
        Else
            update_ghost_graphics(toShow)
        End If
    End Sub

End Class

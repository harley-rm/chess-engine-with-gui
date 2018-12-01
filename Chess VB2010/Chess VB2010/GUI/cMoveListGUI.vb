Public Class cMoveListGUI
    Inherits Panel
    Private _game As cGame
    Public openingTB As TextBox
    Private WithEvents _moveList As DataGridView

    Public Sub New(GAME As cGame, BOARD As cBoard, HEIGHT As Integer)
        Me._game = GAME

        Me._moveList = New DataGridView
        Me.Size = New Size(200, HEIGHT)
        Me.Controls.Add(Me._moveList)
        Me.DrawDGV()

        Me.openingTB = New TextBox
        Me.Controls.Add(openingTB)
        With Me.openingTB
            .Size = New Size(200, 40)
            .Location = New Point(0, Me._moveList.Height + 10)
            .ReadOnly = True
            .TextAlign = HorizontalAlignment.Center
            .Text = "000: Starting Position"
            .BringToFront()
        End With

    End Sub

    Public Sub ResizeAll(HEIGHT As Integer)
        Me.Size = New Size(200, HEIGHT)
        Me._moveList.Size = New Size(200, HEIGHT - 50)
        Me.openingTB.Location = New Point(0, Me._moveList.Height + 10)
    End Sub

    Private Sub UpdateOpeningName()
        Dim moveList As String = ""
        Dim halfPlys As Integer = 0
        Dim no As Integer = 1
        Dim whitesMove As Boolean = True
        For Each move As String In Me._game.getBoard.getMoveList
            If whitesMove Then
                moveList &= no & "." & move
                whitesMove = Not (whitesMove)
                halfPlys += 1
                moveList &= " "
            Else
                moveList &= move
                no += 1
                whitesMove = Not (whitesMove)
                halfPlys += 1
                moveList &= " "
            End If
        Next
        'remove the extra space off of the end of the string
        moveList = Strings.RTrim(moveList)

        FileOpen(1, System.AppDomain.CurrentDomain.BaseDirectory & "\ecocodes9.txt", OpenMode.Input)
        LineInput(1)
        LineInput(1)    ''skips the two credit lines in the file
        For i = 0 To 10402
            Dim line As String = LineInput(1)
            Dim ECO As String = line(1) & line(2) & line(3)
            Dim openingName As String = ""
            Dim ctr As Integer = 7
            Dim c As Char = line(ctr)
            Do Until c = "}"
                openingName &= c
                ctr += 1
                c = line(ctr)
            Loop

            Dim parsedMoveList As String = Strings.Right(line, line.Length - 1 - ctr)
            If parsedMoveList = moveList Then
                Me.openingTB.Text = ECO & ": " & openingName
                FileClose(1)
                Exit For
            End If
        Next
        FileClose(1)
        '' < 12ms elapsed
    End Sub

    Public Sub DrawDGV()
        With Me._moveList
            .Size = New Size(200, Height - 50)
            .Location = New Point(0, 0)
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .Columns.Add("moveNumber", "#")
            .Columns.Add("whiteMoves", "White")
            .Columns.Add("blackMoves", "Black")
            .ScrollBars = ScrollBars.Vertical
            .RowHeadersVisible = False
            .Columns.Item(0).Width = 50     'move count column
            .Columns.Item(1).Width = 75     'white move column
            .Columns.Item(2).Width = 75     'black move column
            .BringToFront()
        End With
    End Sub

    Public Sub ClearAndUpdate()
        Me._moveList.Rows.Clear()
        Dim isWhite As Alliance = Alliance.White
        For Each move As String In Me._game.getBoard.getMoveList
            Me.AddMove(move, isWhite)
            isWhite = Not isWhite
        Next
        '' < 40ms elapsed
    End Sub

    Public Sub AddMove(MOVE As sMove)
        With Me._moveList
            If Me._game.getBoard.getWhosTurn = Alliance.White Then
                .Rows.Add()
            End If
            Dim rowIndex As Integer = .Rows.GetLastRow(DataGridViewElementStates.Displayed)
            Me._moveList.FirstDisplayedScrollingRowIndex = rowIndex
            If Me._game.getBoard.getWhosTurn = Alliance.White Then
                .Item(0, rowIndex).Value = CStr(rowIndex + 1) & "."
            End If
            Dim columnIndex As Integer
            If Me._game.getBoard.getWhosTurn = Alliance.White Then columnIndex = 1 Else columnIndex = 2
            .Item(columnIndex, rowIndex).Value = MOVE.ToString(Me._game.getBoard)
        End With

        UpdateOpeningName()
    End Sub

    Public Sub AddMove(TEXT As String)
        With Me._moveList
            If Me._game.getBoard.getWhosTurn = Alliance.White Then
                .Rows.Add()
            End If
            Dim rowIndex As Integer = .Rows.GetLastRow(DataGridViewElementStates.Displayed)
            Me._moveList.FirstDisplayedScrollingRowIndex = rowIndex
            If Me._game.getBoard.getWhosTurn = Alliance.White Then
                .Item(0, rowIndex).Value = CStr(rowIndex + 1) & "."
            End If
            Dim columnIndex As Integer
            If Me._game.getBoard.getWhosTurn = Alliance.White Then columnIndex = 1 Else columnIndex = 2
            .Item(columnIndex, rowIndex).Value = TEXT
        End With
        UpdateOpeningName()
    End Sub

    Public Sub AddMove(TEXT As String, WHOS_TURN As Alliance)
        With Me._moveList
            If WHOS_TURN = Alliance.White Then
                .Rows.Add()
            End If
            Dim rowIndex As Integer = .Rows.GetLastRow(DataGridViewElementStates.Displayed)
            Me._moveList.FirstDisplayedScrollingRowIndex = rowIndex
            If WHOS_TURN = Alliance.White Then
                .Item(0, rowIndex).Value = CStr(rowIndex + 1) & "."
            End If
            Dim columnIndex As Integer
            If WHOS_TURN = Alliance.White Then columnIndex = 1 Else columnIndex = 2
            .Item(columnIndex, rowIndex).Value = TEXT
        End With
        UpdateOpeningName()
    End Sub

End Class

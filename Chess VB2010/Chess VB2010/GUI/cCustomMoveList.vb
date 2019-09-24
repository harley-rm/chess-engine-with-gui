'designed to be able to show moves from a standard chess game of two players. Also supports variants such as crazyhouse etc.
'also includes events that allow previous positions from a game to be mirrored on the board gui through aggregation.
Public Class cCustomMoveList
    Inherits Panel
    Private _gameGUI As cGameGUI

    Private _openingText As Label

    'headers
    Private _h1 As Label
    Private _h2 As Label
    Private _h3 As Label

    Private _bgCol As Color     'bg
    Private _primCol As Color   'headers, opening text, count
    Private _secCol As Color    'entries

    Private _numberLabels As Label()
    Private _noOfRows As Integer

    Private _entryPanel As Panel    'used for the scrolling function

    Private _entries As Label()
    Private _entryCount As Integer

    Private _maxHeight As Integer

    'scroll stuff
    Private WithEvents _scrollBar As Panel
    Private _maxNoOfRows As Byte

    Private _hoverCol As Color = Color.FromArgb(80, 80, 80)

    Private _selectedLbl As Label
    Private _selectedCol As Color = Color.FromArgb(70, 70, 70)


#Region "Accessors and Mutators"

    Public Function getEntryCount() As Integer
        Return Me._entryCount
    End Function

    Public Sub setBackgroundColour(BG As Color)
        Me._bgCol = BG
    End Sub
    Public Sub setPrimaryColour(PRIM As Color)
        Me._primCol = PRIM
    End Sub
    Public Sub setSecondaryColour(SEC As Color)
        Me._secCol = SEC
    End Sub

    Public Function getBackgroundColour() As Color
        Return Me._bgCol
    End Function
    Public Function getPrimaryColour() As Color
        Return Me._primCol
    End Function
    Public Function getSecondaryColour() As Color
        Return Me._secCol
    End Function

#End Region

    Public Sub New(GAME_GUI As cGameGUI, BG_COL As Color, PRIM_COL As Color, SEC_COL As Color)
        Me._gameGUI = GAME_GUI
        Me._entryCount = 0 : Me._noOfRows = 0
        Me.Size = New Size(200, 40)
        Me._bgCol = BG_COL : Me._primCol = PRIM_COL : Me._secCol = SEC_COL
        Me.InitHeaders()
        Me.InitOpeningText()
        Me.InitEntryPanel()
        Me.InitScroll()
        Me._maxHeight = CInt(GAME_GUI.getBoardGUI.Height / 2)
        Me._maxNoOfRows = CByte((Me._maxHeight) \ 20)
    End Sub

#Region "Init methods"

    Private Sub InitHeaders()
        Dim lSet = Sub(ByRef lbl As Label, width As Integer, TEXT As String)
                       lbl = New Label : Me.Controls.Add(lbl)
                       lbl.AutoSize = False
                       lbl.Size = New Size(width, 20)
                       lbl.BackColor = Me._primCol
                       lbl.Font = New Font("Microsoft Sans Serif", 8)
                       lbl.ForeColor = Me._primCol
                       lbl.BackColor = Me._bgCol
                       lbl.Text = TEXT
                       lbl.TextAlign = ContentAlignment.MiddleCenter
                       lbl.BorderStyle = BorderStyle.FixedSingle
                   End Sub

        lSet(Me._h1, 40, "#")
        lSet(Me._h2, 77, "White")
        lSet(Me._h3, 77, "Black")
        Me._h1.Location = New Point(0, 20)
        Me._h2.Location = New Point(40, 20)
        Me._h3.Location = New Point(117, 20)
    End Sub

    Private Sub InitOpeningText()
        Me._openingText = New Label
        Me.Controls.Add(Me._openingText)
        With Me._openingText
            .AutoSize = False
            .Size = New Size(200, 20)
            .Location = New Point(0, 0)
            .Font = New Font("Microsoft Sans Serif", 8)
            .ForeColor = Me._primCol
            .BackColor = Me._bgCol
            .TextAlign = ContentAlignment.MiddleLeft
            .Text = "Z00: Starting Position"
            .BorderStyle = BorderStyle.FixedSingle
        End With
    End Sub

    Private Sub InitEntryPanel()
        Me._entryPanel = New Panel
        Me.Controls.Add(Me._entryPanel)
        With Me._entryPanel
            .Location = New Point(0, 40)
            .Size = New Size(194, 0)
        End With
    End Sub

    Private Sub InitScroll()
        Me._scrollBar = New Panel
        Me.Controls.Add(Me._scrollBar)
        With Me._scrollBar
            .Location = New Point(194, 20)
            .Size = New Size(10, 20)
            .BackColor = Color.FromArgb(80, 80, 80)
        End With
    End Sub



#End Region

    Public Sub AddMove(MOVE_STRING As String, WHOS_TURN As Alliance)
        ReDim Preserve Me._entries(Me._entryCount)
        Me._entries(Me._entryCount) = New Label

        'add handlers
        AddHandler Me._entries(Me._entryCount).MouseEnter, AddressOf Me.e_label_mouseenter
        AddHandler Me._entries(Me._entryCount).MouseLeave, AddressOf Me.e_label_mouseleave
        AddHandler Me._entries(Me.getEntryCount).Click, AddressOf Me.e_label_click

        Me._entryPanel.Controls.Add(Me._entries(Me._entries.Length - 1))

        If WHOS_TURN = Alliance.White Then  'add the # if starting a new row
            ReDim Preserve Me._numberLabels(Me._noOfRows)
            Me._numberLabels(Me._noOfRows) = New Label
            Me._entryPanel.Controls.Add(Me._numberLabels(Me._noOfRows))

            With Me._numberLabels(Me._noOfRows)
                .Text = (Me._noOfRows + 1).ToString
                .TextAlign = ContentAlignment.MiddleLeft
                .Size = New Size(77, 20)
                .Font = New Font("Microsoft Sans Serif", 8)
                .Location = New Point(0, Me._noOfRows * 20)
                .ForeColor = Me._primCol
                .BackColor = Me._secCol
            End With
            Me._noOfRows += 1
        End If

        Dim xOffset As Integer : If WHOS_TURN = Alliance.White Then xOffset = 40 Else xOffset = 117
        With Me._entries(Me._entries.Length - 1)
            .Text = MOVE_STRING
            .TextAlign = ContentAlignment.MiddleLeft
            .Size = New Size(77, 20)
            .Font = New Font("Microsoft Sans Serif", 8)
            .Location = New Point(xOffset, (Me._noOfRows - 1) * 20)
            .ForeColor = Me._primCol
            .BackColor = Me._secCol
        End With
        Me._entryCount += 1
        Me.ResizeAll()
        Me._selectedLbl = Me._entries(UBound(Me._entries))
        Me.update_label_graphics()
    End Sub

    Private Sub ResizePanels()
        Me._entryPanel.Size = New Size(Me._entryPanel.Size.Width, (Me._noOfRows * 20))
        'If Me._noOfRows <= Me._maxNoOfRows Then
        With (Me)
            If Me._noOfRows < Me._maxNoOfRows Then
                .Size = New Size(.Width, 40 + (Me._noOfRows * 20))
            Else
                .Size = New Size(.Width, 40 + (Me._maxNoOfRows * 20))
            End If

        End With
        'End If
        'scroll is updated regardless
    End Sub

    Public Sub ClearAndUpdate(BOARD As cBoard)
        For Each lbl As Label In Me._entries
            Me.Controls.Remove(lbl)
            lbl.Dispose()
        Next
        For Each lbl As Label In Me._numberLabels
            Me.Controls.Remove(lbl)
            lbl.Dispose()
        Next
        Me._noOfRows = 0

        Dim whosTurn As Alliance = Alliance.White
        Me._entryCount = 0
        Me._entries = Nothing
        For Each strMove As String In BOARD.getMoveListString
            AddMove(strMove, whosTurn)
            whosTurn = Not (whosTurn)
        Next
        Me.UpdateOpeningName()
    End Sub

    Public Sub UpdateOpeningName()
        Dim moveList As String = ""
        Dim halfPlys As Integer = 0
        Dim no As Integer = 1
        Dim whitesMove As Boolean = True
        For Each move As String In Me._gameGUI.getBoardGUI.get_board.getMoveListString
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
                Me._openingText.Text = ECO & ": " & openingName
                FileClose(1)
                Exit For
            End If
        Next
        FileClose(1)
        '' < 12ms elapsed
    End Sub

    Public Sub ResizeAll()
        'used in conditions of updating the scroll bar and entry 
        Me._maxHeight = CInt(Me._gameGUI.getBoardGUI.Height / 2)
        Me._maxNoOfRows = CByte((Me._maxHeight) \ 20)

        Me.ResizePanels()
        Me.UpdateScroll()
        Me.UpdateEntryLocation()
        Me.UpdateScrollLocation()

    End Sub

    Private Sub UpdateEntryLocation()
        If Me._noOfRows <= Me._maxNoOfRows Then
            Me._entryPanel.Location = New Point(0, 40)
        Else
            Dim oflow As Integer = Me._noOfRows - Me._maxNoOfRows
            Me._entryPanel.Location = New Point(0, 40 - (oflow * 20))
        End If
    End Sub

    Private Sub UpdateScrollLocation()
        If Me._noOfRows <= Me._maxNoOfRows Then
            Me._scrollBar.Location = New Point(194, 20)
        Else
            With (Me._scrollBar)
                .Location = New Point(194, Me.Height - .Height)
            End With
        End If
    End Sub

    Private Sub UpdateScroll()
        Dim height As Integer = 20 + (Me._noOfRows * 20)
        If Me._noOfRows <= Me._maxNoOfRows Then
            Me._scrollBar.Size = New Size(10, height)
            Me._scrollBar.Location = New Point(Me._scrollBar.Location.X, 20)
        Else
            'MsgBox(_maxNoOfEntries)                    ''USED TO TEST
            'MsgBox(Me._noOfRows - Me._maxNoOfEntries)
            Dim excessRows As Integer = Me._noOfRows - Me._maxNoOfRows
            Me._scrollBar.Size = New Size(Me._scrollBar.Width, 20 + (Me._maxNoOfRows * 20) - (excessRows * 20))
            Me._scrollBar.Location = New Point(Me._scrollBar.Location.X, 20)
        End If
    End Sub


#Region "Scroll Event Handling"
    'SCROLL EVENTS
    Private _held As Boolean    'used to store whether the mouse was pressed on the scroll wheel
    ' not using e.Button property since it does not indicate whether the mouse was hovering the bar when clicked
    Private _distFromTop As Integer
    Private Sub E_Mouse_Down(sender As Object, e As MouseEventArgs) Handles _scrollBar.MouseDown
        Me._held = True
        Me._lastLoc = PointToClient(MousePosition)
        Me._distFromTop = Me._lastLoc.Y - Me._scrollBar.Location.Y
    End Sub
    Private _lastLoc As Point
    Private Sub E_Mouse_Move(sender As Object, e As MouseEventArgs) Handles _scrollBar.MouseMove
        Dim newY As Integer = PointToClient(MousePosition).Y - Me._distFromTop
        If Me._held Then
            If newY >= 20 AndAlso newY + Me._scrollBar.Height <= (Me.Height) Then
                Me._scrollBar.Location = New Point(Me._scrollBar.Location.X, PointToClient(MousePosition).Y - Me._distFromTop)
                Me._entryPanel.Location = New Point(Me._entryPanel.Location.X, 60 - Me._scrollBar.Location.Y)
            End If

        End If
    End Sub
    Private Sub E_Mouse_Up(sender As Object, e As MouseEventArgs) Handles _scrollBar.MouseUp
        Me._held = False
        Me._lastLoc = Nothing
    End Sub

    Private Sub E_Mouse_Enter(sender As Object, e As EventArgs) Handles _scrollBar.MouseEnter
        With (Me._scrollBar)
            .BackColor = Color.FromArgb(80, 80, 80)
        End With
    End Sub
    Private Sub E_Mouse_Leave(sender As Object, e As EventArgs) Handles _scrollBar.MouseLeave
        With (Me._scrollBar)
            .BackColor = Color.FromArgb(60, 60, 60)
        End With
    End Sub

#End Region

#Region "Entry Label Event Handling"

    Private Sub e_label_mouseenter(sender As Object, e As EventArgs)
        Dim lbl As Label = CTypeDynamic(Of Label)(sender)
        With (lbl)
            If CTypeDynamic(Of Label)(sender) IsNot Me._selectedLbl Then .BackColor = Me._hoverCol
            .Cursor = Cursors.Hand
        End With
    End Sub

    Private Sub e_label_mouseleave(sender As Object, e As EventArgs)
        With CTypeDynamic(Of Label)(sender)
            If CTypeDynamic(Of Label)(sender) IsNot Me._selectedLbl Then .BackColor = Me._secCol
            .Cursor = Cursors.Arrow
        End With
    End Sub

    Private Sub e_label_click(sender As Object, e As EventArgs)
        Dim senderLbl As Label = CTypeDynamic(Of Label)(sender) : Me._selectedLbl = senderLbl
        senderLbl.BackColor = Me._selectedCol
        Dim index As Integer = 0
        For i = 0 To UBound(Me._entries)
            If Me._entries(i) Is senderLbl Then
                index = i
                Exit For
            End If
        Next

        Me._gameGUI.getBoardGUI.show_ghost_position(index + 1)    'used to represent the board from the chosen position on the gui rather than the up
        ' to date board
        Me.update_label_graphics()
    End Sub

#End Region

#Region "Key Events"

    Public Sub e_previewkeydown(sender As Object, e As PreviewKeyDownEventArgs)
        If Me._entries IsNot Nothing Then
            Dim kd As Keys = e.KeyData
            If Me._selectedLbl Is Nothing Then Me._selectedLbl = Me._entries(UBound(Me._entries))

            Dim findIndex = Function()
                                Dim i As Integer = 0
                                For Each lbl As Label In Me._entries
                                    If lbl Is Me._selectedLbl Then
                                        Return i
                                    End If
                                    i += 1
                                Next
                                Return UBound(Me._entries)
                            End Function
            Dim index As Integer = findIndex()

            Select Case kd
                Case Keys.Left
                    If index <> 0 Then
                        index -= 1
                    End If
                Case Keys.Right
                    If index <> UBound(Me._entries) Then
                        index += 1
                    End If
                Case Keys.Up
                    index = UBound(Me._entries)
                Case Keys.Down
                    index = 0
            End Select

            Me._selectedLbl = Me._entries(index)
            Me._gameGUI.getBoardGUI.show_ghost_position(index + 1)
            Me.update_label_graphics()
        End If
    End Sub

#End Region

    Public Sub update_label_graphics()
        For Each lbl As Label In Me._entries
            lbl.BackColor = Me._secCol
        Next
        Me._selectedLbl.BackColor = Me._selectedCol
    End Sub

End Class

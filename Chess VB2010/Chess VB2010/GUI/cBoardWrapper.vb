<Serializable()>
Public Class cBoardWrapper

    Private _target As cGameGUI
    Private _rankMarkers() As Label
    Private _fileMarkers() As Label

    Private _whiteBottom As Boolean

    Public Function getRankMarkers() As Label()
        Return Me._rankMarkers
    End Function
    Public Function getFileMarkers() As Label()
        Return Me._fileMarkers
    End Function

    Public Sub New(ByRef TARGET As cGameGUI)
        Me._target = TARGET
        Me.AddControls()
        Me._whiteBottom = True
    End Sub

    Private Sub set_colour(c As Color)
        For Each rank As Label In Me._rankMarkers
            rank.ForeColor = c
        Next
        For Each file As Label In Me._fileMarkers
            file.ForeColor = c
        Next
    End Sub

    Private Sub AddControls()
        For i = 0 To 7
            ReDim _rankMarkers(i)
            ReDim _fileMarkers(i)
        Next
        For i = 0 To 7
            _rankMarkers(i) = New Label
            _fileMarkers(i) = New Label
            Me._target.Controls.Add(_rankMarkers(i))
            Me._target.Controls.Add(_fileMarkers(i))
            _rankMarkers(i).SendToBack()
            _fileMarkers(i).SendToBack()

            With _rankMarkers(i)
                .Font = New Font("Microsoft Sans Serif", 10)
                .TextAlign = ContentAlignment.MiddleLeft
                .ForeColor = Color.White
                .AutoSize = False
                .Size = New Size(20, Me._target.getBoardGUI.calc_size)
                .Location = New Point(Me._target.getBoardGUI.Location.X - 25, Me._target.getBoardGUI.Location.Y + (Me._target.getBoardGUI.calc_size * i))
                .Text = CStr(8 - i)
            End With
            With _fileMarkers(i)
                .Font = New Font("Microsoft Sans Serif", 10)
                .TextAlign = ContentAlignment.MiddleCenter
                .ForeColor = Color.White
                .AutoSize = False
                .Size = New Size(Me._target.getBoardGUI.calc_size, 25)
                .Location = New Point(Me._target.getBoardGUI.Location.X + (Me._target.getBoardGUI.calc_size * i), Me._target.getBoardGUI.Location.Y + (Me._target.getBoardGUI.calc_size * 8))
                .Text = Chr(97 + i)
            End With
        Next
    End Sub

    Public Sub FlipRankMarkers()
        Me._whiteBottom = Not (Me._whiteBottom)
        Dim locations(7) As Point
        For i = 0 To 7
            locations(i) = Me._rankMarkers(i).Location
        Next
        For i = 7 To 0 Step -1
            Me._rankMarkers(Math.Abs(i - 7)).Location = locations(i)
        Next
    End Sub

    Public Sub Resize()
        For i = 0 To 7
            With _rankMarkers(i)
                .Size = New Size(25, Me._target.getBoardGUI.calc_size)
                .Location = New Point(Me._target.getBoardGUI.Location.X - 25, Me._target.getBoardGUI.Location.Y + (Me._target.getBoardGUI.calc_size * i))
            End With
            With _fileMarkers(i)
                .Size = New Size(Me._target.getBoardGUI.calc_size, 25)
                .Location = New Point(Me._target.getBoardGUI.Location.X + (Me._target.getBoardGUI.calc_size * i), Me._target.getBoardGUI.Location.Y + (Me._target.getBoardGUI.calc_size * 8))
            End With
        Next
    End Sub

    Public Sub Destroy()
        For Each lbl As Label In Me._rankMarkers
            Me._target.Controls.Remove(lbl)
            lbl.Dispose()
        Next
        For Each lbl As Label In Me._fileMarkers
            Me._target.Controls.Remove(lbl)
            lbl.Dispose()
        Next
    End Sub

End Class

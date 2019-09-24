Public Class game_end_form

    Private Sub e_load(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Select Case InterfaceForm.chess.get_board.getState
            Case GameState.WhiteMated
                Me.announce_label.Text = "Black wins!"
            Case GameState.BlackMated
                Me.announce_label.Text = "White wins!"
            Case GameState.Draw
                Me.announce_label.Text = "Draw!"
            Case GameState.Stalemate
                Me.announce_label.Text = "Draw!"
            Case GameState.ongoing
                Me.announce_label.Text = "ongoing"
        End Select
    End Sub

    Private Sub e_new_game(sender As Object, e As EventArgs) Handles Panel1.Click, new_game_label.Click
        Me.Hide()
        InterfaceForm.start_new_game()
    End Sub

End Class
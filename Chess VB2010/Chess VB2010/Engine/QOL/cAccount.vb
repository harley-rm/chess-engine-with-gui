Public Class cAccount

    Private _username As String
    Private _ELO As Integer
    Private _ppLocation As String

    'statistics
    Private _previousGames() As PGN

    Private _wins As Integer
    Private _losses As Integer
    Private _draws As Integer

    Public Shared Function fetchExisting(loc As String) As cAccount
        Return Nothing
    End Function

End Class

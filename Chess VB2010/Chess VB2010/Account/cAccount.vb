Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' Serves as an object to store accounts in the application.
''' Also contains required shared methods to setup an account storage system to be used with the application.
''' </summary>
<Serializable()>
Public Class cAccount
    Private _location As String

    Private _username As String
    Private _password_hash As String
    Private _elo As Integer
    Private _avi As Bitmap

    Private _accountNumber As Integer

    'statistics
    Private _previousGames As List(Of PGN)

    Private _wins As Integer
    Private _losses As Integer
    Private _draws As Integer

    Public Enum login_response
        valid
        username_invalid
        password_invalid
    End Enum

#Region "Static members"
    Public Shared numberOfAccounts As Integer
    Public Shared accounts_path As String = System.AppDomain.CurrentDomain.BaseDirectory & "accounts\" 'concatenate the name of the file + .acc to access the account file.
    Public Shared table_path As String = System.AppDomain.CurrentDomain.BaseDirectory & "accounts\accounts.dsv"

    Public Shared Sub initialize_account_management(Optional force_change As Boolean = False)
        If Not cAccount.account_table_exists OrElse (force_change) Then
            cAccount.generate_account_table()
        Else
            cAccount.update_no_of_accounts()
        End If
    End Sub

    Private Shared Sub update_no_of_accounts()
        FileOpen(1, cAccount.table_path, OpenMode.Input)
        cAccount.numberOfAccounts = CType(LineInput(1), Integer)
        FileClose(1)
    End Sub

    Public Shared Function account_table_exists() As Boolean
        If IO.File.Exists(cAccount.table_path) Then Return True Else Return False
    End Function

    Public Shared Sub generate_account_table()
        If cAccount.account_table_exists Then
            My.Computer.FileSystem.DeleteFile(cAccount.table_path)  ''deletes the existing accounts file if it already exists.
        End If

        FileOpen(1, cAccount.table_path, OpenMode.Output)   'create the account table, printline creates the first entry, which indicates number of accounts stored by the table
        PrintLine(1, 0)
        FileClose(1)

        If Not File.Exists(cAccount.accounts_path & "white_engine.acc") Then
            cAccount.generate_account("white_engine", cAccount.hash_pword(""), 1000, My.Resources.white_engine_avi)
        End If
        If Not File.Exists(cAccount.accounts_path & "black_engine.acc") Then
            cAccount.generate_account("black_engine", cAccount.hash_pword(""), 950, My.Resources.black_engine_avi)
        End If

    End Sub

    Public Shared Function generate_account(un As String, ph As String, e As Integer, aloc As String) As cAccount
        Dim a As cAccount = New cAccount(un, ph, e, aloc)
        Using w As BinaryWriter = New BinaryWriter(File.Open(a._location, FileMode.Create))
            w.Write(a.to_stream)
        End Using
        cAccount.add_account_to_table(a)
        Return a
    End Function
    Public Shared Function generate_account(un As String, ph As String, e As Integer, avi As Bitmap) As cAccount
        Dim a As cAccount = New cAccount(un, ph, e, avi)
        Using w As BinaryWriter = New BinaryWriter(File.Open(a._location, FileMode.Create))
            w.Write(a.to_stream)
        End Using
        cAccount.add_account_to_table(a)
        Return a
    End Function

    Private Shared Sub add_account_to_table(a As cAccount)
        FileOpen(1, cAccount.table_path, OpenMode.Append)
        Dim s As String = a._username & "#" & a._password_hash & "#" & a._location
        PrintLine(1, s)
        FileClose(1)
        cAccount.increment_account_counter()
    End Sub

    Private Shared Sub increment_account_counter()
        cAccount.numberOfAccounts += 1
        If Not File.Exists(cAccount.table_path) Then Throw New Exception("Account database not found, please generate a new one.")
        Dim inputs As List(Of String) = New List(Of String)

        FileOpen(1, cAccount.table_path, OpenMode.Input)
        Dim [end] As Boolean = False
        Do While Not [end]
            Try
                inputs.Add(LineInput(1))
            Catch ex As Exception
                [end] = True
            End Try
        Loop
        FileClose(1)
        FileOpen(1, cAccount.table_path, OpenMode.Output)
        For Each s As String In inputs
            If inputs.IndexOf(s) = 0 Then
                PrintLine(1, CInt(s) + 1)
            Else
                PrintLine(1, s)
            End If
        Next
        FileClose(1)
    End Sub

    Public Shared Function hash_pword(p As String) As String
        Dim r As String = Nothing
        Dim provider As System.Security.Cryptography.SHA256CryptoServiceProvider = New Security.Cryptography.SHA256CryptoServiceProvider
        Dim bytes As Byte() = provider.ComputeHash(System.Text.Encoding.ASCII.GetBytes(p))
        r = System.Text.Encoding.ASCII.GetString(bytes)
        Return r
    End Function

    Public Shared Function login(username As String, hash As String) As Tuple(Of login_response, cAccount)
        Dim r1 As login_response = login_response.username_invalid
        Dim r2 As cAccount = Nothing
        Dim inputs As List(Of String) = New List(Of String)
        FileOpen(1, cAccount.table_path, OpenMode.Input)
        LineInput(1)
        Do While True
            Try
                inputs.Add(LineInput(1))
            Catch ex As Exception
                Exit Do
            End Try
        Loop
        FileClose(1)

        For Each s As String In inputs
            Dim ss As String() = Split(s, "#")
            If ss(0) = username AndAlso ss(1) = hash Then
                r1 = login_response.valid
                r2 = cAccount.fetch_profile(ss(2))
                Exit For
            ElseIf ss(0) = username AndAlso ss(1) <> hash Then
                r1 = login_response.password_invalid
                Exit For
            End If
        Next
        Return New Tuple(Of login_response, cAccount)(r1, r2)
    End Function

    Public Shared Function fetch_profile(path As String) As cAccount
        Dim r As cAccount
        Using reader As BinaryReader = New BinaryReader(File.Open(path, FileMode.Open))
            r = cAccount.from_stream(reader.BaseStream)
        End Using
        Return r
    End Function

    Public Shared Function from_stream(stream As Stream) As cAccount
        If (Object.ReferenceEquals(stream, Nothing)) Then Return Nothing
        Dim formatter As New BinaryFormatter()
        Return CType(formatter.Deserialize(stream), cAccount)
    End Function

#End Region

#Region "Mutators & Accessors"

    Public Sub set_username(v As String)
        Me._username = v
    End Sub
    Public Function get_username() As String
        Return Me._username
    End Function

    Public Sub set_elo(v As Integer)
        Me._elo = v
    End Sub
    Public Function get_elo() As Integer
        Return Me._elo
    End Function

    Public Function get_previous_games() As List(Of PGN)
        Return Me._previousGames
    End Function

    Public Sub set_wins(v As Integer)
        Me._wins = v
    End Sub
    Public Function get_wins() As Integer
        Return Me._wins
    End Function

    Public Sub set_draws(v As Integer)
        Me._draws = v
    End Sub
    Public Function get_draws() As Integer
        Return Me._draws
    End Function

    Public Sub set_losses(v As Integer)
        Me._losses = v
    End Sub
    Public Function get_losses() As Integer
        Return Me._losses
    End Function

    Public Function get_avi() As Bitmap
        Return Me._avi
    End Function

#End Region

    ''Only having a private constructor makes it impossible to create an 
    ''  account in the standard idea of object instantiation, the generate_account method must be used instead which will
    ''  also add the account to the account to the account table. And ensure the account is valid.
    Private Sub New(un As String, ph As String, e As Integer, avi As String)
        cAccount.update_no_of_accounts()
        With (Me)
            ._username = un : ._password_hash = ph : ._elo = e
            ._previousGames = New List(Of PGN) : ._wins = 0 : ._draws = 0 : ._losses = 0
            ._accountNumber = (cAccount.numberOfAccounts + 1)
            ._avi = New Bitmap(avi)
            ._location = cAccount.accounts_path & ._username & ._accountNumber & ".acc"
        End With
    End Sub

    Private Sub New(un As String, ph As String, e As Integer, avi As Bitmap)
        cAccount.update_no_of_accounts()
        With (Me)
            ._username = un : ._password_hash = ph : ._elo = e
            ._previousGames = New List(Of PGN) : ._wins = 0 : ._draws = 0 : ._losses = 0
            ._accountNumber = (cAccount.numberOfAccounts + 1)
            ._avi = avi
            ._location = cAccount.accounts_path & ._username & ._accountNumber & ".acc"
        End With
    End Sub

    Private Function to_stream() As Byte()
        If (Object.ReferenceEquals(Me, Nothing)) Then Return Nothing
        Dim formatter As New BinaryFormatter()
        Dim stream As New MemoryStream()
        formatter.Serialize(stream, Me)
        stream.Seek(0, SeekOrigin.Begin)
        Return stream.ToArray
    End Function

End Class

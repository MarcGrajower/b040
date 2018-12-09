Imports System.Data.OleDb
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Public Class sqlClass
    Public conn As OleDbConnection
    Public t As OleDbTransaction
    Dim openConn As Boolean
    Dim isTransaction As Boolean = False
    Public dt As New DataTable
    Public parameterCollection As New Collection

    'Public Function Execute(ByVal sqlString As String) As Integer
    '    Dim cmd As New OleDbCommand
    '    Dim da As New OleDbDataAdapter(cmd)
    '    Me.openConn = False
    '    If Me.conn Is Nothing Then
    '        conn = New OleDbConnection(My.Settings.b040_beConnectionString) : conn.Open()
    '        Me.openConn = True
    '    End If
    '    cmd.Connection = conn
    '    If UCase(Left(sqlString, 3)) = "QRY" Then cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = sqlString
    '    dt.Clear() ' MG 17/apr/11
    '    da.Fill(Me.dt)
    '    If Me.openConn Then conn.Close()
    '    Return dt.Rows.Count
    'End Function
    Public Function Execute(ByVal sqlString As String, dtParameter As DataTable) As Integer
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter(cmd)
        Me.openConn = False
        If Me.conn Is Nothing Then
            conn = New OleDbConnection(My.Settings.b040_beConnectionString) : conn.Open()
            Me.openConn = True
        End If
        cmd.Connection = conn
        If UCase(Left(sqlString, 3)) = "QRY" Then cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = sqlString
        For Each p As OleDbParameter In parameterCollection
            cmd.Parameters.Add(p)
        Next
        dtParameter.Clear() ' MG 17/apr/11
        da.Fill(dtParameter)
        If Me.openConn Then conn.Close()
        Return dtParameter.Rows.Count
    End Function
    Public Function Execute(ByVal sqlString As String) As Integer
        Return Execute(sqlString, Me.dt)
    End Function
    Public Function ExecuteScalar(ByVal sqlString As String) As Object
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter(cmd)
        Me.openConn = False
        If (Me.conn Is Nothing) Then
            Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
            Me.openConn = True
        End If
        If (Me.conn.State <> ConnectionState.Open) Then
            Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
            Me.openConn = True
        End If
        cmd.Connection = Me.conn
        If Me.t IsNot Nothing Then cmd.Transaction = Me.t
        If UCase(Left(sqlString, 3)) = "QRY" Then cmd.CommandType = CommandType.StoredProcedure
        For Each p As OleDbParameter In parameterCollection
            cmd.Parameters.Add(p)
        Next
        cmd.CommandText = sqlString
        Dim o = cmd.ExecuteScalar
        If Me.openConn Then conn.Close()
        Return o
    End Function
    Public Function ExecuteNonQuery(ByVal sqlString As String, ByVal t As OleDbTransaction) As Long
        ' MG 23/feb/11
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter(cmd)
        Me.openConn = False
        If Me.conn Is Nothing Then
            Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
            Me.openConn = True
        End If
        If (Me.conn.State <> ConnectionState.Open) Then
            Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
            Me.openConn = True
        End If
        cmd.Transaction = t
        cmd.Connection = Me.conn
        If UCase(Left(sqlString, 3)) = "QRY" Then cmd.CommandType = CommandType.StoredProcedure
        For Each p As OleDbParameter In parameterCollection
            cmd.Parameters.Add(p)
        Next
        cmd.CommandText = sqlString
        Dim tally As Long
        Try
            tally = cmd.ExecuteNonQuery
        Catch ex As Exception
            Throw New InvalidOperationException(sqlString & vbLf & ex.Message)
        End Try

        If Me.openConn Then Me.conn.Close()
        Return tally
    End Function
    Public Function ExecuteNonQuery(ByVal sqlString As String) As Long
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter(cmd)
        Me.openConn = False
        If Me.isTransaction = False Then
            If Me.conn Is Nothing Then
                Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
                Me.openConn = True
            End If
            If (Me.conn.State <> ConnectionState.Open) Then
                Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
                Me.openConn = True
            End If
        End If
        cmd.Connection = Me.conn
        cmd.Transaction = Me.t
        If UCase(Left(sqlString, 3)) = "QRY" Then cmd.CommandType = CommandType.StoredProcedure
        For Each p As OleDbParameter In parameterCollection
            cmd.Parameters.Add(p)
        Next
        cmd.CommandText = sqlString
        Dim tally As Long
        Try
            tally = cmd.ExecuteNonQuery
        Catch ex As Exception
            Throw New InvalidOperationException(sqlString & vbLf & ex.Message)
        End Try
        If Me.openConn Then Me.conn.Close()
        Return tally
    End Function
    Public Function retrieveNewKey(Optional ByVal t As OleDbTransaction = Nothing) As Long
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter(cmd)
        If Me.isTransaction Then t = Me.t
        Me.openConn = False
        If (Me.conn Is Nothing) Then
            Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
            Me.openConn = True
        End If
        If (Me.conn.State <> ConnectionState.Open) Then
            Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
            Me.openConn = True
        End If
        cmd.Connection = Me.conn
        If t IsNot Nothing Then cmd.Transaction = t
        cmd.CommandText = "select @@identity"
        Dim n As Long = cmd.ExecuteScalar
        If Me.openConn Then conn.Close()
        Return n
    End Function
    Function openTable(ByVal c As String) As DataTable
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter(cmd)
        Me.openConn = False
        If (Me.conn Is Nothing) Then
            Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
            Me.openConn = True
        End If
        If (Me.conn.State <> ConnectionState.Open) Then
            Me.conn = New OleDbConnection(My.Settings.b040_beConnectionString) : Me.conn.Open()
            Me.openConn = True
        End If
        cmd.Connection = Me.conn
        cmd.Transaction = t
        cmd.CommandType = CommandType.TableDirect
        cmd.CommandText = c
        Me.dt.Clear()
        da.Fill(Me.dt)
        If Me.openConn Then conn.Close()
        Return Me.dt
    End Function
    Shared Function cDateForJet(ByVal d As Date) As String
        Return "#" & d.ToString("MM/dd/yyyy") & "#"
    End Function
    Shared Function c(ByVal cString As String) As String
        Return Chr(34) & cNvl(cString) & Chr(34)
    End Function
    Shared Function cDoubleForjet(ByVal n As Double) As String
        Dim c As String : c = CStr(n)
        Dim i As Integer
        For i = 1 To Len(c)
            If Mid(c, i, 1) = "," Then Mid(c, i, 1) = "."
        Next
        cDoubleForjet = c
    End Function
    Public Sub beginTransaction()
        conn = New OleDbConnection(My.Settings.b040_beConnectionString) : conn.Open()
        Me.openConn = True
        Me.t = conn.BeginTransaction
        Me.isTransaction = True
    End Sub
    Public Sub commitTransation()
        Me.t.Commit()
        Me.conn.Close()
    End Sub
    Public Shared Function cDataFolder() As String
        Dim conn As New OleDbConnection(My.Settings.b040_beConnectionString)
        Dim c As String = conn.DataSource
        Dim o As New IO.FileInfo(c)
        Return o.DirectoryName
    End Function
    Public Shared Function cLike(ByVal c As String) As String
        Return "'%" & Trim(c) & "%'"
    End Function
    Public Shared Function cBoolean(ByVal l As Boolean) As String
        Return IIf(gen.bNvl(l), "True", "False")
    End Function
    Public Sub AddParameter(value As Object, type As DbType)
        Dim p As New OleDbParameter
        p.Value = value
        p.DbType = type
        Me.parameterCollection.Add(p)
    End Sub
    Class SqlBuilder
        Dim odict As New Dictionary(Of String, String)
        Public cTable As String
        Sub addInsert(ByVal cField, ByVal cValue)
            If cValue Is DBNull.Value Then Exit Sub
            Me.odict.Add(cField, cValue)
        End Sub
        Function cInsert() As String
            Dim cFields As String = "" : Dim cValues As String = ""
            For Each entry As KeyValuePair(Of String, String) In Me.odict
                cFields &= entry.Key & ","
                cValues &= entry.Value & ","
            Next
            odict.Clear()
            cFields = "(" & Left(cFields, Len(cFields) - 1) & ")"
            cValues = "(" & Left(cValues, Len(cValues) - 1) & ")"
            Return "insert into " & Me.cTable & " " & cFields & " values " & cValues
        End Function
    End Class
    Shared Function lTable(ByVal cTable As String) As Boolean
        Dim oConn As New OleDb.OleDbConnection(My.Settings.b040_beConnectionString) : oConn.Open()
        Dim oST As DataTable
        oST = oConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})
        For Each oRow As DataRow In oST.Rows
            If oRow!table_type.ToString = "TABLE" And UCase(oRow!table_name.ToString) = UCase(cTable) Then
                Return True
            End If
        Next
        Return False
    End Function
End Class

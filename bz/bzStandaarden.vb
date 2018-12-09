Imports System.Data.OleDb
Imports System.Configuration
Imports System.Collections
Public Class bzStandaarden
    Dim ds As New StandaardenDS
    Dim da As New StandaardenDSTableAdapters.StandaardHTableAdapter
    Public dt As New StandaardenDS.StandaardHDataTable
    Public pk As Long
    Public Function Exists(ByVal kl As Long, ByVal t As String, ByVal stType As Long) As Boolean
        Me.pk = 0
        Dim v = Me.da.StandaardFromKlantTypeStandaardTypeScalarQuery(kl, t, stType)
        If v Is Nothing Then Return False
        Me.pk = CType(v, Long)
        Return True
    End Function
    'Public Sub NewRecord()
    '    Dim conn As New OleDbConnection(My.Settings.b040_beConnectionString)
    '    Dim com As New OleDbCommand
    '    conn.Open()
    '    com.Connection = conn
    '    com.CommandText = "Insert into StandaardH (sth_type,sth_typsb,sth_klant,sth_timestamp) values (null,null,null,null) "
    '    com.ExecuteNonQuery()
    '    com.CommandText = "select @@identity"
    '    Me.pk = com.ExecuteScalar
    '    com.Connection.Close()
    'End Sub
    Public Sub Delete(ByVal pk As Long, ByVal conn As OleDbConnection)
        Dim oSql As New sqlClass
        oSql.conn = conn
        Dim c As String = "delete from standaardh where sth_id = " & pk
        Dim n As Integer = oSql.ExecuteNonQuery(c)
        c = "delete from standaardd where std_sth = " & pk
        n = oSql.ExecuteNonQuery(c)
        nLog("", "bzStandaarden", LogType.logNormal, LogAction.logDelete, "Standaarden", pk)
    End Sub
End Class

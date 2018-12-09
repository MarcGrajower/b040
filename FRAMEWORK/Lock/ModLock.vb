Imports System.Data.OleDb
Module ModLock
    Public Function lLock(ByVal nSession As Long, ByVal cTable As String, ByVal nPK As Integer, Optional ByVal cDescription As String = "") As Boolean
        Dim c As String
        Dim ds As New dsLock
        Dim da As New dsLockTableAdapters.LockTableAdapter
        Dim n As Integer = da.Fill(ds.Lock, nPK, cTable)
        If n > 0 Then
            Dim row As DataRow = ds.Lock.Rows(n - 1)
            c = "Dit gegeven is op dit ogenblik vergrendeld."
            c = c & vbCrLf & vbCrLf
            c = c & "Gebruiker " & row("Lock_user").ToString & " - Computer " & row("Lock_Computer")
            c = c & "- sinds " & Format(row("Lock_timestamp"), "ddd dd MMM - hh:mm")
            c = c & vbCrLf & vbCrLf
            c = c & "Probeert U het later nog eens?"
            MsgBox(c, , "Opgelet")
            Return False
        End If
        n = da.Insert(My.Computer.Name, Environment.GetEnvironmentVariable("username"), cTable, nPK, cDescription, Now, nSession)
        Return True
    End Function
    Public Sub unLock(ByVal cTable As String, ByVal nLockedPK As Integer)
        Dim da As New dsLockTableAdapters.LockTableAdapter
        da.Delete(cTable, nLockedPK)
    End Sub
    Public Sub unlockSession(ByVal nSession As Long)
        Dim da As New dsLockTableAdapters.LockTableAdapter
        da.UnlockSession(nSession)
    End Sub
    Public Sub unlockCurrentStation()
        Dim sql As New sqlClass
        Dim tally As Integer = sql.ExecuteNonQuery("delete from lock where lock_computer = '" & My.Computer.Name & "'")
        MsgBox("Er werd(en) " & tally & " lijn(en) ontgrendeld.")
    End Sub
End Module

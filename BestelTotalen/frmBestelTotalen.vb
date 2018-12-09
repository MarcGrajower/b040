Public Class frmBestelTotalen

    Private Sub frmBestelTotalen_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.processBestel()
    End Sub
    Sub processBestel()
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Visible = True
        Dim oSqlBestel As New sqlClass
        Dim cSqlBestel As String = "select besth_id from bestH"
        oSqlBestel.Execute(cSqlBestel)
        Me.ProgressBar1.Maximum = oSqlBestel.dt.Rows.Count
        For Each odr As DataRow In oSqlBestel.dt.Rows
            Me.ProgressBar1.Value += 1
            Dim osqlSave As New sqlClass
            Dim nTotal As Double = 0
            Dim lSucceeded As Boolean = True
            Try
                nTotal = bzBestel.nTotaal(odr("Besth_id"))
            Catch ex As Exception
                lSucceeded = False
            End Try
            If lSucceeded Then
                Dim oSqlCount As New sqlClass
                Dim cSqlCount As String = "select count(bestd_id) from bestd where bestd_besth = " & odr("Besth_id")
                Dim nCount = oSqlCount.ExecuteScalar(cSqlCount)
                Dim cSave As String = "update Besth "
                cSave &= "set besth_TotTebetalen = " & sqlClass.cDoubleForjet(bzBestel.nTotaal(odr("Besth_id")))
                cSave &= " , besth_TotLijnen = " & nCount
                cSave &= " where BestH_id = " & odr("Besth_id")
                osqlSave.ExecuteNonQuery(cSave)
            Else
                MsgBox("Gelieve even na te kijken " & bzBestel.cDisplay(odr("Besth_id")))
            End If
        Next
        Me.Close()
    End Sub
End Class

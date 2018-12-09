Public Class BzWinkelproductie
    Public Shared klId As Long
    Shared Sub New()
        klId = bzKlanten.kl_id(modB040Config.Generic("WINKELPRODUCTIE_KLANTENNUMMER"))
    End Sub
    Public Shared Function GetProductie(artId As Long, datum As Date) As Decimal
        Dim sql As String
        sql = "select bestd_hoev1 from pd,ph "
        sql &= " where bestd_besth = besth_id "
        sql &= " and besth_datlevering = ? "
        sql &= " and besth_klant = ? "
        sql &= " and bestd_artikel = ? "
        Dim context As New sqlClass()
        context.parameterCollection.Add(New OleDb.OleDbParameter("?", datum))
        context.parameterCollection.Add(New OleDb.OleDbParameter("?", klId))
        context.parameterCollection.Add(New OleDb.OleDbParameter("?", artId))
        Return context.ExecuteScalar(sql)
    End Function

End Class

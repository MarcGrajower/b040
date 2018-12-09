Public Class frmStandaardomschrijvingenAanpassen


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim oSql As New sqlClass
        Dim cSql As String = ""
        cSql = "UPDATE STandaardD INNER JOIN Artikel ON STandaardD.std_Artikel = Artikel.ARt_Id SET STandaardD.std_ArtOmschrijving = [Art_omschrijving]"
        oSql.ExecuteNonQuery(cSql)
        MsgBox("Omschrijvingen zijn nu aangepast")
        Me.Close()
    End Sub
End Class
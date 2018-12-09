Imports System.ComponentModel

Public Class frmProductiePlanOverzicht
    Dim lSelectall As Boolean
    Dim loading As Boolean
    Private Sub loadLeveringDatums()
        Dim sql As New sqlClass
        sql.Execute("qryProductieplanOverzichtLoadLeveringsDatums")
        Dim count As Long = sql.dt.Rows.Count
        leveringsDatumsCombobox.Items.Clear()
        leveringsDatumsCombobox.Items.Add("Productieplan")
        If count > 1 Then
            leveringsDatumsCombobox.Items.Add("Alle bestellingen")
            leveringsDatumsCombobox.Items.Add("Post Productieplan")
        End If
        leveringsDatumsCombobox.Items.Add("Vandaag")
        leveringsDatumsCombobox.Text = leveringsDatumsCombobox.Items(0)
        setTooltip(leveringsDatumsCombobox, "Leveringen van [Vandaag] zijn niet inbegrepen in [Alle bestellingen]")
    End Sub
    Function getDatereport() As String
        Select Case leveringsDatumsCombobox.SelectedIndex
            Case 0
                Return " = " & sqlClass.cDateForJet(bzBestel.dGetLeveringForBestellingDatum(Now))
            Case 1
                Return "  >= " & sqlClass.cDateForJet(bzBestel.dGetLeveringForBestellingDatum(Now))
            Case 2
                Return " > " & sqlClass.cDateForJet(bzBestel.dGetLeveringForBestellingDatum(Now))
            Case 3
                Return " = " & sqlClass.cDateForJet(Now)
        End Select
        Return " = "
    End Function

    Private Sub requeryAll()
        Dim dateReport As String = getDatereport()
        Dim oSql As New sqlClass
        Dim cSql As String = ""
        If klantTypeCombobox.SelectedIndex = 0 Then
            cSql = "SELECT Kategorie.Kat_ProductiePlan, Artikel.Art_Nr, Art_omschrijving, Sum(sumHoev) AS Hoev1, Eenheden.Eenh_HoevInvoer, Artikel.ARt_Id "
            cSql &= " From ( "
        End If
        If klantTypeCombobox.SelectedIndex <> 2 Then
            cSql &= "SELECT Kategorie.Kat_ProductiePlan, Artikel.Art_Nr, Art_omschrijving, Sum(BestD.BestD_Hoev1) AS sumHoev, Eenheden.Eenh_HoevInvoer, Artikel.ARt_Id "
            cSql &= " FROM (((BestD INNER JOIN BestH ON BestD.BestD_BestH = BestH.BestH_Id) INNER JOIN Artikel ON BestD.BestD_Artikel = Artikel.ARt_Id) INNER JOIN Kategorie ON Artikel.Art_Kategorie = Kategorie.Kat_ID) INNER JOIN Eenheden ON Artikel.Art_Eenheid = Eenheden.Eenh_id "
            cSql &= " where besth_DatLevering " & dateReport & " "
            cSql &= " GROUP BY Kategorie.Kat_ProductiePlan, Artikel.Art_Nr, Art_Omschrijving, Eenheden.Eenh_HoevInvoer, Artikel.ARt_Id "
        End If
        If klantTypeCombobox.SelectedIndex = 0 Then
            cSql &= " UNION all "
        End If
        If klantTypeCombobox.SelectedIndex <> 1 Then
            cSql &= " SELECT Kategorie.Kat_ProductiePlan, Artikel.Art_Nr, Art_omschrijving, Sum(BestD.BestD_Hoev1) AS sumHoev, Eenheden.Eenh_HoevInvoer, Artikel.ARt_Id "
            cSql &= " FROM (((PD BestD INNER JOIN PH BestH ON BestD.BestD_BestH = BestH.BestH_Id) INNER JOIN Artikel ON BestD.BestD_Artikel = Artikel.ARt_Id) INNER JOIN Kategorie ON Artikel.Art_Kategorie = Kategorie.Kat_ID) INNER JOIN Eenheden ON Artikel.Art_Eenheid = Eenheden.Eenh_id "
            cSql &= " where besth_DatLevering " & dateReport & " "
            cSql &= " GROUP BY Kategorie.Kat_ProductiePlan, Artikel.Art_Nr, Art_Omschrijving, Eenheden.Eenh_HoevInvoer, Artikel.ARt_Id "
        End If
        If klantTypeCombobox.SelectedIndex = 0 Then
            cSql &= ") "
            cSql &= " GROUP BY Kategorie.Kat_ProductiePlan, Artikel.Art_Nr, Art_Omschrijving, Eenheden.Eenh_HoevInvoer, Artikel.ARt_Id "
        End If
        cSql &= " ORDER BY Kategorie.Kat_ProductiePlan, Art_omschrijving"
        oSql.Execute(cSql)
        Me.GrdArtikel.Rows.Clear()
        ' GrdArtikel.DataSource = oSql.dt
        For Each oRow As DataRow In oSql.dt.Rows
            Dim nRowGrid As Integer = Me.GrdArtikel.Rows.Add
            Me.GrdArtikel("colKat", nRowGrid).Value = oRow("Kat_productieplan")
            Me.GrdArtikel("colArtNr", nRowGrid).Value = oRow("Art_Nr")
            Me.GrdArtikel("colOmschrijving", nRowGrid).Value = oRow("ARt_Omschrijving")
            Me.GrdArtikel("colHoev1", nRowGrid).Value = oRow(3)
            Me.GrdArtikel("colEenh", nRowGrid).Value = oRow("Eenh_HoevInvoer")
            Me.GrdArtikel("colArt_id", nRowGrid).Value = oRow("Art_id")
        Next
        Me.GrdArtikel.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.GrdArtikel.RowsDefaultCellStyle.SelectionBackColor = Me.GrdBestelling.BackgroundColor
        Me.GrdBestelling.Rows.Clear()
        Try
            Me.refreshArtikel(0)
        Catch
        End Try
    End Sub

    Private Sub frmProductiePlanOverzicht_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormMode = ModeValues.RecordEntry
        loading = True
        loadLeveringDatums()
        Me.lSelectall = True
        Me.BtnSelectAll.Text = "Selecteren"
        Me.FormMode = ModeValues.RecordEntry
        klantTypeCombobox.SelectedIndex = 0
        requeryAll()
        loading = False
        For Each bestellingCol As DataGridViewColumn In GrdBestelling.Columns
            bestellingCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        For Each artikelCol As DataGridViewColumn In GrdArtikel.Columns
            artikelCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        Me.setTooltip(Me.BtnSave, "Opheffing van deze operatie wordt niet ondersteund.")
        Me.setTooltip(Me.btnClose, "Houdt geen rekening met U laatste aanpassingen.")
        Me.CancelButton = Me.btnClose
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub GrdArtikel_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdArtikel.RowEnter
        Me.refreshArtikel(e.RowIndex)
    End Sub
    Sub refreshArtikel(ByVal nRowParameter As Integer)
        Dim leveringsDatum As Date = bzBestel.dGetLeveringForBestellingDatum(Now)
        Dim dateReport As String = getDatereport()
        Dim artID As Long = Me.GrdArtikel.Rows(nRowParameter).Cells("colArt_id").Value
        Dim oSql As New sqlClass
        Dim cSql As String = ""
        If klantTypeCombobox.SelectedIndex <> 2 Then
            cSql = "SELECT BestD.BestD_Artikel, Sum(BestD.BestD_Hoev1) AS Hoev1, BestH.BestH_Klant, BestH.BestH_DatLevering, Klanten.KL_Nummer, Klanten.KL_Naam,Bestd_id"
            cSql &= " ," & sqlClass.c("B") & " as klantType "
            cSql &= " from (BestD INNER JOIN BestH ON BestD.BestD_BestH = BestH.BestH_Id) INNER JOIN Klanten ON BestH.BestH_Klant = Klanten.KL_ID"
            cSql &= " GROUP BY Bestd_id,BestD.BestD_Artikel, BestH.BestH_Klant, BestH.BestH_DatLevering, Klanten.KL_Nummer, Klanten.KL_Naam"
            cSql &= " HAVING BestD.BestD_Artikel =" & artID
            cSql &= " AND BestH.BestH_DatLevering " & dateReport
        End If
        If klantTypeCombobox.SelectedIndex = 0 Then
            cSql &= " UNION ALL "
        End If
        If klantTypeCombobox.SelectedIndex <> 1 Then
            cSql &= " SELECT BestD.BestD_Artikel, Sum(BestD.BestD_Hoev1) AS Hoev1, BestH.BestH_Klant, BestH.BestH_DatLevering, Klanten.KL_Nummer, Klanten.KL_Naam,Bestd_id"
            cSql &= " ," & sqlClass.c("P") & " as klantType "
            cSql &= " FROM (PD BestD INNER JOIN PH BestH ON BestD.BestD_BestH = BestH.BestH_Id) INNER JOIN Klanten ON BestH.BestH_Klant = Klanten.KL_ID"
            cSql &= " GROUP BY Bestd_id,BestD.BestD_Artikel, BestH.BestH_Klant, BestH.BestH_DatLevering, Klanten.KL_Nummer, Klanten.KL_Naam"
            cSql &= " HAVING BestD.BestD_Artikel =" & artID
            cSql &= " AND BestH.BestH_DatLevering " & dateReport
            cSql &= " ORDER BY KL_naam,BestH.BestH_DatLevering,Bestd_id"
        End If

        oSql.Execute(cSql)
        Me.GrdBestelling.Rows.Clear()
        For Each oRowInTable As DataRow In oSql.dt.Rows
            Dim nRow As Integer = Me.GrdBestelling.Rows.Add
            Me.GrdBestelling.Rows(nRow).Cells("colDatum").Value = oRowInTable("Besth_Datlevering")
            Me.GrdBestelling.Rows(nRow).Cells("colDag").Value = modDutch.cDagInDeWeek(oRowInTable("Besth_Datlevering"))
            Me.GrdBestelling.Rows(nRow).Cells("colKl_nummer").Value = oRowInTable("Kl_Nummer")
            Me.GrdBestelling.Rows(nRow).Cells("colKl_Naam").Value = oRowInTable("Kl_Naam")
            Me.GrdBestelling.Rows(nRow).Cells("colHoev").Value = oRowInTable("Hoev1")
            Me.GrdBestelling.Rows(nRow).Cells("Bestd_id").Value = oRowInTable("Bestd_id")
            If oRowInTable("klantType") = "P" Then
                GrdBestelling.Rows(nRow).DefaultCellStyle.BackColor = applicationParticulierColor
            End If
        Next
    End Sub

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAll.Click
        For Each oRow As DataGridViewRow In Me.GrdBestelling.Rows
            oRow.Cells("colSel").Value = Me.lSelectall
        Next
        Me.lSelectall = Not Me.lSelectall
        Me.BtnSelectAll.Text = IIf(Me.lSelectall, "Selecteer", "Deselecteer")
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim osql As New sqlClass
        osql.beginTransaction()
        Dim nSum As Double = 0
        For Each oRow As DataGridViewRow In Me.GrdBestelling.Rows
            If oRow.Cells("colSel").Value = False Then Continue For
            Dim tableName As String = IIf(bzKlanten.isParticulier(bzKlanten.kl_id(oRow.Cells("colKL_Nummer").Value)), "pD", "bestD")
            Dim cSql As String
            cSql = "delete * from " & tableName & " where bestd_id = " & oRow.Cells("Bestd_id").Value
            osql.ExecuteNonQuery(cSql, osql.t)
            modLog.nLog("Deleted Art " & Me.GrdArtikel.CurrentRow.Cells("colArtNr").Value & " - Kl " & oRow.Cells("colKl_nummer").Value, Me.Name)
            nSum += oRow.Cells("colhoev").Value
        Next
        osql.commitTransation()
        Me.GrdArtikel.CurrentRow.Cells("colHoev1").Value -= nSum
        refreshArtikel(Me.GrdArtikel.CurrentRow.Index)
    End Sub

    Private Sub klantTypeCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles klantTypeCombobox.SelectedIndexChanged
        If loading <> True Then
            requeryAll()
        End If
    End Sub

    Private Sub leveringsDatumsCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles leveringsDatumsCombobox.SelectedIndexChanged
        If loading <> True Then
            requeryAll()
        End If
    End Sub

    Private Sub frmProductiePlanOverzicht_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim osql As New sqlClass
        osql.ExecuteNonQuery("delete from ph where not exists (select * from pd where bestd_besth = besth_id)")
        osql.ExecuteNonQuery("delete from besth where not exists (select * from bestd where bestd_besth = besth_id)")
    End Sub
End Class

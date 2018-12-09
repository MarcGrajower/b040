Public Class frmIndex
    Inherits b040.frmB040
    Dim oSqlGlobal As New sqlClass
    Public cGlobalFilename As String = "tmpGlobal"
    Dim cWorkfilename As String = "tmpWork"
    Dim cIndexFilename As String = "tmpIndex"
    Dim cKLantFilename As String = "tmpKlant"
    Public oSelectedDetail As New IndexSelectedDetail(Me)
    Dim nTotBedrag As Double
    Dim nTotDoel As Double
    Dim nTotExPost As Double
    Public Shared cXls As String
    Public Shared Function lActive() As Boolean
        frmIndex.cXls = sqlClass.cDataFolder & "\index2.xlsx"
        Return IO.File.Exists(frmIndex.cXls)
    End Function
    Public Shared Sub dropTmp()
        Dim cMail As String = "The following failed"
        Dim lMail As Boolean = False
        Dim oSql As New sqlClass
        Dim cSql As String = "drop table tmpGlobal"
        Try
            oSql.ExecuteNonQuery(cSql)
        Catch
            cMail &= vbCrLf & cSql
            lMail = True
        End Try

        cSql = "drop table tmpIndex"
        Try
            oSql.ExecuteNonQuery(cSql)
        Catch
            cMail &= vbCrLf & cSql
            lMail = True
        End Try
        cSql = "drop table tmpWork"
        Try
            oSql.ExecuteNonQuery(cSql)
        Catch
            cMail &= vbCrLf & cSql
            lMail = True
        End Try
        cSql = "drop table tmpKlant"
        Try
            oSql.ExecuteNonQuery(cSql)
        Catch
            cMail &= vbCrLf & cSql
            lMail = True
        End Try
        If lMail Then
            SendEmail("b040 - failure ", cMail, "p806Antwerp@gmail.com", "p806Antwerp@gmail.com", "")
        End If
    End Sub

    Private Sub frmIndex_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnArtikelsClick()
        End If
    End Sub
    Private Sub frmIndex_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.FormMode = ModeValues.RecordEntry
        Me.txtTotDatum.Text = Format(bzFactuur.dBatchFactuurDatum, modDutch.cDateFormat)
        For Each oCol As DataGridViewColumn In GrdKlant.Columns
            If oCol.Visible = True Then oCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        For Each oCol As DataGridViewColumn In GrdTransaction.Columns
            If oCol.Visible = True Then oCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        For Each oCol As DataGridViewColumn In grdDetail.Columns
            If oCol.Visible = True Then oCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        GrdKlant.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 255)
        GrdTransaction.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 255, 230)
        GrdTransaction.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 255, 230)
        grdDetail.setColumnDisabled("colKat")
        grdDetail.setColumnDisabled("colEenh")
        grdDetail.setColumnDisabled("colArt")
        grdDetail.setColumnDisabled("colOmschrijving")
        grdDetail.setColumnDisabled("colHoev")
        grdDetail.setColumnDisabled("colBedrag1")
        Dim oTooltip As New ToolTip
        oTooltip.ShowAlways = True
        oTooltip.SetToolTip(Me.BtnArtikels, "Aanpassen op het niveau van de faktuurlijn.")
        oTooltip.SetToolTip(Me.BtnCN, "Verwijder Credite Nota's (negatieve bestellingen en leveringen)")
        oTooltip.SetToolTip(Me.btnOK, "Opheffing van deze operatie wordt niet ondersteund.  Er wordt ondersteld dat er een copij van b040_be.accdb voorhanden is.")
        oTooltip.SetToolTip(Me.btnClose, "Heft alle aanpassingen op.  Gebruik 'schorsen' indien U later wenst af te werken.")
        oTooltip.SetToolTip(Me.BtnSchors, "Schorst deze sessie.   Heropenen formulier herlaadt de aanpaasingen.")
        oTooltip.SetToolTip(Me.BtnVerwijder, "Opheffing van deze operatie wordt niet ondersteund.  U kunt deze sessie wel annuleren.")
        oTooltip.Active = True
    End Sub
    Private Sub frmIndex_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.grdDetail.Columns("colHoevEP").DefaultCellStyle.BackColor = Color.White
        Me.grdDetail.Columns("colBedragEP").DefaultCellStyle.BackColor = Color.White
        If sqlClass.lTable("TmpKlant") Then
            Dim oSql As New sqlClass
            Dim cSql As String
            cSql = "select * from tmpKlant"
            oSql.Execute(cSql)
            Me.GrdKlant.Rows.Clear()
            Me.nTotBedrag = 0
            Me.nTotDoel = 0
            Me.nTotExPost = 0
            For Each oRowTable As DataRow In oSql.dt.Rows
                Dim nRow As Integer = GrdKlant.Rows.Add
                Me.GrdKlant("Rekening", nRow).Value = oRowTable("Rekening")
                Me.GrdKlant("Bedrag", nRow).Value = oRowTable("Bedrag")
                Me.GrdKlant("Percent", nRow).Value = oRowTable("PercentFld")
                Me.GrdKlant("Doel", nRow).Value = oRowTable("Doel")
                Me.GrdKlant("Expost", nRow).Value = oRowTable("Expost")
                Me.GrdKlant("id", nRow).Value = oRowTable("ID")
                Me.GrdKlant("BTW", nRow).Value = oRowTable("BTW")
                Me.GrdKlant("Klant", nRow).Value = oRowTable("Klant")
                Me.GrdKlant("Kl_Nummer", nRow).Value = oRowTable("Kl_Nummer")
                Me.nTotBedrag += oRowTable("Bedrag")
                Me.nTotDoel += oRowTable("Doel")
                Me.nTotExPost += oRowTable("Expost")
            Next
            Me.refreshKlantTotals()
            Try
                Me.GrdKlant.Rows(0).Selected = True
            Catch
            End Try
            Me.GrdTransaction.Focus()
            Me.GrdKlant.Focus()
            Me.refreshTransaction(0)
            Exit Sub
        End If
        copyIndexToTemp()
        refreshAll()
    End Sub
    Sub copyIndexToTemp()
        Dim oSql As New sqlClass
        Try
            oSql.ExecuteNonQuery("drop table " & Me.cIndexFilename)
        Catch
        End Try
        Dim cSql As String = "create table " & Me.cIndexFilename & " (Ind_KlNummer text(5), Ind_Percent currency) "
        oSql.ExecuteNonQuery(cSql)
        Using oXl As New clsExcel
            oXl.openWorkbook(frmIndex.cXls)
            For i As Long = 2 To oXl.nUsedrangeRow
                Dim cKlant As String = oXl.cGet(i, 1)
                Dim nPercent As Double = Math.Round(oXl.nGetDouble(i, 3), 1)
                Dim oSqlB As New sqlClass.SqlBuilder
                oSqlB.cTable = Me.cIndexFilename
                oSqlB.addInsert("Ind_KlNummer", sqlClass.c(cKlant))
                oSqlB.addInsert("Ind_Percent", sqlClass.cDoubleForjet(nPercent))
                oSql.ExecuteNonQuery(oSqlB.cInsert)
            Next
            oXl.oWB.Close()
        End Using
    End Sub
    Sub saveIndex()
        Dim osql As New sqlClass
        Dim c As String

        For Each oRow As DataGridViewRow In Me.GrdKlant.Rows
            If oRow.Cells("Percent").Value = 1 Then
                c = "delete * from " & Me.cIndexFilename
                c &= " where val(ind_KLNummer) = val(" & sqlClass.c(oRow.Cells("KL_Nummer").Value) & ")"
                osql.ExecuteNonQuery(c)
                Continue For
            End If
            c = "update " & Me.cIndexFilename
            c &= " set ind_Percent = " & sqlClass.cDoubleForjet(oRow.Cells("PERCENT").Value)
            c &= " where val(ind_KLNummer) = val(" & sqlClass.c(oRow.Cells("KL_Nummer").Value) & ")"
            Dim nTally As Long = osql.ExecuteNonQuery(c)
            If nTally = 0 Then
                Dim oSB As New sqlClass.SqlBuilder
                oSB.cTable = Me.cIndexFilename
                oSB.addInsert("Ind_KlNummer", sqlClass.c(oRow.Cells("KL_Nummer").Value))
                oSB.addInsert("Ind_Percent", sqlClass.cDoubleForjet(oRow.Cells("PERCENT").Value))
                osql.ExecuteNonQuery(oSB.cInsert)
            End If
        Next
        Using oXL As New clsExcel
            oXL.openWorkbook(frmIndex.cXls, lReadonly:=False)
            oXL.selectRange(2, 1, oXL.nUsedrangeRow, oXL.nUsedRangeColumn)
            oXL.selClear()
            Dim i As Long = 2
            c = "select *,KL_Naam from " & Me.cIndexFilename & ",klanten  where val(Ind_KlNummer) = val(Kl_Nummer)"
            osql.Execute(c)
            For Each oRow As DataRow In osql.dt.Rows
                oXL.setString("A" & i, oRow("Ind_KLNummer"))
                oXL.setString("B" & i, oRow("KL_NAAM"))
                oXL.setNum("C" & i, oRow("IND_PERCENT"))
                i += 1
            Next
            oXL.selectRange("C" & 2 & ":C" & i)
            oXL.selPercent()
            oXL.oWB.SaveAs(frmIndex.cXls)
        End Using
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        frmIndex.dropTmp()


        Me.Close()
    End Sub

    Private Sub TxtTotDatum_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotDatum.Validating
        If Me.lastKeycode <> Keys.Tab Then Exit Sub
        If b040.modDutch.checkDate(Me.txtTotDatum.Text) = False Then
            MsgBox(Me.txtTotDatum.Text & " is geen geldig datum. ")
            e.Cancel = True
            Exit Sub
        End If
        Me.refreshAll()

    End Sub
    Sub refreshAll()
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 10
        Try
            oSqlGlobal.ExecuteNonQuery("drop table " & Me.cWorkfilename)
            oSqlGlobal.Execute("drop table " & Me.cGlobalFilename)

        Catch
        End Try
        Me.ProgressBar1.Value = 20
        Dim c As String
        c = "select bestd_id"
        c &= ",bestd_besth"
        c &= ",besth_docnr"
        c &= ",besth_klant"
        c &= ",kl_nummer"
        c &= ",Kl_Code"
        c &= ",Kl_Naam"
        c &= ",Kl_Korting"
        c &= ",besth_datlevering"
        c &= ",besth_factuur"
        c &= ",bestd_Artikel"
        c &= ",art_nr"
        c &= ",art_kategorie"
        c &= ",kat_naam"
        c &= ",kat_productieplan"
        c &= ",art_eenheid"
        c &= ",eenh_omschrijving"
        c &= ",art_BTW"
        c &= ",art_Korting"
        c &= ",art_omschrijving"
        c &= ",bestd_Omschrijving"
        c &= ",bestd_Hoev1"
        c &= ",bestd_Waarde"
        c &= " into " & Me.cWorkfilename
        c &= " from bestd"
        c &= ",besth"
        c &= ",klanten"
        c &= ",TypeFact"
        c &= ",Artikel"
        c &= ",Kategorie"
        c &= ",Eenheden"
        c &= " where bestd_besth = besth_id"
        c &= " and besth_klant = kl_id"
        c &= " and kl_facturatie = typf_id"
        c &= " and bestd_artikel = art_id"
        c &= " and art_kategorie = kat_id"
        c &= " and art_eenheid = eenh_id"
        c &= " and besth_datlevering <= " & sqlClass.cDateForJet(CDate(Me.txtTotDatum.Text))
        c &= " and besth_factuur = '0'"
        c &= " and Typf_omschrijving = " & sqlClass.c("Groothandel")
        oSqlGlobal.ExecuteNonQuery(c)
        Me.ProgressBar1.Value = 30

        c = "select " & Me.cWorkfilename & ".*"
        c &= ",KK_Korting"
        c &= ",bestd_waarde * iif(art_korting=0,1,iif(kk_korting is null,1-kl_Korting/100,1-kk_Korting/100)) as netto"
        c &= " into " & Me.cGlobalFilename
        c &= " from " & Me.cWorkfilename
        c &= " left join KlantenKorting on klantenkorting.KK_Artikel = " & Me.cWorkfilename & ".bestd_Artikel and KlantenKorting.KK_Klant = " & Me.cWorkfilename & ".besth_Klant"
        oSqlGlobal.ExecuteNonQuery(c)
        c = "alter table " & Me.cGlobalFilename & " add column expostHoev float"
        oSqlGlobal.ExecuteNonQuery(c)
        c = "alter table " & Me.cGlobalFilename & " add column expostBedrag float"
        oSqlGlobal.ExecuteNonQuery(c)
        Me.ProgressBar1.Value = 40

        c = "Select kl_naam"
        c &= ",kl_Nummer"
        c &= ",Besth_Klant"
        c &= ",Art_BTW"
        c &= ",sum(Netto) as bedrag"
        c &= ", iif(isnull(ind_percent),1,ind_percent) as pct"
        c &= "," & (New Double).ToString & " as expost"
        c &= " from " & Me.cGlobalFilename
        c &= " left join " & Me.cIndexFilename
        c &= " on val(" & Me.cGlobalFilename & ".kl_nummer) =  val(" & Me.cIndexFilename & ".Ind_KlNummer)"
        c &= " group by kl_naam,kl_Nummer,Besth_Klant,ARt_BTW,iif(isnull(ind_percent),1,ind_percent),0"
        c &= " order by iif(isnull(ind_percent),1,ind_percent)"
        Dim nKl As Long = oSqlGlobal.Execute(c)
        Me.ProgressBar1.Value = 50

        Dim nRow As Integer = -1
        GrdKlant.Rows.Clear()
        Me.nTotBedrag = 0
        Me.nTotDoel = 0
        Me.nTotExPost = 0
        For Each oRow As DataRow In oSqlGlobal.dt.Rows
            GrdKlant.Rows.Add()
            nRow += 1
            Me.ProgressBar1.Value = 50 + 45 * nRow / nKl
            Me.GrdKlant("Rekening", nRow).Value = Trim(oRow("KL_Naam")) & " (" & CType(oRow("Art_BTW"), Double).ToString("#0.00") & "% BTW)"
            Me.GrdKlant("Bedrag", nRow).Value = oRow("Bedrag")
            Me.nTotBedrag += oRow("Bedrag")
            Me.GrdKlant("Percent", nRow).Value = CDbl(oRow("PCT"))  ' make sure of type as this is an updatable and sortable field
            Me.GrdKlant("percent", nRow).Style.BackColor = Color.White
            Dim nDoel As Double = oRow("PCT") * oRow("Bedrag")
            Me.GrdKlant("Doel", nRow).Value = nDoel
            Me.nTotDoel += nDoel
            Me.GrdKlant("id", nRow).Value = nRow
            Me.GrdKlant("BTW", nRow).Value = oRow("Art_BTW")
            Me.GrdKlant("Klant", nRow).Value = oRow("Besth_Klant")
            Me.GrdKlant("KL_Nummer", nRow).Value = oRow("KL_Nummer")
            Dim nTotalKlant As Double = 0
            Dim o As New Index
            o.nKL_Id = oRow("Besth_Klant")
            o.nBTW = oRow("Art_BTW")
            o.nPercent = oRow("PCT")
            o.cTable = Me.cGlobalFilename
            o.recompute()
            Me.GrdKlant("Expost", nRow).Value = o.nExPost
            Me.nTotExPost += o.nExPost
        Next
        ' MsgBox(Me.GrdKlant("Percent", 0).Value.GetType.ToString)
        Me.refreshKlantTotals()
        Try
            Me.GrdKlant.Rows(0).Selected = True
        Catch
        End Try
        Me.GrdTransaction.Focus()
        Me.GrdKlant.Focus()
        Me.refreshTransaction(0)
        Me.ProgressBar1.Visible = False
    End Sub
    Sub refreshKlantTotals()
        Me.txtBedrag.Text = Me.nTotBedrag.ToString("N2")
        Me.txtBedrag.Left = Me.GrdKlant.nColumnLeft("Bedrag")
        Me.txtBedrag.Width = Me.GrdKlant.Columns("Bedrag").Width
        Me.txtBedrag.Visible = True
        Me.txtDoel.Text = Me.nTotDoel.ToString("N2")
        Me.txtDoel.Left = Me.GrdKlant.nColumnLeft("Doel")
        Me.txtDoel.Width = Me.GrdKlant.Columns("Doel").Width
        Me.txtDoel.Visible = True
        Me.txtExPost.Text = Me.nTotExPost.ToString("N2")
        Me.txtExPost.Left = Me.GrdKlant.nColumnLeft("Expost")
        Me.txtExPost.Width = Me.GrdKlant.Columns("Expost").Width
        Me.txtExPost.Visible = True
    End Sub

    Private Sub GrdKlant_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdKlant.CellEndEdit
        Dim cCol As String = UCase(Me.GrdKlant.Columns(Me.GrdKlant.CurrentCell.ColumnIndex).Name)
        Dim nRow As Integer = Me.GrdKlant.SelectedRows(0).Index

        Select Case cCol
            Case "PERCENT"
                Me.GrdKlant("DOEL", nRow).Value = Me.GrdKlant("BEDRAG", nRow).Value * Me.nCDouble(Me.GrdKlant("PERCENT", nRow).Value) / 100
                Dim o As New Index
                o.nKL_Id = Me.GrdKlant("Klant", nRow).Value
                o.nBTW = Me.GrdKlant("BTW", nRow).Value
                o.nPercent = Me.nCDouble(Me.GrdKlant("PERCENT", nRow).Value) / 100
                o.cTable = Me.cGlobalFilename
                o.recompute()
                Me.GrdKlant("Expost", nRow).Value = o.nExPost
                Me.refreshTransaction(nRow)
                Me.computeTotalsforsession()
                Me.refreshKlantTotals()
                ' you need this to keep the column sortable.
                Me.GrdKlant.CurrentCell.Value = CDbl(o.nPercent)
        End Select
    End Sub
    Public Sub computeTotalsforsession()
        Me.nTotDoel = 0
        Me.nTotExPost = 0
        For Each oRow As DataGridViewRow In GrdKlant.Rows
            Me.nTotDoel += Me.nCDouble(oRow.Cells("Doel").Value)
            Me.nTotExPost += Me.nCDouble(oRow.Cells("Expost").Value)
        Next
    End Sub
    Private Sub GrdKlant_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdKlant.RowEnter
        Me.refreshTransaction(e.RowIndex)
    End Sub


    Sub refreshTransaction(ByVal nRowIndex As Integer)
        Dim nKlant As Object = 0
        Dim lEmptyGrid As Boolean = False
        Try
            nKlant = Me.GrdKlant("Klant", nRowIndex).Value
        Catch ex As Exception
            lEmptyGrid = True
        End Try
        If lEmptyGrid = True Then Exit Sub
        If nKlant Is Nothing Then Exit Sub
        Dim oSqlTransactions As New sqlClass
        Dim cSqlTransactions As String
        cSqlTransactions = "Select tmpGlobal.bestd_Besth,tmpGlobal.besth_datlevering, tmpGlobal.besth_docnr, tmpGlobal.bestd_besth,Sum(tmpGlobal.Netto) AS Netto, Sum(tmpGlobal.expostBedrag) AS Expost"
        cSqlTransactions &= " FROM " & Me.cGlobalFilename & " as tmpGlobal"
        cSqlTransactions &= " WHERE(((tmpGlobal.besth_klant) = " & nKlant & ") And ((tmpGlobal.art_BTW) = " & sqlClass.cDoubleForjet(Me.GrdKlant("BTW", nRowIndex).Value) & "))"
        cSqlTransactions &= " GROUP BY bestd_BestH,tmpGlobal.besth_datlevering, tmpGlobal.besth_docnr, tmpGlobal.bestd_besth, tmpGlobal.besth_klant, tmpGlobal.art_BTW"
        cSqlTransactions &= " ORDER BY tmpGlobal.besth_klant, tmpGlobal.besth_datlevering"
        oSqlTransactions.Execute(cSqlTransactions)
        Me.GrdTransaction.Rows.Clear()
        For Each oRow As DataRow In oSqlTransactions.dt.Rows

            Dim nGrdRow As Integer = GrdTransaction.Rows.Add
            Me.GrdTransaction("ColType", nGrdRow).Value = bzBestel.cDocType(oRow("Besth_Docnr"))
            Me.GrdTransaction("ColVlg", nGrdRow).Value = bzBestel.cDocSeq(oRow("Besth_Docnr"))
            Me.GrdTransaction("colDag", nGrdRow).Value = modDutch.cDagInDeWeek(oRow("Besth_datlevering")) & If(bzBestel.lHasKg(oRow("Bestd_BestH")), " *", "")
            Me.GrdTransaction("colDatum", nGrdRow).Value = oRow("besth_DatLevering")
            Me.GrdTransaction("colBedrag", nGrdRow).Value = oRow("Netto")
            Me.GrdTransaction("colExpost", nGrdRow).Value = oRow("Expost")
            Me.GrdTransaction("colBestH_id", nGrdRow).Value = oRow("Bestd_BestH")
        Next
        Me.GrdTransaction.Rows(0).Selected = True
        Me.refreshDetail(0)

    End Sub
    Sub refreshDetail(ByVal nRowTransaction As Integer)
        If Me.GrdTransaction.Rows.Count = 0 Then Exit Sub
        If Me.GrdTransaction.Rows(nRowTransaction).Cells("colBestH_Id").Value = 0 Then Return
        Dim nKlantRow As Integer = Me.GrdKlant.SelectedRows(0).Index
        If Me.GrdKlant("Klant", nKlantRow).Value Is Nothing Then Exit Sub

        Dim osqlDetail As New sqlClass
        Dim cSqlDetail As String
        Dim cTableDetail As String = Me.cGlobalFilename
        Dim nPkDetail As Long = Me.GrdTransaction.Rows(nRowTransaction).Cells("colBestH_Id").Value
        cSqlDetail = "SELECT tmpGlobal.kat_productieplan, tmpGlobal.eenh_omschrijving, tmpGlobal.art_nr, tmpGlobal.bestd_Omschrijving, tmpGlobal.bestd_Hoev1, "
        cSqlDetail &= "tmpGlobal.netto, tmpGlobal.expostHoev, tmpGlobal.expostBedrag, tmpGlobal.bestd_id, tmpGlobal.bestd_besth, tmpGlobal.besth_klant "
        cSqlDetail &= " FROM " & cTableDetail & " as tmpGlobal "
        cSqlDetail &= " WHERE tmpGlobal.bestd_besth= " & nPkDetail
        cSqlDetail &= " order by 2,1 "
        osqlDetail.Execute(cSqlDetail)
        Me.grdDetail.Rows.Clear()
        For Each oRow As DataRow In osqlDetail.dt.Rows
            Dim nGrdRow As Integer = grdDetail.Rows.Add
            Me.grdDetail("ColKat", nGrdRow).Value = oRow("kat_productieplan")
            Me.grdDetail("ColEenh", nGrdRow).Value = oRow("eenh_omschrijving")
            Me.grdDetail("ColArt", nGrdRow).Value = oRow("Art_Nr")
            Me.grdDetail("ColOmschrijving", nGrdRow).Value = oRow("bestd_omschrijving")
            Me.grdDetail("ColHoev", nGrdRow).Value = oRow("bestd_Hoev1")
            Me.grdDetail("ColBEdrag1", nGrdRow).Value = oRow("Netto")
            Me.grdDetail("ColHoevEP", nGrdRow).Value = oRow("ExPostHoev")
            Me.grdDetail("ColHoevEP", nGrdRow).Style.BackColor = Color.White
            Me.grdDetail("ColBedragEP", nGrdRow).Value = oRow("expostBedrag")
            Me.grdDetail("ColBedragEP", nGrdRow).Style.BackColor = Color.White
            Me.grdDetail("ColBestd_id", nGrdRow).Value = oRow("BEstd_id")
        Next
        Me.grdDetail.ClearSelection()
        Me.grdDetail("colHoevEP", 0).Selected = True
    End Sub
    Public Overrides Function grdValidate(ByVal ctrl As String, ByRef cInput As String) As Boolean
        Dim oGrd As grdBase = Me.grdCurrentlyValidating
        Select Case Trim(ctrl)
            Case "COLHOEVEP"
                If cInput = "" Then cInput = "0"
                Dim nPrice As Double = Me.oSelectedDetail.nPrice()
                cInput = Val(cInput).ToString("N0")
                If oSelectedDetail.nPrice <> 0 Then
                    oGrd.currentColumnValue("COLBEDRAGEP") = Math.Round((Me.nCDouble(cInput) * nPrice), 2).ToString("N2")
                End If
                Return True
            Case "COLBEDRAGEP"
                If cInput = "" Then cInput = "0.00"
                Dim nPrice As Double = Me.oSelectedDetail.nPrice()
                cInput = Me.nCDouble(cInput).ToString("N2")
                If oSelectedDetail.nPrice <> 0 Then
                    Dim nHoev As Long = Math.Round(Me.nCDouble(cInput) / Me.oSelectedDetail.nPrice, 0)
                    oGrd.currentColumnValue("COLHOEVEP") = nHoev.ToString("N0")
                    cInput = Math.Round((nHoev * nPrice), 2).ToString("N2")
                End If
                Return True
            Case "PERCENT"
                If cInput = "" Then cInput = "0"
                If Val(cInput) = 0 Then
                    MsgBox("Percent kan niet nul zijn")
                    Return False
                End If
                cInput = (Me.nCDouble(cInput) / 100).ToString("P2")
            Case Else
                cInput = oGrd.currentColumnValue(ctrl)
                Return True
        End Select
        Return True

    End Function
    Private Sub GrdArtikel_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetail.CellEndEdit
        ' carule the grid is grdDetail.
        Dim cCol As String = UCase(Me.grdDetail.Columns(Me.grdDetail.CurrentCell.ColumnIndex).Name)
        Select Case cCol
            Case "COLHOEVEP", "COLBEDRAGEP"
                Me.oSelectedDetail.recompute()
                Me.nTotExPost = 0
                For Each oRow As DataGridViewRow In GrdKlant.Rows
                    nTotExPost += Me.nCDouble(oRow.Cells("Expost").Value)
                Next
                Me.refreshKlantTotals()
                Me.grdDetail.CurrentCell.Value = CDbl(Me.grdDetail.CurrentCell.Value) ' you need this for the column to be sortable.
            Case Else
        End Select
    End Sub
    Function nCDouble(ByVal c As String) As Double
        c = Replace(c, "%", "")
        Dim a As String() = Split(c, ".")
        Dim n As Double
        n = 0
        If a.Count = 2 AndAlso CType(a(1), String).Length = 2 Then c = Replace(c, ".", ",")
        Try
            n = CType(c, Double)
        Catch ex As Exception
        End Try
        Return n
    End Function
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Value = 10
        Dim osql As New sqlClass
        Dim c As String
        c = "update (bestd "
        c &= " inner join " & Me.cGlobalFilename & " on bestd.bestd_id = " & Me.cGlobalFilename & ".bestd_id)"
        c &= " inner join Artikel on bestd.bestd_artikel = artikel.art_id"
        c &= " set bestd.bestd_hoev1 = expostHoev"
        c &= ", bestd.bestd_waarde = expostBedrag * " & Me.cGlobalFilename & ".bestd_waarde / " & Me.cGlobalFilename & ".Netto "
        c &= ", bestd.bestd_omschrijving = artikel.art_omschrijving"
        c &= " where " & Me.cGlobalFilename & ".netto<>0"
        osql.ExecuteNonQuery(c)
        Me.ProgressBar1.Value = 70
        'Delete all the Bestd_Waarde = 0 from bestd.
        c = "DELETE bestd.*, bestd.BestD_Waarde, Exists (select * from " & Me.cGlobalFilename & " where tmpglobal.bestd_id = bestd.bestd_id) AS Expr1"
        c &= " FROM(bestd)"
        c &= " WHERE (((bestd.BestD_Waarde)=0)"
        c &= " AND ((Exists (select * from " & Me.cGlobalFilename & " where " & Me.cGlobalFilename & ".bestd_id = bestd.bestd_id))<>False))"
        osql.ExecuteNonQuery(c)
        Me.ProgressBar1.Value = 80
        'Delete Zero docs from bestH and renumber where necessary
        For Each oRowPickedKlant As DataGridViewRow In Me.GrdKlant.Rows
            If (oRowPickedKlant.Cells("percent").Value < 1) = False Then Continue For
            Dim cKlant As String = Strings.Right("00000" & Trim(oRowPickedKlant.Cells("kl_nummer").Value), 5)
            Dim oSqlForKlant As New sqlClass
            Dim cSqlForKlant As String
            cSqlForKlant = "select BestH_Docnr from tmpGlobal "
            cSqlForKlant &= " where left(besth_docnr,5) = " & sqlClass.c(cKlant)
            cSqlForKlant &= " group by besth_docnr having sum(expostbedrag) = 0 order by besth_docnr DESC"
            oSqlForKlant.Execute(cSqlForKlant)
            For Each oRowForKlant As DataRow In oSqlForKlant.dt.Rows
                'Delete The record in BestH
                Dim cDocToBeDeleted As String = oRowForKlant("Besth_Docnr")
                c = "delete besth.* from besth where besth_Docnr = " & sqlClass.c(cDocToBeDeleted)
                osql.ExecuteNonQuery(c)
                'Get the docs to be renumbered as those in BestH that are bigger and with equal kkkkkyymmddt (12 bytes)
                Dim oSqlForDoc As New sqlClass
                Dim cSqlForDoc As String
                cSqlForDoc = "select besth_docnr from BEstH group by besth_docnr,left(besth_docnr,12) = " & sqlClass.c(Strings.Left(cDocToBeDeleted, 12)) & " "
                cSqlForDoc &= " having besth_docnr > " & sqlClass.c(cDocToBeDeleted) & " and left(BestH_Docnr,12) = " & sqlClass.c(Strings.Left(cDocToBeDeleted, 12)) & " "
                cSqlForDoc &= " order by besth_docnr"
                oSqlForDoc.Execute(cSqlForDoc)
                For Each oRowForDoc As DataRow In oSqlForDoc.dt.Rows
                    'renumber the besth
                    Dim cDocToRename As String = oRowForDoc("Besth_Docnr")
                    'subtract 1 from the sequence nr
                    Dim cDocRenamed As String = Strings.Left(cDocToRename, 12) & Strings.Right("000" & Val(Strings.Right(cDocToRename, 3) - 1), 3)
                    c = " update besth set Besth_docnr = " & sqlClass.c(cDocRenamed) & "  where Besth_docnr = " & sqlClass.c(cDocToRename)
                    osql.ExecuteNonQuery(c)
                Next
            Next
        Next
        Me.ProgressBar1.Value = 85
        Me.saveIndex()
        Me.ProgressBar1.Value = 90
        Dim oConn As New OleDb.OleDbConnection(My.Settings.b040_beConnectionString) : oConn.Open()
        Dim oST As DataTable
        oST = oConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})
        For Each oRow As DataRow In oST.Rows
            If oRow!table_type.ToString = "TABLE" And UCase(Strings.Left(oRow!table_name.ToString, 3)) = "TMP" Then
                c = "drop table " & oRow!table_name.ToString
                osql.ExecuteNonQuery(c)
            End If
        Next
        Me.ProgressBar1.Value = 100
        Me.ProgressBar1.Visible = False
        Me.Close()
    End Sub

    Private Sub BtnARtikels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnArtikels.Click
        btnArtikelsClick()
    End Sub
    Private Sub btnArtikelsClick()
        Dim oFrm As New frmIndexArtikels
        oFrm.IndexForm = Me
        oFrm.createIndexArtikel()

        oFrm.ShowDialog()

        Me.grdDetail.Focus()
    End Sub
    Private Sub BtnCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCN.Click
        Dim oSql As New sqlClass
        Dim cSql As String
        cSql = "SELECT tmpGlobal.bestd_id, tmpGlobal.Kl_Naam, tmpGlobal.art_omschrijving, tmpGlobal.expostHoev, tmpGlobal.expostBedrag,kl_Nummer,BestD_BestH "
        cSql &= "FROM tmpGlobal "
        cSql &= "WHERE (((tmpGlobal.expostBedrag)<0))"
        oSql.Execute(cSql)
        oSql.dt.Columns.Add("Percent", GetType(Double))
        oSql.dt.Columns.Add("Nul", GetType(Boolean))
        For Each oRow As DataRow In oSql.dt.Rows
            For Each oRowGrid As DataGridViewRow In Me.GrdKlant.Rows
                If oRow("kl_nummer") = Me.GrdKlant("kl_nummer", oRowGrid.Index).Value Then
                    oRow("Percent") = Me.GrdKlant("Percent", oRowGrid.Index).Value
                    oRow("Nul") = (oRow("Percent") <> 1)
                    Exit For
                End If
            Next

        Next
        oSql.dt.DefaultView.Sort = "Percent,kl_naam"
        oSql.dt = oSql.dt.DefaultView.ToTable
        Dim oFrm As New frmIndexCN


        oFrm.grdCN.BackgroundColor = Me.GrdKlant.BackgroundColor
        For Each oCol As DataGridViewColumn In oFrm.grdCN.Columns
            oCol.DefaultCellStyle.BackColor = oFrm.grdCN.BackgroundColor
        Next
        Dim oNewColumn As New DataGridViewTextBoxColumn
        oNewColumn.Name = "colBestH_Id"
        oNewColumn.Visible = False
        ' oNewColumn.CellType = oFrm.grdCN.Columns("colBestd_id").CellType
        oFrm.grdCN.Columns.Add(oNewColumn)
        For Each oRow As DataRow In oSql.dt.Rows
            Dim nRow As Integer = oFrm.grdCN.Rows.Add()
            oFrm.grdCN("colKlant", nRow).Value = oRow("Kl_Naam")
            oFrm.grdCN("colArtikel", nRow).Value = oRow("Art_Omschrijving")
            oFrm.grdCN("colPercent", nRow).Value = oRow("Percent")
            oFrm.grdCN("colExpostHoev", nRow).Value = oRow("expostHoev")
            oFrm.grdCN("colExpostBedrag", nRow).Value = oRow("expostBedrag")
            oFrm.grdCN("colNul", nRow).Value = oRow("Nul")
            oFrm.grdCN("colBestd_id", nRow).Value = oRow("Bestd_id")
            oFrm.grdCN("colKl_nummer", nRow).Value = oRow("KL_Nummer")
            oFrm.grdCN("colBestH_id", nRow).Value = oRow("Bestd_BestH")
        Next
        oFrm.grdCN.Columns("colKlant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        oFrm.grdCN.Columns("colArtikel").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        oFrm.grdCN.Columns("colPercent").DefaultCellStyle.Format = "##0 %"
        oFrm.grdCN.Columns("colExpostHoev").DefaultCellStyle.Format = "#,##0"
        oFrm.grdCN.Columns("colExpostBedrag").DefaultCellStyle.Format = "#,##0.00"
        oFrm.grdCN.Columns("colNul").DefaultCellStyle.BackColor = Color.White
        oFrm.grdCN.AllowUserToAddRows = False
        If oFrm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return
        For Each oRowCN As DataGridViewRow In oFrm.grdCN.Rows
            If oRowCN.Cells("colNul").Value = True Then
                Dim osqlUpdate As New sqlClass
                Dim cSQlUpdate As String = "UPDATE tmpGlobal SET expostHoev = 0, expostBedrag = 0 "
                cSQlUpdate &= "WHERE bestd_id = " & oRowCN.Cells("colBestd_id").Value
                osqlUpdate.ExecuteNonQuery(cSQlUpdate)
                For Each oRowKlant As DataGridViewRow In Me.GrdKlant.Rows
                    If oRowKlant.Cells("kl_nummer").Value = oRowCN.Cells("colKl_Nummer").Value Then
                        oRowKlant.Cells("Expost").Value -= oRowCN.Cells("colExpostBEdrag").Value
                        Exit For
                    End If
                Next
                For Each oRowTransaction As DataGridViewRow In Me.GrdTransaction.Rows
                    If oRowTransaction.Cells("colBestH_Id").Value = oRowCN.Cells("colBestH_id").Value Then
                        oRowTransaction.Cells("colExpost").Value -= oRowCN.Cells("colExpostBEdrag").Value
                        Exit For
                    End If

                Next
            End If
        Next
        Me.nTotExPost = 0
        For Each oRow As DataGridViewRow In GrdKlant.Rows
            nTotExPost += Me.nCDouble(oRow.Cells("Expost").Value)
        Next
        Me.refreshKlantTotals()
    End Sub

    Private Sub BtnSchors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSchors.Click
        Dim osql As New sqlClass
        Dim cSql As String
        cSql = "drop table tmpKlant"
        Try
            osql.ExecuteNonQuery(cSql)
        Catch ex As Exception
        End Try
        cSql = "Create table tmpKlant "
        cSql &= "(Rekening char(40),Bedrag Decimal(10,2),PercentFld decimal(10,4),Doel Decimal(10,2),Expost Decimal(10,2), id integer, Btw Decimal(10,4),Klant integer,Kl_Nummer char(5))"
        osql.ExecuteNonQuery(cSql)

        For Each oRowKlant As DataGridViewRow In Me.GrdKlant.Rows
            Dim oSqlB As New sqlClass.SqlBuilder
            oSqlB.cTable = "tmpKlant"
            oSqlB.addInsert("Rekening", sqlClass.c(oRowKlant.Cells("Rekening").Value))
            oSqlB.addInsert("Kl_Nummer", sqlClass.c(oRowKlant.Cells("Kl_Nummer").Value))
            oSqlB.addInsert("Bedrag", sqlClass.cDoubleForjet(oRowKlant.Cells("Bedrag").Value))
            oSqlB.addInsert("PercentFld", sqlClass.cDoubleForjet(oRowKlant.Cells("Percent").Value))
            oSqlB.addInsert("Doel", sqlClass.cDoubleForjet(oRowKlant.Cells("Doel").Value))
            oSqlB.addInsert("Expost", sqlClass.cDoubleForjet(oRowKlant.Cells("Expost").Value))
            oSqlB.addInsert("BTW", sqlClass.cDoubleForjet(oRowKlant.Cells("BTW").Value))
            oSqlB.addInsert("ID", oRowKlant.Cells("ID").Value)
            oSqlB.addInsert("Klant", oRowKlant.Cells("Klant").Value)

            osql.ExecuteNonQuery(oSqlB.cInsert)
        Next
        Me.Close()
    End Sub
    Private Sub BtnVerwijder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerwijder.Click
        For Each oGrdRow As DataGridViewRow In Me.grdDetail.Rows
            oGrdRow.Cells("colHoevEP").Value = 0
            oGrdRow.Cells("colBedragEP").Value = 0
            Me.oSelectedDetail.recompute(oGrdRow.Index)
        Next
    End Sub

    Private Sub GrdTransaction_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdTransaction.RowEnter
        Me.refreshDetail(e.RowIndex)
    End Sub

    
End Class
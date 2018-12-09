Option Infer On
Imports System.Linq

Public Class frmBatchFacturatie
    Inherits b040.frmB040
    Dim qGlobal
    Dim osqlGlobal As New sqlClass
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmBatchFacturatie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormMode = ModeValues.RecordEntry
        Dim i As Integer : For i = 1 To 40
            grdFacturatie.Rows.Add()
        Next
        Me.TxtCopijenVervoerDoc.Text = "0"
        Me.TxtCopijenAfrekening.Text = "0"
        Me.setTooltip(Me.btnOK, "Genereer facturen en druk ze éénmaal af, per nummer.")
        Dim cWork As String = Me.LijnenverwijderenLabel.Text
        Me.LijnenverwijderenLabel.Text = Replace(cWork, "<d>", bzFactuur.dBatchFactuurDatum.ToString("dd/MM/yy"))
        Me.particulierenTransactiesVerwijderen.Text = Replace(cWork, "<d>", bzFactuur.dBatchFactuurDatum.ToString("dd/MM/yy"))
        If frmIndex.lActive = False Then
            Me.TpgBase1.TabPages.RemoveAt(Me.TpgBase1.TabCount - 1)
            Me.chkLijnenVerwijderen.Visible = False
            Me.LijnenverwijderenLabel.Visible = False
        End If
        If modB040Config.Generic("VERWIJDERENORDERS") = "YES" Then
            Me.chkLijnenVerwijderen.Checked = True
        End If
        Me.txtLeveringDat.Text = bzFactuur.dBatchFactuurDatum.ToString("dd/MM/yy")
    End Sub

    Private Sub txtLeveringDat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeveringDat.Validating
        If Me.lastKeycode <> Keys.Tab Then Exit Sub
        Dim c As String = Me.txtLeveringDat.Text
        If b040.modDutch.checkDate(c) = False Then
            If Me.lastKeycode <> Keys.Tab Then Exit Sub
            MsgBox(c & " is geen geldige datum.")
            e.Cancel = True
            Exit Sub
        End If
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 10
        Dim sqlTeFactureren As String = "select * from qryBestelKK where bestH_DatLevering <= " & sqlClass.cDateForJet(CType(c, Date))
        sqlTeFactureren &= " and typf_omschrijving = " & sqlClass.c("Groothandel")
        Dim n As Long = osqlGlobal.Execute(sqlTeFactureren)
        Me.ProgressBar1.Value = 50
        If n = 0 Then
            MsgBox("Er zijn geen te factureren bestellingen")
            e.Cancel = True
            Exit Sub
        End If
        'Dim nTotaalNetto As Double = 0
        'For Each oRow As DataRow In osqlGlobal.dt.Rows
        '    Dim nDiscount As Double = 0
        '    If oRow("Art_Korting") = True Then
        '        If nNvlD(oRow("kkkorting")) = 0 Then
        '            nDiscount = nNvlD(oRow("KLkorting"))
        '        Else
        '            nDiscount = nNvlD(oRow("KKkorting"))
        '        End If
        '    End If
        '    nTotaalNetto += nNvlD(oRow("Bestd_Waarde")) * (1 - nDiscount)
        'Next
        Dim q
        q = ( _
            From r In osqlGlobal.dt _
            Select CDbl(nNvlD(r("Bestd_Waarde")) * (1 - If(r("art_korting") = False, 0, If(nNvlD(r("kkkorting")) = 0, r("KLkorting"), r("KKKorting"))))) _
            ).Sum()
        Me.ProgressBar1.Value = 65
        Me.txtTotaalNetto.Text = CType(q, Double).ToString(" #,##0.00 EUR")
        Me.txtVolgendeFactuur.Text = bzFactuur.cNextNr(CDate(Me.txtLeveringDat.Text))
        Me.ProgressBar1.Value = 75
        q = ( _
            From r In osqlGlobal.dt _
            Select klNumber = r("KL_Nummer"), ArtBTW = r("ArtBTW") Distinct).Count()
        Me.txtAantalFacturen.Text = CType(q, Long).ToString(" #,##0")
        Me.ProgressBar1.Value = 85
        Dim dtSource As IEnumerable(Of DataRow) = osqlGlobal.dt.AsEnumerable
        Dim q2 = From r In dtSource _
            Group r By nummer = r.Field(Of String)("KL_Nummer"), name = r.Field(Of String)("KL_Naam"), artBtw = r.Field(Of Double)("ArtBtw") _
            Into g = Group Select New With {.Nummer = nummer, .Name = name, .artbtw = artBtw, .total = g.Sum(Function(r) _
                r.Field(Of Decimal)("Bestd_Waarde") * (1.0 - CDbl(If(r("art_korting") = False, 0.0, If(r("kkkorting") Is DBNull.Value, CDbl(r("KLkorting")), CDbl(r("KKKorting")))))))}
        qGlobal = From r In q2 Order By r.Nummer
        Dim q3 = From r In q2 Order By r.Name
        Dim i As Integer : i = -1
        While Me.grdFacturatie.Rows.Count > 0
            Me.grdFacturatie.Rows.Remove(Me.grdFacturatie.Rows(0))
        End While

        For Each r In q3
            i += 1
            Me.grdFacturatie.Rows.Add()
            Me.grdFacturatie(0, i).Value = r.Nummer
            Me.grdFacturatie(1, i).Value = r.Name
            Me.grdFacturatie(2, i).Value = r.artbtw
            Me.grdFacturatie(3, i).Value = r.total
        Next

        Me.ProgressBar1.Value = 100

        Me.ProgressBar1.Visible = False
        Me.btnOK.Enabled = True
        Me.btnOK.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim obzFact As New bzFactuur
        Dim nFactuurCount As Long = 0
        For Each r In qGlobal
            nFactuurCount += 1
        Next
        Dim oCollFactuurNr As New Collection
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Maximum = nFactuurCount * 2
        Me.ProgressBar1.Value = 0
        Dim nFactuur As Integer = 0 ' in fact this is the "previous" factuurNummer
        Dim cFirstFactuurNr As String = bzFactuur.cNextNr(CDate(Me.txtLeveringDat.Text))
        Dim nFirstFactuurNr As Integer = Val(Strings.Right(cFirstFactuurNr, 4))
        For Each r In Me.qGlobal
            ' Dim cFactNr As String = bzFactuur.cNextNr - does not seem to work properly
            Dim cFactNr As String = Strings.Left(cFirstFactuurNr, 2) & Strings.Right("0000" & nFirstFactuurNr + nFactuur, 4)
            bzFactuur.convKlant(r.Nummer, r.Artbtw * 100, Me.txtLeveringDat.Text, cFactNr)
            modLog.nlog("Converted " & cFactNr & " for " & r.Nummer, Me.Name)
            oCollFactuurNr.Add(cFactNr)
            nFactuur += 1
            Me.ProgressBar1.Value = nFactuur
        Next

        nFactuur = 0
        Using oExcel As New clsExcel
            For Each cFactnr As String In oCollFactuurNr
                obzFact.print(cFactnr, oExcel)
                nFactuur += 1
                Me.ProgressBar1.Value = nFactuurCount + nFactuur
                'Application.DoEvents()
                'Dim I As Long : For I = 1 To 10000 : Next
            Next
        End Using
        Dim cLastFactuurNr As String = bzFactuur.cLastNr
        MsgBox(nFactuurCount & " facturen (" & cFirstFactuurNr & "-" & cLastFactuurNr & ") werden gegenereerd en éénmaal afgedrukt.")
        Me.ProgressBar1.Visible = False
        Me.Close()
    End Sub
    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
        Dim osql As New sqlClass
        Me.txtLaatsteFactuur.Text = osql.ExecuteScalar("select Max(FactH_Nummer) from facth")
        Me.TxtCopijenFacturen.Text = "1"
        Me.TxtCopijenVervoerDoc.Text = "0"
        Me.TxtCopijenAfrekening.Text = "0"
        Me.CboSet.Text = Me.cboSet.items(0)
        Me.txtVan.Focus()
        Me.txtVan.SelectAll()
    End Sub
    Private Sub txtVan_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVan.Validating
        Dim osql As New sqlClass
        If Trim(Me.txtVan.Text) = "" And Me.lastKeycode <> Keys.Tab Then
            Exit Sub
        End If
        If osql.Execute("select * from facth where facth_Nummer = " & sqlClass.c(Me.txtVan.Text)) = 0 Then
            MsgBox("Dit nummer bestaat niet.")
            e.Cancel = True
            Exit Sub
        End If
        Me.txtTot.Text = Me.txtVan.Text
        Me.TxtAantal.Text = 1

    End Sub
    Private Sub txtTot_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTot.Validating
        Dim osql As New sqlClass
        If Trim(Me.txtTot.Text) = "" And Me.lastKeycode <> Keys.Tab Then
            Exit Sub
        End If
        If osql.Execute("select * from facth where facth_Nummer = " & sqlClass.c(Me.txtTot.Text)) = 0 Then
            MsgBox("Dit nummer bestaat niet.")
            e.Cancel = True
            Exit Sub
        End If
        Dim c As String = Me.txtTot.Text
        If Me.txtTot.Text < Me.txtVan.Text Then
            Me.txtTot.Text = Me.txtVan.Text
            Me.txtVan.Text = c
        End If
        Me.TxtAantal.Text = osql.ExecuteScalar("select count(facth_nummer) from facth where facth_nummer >= " & sqlClass.c(Me.txtVan.Text) & " and facth_nummer <= " & sqlClass.c(Me.txtTot.Text))
    End Sub
#Region "ParticulierenPurge"
    Shared Function laatstebestelling(klant As Long) As Date
        Dim sql As New sqlClass
        Dim p As New OleDb.OleDbParameter
        p.DbType = DbType.Int32
        p.Value = klant
        sql.parameterCollection.Add(p)
        Return sql.ExecuteScalar("qryFacturatieLaatsteDatum")
    End Function
    Shared Sub deletePDocument(id As Long)
        Dim conn As New OleDb.OleDbConnection(My.Settings.b040_beConnectionString) : conn.Open()
        Dim t As OleDb.OleDbTransaction = conn.BeginTransaction
        Dim sql As New sqlClass
        sql.conn = conn
        Dim p As New OleDb.OleDbParameter
        p.DbType = DbType.Int32
        p.Value = id
        sql.parameterCollection.Add(p)
        sql.ExecuteNonQuery("qryFacturatiePHDelete", t)
        Dim sqld As New sqlClass
        sqld.conn = conn
        Dim pd As New OleDb.OleDbParameter
        pd.DbType = DbType.Int32
        pd.Value = id
        sqld.parameterCollection.Add(pd)
        sqld.ExecuteNonQuery("qryFacturatiePDDelete", t)
        t.Commit()
        conn.Close()
    End Sub
    Public Shared Sub particulierenPurge(verwijderen As Boolean)
        Dim sql As New sqlClass
        Dim p As New OleDb.OleDbParameter
        p.DbType = DbType.Date
        p.Value = bzFactuur.dBatchFactuurDatum
        sql.parameterCollection.Add(p)
        sql.Execute("qryFacturatiePH")
        For Each dr As DataRow In sql.dt.Rows
            If bzBestel.isBestelling(dr("BestH_Docnr")) Then
                If verwijderen = False Then
                    If dr("kl_laatstebestellingBehouden") = True Then
                        If dr("besth_datlevering") = frmBatchFacturatie.laatstebestelling(dr("bestH_klant")) Then
                            Continue For
                        End If
                    End If
                End If
            End If
            frmBatchFacturatie.deletePDocument(dr("bestH_id"))
        Next
    End Sub
#End Region

    Private Sub BtnOKPge2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOKPge2.Click
        If Me.TxtCopijenFacturen.Text = "" Then Me.TxtCopijenFacturen.Text = "0"
        If Me.TxtCopijenVervoerDoc.Text = "" Then Me.TxtCopijenVervoerDoc.Text = "0"
        If Me.TxtCopijenAfrekening.Text = "" Then Me.TxtCopijenAfrekening.Text = "0"
        Dim osql As New sqlClass
        osql.Execute("select facth_nummer from facth where facth_nummer >= " & sqlClass.c(Me.txtVan.Text) & " and facth_nummer <= " & sqlClass.c(Me.txtTot.Text))
        ' see on note in form
        Using oExcel As New clsExcel
            For nCopy As Long = 1 To Me.TxtCopijenFacturen.Text
                For Each oRow As DataRow In osql.dt.Rows
                    If Me.cboSet.Text = "Voldaan" And bzFactuur.lIsVoldaan(oRow("facth_Nummer")) = False Then Continue For
                    If Me.cboSet.Text = "Niet Voldaan" And bzFactuur.lIsVoldaan(oRow("facth_Nummer")) = True Then Continue For
                    Dim obzFact As New bzFactuur
                    obzFact.print(oRow("facth_nummer"), oExcel)
                    If Val(Me.TxtCopijenVervoerDoc.Text) > 0 Then
                        Dim obzVervoerdocument As New bzVervoerDocument
                        obzVervoerdocument.printForFactuur(oRow("facth_nummer"), Me.TxtCopijenVervoerDoc.Text, oExcel)
                    End If
                    If Val(Me.TxtCopijenAfrekening.Text) > 0 Then
                        Dim obzAfrekening As New bzAfrekeningDocument
                        obzAfrekening.printForFactuur(oRow("facth_nummer"), Me.TxtCopijenAfrekening.Text, oExcel)
                    End If
                Next
            Next
        End Using
        If Me.chkLijnenVerwijderen.Checked = True Then
            bzBestel.purgeTransactions(bzFactuur.dBatchFactuurDatum())
        End If
        frmBatchFacturatie.particulierenPurge(Me.particulierenTransactiesVerwijderen.Checked)
        Me.TxtTeAnnuleren.Text = ""
    End Sub

    Private Sub TabPage3_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Enter
        Me.refreshPge3()
    End Sub
    Private Sub refreshPge3()
        Dim osql As New sqlClass
        Me.txtLF.Text = osql.ExecuteScalar("select Max(FactH_Nummer) from facth")
        osql.Execute("select kl_Nummer,kl_Naam,facth_TotBet from facth,klanten where kl_id = facth_klant and facth_Nummer = " & sqlClass.c(Me.txtLF.Text))
        Me.TxtKlant.Text = "[" & osql.dt(0)("kL_nummer") & "] " & osql.dt(0)("kL_naam")
        Me.TxtBedrag.Text = CType(osql.dt(0)("facth_TotBet"), Double).ToString("#,###.##")
        Me.TxtTeAnnuleren.Focus()
        Me.TxtTeAnnuleren.SelectAll()
    End Sub

    Private Sub TxtTeAnnuleren_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtTeAnnuleren.Validating
        Dim osql As New sqlClass
        If Trim(Me.TxtTeAnnuleren.Text) = "" And Me.lastKeycode <> Keys.Tab Then
            Exit Sub
        End If
        If osql.Execute("select * from facth,klanten where kl_id = facth_klant and facth_Nummer = " & sqlClass.c(Me.TxtTeAnnuleren.Text)) = 0 Then
            MsgBox("Dit nummer bestaat niet.")
            e.Cancel = True
            Exit Sub
        End If
        Dim dAnnuleren As Date = CType(osql.dt(0)("facth_datum"), Date)
        Me.txtKlant2.Text = "[" & osql.dt(0)("kL_nummer") & "] " & osql.dt(0)("kL_naam")
        Me.TxtBedrag2.Text = CType(osql.dt(0)("facth_TotBet"), Double).ToString("#,###.##")
        Dim dLaatste As Date = CType(osql.ExecuteScalar("select facth_datum from facth where facth_nummer = " & sqlClass.c(Me.txtLF.Text)), Date)
        If dLaatste <> dAnnuleren Then
            MsgBox("Datums komen niet overeen.")
            e.Cancel = True
        End If
    End Sub

    Private Sub btnOKAnnuleer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOKAnnuleer.Click
        Dim osql As New sqlClass
        osql.beginTransaction()
        Dim nFactPk As Long = osql.ExecuteScalar("select facth_id from facth where facth_nummer = " & sqlClass.c(Me.TxtTeAnnuleren.Text))
        osql.ExecuteNonQuery("delete from facth where facth_id = " & nFactPk)
        osql.ExecuteNonQuery("delete from factd where factd_facth = " & nFactPk)
        nLog("Deleted Factuur " & Me.TxtTeAnnuleren.Text, "facturatie")
        Dim oBest As New sqlClass
        oBest.Execute("select besth_id,besth_docnr from besth where besth_facth = " & nFactPk)
        For Each orow As DataRow In oBest.dt.Rows
            Dim nBestPk As Long = orow("Besth_id")
            osql.ExecuteNonQuery("delete from besth where besth_id = " & nBestPk)
            osql.ExecuteNonQuery("delete from bestd where bestd_besth = " & nBestPk)
            nLog("Deleted Bestelling " & orow("beSth_docnr"), "facturatie")
        Next
        If Me.TxtTeAnnuleren.Text <> Me.txtLF.Text Then
            osql.ExecuteNonQuery("update facth set facth_nummer = " & sqlClass.c(Me.TxtTeAnnuleren.Text) & " where facth_nummer = " & sqlClass.c(Me.txtLF.Text))
            nLog("Replaced factnr " & Me.txtLF.Text & " with " & Me.TxtTeAnnuleren.Text, "facturatie")
        End If
        osql.commitTransation()
        If Me.TxtTeAnnuleren.Text <> Me.txtLF.Text Then
            Dim obzfact As New bzFactuur
            obzfact.print(Me.TxtTeAnnuleren.Text)
            If Me.cboSet.Text = "Ja" Then
                Dim obzAfrekening As New bzAfrekeningDocument
                obzAfrekening.printForFactuur(Me.TxtTeAnnuleren.Text, Me.TxtCopijenFacturen.Text)
            End If
        End If
        Me.TxtTeAnnuleren.Text = "       "
        Me.txtKlant2.Text = ""
        Me.TxtBedrag2.Text = ""
        Me.refreshPge3()
    End Sub
    Private Sub cboSEt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.cboSet.Text <> "Alle" Then
            Me.TxtCopijenVervoerDoc.Text = "0"
            Me.TxtCopijenAfrekening.Text = "0"
        End If
    End Sub


End Class

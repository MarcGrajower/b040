Imports System.Globalization
''' <summary>
''' 6221 - Implemente Winkelproductie (aka Kleinblatt)
''' </summary>
Public Class frmProductiePlan
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim f = frmMain.MdiChildren.FirstOrDefault(Function(x) x.Name = "frmAutomatischBestellen")
        If (f Is Nothing) = False Then
            f.Close()
        End If
        Me.Close()
    End Sub
    Private Sub frmProductiePlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pc As New PrinterClass
        pc.fillCbo(Me.cboPrinters)
        Me.cboPrinters.Items.Add(PrinterClass.cPreview)
        Me.cboPrinters.Text = modB040Config.cDefaultPrinter()
        Me.TxtLeveringsDatum.Text = Format(bzBestel.dGetLeveringForBestellingDatum(Now), cDateFormat)
        Me.TxtKat1.Text = "1"
        Me.txtKat2.Text = "1"
        Me.TxtKat3.Text = ""
        Me.TxtKat4.Text = ""
        Me.TxtKat5.Text = "1"
        Me.TxtBijzonderArtikels.Text = "0"
        Me.TxtSnijdplan.Text = "1"
        Dim f = frmMain.MdiChildren.FirstOrDefault(Function(x) x.Name = "frmAutomatischBestellen")
        If (f Is Nothing) = False Then
            Dim totalWidth As Integer = f.Width + Me.Width + 2
            Me.Left = (My.Computer.Screen.Bounds.Width - totalWidth) / 2
            f.Left = Me.Left + Me.Width + 2
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.printProductiePlan(1, Me.TxtKat1.Text)
        Me.printProductiePlan(5, Me.TxtKat5.Text)
        Me.printProductiePlan(2, Me.txtKat2.Text)
        Me.printProductiePlan(3, Me.TxtKat3.Text)
        Me.printProductiePlan(4, Me.TxtKat4.Text)
        Me.printSnijdplan()
        Me.printUitzPlan()
    End Sub
    Private Sub SetAlternateBackground(RowsCount As Integer, o As clsExcel)
        '6222
        Dim firstRow As Integer
        firstRow = o.nRow("rngLijn1")
        Dim columnCount = o.nUsedRangeColumn()
        For i As Integer = firstRow + 1 To firstRow + RowsCount Step 2
            o.selectRange(i, 1, i, columnCount)
            o.SetBackgroundLightgreen()
        Next
    End Sub
    ''' <summary>
    ''' 6224 - adds groep and rank to source and sorts into target
    ''' </summary>
    ''' <param name="source">from data access</param>
    ''' <param name="target">sorted by GROEP,RANK,ART_OMSCHRIJVING</param>
    Private Sub processProductielijst(source As DataTable, ByRef target As DataView)
        Productielijst.Initialise()
        source.Columns.Add("Groep", GetType(Integer))
        source.Columns.Add("Rank", GetType(Integer))
        For Each r As DataRow In source.Rows
            Dim p As New Productielijst.Model
            p = Productielijst.GetModel(r("Art_Nr"))
            r("Groep") = p.Groep
            r("Rank") = p.Rank
        Next
        target = New DataView(source)
        target.Sort = "Groep Asc,Rank Asc,Art_Omschrijving Asc"
    End Sub
    Private Function GetMeel(artid As Integer) As Integer
        Dim oSql As New sqlClass
        Dim cSql As String
        cSql = "Select art_meel from artikel where art_id =  ?"
        oParameter = New OleDb.OleDbParameter("?", artid)
        oSql.AddParameter(artid, DbType.Int32)
        Dim meel = oSql.ExecuteScalar(cSql)
        If meel Is Nothing Then Return 0
        Return nNvlI(meel)
    End Function
    ''' <summary>
    ''' 6224 - reorder by Productielijst (deeg), rank.
    ''' </summary>
    ''' <param name="nKat"></param>
    ''' <param name="cCopies"></param>
    Private Sub printProductiePlan(ByVal nKat As Integer, ByVal cCopies As String)
        Dim nCopies As Integer = Val(cCopies)
        If nCopies = 0 Then Exit Sub
        Dim dLevering As Date = CDate(CDate(Me.TxtLeveringsDatum.Text))
        Dim oSql As New sqlClass
        Dim cSql As String
        cSql = "Select Kat_ProductiePlan,Art_Omschrijving,Art_Nr,sum(sumtour1) AS tour1,sum(sumTotaal) AS totaal,sum(sumVoorafgedrukt) as voorafgedrukt "
        cSql &= " from ( "
        cSql &= "Select Kat_ProductiePlan,Art_Omschrijving,Art_Nr,sum(iif(bestd_tour = '1',bestd_Hoev1,0)) AS sumtour1,sum(bestd_hoev1) AS sumtotaal, "
        cSql &= "sum(iif(bestd_voorafdrukken is not null and trim(bestd_voorafdrukken)<>'',bestd_hoev1,0)) as sumVoorafgedrukt "
        cSql &= "from Bestd,BestH,ARtikel,Kategorie "
        cSql &= "where bestd_besth = besth_id "
        cSql &= "and art_id = bestd_artikel "
        cSql &= "and Kat_id = art_Kategorie "
        cSql &= "and besth_DatLevering = " & sqlClass.cDateForJet(dLevering) & " "
        cSql &= "and art_Kategorie = " & nKat & " "
        cSql &= "group by Kat_ProductiePlan,Art_Omschrijving,Art_Nr "
        cSql &= " union all "
        cSql &= "Select Kat_ProductiePlan,Art_Omschrijving,Art_Nr,sum(iif(bestd_tour = '1',bestd_Hoev1,0)) AS sumtour1,sum(bestd_hoev1) AS sumtotaal, "
        cSql &= "sum(iif(bestd_voorafdrukken is not null and trim(bestd_voorafdrukken)<>'',bestd_hoev1,0)) as sumVoorafgedrukt "
        cSql &= "from pd Bestd,ph BestH,ARtikel,Kategorie "
        cSql &= "where bestd_besth = besth_id "
        cSql &= "and art_id = bestd_artikel "
        cSql &= "and Kat_id = art_Kategorie "
        cSql &= "and besth_DatLevering = " & sqlClass.cDateForJet(dLevering) & " "
        cSql &= "and art_Kategorie = " & nKat & " "
        cSql &= "group by Kat_ProductiePlan,Art_Omschrijving,Art_Nr "
        cSql &= " ) "
        cSql &= "group by Kat_ProductiePlan,Art_Omschrijving,Art_Nr "
        cSql &= "order by Kat_ProductiePlan,Art_Omschrijving,Art_nr "
        Dim _tally = oSql.Execute(cSql)
        If _tally = 0 Then
            Exit Sub
        End If
        Dim sorted As New DataView()
        processProductielijst(oSql.dt, sorted)
        Using o As New clsExcel
            o.openWorkbook(cXLSFolder() & "Productieplan.xls")
            o.setString("rngLeveringsDatum", Me.TxtLeveringsDatum.Text)
            o.setString("rngKat1", oSql.dt(0)("Kat_ProductiePlan"))
            Dim cRange As String = ""
            For Each r As DataRowView In sorted
                Dim totaal As Long = r("Totaal")
                Dim artid As Long = bzArtikel.GetArtId(r("art_nr"))
                Dim kleinblatt As Long = BzWinkelproductie.GetProductie(artid, dLevering)
                Dim klanten As Long = totaal - kleinblatt
                Dim meel As Integer = GetMeel(artid)
                Dim meelTotaal As Decimal = meel * totaal / 1000
                cRange &= Trim(r("Art_omschrijving")) & " [" & Trim(cNvl(r("Art_nr"))) & "]" & vbTab
                cRange &= cNvl(klanten) & vbTab
                cRange &= cNvl(kleinblatt) & vbTab
                cRange &= cNvl(totaal) & vbTab
                cRange &= $"{meel:n0}" & vbTab
                cRange &= $"{meelTotaal:n2}" & vbTab
                cRange &= vbCrLf
            Next
            o.pasteToRange("rngLijn1", cRange, 1)
            '6222
            SetAlternateBackground(_tally, o)
            o.cPrinter = Me.cboPrinters.Text
            o.nCopies = nCopies
            o.cXlsRoot = Format(dLevering, "yyMMdd") & "_PP_" & nKat
            o.printOut()
        End Using
    End Sub
#Region "snijdplan"
    Sub printSnijdplanPerType(parameterDatatable As DataTable, xl As clsExcel, klantType As String, nCopies As Long, dLevering As Date)
        Dim _tally As Long = parameterDatatable.Rows.Count
        If _tally > 0 Then
            xl.openWorkbook(cXLSFolder() & "Snijdplan.xls")
            xl.setString("rngLeveringsDatum", Me.TxtLeveringsDatum.Text)
            xl.setString("rngType", klantType)
            Dim cRange As String = ""
            For i As Integer = 1 To _tally
                cRange &= cNvl(parameterDatatable(i - 1)("Totaal")) & vbTab
                cRange &= Trim(parameterDatatable(i - 1)("Art_omschrijving")) & " [" & parameterDatatable(i - 1)("Art_Nr") & "]" & vbTab
                cRange &= cNvl(parameterDatatable(i - 1)("Tour1")) & vbTab
                cRange &= cNvl(parameterDatatable(i - 1)("Totaal")) - cNvl(parameterDatatable(i - 1)("Tour1")) & vbTab
                cRange &= vbCrLf
            Next
            xl.pasteToRange("rngLijn1", cRange, 1)
            xl.cPrinter = Me.cboPrinters.Text
            xl.nCopies = nCopies
            xl.cXlsRoot = Format(dLevering, "yyMMdd") & "_PS_" & klantType
            xl.printOut()
        End If
    End Sub
    Sub printSnijdplan()
        Dim nCopies As Integer = Val(Me.TxtSnijdplan.Text)
        If nCopies = 0 Then Exit Sub
        Dim dLevering As Date = CDate(Me.TxtLeveringsDatum.Text)
        Dim groothandel As DataTable
        Dim oSql As New sqlClass
        Dim cSql As String
        cSql = "select Art_Omschrijving,Art_Nr,sum(iif(bestd_tour = '1',bestd_Hoev1,0)) AS tour1,sum(bestd_hoev1) AS totaal "
        cSql &= "from Bestd,BestH,ARtikel "
        cSql &= "where bestd_besth = besth_id "
        cSql &= "and art_id = bestd_artikel "
        cSql &= "and besth_DatLevering = " & sqlClass.cDateForJet(dLevering) & " "
        cSql &= "and bestd_Snijden = true "
        cSql &= "group by Art_Omschrijving,Art_Nr "
        cSql &= "order by Art_Omschrijving,Art_nr "
        oSql.Execute(cSql)
        groothandel = oSql.dt.Copy
        cSql = "select Art_Omschrijving,Art_Nr,sum(iif(bestd_tour = '1',bestd_Hoev1,0)) AS tour1,sum(bestd_hoev1) AS totaal "
        cSql &= "from pD Bestd,pH BestH,ARtikel "
        cSql &= "where bestd_besth = besth_id "
        cSql &= "and art_id = bestd_artikel "
        cSql &= "and besth_DatLevering = " & sqlClass.cDateForJet(dLevering) & " "
        cSql &= "and bestd_Snijden = true "
        cSql &= "group by Art_Omschrijving,Art_Nr "
        cSql &= "order by Art_Omschrijving,Art_nr "
        oSql.Execute(cSql)
        particulieren = oSql.dt.Copy
        Using o As New clsExcel
            Me.printSnijdplanPerType(groothandel, o, "(Groothandel)", nCopies, dLevering)
            Me.printSnijdplanPerType(particulieren, o, "(Particulieren)", nCopies, dLevering)
        End Using
    End Sub
#End Region

    Sub printUitzPlan()
        ' Bijzonder
        Dim nCopies As Integer = Val(Me.TxtBijzonderArtikels.Text)
        If nCopies = 0 Then Exit Sub
        Dim dLevering As Date = CDate(Me.TxtLeveringsDatum.Text)
        Dim oSQL As New sqlClass : Dim cSql As String
        cSql = "Select * "
        cSql &= "from Bestd,BestH,Artikel,Klanten,Adres,Bediening,Eenheden "
        cSql &= "where bestH_id = bestD_BestH "
        cSql &= "and art_id = bestd_Artikel "
        cSql &= "and kl_id = besth_klant "
        cSql &= "and Adr_id = besth_Adres "
        cSql &= "and Bed_id = besth_Bediening "
        cSql &= "and Eenh_id = Art_Eenheid "
        cSql &= "and art_uitzonderlijk = " & True & " "
        cSql &= "and besth_datLevering = " & sqlClass.cDateForJet(dLevering)
        Dim _tally As Integer = oSQL.Execute(cSql)
        If _tally = 0 Then
            MsgBox("Er is geen Productie Plan voor bijzondere artikels")
            Exit Sub
        End If
        Using o As New clsExcel
            o.openWorkbook(cXLSFolder() & "UitzProductiePlan.xls")
            o.setString("rngLeveringsDatum", Me.TxtLeveringsDatum.Text)
            Dim nLinesPerBest As Integer = 8
            For i As Integer = 1 To _tally
                Dim r As DataRow = oSQL.dt(i - 1)

                Dim cRange As String = "Bestelling" & vbTab
                cRange &= CDate(oSQL.dt(i - 1)("Besth_datBest")).ToString(cDateWithWeekdayFormat, o.originalCulture) & " (" & oSQL.dt(i - 1)("Besth_DocNr") & ")" & vbCrLf
                cRange &= "Artikel" & vbTab
                cRange &= Trim(oSQL.dt(i - 1)("BestD_Omschrijving")) & " [" & Trim(oSQL.dt(i - 1)("Art_Nr")) & "]" & vbCrLf
                cRange &= "Klant" & vbTab
                cRange &= Trim(oSQL.dt(i - 1)("KL_naam")) & " [" & Trim(oSQL.dt(i - 1)("Kl_Nummer")) & "] " & oSQL.dt(i - 1)("Adr_Telefoon") & vbCrLf
                Dim cPorties As String = "" : Dim cPortiesPrompt As String = ""
                If nNvlD(r("bestd_Portie")) = 0 Then
                    cPortiesPrompt = "Gewicht"
                    cPorties = FormatNumber(r("bestd_Hoev1"), 0) & " " & r("eenh_HoevInvoer")
                Else
                    cPortiesPrompt = "Porties"
                    cPorties = FormatNumber(r("Bestd_Portie"), 0) & " van " & FormatNumber(r("Art_Portie"), 0) & " g (" & FormatNumber(r("bestd_Hoev1"), 0) & " g)"
                End If
                cRange &= cPortiesPrompt & vbTab
                cRange &= cPorties & vbCrLf
                cRange &= "Opschrift" & vbTab
                cRange &= r("BEstd_Opschrift") & vbCrLf
                cRange &= "Instructie" & vbTab
                cRange &= r("bestd_Boodschap") & vbCrLf
                cRange &= "Uur Levering" & vbTab
                cRange &= r("BestH_Uurlevering") & " " & IIf(r("Besth_KomtHalen"), "komt halen", "wordt geleverd") & vbCrLf
                cRange &= "Bediening" & vbTab
                cRange &= r("Bed_Naam")
                o.pasteToRange("rngLijn1", cRange, (i - 1) * nLinesPerBest)
                o.borderSingle()
            Next
            o.cPrinter = Me.cboPrinters.Text
            o.nCopies = 1
            o.cXlsRoot = Format(dLevering, "yyMMdd") & "_BPP_"
            o.printOut()
        End Using
    End Sub
End Class

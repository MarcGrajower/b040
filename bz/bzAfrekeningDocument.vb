Imports Microsoft.Office.Interop
Public Class bzAfrekeningDocument
    ' MG 02/apr/11
    Public cDocNr As String
    Public cTour As String = " "
    Public lReportByTour As Boolean = True
    Public nCopies As Integer = 1
    Public cPrinter As String = cDefaultPrinter()
    Dim obzBestel As New bzBestel
    Public Overloads Sub print()
        Using o As New clsExcel
            print(o)
        End Using
    End Sub
    Public Overloads Sub Print(o As clsExcel)
        Dim c As String : Dim i As Integer : Dim n As Integer : Dim n2 As Integer : Dim cRange As String
        Dim nInfo As Integer : Dim cInfo As String
        If Me.obzBestel.existsDocnr(Me.cDocNr) = False Then
            Throw New InvalidOperationException(Me.cDocNr & " bestaat niet in het Bestel Bestand")
        End If
        Dim nPK = Me.obzBestel.pk
        Dim dDocument = Me.obzBestel.oHeader("BestH_DatLevering")
        Dim cRngDatum As String = "Levering: " & modDutch.cDagInDeWeek(dDocument) & " " & Format(dDocument, "dd/MM/yy")
        Dim cRngRef As String = ""
        If Me.obzBestel.lIslevering Then
            cRngRef = "REF " & Right(Me.obzBestel.oHeader("besth_Docnr"), 4)
        Else
            cRngRef = "REF B"
        End If
        Dim coll As Collection = Me.obzBestel.collTours(Me.cTour, Me.lReportByTour)
        Dim detailTable As String = IIf(bzKlanten.isParticulierFromDocument(cDocNr), "PD", "BestD")
        Dim cLastTour As String = Bestel.Tour.cLastTour(nPK, detailTable)
        Dim oSql As New sqlClass : Dim _tally As Integer
        Dim cSQL As String
        Dim oPrice As New bzPrice : Dim nWI As Double : Dim nW As Double
        oPrice.klant = Me.obzBestel.oHeader("KL_Nummer")
        Dim lstBold As New List(Of Integer)
        For Each cTour As String In coll
            cSQL = "SELECT Artikel.Art_Nr"
            cSQL &= ", BestD.BestD_Omschrijving, BestD.BestD_Snijden, BestD.BestD_Tour, BestD.BestD_EenhPrijs"
            cSQL &= ",Eenh_hoevinvoer,Eenh_omschrijving"
            cSQL &= ", Sum(BestD.BestD_Hoev1) AS BestD_Hoev1, Sum(BestD.BestD_Waarde) AS BestD_Waarde,Sum(BestD.BestD_Hoev) AS BestD_Hoev"
            cSQL &= " FROM (" & detailTable & " BESTD INNER JOIN Artikel ON BestD.BestD_Artikel = Artikel.ARt_Id)"
            cSQL &= " INNER JOIN Eenheden ON Artikel.Art_Eenheid = Eenheden.Eenh_id"
            cSQL &= " WHERE(((BestD.BestD_BestH) = " & Me.obzBestel.pk & "))"
            If cTour <> " " Then cSQL &= " and bestd_tour = '" & cTour & "'"
            cSQL &= " GROUP BY Artikel.Art_Nr"
            cSQL &= ", BestD.BestD_Omschrijving, BestD.BestD_Snijden, BestD.BestD_Tour, BestD.BestD_EenhPrijs,Art_kategorie"
            cSQL &= ",Eenh_hoevinvoer,Eenh_omschrijving"
            cSQL &= " order by Art_Kategorie,BestD_Omschrijving,Art_Nr,BestD_Snijden"
            _tally = oSql.Execute(cSQL)
            If _tally = 0 Then Continue For
            Dim oWb = o.openWorkbook(cXLSFolder() & "Afrekening.xls")
            o.setString("rngDatum", cRngDatum)
            o.setString("rngRef", cRngRef)
            o.setString("rngKlantNr", "Klant Nummer : " & Trim(Me.obzBestel.oHeader("KL_Nummer")))
            o.setString("rngKlant", Trim(cNvl(Me.obzBestel.oHeader("KL_Titel"))) & " " & Me.obzBestel.oHeader("KL_Naam"))
            o.setString("rngAfrekening", "Afrekening " & IIf(cTour <> " ", " Tour " & cTour & "/" & cLastTour, ""))
            o.setString("rngAdres", Me.obzBestel.oHeader("Adr_Adres"))
            o.setString("rngGemeenteEnPostnummer", Trim(cNvl(Me.obzBestel.oHeader("Adr_PostNummer"))) & " " & Trim(cNvl(Me.obzBestel.oHeader("Adr_Gemeente")) & " " & Trim(cNvl(Me.obzBestel.oHeader("Adr_Land")))))
            o.setString("rngBTW", "BTW : " & Me.obzBestel.oHeader("KL_BTW"))
            cRange = ""
            lstBold.Clear()
            For i = 1 To _tally
                cRange &= i & vbTab
                cRange &= cNvl(oSql.dt(i - 1)("bestd_Tour")) & vbTab
                cRange &= nNvlD(oSql.dt(i - 1)("bestd_Hoev1")) & vbTab
                Me.checkBold(i, oSql.dt, lstBold)
                cRange &= cNvl(oSql.dt(i - 1)("Eenh_HoevInvoer")) & vbTab
                c = cNvl(oSql.dt(i - 1)("bestd_Omschrijving")) & IIf(oSql.dt(i - 1)("bestd_Snijden"), " (Gesneden)", "")
                cRange &= c & vbTab
                cRange &= vbCrLf
            Next
            n = o.nRow("rngLijn") : n2 = o.nUsedRangeColumn
            For i = 0 To lstBold.Count - 1
                o.selectRange(lstBold(i) + n, 1, lstBold(i) + n, n2)
                o.fmtBold()
            Next
            o.pasteToRange("rngLijn", cRange)
            nWI = 0 : nW = 0
            cRange = ""
            For i = 1 To _tally
                oPrice.artikel = oSql.dt(i - 1)("Art_Nr")
                oPrice.h = nNvlD(oSql.dt(i - 1)("bestd_Hoev1"))
                oPrice.compute(nNvlD(oSql.dt(i - 1)("BestD_Waarde")))
                nWI = nWI + oPrice.nTotaal : nW = nW + oPrice.nTeBetalen
                cRange &= IIf(oPrice.nKorting = 0, "Netto", "") & vbTab
                cRange &= cNvl(oSql.dt(i - 1)("BestD_EenhPrijs")) & vbTab
                cRange &= cNvl(oSql.dt(i - 1)("Eenh_omschrijving")) & vbTab
                cRange &= nNvlD(oSql.dt(i - 1)("BestD_Waarde")) & vbTab
                cRange &= vbCrLf
            Next
            o.pasteToRange("rngNetto", cRange)
            nWI = nRound(nWI, 2) : nW = nRound(nW, 2)
            nInfo = 0
            cInfo = Trim(cNvl(Me.obzBestel.oHeader("besth_info")))
            'cInfo &= IIf(cInfo = "", "", vbCrLf & vbCrLf)
            'cInfo &= "Betaling : " & IIf(obzBestel.oHeader("kl_voldaan"), " CONTANT.", " VIA OVERSCHRIJVING.")
            If cInfo <> "" Then
                cInfo = gen.cReformat(cInfo)
                nInfo = gen.mLines(cInfo)
                o.insertRows(o.nRow("rngLijn"), nInfo)
                o.setString("rnglijn", "Info:", 1)
                o.pasteToRange("rngTour", cInfo)
                n = o.nColumn("rngTour")
                n2 = o.nRow("rngTour")
                o.selectRange(n2 + 1, n, n2 + nInfo, n)
                o.fmtBold()
                o.borderSingle(n2 + nInfo)
            End If
            o.fmt2Dec("rngPrijsEur", _tally)
            o.fmt2Dec("rngWaarde", _tally)
            '
            Dim nLPP As Long = 38
            Dim nLinesTotal As Long = 4
            Dim nHeaderRows = o.nRow("rngLijn") '+ nInfo
            Dim nLastLine0 As Integer = o.nUsedrangeRow
            Dim nLinesReport As Long = nLastLine0 - nHeaderRows
            Dim nLastPage0 As Long = nLinesReport \ nLPP + 1
            Dim nLinesLastPage0 As Long = nLinesReport - (nLastPage0 - 1) * nLPP
            Dim nFirstTotalLine = nHeaderRows + nLastPage0 * nLPP - nLinesTotal + 1

            If nLinesLastPage0 > nLPP - nLinesTotal Then
                o.insertRows(nFirstTotalLine - 1, nLinesTotal)
                nFirstTotalLine += nLPP
            End If
            Dim nWhereRow As Integer = nFirstTotalLine
            Dim nWhereColumn As Integer = o.nUsedRangeColumn
            o.borderSingle(nWhereRow - 1)
            o.nameRange("rngPrompt", nWhereRow, nWhereColumn - 1)
            o.nameRange("rngTotaal", nWhereRow, nWhereColumn)
            Dim betalingColumn As Long = 2 ' see sheet (column A is used for margin.
            o.nameRange("rngBetaling", nWhereRow, betalingColumn)
            Dim cBTWClause As String = "Totaal BTW inbegrepen"
            If obzBestel.oHeader("KL_BTWTYPE") <> 1 Then
                cBTWClause = "Totaal BTW exclusief"
            End If
            o.setString("rngPrompt", cBTWClause)
            o.setString("rngTotaal", nWI)
            o.setString("rngPrompt", "Korting", 1)
            o.setString("rngTotaal", nWI - nW, 1)
            o.setString("rngPrompt", "Te betalen", 2)
            o.setString("rngTotaal", nW, 2)
            o.setString("rngBetaling", IIf(obzBestel.oHeader("kl_voldaan"), "Betaling : CONTANT", "Betaling : PER OVERSCHRIJVING"), 2)
            o.borderDouble()
            o.selectRange(nWhereRow, nWhereColumn - 1, nWhereRow + 2, nWhereColumn - 1)
            o.justifyRight()
            o.selectRange(nWhereRow + 2, nWhereColumn)
            o.fmtBold()
            o.selectRange(nWhereRow, nWhereColumn, nWhereRow + 2, nWhereColumn)
            o.fmt2Dec()

            o.fitLastPage(0)
            o.cPrinter = Me.cPrinter
            o.nCopies = Me.nCopies
            o.cXlsRoot = obzBestel.oHeader("besth_DocNr") & "_A" & Trim(cTour)
            o.printOut()
        Next
    End Sub
    Sub checkBold(ByVal i As Integer, ByVal dt As DataTable, ByVal lst As List(Of Integer))
        If Me.obzBestel.oHeader("BestH_StToegepast") = False Then Exit Sub
        If nNvlD(dt(i - 1)("BestD_Hoev")) <> nNvlD(dt(i - 1)("BestD_Hoev1")) Then lst.Add(i)
    End Sub
    Overloads Sub printForFactuur(ByVal cFactuur As String, ByVal nCopies As Long, Optional oExcel As clsExcel = Nothing)
        Dim oSql As New sqlClass
        Dim cSql As String
        Me.nCopies = nCopies
        cSql = "select BestH_Docnr from bestH,factH where besth_facth = facth_id and facth_nummer = " & sqlClass.c(cFactuur) & " order by besth_docnr"
        oSql.Execute(cSql)
        For Each orow As DataRow In oSql.dt.Rows
            Me.cDocNr = orow("BestH_Docnr")
            If oExcel Is Nothing Then
                Me.print()
            Else
                Me.print(oExcel)
            End If
        Next
    End Sub
    Overloads Sub printForFactuur(ByVal cFactuur As String, ByVal cCopies As String, Optional oExcel As clsExcel = Nothing)
        Me.printForFactuur(cFactuur, CType(Val(cCopies), Long), oExcel)
    End Sub
End Class

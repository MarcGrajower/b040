
Public Class bzUitzonderlijkAfrekening
    Function getDataTables(document As String) As String
        Return IIf(bzKlanten.isParticulierFromDocument(document), "pH,pD", "bestH,bestD")
    End Function

    Function getSql(document As String, tour As String) As String
        Dim cSql As String = "select * "
        cSql &= "from " & getDataTables(document) & ",Klanten,adres,artikel "
        cSql &= "where bestd_besth = besth_id "
        cSql &= "and Kl_id = besth_Klant "
        cSql &= "and adr_id = besth_Adres "
        cSql &= "and art_id = bestd_artikel "
        cSql &= "and besth_docnr = " & sqlClass.c(document) & " "
        If tour <> "All" Then
            cSql &= "and bestd_tour = " & sqlClass.c(tour) & " "
        End If
        Return cSql
    End Function
#Region "makeHeader"
    Function format_date(d As Date) As String
        Dim c As String = modDutch.cDagInDeWeek(d)
        Return c & " " & Format(d, "dd-MM-yyyy")
    End Function
    Function format_postnummer_adres(postnummer, gemeente)
        postnummer = Trim(postnummer)
        If postnummer = "" Then
            Return gemeente
        End If
        Return postnummer & " " & gemeente
    End Function
    Sub makeHeader(r1 As DataRow, xl As clsExcel)
        xl.setString("B2", r1("KL_Naam"))
        xl.setString("F5", IIf(r1("besth_komthalen"), "", "STUREN"))
        xl.setString("B3", "Klant " & r1("KL_Nummer"))
        xl.setString("E3", "Tel: " & Trim(cNvl(r1("Adr_Telefoon"))))
        xl.setString("B4", cNvl(r1("adr_adres")))
        xl.setString("B5", Me.format_postnummer_adres(cNvl(r1("adr_postnummer")), cNvl(r1("adr_gemeente"))))
        xl.setString("F8", cNvl(r1("bestd_tour")))
        xl.setString("B9", Me.format_date(r1("besth_datlevering")))
    End Sub
#End Region
    Sub computeTotals(ByRef totaal As Double, ByRef teBetalen As Double, dt As DataTable)
        totaal = 0
        teBetalen = 0
        Dim o As New bzPrice
        o.klant = bzKlanten.cNummer(dt(0)("bestH_klant"))
        For Each r As DataRow In dt.Rows
            o.artikel = bzArtikel.cArt_nr(r("bestd_artikel"))
            o.h = r("bestd_hoev1")
            o.compute(r("bestd_waarde"))
            totaal += o.nTotaal
            teBetalen += o.nTeBetalen
        Next
    End Sub
    Sub addRows(addedLines, xl)
        Dim currentRow As Long = xl.oApp.activecell.row
        For addedrow As Long = 1 To addedLines
            xl.oApp.ActiveCell.EntireRow.Insert()
            ' rows are created in reverse order
            If addedrow = 1 Then
                ' we don't want the merg to happen in the Totals row.
                Continue For
            End If
            Dim row As Integer = currentRow
            xl.oApp.range("C" & row & ":E" & row).select()
            xl.oApp.selection.merge()
            xl.oApp.selection.horizontalalignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xl.oApp.selection.verticalalignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop
        Next
    End Sub
    Function getSnijden(r As DataRow) As String
        If r("Art_Snijden") = False Then
            Return ""
        End If
        Return IIf(r("BestD_Snijden"), " [SN]", "")
    End Function
    Sub makeDetail(xl As clsExcel, l As Long, r As DataRow)
        xl.setNum("B" & l + 12, r("bestd_Hoev1"))
        xl.setString("C" & l + 12, IIf(bzEenheden.isGewicht(r("Art_Eenheid")), "g ", "") & r("Bestd_omschrijving") & getSnijden(r))
        xl.setNum("F" & l + 12, r("BestD_EenhPrijs"))
        xl.setNum("G" & l + 12, r("Bestd_waarde"))
    End Sub
    Sub formatAsTebetalenLine(currentline As Long, xl As clsExcel, tebetalenClause As String)
        xl.oApp.Range("B" & currentline & ":G" & currentline).Select()
        xl.formatSelectionAsTotal()
        xl.oApp.Selection.font.bold = True
        xl.formatRangeRightJustify("F" & currentline)
        xl.setString("F" & currentline, tebetalenClause)
    End Sub
 
    Public Sub print(document As String, xl As clsExcel, Optional tour As String = "All")
        xl.openWorkbook(cXLSFolder() & "UitzonderlijkAfrekening.xls")
        Dim osql As New sqlClass
        Dim tally As Integer = osql.Execute(getSql(document, tour))
        If tally = 0 Then Exit Sub
        makeHeader(osql.dt.Rows(0), xl)
        xl.oApp.Range("a14").Select()
        Dim totaalWaarde As Double = 0
        Dim totaalTebetalen As Double = 0
        Me.computeTotals(totaalWaarde, totaalTebetalen, osql.dt)
        Dim addedLines As Long = tally + IIf((totaalWaarde = totaalTebetalen), 0, 2)
        addRows(addedLines, xl)
        For l As Long = 1 To tally
            Dim r As DataRow = osql.dt.Rows(l - 1)
            makeDetail(xl, l, r)
        Next
        Dim teBetalenClause As String = "Te betalen " & IIf(osql.dt(0)("kl_BTWType") <> 1, "(Ex BTW) ", "") & ": "
        Dim rangeTotaal As String = "G" & tally + 12 + 1
        xl.setNum(rangeTotaal, totaalWaarde)
        If totaalWaarde = totaalTebetalen Then
            formatAsTebetalenLine(tally + 12 + 1, xl, teBetalenClause)
        Else
            Dim currentLine = tally + 12 + 1
            xl.oApp.Range("B" & currentLine & ":G" & currentLine).Select()
            xl.formatSelectionLineTop()
            xl.setNum("G" & tally + 12 + 2, totaalTebetalen - totaalWaarde)
            xl.setString("F" & tally + 12 + 2, "Korting : ")
            xl.formatRangeRightJustify("F" & tally + 12 + 2)
            Dim rangeTotaalTebetalen As String = "G" & tally + 12 + 3
            xl.setNum(rangeTotaalTebetalen, totaalTebetalen)
            formatAsTebetalenLine(tally + 12 + 3, xl, teBetalenClause)
        End If
        xl.setString("B" & addedLines + 1 + 16, Trim(osql.dt.Rows(0)("besth_info")))
    End Sub
    Sub getTours(document As String, tours As Collection)
        tours.Clear()
        Dim sql As String = "select distinct bestd_tour from " & getDataTables(document)
        sql &= " where bestd_besth = besth_id "
        sql &= " and besth_docnr = " & sqlClass.c(document)
        Dim osql As New sqlClass
        osql.Execute(sql)
        For Each r As DataRow In osql.dt.Rows
            tours.Add(r("bestd_Tour"))
        Next
    End Sub
    Sub requestPrinting(Document As String, printPerTour As Boolean, tourToPrint As String, printer As String, xl As clsExcel)
        xl.cXlsRoot = "UitzonderlijkAfrekening"
        xl.cPrinter = printer
        xl.nCopies = 1
        If printPerTour = False Then
            print(Document, xl)
            xl.printOut()
            Return
        End If
        If Trim(tourToPrint) <> "" Then
            print(Document, xl, tourToPrint)
            xl.printOut()
            Return
        End If
        Dim tours As New Collection
        getTours(Document, tours)
        For Each tour As String In tours
            print(Document, xl, tour)
            xl.printOut()
        Next
    End Sub
End Class

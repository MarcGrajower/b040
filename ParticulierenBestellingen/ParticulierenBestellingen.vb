Public Class ParticulierenBestellingen
    Public copijen As Long
    Public datum As Date
    Public printer As String
    Sub getLijnen(ByRef dt As DataTable)
        Dim db As New sqlClass
        Dim sql As String = "Select Kat_ProductiePlan,Art_Omschrijving,Art_Nr,sum(iif(bestd_tour = '1',bestd_Hoev1,0)) AS tour1,sum(bestd_hoev1) AS totaal "
        sql &= "from pd Bestd,ph BestH,ARtikel,Kategorie "
        sql &= "where bestd_besth = besth_id "
        sql &= "and art_id = bestd_artikel "
        sql &= "and Kat_id = art_Kategorie "
        sql &= "and besth_klant <> ?"
        sql &= "and besth_DatLevering = " & sqlClass.cDateForJet(datum) & " "
        sql &= "group by Kat_ProductiePlan,Art_Omschrijving,Art_Nr "
        sql &= "order by Kat_ProductiePlan,Art_Omschrijving,Art_nr "
        db.AddParameter(BzWinkelproductie.klId, DbType.Int32)
        db.Execute(sql)
        dt = db.dt
    End Sub
    Sub moveToSheet(dt As DataTable, xl As clsExcel)
        Dim kat As String = "***"
        Dim cRange As String = ""
        For Each r In dt.Rows
            If kat = "***" Then
                kat = r("Kat_ProductiePlan")
            End If
            If kat <> r("Kat_ProductiePlan") Then
                cRange &= vbCrLf
                kat = r("Kat_ProductiePlan")
            End If
            cRange &= cNvl(r("Totaal")) & vbTab
            cRange &= Trim(r("Art_omschrijving")) & " [" & r("Art_Nr") & "]" & vbTab
            cRange &= cNvl(r("Tour1")) & vbTab
            cRange &= cNvl(r("Totaal")) - cNvl(r("Tour1")) & vbTab
            cRange &= vbCrLf
        Next
        xl.pasteToRange("rngLijn1", cRange, 1)
    End Sub
    Public Sub report()
        If copijen = 0 Then
            Return
        End If
        Using xl As New clsExcel
            xl.openWorkbook(cXLSFolder() & "ParticulierenBestellingenOverzicht.xls")
            xl.cPrinter = printer
            xl.nCopies = copijen
            xl.setString("rngLeveringsDatum", datum)
            Dim dt As New DataTable
            getLijnen(dt)
            moveToSheet(dt, xl)
            xl.cXlsRoot = "PBO_" & Format(datum, "yyMMdd")
            xl.printOut()
        End Using
    End Sub
    Shared Sub getDates(ByRef dates() As Date, ByRef nodates As Boolean)
        nodates = False
        Dim bestellingen As New sqlClass
        Dim sql As String = "select distinct bestH_datlevering from ph order by besth_datlevering"
        Dim dateCount As Long = bestellingen.Execute(sql)
        If dateCount = 0 Then
            nodates = True
            Return
        End If
        ReDim dates(dateCount)
        Dim i As Long = 0
        For Each r As DataRow In bestellingen.dt.Rows
            dates(i) = CDate(r("bestH_datLevering"))
            i += 1
        Next
    End Sub
End Class

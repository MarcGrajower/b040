Imports Microsoft.Office.Interop
Public Class bzVervoerDocument
    ' MG 02/apr/11
    Public cDocNr As String
    Public cTour As String = " "
    Public lReportByTour As Boolean = True
    Public nCopies As Integer = 1
    Public cPrinter As String = cDefaultPrinter()
    Dim obzBestel As New bzBestel
    Public Overloads Sub Print()
        Using o As New clsExcel
            Me.Print(o)
        End Using
    End Sub
    Public Overloads Sub Print(o As clsExcel)
        Dim c As String : Dim i As Integer : Dim n As Integer : Dim n2 As Integer : Dim cRange As String
        Dim lstBold As New List(Of Integer)
        Dim nInfo As Integer : Dim cInfo As String
        If Me.obzBestel.existsDocnr(Me.cDocNr) = False Then
            Throw New InvalidOperationException(Me.cDocNr & " bestaat niet in het Bestel Bestand")
        End If
        Dim nPK As Long = Me.obzBestel.pk
        Dim dDocument As Date = Me.obzBestel.oHeader("besth_DatLevering")
        Dim cRngDatum As String = "Datum: " & modDutch.cDagInDeWeek(dDocument) & " " & Format(dDocument, "dd/MM/yy")
        Dim cRngRef As String
        If Me.obzBestel.lIslevering Then
            cRngRef = "REF " & Right(Me.obzBestel.oHeader("besth_Docnr"), 4)
        Else
            cRngRef = "REF B"
        End If
        Dim coll As Collection = Me.obzBestel.collTours(Me.cTour, Me.lReportByTour)
        Dim detailTable As String = IIf(bzKlanten.isParticulierFromDocument(cDocNr), "PD", "BestD")
        Dim cLastTour As String = Bestel.Tour.cLastTour(nPK, detailTable)
        Dim oSql As New sqlClass : Dim _tally As Integer
        Dim cSQLGroup As String : Dim cSql As String

        For Each cTour As String In coll
            o.openWorkbook(cXLSFolder() & "Vervoer.xls")
            o.setString("rngDatum", cRngDatum)
            o.setString("rngRef", cRngRef)
            o.setString("rngKlantNr", "Klant Nummer : " & Trim(Me.obzBestel.oHeader("KL_Nummer")))
            o.setString("rngKlant", Trim(cNvl(Me.obzBestel.oHeader("KL_Titel"))) & " " & Me.obzBestel.oHeader("KL_Naam"))
            o.setString("rngVervoer", "Vervoer Document " & IIf(cTour <> " ", " Tour " & cTour & "/" & cLastTour, ""))
            o.setString("rngAdres", Me.obzBestel.oHeader("Adr_Adres"))
            o.setString("rngGemeenteEnPostnummer", Trim(cNvl(Me.obzBestel.oHeader("Adr_PostNummer"))) & " " & Trim(Me.obzBestel.oHeader("Adr_Gemeente")) & " " & Trim(cNvl(Me.obzBestel.oHeader("Adr_Land"))))
            o.setString("rngBTW", "BTW : " & Me.obzBestel.oHeader("KL_BTW"))
            cSQLGroup = "bestd_Tour,Eenh_HoevInvoer,bestd_Omschrijving,Art_Nr,bestd_snijden,Art_Kategorie"
            cSql = "select " & cSQLGroup & ",sum(bestd_Hoev1) as bestd_Hoev1,Sum(BestD.BestD_Hoev) AS BestD_Hoev"
            cSql &= " from " & detailTable & " BESTD,Artikel,Eenheden"
            cSql &= " where Art_Eenheid = Eenh_id and BestD_Artikel = ARt_Id "
            cSql &= " and bestd_besth = " & Me.obzBestel.pk
            If cTour <> " " Then cSql &= " and bestd_tour = '" & cTour & "'"
            cSql &= " group by " & cSQLGroup
            cSql &= " order by Art_Kategorie,BestD_Omschrijving,Art_Nr,BestD_Snijden"
            _tally = oSql.Execute(cSql)
            If _tally = 0 Then Continue For

            cRange = ""
            For i = 1 To _tally
                cRange &= i & vbTab
                cRange &= cNvl(oSql.dt(i - 1)("bestd_Tour")) & vbTab
                cRange &= nNvlD(oSql.dt(i - 1)("bestd_Hoev1")) & vbTab
                cRange &= cNvl(oSql.dt(i - 1)("Eenh_HoevInvoer")) & vbTab
                c = cNvl(oSql.dt(i - 1)("bestd_Omschrijving")) & IIf(oSql.dt(i - 1)("bestd_Snijden"), " (Snijden)", "")
                cRange &= c & vbTab
                cRange &= vbCrLf
                Me.checkBold(i, oSql.dt, lstBold)
            Next
            n = o.nRow("rngLijn") : n2 = o.nUsedRangeColumn
            For i = 0 To lstBold.Count - 1
                o.selectRange(lstBold(i) + n, 1, lstBold(i) + n, n2)
                o.fmtBold()
            Next
            o.pasteToRange("rngLijn", cRange)
            o.borderSingle()
            nInfo = 0
            cInfo = cNvl(Me.obzBestel.oHeader("besth_info"))
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
            o.cPrinter = Me.cPrinter
            o.nCopies = Me.nCopies
            o.cXlsRoot = obzBestel.oHeader("besth_DocNr") & "_V" & Trim(cTour)
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
                Me.Print()
            Else
                Me.Print(oExcel)
            End If
        Next
    End Sub
    Overloads Sub printForFactuur(ByVal cFactuur As String, ByVal cCopies As String, Optional oExcel As clsExcel = Nothing)
        Me.printForFactuur(cFactuur, CType(Val(cCopies), Long))
    End Sub
End Class


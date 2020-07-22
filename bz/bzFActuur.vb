Public Class bzFactuur
    ' MG 11/mei/11
    Public cPrinter As String = cDefaultPrinter()
    Public nCopies As Integer = 1
    Public oAdres As New sqlClass
    Public Shared Function cNextNr(facturatieDatum As Date) As String
        Dim n As Integer
        Dim cLast As String = bzFactuur.cLastNr
        Dim nYear As Integer = Left(cLast, 2) + 2000
        Dim nThisYear As Integer = Year(facturatieDatum)
        If nThisYear > nYear Then
            n = 1
        Else
            n = Val(Right(cLast, 4)) + 1
        End If
        Return Right("00" & nThisYear, 2) & Right("0000" & n, 4)
    End Function
    Public Shared Function cLastNr() As String
        Dim o As New sqlClass
        Dim c As String = "select max(FactH_Nummer) from FactH"
        Return o.ExecuteScalar(c)
    End Function
    Public Shared Sub convBestel(ByVal cBestel As String, ByVal cFactNr As String, ByVal nBTW As Double)
        Dim n As Double
        Dim oSql As New sqlClass
        oSql.Execute("select * from besth where besth_docnr = '" & cBestel & "'")
        Dim nPKBestH = oSql.dt(0)("BestH_Id")
        Dim nBestH_Klant = oSql.dt(0)("BestH_Klant")
        Dim dBestH_DatLevering = oSql.dt(0)("BestH_DatLevering")
        Dim nPKFactH As Long = nNvlI(oSql.dt(0)("BestH_FactH"))
        Dim c As String
        c = "select Art_Nr,Bestd_Artikel,Bestd_Snijden,sum(Bestd_Hoev1) as Hoev,sum(BestD_Waarde) as Waarde"
        c &= " from bestd,artikel"
        c &= " where Art_id = Bestd_Artikel"
        c &= " and bestd_besth = " & nPKBestH
        c &= " and art_btw = " & sqlClass.cDoubleForjet(nBTW)
        c &= " group by Art_Nr,Bestd_Artikel,Bestd_Snijden"
        Dim oBestD As New sqlClass : oBestD.Execute(c)
        Dim oConn As New OleDb.OleDbConnection(My.Settings.b040_beConnectionString) : oConn.Open()
        Dim oT As OleDb.OleDbTransaction = oConn.BeginTransaction
        oSql.conn = oConn
        If nPKFactH <> 0 Then
            oSql.ExecuteNonQuery("delete from FactH where FactH_id = " & nPKFactH, oT)
            oSql.ExecuteNonQuery("delete from FactD where FactD_FactH = " & nPKFactH, oT)
        End If
        c = "insert into FactH (FactH_Nummer,FactH_Datum,FactH_KN,FactH_BTW,FactH_Klant,FactH_TotBet) values ("
        c &= "'" & cFactNr & "',"
        c &= "#" & CType(dBestH_DatLevering, Date).ToString("MM/dd/yyyy") & "#,"
        c &= False & ","
        c &= nBTW & ","
        c &= nBestH_Klant & ","
        c &= 0 & ")"
        oSql.ExecuteNonQuery(c, oT)
        nPKFactH = oSql.RetrieveNewKey(oT)
        Dim oP As New bzPrice : Dim nTotKorting As Double = 0 : Dim nKorting As Double : Dim nTotWaarde As Double = 0
        Dim oFactD As New sqlClass : oFactD.conn = oConn
        For Each row As DataRow In oBestD.dt.Rows
            If row("Waarde") <> 0 Then
                c = "insert into FactD (FactD_FactH,FactD_Artikel,FactD_Gesn,FactD_Hoev,FactD_Prijs,FactD_Waarde,FactD_Korting) values ("
                c &= nPKFactH & ","
                c &= row("BestD_Artikel") & ","
                c &= row("Bestd_Snijden") & ","
                oP.artikel = row("Art_nr")
                oP.klant = bzKlanten.cNummer(nBestH_Klant)
                Dim artikelPrijs = oP.oArt.Record.Art_Prijs
                Dim exponent = 10 ^ bzArtikel.nArt_PrijsExponent(oP.oArt.Record.ARt_Id)
                Dim hoev As Decimal = row("Hoev")
                Dim waarde = artikelPrijs * hoev * exponent
                ' Dim gemiddeldePrijs = gen.nRound(bzFactuur.nAveragePrice(row("BEstd_Artikel"), hoev, waarde), 2)

                c &= hoev.ToString(Globalization.CultureInfo.InvariantCulture) & ","
                c &= artikelPrijs.ToString(Globalization.CultureInfo.InvariantCulture) & ","
                c &= waarde.ToString(Globalization.CultureInfo.InvariantCulture) & ","
                oP.artikel = row("Art_nr")
                oP.klant = bzKlanten.cNummer(nBestH_Klant)
                oP.compute()
                nKorting = gen.nRound(waarde * oP.nKortingPct, 2)
                c &= nKorting.ToString(Globalization.CultureInfo.InvariantCulture) & ")"
                oFactD.ExecuteNonQuery(c, oT)
                nTotKorting += nKorting : nTotWaarde += waarde
            End If
        Next
        n = nTotWaarde - nTotKorting
        c = "update FactH "
        c &= "set facth_TotBet = " & n.ToString(Globalization.CultureInfo.InvariantCulture) & " "
        c &= ",facth_KN = " & (n < 0) & " "
        c &= "where facth_id = " & nPKFactH
        oSql.ExecuteNonQuery(c, oT)
        c = "update BestH set BestH_FactH = " & nPKFactH & ", besth_Factuur = '1' where besth_id = " & nPKBestH
        oSql.ExecuteNonQuery(c, oT)
        oT.Commit()
    End Sub
    Overloads Sub print(cFactNr As String, Optional nCopies As Long = 0)
        Using o As New clsExcel
            Me.print(cFactNr, o, nCopies)
        End Using
    End Sub
    Overloads Sub print(cFactNr As String, o As clsExcel, Optional nCopies As Long = 0)
        If nCopies <> 0 Then Me.nCopies = nCopies
        If Me.nCopies = 0 Then Exit Sub
        Dim lError As Boolean = True
        Dim oFactH As New sqlClass
        Dim nFActHpk As Long
        Dim nAttempt As Integer = 3
        Do
            lError = False
            Try
                oFactH.Execute("select * from FactH where facth_Nummer = '" & cFactnr & "'")
                nFActHpk = oFactH.dt(0)("facth_id")
            Catch
                nLog("Failure oFactH.execute", "bzFactuur.print")
                lError = True
                nAttempt -= 1
            End Try
        Loop While lError = True AndAlso nAttempt > 0
        If lError Then
            Throw New InvalidOperationException("Failed to print " & cFactnr & " after 3 attempts")
            Exit Sub
        End If
        Dim lKN As Boolean = oFactH.dt(0)("facth_KN")
        Dim cDatum = CType(oFactH.dt(0)("FactH_Datum"), Date).ToString("dd/MM/yy")
        Dim cKlantNr = bzKlanten.cNummer(oFactH.dt(0)("Facth_Klant"))
        Dim oKlant As New bzKlanten : oKlant.kl_nummer = cKlantNr
        Me.loadFActAdres(oKlant.record.KL_ID)
        Dim cBTW As String = "BTW: " & oKlant.record.KL_BTW
        Dim cTel As String = "Telefoon: " & oKlant.Adr_Telefoon
        Dim cNaam As String = oKlant.record.KL_Naam
        Dim oFactD As New sqlClass
        Dim c As String
        c = "select factd.*,Eenh_HoevInvoer,Eenh_Omschrijving,Art_Omschrijving from FactD,Eenheden,Artikel "
        c &= "where Art_id = Factd_Artikel "
        c &= "and Eenh_id = Art_Eenheid "
        c &= "and Factd_FactH = " & nFActHpk
        Dim nFactD = oFactD.Execute(c)
        Dim cRange As String = "" : Dim nFactTotal As Double = 0 : Dim nFactKorting As Double = 0
        Dim oWB = o.openWorkbook(cXLSFolder() & "Factuur.xls")
        Dim cRighttitle As String = o.oApp.Range("rngRighttitle").Value
        o.setString("rngRighttitle", Replace(cRighttitle, "<R>", Trim(cKlantNr) & "/" & Trim(cFactNr)))
        Dim cRightfooter As String = o.oApp.ActiveSheet.pagesetup.rightfooter
        o.oApp.ActiveSheet.pagesetup.rightfooter = Replace(cRightfooter, "<F>", Trim(cFactNr))
        o.setString("rngNummer", IIf(lKN, "Crediet nota nr : ", "Factuur nr : ") & cFactnr)
        o.setString("rngDatum", cDatum)
        o.setString("rngKlantNr", "Klant Nr: " & cKlantNr)
        o.setString("rngBTW", cBTW)
        o.setString("rngTel", cTel)
        o.setString("rngAdres", cNaam)
        o.setString("rngAdres", cNvl(Me.oAdres.dt(0)("Adr_Adres")), 1)
        o.setString("rngAdres", cNvl(Me.oAdres.dt(0)("Adr_PostNummer")) & " " & cNvl(Me.oAdres.dt(0)("Adr_Gemeente")), 2)
        o.setString("rngAdres", cNvl(Me.oAdres.dt(0)("Adr_Land")), 3)
        For i As Integer = 1 To nFactD
            cRange &= i & vbTab
            Dim lHoevZero As Boolean = cNvl(oFactD.dt(i - 1)("factd_Hoev")) = 0
            If lHoevZero = False Then
                cRange &= cNvl(oFactD.dt(i - 1)("factd_Hoev")) * IIf(lKN, -1, 1) & vbTab
                cRange &= cNvl(oFactD.dt(i - 1)("Eenh_HoevInvoer")) & vbTab
            Else
                cRange &= vbTab
                cRange &= vbTab
            End If
            c = cNvl(oFactD.dt(i - 1)("art_Omschrijving"))
            cRange &= c & vbTab
            cRange &= vbTab
            cRange &= vbTab
            If lHoevZero = False Then
                cRange &= nNvlD(oFactD.dt(i - 1)("FactD_Prijs")) & vbTab
                cRange &= cNvl(oFactD.dt(i - 1)("Eenh_omschrijving")) & vbTab
            Else
                cRange &= vbTab
                cRange &= vbTab
            End If
            cRange &= nNvlD(oFactD.dt(i - 1)("FactD_Waarde")) * IIf(lKN, -1, 1) & vbTab
            cRange &= vbCrLf
            nFactTotal += nNvlD(oFactD.dt(i - 1)("FactD_Waarde")) * IIf(lKN, -1, 1)
            nFactKorting += nNvlD(oFactD.dt(i - 1)("FactD_Korting")) * IIf(lKN, -1, 1)
        Next
        ' check out pagination.xslx
        '	Factuurlijnen	48	49	50	51	52	99	100	101	102	103	150	151	152	153	154	201	202	203	204	205
        '	LPP	51	51	51	51	51	51	51	51	51	51	51	51	51	51	51	51	51	51	51	51
        '	LinesTotal	3	3	3	3	3	3	3	3	3	3	3	3	3	3	3	3	3	3	3	3
        '	nHeaderRows	11	11	11	11	11	11	11	11	11	11	11	11	11	11	11	11	11	11	11	11
        '	Lastline0	59	60	61	62	63	110	111	112	113	114	161	162	163	164	165	212	213	214	215	216
        '	LinesReport	48	49	50	51	52	99	100	101	102	103	150	151	152	153	154	201	202	203	204	205
        '	LastPage0	1	1	1	1	2	2	2	2	2	3	3	3	3	3	4	4	4	4	4	5
        '	nLinesonlastpage0	48	49	50	51	1	48	49	50	51	1	48	49	50	51	1	48	49	50	51	1
        '	nFirstTotalLine	60	60	60	60	111	111	111	111	111	162	162	162	162	162	213	213	213	213	213	264
        '	Insert liens	No	YES	YES	YES	No	No	YES	YES	YES	No	No	YES	YES	YES	No	No	YES	YES	YES	No

        o.pasteToRange("rngLijn", cRange)
        Dim nLPP As Long = 51   ' actual lines per page (excluding the header, header is counted only once)
        Dim nLinesTotal As Long = 3
        Dim nHeaderRows = o.nRow("rngLijn")
        Dim nLastLine0 As Integer = o.nUsedrangeRow
        Dim nLinesReport As Long = nLastLine0 - nHeaderRows
        Dim nLastPage0 As Long = (nLinesReport - 1) \ nLPP + 1
        Dim nLinesLastPage0 As Long = nLinesReport - (nLastPage0 - 1) * nLPP
        Dim nFirstTotalLine = nHeaderRows + nLastPage0 * nLPP - nLinesTotal + 1

        If nLinesLastPage0 > nLPP - nLinesTotal Then
            o.insertRows(nFirstTotalLine - 1, nLinesTotal)
            nFirstTotalLine += nLPP
        End If
        '--
        Dim nTebet As Double = nFactTotal - nFactKorting
        Dim nBTWRate As Double = oFactH.dt(0)("FActH_BTW") / 100
        Dim nFActBTW As Double = gen.nRoundup((nTebet / (1 + nBTWRate)) * nBTWRate, 2)
        Dim nBelastbaar As Double = nTebet - nFActBTW
        Dim cBTW1 As String : Dim cBTW2 As String = ""
        cBTW = bzBTWType.cOmschrijving(oKlant.record.KL_BTWType)
        Select Case cBTW
            Case "In EU"
                cBTW1 = "Commerciële Korting " & nFactKorting.ToString("#,##0.00 EUR", o.originalCulture)
                cBTW2 = "Vrij van BTW " & oFactH.dt(0)("FactH_BTW") & "% (Europese Unie) " & nFActBTW.ToString("#,##0.00 EUR", o.originalCulture)
                nFactKorting += nFActBTW
                nTebet -= nFActBTW
            Case "Buiten EU"
                cBTW1 = "Commerciële Korting " & nFactKorting.ToString("#,##0.00 EUR", o.originalCulture)
                cBTW2 = "Vrij van BTW " & oFactH.dt(0)("FactH_BTW") & "% (Export) " & nFActBTW.ToString("#,##0.00 EUR", o.originalCulture)
                nFactKorting += nFActBTW
                nTebet -= nFActBTW
            Case "Vrijstelling"
                cBTW1 = "Commerciële Korting " & nFactKorting.ToString("#,##0.00 EUR", o.originalCulture)
                cBTW2 = "Vrij van BTW " & oFactH.dt(0)("FactH_BTW") & "% (Vrijstelling)" & nFActBTW.ToString("#,##0.00 EUR", o.originalCulture)
                nFactKorting += nFActBTW
                nTebet -= nFActBTW
            Case Else
                cBTW1 = "Belastbaar " & nBelastbaar.ToString("#,##0.00 EUR", o.originalCulture)
                cBTW2 = "BTW " & oFactH.dt(0)("FactH_BTW") & "% " & nFActBTW.ToString("#,##0.00 EUR", o.originalCulture)
        End Select

        o.fmt2Dec("rngPrijs", nFactD)
        o.fmt2Dec("rngWaarde", nFactD)
        o.borderSingle(nFirstTotalLine - 1)

        Dim nCol As Integer = o.nColumn("rngLijn") : Dim nRow As Integer = nFirstTotalLine
        '       o.selectRange(nRow + 1, nCol, nRow + nFactD, nCol)
        '      o.selFmtAsLinenr()
        nRow = o.nUsedrangeRow + 1 : nCol = o.nUsedRangeColumn
        o.nameRange("rngPrompt", nRow, nCol - 1)
        o.setString("rngPrompt", "Tot. BTW Incl")
        o.setString("rngPrompt", "Korting", 1)
        o.nameRange("rngTotal", nRow, nCol)
        o.setString("rngTotal", nFactTotal)
        o.setString("rngTotal", -nFactKorting, 1)
        o.setString("rngPrompt", IIf(lKN, "Terug te betalen", "Te Betalen"), 2)
        o.setString("rngTotal", nFactTotal - nFactKorting, 2)
        o.selectRange(nRow, nCol - 1, nRow + 2, nCol - 1)
        o.justifyRight()
        o.selectRange(nRow, nCol, nRow + 2, nCol)
        o.fmt2Dec()
        o.fmtBold()
        o.borderDouble()
        o.nameRange("rngBEF", nRow + 2, nCol - 5)
        o.setString("rngBEF", IIf(oKlant.record.KL_Voldaan, "VOLDAAN", ""))
        o.selectRange("rngBEF")
        o.fmtBold()
        o.nameRange("rngBTW1", nRow, o.nColumn("rngOmschrijving"))
        o.setString("rngBTW1", cBTW1)
        o.selectRange("rngBTW1")
        o.justifyRight()
        o.setString("rngBTW1", cBTW2, 1)
        o.selectRange("rngBTW1", 1)
        o.justifyRight()
        If lKN Then
            o.selectRange("rngPrompt", 2) : o.fmtRed() : o.fmtBold()
            o.selectRange("rngNummer") : o.fmtRed() : o.fmtBold()
            o.selectRange("rngTotal", 2) : o.fmtRed() : o.fmtBold()
        End If
        ' o.fitLastPage(4)
        o.cPrinter = Me.cPrinter
        o.nCopies = Me.nCopies
        o.cXlsRoot = "Fact" & cFactnr
        o.saveAs()
        o.printOut()
        nLog("Printed " & o.cXlsRoot & cKlantNr & " " & nTebet.ToString("#.###,## " & "EUR"), "bzFactuur.print")
    End Sub
    Sub loadFActAdres(ByVal nKlant)
        Me.oAdres.Execute("select * from adres where adr_klant = " & nKlant & " and Adr_Facturatie = true")
    End Sub
    Public Shared Function cDocnr(ByVal nID As Long) As String
        Dim oSql As New sqlClass : Return oSql.ExecuteScalar("select facth_Nummer from facth where facth_id = " & nID)
    End Function
    Public Shared Sub convKlant(ByVal cKlNr As String, ByVal nBtw As Double, ByVal cFactDate As String, ByVal cFactnr As String)
        Dim osql As New sqlClass
        Dim c As String
        c = "select Art_Nr,Bestd_ARtikel,sum(Bestd_Hoev1) as Hoev,sum(BestD_Waarde) as Waarde"
        c &= " from bestd,artikel,klanten,bestH"
        c &= " where Art_id = Bestd_Artikel"
        c &= " and besth_klant = Kl_Id"
        c &= " and bestd_besth = besth_Id"
        c &= " and kl_Nummer =  '" & cKlNr & "'"
        c &= " and art_btw = " & sqlClass.cDoubleForJet(nBtw)
        c &= " and besth_DatLevering <= " & sqlClass.cDateForJet(cFactDate)
        c &= " and besth_Factuur = '0'"
        c &= " group by Art_Nr,Bestd_Artikel"
        Dim oBestD As New sqlClass : Dim nRecs As Long = oBestD.Execute(c)
        Dim oConn As New OleDb.OleDbConnection(My.Settings.b040_beConnectionString) : oConn.Open()
        Dim oT As OleDb.OleDbTransaction = oConn.BeginTransaction
        osql.conn = oConn
        c = "insert into FactH (FactH_Nummer,FactH_Datum,FactH_KN,FactH_BTW,FactH_Klant,FactH_TotBet) values ("
        c &= "'" & cFactnr & "',"
        c &= sqlClass.cDateForJet(cFactDate) & ","
        c &= False & ","
        c &= sqlClass.cDoubleForjet(nBtw) & ","
        Dim nKlid As Long = bzKlanten.kl_id(cKlNr)
        c &= bzKlanten.kl_id(cKlNr) & ","
        c &= 0 & ")"
        osql.ExecuteNonQuery(c, oT)
        Dim nPKFactH As Long = osql.RetrieveNewKey(oT)
        Dim oP As New bzPrice : Dim nTotKorting As Double = 0 : Dim nKorting As Double : Dim nTotWaarde As Double = 0
        Dim oFactD As New sqlClass : oFactD.conn = oConn
        For Each row As DataRow In oBestD.dt.Rows
            If row("waarde") <> 0 Then
                c = "insert into FactD (FactD_FactH,FactD_Artikel,FactD_Hoev,FactD_Prijs,FactD_Waarde,FactD_Korting) values ("
                c &= nPKFactH & ","
                c &= row("BestD_Artikel") & ","
                Dim n As Double = row("Hoev") : c &= n.ToString(Globalization.CultureInfo.InvariantCulture) & ","
                n = 0
                Try
                    n = gen.nRound(bzFactuur.nAveragePrice(row("BestD_Artikel"), row("Hoev"), row("Waarde")), 2)
                Catch
                End Try
                c &= n.ToString(Globalization.CultureInfo.InvariantCulture) & ","
                n = row("Waarde") : c &= n.ToString(Globalization.CultureInfo.InvariantCulture) & ","
                oP.artikel = row("Art_nr")
                oP.klant = cKlNr
                oP.compute()
                nKorting = gen.nRound(row("Waarde") * oP.nKortingPct, 2)
                c &= nKorting.ToString(Globalization.CultureInfo.InvariantCulture) & ")"
                oFactD.ExecuteNonQuery(c, oT)
                nTotKorting += nKorting : nTotWaarde += row("Waarde")
            End If
        Next
        Dim nTot As Double = nTotWaarde - nTotKorting
        c = "update FactH "
        c &= "set facth_TotBet = " & nTot.ToString(Globalization.CultureInfo.InvariantCulture) & " "
        c &= ",facth_KN = " & (nTot < 0) & " "
        c &= "where facth_id = " & nPKFactH
        osql.ExecuteNonQuery(c, oT)
        c = "update BestH set BestH_FactH = " & nPKFactH & ", besth_Factuur = '1' "
        c &= " where besth_Klant = " & bzKlanten.kl_id(cKlNr)
        c &= " and besth_Factuur = '0'"
        c &= " and besth_DatLevering <= " & sqlClass.cDateForJet(cFactDate)
        osql.ExecuteNonQuery(c, oT)
        oT.Commit()
    End Sub
    Public Overloads Shared Function dBatchFactuurDatum() As Date
        If Today.Day >= 15 Then Return New Date(Today.Year, Today.Month, 15)
        Return New Date(Today.Year, Today.Month, 1).AddDays(-1)
    End Function
    Public Overloads Shared Function dBatchFactuurDatum(ByVal d As Date) As Date
        If d.Day >= 15 Then Return New Date(d.Year, d.Month, 15)
        Return New Date(d.Year, d.Month, 1).AddDays(-1)
    End Function
    Public Shared Sub deleteBesteldocumenten(ByVal cFactNr As String)
        Dim oSQl As New sqlClass
        Dim cSql As String
        cSql = "select factH_id from FactH where FactH_Nummer = " & sqlClass.c(cFactNr)
        Dim nFact_id As Long
        nFact_id = oSQl.ExecuteScalar(cSql)
        Dim oHeaders As New sqlClass
        cSql = "select besth_id from besth where besth_factH = " & nFact_id
        oHeaders.Execute(cSql)
        oSQl.beginTransaction()
        For Each oRow As DataRow In oHeaders.dt.Rows
            cSql = "delete * from Besth where besth_id = " & oRow("Besth_id")
            oSQl.ExecuteNonQuery(cSql)
            cSql = "delete * from Bestd where bestd_besth = " & oRow("Besth_id")
            oSQl.ExecuteNonQuery(cSql)
        Next
        oSQl.commitTransation()
    End Sub
    Public Shared Function lIsVoldaan(ByVal cFactnr As String) As Boolean
        Dim oSQL As New sqlClass
        Dim cSQL As String
        cSQL = "select Kl_Voldaan from Klanten,Facth where kl_id = facth_klant and facth_Nummer = " & sqlClass.c(cFactnr)
        Return oSQL.ExecuteScalar(cSQL)
    End Function
    Shared Function nAveragePrice(ByVal nARt_id As Long, ByVal nHoev As Double, ByVal nWaarde As Double)
        If nHoev = 0 Then Return 0
        Return nWaarde / nHoev / 10 ^ bzArtikel.nArt_PrijsExponent(nARt_id)
    End Function
End Class

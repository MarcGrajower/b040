Imports System.Data.OleDb
Imports System.Configuration
Imports System.String
Public Class bzBestel
    Public pk As Long
    Public oHeader As DataRow

    Sub fillWeekdagenCbo(ByVal cbo As ComboBox)
        ' ? CultureInfo.CurrentCulture.DateTimeFormat.DayNames (dayofweek.sunday) = "zondag"
        cbo.Items.Add("Zondag")
        cbo.Items.Add("Maandag")
        cbo.Items.Add("Dinsdag")
        cbo.Items.Add("Woensdag")
        cbo.Items.Add("Donderdag")
        cbo.Items.Add("Vrijdag")
    End Sub
    Function dow(ByVal c As String) As Integer
        Select Case UCase(c)
            Case "ZONDAG"
                Return 0
            Case "MAANDAG"
                Return 1
            Case "DINSDAG"
                Return 2
            Case "WOENSDAG"
                Return 3
            Case "DONDERDAG"
                Return 4
            Case "VRIJDAG"
                Return 5
            Case Else
                Throw New InvalidOperationException(c & " is not a day in the week")
                Return 0
        End Select
    End Function
    Function nextDocnr(ByVal KlantDate As String, Optional ByVal lIsLevering As Boolean = False) As String
        ' MG 19/feb/11
        Dim cCode As String = IIf(lIsLevering, "L", "B")
        Dim sql As New sqlClass : Dim c As String = cNvl(sql.ExecuteScalar("select max(besth_docnr) from BestH where besth_docnr like '" & KlantDate & cCode & "%'"))
        If c = "" Then Return KlantDate & cCode & "001"
        Dim n As Integer = Right(c, 3)
        Return KlantDate & cCode & Right("000" & n + 1, 3)
    End Function
    Public Overloads Function lIslevering() As Boolean
        Return lIslevering(Me.oHeader("besth_Docnr"))
    End Function
    Public Overloads Function lIsLevering(ByVal c As String) As Boolean
        Return Mid(c, 12, 1) = "L"
    End Function

    Public Function existsDocnr(ByVal docNr As String) As Boolean
        '' MG 20/feb/11
        Dim tableName As String = IIf(bzKlanten.isParticulierFromDocument(docNr), "PH", "BESTH")
        Dim sql As New sqlClass
        Dim sqlString As String = "select besth_id "
        sqlString &= "from " & tableName & " "
        sqlString &= "where besth_docnr = " & sqlClass.c(docNr)
        Me.pk = sql.ExecuteScalar(sqlString)
        If Me.pk = 0 Then Return False
        Me.oHeader = Me.dtHeader(tableName)(0)
        Return True
    End Function
    ''' <summary>
    ''' true if there is one or more bestd_voorafdrukken
    ''' </summary>

    Public Function lUitzonderlijk(ByVal cDocNr As String) As Boolean
        ' MG 02/apr/11
        Dim isParticulier As Boolean = bzKlanten.isParticulierFromDocument(cDocNr)
        Dim headerTable As String = IIf(isParticulier, "PH", "BESTH")
        Dim detailTable As String = IIf(isParticulier, "PD", "BESTD")
        Dim c As String
        c = "select count(*) from "
        c &= headerTable & "," & detailTable
        c &= " where bestd_besth = besth_id and besth_docnr = '" & cDocNr & "' and trim(bestd_voorafdrukken) <> " & sqlClass.c("")
        Dim sql As New sqlClass : Return sql.ExecuteScalar(c) > 0

    End Function
    Public Function dtHeader(Optional headerTable As String = "BESTH") As DataTable
        Dim sql As New sqlClass
        Dim c As String = "SELECT BestH.*, Klanten.*, Adres.* "
        c &= "FROM (" & headerTable & " BESTH "
        c &= "INNER JOIN Adres ON BestH.BestH_Adres = Adres.Adr_id) "
        c &= "INNER JOIN Klanten ON BestH.BestH_Klant = Klanten.KL_ID "
        c &= "WHERE BestH.BestH_Id = " & Me.pk
        sql.Execute(c)
        Return sql.dt
    End Function
    Public Function cVervoerTijd() As String
        Dim c As String = ""
        Try
            c = CType(Me.oHeader("BestH_DatVervoer"), Date).ToString("dd/MMM/yy") & "-" & Me.oHeader("BestH_TijdVervoer")
        Catch
        End Try
        Return c
    End Function
    Public Function collTours(ByVal cTour As String, ByVal lByTour As Boolean) As Collection
        Dim coll As New Collection
        If cTour <> " " Then
            coll.Add(cTour)
            Return coll
        End If
        If lByTour = False Then
            coll.Add(" ")
            Return coll
        End If
        Dim detailTable As String = IIf(bzKlanten.isParticulier(Me.oHeader("BestH_Klant")), "PD", "BESTD")
        Dim c As String = "select distinct bestd_tour "
        c &= "from " & detailTable & " "
        c &= "where bestd_besth = " & Me.pk
        Dim o As New sqlClass : Dim _tally As Integer = o.Execute(c)
        For i As Integer = 1 To _tally
            coll.Add(o.dt(i - 1)("Bestd_tour"))
        Next
        Return coll
    End Function
    Public Function oCollBTW() As Collection
        Dim oColl As New Collection
        Dim o As New sqlClass : Dim c As String
        c = "select distinct Art_BTW from Bestd,Artikel where Bestd_Artikel = Art_id and Bestd_BestH = " & Me.pk
        Dim n As Integer = o.Execute(c)
        For i As Integer = 1 To n
            oColl.Add(o.dt(i - 1)(0))
        Next
        Return oColl
    End Function
    Public Function lMultipleInvoiced() As Boolean
        If nNvlI(Me.oHeader("BestH_FactH")) = 0 Then Return False
        Dim oColl As Collection = oCollBTW() : If oColl.Count = 1 Then Return False
        Return True
    End Function
    Public Sub load(ByVal nPk As Long, Optional headerTable As String = "Besth")
        Me.pk = nPk

        Me.oHeader = Me.dtHeader(headerTable)(0)
    End Sub
    Public Overloads Function lExistsBestelling(ByVal nKlant As Long, ByVal dLevering As Date, Optional lBestellingOnly As Boolean = False) As Boolean
        ' this is really load any Document rather than bestelling.
        ' this answers the question "is there a bestelling", not if a specific bestelling exists!
        Dim tableName As String = IIf(bzKlanten.isParticulier(nKlant), "pH", "bestH")
        Dim oSql As New sqlClass
        Dim c As String = "select besth_id from " & tableName & " "
        c &= "where besth_klant = " & nKlant & " "
        c &= "and besth_datlevering = #" & dLevering.ToString("MM/dd/yyyy") & "# "
        If lBestellingOnly = True Then
            c &= " and mid(besth_DocNr,12,1) = " & sqlClass.c("B")
        End If
        Dim n As Long = oSql.ExecuteScalar(c)
        If n = 0 Then Return False
        Me.load(n, tableName)
        Return True
    End Function
    Public Overloads Function lExistsBestelling(ByVal cDocnr As String) As Boolean
        Dim tableName As String = IIf(bzKlanten.isParticulierFromDocument(cDocnr), "pH", "bestH")
        Dim oSql As New sqlClass
        Dim c As String = "select besth_id from " & tableName & " "
        c &= "where besth_Docnr = " & sqlClass.c(cDocnr)
        Dim n As Long = oSql.ExecuteScalar(c)
        If n = 0 Then Return False
        Me.load(n, tableName)
        Return True
    End Function
    Public Function nCountLeveringen(ByVal nKlant As Long, ByVal dLevering As Date) As Long
        Dim oSql As New sqlClass
        Dim c As String = "select besth_id from besth "
        c &= "where besth_klant = " & nKlant & " "
        c &= " and besth_datlevering = " & sqlClass.cDateForJet(dLevering)
        c &= " and mid(besth_DocNr,12,1) = " & sqlClass.c("L")
        Dim n As Long = oSql.Execute(c)
        If n = 1 Then Me.load(n)
        Return n
    End Function
    Public Overloads Sub doDelete()
        Me.doDelete(Me.oHeader("BestH_Klant"), Me.pk)
    End Sub
    Public Overloads Sub doDelete(klantPk As Long, bestelHPk As Long)
        Dim bestH As String = "bestH"
        Dim bestD As String = "bestD"
        If bzKlanten.isParticulier(klantPk) Then
            bestH = "PH"
            bestD = "pD"
        End If
        Dim osql As New sqlClass
        osql.beginTransaction()
        osql.ExecuteNonQuery("delete * from " & bestH & " where besth_id = " & bestelHPk)
        osql.ExecuteNonQuery("delete * from " & bestD & " where bestd_besth = " & bestelHPk)
        osql.commitTransation()
    End Sub
    Public Sub createBestelFromStandaard(ByVal nSth_id As Long,
                                         ByVal d As Date,
                                         ByRef documentNumberReturned As String,
                                         ByRef isParticulierReturned As Boolean)
        Dim c As String
        Dim standaardHeader As New sqlClass
        c = "select * from standaardh where sth_id = " & nSth_id
        standaardHeader.Execute(c)
        Dim nKl_id As Long = standaardHeader.dt.Rows(0)("sth_klant")
        Dim isParticulier As Boolean = bzKlanten.isParticulier(nKl_id)
        Dim bestHTablename As String = IIf(isParticulier, "pH", "bestH")
        Dim bestDTablename As String = IIf(isParticulier, "pD", "bestD")
        Dim cDocnr = Me.cDocnrFormat(standaardHeader.dt.Rows(0)("sth_klant"), d, Bestelfrm.eToggle.eToggleBestelling, 1)
        If Me.lExistsBestelling(cDocnr) Then Exit Sub
        Dim oKlant As New bzKlanten : oKlant.kl_nummer = bzKlanten.cNummer(standaardHeader.dt.Rows(0)("sth_klant"))
        Dim standaardDocument As New sqlClass
        c = "select * "
        c &= "from standaardh,standaardd,artikel "
        c &= "where std_sth = sth_id "
        c &= " and std_artikel = art_id "
        c &= "and sth_id = " & nSth_id
        c &= " and art_actief = true "
        Dim nCount As Long = standaardDocument.Execute(c)
        Dim osql As New sqlClass : Dim cSql As String
        osql.beginTransaction()
        cSql = "insert into " & bestHTablename & "("
        'cSql = cSql & "BestH_Id, "
        cSql = cSql & "BEstH_DocNr, "
        cSql = cSql & "BestH_Klant, "
        cSql = cSql & "BestH_KomtHalen, "
        cSql = cSql & "BestH_Bediening, "
        cSql = cSql & "BestH_DatBest, "
        cSql = cSql & "BestH_DatLevering, "
        cSql = cSql & "BestH_UurLevering, "
        ' cSql = cSql & "BestH_DatVervoer, "
        cSql = cSql & "BestH_TijdVervoer, "
        cSql = cSql & "BestH_Adres, "
        cSql = cSql & "BestH_Info, "
        cSql = cSql & "BestH_Standaard, "
        cSql = cSql & "BestH_StToegepast, "
        cSql = cSql & "BestH_StType, "
        cSql = cSql & "BestH_Factuur, "
        cSql = cSql & "BestH_FactH "
        cSql = cSql & ") values ("
        'cSql = cSql & "BestH_Id, "
        cSql = cSql & sqlClass.c(cDocnr) & ", "
        cSql = cSql & nKl_id & ", "
        cSql = cSql & oKlant.record("KL_KomtHalen") & ", "
        cSql = cSql & oKlant.record("KL_Bediening") & ", "
        cSql = cSql & sqlClass.cDateForJet(Today) & ", "
        cSql = cSql & sqlClass.cDateForJet(d) & ","
        cSql = cSql & sqlClass.c("") & ", "
        ' cSql = cSql & "DBNull.value" & ", "
        cSql = cSql & sqlClass.c("") & ", "
        cSql = cSql & oKlant.getStandaardAdres & ", "
        cSql = cSql & sqlClass.c("") & ", "
        cSql = cSql & sqlClass.c(standaardHeader.dt(0)("sth_TypSB")) & ", "
        cSql = cSql & True & ", "
        cSql = cSql & sqlClass.c(standaardHeader.dt(0)("sth_Type")) & ", "
        cSql = cSql & "0" & ", "
        cSql = cSql & 0
        cSql = cSql & ")"
        osql.ExecuteNonQuery(cSql)
        Dim nBestH = osql.retrieveNewKey()
        Dim nLijnen As Long = standaardDocument.dt.Rows.Count
        Dim nTotaal As Double = 0
        Dim oArtikel As New bzArtikel
        For Each oRow As DataRow In standaardDocument.dt.Rows
            oArtikel.load(oRow("std_Artikel"))
            If oArtikel.Record("art_actief") = True Then
                cSql = "insert into " & bestDTablename & " ("
                cSql &= "BestD_BestH,"
                cSql &= "BestD_IsStandaard,"
                cSql &= "BestD_Artikel,"
                cSql &= "BestD_Omschrijving,"
                cSql &= "BestD_Snijden,"
                cSql &= "BestD_Tour,"
                'cSql &= "BestD_Portie,"
                cSql &= "BestD_Hoev,"
                cSql &= "BestD_Hoev1,"
                cSql &= "BestD_EenhPrijs,"
                cSql &= "BestD_Waarde"
                'cSql &= "BestD_Verwittigen,"
                'cSql &= "BestD_Opschrift,"
                'cSql &= "BestD_Boodschap "
                cSql &= ") values ("
                cSql &= nBestH & ","
                cSql &= True & ","
                cSql &= oRow("Std_Artikel") & ","
                cSql &= sqlClass.c(oArtikel.Record("Art_Omschrijving")) & ","
                cSql &= oRow("Std_Snijden") & ","
                cSql &= sqlClass.c(oRow("Std_Tour")) & ","
                'cSql &= "BestD_Portie,"
                cSql &= sqlClass.cDoubleForjet(oRow("Std_Hoeveelheid")) & ","
                cSql &= sqlClass.cDoubleForjet(oRow("Std_Hoeveelheid")) & ","
                cSql &= sqlClass.cDoubleForjet(oArtikel.Record("Art_Prijs")) & ","
                '            Me.BestelDBS(line)("BestD_Waarde") = Sql.dt(line)("Art_Prijs") * Sql.dt(line)("std_Hoeveelheid") * 10 ^ Sql.dt(line)("Eenh_Exponent")
                cSql &= sqlClass.cDoubleForjet(oRow("Std_Hoeveelheid") * oArtikel.Record("Art_Prijs") * 10 ^ bzEenheden.getExponent(oArtikel.Record("Art_Eenheid")))
                'cSql &= False & ","
                'cSql &= "BestD_Opschrift,"
                'cSql &= "BestD_Boodschap "
                cSql &= ")"
                osql.ExecuteNonQuery(cSql)
            End If
        Next
        osql.commitTransation()
        nTotaal = bzBestel.nTotaal(nBestH, isParticulier)
        Dim osqlt As New sqlClass
        cSql = "update " & bestHTablename
        cSql &= " set besth_tottebetalen = " & sqlClass.cDoubleForjet(nTotaal) & ",bestH_totlijnen = " & nLijnen
        cSql &= " where besth_id = " & nBestH
        osqlt.ExecuteNonQuery(cSql)
        nLog(cDocnr & " generated", "bzBestel", LogType.logNormal, LogAction.logCreate, bestHTablename, nBestH)
        documentNumberReturned = cDocnr
        isParticulierReturned = isParticulier
    End Sub
    Public Function cDocnrFormat(ByVal nKl_ID As Long, ByVal d As Date, ByVal oDocType As Bestelfrm.eToggle, ByVal nExtension As Integer) As String
        Dim obzKlanten As New bzKlanten
        Return obzKlanten.Zerofill(bzKlanten.cNummer(nKl_ID)) & d.ToString("yyMMdd") & IIf(oDocType = Bestelfrm.eToggle.eToggleBestelling, "B", "L") & Right("000" & nExtension, 3)
    End Function
#Region "shared"
    Shared Function cDocType(ByVal c As String) As String
        Dim o As New bzBestel
        Return If(o.lIslevering(c), "L", "B")
    End Function
    Shared Function cDocSeq(ByVal cDoc As String) As String
        Return Right(cDoc, 3)
    End Function

    Shared Function lHasKg(ByVal nBestH As Long) As Boolean
        Dim oSql As New sqlClass
        Dim c As String = "select * from Bestd,Artikel,Eenheden "
        c &= "where Art_id = Bestd_Artikel "
        c &= "and Eenh_id = Art_Eenheid "
        c &= "and bestd_besth = " & nBestH & " "
        c &= "and Eenh_Omschrijving = " & sqlClass.c("kg")
        Dim n As Long = oSql.Execute(c)
        Return n <> 0
    End Function
    Shared Sub loadMonthcalendarForDat_Levering(ByVal oMC As MonthCalendar)
        oMC.ShowToday = False
        oMC.MaxSelectionCount = 1
        oMC.MinDate = Now.AddDays(-180)
        oMC.MaxDate = Now.AddDays(180)
        Dim dColl As DateTime() = {}
        Dim nBd As Long = 0
        Dim d As Date = oMC.MinDate
        Do While d < oMC.MaxDate
            If d.DayOfWeek = DayOfWeek.Saturday Then
                nBd += 1
                ReDim Preserve dColl(nBd)
                dColl(nBd) = d
            End If
            d = d.AddDays(1)
        Loop
        Dim oSql As New sqlClass
        Dim cSql As String
        cSql = "select fd_datum from feestdagen "
        cSql &= " where fd_datum >= " & sqlClass.cDateForJet(oMC.MinDate)
        cSql &= " and fd_datum <= " & sqlClass.cDateForJet(oMC.MaxDate)
        oSql.Execute(cSql)
        For Each oDR As DataRow In oSql.dt.Rows
            nBd += 1
            ReDim Preserve dColl(nBd)
            dColl(nBd) = oDR("FD_Datum")
        Next
        oMC.AnnuallyBoldedDates = dColl
    End Sub
    Shared Function lValidLeverdatum(ByVal d As Date) As Boolean
        If bzFeestdagen.lFeestdag(d) Then
            Return False
        End If
        If d.DayOfWeek = DayOfWeek.Saturday Then
            Return False
        End If
        Return True
    End Function
    Shared Function cNextNrLevering(ByVal cKl_Nr As String, ByVal dbesth_datlevering As Date) As String
        Dim oSql As New sqlClass
        Dim cSql As String
        cSql = "select top 1 besth_docnr from besth "
        cSql &= "where besth_Klant = " & bzKlanten.kl_id(cKl_Nr) & " "
        cSql &= "and besth_datlevering = " & sqlClass.cDateForJet(dbesth_datlevering) & " "
        cSql &= "order by besth_docnr desc "
        Dim u = oSql.ExecuteScalar(cSql)
        If u Is Nothing Then Return "L001"
        Return "L" & Right("000" & Val(Right(CStr(u), 3)) + 1, 3)
    End Function
    Shared Function cDisplay(ByVal nId As Long) As String
        Dim oSql As New sqlClass
        Dim cSql As String = "select * "
        cSql &= " from  bestH,Klanten where kl_id = besth_klant and besth_id = " & nId
        Dim _tally As Long = oSql.Execute(cSql)
        If _tally = 0 Then
            Dim cSqlPH As String = "select * "
            cSqlPH &= " from  PH,Klanten where kl_id = besth_klant and besth_id = " & nId
            oSql.Execute(cSqlPH)
        End If
        Dim c As String
        If Mid(oSql.dt(0)("Besth_DocNr"), 12, 1) = "L" Then
            c = "Levering " & Right(oSql.dt(0)("Besth_DocNr"), 3)
        Else
            c = "Bestelling"
        End If
        c &= " van " & Strings.Trim(oSql.dt(0)("kl_Naam")) & " op " & CDate(oSql.dt(0)("besth_DatLevering")).ToString("dd/MM/yy")
        Return c
    End Function
    Shared Function cDocnr(ByVal nId As Long) As String
        Dim oSql As New sqlClass
        Dim cSql As String = "select besth_Docnr from bestH,Klanten where kl_id = besth_klant and besth_id = " & nId
        Return oSql.ExecuteScalar(cSql)
    End Function
    Shared Sub purgeTransactions(cutoffdate As Date)
        Dim cSql As String = "delete * from bestH where besth_datlevering <= " & sqlClass.cDateForJet(cutoffdate)
        Dim oSql As New sqlClass
        oSql.ExecuteNonQuery(cSql)
        cSql = "delete * from bestD where not exists (select * from bestH where besth_id = bestd_bestH)"
        oSql.ExecuteNonQuery(cSql)
        cSql = "delete * from log where log_timestamp <= " & sqlClass.cDateForJet(cutoffdate)
        oSql.ExecuteNonQuery(cSql)
    End Sub
    Shared Sub report(cDocnr As String, Optional preview As Boolean = False)
        ' MG 30/mrt/11
        If preview Then
            Dim o2 As New bzAfrekeningDocument
            o2.cDocNr = cDocnr
            o2.cTour = " "
            o2.lReportByTour = False
            o2.cPrinter = "<PREVIEW>"
            o2.nCopies = 1
            o2.print()
            o2 = Nothing
            Return
        End If
        Dim obz As New bzBestel
        obz.existsDocnr(cDocnr)
        Dim cFactNr As String = ""
        Dim oFrm As New BestelHardcopyRequestFrm
        oFrm.Text = bzBestel.cDisplay(obz.pk)
        oFrm.lAfdrukkenTour = True
        oFrm.TourCtl.Text = " "
        oFrm.Vervoer.Text = "1"
        oFrm.Afrekening.Text = "1"
        oFrm.Faktuur.ioEnable(IOValues.IOAlwaysDisable)
        oFrm.Faktuur.Text = " "
        oFrm.Faktuur.nIO = IOValues.IOAlwaysEnable
        oFrm.particulierMode = False
        If bzKlanten.isParticulierFromDocument(cDocnr) Then
            If obz.oHeader("besth_klant") = BzWinkelproductie.klId = False Then
                oFrm.Vervoer.Text = "0"
                oFrm.Afrekening.Text = "O"
                oFrm.particulierMode = True
                oFrm.Faktuur.nIO = IOValues.IOAlwaysDisable
            End If
        End If
        Dim obzKlanten As New bzKlanten
        obzKlanten.kl_nummer = bzKlanten.cNummer(obz.oHeader("besth_klant"))
        If obzKlanten.lFacturatieAdresExists = False Then
            oFrm.Faktuur.Enabled = False
        End If
        oFrm.lUitzonderlijk = obz.lUitzonderlijk(cDocnr)
        If oFrm.lUitzonderlijk Then oFrm.Uitzonderlijk.Text = "Ja"
        oFrm.cUitzPrinter = cConfiguredUitzPrinter()
        If nNvlI(obz.oHeader("Besth_Facth")) <> 0 Then cFactNr = bzFactuur.cDocnr(obz.oHeader("Besth_FactH"))
        If cFactNr <> "" Then
            oFrm.lblFactNr.Text = "Factuur : " & cFactNr
            oFrm.Faktuur.Text = "1"
            oFrm.Faktuur.ForeColor = Color.Red
        End If
        If oFrm.particulierMode = True Then
            Using xl As New clsExcel
                Dim o As New bzUitzonderlijkAfrekening
                o.requestPrinting(cDocnr, oFrm.lAfdrukkenTour, oFrm.TourCtl.Text, oFrm.cUitzPrinter, xl)
                o = Nothing
            End Using
            Dim o3 As New bzUitzonderlijkDocument
            o3.cDocument = cDocnr
            o3.cPrinter = oFrm.cUitzPrinter
            o3.print()
            o3 = Nothing
            Return
        Else
            If oFrm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        Dim nCopies = Val(oFrm.Vervoer.Text)
        If nCopies <> 0 Then
            Dim o As New bzVervoerDocument
            o.cDocNr = cDocnr
            o.cTour = oFrm.TourCtl.Text
            o.lReportByTour = oFrm.lAfdrukkenTour
            o.cPrinter = oFrm.cboPrinters.Text
            o.nCopies = nCopies
            o.Print()
            o = Nothing
        End If
        nCopies = Val(oFrm.Afrekening.Text) : If nCopies <> 0 Then
            Dim o2 As New bzAfrekeningDocument
            o2.cDocNr = cDocnr
            o2.cTour = oFrm.TourCtl.Text
            o2.lReportByTour = oFrm.lAfdrukkenTour
            o2.cPrinter = oFrm.cboPrinters.Text
            o2.nCopies = nCopies
            o2.print()
            o2 = Nothing
        End If
        If oFrm.lUitzonderlijk Then
            Dim o3 As New bzUitzonderlijkDocument
            o3.cDocument = cDocnr
            o3.cPrinter = oFrm.UitzondelijkPrinter.Text
            o3.print()
            o3 = Nothing
        End If
        nCopies = Val(oFrm.Faktuur.Text)
        If nCopies <> 0 Then
            Dim o4 As New bzFactuur
            o4.cPrinter = oFrm.cboPrinters.Text
            o4.nCopies = nCopies
            Dim oColl As Collection = obz.oCollBTW
            For Each nBTW As Decimal In oColl
                If cFactNr = "" Then cFactNr = bzFactuur.cNextNr(Now()) ' remember updates of multipleinvoices are not supported
                bzFactuur.convBestel(cDocnr, cFactNr, nBTW)
                o4.print(cFactNr)
            Next
            o4 = Nothing
        End If
        If oFrm.ParticulierJaNeen.Text = "Ja" Then
            Using xl As New clsExcel
                Dim o As New bzUitzonderlijkAfrekening
                o.requestPrinting(cDocnr, oFrm.lAfdrukkenTour, oFrm.TourCtl.Text, oFrm.UitzondelijkPrinter.Text, xl)
            End Using
        End If
    End Sub
    Overloads Shared Function dGetLeveringForBestellingDatum(ByVal d As Date) As Date
        Dim o As New bzFeestdagen
        Dim endloop As Boolean = False
        Do
            d = d.AddDays(1)
            If o.isFeesdag(d) = False And d.DayOfWeek <> 6 Then endloop = True
        Loop Until endloop = True
        Return d
    End Function
    Overloads Shared Function dGetLeveringForBestellingDatum() As Date
        Return dGetLeveringForBestellingDatum(Today)
    End Function
    Shared Function dGetDefaultLeveringDatum() As Date
        If (bzFeestdagen.lFeestdag(Now) = False) AndAlso (Now.DayOfWeek <> 6) Then Return Now
        Return bzBestel.dGetLeveringForBestellingDatum
    End Function
    Shared Function nTotaal(ByVal nBestH_id As Long, Optional isParticulier As Boolean = False) As Double
        Dim bestHTableName As String = IIf(isParticulier, "pH", "bestH")
        Dim bestDTableName As String = IIf(isParticulier, "pD", "bestD")

        Dim osqlKlant As New sqlClass
        Dim sqlKlant As String = "select Kl_Nummer from klanten," & bestHTableName & " "
        sqlKlant &= " where besth_klant = kl_id and besth_id = " & nBestH_id
        Dim cKl_Nummer As String = osqlKlant.ExecuteScalar(sqlKlant)

        Dim oSql As New sqlClass
        Dim sql As String = "select * from " & bestDTableName & " "
        sql &= "where bestd_besth = " & nBestH_id
        oSql.Execute(sql)

        Dim n As Double = 0
        Dim obzPrice As New bzPrice
        obzPrice.klant = cKl_Nummer
        For Each oRow As DataRow In oSql.dt.Rows
            obzPrice.artikel = bzArtikel.cArt_nr(oRow("Bestd_Artikel"))
            obzPrice.compute(oRow("Bestd_waarde"))
            n += obzPrice.nTeBetalen
        Next
        Return n
    End Function
    Shared Function lExists(cDocnr) As Boolean
        If IsDBNull(cDocnr) Then Return False
        If IsNullOrEmpty(cDocnr) Then Return False
        Dim oSql As New sqlClass
        Return (oSql.Execute("select * from besth where besth_docnr = " & sqlClass.c(cDocnr)) = 1)
    End Function
    Public Shared Function isBestelling(document As String) As Boolean
        Return Mid(document, 12, 1) = "B"
    End Function

#End Region ' shared

End Class

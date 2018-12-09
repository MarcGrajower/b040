Option Infer On
'Option Explicit On

Imports System.IO
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop

Module test1
    Public Sub testdateformat()
        Debug.Print(DateTimeFormatInfo.CurrentInfo.DateSeparator)
    End Sub
    Sub testisfeesdag()
        Dim o As New bzFeestdagen
        Dim dt As Date = Now
        Debug.Print(dt.DayOfWeek)

        Debug.Print(o.isFeesdag(Now))
        Debug.Print(o.record.FD_Naam)
    End Sub
    Public Sub testbestel()
        Debug.Print(bzBestel.dGetLeveringForBestellingDatum(Now).ToShortDateString)
    End Sub
    Public Sub testvolgende()
        Dim o As New bzFeestdagen
        Debug.Print(o.volgende(Now))
        Debug.Print(o.volgende(Date.Parse("1-jan-2099")))
    End Sub
    Public Sub testdate()
        Dim d As Date
        Debug.Print(Date.TryParseExact("31-jan-11", cDateFormat, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, d))

    End Sub
    Public Sub testgetdayname()
        Dim instance As New DateTimeFormatInfo
        Dim dayofweek As DayOfWeek = DayOfWeek.Friday
        Debug.Print(instance.GetDayName(System.DayOfWeek.Friday).ToString)
    End Sub
    Public Sub testZerofillKlanten()
        Dim o As New bzKlanten
        o.kl_nummer = "  125"
        Debug.Print(o.Zerofill("  125"))
    End Sub
    Public Sub testCheckDate()
        Dim d As Date : d = #1/1/2011# : Dim c As String
        For i As Integer = 0 To 364
            c = d.AddDays(i).ToString("dd/MMM/yy")
            Debug.Print(c)
            If checkDate(c) = False Then
                Debug.Print(c & " failed")
            End If
        Next
    End Sub
    Public Sub testConnections()
        Dim o As New bzArtikel
        ' o.da.Connection.Open()
        Dim t As Date = Now
        For i As Integer = 1 To 100
            o.Art_Nr = "  125"
        Next
        Debug.Print((Now() - t).ToString)
    End Sub

    Public Sub testConnections2()
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter(cmd)
        Dim conn As New OleDbConnection
        Dim dt As New DataTable
        conn.ConnectionString = My.Settings.b040_beConnectionString
        conn.Open()
        cmd.Connection = conn
        Dim n As Long
        Dim t As Date = Now
        For i As Integer = 1 To 100
            cmd.CommandText = "select Art_id from Artikel where Art_nr = '  125'"
            n = cmd.ExecuteScalar()
            cmd.CommandText = "select * from artikel where Art_Nr = '  125'"
            da.Fill(dt)
        Next
        Debug.Print((Now() - t).ToString)
    End Sub
    Public Sub testConnections3()
        Dim cmd As New OleDbCommand
        Dim da As New OleDbDataAdapter(cmd)
        Dim conn As New OleDbConnection
        Dim dt As New DataTable
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=z:\data\b040\b040_be.accdb;OLE DB Services=-1"
        cmd.Connection = conn
        Dim n As Long
        Dim t As Date = Now
        For i As Integer = 1 To 100
            conn.Open()
            cmd.CommandText = "select Art_id from Artikel where Art_nr = '  125'"
            n = cmd.ExecuteScalar()
            cmd.CommandText = "select * from artikel where Art_Nr = '  125'"
            da.Fill(dt)
            conn.Close()
        Next
        Debug.Print((Now() - t).ToString)
    End Sub
    Public Sub testmsgbox()
        Dim o As New b040.YesNoForm
        o.lblbase1.Text = "Dit is de text"
        Dim v = o.ShowDialog
        Debug.Print(v)
    End Sub
    Public Sub testEnumeratePrinters()
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            Debug.Print(PrinterSettings.InstalledPrinters.Item(i))
        Next
        Dim o As New PrinterSettings

        Debug.Print(o.PrinterName)
    End Sub
    Public Sub testBestelHardcopyRequestFrm()
        Dim o As New BestelHardcopyRequestFrm
        If o.ShowDialog = DialogResult.Cancel Then MsgBox("canceled")
        MsgBox(o.cboPrinters.Text)
    End Sub
    Public Sub testExcel()
        Dim thisThread As System.Threading.Thread = System.Threading.Thread.CurrentThread
        Dim originalCulture As System.Globalization.CultureInfo = thisThread.CurrentCulture
        thisThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim o = New Excel.Application
        o.Workbooks.Open(cXLSFolder() & "vervoer.xls", , False)
        o.Visible = True
        o.Range("B25").Value = 1.25

        MsgBox("check")
        o.Quit()
        o = Nothing
        thisThread.CurrentCulture = originalCulture
    End Sub
    Public Sub testExcel2()
        Debug.Print(Threading.Thread.CurrentThread.CurrentCulture.DisplayName)
        testExcel3()
        Debug.Print(Threading.Thread.CurrentThread.CurrentCulture.DisplayName)
    End Sub
    Public Sub testExcel3()
        Dim o As New clsExcel
        Debug.Print(Threading.Thread.CurrentThread.CurrentCulture.DisplayName)
        ' o.Dispose()
        o = Nothing
    End Sub
    Public Sub testExcel4()
        Debug.Print(Threading.Thread.CurrentThread.CurrentCulture.DisplayName)
        Using o As New clsExcel
            Debug.Print(Threading.Thread.CurrentThread.CurrentCulture.DisplayName)
        End Using
        Debug.Print(Threading.Thread.CurrentThread.CurrentCulture.DisplayName)
    End Sub
    Public Sub testMultiline()
        Dim o As New sqlClass
        Dim c As String = o.ExecuteScalar("select besth_info from bestH where besth_id = 137")
        Dim l1 As Array = Split(c, vbNewLine)
        Dim l2 As New List(Of String)
        For Each c2 As String In l1
            For Each c3 As String In WrapText(c2, 40)
                l2.Add(c3)
            Next
        Next
        c = ""
        For Each c2 As String In l2
            c &= c2 & vbNewLine
        Next
        Dim o1 As New clsExcel
        o1.oApp.Workbooks.Add()
        o1.setVisible()
        o1.pasteToRange("a1", c)
    End Sub
    Public Sub testMultiline2()
        Dim o As New sqlClass
        Dim c As String = o.ExecuteScalar("select besth_info from bestH where besth_id = 136")
        For Each c1 As String In WrapText(c, 35)
            MsgBox(c1)
        Next
    End Sub

    Public Sub testMultiline3()
        Dim o As New sqlClass
        Dim c As String = o.ExecuteScalar("select besth_info from bestH where besth_id = 137")
        c = gen.cReformat(c)
        Debug.Print(gen.mLines(c))
    End Sub
    Public Sub testMultiline4()
        Dim o As New sqlClass
        Dim c As String = o.ExecuteScalar("select besth_info from bestH where besth_id = 138")
        c = gen.cReformat(c)
        Dim o1 As New clsExcel
        o1.oApp.Workbooks.Add()
        o1.setVisible()
        o1.setString("a1", "line 1")
        o1.setString("a2", "line 2")
        o1.insertRows(1, mLines(c))
        o1.pasteToRange("a1", c)
    End Sub
    Public Sub testCommandbuilder()
        Dim oConn As OleDb.OleDbConnection = New OleDbConnection(My.Settings.b040_beConnectionString) : oConn.Open()
        Dim oDA As OleDb.OleDbDataAdapter = New OleDbDataAdapter("select * from artikel", oConn)
        Dim oDB As OleDbCommandBuilder = New OleDbCommandBuilder(oDA)
        Debug.Print(oDB.GetInsertCommand.CommandText)
    End Sub
    Public Function testNumericFormat(ByVal n As Double) As String
        Return n.ToString("#,###.00", Globalization.CultureInfo.InstalledUICulture)

    End Function
    Public Sub testScope()
        For i As Integer = 1 To 100
            Dim c As String
            c = "coucou"
        Next
    End Sub
    Sub initializeHistory()
        Dim oSQL As New sqlClass : oSQL.Execute("select BestH_Docnr,Klanten.KL_Naam,BestH_DatBEst,BestH_DatLevering,BestH_ID from BestH,Klanten where BestH_Klant = Kl_id order by BestH_Id")
    End Sub
    Sub testPrice()
        Dim a As Double = 0
        Dim b As Double = 0
        Dim c As Double = 0
        Dim d As Double = 0
        Dim e As Double = 0
        Dim f As Double = 0
        bzPrice.QuickCompute(1802.52, 1, 20, 6, True, 0, False, a, b, c, d, e, f)
        Debug.Print(a)
        Debug.Print(b)
        Debug.Print(c)
        Debug.Print(d)
        Debug.Print(e)
        Debug.Print(f)
    End Sub
    Sub testbyRef()
        Dim a As Double = 1
        testbyref2(1, a)
        Debug.Print(a)
    End Sub
    Sub testbyref2(ByVal p As Double, ByRef q As Double)
        q = 10
    End Sub
    Sub testquery()
        Dim osql As New sqlClass : osql.Execute("select * from qBestTotal1")
        Debug.Print(osql.dt.Rows.Count)
    End Sub
    Sub testlinq()
        Dim osql As New sqlClass : osql.Execute("qryBestelKK")
        Dim orders As IEnumerable(Of DataRow) = osql.dt.AsEnumerable

        Dim test = From r In orders
                   Group r By name = r.Field(Of String)("KL_Naam"), artBtw = r.Field(Of Double)("ArtBtw")
                   Into g = Group Select New With {.Name = name, .artbtw = artBtw, .total = g.Sum(Function(r) r.Field(Of Decimal)("Bestd_Waarde"))}

        For Each r In test
            Console.WriteLine("name: {0} artbtw {1} total {2}", r.Name, r.artbtw, r.total)
        Next
    End Sub
    Sub testGetAccdbName()
        Dim conn As New OleDbConnection(My.Settings.b040_beConnectionString)
        Dim i As Integer : For i = 1 To 10
            Dim t As Date = Now()
            '            conn.Open()
            Dim cFullPath As String = "z:\data\b040\b040_be.accdb" ' conn.DataSource
            '            conn.Close()
            Dim cFolder As String = IO.Path.GetDirectoryName(cFullPath)
            Dim cFilename As String = IO.Path.GetFileName(cFullPath)
            Dim cTempName As String = IO.Path.GetRandomFileName
            Dim cCheckName As String = cFolder & "\" & IO.Path.GetFileNameWithoutExtension(cFullPath) & ".laccdb"
            While IO.File.Exists(cCheckName)
                'System.Threading.Thread.Sleep(2000)
                Application.DoEvents()
            End While
            Debug.Print(Now.Subtract(t).ToString)
        Next

    End Sub
    Sub testPopup()
        ' does not work anyway
        CreateObject("WSScript.shell").popup("Please wait", 1, "Processing", 4096)
    End Sub
    Sub testLongYesNO()
        Dim c As String = "Het zou kunnen dat de database niet exclusief toegangkelijk is."
        c &= "  Controleert U dit even?" & vbCrLf
        c &= "Indien U Ja antwoordt wordt nogmaals gedurenende 2 min getracht de database exclusief te openen."
        YesNO(c, ContentAlignment.MiddleLeft)
    End Sub
    Sub testFilesize()
        Dim info As New FileInfo("z:\data\b040\b040_be.accdb")

        Debug.Print(info.Length)

    End Sub
    Sub testlogfilesize()
        nLog("DB Size before " & New FileInfo("z:\data\b040\b040_be.accdb").Length & ")")
    End Sub
    Sub testIndex()


    End Sub
    Sub testCDouble(ByVal c As String)
        c = Replace(c, "%", "")
        Dim a = Split(c, ".")
        Dim n As Double
        n = 0
        If CType(a(a.Count - 1), String).Length = 2 Then c = Replace(c, ".", ",")
        Debug.Print(c)
        Try
            n = CType(c, Double)
        Catch ex As Exception
        End Try
        Debug.Print(n)
    End Sub
    Function nCDouble(ByVal c As String) As Double
        c = Replace(c, "%", "")
        Dim a As String() = Split(c, ".")
        Dim n As Double
        n = 0
        If a.Count = 2 And CType(a(0), String).Length = 2 Then c = Replace(c, ".", ",")
        Try
            n = CType(c, Double)
        Catch ex As Exception
        End Try
        Return n
    End Function
    Sub listTables()
        Dim oConn As New OleDb.OleDbConnection(My.Settings.b040_beConnectionString) : oConn.Open()
        Dim oST As DataTable
        oST = oConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})
        For Each oRow As DataRow In oST.Rows
            If oRow!table_type.ToString = "TABLE" Then
                Debug.Print(oRow!table_name)
            End If
        Next
    End Sub
    Sub testBlankFields()
        Dim o As New sqlClass
        Debug.Print(o.ExecuteScalar("select ops_omschrijving from opschriften where ops_Id  = 5") & "*")
    End Sub
    Function cIntegerParse(ByVal c As String) As String
        Dim c1 As String = ""
        For i As Integer = 1 To Len(c)
            If Mid(c, i, 1) <> "." Then
                c1 = c1 + Mid(c, i, 1)
            End If
        Next
        Return c1
    End Function
    Sub testCreateTable()
        Dim cSql As String
        cSql = "Create table tmpKlant1 "
        cSql &= "(Rekening char(40), decimalfld decimal(15,2), id integer, Klant integer,Kl_Number char(5))"
        Dim osql As New sqlClass
        osql.ExecuteNonQuery(cSql)
    End Sub
    Sub testSQL()
        Dim osqlArtikelDetails As New sqlClass
        Dim cSqlArtikelDetails As String
        Dim cTableArtikelDetails As String = "tmpGlobal"
        Dim nPkArtikleDetailsKlant As Long = 23723
        Dim nPkArticleDetailsArtikel As Double = 59289
        cSqlArtikelDetails = "select tmpGlobal.bestd_besth, tmpGlobal.besth_docnr, tmpGlobal.besth_datlevering, tmpGlobal.bestd_Hoev1, tmpGlobal.netto, tmpGlobal.expostHoev, "
        cSqlArtikelDetails &= "tmpGlobal.expostBedrag "
        cSqlArtikelDetails &= "FROM " & cTableArtikelDetails & " as tmpGlobal "
        cSqlArtikelDetails &= "WHERE (((tmpGlobal.besth_klant)= " & nPkArtikleDetailsKlant & ") AND ((tmpGlobal.bestd_Artikel)= " & nPkArticleDetailsArtikel & "))"
        osqlArtikelDetails.Execute(cSqlArtikelDetails)
        Debug.Print(osqlArtikelDetails.dt.Rows.Count)
    End Sub
    Public Sub testTodoubleExtension()
        Dim c
        c = DBNull.Value
        Dim n As Double = c.toDouble
        Debug.Print(n)
    End Sub
    Public Sub testGetbesth()
        Dim sql As New sqlClass
        Dim sqlstring As String
        Dim id As Long = 17929
        sqlstring = "select * from besth where besth_id = " & id
        sql.Execute(sqlstring)
        Debug.Print(sql.dt.Rows.Count)
    End Sub
    Public Sub testget_listfromtoursandvooradrukken()
        Dim id As String = "00125131013B001"
        Dim o As New bzUitzonderlijkDocument
        Dim dt As DataTable = o.get_listfromtourandvoorafdrukken(id)
        For Each row As DataRow In dt.Rows
            Debug.Print(row("bestd_voorafdrukken") & "-" & row("bestd_tour"))
        Next
    End Sub
    Public Sub testprint_underline_on_citizen()
        Using printer As New PCPrint
            printer.PrinterSettings.PrinterName = "Citizen CT-S851"
            printer.PrinterFont = New Font("Courier New", 10, FontStyle.Bold)
            printer.DefaultPageSettings.Margins.Left = 5
            printer.DefaultPageSettings.Margins.Right = 5
            printer.DefaultPageSettings.Margins.Top = 5
            printer.TextToPrint = "  " & Chr(27) & Chr(45) & Chr(50) & "underlined" & Chr(10)
            printer.Print()
            printer.TextToPrint = "  " & Chr(27) & Chr(45) & Chr(50) & "underlined" & Chr(10)
            printer.Print()
        End Using
    End Sub
    Public Function test_leveringsdatum(d As Date) As String
        Dim c As String = modDutch.cDagInDeWeek(d)
        Return c & " " & Format(d, "dd-MM-yyyy")
    End Function
    Public Sub test_emptyVoorafdrukken()
        Dim o As New sqlClass
        o.Execute("select * from bestd where bestd_id = 424801")
        Dim c As String = o.dt(0)("bestd_voorafdrukken")
        Debug.Print(Trim(c) = "")
    End Sub
    Public Sub test_cdate()
        Debug.Print(CDate("23/10/13"))
    End Sub
    Public Sub testSqlInPrintKlantOverview()
        Dim id As Long = 19882
        Dim sql As String = "select * from besth,klanten where besth_klant = kl_id and besth_id = " & id
        Dim sqlobject As New sqlClass
        Debug.Print(sqlobject.Execute(sql))
    End Sub
    Public Function test_strip(telefoonnummer As String) As String
        Dim stripped As String = ""
        For Each currentCharacter In telefoonnummer.ToList
            stripped &= IIf(IsNumeric(currentCharacter), currentCharacter, "")
        Next
        Return stripped
    End Function
    Public Sub testKlantenIsParticulier()
        Debug.Print(bzKlanten.isParticulier(32037))
    End Sub
    Public Sub testUitzonderlijkAfrekening()
        Using xl As New clsExcel
            Dim o As New bzUitzonderlijkAfrekening
            o.print("01024140105B001", xl, "1")
            xl.setVisible()
        End Using
    End Sub
    Function testGetEenheid(Artikel As Long) As String
        Dim sql As String = "select eenh_omschrijving from artikel,eenheden where art_eenheid = eenh_id and art_id = " & Artikel
        Dim osql As New sqlClass
        Return IIf(osql.ExecuteScalar(sql) = "kg", "g ", "")
    End Function
    Sub testChr()
        Debug.Print(Chr(137))
    End Sub
    Sub testExitFor()
        For i As Integer = 1 To 10
            Debug.Print(i)
            If i = 6 Then
                Exit For
            End If
        Next
    End Sub
    Sub addingPoints()
        Dim a As New Point(1, 1)
        Dim b As New Point(2, 1)
        Debug.Print((a + b).X)
        Debug.Print((a + b).Y)
    End Sub
    Sub test_andalso()
        Dim b As Boolean = (5 = 5) AndAlso (6 = 6)
        Debug.Print(b)
    End Sub
    Sub test_getparticulierenbestelllingendates()
        Dim nodates As Boolean = True
        Dim dates() As Date = Nothing
        ParticulierenBestellingen.getDates(dates, nodates)
        If nodates = True Then
            Debug.Print("no dates")
            Exit Sub
        End If
        If nodates = False Then
            Debug.Print(dates.Count)
            For i As Integer = dates.GetLowerBound(0) To dates.GetUpperBound(0)
                Debug.Print(dates(i))
            Next
        End If
    End Sub
    Sub test_particulierenbestellingenreport()
        Dim o As New ParticulierenBestellingen
        o.copijen = 1
        o.datum = DateSerial(2014, 5, 16)
        o.printer = "<PREVIEW>"
        o.report()
    End Sub
    Sub test_query()
        Dim bestellingsDatums As New sqlClass
        Dim p As New OleDbParameter
        p.ParameterName = "coucou"
        p.Value = Now().AddDays(3)
        p.OleDbType = OleDbType.Date
        bestellingsDatums.parameterCollection.Add(p)
        p.ParameterName = "coucou2"
        p.Value = Now()
        p.OleDbType = OleDbType.Date
        bestellingsDatums.parameterCollection.Add(p)
        Debug.Print(bestellingsDatums.Execute("qry_ProductiePlanOverzicht_Datums_Alle"))
    End Sub
    Sub test_datareader()
        Dim conn As New OleDbConnection(My.Settings.b040_beConnectionString)
        conn.Open()
        Dim command As New OleDbCommand("select * from Klanten", conn)
        Dim reader As OleDbDataReader = command.ExecuteReader
        reader.Read()
        Debug.Print(reader.GetInt32(0))
    End Sub
    Sub test_qryBatchAfdrukkenParticulieren()
        Dim sql As New sqlClass
        Dim datum As New OleDb.OleDbParameter
        datum.Value = Now().AddDays(1)
        datum.DbType = DbType.Date
        sql.parameterCollection.Add(datum)
        Debug.Print(sql.Execute("qryBatchAfdrukkenParticulieren"))
    End Sub
    Sub test_batchAfdrukkenParticulierenOverzicht()
        Using xl As New clsExcel
            batchAfdrukkenParticulierenOverzicht.report(xl, DateSerial(2014, 5, 28))
        End Using
    End Sub
    Sub test_qryBestelKl_Nummer_Validating()
        Dim sql As New sqlClass
        Dim c As String = "qrybestelKl_Nummer_Validating"
        Dim p As New OleDb.OleDbParameter()
        p.Value = "%GRA%"
        sql.parameterCollection.Add(p)
        Debug.Print(sql.Execute(c))
    End Sub
    Sub test_qryFacturatiePH()
        Dim cutoff As Date = DateSerial(2014, 5, 31)
        Dim sql As New sqlClass
        Dim p As New OleDb.OleDbParameter
        p.DbType = DbType.Date
        p.Value = cutoff
        sql.parameterCollection.Add(p)
        Debug.Print(sql.Execute("qryFacturatiePH"))
    End Sub
    Sub test_checkLastBestelling()
        Dim klant As Long = 32103
        Dim sql As New sqlClass
        Dim p As New OleDbParameter
        p.DbType = DbType.Int32
        p.Value = klant
        sql.parameterCollection.Add(p)
        Debug.Print(sql.ExecuteScalar("qryFacturatieLaatsteDatum"))
    End Sub
    Sub test_deletePDocuments()
        Dim id As Long = 6
        Dim conn As New OleDbConnection(My.Settings.b040_beConnectionString) : conn.Open()
        Dim t As OleDbTransaction = conn.BeginTransaction
        Dim sql As New sqlClass
        sql.conn = conn
        Dim p As New OleDbParameter
        p.DbType = DbType.Int32
        p.Value = id
        sql.parameterCollection.Add(p)
        sql.ExecuteNonQuery("qryFacturatiePHDelete", t)
        Dim sqld As New sqlClass
        sqld.conn = conn
        Dim pd As New OleDbParameter
        pd.DbType = DbType.Int32
        pd.Value = id
        sqld.parameterCollection.Add(pd)
        sqld.ExecuteNonQuery("qryFacturatiePDDelete", t)
        t.Commit()
        conn.Close()
    End Sub
    Sub test_purgePDocuments()
        frmBatchFacturatie.particulierenPurge(False)
    End Sub
    Sub test_dateformat()
        Debug.Print(UCase(Now().ToString("dddd d")))
    End Sub
    Sub test_existbestelling()
        Dim o As New bzBestel
        Debug.Print(o.lExistsBestelling(32044, DateSerial(2014, 6, 23)))
    End Sub
    Public Sub test_deleteFossiles()
        Dim osql As New sqlClass
        Debug.Print(osql.ExecuteNonQuery("delete * from ph where not exists (select * from pd where bestd_besth = besth_id)"))
    End Sub
    Public Sub test_TryParse()
        Dim d As Double = 0
        Debug.Print("Result {0}, value {1}", Double.TryParse(False, d), d)
    End Sub

End Module

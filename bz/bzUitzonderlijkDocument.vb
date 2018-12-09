Public Class bzUitzonderlijkDocument
    Public cDocument As String
    Public cPrinter As String
    Dim excelwrapper As New clsExcel
    Dim bestTables As String = "BESTH,BESTD"
    ' Dim obzBestel As New bzBestel
    Function getEenheid(Artikel As Long) As String
        Dim sql As String = "select eenh_omschrijving from artikel,eenheden where art_eenheid = eenh_id and art_id = " & Artikel
        Dim osql As New sqlClass
        Return IIf(osql.ExecuteScalar(sql) = "kg", "g ", "")
    End Function
#Region "printDirect"
    Public Class uitzondelijkdocument_variabelen
        Public telefoon As String
        Public komthalen As String
        Public klant_naam As String
        Public adres As String
        Public postnummer_en_gemeente As String
        Public tour As String
        Public datum_levering As String
        Public voorafdrukken As String
        Public hoeveelheid As String
        Public artikel_omschrijving As String
        Public info As String
        Public artikel As Long
        Public klantNummer As String
    End Class
    Sub print(variabelen As uitzondelijkdocument_variabelen)
        Using Me.excelwrapper
            Dim eenheid As String = getEenheid(variabelen.artikel)
            Me.excelwrapper.openWorkbook(cXLSFolder() & "uitzonderlijk.xls")
            Me.excelwrapper.setString("D3", variabelen.telefoon)
            Me.excelwrapper.setString("E2", variabelen.komthalen)
            Me.excelwrapper.setString("B2", variabelen.klant_naam)
            Me.excelwrapper.setString("B3", variabelen.klantNummer)
            Me.excelwrapper.setString("B4", variabelen.adres)
            Me.excelwrapper.setString("B5", variabelen.postnummer_en_gemeente)
            Me.excelwrapper.setString("E8", variabelen.tour)
            Me.excelwrapper.setString("B9", variabelen.datum_levering)
            Me.excelwrapper.setString("D12", "(" & variabelen.voorafdrukken & ")")
            Me.excelwrapper.setString("B13", variabelen.hoeveelheid)
            Me.excelwrapper.setString("C13", eenheid & variabelen.artikel_omschrijving)
            Me.excelwrapper.setString("B17", variabelen.info)
            Me.excelwrapper.cXlsRoot = "Uitzonderlijk"
            Me.excelwrapper.cPrinter = modB040Config.cConfiguredUitzPrinter
            Me.excelwrapper.nCopies = 1
            Me.excelwrapper.printOut()
        End Using
    End Sub
#End Region

    Function get_listfromtourandvoorafdrukken(document As String) As DataTable
        Dim sql As New sqlClass
        Dim sqlstring As String
        sqlstring = "select distinct bestd_voorafdrukken,bestd_tour "
        sqlstring &= "from " & bestTables & " "
        sqlstring &= "where bestd_besth = besth_id "
        sqlstring &= "and besth_docnr = " & sqlClass.c(document) & " "
        sqlstring &= "and isnull(bestd_voorafdrukken) = False "
        sqlstring &= "and trim(bestd_voorafdrukken)<>" & sqlClass.c("") & " "
        sqlstring &= "order by 1,2"
        sql.Execute(sqlstring)
        Return sql.dt
    End Function
#Region "printalist"
    Function format_date(d As Date) As String
        Dim c As String = modDutch.cDagInDeWeek(d)
        Return c & " " & Format(d, "dd-MM-yyyy")
    End Function
    Function format_postnummer_adres(postnummer, gemeente)
        postnummer = Trim(cNvl(postnummer))
        If postnummer = "" Then
            Return gemeente
        End If
        Return postnummer & " " & gemeente
    End Function
 
    Sub printalist(list As String, tour As String)
        Dim oSql As New sqlClass
        Dim cSql As String = "select * "
        cSql &= "from " & bestTables & ",Klanten,adres "
        cSql &= "where bestd_besth = besth_id "
        cSql &= "and Kl_id = besth_Klant "
        cSql &= "and adr_id = besth_adres "
        cSql &= "and besth_docnr = " & sqlClass.c(Me.cDocument) & " "
        cSql &= "and bestd_tour = " & sqlClass.c(tour) & " "
        cSql &= "and bestd_voorafdrukken = " & sqlClass.c(list) & " "

        Dim tally As Integer = oSql.Execute(cSql)
        If tally = 0 Then Exit Sub
        Dim r1 As DataRow = oSql.dt.Rows(0) ' first row
        Me.excelwrapper.openWorkbook(cXLSFolder() & "uitzonderlijk.xls")
        Me.excelwrapper.setString("C2", Trim(cNvl(r1("Adr_Telefoon"))))
        Me.excelwrapper.setString("F2", IIf(r1("besth_komthalen"), "Ja", "Neen"))
        Me.excelwrapper.setString("B3", r1("KL_Naam"))
        Me.excelwrapper.setString("B4", r1("adr_adres"))
        Me.excelwrapper.setString("B5", Me.format_postnummer_adres(r1("adr_postnummer"), r1("adr_gemeente")))
        Me.excelwrapper.setString("E8", cNvl(r1("bestd_tour")))
        Me.excelwrapper.setString("B9", Me.format_date(r1("besth_datlevering")))
        Me.excelwrapper.setString("D12", "(" & cNvl(r1("BestD_Voorafdrukken")) & ")")
        If tally > 1 Then
            Me.excelwrapper.oApp.Range("a14").Select()
            For addedrow As Long = 1 To tally - 1
                Me.excelwrapper.oApp.ActiveCell.EntireRow.Insert()
            Next
        End If
        For line As Long = 1 To tally
            Dim r As DataRow = oSql.dt.Rows(line - 1)
            Me.excelwrapper.setString("B" & line + 12, r("bestd_Hoev1"))
            Dim eenheid As String = ""
            eenheid = getEenheid(r("BestD_Artikel"))
            Me.excelwrapper.setString("C" & line + 12, eenheid & r("Bestd_omschrijving"))
        Next
        Me.excelwrapper.cXlsRoot = "Uitzonderlijk"
        Me.excelwrapper.setString("B" & tally + 16, Trim(cNvl(r1("besth_info"))))
        Me.excelwrapper.cPrinter = Me.cPrinter
        Me.excelwrapper.nCopies = 1
        Me.excelwrapper.printOut()
    End Sub
#End Region
    Public Sub print()
        ' MG 17/mei/12
        Dim isParticulier As Boolean = bzKlanten.isParticulierFromDocument(Me.cDocument)
        Me.bestTables = IIf(isParticulier, "PH,PD", "BESTH,BESTD")
        Using Me.excelwrapper
            Dim lists As DataTable = Me.get_listfromtourandvoorafdrukken(Me.cDocument)
            For Each row As DataRow In lists.Rows
                Me.printalist(row("bestd_voorafdrukken"), row("bestd_tour"))
            Next
        End Using
    End Sub
End Class

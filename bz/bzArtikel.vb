Public Class bzArtikel
    Dim ds As New dsArtikel
    Public da As New dsArtikelTableAdapters.ArtikelTableAdapter
    Public dt As New dsArtikel.ArtikelDataTable
    Dim pk As Long
    Public Record As dsArtikel.ArtikelRow
    'Public Sub New()
    '    Me.da.Connection.Open()
    'End Sub
    'Protected Overrides Sub Finalize()
    '    If Me.da.Connection.State = ConnectionState.Open Then Me.da.Connection.Close()
    '    MyBase.Finalize()
    'End Sub

    Public Property Art_Nr() As String
        Get
            Return Record("Art_Nr")
        End Get
        Set(ByVal value As String)
            Dim osql As New sqlClass
            Dim v = osql.ExecuteScalar("select art_id from Artikel where art_nr = '" & value & "'")
            'Dim v = Me.da.ArtikelFromNrScalarQuery(value)
            If v Is Nothing Then Throw New InvalidOperationException(value & " is not a valid Artikel Nummer.")
            pk = CType(v, Integer)
            dt = da.GetData(pk)
            If dt.Count <> 1 Then Throw New InvalidOperationException(value & " is not a unique Artikel Nummer.")
            Record = dt(0)
        End Set
    End Property
    Public Function SnijdenApplicable() As Boolean
        Return Me.Record("Art_Categorie") = "1"
    End Function
    Public Function Art_NrExists(ByVal art_Nr As String) As Boolean
        Dim v = Me.da.ArtikelFromNrScalarQuery(art_Nr)
        If v Is Nothing Then Return False
        Me.Art_Nr = art_Nr
        Return True
    End Function
    Public Function Art_NrFormat(ByVal c As String) As String
        Return (RSet(c, Me.dt.Columns("Art_Nr").MaxLength))
    End Function
    Public Function CodeExists(ByVal c As String) As Boolean
        Dim sql As New sqlClass : Dim tally As Integer = sql.Execute("select Art_Nr from Artikel where Art_AlphaCode = '" & c & "'")
        If tally <> 1 Then Return False
        Me.Art_Nr = sql.dt(0)("Art_nr")
        Return True
    End Function
    Public Function Waarde(ByVal hoev As Double) As Double
        If Me.Record Is Nothing Then Return 0
        Dim o As New bzEenheden : o.Eenh_id = Me.Record.Art_Eenheid
        Return hoev * Me.Record.Art_Prijs * 10 ^ o.record.Eenh_Exponent
    End Function
    Public Function calcHoev(ByVal Waarde As Double) As Double
        If Me.Record Is Nothing Then Return 0
        Dim o As New bzEenheden : o.Eenh_id = Me.Record.Art_Eenheid
        Return (Waarde / Me.Record.Art_Prijs) / 10 ^ o.record.Eenh_Exponent
    End Function
    Public Sub load(ByVal pk As Long)
        Me.dt = da.GetData(pk)
        Me.Record = Me.dt(0)
    End Sub
    Public Function nFieldLength(ByVal cFieldName As String) As Long
        Return Me.dt.Columns(cFieldName).MaxLength
    End Function
    Shared Function nArt_Prijs(ByVal nArt_Id As Long) As Double
        Dim oSql As New sqlClass
        Dim cSql As String = "select Art_Prijs from Artikel where art_id = " & nArt_Id
        Return oSql.ExecuteScalar(cSql)
    End Function
    Shared Function nArt_PrijsExponent(ByVal nArt_Id As Long) As Long
        Dim oSql As New sqlClass
        Dim cSql As String = "select Eenh_Exponent from eenheden,Artikel where eenh_id = art_eenheid and art_id = " & nArt_Id
        Return oSql.ExecuteScalar(cSql)
    End Function
    Shared Function cArt_nr(ByVal nArt_id As Long) As String
        Dim osql As New sqlClass
        Return osql.ExecuteScalar("select Art_Nr from Artikel where Art_id = " & nArt_id)
    End Function
    Shared Function omschrijving(pk As Long) As String
        Dim artikel As New sqlClass
        Return artikel.ExecuteScalar("select Art_Omschrijving from Artikel where Art_id = " & pk)
    End Function
    Public Shared Function GetArtId(artnummer As String) As Long
        Dim context As New sqlClass
        context.parameterCollection.Add(New OleDb.OleDbParameter("?", artnummer))
        Return context.ExecuteScalar("select art_id from artikel where art_nr = ?")
    End Function
    Class clsSearch
        Public lFound As Boolean = True
        Public cInput As String
        Public cArtNr As String
        Public cMessage As String
        Public nFieldLength As Long
        Public oCaller As Control
        Public lUserCanceled As Boolean = False
        Public allowNietActief As Boolean = True
        Sub search()
            Dim rgx As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 -]")
            Me.cInput = rgx.Replace(Me.cInput, "")
            Me.lFound = True
            Me.lUserCanceled = False
            Me.cMessage = ""
            ' check numeric
            Dim n As Long = Val(Me.cInput)
            If n <> 0 Then
                If Len(Trim(Me.cInput)) > Me.nFieldLength Then
                    Me.cMessage = "Artikel nr " & Me.cInput & " bestaat niet."""
                    Me.lFound = False
                    Exit Sub
                End If
                Me.cArtNr = Strings.RSet(Me.cInput, Me.nFieldLength)
                Dim obzArtikel = New bzArtikel
                If obzArtikel.Art_NrExists(Me.cArtNr) = False Then
                    Me.cMessage = "Artikel nr " & Me.cInput & " bestaat niet."""
                    Me.lFound = False
                    Exit Sub
                End If
                Exit Sub
            End If
            Dim sql As New sqlClass
            Dim tally As Long
            Dim a As Array = Split(Me.cInput)
            If a.Length > 1 Then
                Dim oSB As New System.Text.StringBuilder
                For Each c As String In a
                    oSB.Append("Art_Omschrijving like '%" & Trim(c) & "%' and ")
                Next
                Dim cTokens As String = oSB.ToString
                cTokens = Strings.Left(cTokens, Len(cTokens) - 5)
                Dim csqlTokens As String
                csqlTokens = "select Art_Nr,Art_Omschrijving,format(Art_prijs,'#,##0.00 EUR'),IIf([ARt_korting],'-','NETTO'),IIf(Art_Actief,'Actief','Niet Actief'),Art_AlphaCode from Artikel "
                csqlTokens &= " where " & cTokens
                csqlTokens &= IIf(Me.allowNietActief, "", "and art_actief = true ")
                csqlTokens &= " order by Art_Omschrijving"
                tally = sql.Execute(csqlTokens)
                If tally = 1 Then
                    Me.cArtNr = sql.dt(0)("art_nr")
                    Exit Sub
                End If
                If tally > 1 Then
                    Dim f As New PopupFrm
                    f.caller = Me.oCaller
                    f.dt = sql.dt
                    f.ShowDialog()
                    If f.userCanceled Then
                        Me.lUserCanceled = True
                        Me.lFound = False
                        Me.cMessage = ""
                        Exit Sub
                    End If
                    Me.cArtNr = sql.dt(f.selected)("art_nr")
                    Exit Sub
                End If
            End If
            Dim sqlsearch As String
            sqlsearch = "select Art_Nr,Art_Omschrijving,format(Art_prijs,'#,##0.00 EUR'),IIf([ARt_korting],'-','NETTO'),IIf(Art_Actief,'Actief','Niet Actief'),Art_AlphaCode from Artikel "
            sqlsearch &= "where Art_Omschrijving & Art_Alphacode like '%" & Me.cInput & "%' "
            sqlsearch &= IIf(Me.allowNietActief, "", "and art_actief = true ")
            sqlsearch &= " order by Art_Omschrijving "
            tally = sql.Execute(sqlsearch)
            If tally = 1 Then
                Me.cArtNr = sql.dt(0)("art_nr")
                Exit Sub
            End If
            If tally > 1 Then
                Dim f As New PopupFrm
                f.caller = Me.oCaller
                f.dt = sql.dt
                f.ShowDialog()
                If f.userCanceled Or f.selected = -1 Then
                    Me.lUserCanceled = True
                    Me.lFound = False
                    Me.cMessage = ""
                    Exit Sub
                End If
                Me.cArtNr = sql.dt(f.selected)("Art_nr")
                Exit Sub
            End If
            Me.lFound = False
            cMessage = "Geen Artikel met " & Me.cInput & " kon gevonden worden"
        End Sub

    End Class
End Class

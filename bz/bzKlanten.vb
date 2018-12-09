Public Class bzKlanten
    Public ds As New KlantenDS
    Public da As New KlantenDSTableAdapters.KlantenCRUD
    Public dt As New KlantenDS.KlantenDataTable
    Dim pk As Long
    Public record As KlantenDS.KlantenRow
    Property kl_nummer() As String
        Get
            Return record.KL_Nummer
        End Get
        Set(ByVal value As String)
            Dim v = Me.da.KL_ID(value)
            If v Is Nothing Then Throw New InvalidOperationException(value & " is not a valid KL_Nummer")
            Me.da.Fill(Me.dt, CType(v, Long))
            Me.record = Me.dt(0)
            Me.pk = Me.record.KL_ID
        End Set
    End Property
    Public Function Kl_NummerExists(ByVal kl_nummer As String) As Boolean
        Dim c As String = Me.Kl_NummerFormat(kl_nummer)
        Dim v = Me.da.KL_ID(c)
        If v Is Nothing Then Return False
        Me.kl_nummer = c
        Return True
    End Function
    Public Function Kl_NummerFormat(ByVal KL_Nummer As String) As String
        Return RSet(KL_Nummer, Me.dt.Columns("KL_Nummer").MaxLength)
    End Function
    Public Function Adr_Telefoon() As String
        Dim sql As New sqlClass : Dim tally As Integer = sql.Execute("select Adr_Telefoon from Adres where Adr_klant = " & Me.record("kl_id") & " and adr_Facturatie = true ")
        If tally = 1 Then Return cNvl(sql.dt(0)("Adr_Telefoon"))
        Return ""
    End Function
    Public Function KL_CodeExists(ByVal c As String) As Boolean
        Dim sql As New sqlClass : Dim tally As Integer = sql.Execute("select Kl_Nummer from Klanten where kl_Code = '" & c & "'")
        If tally <> 1 Then Return False
        Me.kl_nummer = sql.dt(0)("kl_nummer")
        Return True
    End Function
    Public Function Zerofill(ByVal c As String) As String
        Dim l As Integer = Me.dt.Columns("KL_Nummer").MaxLength
        Return Right(New String("0", l) & Trim(c), l)
    End Function
    Public Shared Function kl_id(ByVal c As String) As Long
        Dim o As New bzKlanten : o.kl_nummer = c
        Return o.record.KL_ID
    End Function
    Public Shared Function cNummer(ByVal nPk As Long) As String
        Dim o As New bzKlanten
        o.da.Fill(o.dt, nPk)
        Return o.dt(0).KL_Nummer
    End Function
    Public Function lAdresExists(ByVal nPkAdr As Long) As Boolean
        Dim o As New sqlClass
        Dim n As Long = o.Execute("select * from Adres where adr_id = " & nPkAdr & " and adr_klant = " & Me.pk)
        Return (n = 1)
    End Function
    Public Sub insertAdres(ByVal cAdres As String, ByVal cPostNr As String, ByVal cGemeente As String, ByVal cLand As String, ByRef nNewPk As Long)
        Dim o As New sqlClass
        If cNvl(cAdres) = "" Then cAdres = " "
        If cNvl(cPostNr) = "" Then cPostNr = " "
        If cNvl(cGemeente) = "" Then cGemeente = " "
        If cNvl(cLand) = "" Then cLand = " "
        Dim c As String = "insert into adres "
        c &= "(Adr_Klant,Adr_Adres,Adr_Postnummer,Adr_Gemeente,Adr_land,Adr_Telefoon,Adr_Facturatie,Adr_Actief) "
        c &= "values "
        c &= "(" & Me.pk & ",'" & cAdres & "','" & cPostNr & "','" & cGemeente & "','" & cLand & "',' ',false,true)"
        o.ExecuteNonQuery(c)
        nNewPk = o.RetrieveNewKey
    End Sub
    Public Function lFacturatieAdresExists() As Boolean
        Dim o As New sqlClass
        Dim n As Integer = o.Execute("select * from adres whEre adr_klant = " & Me.record.KL_ID & " and adr_facturatie = true")
        Return (n = 1)
    End Function
    Public Function getStandaardAdres() As Long
        Return getFacturatieAdres()
    End Function
    Public Function getFacturatieAdres() As Long
        Dim o As New sqlClass
        Dim n As Integer = o.ExecuteScalar("select adr_id from adres whEre adr_klant = " & Me.record.KL_ID & " and adr_facturatie = true")
        Return n
    End Function
    Public Shared Function cKl_Naam(ByVal cKl_Nummer As String) As String
        Dim o As New sqlClass
        Dim cSql As String = "select Kl_Naam from Klanten where Kl_Nummer = " & sqlClass.c(cKl_Nummer)
        Return o.ExecuteScalar(cSql)
    End Function
    Public Shared Function searchByTelefoon(telefoonSeed As String, controlObject As Control) As Long
        Dim telefoonNummers As New sqlClass
        Dim sql As String = "select distinct tel_klanten,kl_naam & ' ' & kl_voornaam,tel_nummerStripped,iif(kl_facturatie=1,'Groothandel','Particulier') "
        sql &= "from telefoon,klanten "
        sql &= "where kl_id = tel_klanten "
        sql &= "and kl_actief = " & sqlClass.cBoolean(True) & " "
        sql &= " and tel_nummerStripped Like " & sqlClass.cLike(telefoonSeed)
        Dim candidateCount As Long = telefoonNummers.Execute(sql)
        If candidateCount = 1 Then
            Return telefoonNummers.dt(0)(0)
        End If
        If candidateCount > 1 Then
            Dim f As New PopupFrm
            f.caller = controlObject
            f.dt = telefoonNummers.dt
            f.hideFirstColumn = True
            f.ShowDialog()
            If f.userCanceled Then
                Return 0
            End If
            Return telefoonNummers.dt(f.selected)(0)
        End If
        Return 0
    End Function
    Public Shared Function isParticulier(kl_id As Long) As Boolean
        Dim sql As String = "select (TypF_Omschrijving=" & sqlClass.c("Particulier") & ") from Klanten,TypeFact "
        sql &= "where kl_Facturatie = typF_Id "
        sql &= "and kl_id = " & kl_id
        Dim sqlObject As New sqlClass
        Return sqlObject.ExecuteScalar(sql)
    End Function
    Public Shared Function cNummerFromDocument(document As String) As String
        Dim work As String
        work = Left(document, 5)
        Dim count As Long
        For count = 1 To 5
            If Mid(work, count, 1) = "0" Then
                Mid(work, count, 1) = " "
            Else
                Exit For
            End If
        Next
        Return work
    End Function
    Public Shared Function isParticulierFromDocument(document As String) As Boolean
        Dim klNummer As String = bzKlanten.cNummerFromDocument(document)
        Dim sql As String = "select (TypF_Omschrijving=" & sqlClass.c("Particulier") & ") from Klanten,TypeFact "
        sql &= "where kl_Facturatie = typF_Id "
        sql &= "and kl_Nummer = " & sqlClass.c(bzKlanten.cNummerFromDocument(document))
        Dim sqlObject As New sqlClass
        Return sqlObject.ExecuteScalar(sql)

    End Function
    Public Shared Function exBTW(p1 As Object) As Boolean
        Throw New NotImplementedException
    End Function
    Public Shared Sub getKlantenFromTokenized(zoek As String, ByRef dt As DataTable)
        Dim tokens As Array = Split(zoek, " ")
        Dim tokenscount As Long = tokens.GetLength(0)
        If tokenscount < 1 Then
            Exit Sub
        End If
        Dim c As String = "select KL_nummer,trim(Kl_naam) & ' ' & trim(kl_voornaam) & (IIf(kl_Facturatie = 1, '(Groothandel)', '(Particulier)')) as displayField from klanten  "
        c &= " where KL_Naam like " & sqlClass.cLike(tokens(0))
        For i As Long = 2 To tokenscount
            If Trim(tokens(i - 1)) = "" Then
                Continue For
            End If
            c &= " and KL_Naam like " & sqlClass.cLike(tokens(i - 1))
        Next
        c &= " and kl_Actief = true "
        c &= " order by kl_naam"
        Dim zoekKlantSql As New sqlClass
        zoekKlantSql.Execute(c)
        Dim insertRow As DataRow = zoekKlantSql.dt.NewRow()
        insertRow("KL_Nummer") = "0"
        insertRow("displayField") = "<Nieuwe Klant>"
        zoekKlantSql.dt.Rows.InsertAt(insertRow, 0)
        dt = zoekKlantSql.dt
    End Sub
    Public Shared Function hasTransactions(klid As Long) As Boolean
        Dim sql As String = "select * from " & bzTypeFact.headerTablename(klid)
        sql &= " where besth_klant = " & klid
        Dim sqlClass As New sqlClass
        If sqlClass.Execute(sql) > 0 Then
            Return True
        End If
        sql = "select * from FactH "
        sql &= " where facth_klant = " & klid
        Return sqlClass.Execute(sql) > 0
    End Function
    Public Shared Function klantType(klNummer As String) As Boolean
        Dim id As Long = bzKlanten.kl_id(klNummer)
        Dim sql As String = "select * from " & bzTypeFact.headerTablename(id)
        sql &= " where besth_klant = " & id
    End Function
    Public Shared Function getTelefoon(klNummer As String) As String
        Dim id As Long = bzKlanten.kl_id(klNummer)
        Dim sql As New sqlClass
        Dim tally As Integer = sql.Execute("select Adr_Telefoon from Adres where Adr_klant = " & id & " and adr_Facturatie = true ")
        If tally = 1 Then Return cNvl(sql.dt(0)("Adr_Telefoon"))
        Return ""
    End Function
    Public Shared Function getKlNummer(klid As Long) As String
        Dim context As New sqlClass
        Return context.ExecuteScalar("select kl_Nummer from Klanten where kl_id = " & klid)
    End Function
End Class

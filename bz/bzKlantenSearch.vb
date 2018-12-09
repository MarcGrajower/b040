Imports System.Text
Public Class bzKlantenSearch
    Public Class clsKlantInfo
        Public Property Telefoon As String
        Public Property Adres As String
        Public Property PostNr As String
        Public Property Gemeente As String
        Public Property Fax As String
        Public Property GSM As String
        Public Property BTW_NR As String
        Public Property Type_Fact As String
    End Class
    Public Shared Sub GenerateFilter(input As String, fieldname As String, ByRef filter As String, ByRef success As Boolean, ByRef message As String)
        success = True
        message = ""
        filter = ""
        Dim rgx As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 -]")
        input = rgx.Replace(input, "").Trim
        If input = "" Then
            success = False
            message = "Invalid Input"
            Exit Sub
        End If
        Dim tokens As Array = Split(input, " ")
        Dim builder As New StringBuilder
        builder.Clear()
        For Each token In tokens
            builder.Append(fieldname & " like '%" & token & "%' and ")
        Next
        filter = builder.ToString()
        ' take out the 'and' operator in the last line.
        filter = Left(filter, Len(filter) - 4)
    End Sub
    ''' <summary>
    ''' Feeds the KlantenSearch 6127
    ''' [includeInactief default to false for Bestel.  For Klanten set to true]
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="klanten"></param>
    ''' <param name="includeInactief"></param>
    Public Shared Sub GetKlanten(input As String, ByRef klanten As DataTable, Optional includeInactief As Boolean = False)
        Dim filter As String = ""
        Dim success As Boolean
        Dim message As String = ""
        GenerateFilter(input, "KL_Naam & ' ' & Kl_Voornaam", filter, success, message)
        Dim sql As String
        sql = "select KL_Id,KL_Naam,Kl_Voornaam,iif(kl_Actief=true,'          ','Niet Actief') as actief  from Klanten where " & filter
        If includeInactief = False Then
            sql &= " and kl_actief = true "
        End If
        Dim b040 As New sqlClass()
        b040.Execute(sql)
        klanten = b040.dt.Copy()
    End Sub
    Public Shared Sub GetKlant(klid As Integer, klantInfo As clsKlantInfo)
        Dim sql As String
        sql = "select * from Klanten,Adres,TypeFact "
        sql &= " where adr_Klant = kl_id and adr_facturatie = true and TypF_id = Kl_FActuratie and kl_id = ? "
        Dim context As New sqlClass()
        context.parameterCollection.Add(New OleDb.OleDbParameter("?", klid))
        Dim count As Integer = context.Execute(sql)
        klantInfo.Telefoon = cNvl(context.dt(0)("Adr_Telefoon"))
        klantInfo.Adres = cNvl(context.dt(0)("Adr_Adres"))
        klantInfo.PostNr = cNvl(context.dt(0)("Adr_PostNummer"))
        klantInfo.Gemeente = cNvl(context.dt(0)("Adr_Gemeente"))
        klantInfo.Fax = cNvl(context.dt(0)("KL_Fax"))
        klantInfo.GSM = cNvl(context.dt(0)("KL_GSM"))
        klantInfo.BTW_NR = cNvl(context.dt(0)("KL_BTW"))
        klantInfo.Type_Fact = cNvl(context.dt(0)("TypF_Omschrijving"))
    End Sub
    ''' <summary>
    ''' tokenized search in klanten.kl_naam
    ''' </summary>
    ''' <param name="input">key in tokens (serparated by blanks)</param>
    ''' <param name="klid">klanten.kl_id or zero if not found, or if user escaped</param>
    Public Shared Sub SearchKlant(input As String, ByRef klid As Long, Optional includeInactief As Boolean = False)
        klid = 0
        Dim klanten As DataTable = New DataTable()
        bzKlantenSearch.GetKlanten(input, klanten, includeInactief)
        Select Case klanten.Rows.Count
            Case 0
            Case 1
                klid = CInt(klanten(0)(0))
            Case Else
                Dim f As New KlantenSearch
                f.klanten = klanten
                f.Activate()
                f.ShowDialog()
                klid = f.ReturnValue
        End Select
    End Sub
End Class

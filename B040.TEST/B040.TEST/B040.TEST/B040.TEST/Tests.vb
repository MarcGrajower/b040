Imports B040
Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Public Class Tests
    Public Shared Sub Test_Conversion()
        Dim d As Double = "8,5"
        Console.WriteLine(d + 1)
        Dim d1 As Decimal = "8.5"
        Console.WriteLine(d1 + 1)
    End Sub
    Public Shared Sub Test_ProductielijstInitialise()
        Productielijst.Initialise()
        Console.WriteLine("There are {0} items in the list", Productielijst.list.Count)
        Dim a As String = "1367"
        Dim m As New Productielijst.Model
        Dim found As Boolean = True
        m = Productielijst.GetModel(a)
        Console.WriteLine("The Group of Artikel {0} is {1}, its rank is {2}", a, m.Groep, m.Rank)
        a = " 444"
        m = Productielijst.GetModel(a)
        Console.WriteLine("The Group of Artikel {0} is {1}, its rank is {2}", a, m.Groep, m.Rank)
        a = "9999"
        m = Productielijst.GetModel(a, found)
        Console.WriteLine("The Group of Artikel {0} is {1}, its rank is {2}", a, m.Groep, m.Rank)
        Console.WriteLine("Artikel {0} was found is {1}", a, found)
    End Sub
    Public Shared Sub Test_GetArtId()
        Dim artnr As String
        artnr = " 451"
        Console.WriteLine("Key of {0} is {1}", artnr, bzArtikel.GetArtId(artnr))
    End Sub
    Public Shared Sub Test_GetPoductie()
        Dim artnr As String
        Dim d As Date
        artnr = " 451"
        d = Today.AddDays(1)
        Console.WriteLine("Winkel productie voor {0} voor artikel {1} is {2}", d, artnr, BzWinkelproductie.GetProductie(bzArtikel.GetArtId(artnr), d))
    End Sub
    Public Shared Sub Test_GetWinkelproductieKlantenNummer()
        Console.WriteLine(modB040Config.Generic("WINKELPRODUCTIE_KLANTENNUMMER"))
    End Sub
    Public Shared Sub Test_GetKlant()
        Dim klid As Integer
        Dim klantInfo As New bzKlantenSearch.clsKlantInfo
        klid = 33769
        bzKlantenSearch.GetKlant(klid, klantInfo)
        Console.WriteLine("[input] {0} return s[KL_Telefoon2] {1}", klid, klantInfo.Telefoon)
    End Sub
    Public Shared Sub Test_KlantenSearchForm()
        Dim input As String = "DAN KOR"
        Dim klid As Long = 0
        bzKlantenSearch.SearchKlant(input, klid)
        Console.WriteLine("ReturnValue : {0}", klid)
    End Sub
    Public Shared Sub Test_KlantSearchGenerateFilter()
        Dim filter As String = ""
        Dim success As Boolean = True
        Dim message As String = ""
        Dim input As String
        input = "Marc Grajower"
        bzKlantenSearch.GenerateFilter(input, "kl_Naam", filter, success, message)
        Console.WriteLine("[Input] {0} returns [filter] {1}, success = {2}, message = {3}", input, filter, success, message)
        input = ""
        bzKlantenSearch.GenerateFilter(input, "kl_Naam", filter, success, message)
        Console.WriteLine("[Input] {0} returns [filter] {1}, success = {2}, message = {3}", input, filter, success, message)
        input = "Marc"
        bzKlantenSearch.GenerateFilter(input, "kl_Naam", filter, success, message)
        Console.WriteLine("[Input] {0} returns [filter] {1}, success = {2}, message = {3}", input, filter, success, message)
    End Sub
    Public Shared Sub Test_GetKlanten()
        Dim klanten As New DataTable()
        Dim input As String
        input = "HEN MAN"
        bzKlantenSearch.GetKlanten(input, klanten)
        For Each dr As DataRow In klanten.Rows
            Console.WriteLine("{0},{1},{2}", dr("Kl_id"), dr("Kl_Voornaam"), dr("Kl_Naam"))
        Next
        Console.WriteLine("*---")
        input = "DAN KOR"
        bzKlantenSearch.GetKlanten(input, klanten)
        For Each dr As DataRow In klanten.Rows
            Console.WriteLine("{0},{1},{2}", dr("Kl_id"), dr("Kl_Voornaam"), dr("Kl_Naam"))
        Next
        Console.WriteLine("*---")
        input = "MARC"
        bzKlantenSearch.GetKlanten(input, klanten)
        For Each dr As DataRow In klanten.Rows
            Console.WriteLine("{0},{1},{2}", dr("Kl_id"), dr("Kl_Voornaam"), dr("Kl_Naam"))
        Next
        Console.WriteLine("*---")
        input = "MARC"
        bzKlantenSearch.GetKlanten(input, klanten, True)
        For Each dr As DataRow In klanten.Rows
            Console.WriteLine("{0},{1},{2}", dr("Kl_id"), dr("Kl_Voornaam"), dr("Kl_Naam"))
        Next
    End Sub
    Public Shared Sub Test_xlPatternAutomatic()
        Console.WriteLine("xlPatternAutomatic : {0}", Excel.XlPattern.xlPatternAutomatic)
    End Sub
End Class

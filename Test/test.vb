Imports System
Imports System.Globalization

Public Class printClass
    Public Shared Sub Main()
        Dim ci As CultureInfo
        For Each ci In _
        CultureInfo.GetCultures(CultureTypes.AllCultures)
            Console.WriteLine(ci)
        Next ci
    End Sub
    Public Shared Sub test()
        Dim o As New bzKlanten
        Debug.Print(o.Kl_NummerExists("  125"))
    End Sub
End Class

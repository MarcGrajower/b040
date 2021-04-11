Imports System.Text
Public Class MaandelijkseFacturatiStatistieken
    Sub New(year As Integer, month As Integer)
        SetYear(year)
        SetMonth(month)
    End Sub

    Public Shared Sub SetYear(year As Int16)
        _Year = year
    End Sub
    Public Shared Sub SetMonth(month As Int16)
        _Month = month
    End Sub
    Public Shared Function GetRowCount() As Int16
        Return _RowsCount
    End Function
    Public Shared Sub GetData(year As Integer, month As Integer)
        _Year = year
        _Month = month
        Dim sql As New StringBuilder()
        sql.Append("Select Kategorie.Kat_Naam, Artikel.art_omschrijving, ")
        sql.Append("Artikel.Art_Nr, Sum([FactD_Hoev] * 10 ^ [Eenh_Exponent]) As Expr3, ")
        sql.Append("Eenheden.Eenh_omschrijving, Artikel.Art_Prijs, ")
        sql.Append("Sum(FactD.FactD_Waarde) As SumOfFactD_Waarde, ")
        sql.Append("Sum(([FactD_Waarde] - [FactD_Korting]) / (1 + [Art_BTW] / 100)) As Expr2 ")
        sql.Append("From Eenheden ")
        sql.Append("INNER Join( ")
        sql.Append("((FactD INNER Join FactH ")
        sql.Append("On FactD.FactD_FactH = FactH.FactH_ID) ")
        sql.Append("INNER Join Artikel On FactD.FactD_Artikel = Artikel.ARt_Id) ")
        sql.Append("INNER Join Kategorie On Artikel.Art_Kategorie = Kategorie.Kat_ID) ")
        sql.Append("On Eenheden.Eenh_id = Artikel.Art_Eenheid ")
        sql.Append("Group By Kategorie.Kat_Naam, Artikel.art_omschrijving, ")
        sql.Append("Artikel.Art_Nr, Eenheden.Eenh_omschrijving, Artikel.Art_Prijs, ")
        sql.Append("Year([FactH]![FactH_Datum]), Month([FactH]![FactH_Datum]) ")
        sql.Append("HAVING(((Year(FactH!FactH_Datum)) = ?) And ((Month(FactH!FactH_Datum)) = ?))")
        Dim cmd = New sqlClass
        cmd.AddParameter(_Year, DbType.Int16)
        cmd.AddParameter(_Month, DbType.Int16)
        Dim unused = cmd.Execute(sql.ToString)
        _RowsCount = cmd.dt.Rows.Count
        _Dt = cmd.dt
    End Sub
    Public Shared Function GetMonthString() As String
        Dim rv As String = ""
        Dim shortMonths As String() = New String() {"jan", "feb", "maart", "apr", "jun", "jul", "aug", "sep", "okt", "nov", "dec"}
        rv = $"{shortMonths(_Month - 1)}/{_Year}"
        Return rv
    End Function
    Public Shared Function GetDataTable() As DataTable
        Return _Dt
    End Function
    Shared _Year As Int16 = 2021
    Shared _Month As Int16 = 2
    Shared _RowsCount As Int16
    Shared _Dt As DataTable
End Class

Public Class Index
    Public nKL_Id As Long
    Public nBTW As Double
    Public nPercent As Double
    Public cTable As String
    Public nExPost As Double
    Public nArt_id As Long
    Public oSqlInvoice As New sqlClass
    Public oSqlArtikel As New sqlClass
    Dim nExAnte As Double
    Dim cFilter As String
    Dim nTarget As Double
    Dim nExcluded As Double
    Dim nByWeight As Double
    Dim nOther As Double
    Dim nApply As Double
    Public Sub recompute()
        Dim osql As New sqlClass
        Me.cFilter = "besth_Klant = " & Me.nKL_Id & " and Art_BTW = " & sqlClass.cDoubleForjet(Me.nBTW)
        Dim c As String = "select sum(Netto) as total from " & Me.cTable & " where " & cFilter & " group by besth_Klant, art_btw"
        Me.nExAnte = gen.nNvlD(osql.ExecuteScalar(c))
        If Me.nPercent = 1 Then
            c = "update " & Me.cTable
            c &= " set expostBedrag = netto, expostHoev = bestd_Hoev1"
            c &= " where " & Me.cFilter
            osql.ExecuteNonQuery(c)
            Me.nExPost = Me.nExAnte
            Exit Sub
        End If
        Me.nTarget = Me.nExAnte * Me.nPercent
        Me.computeExcluded()
        Me.setExcluded()
        Me.computeOther()
        Me.nApply = Me.nPercent
        If Me.nOther <> 0 Then Me.nApply = Me.nPercent - Me.nExcluded / Me.nOther * (1 - Me.nPercent)
        Me.setNulBedrag()
        Me.setNulHoev()
        Me.setAll()
        ' Me.setPerGewicht()
        '
        c = "select sum(exPostBedrag) as total from " & Me.cTable & " where " & cFilter & " group by besth_Klant, art_btw"
        Me.nExPost = gen.nNvlD(osql.ExecuteScalar(c))
    End Sub
    Public Sub loadInvoice()
        Me.cFilter = "besth_Klant = " & Me.nKL_Id & " and Art_BTW = " & sqlClass.cDoubleForjet(Me.nBTW)
        Dim c As String = "select bestd_Artikel, art_Nr, art_omschrijving, eenh_omschrijving,kat_productieplan, sum(expostHoev) as hoev, sum(expostBedrag) as bedrag "
        c &= " from " & Me.cTable
        c &= " where " & cFilter
        c &= " group by bestd_Artikel, art_Nr, art_omschrijving,eenh_omschrijving,kat_productieplan"
        c &= " order by eenh_omschrijving, kat_productieplan, Art_Omschrijving"
        Me.oSqlInvoice.Execute(c)
    End Sub
    Public Sub loadArtikel()
        Dim c As String
        c = "select besth_docnr"
        c &= ",besth_datlevering"
        c &= ",bestd_omschrijving"
        c &= ",bestd_hoev1"
        c &= ",netto"
        c &= ",exposthoev"
        c &= ",expostbedrag"
        c &= ",bestd_id"
        c &= " from " & Me.cTable
        c &= " where besth_Klant = " & Me.nKL_Id & " and bestd_Artikel = " & Me.nArt_id
        c &= " order by besth_datlevering, besth_Docnr"
        Me.oSqlArtikel.Execute(c)

    End Sub
    Sub computeExcluded()
        Dim c As String
        Dim osql As New sqlClass
        Me.cFilter = "besth_Klant = " & Me.nKL_Id & " and Art_BTW = " & sqlClass.cDoubleForjet(Me.nBTW)
        c = "select sum(netto) from " & Me.cTable & " where " & cFilter & " and kat_naam like " & sqlClass.cLike("Groothandel")
        Me.nExcluded = gen.nNvlD(osql.ExecuteScalar(c))
    End Sub
    Sub computeOther()
        Dim c As String
        Dim osql As New sqlClass
        Me.cFilter = "besth_Klant = " & Me.nKL_Id & " and Art_BTW = " & sqlClass.cDoubleForjet(Me.nBTW)
        c = "select sum(netto) from " & Me.cTable
        c &= " where " & cFilter
        c &= " and kat_naam not like " & sqlClass.cLike("Groothandel")
        c &= " and eenh_omschrijving like " & sqlClass.cLike("stuk")
        Me.nOther = gen.nNvlD(osql.ExecuteScalar(c))
    End Sub

    Sub setExcluded()
        Dim c As String
        Dim osql As New sqlClass
        c = "update " & Me.cTable
        c &= " set expostBedrag = netto, expostHoev = bestd_Hoev1"
        c &= " where " & Me.cFilter & " and kat_naam like " & sqlClass.cLike("Groothandel")
        osql.ExecuteNonQuery(c)
    End Sub
    Sub setAll()
        Dim c As String
        Dim osql As New sqlClass

        c = "update " & Me.cTable
        c &= " set expostHoev = round(bestd_hoev1 * " & sqlClass.cDoubleForjet(Me.nApply) & ",0)"
        c &= " where " & Me.cFilter
        c &= " and kat_naam not like " & sqlClass.cLike("Groothandel")
        c &= " and eenh_omschrijving like " & sqlClass.cLike("stuk")
        c &= " and Netto <> " & 0
        c &= " and bestd_hoev1 <> " & 0
        osql.ExecuteNonQuery(c)

        Dim nMod As Long = Math.Round(1 / Me.nApply)
        If nMod <> 0 Then
            c = "update " & Me.cTable
            c &= " set expostHoev = 1"
            c &= " where " & Me.cFilter
            c &= " and kat_naam not like " & sqlClass.cLike("Groothandel")
            c &= " and eenh_omschrijving like " & sqlClass.cLike("stuk")
            c &= " and Netto <> " & 0
            c &= " and bestd_hoev1 <> " & 0
            c &= " and expostHoev = 0"
            c &= " and bestd_id mod " & nMod & " = 1"
            osql.ExecuteNonQuery(c)
        End If

        c = "update " & Me.cTable
        c &= " set expostHoev = round( bestd_hoev1 * " & sqlClass.cDoubleForjet(Me.nPercent) & ",0)"
        c &= " where " & Me.cFilter
        c &= " and kat_naam not like " & sqlClass.cLike("Groothandel")
        c &= " and eenh_omschrijving like " & sqlClass.cLike("kg")
        c &= " and Netto <> " & 0
        c &= " and bestd_hoev1 <> " & 0
        osql.ExecuteNonQuery(c)

        c = "update " & Me.cTable
        c &= " set expostBedrag = expostHoev * netto/bestd_hoev1"
        c &= " where " & Me.cFilter
        c &= " and kat_naam not like " & sqlClass.cLike("Groothandel")
        c &= " and Netto <> " & 0
        c &= " and bestd_hoev1 <> " & 0
        osql.ExecuteNonQuery(c)
    End Sub
    Sub setNulBedrag()
        Dim c As String
        Dim osql As New sqlClass
        c = "update " & Me.cTable
        c &= " set expostHoev = " & 0
        c &= ", expostBedrag = " & 0
        c &= " where " & Me.cFilter
        c &= " and kat_naam not like " & sqlClass.cLike("Groothandel")
        c &= " and Netto = " & 0
        osql.ExecuteNonQuery(c)
    End Sub
    Sub setNulHoev()
        Dim c As String
        Dim osql As New sqlClass
        c = "update " & Me.cTable
        c &= " set expostHoev = " & 0
        c &= ", expostBedrag = netto * " & sqlClass.cDoubleForjet(Me.nApply)
        c &= " where " & Me.cFilter
        c &= " and kat_naam not like " & sqlClass.cLike("Groothandel")
        c &= " and bestd_Hoev1 = " & 0
        osql.ExecuteNonQuery(c)
    End Sub


End Class

Module KategorieMod
    Public Sub KategorieFillCbo(ByRef cbo As cboBase)
        Dim Da As New KategorieDSTableAdapters.KategorieTableAdapter
        Dim dt As New KategorieDS.KategorieDataTable
        Dim n As Integer = Da.Fill(dt)
        For Each row As KategorieDS.KategorieRow In dt
            cbo.Items.Add(row("Kat_Naam"))
        Next
    End Sub
    Public Function kategorieFromNaam(ByVal c As String) As Integer
        Dim Da As New KategorieDSTableAdapters.KategorieTableAdapter
        kategorieFromNaam = Da.KategorieFromNaamScalarQuery(c)
    End Function
End Module

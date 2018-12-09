Module EenhedenMod
    Dim Da As New EenhedenDSTableAdapters.EenhedenTableAdapter
    Dim dt As New EenhedenDS.EenhedenDataTable
    Public Sub EenhedenFillCbo(ByRef cbo As cboBase)
        Dim Da As New EenhedenDSTableAdapters.EenhedenTableAdapter
        Dim dt As New EenhedenDS.EenhedenDataTable
        dt = Da.GetAll
        For Each row As EenhedenDS.EenhedenRow In dt
            cbo.Items.Add(row("Eenh_Omschrijving"))
        Next
    End Sub
    Public Function EenhedenFromOmschrijving(ByVal c As String) As Integer
        Dim Da As New EenhedenDSTableAdapters.EenhedenTableAdapter
        Return Da.EenhedenFromOmschrijvingScalarQuery(c)
    End Function
    Public Function Eenh_HoevInvoer(ByVal pk As Long) As String
        Dim o As New bzEenheden
        o.Eenh_id = pk
        Return o.record("Eenh_HoevInvoer")
    End Function
End Module
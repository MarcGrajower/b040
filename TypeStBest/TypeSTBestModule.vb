Module TypeSTBestModule

    Public Sub TypSTBestFillCbo(ByRef cbo As cboBase)
        Dim Da As New TypeStBestDSTableAdapters.TypeStBEstTableAdapter
        Dim dt As New TypeStBestDS.TypeStBEstDataTable
        Dim n As Integer = Da.Fill(dt)
        For Each row As TypeStBestDS.TypeStBEstRow In dt
            cbo.Items.Add(row("TypSB_Omschrijving"))
        Next
    End Sub
    Public Function TypeSTBestFromOmschrijving(ByVal c As String) As Integer
        Dim Da As New TypeStBestDSTableAdapters.TypeStBEstTableAdapter
        Return Da.TypeStBEstFromOmschrijvingScalarQuery(c)
    End Function
 
End Module
Module StandaardNr
    Public StandaardNrErrMsg As String = "Gelieve 1,2 of 3 in te vullen voor Standaard Type"
    Public Function checkStandaardNr(ByVal c As String) As Boolean
        If c = "1" Then Return True
        If c = "2" Then Return True
        If c = "3" Then Return True
        Return False
    End Function
End Module
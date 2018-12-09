Module NummersModule
    Dim ds As New NummersDS
    Dim da As New NummersDSTableAdapters.NummersTableAdapter
    Public Function getNextNummer(ByVal cTable As String) As Long
        Dim n As Integer = da.Fill(ds.Nummers, cTable)
        If n <> 1 Then
            Throw New InvalidOperationException("Gelieve Nummers bestand na te zien.  Vind geen volgend nummer voor " & cTable)
        End If
        Dim r As DataRow = ds.Nummers.Rows(0)
        Dim i As Double = r("Num_Next")

        getNextNummer = i
        r("Num_Next") = i + 1
        da.Update(ds.Nummers)
    End Function
End Module

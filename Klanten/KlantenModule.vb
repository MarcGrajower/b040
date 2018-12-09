Module KlantenModule
    Public Function Kl_Id(ByVal Kl_Nr As String) As Long
        Kl_Id = 0
        ' Dim ds As New KlantenDS
        Dim da As New KlantenDSTableAdapters.KlantenTA

        Dim v = da.KlantenFromNummerScalarQuery(Kl_Nr)
        If v IsNot Nothing Then
            Kl_Id = CType(v, Long)
        End If

    End Function
    Public Function KL_Naam(ByVal kl_id As Long) As String
        'Dim ds As New KlantenDS
        Dim da As New KlantenDSTableAdapters.KlantenTA

        Dim v = da.KlNaamScalarQuery(kl_id)
        If v Is Nothing Then
            Throw New InvalidOperationException("Klant naam kon niet opgevraagd worden. " & vbCrLf & "Kl_Id  = " & kl_id)
        End If
        KL_Naam = CType(v, String)
    End Function
End Module

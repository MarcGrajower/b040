Module StandaardenModule
    Public Function StandaardFromKlantTypeStandaardType(ByVal kl As Long, ByVal t As String, ByVal stType As Long) As Long
        Dim o As New bzStandaarden
        If o.Exists(kl, t, stType) Then Return o.pk Else Return CType(0, Long)
    End Function
End Module

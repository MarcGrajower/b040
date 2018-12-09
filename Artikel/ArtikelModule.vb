Module ArtikelModule
    Public Function getNextArt_Nr() As String
        getNextArt_Nr = CType(getNextNummer("ARTIKEL"), String)
    End Function
    Public Function Art_Id(ByVal Art_Nr As String) As Long
        Art_Id = 0
        Dim ds As New dsArtikel
        Dim da As New dsArtikelTableAdapters.ArtikelTableAdapter

        Dim v = da.ArtikelFromNrScalarQuery(Art_Nr)
        If v IsNot Nothing Then
            Art_Id = CType(v, Integer)
        End If

    End Function
    Public Function Art_fromCode(ByVal c As String) As Long
        Dim ds As New dsArtikel
        Dim da As New dsArtikelTableAdapters.ArtikelTableAdapter
        Dim dt As dsArtikel.ArtikelDataTable = da.ArtikelDSFromAlphacode(c)
        Dim n As Long = 0
        If dt.Count = 1 Then
            n = dt(0)("art_id")
        End If


        Return n
    End Function
    Public Function Art_Nr(ByVal id As Long) As String
        Dim ds As New dsArtikel
        Dim da As New dsArtikelTableAdapters.ArtikelTableAdapter
        Dim dt As dsArtikel.ArtikelDataTable = da.GetData(id)
        Dim n As Long
        If dt.Count = 1 Then
            n = dt(0)("art_nr")
        End If
        Return n
    End Function
    Public Function ARt_AlphacodeExists(ByVal c As String, Optional ByVal pk As Long = 0) As Boolean
        Dim ds As New dsArtikel
        Dim da As New dsArtikelTableAdapters.ArtikelTableAdapter
        Dim v = da.Art_AlphacodeExistsScalarQuery(pk, c)
        If v Is Nothing Then
            Return False
        End If
        Return True
    End Function
End Module

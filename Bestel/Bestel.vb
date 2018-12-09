Public Class Bestel
    Public Class Tour
        Dim t1 As String
        Public Shared ErrorMsg As String = "Gelieve een tour tussen '1' en '9' te willen invullen."
        Public Shared Function Valid(ByVal T As String) As Boolean
            If T = "1" Then Return True
            If T = "2" Then Return True
            If T = "3" Then Return True
            If T = "4" Then Return True
            If T = "5" Then Return True
            If T = "6" Then Return True
            If T = "7" Then Return True
            If T = "8" Then Return True
            If T = "9" Then Return True
            Return False
        End Function
        Public Shared Function cLastTour(nBestH_id As Long, Optional detailTable As String = "BESTD") As String
            Dim o As New sqlClass
            Dim c As String
            c = "select max(bestd_tour) "
            c &= "from " & detailTable & " "
            c &= "where Bestd_besth = " & nBestH_id
            Return o.ExecuteScalar(c)
        End Function
    End Class
End Class

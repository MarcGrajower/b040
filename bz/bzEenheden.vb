Public Class bzEenheden
    Public Da As New EenhedenDSTableAdapters.EenhedenTableAdapter
    Public dt As New EenhedenDS.EenhedenDataTable
    Public record As EenhedenDS.EenhedenRow
    Public Property Eenh_id() As Long
        Get
            Return record("Eenh_id")
        End Get
        Set(ByVal value As Long)
            Dim i As Integer = Me.Da.Fill(Me.dt, value)
            If i <> 1 Then Throw New InvalidOperationException("Could not load eenheden record")
            Me.record = Me.dt(0)
        End Set
    End Property
    Public Shared Function getExponent(ByVal nEenh_Id As Long) As Integer
        Dim o As New bzEenheden : o.Eenh_id = nEenh_Id : Return o.record("Eenh_Exponent")
    End Function
    Public Shared Function isGewicht(Eenheid_id As Long) As Boolean
        Return (Eenheid_id = 1)
    End Function
End Class

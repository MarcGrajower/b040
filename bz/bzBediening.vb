Public Class bzBediening
    Public da As New BedieningDSTableAdapters.BedieningTableAdapter
    Public dt As New BedieningDS.BedieningDataTable
    Public record As BedieningDS.BedieningRow
    Public cDefault As String = "Niet Toegewezen"
    Public Sub fillCbo(ByVal ctl As cboBase)
        Dim bediening As New sqlClass
        bediening.Execute("select * from bediening")
        For Each r As DataRow In bediening.dt.Rows
            ctl.Items.Add(r("Bed_naam"))
        Next
    End Sub
    Public Property bed_Naam() As String
        Get
            Return Me.record.BEd_naam
        End Get
        Set(ByVal value As String)
            Dim v = Me.da.bed_id(value)
            If v Is Nothing Then v = 9 ' Niet toegewezen
            Me.da.Fill(Me.dt, CType(v, Long))
            Me.record = Me.dt(0)
        End Set
    End Property
    Public Property bed_id() As Long
        Get
            Return Me.record.Bed_id
        End Get
        Set(ByVal value As Long)
            Me.da.Fill(Me.dt, value)
            Me.record = Me.dt(0)
        End Set
    End Property
    Shared Function id(ByVal cNaam As String) As Long
        Dim oSql As New sqlClass
        Return osql.ExecuteScalar("select bed_id from bediening where bed_naam = '" & cNaam & "'")
    End Function
End Class

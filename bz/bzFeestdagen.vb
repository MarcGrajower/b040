Public Class bzFeestdagen
    Dim ds As New FeestdagenDataset
    Dim da As New FeestdagenDatasetTableAdapters.FeestdagenTableAdapter
    Public dt As New FeestdagenDataset.FeestdagenDataTable
    Dim pk As Long
    Public record As FeestdagenDataset.FeestdagenRow
    Public cNaam As String
    Public Property fd_datum() As Date
        Get
            Return record.FD_Datum.Date
        End Get
        Set(ByVal value As Date)
            Dim osql As New sqlClass
            Dim v = osql.ExecuteScalar("select id from feestdagen where fd_datum = " & sqlClass.cDateForJet(value))
            If v Is Nothing Then Throw New InvalidOperationException(value & " is not a Feestdag")
            pk = CType(v, Integer)
            Me.da.Fill(Me.dt, value)
            Me.record = Me.dt(0)
        End Set
    End Property
    Function isFeesdag(ByVal d As Date) As Boolean
        Dim osql As New sqlClass
        Dim n As Integer = osql.Execute("select * from feestdagen where fd_datum = " & sqlClass.cDateForJet(d))
        If n = 0 Then Return False
        Me.fd_datum = osql.dt(0)("fd_datum")
        Me.cNaam = osql.dt(0)("fd_naam")
        Return True
    End Function
    Public Function volgende(ByVal d As Date) As String
        Dim v = Me.da.Fd_DatumNa(d)
        If v Is Nothing Then Return "Geen Feestdagen meer geregistreerd"
        Me.fd_datum = CType(v, Date)
        Return Format(Me.record.FD_Datum, cDateFormat) & " " & Me.record.FD_Naam
    End Function
    Shared Function lFeestdag(ByVal d As Date) As Boolean
        Dim osql As New sqlClass
        Dim n As Integer = osql.Execute("select * from feestdagen where fd_datum = " & sqlClass.cDateForJet(d))
        If n = 0 Then Return False
        Return True
    End Function
End Class

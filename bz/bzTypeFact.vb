Public Class bzTypeFact
    Public da As New TypeFactDSTableAdapters.TypeFactTableAdapter
    Public dt As New TypeFactDS.TypeFactDataTable
    Public record As TypeFactDS.TypeFactRow
    Public Enum TypeFact
        Groothandel
        Partikulier
    End Enum
    Public Sub fillcbo(ByVal ctl As cboBase)
        dt = da.GetDataCBO()
        For Each r As TypeFactDS.TypeFactRow In dt
            ctl.Items.Add(r.TYPF_OMSCHRIJVING)
        Next
    End Sub
    Public Property typF_Omschrijving() As String
        Get
            Return Me.record.TYPF_OMSCHRIJVING
        End Get
        Set(ByVal value As String)
            Dim v = Me.da.typF_id(value)
            If v Is Nothing Then v = 5 ' Particulier
            Me.da.Fill(Me.dt, CType(v, Long))
            Me.record = Me.dt(0)
        End Set
    End Property
    Public Shared Function getKlantType(klantNummer As String) As String
        If cNvl(klantNummer) = "" Then
            Return "Groothandel"
        End If
        Dim db As New sqlClass
        If db.Execute("select typF_omschrijving from klanten,typeFact where typF_id = kl_Facturatie and kl_Nummer = " & sqlClass.c(klantNummer)) = 0 Then
            Return "Groothandel"
        End If
        Return db.dt(0)("typF_omschrijving")
    End Function
    Public Shared Function klantType(klid As Long) As String
        Return bzTypeFact.getKlantType(bzKlanten.cNummer(klid))
    End Function
    Public Shared Function typefactEnum(typeFactString As String) As bzTypeFact.TypeFact
        Return IIf(typeFactString = "Groothandel", bzTypeFact.TypeFact.Groothandel, bzTypeFact.TypeFact.Partikulier)
    End Function
    Public Shared Function headerTablename(typeFact As bzTypeFact.TypeFact) As String
        Return IIf(typeFact = bzTypeFact.TypeFact.Groothandel, "BESTH", "PH")
    End Function
    Public Shared Function headerTablename(klid As Long) As String
        Return bzTypeFact.headerTablename(bzTypeFact.typefactEnum(bzTypeFact.klantType(klid)))
    End Function
    Public Shared Function detailTablename(typeFact As bzTypeFact.TypeFact) As String
        Return IIf(typeFact = bzTypeFact.TypeFact.Groothandel, "BESTD", "PD")
    End Function
    Public Shared Function detailTablename(klid As Long) As String
        Return bzTypeFact.detailTablename(bzTypeFact.typefactEnum(bzTypeFact.klantType(klid)))
    End Function
End Class

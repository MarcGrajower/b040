Imports System.Math
Public Class bzPrice
    ' MG 21/feb/11
    Public oArt As New bzArtikel
    Public oKl As New bzKlanten
    Public WriteOnly Property artikel() As String
        Set(ByVal value As String)
            oArt.Art_Nr = value
        End Set
    End Property
    Public WriteOnly Property klant() As String
        Set(ByVal value As String)
            oKl.kl_nummer = value
        End Set
    End Property
    Public h As Double ' hoeveelheid
    Public nTotaal As Double
    Public nKorting As Double
    Public nBelastbaar As Double
    Public nBTW As Double
    Public nTeBetalen As Double
    Public nKortingPct As Double

    Public Sub compute()
        Dim w As Double : w = Me.oArt.Waarde(nRound(Me.h, 2))
        Me.compute(Me.oArt.Waarde(nRound(Me.h, 2)))
    End Sub
    Public Sub compute(ByVal w As Double)
        Dim cSql As String
        cSql = "select kk_korting from klantenkorting "
        cSql &= "where kk_artikel = " & oArt.Record.ARt_Id & " "
        cSql &= "and kk_klant = " & oKl.record.KL_ID
        Dim nKK As Double : Dim lKK As Boolean
        Dim sql As New sqlClass
        sql.conn = Me.oArt.da.Connection
        Dim v = sql.Execute(cSql)
        If v = Nothing Then
            lKK = False
            nKK = 0
        Else
            lKK = True
            nKK = sql.dt(0)("kk_Korting")
        End If
        bzPrice.QuickCompute(w, Me.oKl.record.KL_BTWType, Me.oKl.record.KL_Korting, Me.oArt.Record.Art_BTW, Me.oArt.Record.Art_Korting, nKK, lKK, _
                             Me.nTeBetalen, Me.nKorting, Me.nBTW, Me.nBelastbaar, Me.nTotaal, Me.nKortingPct)
    End Sub
    Shared Sub QuickCompute(ByVal nWaarde As Double, _
                            ByVal nKL_BTWType As Long, _
                            ByVal nKL_Korting As Double, _
                            ByVal nArt_BTW As Double, _
                            ByVal lArt_Korting As Boolean, _
                            ByVal nKK_korting As Double, _
                            ByVal lKK_Korting As Boolean, _
                            ByRef nTebetalen As Double, _
                            ByRef nKortingBedrag As Double, _
                            ByRef nBTW As Double, _
                            ByRef nBelastbaar As Double, _
                            ByRef nTotaal As Double, _
                            ByRef nKortingPCT As Double)

        Dim lEU As Boolean = (nKL_BTWType <> 1)
        If lEU Then nWaarde /= (1 + nArt_BTW / 100)
        nTotaal = gen.nRound(nWaarde, 2)
        nKortingPCT = IIf(lArt_Korting, IIf(lKK_Korting, nKK_korting, nKL_Korting), 0) / 100
        nKortingBedrag = nTotaal * nKortingPCT
        nTebetalen = gen.nRound(nTotaal - nKortingBedrag, 2)
        nBTW = gen.nRoundup((IIf(lEU, 0, (nTebetalen * nArt_BTW / 100) / (1 + nArt_BTW / 100))), 2)
        nBelastbaar = nTebetalen - nBTW
    End Sub

End Class

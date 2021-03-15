Public Class frmArtikel
    Inherits frmB040
    Dim loadPK As Long
    Dim alphacodeFound As Boolean

    Private Sub frmArtikel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.PageDown Then
            If Me.FormMode <> ModeValues.KeyEntry Then Exit Sub
            Dim oNext As New sqlClass
            Dim cNext As String
            cNext = "select Art_nr from Artikel where Art_nr > " & sqlClass.c(Me.txtArt_Nr.Text) & " order by Art_Nr"
            Dim nNext = oNext.Execute(cNext)
            If nNext = 0 Then
                cNext = "select Art_nr from Artikel order by Art_Nr"
                oNext.Execute(cNext)
            End If
            Me.txtArt_Nr.Text = oNext.dt(0)("Art_nr")
            Me.lLoadArtikel()
            Me.TxtArtSearch.Visible = False
            Me.txtArt_Nr.Focus()
            Return
        End If
        If e.KeyCode = Keys.PageUp Then
            If Me.FormMode <> ModeValues.KeyEntry Then Exit Sub
            Dim oPrev As New sqlClass
            Dim cPrev As String
            cPrev = "select Art_nr from Artikel where Art_nr < " & sqlClass.c(Me.txtArt_Nr.Text) & " order by Art_Nr desc"
            Dim nPrev = oPrev.Execute(cPrev)
            If nPrev = 0 Then
                cPrev = "select Art_nr from Artikel order by Art_Nr desc"
                oPrev.Execute(cPrev)
            End If
            Me.txtArt_Nr.Text = oPrev.dt(0)("Art_nr")
            Me.lLoadArtikel()
            Me.TxtArtSearch.Visible = False
            Me.txtArt_Nr.Focus()
            Return
        End If
        If e.KeyCode = Keys.End Then
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            Me.SaveButton_Click(sender, e)
            Return
        End If
    End Sub
    Private Sub frmArtikel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsArtikel1.Kategorie' table. You can move, or remove it, as needed.
        'TODO: This line of code loads data into the 'DsArtikel1.Artikel' table. You can move, or remove it, as needed.
        KategorieFillCbo(Me.Kat_Naamcbo)
        EenhedenFillCbo(Me.Eenh_OmschrijvingCbo)
        Me.clear()
    End Sub
    Private Sub TxtArtSearch_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtArtSearch.Validating
        Dim Input As String = TxtArtSearch.Text
        If Me.lastKeycode = Keys.Tab And input = "" Then
            Me.txtArt_Nr.Text = getNextArt_Nr()
            Me.TxtArt_Alphacode.nIO = IOValues.IORecordEntryEnable
            Me.FormMode = ModeValues.RecordEntry
            Me.TxtArtSearch.Visible = False

            Me.txtArt_omschrijving.Focus()
            Me.FormMode = Me.FormMode
            Exit Sub
        End If
        If Me.lastKeycode <> Keys.Tab And input = "" Then Exit Sub
        Dim obzArtSearch As New bzArtikel.clsSearch
        With obzArtSearch
            .cInput = TxtArtSearch.Text
            .oCaller = Me.TxtArtSearch
            .nFieldLength = Me.txtArt_Nr.fieldLength
            .search()
            If .lFound = True Then
                Me.txtArt_Nr.Text = .cArtNr
                If Me.lLoadArtikel = False Then
                    e.Cancel = True
                    Exit Sub
                End If
                Me.TxtArtSearch.Visible = False
                Me.txtArt_omschrijving.Focus()
                Me.FormMode = Me.FormMode
                Exit Sub
            End If
            e.Cancel = True
            If .lUserCanceled = False Then
                MsgBox(.cMessage)
            End If
        End With
    End Sub
    Function lLoadArtikel() As Boolean
        Dim n As Long = Art_Id(Me.txtArt_Nr.Text)
        If n = 0 Then
            MsgBox("Artikel nr " & Me.txtArt_Nr.Text & " bestaat niet.")
            Return False
        End If
        Dim n1 As Integer = Me.ArtikelTableAdapter.Fill(Me.DsArtikel1.Artikel, n)
        If n1 <> 1 Then
            Throw New InvalidOperationException("Artikel kon niet opgevraagd worden. " & vbCrLf & "Art_Id  = " & n & " Art_nr = " & Trim(Me.TxtArtSearch.Text))
            Exit Function
        End If
        Me.txtArt_Nr.previousText = Me.txtArt_Nr.Text
        Me.loadPK = n
        Return True
    End Function

    Private Sub txtArt_Nr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtArt_Nr.Validating
        Dim input As String = txtArt_Nr.Text
        If Me.lastKeycode = Keys.Tab And input = "" Then
            Me.txtArt_Nr.Text = getNextArt_Nr()
            Me.txtArt_omschrijving.Focus()
            Me.TxtArt_Alphacode.nIO = IOValues.IORecordEntryEnable
            Me.FormMode = ModeValues.RecordEntry
            Me.txtArt_omschrijving.Focus()
            Exit Sub
        End If
        If Me.lastKeycode = Keys.Tab Then
            If input = Me.txtArt_Nr.previousText Then
                If lLock(Me.nLogSession, "Artikel", Me.loadPK, "") Then
                    Me.FormMode = ModeValues.RecordEntry

                    Me.txtArt_omschrijving.Focus()
                Else
                    e.Cancel = True
                End If
                Exit Sub
            End If
        End If
        If Me.lastKeycode <> Keys.Tab And input = "" Then Exit Sub
        Dim n As Long = Val(input)
        If n = 0 Then
            MsgBox("Artikel nummers zijn numerisch. [" & input & "]")
            e.Cancel = True
            Exit Sub
        End If

        Me.txtArt_Nr.Text = Strings.RSet(Me.txtArt_Nr.Text, Me.txtArt_Nr.fieldLength)
        n = Art_Id(Me.txtArt_Nr.Text)
        If n = 0 Then
            MsgBox("Artikel nr " & Me.txtArt_Nr.Text & " bestaat niet.")
            e.Cancel = True
            Exit Sub
        End If
        Dim n1 As Integer = Me.ArtikelTableAdapter.Fill(Me.DsArtikel1.Artikel, n)
        If n1 <> 1 Then
            Throw New InvalidOperationException("Artikel kon niet opgevraagd worden. " & vbCrLf & "Art_Id  = " & n & " Art_nr = " & input)
        End If
        Me.TxtArt_Alphacode.nIO = IOValues.IORecordEntryEnable
        Me.TxtArt_Alphacode.ioEnable(Me.FormMode)
        Me.txtArt_Nr.previousText = Me.txtArt_Nr.Text
        Me.loadPK = n
        Me.txtArt_Nr.Focus()

    End Sub
    Public Overrides Sub clear()
        MyBase.clear()
        Me.DsArtikel1.Clear()
        Me.BindingSource1.AddNew()
        Me.Art_VerwittigenGewichtCtl.nIO = IOValues.IORecordEntryEnable
        Me.Art_PerpersoonCtl.nIO = IOValues.IORecordEntryEnable
        Me.Art_PortieCtl.nIO = IOValues.IORecordEntryEnable
        Me.Art_ActiefCtl.Checked = True
        Me.Art_BTW.Text = "6,00"
        Me.FormMode = ModeValues.KeyEntry
        unlockSession(Me.nLogSession)
        Me.loadPK = 0
        Me.alphacodeFound = False
        If Me.eOpenMode = eFormOpen.eFromOpenNew Then
            Me.txtArt_Nr.Text = ArtikelModule.getNextArt_Nr
            Me.FormMode = ModeValues.RecordEntry
            Me.TxtArt_Alphacode.nIO = IOValues.IORecordEntryEnable
            Me.TxtArtSearch.Visible = False
            Me.txtArt_omschrijving.Focus()
            Return
        End If
        Me.TxtArtSearch.Visible = True
        Me.TxtArtSearch.Text = ""
        Me.TxtArtSearch.BackColor = Color.LightPink
        Me.TxtArtSearch.Focus()
    End Sub
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim l As Boolean = Me.diagnose
        If l = False Then Exit Sub

        Me.BindingSource1.EndEdit()
        Dim n As Integer = Me.ArtikelTableAdapter.Update(DsArtikel1.Artikel)
        If n <> 1 Then
            Throw New InvalidOperationException("Artikel bestand werd niet bijgewerkt.")
        End If
        unLock("Artikel", Me.loadPK)
        Dim c As String = IIf(Me.loadPK = 0, "Append ", "Update ") & Me.txtArt_omschrijving.Text
        Dim a As LogAction = IIf(Me.loadPK = 0, LogAction.logCreate, LogAction.logUpdate)
        nlog(c, Me.Name, LogType.logNormal, a, "Artikel", Me.loadPK)
        Dim cArtikel As String = Me.txtArt_Nr.Text
        Me.clear()
        If Me.ModeShow = b040.ModeShow.Modal Then
            Me.cParameter = cArtikel
            Me.Close()
        End If
    End Sub
    Function diagnose() As Boolean
        Dim n As Integer
        diagnose = True
        If Trim(Me.Kat_Naamcbo.Text) = "" Then
            MsgBox("Gelieve een Kategorie te kiezen")
            Me.Kat_Naamcbo.Focus()
            Return False
        End If
        Me.BindingSource1(0)("Art_Kategorie") = kategorieFromNaam(Me.Kat_Naamcbo.Text)
        '
        If Trim(Me.Eenh_OmschrijvingCbo.Text) = "" Then
            MsgBox("Gelieve een Eenheid te kiezen")
            Me.Eenh_OmschrijvingCbo.Focus()
            Return False
        End If
        '
        If Me.Art_perpersoonctl.Checked And Val(cNvl(Me.Art_PortieCtl.Text)) = 0 Then
            MsgBox("Gelieve de Portie te willen aangeven")
            Me.Art_PortieCtl.Focus()
            Return False
        End If
        Dim cMsg As String = ""
        Dim lWarning As Boolean = False
        If Me.TxtArt_Alphacode.Text = "" Then
            cMsg &= "U hebt geen alpha_code aangegeven. " & vbCrLf
            lWarning = True
        Else
            n = ArtikelModule.Art_fromCode(Me.TxtArt_Alphacode.Text)
            If n > 0 AndAlso n <> Me.loadPK Then
                cMsg &= "Deze Aphacode bestaat reeds. " & vbCrLf
                lWarning = True
            End If
        End If
        If Me.txtArt_omschrijving.Text = "" Then
            cMsg &= "U hebt geen Omschrijving ingevuld. " & vbCrLf
            lWarning = True
        End If
        If Me.PrijsTxt.Text = "" Then
            cMsg &= vbCrLf & "U hebt geen Prijs ingevuld. " & vbCrLf
            lWarning = True
        End If
        If Me.Art_BTW.Text = "" Then
            cMsg &= "U hebt geen BTW ingevuld. Er wordt 6% verondersteld. " & vbCrLf
            Me.BindingSource1(0)("Art_BTW") = 6

            lWarning = True
        End If
        If Me.PrijsTxt.Text = "" Then
            cMsg &= "U hebt geen prijs ingegeven.  De prijs wordt 0 verondersteld" & vbCrLf
            Me.BindingSource1(0)("Art_prijs") = 0
            lWarning = True
        End If
        If lWarning = True Then
            cMsg &= vbCrLf & "Gelieve te willen confirmeren."
            If MsgBox(cMsg, MsgBoxStyle.YesNo, "Waarschuwing") = MsgBoxResult.No Then
                Return False
            End If
        End If
        Me.BindingSource1(0)("Art_Eenheid") = EenhedenFromOmschrijving(Me.Eenh_OmschrijvingCbo.Text)
        Me.BindingSource1(0)("Art_Snijden") = Me.ARt_SnijdenCtl.Checked
        Me.BindingSource1(0)("Art_Korting") = Me.Art_KortingCtl.Checked
        Me.BindingSource1(0)("Art_Uitzonderlijk") = Me.Art_UitzonderlijkCtl.Checked
        Me.BindingSource1(0)("Art_Perpersoon") = Me.Art_perpersoonctl.Checked
        Me.BindingSource1(0)("Art_Actief") = Me.Art_ActiefCtl.Checked
        Me.BindingSource1(0)("Art_Opschrift") = cNvl(Me.Art_OpschriftCtl.Text)
        Me.BindingSource1(0)("Art_BestBoodschap") = cNvl(Me.Art_BestBoodschapCtl.Text)

    End Function


    Private Sub CloseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub

    Private Sub TxtArt_Alphacode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtArt_Alphacode.Validating
        Dim input As String = Me.TxtArt_Alphacode.Text
        If ARt_AlphacodeExists(input, Me.loadPK) Then
            If MsgBox("Een ander artikel bestaat reeds met deze alphacode." & vbCrLf & "Gelieve te bevestigen.", MsgBoxStyle.YesNo, "B040 : Waarschuwing") = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub


    Private Sub Eenh_OmschrijvingCbo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eenh_OmschrijvingCbo.SelectedIndexChanged
        If Me.Eenh_OmschrijvingCbo.Text = "stuk" Then
            Me.Art_VerwittigenGewichtCtl.nIO = IOValues.IOAlwaysDisable
            Me.Art_PerpersoonCtl.nIO = IOValues.IOAlwaysDisable
            Me.Art_PortieCtl.nIO = IOValues.IOAlwaysDisable
            Me.Art_VerwittigenGewichtCtl.Text = False
            Me.Art_PerpersoonCtl.Text = "Neen"
            Me.Art_PortieCtl.Text = ""
        Else
            Me.Art_VerwittigenGewichtCtl.nIO = IOValues.IORecordEntryEnable
            Me.Art_PerpersoonCtl.nIO = IOValues.IORecordEntryEnable
            Me.Art_PortieCtl.nIO = IOValues.IORecordEntryEnable
        End If
        Me.FormMode = Me.FormMode

    End Sub

    Private Sub art_Uitzonderlijkctl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Art_UitzonderlijkCtl.Checked = False Then
            Me.Art_perpersoonctl.nIO = IOValues.IOAlwaysDisable
            Me.Art_PortieCtl.nIO = IOValues.IOAlwaysDisable
            Me.Art_OpschriftCtl.nIO = IOValues.IOAlwaysDisable
            Me.Art_BestBoodschapCtl.nIO = IOValues.IOAlwaysDisable
            Me.Art_perpersoonctl.Checked = False
            Me.Art_PortieCtl.Text = ""
            Me.Art_OpschriftCtl.Text = ""
            Me.Art_BestBoodschapCtl.Text = ""
            Me.Art_ActiefCtl.Focus()
        Else
            Me.Art_perpersoonctl.nIO = IOValues.IORecordEntryEnable
            Me.Art_PortieCtl.nIO = IOValues.IORecordEntryEnable
            Me.Art_OpschriftCtl.nIO = IOValues.IORecordEntryEnable
            Me.Art_BestBoodschapCtl.nIO = IOValues.IORecordEntryEnable
        End If
        Me.FormMode = Me.FormMode
    End Sub
    Private Sub TxtArtSearch_LostFocus(sender As Object, e As EventArgs) Handles TxtArtSearch.LostFocus
        Me.txtArt_omschrijving.Focus()
    End Sub

    Private Sub txtArt_Nr_Leave(sender As Object, e As EventArgs) Handles txtArt_Nr.Leave
        FormMode = FormMode
        Me.txtArt_omschrijving.Focus()
    End Sub
End Class

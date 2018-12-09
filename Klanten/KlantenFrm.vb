Option Infer On
Imports System.Data.OleDb
''' <summary>
''' 6127 added tokenized klantensearch (with includeActief = true)
''' </summary>
Public Class KlantenFrm
    Inherits frmB040
    Dim TypeFacturatie As New bzTypeFact
    Dim Bediening As New bzBediening
    Dim Klanten As New bzKlanten
    Dim Artikel As New bzArtikel
    Dim loadPk As Long
    Dim t As OleDbTransaction
    Dim BTWTypeO As New bzBTWType
    Dim zoekDatasource As New DataTable
    Dim zoekCancel As Boolean = True
    ''' <summary>
    ''' If set (by say Bestel), closes on save and returns Klanten 
    ''' </summary>
    Public operateAsChildform As Boolean = False
    ''' <summary>
    ''' 6127
    ''' </summary>
    Dim normalKl_NummerWidth As Integer
    Dim normalKL_NummerMask As String
#Region "FORM"
#Region "Clear"
    Private Sub clearStorage()
        Me.KlantenDS.Clear()
        Me.BS.AddNew()
        For i As Integer = 1 To 20
            Me.AdresBS.AddNew()
        Next
        Me.AdresBS.MoveFirst()
        For i As Integer = 1 To 20
            Me.KlantenKortingBS.AddNew()
        Next
        Me.KlantenKortingBS.MoveFirst()
        Me.Zoek.Text = ""
        Me.Title.Text = ""
        Me.Telefoon.Text = ""
        Me.adres.Text = ""
        Me.postnr.Text = ""
        Me.gemeente.Text = ""
        Me.land.Text = ""
    End Sub
    Private Sub clearSetDefaults()
        Me.Bed_Naam.Text = "Niet Toegewezen"
        Me.typeFacturatieControl.SelectedIndex = 0  ' Groothandel
        Me.typeFacturatieControl.nIO = IOValues.IORecordEntryEnable
        processTypeFactuur()
        Me.KL_Komthalen.Checked = False
        Me.BTW_Omschrijving.Text = "Belgisch"
        Me.KL_Voldaan.Checked = False
        Me.KL_Automatisch.Checked = True
        laatstebestellingBehoudenCheckbox.Checked = True

    End Sub
    Private Sub setFocusOnKL_Nummer()
        ' should be called from a lostfocus event.
        Me.TpgBase1.SelectTab(0)
        Me.TpgBase1.Focus()
        Me.KL_Nummer.Focus()
    End Sub
    Public Overrides Sub clear()
        MyBase.clear()
        unlockSession(nLogSession)
        Me.loadPk = 0
        clearStorage()
        clearSetDefaults()
        Me.KlantenKortingG.ClearSelection()
        If Me.eOpenMode = eFormOpen.eFormOpenNormal Then
            If operateAsChildform = True Then
                activateZoek()
                Return
            End If
            Me.FormMode = ModeValues.KeyEntry
            setFocusOnKL_Nummer()
        Else
            Me.KL_Nummer.Text = Klanten.Kl_NummerFormat(getNextNummer("KLANT"))
            Me.FormMode = ModeValues.RecordEntry
            With Me.KlantenKortingG.DefaultCellStyle : .SelectionBackColor = .BackColor : End With
            Me.KL_Naam.Focus()
            Return
        End If
    End Sub
#End Region
    ''' <summary>
    ''' 6217 - Implementing tokenized KlantenSearch
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KlantenFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        normalKl_NummerWidth = KL_Nummer.Width
        normalKL_NummerMask = KL_Nummer.Mask
        'TODO: This line of code loads data into the 'B040_beDataSet1.Bediening' table. You can move, or remove it, as needed.
        Me.BedieningTableAdapter.Fill(Me.B040_beDataSet1.Bediening)
        KlantenKortingG.setColumnDisabled("Art_Omschrijving")
        Dim TypF As New sqlClass
        TypF.Execute("select TypF_Omschrijving from typeFact")
        For Each r As DataRow In TypF.dt.Rows
            Me.typeFacturatieControl.Items.Add(r("TypF_Omschrijving"))
        Next
        Bediening.fillCbo(Me.Bed_naam)
        bzBTWType.fillListbox(Me.BTW_Omschrijving)
        Zoek.MaxDropDownItems = 8
        laatstebestellingBehoudenCheckbox.Checked = True
        laatstebestellingBehoudenCheckbox.Visible = True
        laatsteBestellingBehoudenLabel.Visible = True
        adres.Mask = New String("C", 40)
        postnr.Mask = New String("C", 10)
        gemeente.Mask = New String("C", 40)
        land.Mask = New String("C", 40)
        Telefoon.Mask = New String("C", 20)
        If operateAsChildform = True Then
            Me.TpgBase1.TabIndex = 1
            Zoek.TabIndex = 0
        Else
            Me.TpgBase1.TabIndex = 0
            Zoek.TabIndex = 1
        End If
        Me.clear()
    End Sub
    Private Sub KlantenFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.PageDown Then
            If Me.FormMode <> ModeValues.KeyEntry Then Exit Sub
            Dim oNext As New sqlClass
            Dim cNext As String
            cNext = "select Kl_Nummer from Klanten where Kl_Nummer > " & sqlClass.c(Me.KL_Nummer.Text) & " order by Kl_Nummer"
            Dim nNext = oNext.Execute(cNext)
            If nNext = 0 Then
                cNext = "select Kl_Nummer from Klanten order by Kl_Nummer"
                oNext.Execute(cNext)
            End If
            Me.KL_Nummer.Text = oNext.dt(0)("Kl_Nummer")
            Me.lLoadKlant()
            Me.KL_Nummer.Focus()
            Return
        End If
        If e.KeyCode = Keys.PageUp Then
            If Me.FormMode <> ModeValues.KeyEntry Then Exit Sub
            Dim oPrev As New sqlClass
            Dim cPrev As String
            cPrev = "select Kl_Nummer from Klanten where Kl_Nummer < " & sqlClass.c(Me.KL_Nummer.Text) & " order by kl_Nummer desc"
            Dim nPrev = oPrev.Execute(cPrev)
            If nPrev = 0 Then
                cPrev = "select Kl_Nummer from Klanten order by Kl_Nummer desc"
                oPrev.Execute(cPrev)
            End If
            Me.KL_Nummer.Text = oPrev.dt(0)("Kl_Nummer")
            Me.lLoadKlant()
            Me.KL_Nummer.Focus()
            Return
        End If
        If e.KeyCode = Keys.End Then
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            Me.SaveButton_Click(sender, e)
        End If
        If e.KeyCode = Keys.F2 Then
            If Me.FormMode <> ModeValues.KeyEntry Then Exit Sub
            activateZoek()
        End If

    End Sub
    Private Sub KlantenFrm_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        processTypeFactuur()
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region
#Region "Controls"
#Region "zoek"
    Private Sub zoekButton_Click(sender As Object, e As EventArgs) Handles zoekButton.Click
        activateZoek()
    End Sub
    Private Sub activateZoek()
        Zoek.Text = ""
        Zoek.Focus()
        zoekCancel = True
    End Sub
    Private Sub cancelZoek()
        ' clear()
    End Sub
    Private Sub Zoek_Keydown(sender As Object, e As KeyEventArgs) Handles Zoek.KeyDown
        If e.KeyCode = Keys.Tab Then
            zoekCancel = False
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter Then
            zoekCancel = False
            Exit Sub
        End If
    End Sub
    Private Sub Zoek_KeyUp(sender As Object, e As KeyEventArgs) Handles Zoek.KeyUp
        If e.KeyCode = Keys.F2 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.Home Then
            Exit Sub
        End If
        If e.KeyCode = Keys.Escape Then
            Exit Sub
        End If
        If e.KeyCode = Keys.Down Then
            Exit Sub
        End If
        If e.Control Then
            Exit Sub
        End If
        If e.Alt Then
            Exit Sub
        End If
        Dim savedString As String = Zoek.Text
        If Len(Trim(savedString)) < 1 Then
            Exit Sub
        End If
        bzKlanten.getKlantenFromTokenized(Zoek.Text, zoekDatasource)
        Zoek.DisplayMember = "displayField"
        Zoek.ValueMember = "KL_NUMMER"
        Zoek.DataSource = zoekDatasource
        ' Zoek.SelectedIndex = -1
        Zoek.MaxDropDownItems = 8
        Zoek.DroppedDown = True
        If Zoek.ValueMember <> "0" Then
            Zoek.Text = savedString
        End If
        Zoek.Select(Len(Zoek.Text), 1)
    End Sub
    Private Sub Zoek_Lostfocus(sender As Object, e As EventArgs) Handles Zoek.LostFocus
        If zoekCancel = False Then
            If Zoek.SelectedValue = "0" Then
                KL_Actief.Checked = True
                AdresBS(0)("adr_facturatie") = True
                Me.FormMode = ModeValues.RecordEntry
                With Me.KlantenKortingG.DefaultCellStyle : .SelectionBackColor = .BackColor : End With
                Me.KL_Nummer.Text = Klanten.Kl_NummerFormat(getNextNummer("KLANT"))
                Me.KL_Naam.Text = Zoek.Text
                Me.KL_Naam.Focus()
                Me.typeFacturatieControl.SelectedIndex = 1
                Return
            End If
            If operateAsChildform = True Then
                Me.Close()
            End If
            KL_Nummer.Text = Zoek.SelectedValue
            lLoadKlant()
            Zoek.Text = ""
            setFocusOnKL_Nummer()
        Else
            cancelZoek()
        End If
    End Sub
#End Region
#Region "KL_Nummer"
    Function lLoadKlant() As Boolean
        Dim input As String = Klanten.Kl_NummerFormat(Me.KL_Nummer.Text)
        If Klanten.Kl_NummerExists(input) = False Then
            MsgBox("Klant bestaat niet.")
            Return False
        End If
        Me.loadPk = Klanten.record("Kl_ID")
        processTypeFactuur()
        Me.KlantenCRUD.Fill(Me.KlantenDS.Klanten, Me.loadPk)

        Me.KLantenKlantenKortingCRUD.Fill(Me.KlantenDS.KlantenKorting, Me.loadPk)
        For i As Integer = 1 To 20
            Me.KlantenKortingBS.AddNew()
        Next
        For Each oRow As DataGridViewRow In Me.KlantenKortingG.Rows
            oRow.Cells("colArtSearch").Value = oRow.Cells("Art_Nr").Value
        Next
        Me.KlantenKortingBS.MoveFirst()
        Me.KlantAdresCRUD.Fill(Me.KlantenDS.Adres, loadPk)

        For i As Integer = 1 To 20
            Me.AdresBS.AddNew()
        Next
        Me.AdresBS.MoveFirst()
        Me.Telefoon.Text = cNvl(AdresBS(0)("adr_telefoon"))
        Me.adres.Text = cNvl(AdresBS(0)("adr_adres"))
        Me.postnr.Text = cNvl(AdresBS(0)("adr_postnummer"))
        Me.gemeente.Text = cNvl(AdresBS(0)("adr_gemeente"))
        Me.land.Text = cNvl(AdresBS(0)("adr_land"))
        Me.titleRefresh()

        With Me.KlantenKortingG.DefaultCellStyle
            .SelectionBackColor = .BackColor
        End With
        Me.KlantenKortingG.ClearSelection()

        Me.KL_Nummer.previousText = Me.KL_Nummer.Text
        Me.KL_Nummer.Focus()
        Return True
    End Function
    ''' <summary>
    ''' 6127 - Tokenized KlantenSearch
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KL_Nummer_Enter(sender As Object, e As EventArgs) Handles KL_Nummer.Enter
        KL_Nummer.Width = 200
        KL_Nummer.Mask = ">" & New String("C", 23)
    End Sub
    ''' <summary>
    ''' 6127 - Tokenized KlantenSearch, includeInactief is set to true
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub KL_Nr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles KL_Nummer.Validating
        Dim input As String = Me.KL_Nummer.Text
        ' ignore if input empty and enter was not pressed
        If Me.lastKeycode <> Keys.Tab And input = "" Then
            KL_Actief.Checked = True
            AdresBS(0)("adr_facturatie") = True
            Exit Sub
        End If
        ' set new mode for input empty and enter
        If Me.lastKeycode = Keys.Tab And input = "" Then
            Me.KL_Nummer.Text = Klanten.Kl_NummerFormat(getNextNummer("KLANT"))
            KL_Actief.Checked = True
            AdresBS(0)("adr_facturatie") = True
            Me.FormMode = ModeValues.RecordEntry
            With Me.KlantenKortingG.DefaultCellStyle : .SelectionBackColor = .BackColor : End With
            'Me.KL_Naam.Focus()
            Exit Sub
        End If
        ' set edit mode if reentrant
        If Me.lastKeycode = Keys.Tab And input = Me.KL_Nummer.previousText Then
            If lLock(Me.nLogSession, "Klanten", Me.loadPk, "") Then
                Dim enableTypeF As Boolean = bzKlanten.hasTransactions(loadPk)
                Me.typeFacturatieControl.nIO = IIf(enableTypeF, IOValues.IOAlwaysDisable, IOValues.IORecordEntryEnable)
                Me.FormMode = ModeValues.RecordEntry
                With Me.KlantenKortingG.DefaultCellStyle : .SelectionBackColor = .BackColor : End With
            Else
                e.Cancel = True
            End If
            Exit Sub
        End If
        ' before 6127 : only allow numeric entries - 6127 : tokenized KlantenSearch
        Dim n As Long = Val(input)
        'If n = 0 Then
        '    MsgBox("Klanten Nummers zijn numerisch. [" & input & "]")
        '    KL_Nummer.Text = ""
        '    e.Cancel = True
        '    Exit Sub
        'End If
        input = Klanten.Kl_NummerFormat(input)
        If Klanten.Kl_NummerExists(input) = True Then
            lLoadKlant()
            Exit Sub
        End If
        '    MsgBox("Klanten nummer " & Me.KL_Nummer.Text & " bestaat niet.")
        '    e.Cancel = True
        '    Exit Sub
        'End If
        Dim klid As Long
        Dim includeInactief As Boolean = True
        bzKlantenSearch.SearchKlant(input, klid, includeInactief)
        If klid = 0 Then
            e.Cancel = True
            Exit Sub
        End If
        Me.KL_Nummer.Text = bzKlanten.getKlNummer(klid)
            lLoadKlant()


    End Sub
#End Region
#Region "Save"
#Region "Diagnose"
#Region "diagnoseAdres"
    Private Sub removeEmptyAdres(r As Integer)
        If bNvl(Me.AdresBS(r)("adr_facturatie")) = True Then
            Exit Sub
        End If
        If cNvl(Me.AdresBS(r)("adr_telefoon")) <> "" Then
            Exit Sub
        End If
        If cNvl(Me.AdresBS(r)("adr_adres")) <> "" Then
            Exit Sub
        End If
        If cNvl(Me.AdresBS(r)("adr_postnummer")) <> "" Then
            Exit Sub
        End If
        If cNvl(Me.AdresBS(r)("adr_gemeente")) <> "" Then
            Exit Sub
        End If
        If cNvl(Me.AdresBS(r)("adr_land")) <> "" Then
            Exit Sub
        End If
        Me.AdresBS.RemoveAt(r)
    End Sub
    Private Sub checkHasFacturatieAdres()
        For r As Integer = 0 To AdresBS.Count - 1
            If bNvl(AdresBS(r)("adr_facturatie")) = True Then
                Exit Sub
            End If
        Next
        AdresBS(0)("adr_facturatie") = True
    End Sub
    Private Function diagnoseAdres() As Boolean
        For r As Integer = Me.AdresBS.Count - 1 To 0 Step -1
            removeEmptyAdres(r)
        Next
        If AdresBS.Count = 0 Then
            AdresBS.AddNew()
            AdresBS(0)("adr_facturatie") = True
            If bzTypeFact.typefactEnum(typeFacturatieControl.Text) = bzTypeFact.TypeFact.Groothandel Then
                MsgBox("Voor groothandel, gelieve adres in tegeven")
                adres.Focus()
                Return False
            End If
            Me.AdresBS(0)("adr_telefoon") = ""
            Me.AdresBS(0)("adr_adres") = ""
            Me.AdresBS(0)("adr_postnummer") = ""
            Me.AdresBS(0)("adr_gemeente") = ""
            Me.AdresBS(0)("adr_land") = ""
            Return True
        End If
        checkHasFacturatieAdres()
        Return True
    End Function
#End Region
    Function Diagnose() As Boolean
        If cNvl(KL_Naam.Text) = "" Then
            MsgBox("Gelieve de naam in te willen geven")
            KL_Naam.Focus()
            Return False
        End If
        If diagnoseAdres() = False Then
            Return False
        End If
        With Me.KlantenKortingBS
            For i As Integer = .Count - 1 To 0 Step -1
                If Me.KlantenKortingBS(i)("KK_Korting") Is DBNull.Value Then
                    Me.KlantenKortingBS(i)("KK_Korting") = 0
                End If
                If Me.KlantenKortingBS(i)("Art_nr") Is DBNull.Value Then
                    .RemoveAt(i)
                End If
            Next
        End With
        Me.TypeFacturatie.typF_Omschrijving = Me.typeFacturatieControl.SelectedItem.ToString
        Return True
    End Function
#End Region
    Private Sub save()
        With Me.BS
            Me.TypeFacturatie.typF_Omschrijving = Me.typeFacturatieControl.SelectedItem.ToString
            .Current("KL_Facturatie") = TypeFacturatie.record.TYPF_ID
            Me.Bediening.bed_Naam = Me.Bed_naam.Text
            .Current("KL_Bediening") = Bediening.record.Bed_id
            .Current("KL_BTWType") = Me.BTWTypeO.id(Me.BTW_Omschrijving.Text)
            .Current("Kl_Korting") = nNvlI(.Current("Kl_Korting"))
        End With
        Me.BS.EndEdit()
        Dim conn = Me.KlantenCRUD.Connection : conn.Open()
        t = conn.BeginTransaction
        Me.KlantenCRUD.Transaction = t
        Dim Header As Integer = Me.KlantenCRUD.Update(Me.KlantenDS.Klanten)
        If Header <> 1 Then
            t.Rollback()
            Throw New InvalidOperationException("Could not save the Klant record")
        End If
        Dim currLog As LogAction
        If Me.loadPk > 0 Then
            currLog = LogAction.logCreate
        Else
            currLog = LogAction.logUpdate
            Dim com As New OleDbCommand("select @@identity", conn)
            com.Transaction = t
            Try
                Me.loadPk = com.ExecuteScalar
            Catch
                t.Rollback()
                Throw New InvalidOperationException("Error in select @@idendity (KLANTEN)")
            End Try
        End If
        For Each r In AdresBS
            r("Adr_Klant") = Me.loadPk
        Next
        Me.AdresBS.EndEdit()
        Me.KlantAdresCRUD.Connection = conn
        Me.KlantAdresCRUD.Transaction = t
        Dim detailCountA As Integer = Me.KlantAdresCRUD.Update(Me.KlantenDS.Adres)
        KlantenKortingBS.EndEdit()
        For Each r As KlantenDS.KlantenKortingRow In KlantenDS.KlantenKorting
            If r.RowState <> DataRowState.Deleted Then
                r.KK_Klant = Me.loadPk
                Artikel.Art_Nr = r.Art_Nr : r.KK_Artikel = Artikel.Record.ARt_Id
            End If
        Next
        With Me.KLantenKlantenKortingCRUD
            .Connection = conn
            .Transaction = t
            Dim detailCountK As Integer = .Update(Me.KlantenDS.KlantenKorting)
        End With
        ' Throw New InvalidOperationException("Testing rollback")
        t.Commit()
        Dim clog As String = Me.KL_Nummer.Text & "-" & Me.KL_Naam.Text
        nLog(clog, Me.Name, LogType.logNormal, currLog, "Klanten", Me.loadPk)
        conn.Close()
        unLock("KLANTEN", loadPk)
        updateTelefoon(loadPk)
        Dim cKlant = Me.KL_Nummer.Text
        Me.clear()
        If Me.ModeShow = b040.ModeShow.Modal Then
            Me.cParameter = cKlant
            Me.Close()
        End If
    End Sub
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        If Me.Diagnose = False Then
            Exit Sub
        End If
        exitKl_Nummer = KL_Nummer.Text
        save()
        If operateAsChildform = True Then
            KL_Nummer.Text = exitKl_Nummer
            Close()
        End If
    End Sub

#End Region
#Region "Type Factuur"
    Private Sub setParticulierControls(io As IOValues)
        kl_btw.nIO = io
        kl_btw.ioEnable(Me.FormMode)
        BTW_Omschrijving.nIO = io
        BTW_Omschrijving.IOEnable(Me.FormMode)
        KL_Voldaan.nIO = io
        KL_Voldaan.IOEnable(Me.FormMode)
    End Sub
    Private Sub setGroothandelControls(io As IOValues)
        laatstebestellingBehoudenCheckbox.nIO = io
        laatstebestellingBehoudenCheckbox.IOEnable(Me.FormMode)
    End Sub
    Private Sub processTypeFactuur()
        frmMain.setBackgroundColor(Me.typeFacturatieControl.SelectedItem.ToString)
        If bzTypeFact.typefactEnum(Me.typeFacturatieControl.SelectedItem.ToString) = bzTypeFact.TypeFact.Partikulier Then
            setParticulierControls(IOValues.IOAlwaysDisable)
            setGroothandelControls(IOValues.IORecordEntryEnable)
            KL_Automatisch.Checked = True
            KL_Voldaan.Checked = False
        Else
            setParticulierControls(IOValues.IORecordEntryEnable)
            setGroothandelControls(IOValues.IOAlwaysDisable)
        End If
    End Sub
    Private Sub typFCheckedListbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles typeFacturatieControl.SelectedIndexChanged
        processTypeFactuur()
    End Sub
#End Region
    Private Sub KlantenKortingG_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        KlantenKortingG.Columns("colArtSearch").DefaultCellStyle.SelectionBackColor = Color.LightPink
    End Sub
    Private Sub CloseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
    Private Sub KL_Naam_Validated(sender As Object, e As EventArgs) Handles KL_Naam.Validated
        KL_Naam.Text = Trim(KL_Naam.Text)
    End Sub
    Private Sub Telefoon_Validated(sender As Object, e As EventArgs) Handles Telefoon.Validated
        Telefoon.Text = Strings.Left(Telefoon.Text, 40)
        titleRefresh()
        adres1Refresh()
    End Sub
    Private Sub adres_Validated(sender As Object, e As EventArgs) Handles adres.Validated
        adres.Text = Strings.Left(adres.Text, 40)
        adres1Refresh()
    End Sub
    Private Sub postnr_Validated(sender As Object, e As EventArgs) Handles postnr.Validated
        postnr.Text = Strings.Left(postnr.Text, 10)
        adres1Refresh()
    End Sub
    Private Sub gemeente_Validated(sender As Object, e As EventArgs) Handles gemeente.Validated
        gemeente.Text = Strings.Left(gemeente.Text, 40)
        adres1Refresh()
    End Sub
    Private Sub land_Validated(sender As Object, e As EventArgs) Handles land.Validated
        land.Text = Strings.Left(land.Text, 40)
        adres1Refresh()
    End Sub

#End Region
#Region "grdValidate"
    Private Sub setFacturatieToCurrentRow(rowIndex As Integer)
        For Each row As DataGridViewRow In AdresG.Rows
            If row.Index = rowIndex Then
                row.Cells("FactColumn").Value = True
            Else
                row.Cells("FactColumn").Value = False
            End If
        Next
    End Sub

    Private Sub AdresG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles AdresG.CellContentClick
        If e.ColumnIndex <> AdresG.Columns("FactColumn").Index Then
            Exit Sub
        End If
        setFacturatieToCurrentRow(e.RowIndex)
    End Sub

    Public Overrides Function grdValidate(ByVal ctrl As String, ByRef input As String) As Boolean
        'Return MyBase.grdValidate(ctrl, txt)
        Dim l As Boolean = MyBase.grdValidate(ctrl, input)
        Select Case UCase(ctrl)
            Case "COLARTSEARCH"
                Dim obzArtSearch As New bzArtikel.clsSearch
                With obzArtSearch
                    .cInput = input
                    .oCaller = Me.KlantenKortingG.EditingControl
                    .nFieldLength = 4
                    .search()
                    If .lFound = True Then
                        input = .cArtNr
                        If Me.Artikel.Art_NrExists(input) = False Then
                            MsgBox("Artikel Nr " & input & " bestaat niet.")
                            Return False
                        End If
                        ' Me.STandaardDBindingSource.Current("ARt_Nr") = Me.obzArtikel.Art_NrFormat(GrdBase1.currentColumnValue("ART_NRCOL"))
                        Me.KlantenKortingG.currentColumnValue("Art_Nr") = Me.Artikel.Record("art_Nr")
                        Me.KlantenKortingG.currentColumnValue("Art_omschrijving") = Me.Artikel.Record("art_Omschrijving")
                        Return True
                    End If
                    If .lUserCanceled = False Then
                        MsgBox(.cMessage)
                    End If
                    Return False
                End With
            Case "TELEFOONCOLUMN"
                If AdresG.CurrentRow.Index <> 0 Then
                    Return True
                End If
                Telefoon.Text = input
                titleRefresh()
            Case "ADRESCOLUMN"
                If AdresG.CurrentRow.Index <> 0 Then
                    Return True
                End If
                adres.Text = input
            Case "POSTNRCOLUMN"
                If AdresG.CurrentRow.Index <> 0 Then
                    Return True
                End If
                postnr.Text = input
            Case "GEMEENTECOLUMN"
                If AdresG.CurrentRow.Index <> 0 Then
                    Return True
                End If
                gemeente.Text = input
            Case "LANDCOLUMN"
                If AdresG.CurrentRow.Index <> 0 Then
                    Return True
                End If
                land.Text = input
        End Select
        Return True
    End Function

#End Region
    Function strip(telefoonnummer As String) As String
        Dim stripped As String = ""
        For Each currentCharacter In telefoonnummer.ToList
            stripped &= IIf(IsNumeric(currentCharacter), currentCharacter, "")
        Next
        Return stripped
    End Function
    Sub insertTelefoon(klantenId As Long, telefoon As String)
        Dim builder As New sqlClass.SqlBuilder
        builder.cTable = "telefoon"
        builder.addInsert("tel_nummer", sqlClass.c(telefoon))
        builder.addInsert("tel_nummerStripped", sqlClass.c(strip(telefoon)))
        builder.addInsert("tel_klanten", klantenId)
        Dim insertTelefoon As New sqlClass
        insertTelefoon.ExecuteNonQuery(builder.cInsert, t)
    End Sub
    Sub updateTelefoon(klantenId As Long)
        Dim deleteFromTelefoonSql As String = "delete * from telefoon where tel_klanten = " & klantenId
        Dim deleteFromTelefoon As New sqlClass
        deleteFromTelefoon.ExecuteNonQuery(deleteFromTelefoonSql, t)
        Dim Klant As New sqlClass
        Klant.Execute("select * from Klanten where kl_id = " & klantenId)
        If cNvl(Klant.dt(0)("kl_telefoon2")) <> "" Then
            insertTelefoon(klantenId, Klant.dt(0)("kl_telefoon2"))
        End If
        If cNvl(Klant.dt(0)("kl_GSM")) <> "" Then
            insertTelefoon(klantenId, Klant.dt(0)("kl_GSM"))
        End If
        Dim adressen As New sqlClass
        Dim adressenCount As Long = adressen.Execute("select * from adres where adr_klant = " & klantenId)
        For Each adres As DataRow In adressen.dt.Rows
            If cNvl(adres("adr_telefoon")) <> "" Then
                insertTelefoon(klantenId, adres("adr_telefoon"))
            End If
        Next
    End Sub
    Private Sub titleRefresh()
        Title.Text = Trim(KL_Naam.Text) & " - " & Trim(Telefoon.Text)
    End Sub
    Private Sub adres1Refresh()
        AdresG.Rows(0).Cells("telefoonColumn").Value = Telefoon.Text
        AdresG.Rows(0).Cells("adresColumn").Value = adres.Text
        AdresG.Rows(0).Cells("postnrColumn").Value = postnr.Text
        AdresG.Rows(0).Cells("gemeenteColumn").Value = gemeente.Text
        AdresG.Rows(0).Cells("landColumn").Value = land.Text
    End Sub
    Private Sub AnnuleerKlantenKorting()
        If cNvl(Me.KlantenKortingG.CurrentRow.Cells("colArtSearch").FormattedValue) = "" Then
            Return
        End If
        KlantenKortingBS.RemoveCurrent()
    End Sub
    Private Sub AnnuleerKlantenKortingButton_Click(sender As Object, e As EventArgs) Handles AnnuleerKlantenKortingButton.Click
        If previousControl Is KlantenKortingG Then
            AnnuleerKlantenKorting()
        End If
    End Sub
End Class

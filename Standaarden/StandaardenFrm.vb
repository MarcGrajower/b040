Imports System.Data.OleDb

Public Class StandaardenFrm
    Inherits frmB040
    Dim loadPk As Long
    Dim mKlantPk As Long
    Dim mTypeStBestpk As Long
    Dim obzArtikel As New bzArtikel

    Private Sub StandaardenFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.End Then
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            If Me.cActiveControlName = "GRDBASE1" Then
                Dim next_emtpyline As Integer = 0
                For Each oRow As DataGridViewRow In Me.GrdBase1.Rows
                    Dim art_nr = oRow.Cells("Art_nrCOL").Value
                    If IsDBNull(art_nr) OrElse Trim(art_nr) = "" Then
                        next_emtpyline = oRow.Index
                        Exit For
                    End If
                Next
                Dim nCurrentLine As Long = Me.GrdBase1.CurrentCell.RowIndex
                Dim nCurrentColumn As Integer = Me.GrdBase1.CurrentCell.ColumnIndex
                If nCurrentLine = next_emtpyline Then
                    If Me.SaveButton.Enabled = True Then
                        Me.SaveButton_Click(sender, e)
                    End If
                Else
                    Me.GrdBase1.CurrentCell = Me.GrdBase1(Me.GrdBase1.Columns("Art_nrCOL").Index, next_emtpyline)
                    e.Handled = True
                End If
            End If
        End If
        If e.KeyCode = Keys.F4 Then
            Me.deleteButton.PerformClick()
        End If
    End Sub
    Private Sub StandaardenFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StandaardenDS1.STandaardD' table. You can move, or remove it, as needed.
        Me.StandaardHBS.AddNew()
        For i As Integer = 1 To 20
            Me.STandaardDBindingSource.AddNew()
        Next
        Me.STandaardDBindingSource.MoveFirst()
        TypSTBestFillCbo(TypSB_OmschrijvingCTl)
        CType(GrdBase1.Columns("SnijdenCol"), DataGridViewComboBoxColumn).Items.Add("Ja")
        CType(GrdBase1.Columns("SnijdenCol"), DataGridViewComboBoxColumn).Items.Add("Neen")
        GrdBase1.Columns("Art_nrcol").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GrdBase1.setColumnDisabled("Eenh_HoevInvoerCol")
        GrdBase1.setColumnDisabled("std_ArtOmschrijvingCol")
        GrdBase1.setColumnTabstopFalse("SnijdenCol")
        GrdBase1.setColumnTabstopFalse("std_TourCol")
        With GrdBase1 : .columnDecimals(.Columns("Std_hoeveelheidcol").Index) = 0 : End With

    End Sub
    Public Overrides Sub clear()
        Dim keepKlant As Boolean = False
        Dim nummer As String = ""
        Dim naam As String = ""
        Dim typeKlant As String = ""
        Dim telefoon As String = ""
        Dim standaardType As String = ""
        Dim standaardDag As Integer = -1
        If Me.lastKeycode <> Keys.Home Then
            keepKlant = True
            nummer = Me.KL_NummerCtl.Text
            naam = Me.KL_NaamCtl.Text
            typeKlant = typeKlantLabel.Text
            telefoon = telefoonLabel.Text
            standaardType = Me.Sth_TypeCtl.Text
            standaardDag = Me.TypSB_OmschrijvingCTl.SelectedIndex
        Else
            Me.TypSB_OmschrijvingCTl.Text = ""
        End If
        MyBase.clear()
        StandaardenDS1.Clear()
        Me.StandaardHBS.AddNew()
        For i As Integer = 1 To 20
            Me.STandaardDBindingSource.AddNew()
        Next
        Me.STandaardDBindingSource.MoveFirst()
        unlockSession(nLogSession)
        loadPk = 0
        mKlantPk = 0
        FormMode = ModeValues.KeyEntry
        '<REFACTOR>Not sure why this is needed</REFACTOR>
        Me.TypSB_OmschrijvingCTl.TabStop = True
        typeKlantLabel.Text = ""
        telefoonLabel.Text = ""
        If keepKlant Then
            Me.KL_NummerCtl.Text = nummer
            Me.KL_NaamCtl.Text = naam
            Me.Sth_TypeCtl.Text = standaardType
            Dim setDag As Integer = standaardDag + 1
            If setDag > TypSB_OmschrijvingCTl.Items.Count Then
                setDag = 0
            End If
            Me.TypSB_OmschrijvingCTl.SelectedIndex = setDag
        End If
        KL_NummerCtl.Focus()
        unlockSession(nLogSession)
    End Sub
    Private Sub CloseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub

    Private Sub KL_NummerCtl_Validated(sender As Object, e As EventArgs) Handles KL_NummerCtl.Validated
        typeKlantLabel.Text = bzTypeFact.getKlantType(KL_NummerCtl.Text)
        telefoonLabel.Text = bzKlanten.getTelefoon(KL_NummerCtl.Text)
    End Sub
    Private Sub KL_NummerCtl_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles KL_NummerCtl.Validating
        Dim Input As String = Trim(KL_NummerCtl.Text)
        If Input = "" Then Exit Sub
        'Dim Num As Long = Val(Input)
        'If Num = 0 Then
        '    MsgBox("Klanten nummers zijn numerisch. [" & Input & "]")
        '    e.Cancel = True
        '    Exit Sub
        'End If
        Input = Strings.RSet(KL_NummerCtl.Text, KL_NummerCtl.fieldLength)
        mKlantPk = Kl_Id(Input)
        If mKlantPk = 0 Then
            mKlantPk = search_klantid(Input, Me.KL_NaamCtl)
            If mKlantPk = 0 Then
                MsgBox("Klant nr " & KL_NummerCtl.Text & " bestaat niet.")
                e.Cancel = True
                Exit Sub
            End If
            Input = bzKlanten.cNummer(mKlantPk)
        End If
        KL_NummerCtl.Text = Input
        KL_NaamCtl.Text = KL_Naam(mKlantPk)
        Me.Sth_TypeCtl.Text = 1
        If Me.TypSB_OmschrijvingCTl.Text = "" Then
            Me.TypSB_OmschrijvingCTl.Text = modDutch.cDagInDeWeek(bzBestel.dGetLeveringForBestellingDatum())
        End If


    End Sub
    Function search_klantid(input As String, requestingcontrol As Control) As Long
        Dim obzklanten As New bzKlanten
        If obzklanten.KL_CodeExists(input) Then
            Return obzklanten.record("kl_id")
        End If
        Dim oSql As New sqlClass
        Dim cSql = "select Kl_nummer,kl_Naam from Klanten where kl_Naam like " & sqlClass.cLike(input) & " order by Kl_Naam"
        Dim nCandidates As Long = oSql.Execute(cSql)
        If nCandidates = 0 Then
            MsgBox("Klant " & input & " is niet geldig")
            Return 0
        End If
        If nCandidates = 1 Then
            Return Kl_Id(oSql.dt(0)("KL_nummer"))
        End If
        Dim f As New PopupFrm
        f.caller = requestingcontrol
        f.dt = oSql.dt
        f.ShowDialog()
        If f.userCanceled Then
            Return 0
        End If
        Return Kl_Id(f.g(f.g.Columns("KL_Nummer").Index, f.selected).FormattedValue)
    End Function
    Private Sub Sth_TypeCtl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Sth_TypeCtl.Validating
        Dim input As String = Trim(Sth_TypeCtl.Text)
        If input = "" Then Exit Sub
        If checkStandaardNr(input) Then Exit Sub
        MsgBox(StandaardNrErrMsg)
        e.Cancel = True
    End Sub
    Private Sub TypSB_OmschrijvingCTl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TypSB_OmschrijvingCTl.Validating
        Dim input As String = Trim(TypSB_OmschrijvingCTl.Text)
        If input = "" Then Exit Sub
        mTypeStBestpk = TypeSTBestFromOmschrijving(input)
        If mTypeStBestpk = 0 Then
            MsgBox("????")
            e.Cancel = True
        End If
        If mKlantPk = 0 Then
            MsgBox("Gelieve een Klant Nummer in te vullen")
            KL_NummerCtl.Focus()
            Exit Sub
        End If
        If Sth_TypeCtl.Text = "" Then
            MsgBox("Gelieve een Type in te vullen")
            Sth_TypeCtl.Focus()
            Exit Sub
        End If
        loadPk = StandaardFromKlantTypeStandaardType(mKlantPk, Sth_TypeCtl.Text, mTypeStBestpk)
        If loadPk = 0 Then
            Me.FormMode = ModeValues.RecordEntry
            GrdBase1.Focus()
            Exit Sub
        End If
        Dim cLockDescription = Trim(Me.KL_NaamCtl.Text) & "-" & Trim(Me.Sth_TypeCtl.Text) & "-" & Trim(Me.TypSB_OmschrijvingCTl.Text)
        If lLock(Me.nLogSession, "StandaardH", loadPk, cLockDescription) = False Then
            e.Cancel = True
            Exit Sub
        End If
        Me.StandaardHTableAdapter1.Fill(StandaardenDS1.StandaardH, loadPk)
        Dim detailcount As Integer = Me.STandaardDTableAdapter.Fill(StandaardenDS1.STandaardD, loadPk)
        For Each r As StandaardenDS.STandaardDRow In StandaardenDS1.STandaardD.Rows
            r.std_ArtOmschrijving = bzArtikel.omschrijving(r.std_Artikel)
        Next
        Dim colText As Integer = GrdBase1.Columns("SnijdenCol").Index
        Dim colBool As Integer = GrdBase1.Columns("Std_Snijden").Index
        Dim colArtNr As Integer = GrdBase1.Columns("Art_NrCol").Index
        Dim colArtSn As Integer = GrdBase1.Columns("Art_Snijden").Index
        Me.FormMode = ModeValues.RecordEntry
        For r As Integer = 0 To GrdBase1.Rows.Count - 2
            GrdBase1(colText, r).Value = IIf(GrdBase1(colBool, r).Value = True, "Ja", "Neen")
            GrdBase1.EnableCell(GrdBase1(colText, r), GrdBase1(colArtSn, r).Value)
            GrdBase1.EnableCell(GrdBase1(colArtNr, r), False)
        Next
        For i As Integer = 1 To 20
            Me.STandaardDBindingSource.AddNew()
        Next
        Me.STandaardDBindingSource.MoveFirst()
        GrdBase1.Focus()

    End Sub
    Public Overrides Function grdValidate(ByVal ctrl As String, ByRef input As String) As Boolean
        'Return MyBase.grdValidate(ctrl, txt)
        Dim l As Boolean = MyBase.grdValidate(ctrl, input)
        Select Case UCase(ctrl)
            Case "ART_NRCOL"
                If Trim(input) = "" Then Return True
                Dim oSrch As New bzArtikel.clsSearch
                With oSrch
                    .cInput = Trim(input)
                    .oCaller = Me.GrdBase1.EditingControl
                    .nFieldLength = Me.obzArtikel.nFieldLength("Art_Nr")
                    .search()
                    If .lFound = True Then
                        Me.obzArtikel.Art_Nr = .cArtNr
                        If Me.obzArtikel.Record.Art_Actief = False Then
                            MsgBox("Artikel is inactief")
                            Return False
                        End If
                        ' MG 11/dec/11 not sure this right!
                        input = .cArtNr
                    Else
                        If .lUserCanceled = False Then
                            MsgBox(.cMessage)
                        End If
                        Return False
                    End If
                End With
                ' Me.STandaardDBindingSource.Current("ARt_Nr") = Me.obzArtikel.Art_NrFormat(GrdBase1.currentColumnValue("ART_NRCOL"))
                If GrdBase1.currentColumnValue("Std_artomschrijvingcol") = "" Then
                    GrdBase1.currentColumnValue("Std_artomschrijvingcol") = Me.obzArtikel.Record("art_Omschrijving")
                End If
                GrdBase1.currentColumnValue("Eenh_HoevInvoerCol") = Eenh_HoevInvoer(obzArtikel.Record("Art_Eenheid"))
                Dim s As Boolean = obzArtikel.SnijdenApplicable()
                GrdBase1.currentColumnEnable("SnijdenCol", s)
                If s = False Then GrdBase1.currentColumnValue("SnijdenCol") = "Neen"
            Case "STD_TOURCOL"
                If Bestel.Tour.Valid(input) = False Then
                    MsgBox(Bestel.Tour.ErrorMsg)
                    Return False
                End If
        End Select
        Return True
    End Function
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        If Me.diagnose = False Then
            Me.GrdBase1.Focus()
            Exit Sub
        End If
        With Me.StandaardHBS
            .Current("STH_typsb") = TypeSTBestFromOmschrijving(Me.TypSB_OmschrijvingCTl.Text)
            .Current("sth_Klant") = Kl_Id(.Current("kl_nummer"))
            .Current("sth_timestamp") = Now
            .EndEdit()
        End With
        Dim conn = Me.StandaardHTableAdapter1.Connection
        conn.Open()
        Dim t As OleDbTransaction = conn.BeginTransaction()
        Me.StandaardHTableAdapter1.Transaction = t
        Dim n As Integer = Me.StandaardHTableAdapter1.Update(Me.StandaardenDS1.StandaardH)
        If n <> 1 Then
            t.Rollback()
            Throw New InvalidOperationException("Hoofd record STH kon niet weggeschreven worden.")
        End If
        Dim com As New OleDbCommand("select @@identity", Me.StandaardHTableAdapter1.Connection)
        com.Transaction = t
        Dim lGetPK As Boolean = True
        Dim pk As Long
        Dim currentLogAction As LogAction = LogAction.logCreate
        If loadPk > 0 Then
            currentLogAction = b040.LogAction.logUpdate
            pk = loadPk
        Else
            Try
                pk = com.ExecuteScalar
            Catch
                lGetPK = False
                t.Rollback()
                Throw New InvalidOperationException("Nieuwe sleutel kon niet opgehaald worden.")
            End Try
        End If
        '
        For Each r As DataRowView In Me.STandaardDBindingSource
            r("std_sth") = pk
            obzArtikel.Art_Nr = r("Art_Nr")
            r("std_Artikel") = obzArtikel.Record.ARt_Id
        Next
        Me.STandaardDBindingSource.EndEdit()
        Me.STandaardDTableAdapter.Connection = conn
        Me.STandaardDTableAdapter.Transaction = t
        Dim nDetail As Integer = Me.STandaardDTableAdapter.Update(Me.StandaardenDS1.STandaardD)
        If nDetail = 0 Then
            MsgBox("Er waren geen Standaarden om weg te schrijven")
            t.Rollback()
        Else
            t.Commit()
            Dim cLogDescription = Trim(Me.KL_NaamCtl.Text) & "-" & Trim(Me.Sth_TypeCtl.Text) & "-" & Trim(Me.TypSB_OmschrijvingCTl.Text)
            nLog(cLogDescription, Me.Name, LogType.logNormal, currentLogAction, "StandaardH", loadPk)
        End If
        conn.Close()
        unLock("StandaardH", loadPk)
        Me.clear()
    End Sub
    Function diagnose() As Boolean
        ' assume header is ok, otherwise the save button is not enabled
        For i As Integer = Me.STandaardDBindingSource.Count - 1 To 0 Step -1
            If Me.STandaardDBindingSource(i)("ARt_Nr") Is DBNull.Value Then
                Me.STandaardDBindingSource.RemoveAt(i)
            Else
                If Me.STandaardDBindingSource(i)("Std_hoeveelheid") Is DBNull.Value Then
                    Me.STandaardDBindingSource(i)("Std_hoeveelheid") = 0
                End If
                If Me.STandaardDBindingSource(i)("Std_Tour") Is DBNull.Value Then
                    MsgBox("Gelieve Tour te willen invullen")
                    With Me.GrdBase1
                        .CurrentCell = .Item(.Columns("std_Tourcol").Index, i)
                    End With
                    Return False
                End If
                If Me.GrdBase1(Me.GrdBase1.Columns("SnijdenCol").Index, i).Value Is DBNull.Value Then Me.GrdBase1(Me.GrdBase1.Columns("SnijdenCol").Index, i).Value = "Neen"
                Me.GrdBase1(Me.GrdBase1.Columns("std_snijden").Index, i).Value = If(Me.GrdBase1(Me.GrdBase1.Columns("SnijdenCol").Index, i).Value = "Ja", True, False)
            End If
        Next
        Return True
    End Function

    Private Sub GrdBase1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdBase1.CellEndEdit
        Select Case UCase(GrdBase1.Columns(e.ColumnIndex).Name)
            Case "ART_NRCOL"
                With GrdBase1
                    .EnableCell(.CurrentCell, False)
                End With
        End Select
    End Sub

    Private Sub GrdBase1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdBase1.CellValidated
        If Not (TypeOf (Me.GrdBase1.Columns(e.ColumnIndex)) Is DataGridViewTextBoxColumn) Then
            ' MsgBox("Column type not supported")
            Exit Sub
        End If
        If Me.GrdBase1.EditingControl Is Nothing Then Exit Sub
        Dim input As String = Me.GrdBase1.EditingControl.Text
        If input = "" Then Exit Sub
        Select Case UCase(GrdBase1.Columns(e.ColumnIndex).Name)
            Case "ART_NRCOL"
                GrdBase1.currentColumnValue("ART_NRCOL") = Me.obzArtikel.Art_NrFormat(GrdBase1.currentColumnValue("ART_NRCOL"))
                'GrdBase1.CurrentRow.Cells("std_ArtOmschrijvingCol").Value = Me.obzArtikel.Record("Art_Omschrijving")
                GrdBase1.CurrentRow.Cells("std_TourCol").Value = "1"
                If Me.obzArtikel.Record("Art_Snijden") = True Then
                    GrdBase1.CurrentRow.Cells("SnijdenCol").Value = "Ja"
                End If
        End Select
    End Sub
    Sub setFocus(row As DataGridViewRow)
        If cNvl(row.Cells(0).Value) = "" Then
            Me.GrdBase1.CurrentCell = row.Cells(0)
        Else
            Me.GrdBase1.CurrentCell = row.Cells("std_HoeveelheidCol")
        End If

    End Sub
    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        Me.STandaardDBindingSource.RemoveCurrent()
        setFocus(Me.GrdBase1.CurrentRow)
    End Sub
    Private Sub GrdBase1_Enter(sender As Object, e As EventArgs) Handles GrdBase1.Enter
        setFocus(Me.GrdBase1.Rows(0))
    End Sub


End Class

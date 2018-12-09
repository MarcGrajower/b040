Public Class frmKlantOperaties
    Dim cKl_Nummer As String
    Sub doAfdrukken(preview As Boolean)
        Dim cDocnr As String = bzBestel.cDocnr(Me.GrdBase1.CurrentRow.Cells("colPK").Value)
        If Trim(cDocnr) = "" Then
            Return
        End If
        frmMain.waitingMessage.Visible = True
        bzBestel.report(cDocnr, preview)
        frmMain.waitingMessage.Visible = False
    End Sub
    Private Sub frmKlantOperaties_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            Me.doAfdrukken(preview:=False)
            e.Handled = True
            Return
        End If
        If e.Control = True And e.KeyCode = Keys.X Then
            Me.doAfdrukken(preview:=True)
            e.Handled = True
            Return
        End If
    End Sub
    Private Sub frmKlantOperaties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ProgressBar1.Visible = True
        Me.FormMode = ModeValues.RecordEntry
        Me.GrdBase1.DefaultCellStyle.BackColor = Color.LightYellow
        Dim oNewCol1 As New DataGridViewTextBoxColumn
        Dim oNewCol2 As New DataGridViewTextBoxColumn
        Dim oNewCol3 As New DataGridViewTextBoxColumn
        Dim oNewCol4 As New DataGridViewTextBoxColumn
        Dim oNewCol5 As New DataGridViewTextBoxColumn
        oNewCol1.Name = "colDatum"
        oNewCol1.HeaderText = "Datum"
        oNewCol1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        oNewCol1.Width = 75
        Me.GrdBase1.Columns.Add(oNewCol1)

        oNewCol2.Name = "colDag"
        oNewCol2.HeaderText = "Dag"
        oNewCol2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        oNewCol2.Width = 100
        Me.GrdBase1.Columns.Add(oNewCol2)

        oNewCol3.Name = "colVolgnr"
        oNewCol3.HeaderText = "Volgnr"
        oNewCol3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        oNewCol3.Width = 50
        Me.GrdBase1.Columns.Add(oNewCol3)

        oNewCol4.Name = "colTotaal"
        oNewCol4.HeaderText = "Totaal"
        oNewCol4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        oNewCol4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GrdBase1.Columns.Add(oNewCol4)

        oNewCol5.Name = "colPK"
        oNewCol5.HeaderText = "PK"
        oNewCol5.Visible = False
        Me.GrdBase1.Columns.Add(oNewCol5)

        Me.GrdBase1.maskit()
        '        Me.GrdBase1.RowsDefaultCellStyle = Me.GrdBase1.DefaultCellStyle
        Me.GrdBase1.AllowUserToAddRows = False
        Me.GrdBase1.Rows.Clear()
        For iLine As Integer = 1 To 100
            Me.GrdBase1.Rows.Add()
        Next
        Me.GrdBase1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        For Each oCol As DataGridViewColumn In Me.GrdBase1.Columns
            oCol.DefaultCellStyle.BackColor = Color.LightYellow
            oCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        Me.GrdBase1.Columns("colDag").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.GrdBase1.Columns("colDatum").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.GrdBase1.Columns("colVolgNr").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.GrdBase1.Columns("colTotaal").DefaultCellStyle.Format = "N2"
        Me.GrdBase1.Columns("colTotaal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GrdBase1.CurrentCell = Me.GrdBase1(0, 0)
        Me.GrdBase1.Rows(0).Selected = True
        Me.GrdBase1.TabStop = True
        Me.KeyPreview = True

        Me.ProgressBar1.Visible = False
    End Sub
    Public Overrides Sub clear()
        MyBase.clear()
        Me.TxtBase1.Text = ""
        Me.TxtBase2.Text = ""
        Me.GrdBase1.Rows.Clear()
        For iLine As Integer = 1 To 100
            Me.GrdBase1.Rows.Add()
        Next
        Me.TxtBase1.Focus()
    End Sub
    Private Sub BtnBase1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBase1.Click
        Me.Close()
    End Sub

    Private Sub TxtBase1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBase1.Validating
        cKl_Nummer = Trim(Me.TxtBase1.Text)
        If cKl_Nummer = "" Then Return
        Dim obzKlanten As New bzKlanten
        If obzKlanten.Kl_NummerExists(cKl_Nummer) Then
            cKl_Nummer = obzKlanten.Kl_NummerFormat(cKl_Nummer)
            Return
        End If

        If obzKlanten.KL_CodeExists(cKl_Nummer) Then
            cKl_Nummer = obzKlanten.kl_nummer
            Return
        End If
        Dim oSql As New sqlClass
        Dim cSql = "select Kl_nummer,kl_Naam from Klanten where kl_Naam like " & sqlClass.cLike(Me.TxtBase1.Text) & " order by Kl_naam"
        Dim nCandidates As Long = oSql.Execute(cSql)
        If nCandidates = 0 Then
            MsgBox("Klant " & Me.TxtBase1.Text & " is niet geldig")
            e.Cancel = True
            Return
        End If
        If nCandidates = 1 Then
            cKl_Nummer = oSql.dt(0)("KL_Nummer")
            Return
        End If
        Dim f As New PopupFrm
        f.caller = Me.TxtBase1
        f.dt = oSql.dt
        f.ShowDialog()
        If f.userCanceled Then
            e.Cancel = True
            Return
        End If
        cKl_Nummer = f.g(f.g.Columns("KL_Nummer").Index, f.selected).FormattedValue
    End Sub
    Private Sub TxtBase1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBase1.Validated
        If cKl_Nummer = "" Then Return
        Dim isParticulier As Boolean = bzKlanten.isParticulier(bzKlanten.kl_id(Me.cKl_Nummer))
        Dim bestHDatatable As String = IIf(isParticulier, "pH", "bestH")
        Dim oSql As New sqlClass
        Dim cSql As String = "select kl_nummer,kl_Naam from klanten where kl_nummer = " & sqlClass.c(Me.cKl_Nummer)
        Me.TxtBase1.Text = oSql.ExecuteScalar(cSql)
        Me.TxtBase2.Text = bzKlanten.cKl_Naam(Me.TxtBase1.Text)
        Dim oSqlDisplay As New sqlClass
        Dim cSqlDisplay As String = "select * from " & bestHDatatable & " "
        cSqlDisplay &= "besth,klanten where besth_klant=kl_id and kl_nummer = " & sqlClass.c(cKl_Nummer) & " order by bestH_datlevering,bestH_id"
        Dim nDisplayLines As Long = oSqlDisplay.Execute(cSqlDisplay)
        If nDisplayLines = 0 Then
            MsgBox("Geen operaties voor deze klant")
            Return
        End If
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Maximum = nDisplayLines
        Me.ProgressBar1.Value = 0
        Me.GrdBase1.Rows.Clear()

        For Each oRow As DataRow In oSqlDisplay.dt.Rows
            Dim nLine As Integer = Me.GrdBase1.Rows.Add
            Me.GrdBase1("colDatum", nLine).Value = Format(oRow("Besth_datlevering"), "dd/MM/yy")
            Me.GrdBase1("colDag", nLine).Value = modDutch.cDagInDeWeek(oRow("Besth_datlevering"))
            Me.GrdBase1("colVolgnr", nLine).Value = Strings.Right(oRow("besth_Docnr"), 4)
            Me.GrdBase1("colTotaal", nLine).Value = oRow("besth_totTebetalen")
            ' Me.GrdBase1("colTotaal", nLine).Value = bzBestel.nTotaal(oRow("besth_id"), isParticulier)
            Me.GrdBase1("colPK", nLine).Value = oRow("BestH_id")
            Me.ProgressBar1.Value += 1
        Next
        Me.GrdBase1.CurrentCell = GrdBase1(0, GrdBase1.Rows.Count - 1)
        Me.ProgressBar1.Visible = False
        Me.Refresh()
    End Sub


    Private Sub GrdBase1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdBase1.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.Left = 5
            GrdBase1.CurrentRow.Selected = False
            GrdBase1.Rows(e.RowIndex).Selected = True
            Dim oFrm As New Bestelfrm
            oFrm.Show()
            oFrm.FormMode = ModeValues.RecordEntry
            oFrm.obzBestel.pk = GrdBase1("ColPk", GrdBase1.CurrentRow.Index).Value
            oFrm.obzBestel.load(oFrm.obzBestel.pk, IIf(bzKlanten.isParticulier(bzKlanten.kl_id(Me.cKl_Nummer)), "pH", "bestH"))
            Dim lCantLoad As Boolean = False
            oFrm.loadBestel(lCantLoad)
        End If

    End Sub
    Private Sub Excel_Click(sender As System.Object, e As System.EventArgs) Handles Excel.Click
        Me.doAfdrukken(preview:=True)
    End Sub

    Private Sub Afdrukken_Click(sender As System.Object, e As System.EventArgs) Handles Afdrukken.Click
        Me.doAfdrukken(preview:=False)
    End Sub

   
End Class

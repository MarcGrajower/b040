Public Class frmKlantFacturen
    Dim cKl_Nummer As String
    Dim lSubtractBTW As Boolean = False


    Private Sub frmFacturen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormMode = ModeValues.RecordEntry
        Me.GrdBase1.DefaultCellStyle.BackColor = Color.LightYellow
        Dim oNewCol1 As New DataGridViewTextBoxColumn
        Dim oNewCol2 As New DataGridViewTextBoxColumn
        Dim oNewCol3 As New DataGridViewTextBoxColumn
        Dim oNewCol4 As New DataGridViewTextBoxColumn
        oNewCol1.Name = "colDatum"
        oNewCol1.HeaderText = "Datum"
        'oNewCol1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        oNewCol1.Width = 75
        Me.GrdBase1.Columns.Add(oNewCol1)

        oNewCol2.Name = "colNummer"
        oNewCol2.HeaderText = "Nummer"
        'oNewCol2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        oNewCol2.Width = 75
        Me.GrdBase1.Columns.Add(oNewCol2)

        oNewCol3.Name = "colWaarde"
        oNewCol3.HeaderText = "Waarde"
        'oNewCol3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        oNewCol3.Width = 75
        Me.GrdBase1.Columns.Add(oNewCol3)

        oNewCol4.Name = "colDagen"
        oNewCol4.HeaderText = "Dagen"
        oNewCol4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.GrdBase1.Columns.Add(oNewCol4)

        Me.GrdBase1.maskit()
        ' Me.GrdBase1.RowsDefaultCellStyle = Me.GrdBase1.DefaultCellStyle
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
        Me.GrdBase1.Columns("colDatum").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.GrdBase1.Columns("colNummer").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.GrdBase1.Columns("colWaarde").DefaultCellStyle.Format = "N2"
        Me.GrdBase1.Columns("colWaarde").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GrdBase1.Columns("colDagen").DefaultCellStyle.Format = "N0"
        Me.GrdBase1.Columns("colDagen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GrdBase1.CurrentCell = Me.GrdBase1(0, 0)
        Me.GrdBase1.Rows(0).Selected = True
        Me.GrdBase1.TabStop = True
        Me.KeyPreview = True
    End Sub
    Public Overrides Sub clear()
        MyBase.clear()
        Me.TxtBase1.Text = ""
        Me.TxtBase2.Text = ""
        Me.TxtBase3.Text = ""
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
        Me.cKl_Nummer = Trim(Me.TxtBase1.Text)
        If cKl_Nummer = "" Then Return
        Dim obzKlanten As New bzKlanten
        If obzKlanten.Kl_NummerExists(cKl_Nummer) Then
            Me.cKl_Nummer = obzKlanten.kl_nummer
            Return
        End If

        If obzKlanten.KL_CodeExists(cKl_Nummer) Then
            Me.cKl_Nummer = obzKlanten.kl_nummer
            Return
        End If
        Dim oSql As New sqlClass
        Dim cSql = "select Kl_nummer,kl_Naam from Klanten where kl_Naam like " & sqlClass.cLike(Me.TxtBase1.Text) & " order by Kl_Naam"
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
        Dim oSql As New sqlClass
        Dim cSql As String = "select kl_nummer,kl_Naam,kl_BTWType from klanten where kl_nummer = " & sqlClass.c(cKl_Nummer)
        oSql.Execute(cSql)
        Me.TxtBase1.Text = oSql.dt(0)("Kl_Nummer")
        Me.TxtBase2.Text = oSql.dt(0)("Kl_Naam")
        Me.lSubtractBTW = (oSql.dt(0)("Kl_BTWType") = "2")
        Me.TxtBase3.Text = If(Me.lSubtractBTW, "Ja", "Neen")
        Dim oSqlDisplay As New sqlClass
        Dim cSqlDisplay As String = "select * from Facth,klanten where FActh_klant=kl_id and kl_nummer = " & sqlClass.c(cKl_Nummer) & " order by FactH_datum"
        Dim nDisplayLines As Long = oSqlDisplay.Execute(cSqlDisplay)
        If nDisplayLines = 0 Then
            MsgBox("Geen facturen voor deze klant")
            Me.TxtBase1.Focus()
            Return
        End If
        Me.GrdBase1.Rows.Clear()
        Dim dPrevious = Nothing
        For Each oRow As DataRow In oSqlDisplay.dt.Rows
            Dim nLine As Integer = Me.GrdBase1.Rows.Add
            Me.GrdBase1("colDatum", nLine).Value = Format(oRow("Facth_Datum"), "dd/MM/yy")
            Me.GrdBase1("colNUmmer", nLine).Value = oRow("FactH_Nummer")
            Me.GrdBase1("colWaarde", nLine).Value = oRow("FActH_TotBet") * If(Me.lSubtractBTW, (1 / (1 + oRow("FactH_BTW") / 100)), 1)
            Me.GrdBase1("colWaarde", nLine).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            If dPrevious IsNot Nothing Then
                Me.GrdBase1("colDagen", nLine).Value = (CType(oRow("FActh_Datum"), DateTime) - CType(dPrevious, DateTime)).Days
                Me.GrdBase1("colDagen", nLine).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            dPrevious = oRow("Facth_datum")
        Next
        Me.GrdBase1.CurrentCell = GrdBase1(0, GrdBase1.Rows.Count - 1)
        Me.Refresh()
    End Sub
    Private Sub previewFaktuur(nummer As String)
        If Trim(nummer) = "" Then
            Return
        End If
        Dim faktuur As New bzFactuur
        faktuur.cPrinter = "<PREVIEW>"
        frmMain.waitingMessage.Visible = True
        faktuur.print(nummer, 1)
        frmMain.waitingMessage.Visible = False
    End Sub
    Private Sub excelButton_Click(sender As System.Object, e As System.EventArgs) Handles excelButton.Click
        previewFaktuur(Me.GrdBase1("colNummer", Me.GrdBase1.CurrentRow.Index).FormattedValue)
    End Sub
    Private Sub frmKlantFacturen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.X Then
            previewFaktuur(Me.GrdBase1("colNummer", Me.GrdBase1.CurrentRow.Index).FormattedValue)
            e.Handled = True
        End If
    End Sub


End Class


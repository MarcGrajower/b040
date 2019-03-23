'Option Strict On
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Public Class Bestelfrm
    Inherits frmB040
    Public Enum eToggle
        eToggleBestelling
        eToggleLevering
    End Enum
    ''' <summary>
    ''' set in Form.Keydown if AltK was pressed
    ''' </summary>
    Dim altKPressed As Boolean = False
    Public obzBestel As New bzBestel
    Dim obzKlanten As New bzKlanten
    Dim bedieningO As New bzBediening
    Dim feestdagen As New bzFeestdagen
    Dim obzArtikel As New bzArtikel
    Dim bestelstatic As Bestel
    Dim eenhedenBzO As New bzEenheden
    Dim klanttext As String
    Dim klantcolor As Color
    Dim klantFont As Font
    Dim obzBoodschappen As New bzBoodschappen
    ' MG 24/mrt/11
    Dim obzOpschriften As New bzOpschriften
    Public oToggle As eToggle
    Dim cOmschrijving As String
    ' mg 03/sep/11
    ' add to make sure that DagLevering only updates DatumLevering from the combobox (and not when the "dag" is changed programmatically.
    Dim lDagleveringEntered As Boolean = False
    Dim normalKl_NummerWidth As Integer
    Dim normalKL_NummerMask As String = ""
    ''' <summary>
    ''' Set in Kl_Nummer_Validating if first byte is '0'
    ''' </summary>
    Dim _KL_Nummer_ValidatedAsTelefoon As Boolean

#Region "SAVE"
    Private Function diagnose() As Boolean
        If Val(cNvl(Me.Bestellinglijnen.Text)) = 0 Then
            If Not bzBestel.lExists(Me.BestelHBS.Current("BestH_Docnr")) Then
                MsgBox("Leeg document.")
            Else
                MsgBox("Gelieve document in zijn geheel te willen verwijderen (zie tab 'Document'")
            End If
            Return False
        End If
        Dim adres As Integer = Me.getAdresId
        If adres = 0 Then
            MsgBox("Er is geen leveringsadres voor deze klant.")
            Return False
        End If
        With Me.BestelHBS
            ' MG 24/feb/11
            If cNvl(.Current("besth_docnr")) = "" Then
                .Current("BestH_Docnr") = Me.obzBestel.nextDocnr(Me.obzKlanten.Zerofill(Me.KL_Nummer.Text) & Date.Parse(Me.BestH_DatLevering.Text).ToString("yyMMdd"), Me.oToggle = eToggle.eToggleLevering)
                Me.forcePageBinding()
            Else
                If obzBestel.existsDocnr(.Current("Besth_Docnr")) = False Then
                    Throw New InvalidOperationException("Docnr not null, yet does not exist?")
                End If
                If obzBestel.lMultipleInvoiced Then
                    MsgBox("Dit document kan niet veranderd worden. (Multiple Invoiced)")
                    Return False
                End If
            End If
            .Current("BestH_Klant") = Me.obzKlanten.record.KL_ID
            .Current("BestH_Bediening") = bzBediening.id(Me.Bediening.Text)
            .Current("BestH_Adres") = adres
            .Current("BestH_DatVervoer") = Now.Date
            .Current("BestH_TijdVervoer") = TimeOfDay.ToString("HH:mm")
            .Current("BestH_UurLevering") = cNvl(.Current("BestH_UurLevering"))

            .Current("BestH_INFO") = cNvl(.Current("BestH_INFO"))
            .Current("BestH_StType") = gen.nNvlI(.Current("BestH_StType"))
        End With
        Dim a As String
        For Each r As DataRowView In Me.BestelDBS
            a = cNvl(r("Art_nr"))
            If a = "" Then
                ' r.Delete()
            Else
                obzArtikel.Art_Nr = a
                r("Bestd_Artikel") = obzArtikel.Record.ARt_Id
                r("Bestd_IsStandaard") = bNvl(r("Bestd_isstandaard"))
                r("Bestd_Portie") = gen.nNvlD(r("Bestd_Portie"))
                r("bestd_opschrift") = cNvl(r("bestd_opschrift"))
                r("bestd_boodschap") = cNvl(r("bestd_boodschap"))
                r("bestd_voorafdrukken") = cNvl(r("bestd_voorafdrukken"))
                'Make sure there does not remain any null values before you save
                If r("bestd_Waarde") Is DBNull.Value Then r("bestd_Waarde") = 0
                If r("bestd_hoev") Is DBNull.Value Then
                    r("bestd_hoev") = 0
                    r("bestd_hoev1") = nNvlD(r("bestd_hoev1"))
                Else
                    If r("bestd_hoev1") Is DBNull.Value Then
                        r("bestd_hoev1") = r("bestd_hoev")
                    Else
                        r("Bestd_hoev1") = nNvlD(r("Bestd_hoev1"))
                    End If
                End If
                'If r("bestd_hoev1") Is DBNull.Value Then
                '    If nNvlD(r("best_hoev") <> 0 Then
                '        r("bestd_hoev1") = r("bestd_hoev")
                '    Else

                '    End If
                'End If
                'r("bestd_hoev1") = nNvlD(r("bestd_hoev1"))
                'If r("bestd_hoev") Is DBNull.Value Then
                '    r("bestd_hoev") = 0
                '    Continue For
                'End If
                'If r("bestd_hoev") = 0 Then
                '    If r("bestd_hoev1") Is DBNull.Value Then r("bestd_hoev1") = 0
                '    Continue For
                'End If
                'If r("bestd_hoev1") Is DBNull.Value Then r("bestd_hoev1") = r("bestd_hoev")

            End If
        Next
        Return True
    End Function
    Sub updateTotals(bestHTable As String, t As OleDbTransaction, conn As OleDbConnection, pk As Long)
        Dim cTotals As String
        Dim oSqlTotals As New sqlClass
        oSqlTotals.conn = conn

        cTotals = "update " & bestHTable & " "
        cTotals &= " set besth_totLijnen = " & Me.Bestellinglijnen.Text
        cTotals &= " , besth_totTebetalen = " & sqlClass.cDoubleForjet(Double.Parse(Me.TotaalEur.Text))
        cTotals &= " where besth_id = " & pk
        oSqlTotals.ExecuteNonQuery(cTotals, t)
    End Sub
    Private Function save() As Boolean
        Me.BestelHBS.EndEdit()
        Dim header As String = "BestH"
        Dim detail As String = "BestD"
        If bzKlanten.isParticulier(BestelDS.BestH(0).BestH_Klant) = True Then
            header = "PH"
            detail = "PD"
        End If
        Dim sql As New sqlClass
        sql.beginTransaction()
        Dim BestH_Id As Long
        Dim oldPk As Long = BestelDS.BestH(0).BestH_Id
        Dim Action As LogAction = IIf(BestelDS.BestH(0).BestH_Id > 0, LogAction.logUpdate, LogAction.logCreate)
        If Action = LogAction.logUpdate Then
            Dim sqlDeleteHeader As String = "delete * from " & header & " where bestH_id = " & oldPk
            sql.ExecuteNonQuery(sqlDeleteHeader)
        End If
        Dim builderInsertPH As New sqlClass.SqlBuilder
        builderInsertPH.cTable = header
        builderInsertPH.addInsert("BEstH_DocNr", sqlClass.c(BestelDS.BestH(0).BEstH_DocNr))
        builderInsertPH.addInsert("BestH_Klant", BestelDS.BestH(0).BestH_Klant)
        builderInsertPH.addInsert("BestH_KomtHalen", sqlClass.cBoolean(BestelDS.BestH(0).BestH_KomtHalen))
        builderInsertPH.addInsert("BestH_Bediening", BestelDS.BestH(0).BestH_Bediening)
        builderInsertPH.addInsert("BestH_DatBest", sqlClass.cDateForJet(BestelDS.BestH(0).BestH_DatBest))
        builderInsertPH.addInsert("BestH_DatLevering", sqlClass.cDateForJet(BestelDS.BestH(0).BestH_DatLevering))
        builderInsertPH.addInsert("BestH_UurLevering", sqlClass.c(BestelDS.BestH(0).BestH_UurLevering))
        builderInsertPH.addInsert("BestH_DatVervoer", sqlClass.cDateForJet(BestelDS.BestH(0).BestH_DatVervoer))
        builderInsertPH.addInsert("BestH_TijdVervoer", sqlClass.c(BestelDS.BestH(0).BestH_TijdVervoer))
        builderInsertPH.addInsert("BestH_Adres", BestelDS.BestH(0).BestH_Adres)
        builderInsertPH.addInsert("BestH_Info", sqlClass.c(BestelDS.BestH(0).BestH_Info))
        builderInsertPH.addInsert("BestH_Standaard", sqlClass.c(BestelDS.BestH(0).BestH_Standaard))
        builderInsertPH.addInsert("BestH_StToegepast", sqlClass.cBoolean(BestelDS.BestH(0).BestH_StToegepast))
        builderInsertPH.addInsert("BestH_StType", BestelDS.BestH(0).BestH_StType)
        builderInsertPH.addInsert("BestH_Factuur", sqlClass.c(BestelDS.BestH(0).BestH_Factuur))
        sql.ExecuteNonQuery(builderInsertPH.cInsert)
        BestH_Id = sql.retrieveNewKey
        BestelDBS.EndEdit()
        If Action = LogAction.logUpdate Then
            Dim sqlDeleteDetail As String = "delete * from " & detail & " where bestD_BESTH = " & oldPk
            sql.ExecuteNonQuery(sqlDeleteDetail)
        End If
        For Each r As BestelDS.BestDRow In BestelDS.BestD.Rows
            If r.RowState = DataRowState.Deleted Then Continue For
            If cNvl(r("Art_nr")) = "" Then Continue For
            builderInsertPH.cTable = detail
            builderInsertPH.addInsert("BestD_BestH", BestH_Id)
            builderInsertPH.addInsert("BestD_IsStandaard", sqlClass.cBoolean(r.BestD_IsStandaard))
            builderInsertPH.addInsert("BestD_Artikel", r.BestD_Artikel)
            builderInsertPH.addInsert("BestD_Omschrijving", sqlClass.c(r.BestD_Omschrijving))
            builderInsertPH.addInsert("BestD_Snijden", sqlClass.cBoolean(r.BestD_Snijden))
            builderInsertPH.addInsert("BestD_Tour", sqlClass.c(r.BestD_Tour))
            builderInsertPH.addInsert("BestD_Portie", sqlClass.cDoubleForjet(r.BestD_Portie))
            builderInsertPH.addInsert("BestD_Hoev", sqlClass.cDoubleForjet(r.BestD_Hoev))
            builderInsertPH.addInsert("BestD_Hoev1", sqlClass.cDoubleForjet(nNvlD(r.BestD_Hoev1)))
            builderInsertPH.addInsert("BestD_EenhPrijs", sqlClass.cDoubleForjet(r.BestD_EenhPrijs))
            builderInsertPH.addInsert("BestD_Waarde", sqlClass.cDoubleForjet(r.BestD_Waarde))
            builderInsertPH.addInsert("BestD_Verwittigen", sqlClass.cBoolean(r.BestD_Verwittigen))
            builderInsertPH.addInsert("BestD_Opschrift", sqlClass.c(r.BestD_Opschrift))
            builderInsertPH.addInsert("BestD_Boodschap", sqlClass.c(r.BestD_Boodschap))
            builderInsertPH.addInsert("bestd_voorafdrukken", sqlClass.c(r.bestd_voorafdrukken))
            sql.ExecuteNonQuery(builderInsertPH.cInsert)
        Next

        updateTotals(header, sql.t, sql.conn, BestH_Id)
        nlog(Me.BestH_Docnr.Text, Me.Name, LogType.logNormal, Action, header, BestH_Id)
        sql.commitTransation()
        ' Restore the newly created key in the DS.   Normal save overwrites this, but BewaarEnBlijf needs this
        ' because otherwise, it does not delete the right record before it inserts the new one and a duplicate 
        ' record is created.
        BestelDS.BestH(0).BestH_Id = BestH_Id
        Return True
    End Function
    Private Sub BewaarEnBlijf_Click(sender As Object, e As EventArgs) Handles BewaarEnBlijf.Click

        Dim saveWaitingmessage As String = frmMain.waitingMessage.Text
        frmMain.waitingMessage.Text = "Uw document wordt nu bewaard"
        frmMain.waitingMessage.Visible = True
        frmMain.Refresh()
        Me.SuspendLayout()
        If Me.diagnose = False Then
            ResumeLayout()
            frmMain.waitingMessage.Visible = False
            frmMain.waitingMessage.Text = saveWaitingmessage
            Return
        End If
        Me.save()
        For Each r As DataRowView In Me.BestelDBS
            If cNvl(r("Art_nr")) = "" Then
                Continue For
            End If
            If r("bestd_hoev") = 0 Then
                r("bestd_hoev") = DBNull.Value
            Else
                If r("bestd_hoev1") = r("bestd_Hoev") Then
                    r("bestd_hoev1") = DBNull.Value
                End If
            End If
        Next
        Me.ResumeLayout()
        Me.SetStyle(ControlStyles.UserPaint, False)
        frmMain.waitingMessage.Visible = False
        frmMain.waitingMessage.Text = saveWaitingmessage
        Me.grdBestelD.Focus()
        Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
        Me.grdBestelD.CurrentCell.Selected = True
        If cNvl(grdBestelD.CurrentRow.Cells("Art_nr").Value) <> "" Then
            Me.obzArtikel.Art_Nr = grdBestelD.CurrentRow.Cells("Art_nr").Value
        End If
    End Sub

#End Region
#Region "history"
    Sub initializeHistory()
        Dim oSQLBestel As New sqlClass
        Dim sqlString As String = "select Klanten.KL_Naam,right(BestH_Docnr,4),BestH_DatLevering,BestH_DatLevering,BestH_ID,besth_totLijnen,besth_totTeBetalen,BestH_Docnr "
        sqlString &= "from BestH,Klanten "
        sqlString &= "where BestH_Klant = Kl_id "
        sqlString &= "order by bestH_id"
        oSQLBestel.Execute(sqlString)
        displayInHistory(oSQLBestel, Me.grdHistory)
        Dim oSQLP As New sqlClass
        sqlString = "select Klanten.KL_Naam,right(BestH_Docnr,4),BestH_DatLevering,BestH_DatLevering,BestH_ID,besth_totLijnen,besth_totTeBetalen,BestH_Docnr "
        sqlString &= "from pH,Klanten "
        sqlString &= "where BestH_Klant = Kl_id "
        sqlString &= "order by bestH_id"
        oSQLP.Execute(sqlString)
        displayInHistory(oSQLP, Me.particulierenOverzichtDatagridview)
    End Sub
    Sub displayInHistory(ByVal osql As sqlClass, historyGrid As DataGridView)
        If osql.dt.Rows.Count = 0 Then Exit Sub
        historyGrid.DataSource = osql.dt
        historyGrid.Columns(0).HeaderText = "Naam"
        historyGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        historyGrid.Columns(1).HeaderText = "Doc"
        historyGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        historyGrid.Columns(2).HeaderText = "Levering"
        historyGrid.Columns(2).DefaultCellStyle.Format = "dd/MMM/yy"
        historyGrid.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        historyGrid.Columns(3).HeaderText = "Dag"
        historyGrid.Columns(3).DefaultCellStyle.Format = "dddd"
        historyGrid.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        historyGrid.Columns(4).Visible = False
        historyGrid.Columns(5).HeaderText = "Lijnen"
        historyGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        historyGrid.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        historyGrid.Columns(6).HeaderText = "Te Betalen"
        historyGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        historyGrid.Columns(6).DefaultCellStyle.Format = "N2"
        historyGrid.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        historyGrid.Columns(7).Visible = False
        Dim f As Font = historyGrid.DefaultCellStyle.Font
        historyGrid.DefaultCellStyle.Font = New Font(f.FontFamily, 12, FontStyle.Bold)


        'For Each oRow As DataRow In osql.dt.Rows
        '    nRow += 1
        '    frmMain.ToolStripProgressBar1.Value = nRow
        '    historyGrid.Rows.Add()
        '    historyGrid(0, nRow).Value = oRow("Kl_Naam")
        '    historyGrid(1, nRow).Value = Strings.Right(oRow("BestH_DocNr").ToString, 4)
        '    historyGrid(2, nRow).Value = oRow("BestH_DatLevering")
        '    historyGrid(3, nRow).Value = modDutch.cDagInDeWeek(oRow("BestH_DatLevering"))
        '    historyGrid(4, nRow).Value = oRow("Besth_Id")
        '    historyGrid(5, nRow).Value = nNvlD(oRow("Besth_totLijnen"))
        '    historyGrid(6, nRow).Value = nNvlD(oRow("Besth_totTeBetalen"))
        '    historyGrid(7, nRow).Value = oRow("Besth_Docnr")

        'Next

        frmMain.ToolStripProgressBar1.Visible = False
        Dim nRow As Integer = osql.dt.Rows.Count
        historyGrid.CurrentCell = historyGrid(0, nRow - 1)
        historyGrid.Rows(nRow - 1).Selected = True
    End Sub
    Sub filterHistory(ByVal cKlNummer As String)
        Dim obzKlanten As New bzKlanten
        obzKlanten.kl_nummer = cKlNummer
        Dim nKL_ID As Long = obzKlanten.record.KL_ID
        Dim tableName As String = IIf(bzKlanten.isParticulier(nKL_ID), "pH", "BestH")
        Dim historyGrid As DataGridView = IIf(bzKlanten.isParticulier(nKL_ID), Me.particulierenOverzichtDatagridview, Me.grdHistory)
        Dim oSql As New sqlClass
        Dim sql As String = "select Klanten.KL_Naam,right(BestH_Docnr,3),BestH_DatLevering,space(8) as Dag,BestH_ID,besth_totLijnen,besth_totTeBetalen,BestH_Docnr "
        sql &= "from " & tableName & ",Klanten "
        sql &= "where BestH_Klant = Kl_id  and Kl_Id = " & nKL_ID & " order by BestH_Id"
        oSql.Execute(sql)
        displayInHistory(oSql, historyGrid)
    End Sub
    Private Sub goBottom(d As DataGridView)
        Dim lastline As Integer = d.Rows.Count - 1
        d.CurrentCell = d(0, lastline)
    End Sub
    Private Sub goTop(d As DataGridView)
        d.CurrentCell = d(0, 0)
    End Sub
    Private Sub handleOverzichtKeydown(historyGrid As DataGridView, sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.loadFromHistory(historyGrid)
            ' e.Handled = True
            Return
        End If
        If e.Control = True And Keys.Down Then
            goBottom(historyGrid)
            'e.Handled = True
            Return
        End If
        If e.Control = True And Keys.Up Then
            goTop(historyGrid)
            'e.Handled = True
            Return
        End If
    End Sub
    Private Sub grdHistory_KeyDown(sender As Object, e As KeyEventArgs) Handles grdHistory.KeyDown
        handleOverzichtKeydown(grdHistory, sender, e)
    End Sub
    Private Sub particulierenOverzichtDatagridview_KeyDown(sender As Object, e As KeyEventArgs) Handles particulierenOverzichtDatagridview.KeyDown
        handleOverzichtKeydown(particulierenOverzichtDatagridview, sender, e)
    End Sub
    Private Sub particulierenGotopButton_Click(sender As Object, e As EventArgs) Handles particulierenGotopButton.Click
        goTop(particulierenOverzichtDatagridview)
    End Sub
    Private Sub particulierenGobottomButton_Click(sender As Object, e As EventArgs) Handles particulierenGobottomButton.Click
        goBottom(particulierenOverzichtDatagridview)
    End Sub
    Private Sub overzichtGotopButton_Click(sender As Object, e As EventArgs) Handles overzichtGotopButton.Click
        goTop(grdHistory)
    End Sub
    Private Sub overzichtGobottomButton_Click(sender As Object, e As EventArgs) Handles overzichtGobottomButton.Click
        goBottom(grdHistory)
    End Sub

    Private Sub grdHistory_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdHistory.CellContentClick
        If e.ColumnIndex = 1 And e.RowIndex = -1 Then
            Me.grdHistory.Sort(Me.grdHistory.Columns("BestH_id"), System.ComponentModel.ListSortDirection.Ascending)
        End If
    End Sub
    Private Sub particulierenOverzichtDatagridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles particulierenOverzichtDatagridview.CellContentClick
        If e.ColumnIndex = 1 And e.RowIndex = -1 Then
            Me.particulierenOverzichtDatagridview.Sort(Me.particulierenOverzichtDatagridview.Columns("BestH_id"), System.ComponentModel.ListSortDirection.Ascending)
            Exit Sub
        End If
    End Sub
    Private Sub loadFromHistory(historyGrid As DataGridView)
        If Me.FormMode = ModeValues.RecordEntry Then
            unlockSession(Me.nLogSession)
        End If
        Dim documentColumn As Integer = 7
        Dim document As String = historyGrid.SelectedRows(0).Cells(documentColumn).Value
        Dim headerTable = IIf(bzKlanten.isParticulierFromDocument(document), "PH", "BestH")
        Dim pkColumn As Integer = 4
        Me.obzBestel.load(historyGrid.SelectedRows(0).Cells(pkColumn).Value, headerTable)
        Dim lCantLoad As Boolean = False
        Me.loadBestel(lCantLoad)
        If lCantLoad Then
            MsgBox("Can't load")
            Exit Sub
        End If
        Me.bestelTabpage.SelectTab(0)
        Me.bestelTabpage.Focus()
        Me.grdBestelD.Focus()
    End Sub
    Private Sub grdHistory_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdHistory.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Me.loadFromHistory(Me.grdHistory)
    End Sub
    Private Sub particulierenOverzichtDatagridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles particulierenOverzichtDatagridview.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Me.loadFromHistory(Me.particulierenOverzichtDatagridview)
    End Sub
#End Region
#Region "NulBestelling"
    Private Sub NulBestelling_Click(sender As System.Object, e As System.EventArgs) Handles NulBestelling.Click
        setNulbestelling()
    End Sub
    Sub setNulbestelling()
        If oToggle = eToggle.eToggleBestelling Then
            For Each oRow As DataGridViewRow In Me.grdBestelD.Rows
                oRow.Cells("BestD_Hoev1").Value = 0
                oRow.Cells("BestD_Waarde").Value = 0
                Me.calculate()
            Next
        End If
    End Sub
#End Region ' Nul Bestelling
    Private Sub Bestelfrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.oToggle = eToggle.eToggleBestelling Then Exit Sub
        Dim nCount As Long
        For Each oRow As DataGridViewRow In grdBestelD.Rows
            If oRow.Cells("Art_Nr").Value Is Nothing Then Exit For
            If Trim(CStr(oRow.Cells("Art_Nr").Value)) <> "" Then nCount += 1
            Exit For
        Next
        If nCount > 0 Then
            If modDutch.YesNO("Dit formulier wordt nu gesloten.  Uw aanpassingen worden niet bewaard.  Gelieve te bevestigen.") = False Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub Bestelfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        normalKl_NummerWidth = KL_Nummer.Width
        normalKL_NummerMask = KL_Nummer.Mask
        Me.bestelTabpage.SelectTab("particulierenTabpage")
        Me.bestelTabpage.SelectTab(3)
        Me.bestelTabpage.SelectTab(2)
        Me.bestelTabpage.SelectTab(1)
        Me.bestelTabpage.SelectTab(0)
        Me.bestelTabpage.Focus()
        Me.bedieningO.fillCbo(Me.Bediening)
        Me.grdBestelD.setColumnTabstopFalse("Bestd_Snijden")
        Me.grdBestelD.setColumnTabstopFalse("Tour")
        Me.grdBestelD.setColumnTabstopFalse("Omschrijving")
        Me.grdBestelD.setColumnDisabled("Standaard")
        Me.grdBestelD.setColumnDisabled("Eenh_Omschrijving")
        Me.grdBestelD.setColumnDisabled("Eenh_HoevInvoer")
        Me.grdBestelD.setColumnDisabled("BestD_EenhPrijs")
        Me.grdBestelD.setColumnTabstopFalse("Bestd_Waarde")
        Me.grdBestelD.setColumnTabstopFalse("Voorafdrukken")

        ' MG 16/mrt/11
        Me.grdBestelD.setColumnDecimals("Bestd_Portie", 0)
        Me.grdBestelD.setColumnDecimals("Standaard", 0)
        Me.grdBestelD.setColumnDecimals("Bestd_Hoev1", 0)
        Me.grdBestelD.setColumnDecimals("Bestd_Waarde", 2)

        Me.grdBestelD.columnValidateIfEmpty(Me.grdBestelD.Columns("Bestd_Hoev1").Index) = True
        Me.grdBestelD.DefaultCellStyle.Font = New Font("Trebuchet MS", 12, FontStyle.Bold)
        TypSTBestFillCbo(Me.StType) ' MG 27/feb/11
        Me.klanttext = Me.KlantLbl.Text
        Me.klantcolor = Me.KlantLbl.ForeColor
        Me.klantFont = Me.KlantLbl.Font
        ' MG 11/dec/11
        Me.KL_Nummer.backColorFocus = Color.LightPink
        For Each oCol As DataGridViewColumn In Me.grdHistory.Columns
            If oCol.Visible Then oCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        bzBestel.loadMonthcalendarForDat_Levering(Me.MonthCalendar1)
        MonthCalendar1.FirstDayOfWeek = Windows.Forms.Day.Sunday
        Me.DagLevering.nIO = IOValues.IOAlwaysDisable
        Me.BestH_DatLevering.nIO = IOValues.IOAlwaysDisable
        Me.clear()
    End Sub
    Public Overrides Sub clear()
        If Me.lastKeycode = Keys.Home Then
            If Me.cActiveControlName = "GRDBESTELD" Then
                If YesNO("Dit formulier wordt nu leeggemaakt.  Gelieve te bevestigen.") = False Then
                    Exit Sub
                End If
            End If
        End If
        MyBase.clear()
        Me.BestelDS.Clear()
        Me.FormMode = ModeValues.KeyEntry
        Me.BestelHBS.AddNew()
        Me.KlantLbl.Text = Me.klanttext
        Me.KlantLbl.ForeColor = Me.klantcolor
        Me.KlantLbl.Font = Me.klantFont
        Dim AddressRow As Integer : For AddressRow = 1 To 4 : Me.AdresBS.AddNew() : Next : Me.AdresBS.MoveFirst()
        Dim BestelDRow As Integer : For BestelDRow = 1 To 30 : Me.BestelDBS.AddNew() : Next : Me.BestelDBS.MoveFirst()
        Me.BestelHBS(0)("besth_datbest") = Now
        Me.txtBestH_DatBest2.Text = Format(Now, cDateFormat)
        If oToggle = eToggle.eToggleBestelling Then
            Me.BestH_DatLevering.Text = Format(bzBestel.dGetLeveringForBestellingDatum(Now), cDateFormat)
        Else
            Me.BestH_DatLevering.Text = Format(bzBestel.dGetDefaultLeveringDatum, cDateFormat)
        End If
        Me.obzBestel.pk = 0
        Me.DagLevering.Text = modDutch.cDagInDeWeek(CDate(Me.BestH_DatLevering.Text))
        Me.VolgendeFeestdag.Text = Me.feestdagen.volgende(Now)
        ' MG 27/feb/11
        Me.BestelHBS.Current("besth_StToegepast") = True
        Me.StType.Text = Me.DagLevering.Text
        Me.MonthCalendar1.SetSelectionRange(CDate(Me.BestH_DatLevering.Text), CDate(Me.BestH_DatLevering.Text))
        Me.MonthCalendar1.Enabled = True
        BetalingTextbox.Text = ""
        'Me.BestelHBS.Current("BestH_Standaard") = "1"
        Me.BestelHBS(0)("besth_Standaard") = "1"
        Me.bestelTabpage.SelectTab(0)
        Me.bestelTabpage.Focus()
        Me.DagLevering.Focus()
        Me.TotaalEur.Text = ""
        Me.TotBTW.Text = ""
        Me.Bestellinglijnen.Text = ""
        Me.BestH_StToegepast.Text = "Ja"
        'Me.BestelHBS.Current("besth_Standaard") = 1
        Me.BestelHBS.Current("BestH_Standaard") = "1"
        Me.BestelHBS(0)("besth_Standaard") = "1"
        Me.BestH_Standaard.Text = "1"
        ' MG 26/jun/11
        Me.TabPage1.Text = "Document"
        Me.obzBestel.pk = 0
        Me.grdBestelD.ClearSelection()
        Me.initializeHistory()
        Me.setToggle()
        Me.KL_Nummer.Select()
    End Sub
    Private Sub DagLevering_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles DagLevering.Enter
        Me.lDagleveringEntered = True
    End Sub
    Private Sub DagLevering_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DagLevering.Leave
        Me.lDagleveringEntered = False
        If Me.KL_Nummer.Text = "" Then
            Me.KL_Nummer.Focus()
        End If
    End Sub
    Private Sub DagLevering_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DagLevering.Validating
        If feestdagen.isFeesdag(Date.Parse(Me.BestH_DatLevering.Text)) Then
            e.Cancel = True
            Exit Sub
        End If
        Me.StType.Text = Me.DagLevering.Text
        Me.StType.Refresh()
    End Sub
    Private Sub txtBestH_DatBest2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBestH_DatBest2.Validating
        If checkDate(Me.txtBestH_DatBest2.Text) = False Then
            MsgBox(Me.txtBestH_DatBest2.Text & " is geen geldige datum.")
            e.Cancel = True
            Exit Sub
        End If
        If feestdagen.isFeesdag(Date.Parse(Me.BestH_DatLevering.Text)) Then
            e.Cancel = True
            Exit Sub
        End If
        If Me.oToggle = eToggle.eToggleLevering Then
            Me.BestH_DatLevering.Text = Me.txtBestH_DatBest2.Text
        Else
            Me.BestH_DatLevering.Text = Format(bzBestel.dGetLeveringForBestellingDatum(Date.Parse(Me.txtBestH_DatBest2.Text)), cDateFormat)
        End If
        Me.DagLevering.Text = modDutch.cDagInDeWeek(CDate(Me.BestH_DatLevering.Text))
    End Sub
#Region "KL_Nummer"
    Private Sub KL_Nummer_Enter(sender As Object, e As EventArgs) Handles KL_Nummer.Enter
        KL_Nummer.Width = 200
        KL_Nummer.Mask = ">" & New String("C", 23)
    End Sub
    Private Sub KL_Nummer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles KL_Nummer.KeyDown
        If e.KeyCode = Keys.Insert Then
            If cNvl(Me.KL_Nummer.Text) <> "" Then Exit Sub
            Dim oFrm As New KlantenFrm
            oFrm.eOpenMode = eFormOpen.eFromOpenNew
            oFrm.cParameter = ""
            oFrm.ModeShow = b040.ModeShow.Modal
            oFrm.ShowDialog()
            Me.KL_Nummer.Text = oFrm.cParameter
            oFrm = Nothing
            Me.SelectNextControl(Me.KL_Nummer, True, True, True, True)
        End If
    End Sub
    Private Sub KL_Nummer_TextChanged(sender As System.Object, e As System.EventArgs) Handles KL_Nummer.TextChanged
        Me.setbackground(Me.KL_Nummer.Text)
    End Sub
    Private Sub KL_Nummer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles KL_Nummer.Validated
        If Trim(Me.KL_Nummer.Text) = "" Then Exit Sub
        Me.MonthCalendar1.Enabled = False
        setKlantLbl()
        If Me.oToggle = eToggle.eToggleBestelling Then
            If Me.obzBestel.lExistsBestelling(Me.obzKlanten.record.KL_ID, CDate(Me.BestH_DatLevering.Text), lBestellingOnly:=True) Then
                Dim lCantLoad As Boolean = False
                Me.loadBestel(lCantLoad)
                If lCantLoad Then
                    ' Throw New InvalidOperationException("Bestelling kan niet geladen worden.")
                    Exit Sub
                End If
                Me.MonthCalendar1.SetDate(CDate(Me.BestH_DatLevering.Text))
                Me.bestelTabpage.SelectTab(0)
                Me.grdBestelD.Focus()
                Exit Sub
            End If
        End If
        Me.KL_Nummer.Text = Me.obzKlanten.record.KL_Nummer
        Me.KL_Naam.Text = Me.obzKlanten.record.KL_Naam
        Me.Adr_Telefoon.Text = CType(Me.obzKlanten.Adr_Telefoon(), String)
        Me.BestH_KomtHalen.cast(Me.obzKlanten.record.KL_KomtHalen)
        Me.bedieningO.bed_id = Me.obzKlanten.record.KL_Bediening
        Dim klantenEFacturatieType = (Me.obzKlanten.GetKlantenEType())
        Me.Bediening.Text = Me.bedieningO.record.BEd_naam
        SetBetaling(KL_Nummer.Text)
        Dim lines As Integer = Me.BestelAdresTA.Fill(Me.BestelDS.Adres, Me.obzKlanten.record.KL_ID)
        Me.bestelTabpage.SelectTab(2)
        Me.AdresG.Select()
        Me.AdresG(Me.AdresG.Columns("Kies").Index, 0).Value = True
        If lines < 4 Then
            For i As Integer = 1 To 4 - lines
                Me.AdresBS.AddNew()
            Next
        End If
        Me.AdresBS.MoveFirst()
        Me.FormMode = ModeValues.RecordEntry
        Me.Bediening.SelectionLength = 0
        Me.TxtNrLevering.Text = ""
        If Me.oToggle = eToggle.eToggleLevering Then Me.TxtNrLevering.Text = bzBestel.cNextNrLevering(Me.KL_Nummer.Text, CDate(Me.BestH_DatLevering.Text))
        Me.loadStandaard() ' MG 27/feb/11
        Me.filterHistory(Me.KL_Nummer.Text)
        Me.bestelTabpage.SelectTab(0)
        Me.grdBestelD.Focus()
        ResetKl_Nummer()
        frmMain.typeKlant = klantenEFacturatieType

    End Sub
    Private Sub KL_Nummer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles KL_Nummer.Validating
        Dim input As String = Trim(Me.KL_Nummer.Text)
        If input = "" Then Exit Sub
        If bzBestel.lValidLeverdatum(CDate(Me.BestH_DatLevering.Text)) = False Then
            MsgBox("De leveringsdatum is niet geldig (Feesdag of Zaterdag)")
            e.Cancel = True
            Exit Sub
        End If
        If oToggle = eToggle.eToggleLevering Then
            If (CDate(Me.BestH_DatLevering.Text)) <> Now.Date Then
                If YesNO("Opgelet.  De leveringsdatum is niet vandaag.  Gelieve te bevestigen.") = False Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
        _KL_Nummer_ValidatedAsTelefoon = (Mid(input, 1, 1) = "0")
        If Mid(input, 1, 1) = "0" Then
            Adr_Telefoon.Text = input
            Adr_Telefoon_Validating(sender, e)
            Exit Sub
        End If
        If obzKlanten.Kl_NummerExists(input) Then
            If oToggle = eToggle.eToggleBestelling Then
                If (CDate(Me.BestH_DatLevering.Text)) <= Now Then
                    If Me.obzBestel.lExistsBestelling(Me.obzKlanten.record.KL_ID, CDate(Me.BestH_DatLevering.Text)) = False Then
                        If YesNO("Opgelet.  U tracht een bestelling in het verleden in te geven.  Gelieve te bevestigen.") = False Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
            End If
            If obzKlanten.record.KL_Actief = False Then
                If YesNO("Klant " & Trim(obzKlanten.record.KL_Naam) & " staat op inactief.  Gelieve te bevestigen.") = False Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If obzKlanten.KL_CodeExists(input) Then
            If oToggle = eToggle.eToggleBestelling Then
                If (CDate(Me.BestH_DatLevering.Text)) <= Now Then
                    If Me.obzBestel.lExistsBestelling(Me.obzKlanten.record.KL_ID, CDate(Me.BestH_DatLevering.Text)) = False Then
                        If YesNO("Opgelet.  U tracht een bestelling in het verleden in te geven.  Gelieve te bevestigen.") = False Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
            End If
            If obzKlanten.record.KL_Actief = False Then
                If YesNO("Deze klant staat op inactief.  Gelieve te bevestigen.") = False Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        Dim klid As Long
        bzKlantenSearch.SearchKlant(input, klid)
        If klid = 0 Then
            e.Cancel = True
            Exit Sub
        End If
        obzKlanten.kl_nummer = bzKlanten.getKlNummer(klid)
        Me.KL_Nummer.Text = obzKlanten.kl_nummer
        If oToggle = eToggle.eToggleBestelling Then
            If (CDate(Me.BestH_DatLevering.Text)) <= Now Then
                If Me.obzBestel.lExistsBestelling(Me.obzKlanten.record.KL_ID, CDate(Me.BestH_DatLevering.Text)) = False Then
                    If YesNO("Opgelet.  U tracht een bestelling in het verleden in te geven.  Gelieve te bevestigen.") = False Then
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        End If
        If obzKlanten.record.KL_Actief = False Then
            If YesNO("Deze klant staat op inactief.  Gelieve te bevestigen.") = False Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub
#End Region
    Private Sub Adr_Telefoon_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Adr_Telefoon.Validating
        If Trim(Me.Adr_Telefoon.Text) = "" Then
            Return
        End If
        Dim pk As Long = bzKlanten.searchByTelefoon(Trim(Me.Adr_Telefoon.Text), Adr_Telefoon)
        If pk = 0 Then
            MsgBox("Telefoon nr is niet in het bestand")
            e.Cancel = True
            Return
        End If
        Me.KL_Nummer.Text = bzKlanten.cNummer(pk)
        Me.obzKlanten.kl_nummer = Me.KL_Nummer.Text
        If _KL_Nummer_ValidatedAsTelefoon = False Then
            KL_Nummer_Validated(sender, e)
        End If
    End Sub
    Private Sub CloseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseBtn.Click
        If Me.lastKeycode = Keys.Escape Then
            If Me.cActiveControlName = "GRDBESTELD" Then
                If YesNO("Dit formulier wordt nu gesloten." & vbCrLf & "Uw aanpassingen worden niet bewaard." & vbCrLf & "Gelieve te bevestigen.") = False Then
                    Exit Sub
                End If
            End If
        End If
        Me.Close()
    End Sub
    Public Overrides Function grdValidate(ByVal ctrl As String, ByRef input As String) As Boolean
        Dim l As Boolean = MyBase.grdValidate(ctrl, input)
        Try : input = Trim(input) : Catch : End Try
        Dim cCtrl As String = UCase(ctrl)
        Dim cArtikel As String = gen.cNvl(Me.grdBestelD.currentColumnValue("ART_NR"))
        If cCtrl <> "ART_NR" And cArtikel = "" Then
            input = ""
            Return True
        End If
        Select Case UCase(ctrl)
            Case "ART_NR"
                If Trim(input) = "" Then Return True
                Dim replace As String = New Regex("[^a-zA-Z0-9 -]").ToString

                ' MG 20/feb/11
                Dim oSrch As New bzArtikel.clsSearch
                With oSrch
                    .allowNietActief = False
                    .cInput = Trim(input)
                    .oCaller = Me.grdBestelD.EditingControl
                    .nFieldLength = Me.obzArtikel.nFieldLength("Art_Nr")
                    .search()
                    If .lFound = True Then
                        Me.obzArtikel.Art_Nr = .cArtNr
                        If Me.obzArtikel.Record.Art_Actief = False Then
                            MsgBox("Artikel is inactief")
                            Return False
                        End If
                        ' MG 11/dec/11 not sure this right!
                        If Me.checkDuplicate = True Then
                            MsgBox("Artikel is reeds in deze bestelling")
                            Return False
                        End If
                        input = .cArtNr
                        Me.grdBestelD.currentColumnValue("colArtNrBound") = .cArtNr
                        Me.loadArtikel()
                        If Me.obzArtikel.Record.Art_Prijs = 0 Then
                            Me.grdBestelD.setColumnTabstopFalse("BESTD_Hoev1")
                            Me.grdBestelD.setColumnTabstop("BESTD_Waarde")
                        Else
                            Me.grdBestelD.setColumnTabstop("BESTD_Hoev1")
                            Me.grdBestelD.setColumnTabstopFalse("BESTD_Waarde")
                        End If
                        Return True
                    End If
                    If .lUserCanceled = False Then
                        MsgBox(.cMessage)
                    End If
                    Return False
                End With
            Case "TOUR"
                If Bestel.Tour.Valid(input) = False Then
                    MsgBox(Bestel.Tour.ErrorMsg)
                    Return False
                End If
            Case "BESTD_HOEV1"
                input = Trim(input)
                If input = "" Then
                    input = ""
                    If Val(Me.grdBestelD.currentColumnValue("STANDAARD")) = 0 Then
                        If Me.obzArtikel.Record.Art_Prijs <> 0 Then
                            Me.grdBestelD.currentColumnValue("BESTD_WAARDE") = 0
                        End If
                    Else
                        Me.grdBestelD.currentColumnValue("BESTD_WAARDE") = Me.obzArtikel.Waarde(Me.grdBestelD.currentColumnValue("STANDAARD"))
                    End If
                    Me.calculate()
                    Return True
                End If
                'input = modDutch.cIntegerParse(input)
                Dim n As Double = 0
                Try
                    n = Convert.ToDouble(input)
                Catch
                End Try

                Dim nHoev1 As Double = nRound(n, 0)
                Dim waarde As Double = gen.nNvlD(Me.grdBestelD.currentColumnValue("BESTD_WAARDE"))
                If Me.obzArtikel.Record.Art_Prijs <> 0 Then
                    If obzArtikel.Record.Art_Eenheid = 2 Then
                        Me.grdBestelD.currentColumnValue("BESTD_WAARDE") = n * Me.grdBestelD.currentColumnValue("BESTD_EENHPRIJS")
                    Else
                        Me.grdBestelD.currentColumnValue("BESTD_WAARDE") = Me.obzArtikel.Waarde(nHoev1)
                    End If

                End If

                If Me.obzArtikel.Record.Art_PerPersoon Then
                    Me.grdBestelD.currentColumnValue("BESTD_PORTIE") = nRound(Val(input) / Me.obzArtikel.Record.Art_Portie, 0)
                End If
            Case "BESTD_WAARDE"
                ' not sure what this is for
                If Me.grdBestelD.EditingControl Is Nothing Then
                    input = "0.00"
                End If
                If Me.obzArtikel.Record.Art_Prijs = 0 Then
                    Me.grdBestelD.currentColumnValue("BESTD_HOEV1") = 0
                    Return True
                End If
                Dim n As Double = 0
                Try
                    n = Convert.ToDouble(input)
                Catch
                End Try
                If obzArtikel.Record.Art_Eenheid = 2 Then
                    Dim hoev = gen.nNvlD(grdBestelD.currentColumnValue("BESTD_HOEV1"))
                    If hoev = 0 Then
                        hoev = gen.nNvlD(grdBestelD.currentColumnValue("STANDAARD"))
                    End If
                    If hoev = 0 Then
                        MsgBox("Hoeveelheid is nul.")
                        Return False
                    End If
                    Me.grdBestelD.currentColumnValue("BESTD_EENHPRIJS") = n / hoev
                Else
                    Me.grdBestelD.currentColumnValue("BESTD_HOEV1") = Me.obzArtikel.calcHoev(n)
                End If
                If Me.obzArtikel.Record.Art_PerPersoon Then
                    Me.grdBestelD.currentColumnValue("BESTD_PORTIE") = nRound(Me.grdBestelD.currentColumnValue("BESTD_HOEV1") / Me.obzArtikel.Record.Art_Portie, 0)
                End If
            Case "BESTD_PORTIE"
                ' MG 16/mrt/11
                If IsNothing(Me.obzArtikel.Record) Then
                    Me.grdBestelD.currentColumnValue("Bestd_Hoev1") = ""
                    Me.grdBestelD.currentColumnValue("BESTD_WAARDE") = ""
                    input = ""
                Else
                    Me.grdBestelD.currentColumnValue("Bestd_Hoev1") = Val(input) * Me.obzArtikel.Record.Art_Portie
                    Me.grdBestelD.currentColumnValue("BESTD_WAARDE") = Me.obzArtikel.Waarde(Me.grdBestelD.currentColumnValue("BESTD_HOEV1"))
                End If
            Case "BESTD_BOODSCHAP"
                ' MG 19/mrt/11
                If Trim(Me.grdBestelD.currentColumnValue("BESTD_BOODSCHAP")) = "" Then
                    Me.grdBestelD.currentColumnValue("BESTD_BOODSCHAP") = ""
                    Exit Function
                End If
                Me.grdBestelD.currentColumnValue("BESTD_BOODSCHAP") = UCase(Me.grdBestelD.currentColumnValue("BESTD_BOODSCHAP"))
                Me.obzBoodschappen.checkNewValue(Me.grdBestelD.currentColumnValue("BESTD_BOODSCHAP"), CType(Me.grdBestelD.Columns("Bestd_Boodschap"), DataGridViewComboBoxColumn))
                Me.grdBestelD.currentColumnValue("BESTD_BOODSCHAP") = UCase(Me.grdBestelD.currentColumnValue("BESTD_BOODSCHAP"))
            Case "BESTD_OPSCHRIFT"
                ' MG 19/mrt/11
                If Trim(Me.grdBestelD.currentColumnValue("BESTD_OPSCHRIFT")) = "" Then
                    Me.grdBestelD.currentColumnValue("BESTD_OPSCHRIFT") = ""
                    Exit Function
                End If
                Me.grdBestelD.currentColumnValue("BESTD_OPSCHRIFT") = UCase(Me.grdBestelD.currentColumnValue("BESTD_OPSCHRIFT"))
                Me.obzOpschriften.checkNewValue(Me.grdBestelD.currentColumnValue("BESTD_OPSCHRIFT"), Me.grdBestelD.Columns("Bestd_Opschrift"))
                Me.grdBestelD.currentColumnValue("BESTD_OPSCHRIFT") = UCase(Me.grdBestelD.currentColumnValue("BESTD_OPSCHRIFT"))
            Case "KIES"
                Me.setKies()
        End Select
        Return True
    End Function
    Function checkArtikel(ByVal input As String) As Boolean
        ' MG 20/feb/11
        If Me.obzArtikel.Art_NrExists(Me.obzArtikel.Art_NrFormat(input)) = True Then Return True
        If Me.obzArtikel.CodeExists(input) = True Then Return True
        Dim sql As New sqlClass
        Dim tally = sql.Execute("select Art_Nr,Art_Omschrijving,Art_AlphaCode from Artikel where Art_Omschrijving like '%" & input & "%' AND ART_Actief = true order by Art_Omschrijving")
        If tally = 1 Then
            Me.obzArtikel.Art_Nr = sql.dt(0)("art_nr")
            Return True
        End If
        If tally = 0 Then
            MsgBox("Artikel " & input & " bestaat niet.")
            Return False
        End If
        Dim fArtikel As New PopupFrm
        fArtikel.caller = Me.grdBestelD.EditingControl
        fArtikel.dt = sql.dt
        fArtikel.ShowDialog()
        If fArtikel.userCanceled Then
            Return False
        End If
        Me.obzArtikel.Art_Nr = fArtikel.g(fArtikel.g.Columns("Art_Nr").Index, fArtikel.selected).FormattedValue
        Return True
    End Function
    Sub loadArtikel()
        ' MG zondag 13 februari 2011
        Me.grdBestelD.currentColumnValue("Omschrijving") = Me.obzArtikel.Record.Art_Omschrijving
        Dim SnijdenApplicable As Boolean = Me.obzArtikel.SnijdenApplicable()
        Me.grdBestelD.currentColumnEnable("bestd_Snijden", SnijdenApplicable)
        ' MG zondag 13 februari 2011 - this does not work for some reason.
        Me.BestelDBS.Current("BESTD_SNIJDEN") = SnijdenApplicable
        Me.BestelDBS.Current("bestd_artikel") = Me.obzArtikel.Record.ARt_Id
        ' Me.BestelDG.currentColumnValue("Bestd_Snijden") = SnijdenApplicable
        'If Me.BestelDBS.Current("Bestd_EenhPrijs") <> Me.obzArtikel.Record("Art_Prijs") Then
        '    Me.grdBestelD.currentColumnEnable("BestD_Hoev1", False)
        'End If
        Me.grdBestelD.currentColumnValue("Tour") = "1"
        If Me.obzArtikel.Record.Art_PerPersoon = False Then
            Me.grdBestelD.currentColumnEnable("Bestd_Portie", False)
        End If
        Me.eenhedenBzO.Eenh_id = Me.obzArtikel.Record.Art_Eenheid
        Me.grdBestelD.currentColumnValue("Eenh_omschrijving") = Me.eenhedenBzO.record.Eenh_omschrijving
        Me.grdBestelD.currentColumnValue("Eenh_HoevInvoer") = Me.eenhedenBzO.record.Eenh_HoevInvoer
        Me.grdBestelD.currentColumnValue("Bestd_EenhPrijs") = Me.obzArtikel.Record.Art_Prijs
        If Me.obzArtikel.Record.Art_Uitzonderlijk = False Then
            Me.grdBestelD.currentColumnEnable("BestD_Verwittigen", False)
            Me.grdBestelD.currentColumnValue("Bestd_Verwittigen") = False
            Me.grdBestelD.currentColumnEnable("BestD_Opschrift", False)
            Me.grdBestelD.currentColumnEnable("BestD_Boodschap", False)
        Else
            Me.grdBestelD.currentColumnValue("Bestd_Opschrift") = cNvl(Me.obzArtikel.Record.Art_Opschrift)
            Me.grdBestelD.currentColumnValue("Bestd_Boodschap") = cNvl(Me.obzArtikel.Record.Art_BestBoodschap)
            Me.grdBestelD.currentColumnValue("Bestd_Verwittigen") = Me.obzArtikel.Record.Art_VerwittigenGewicht
        End If
    End Sub
    Private Sub Besteldg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBestelD.CellEndEdit
        ' should be implemented at the grdbase level.
        Select Case UCase(grdBestelD.Columns(e.ColumnIndex).Name)
            Case "ART_NR"
                With grdBestelD
                    .EnableCell(.CurrentCell, False)
                End With
            Case "BESTD_HOEV1"
                Me.calculate()
            Case "BESTD_WAARDE"
                Me.calculate()
            Case "BESTD_PORTIE"
                Me.calculate()
        End Select
    End Sub
    Private Sub BestelDG_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBestelD.RowEnter
        Me.grdBestelD.setColumnTabstopFalse("bestd_waarde")
        Dim c As String = Me.grdBestelD(Me.grdBestelD.Columns("Art_nr").Index, e.RowIndex).FormattedValue
        If cNvl(c) <> "" Then
            Me.obzArtikel.Art_Nr = c
            Dim prijsArtikel As Decimal = obzArtikel.Record.Art_Prijs
            Dim prijsBesteld As Decimal = grdBestelD(Me.grdBestelD.Columns("Bestd_EenhPrijs").Index, e.RowIndex).FormattedValue
            If prijsArtikel = 0 Or prijsBesteld <> prijsArtikel Then
                Me.grdBestelD.setColumnTabstopFalse("bestd_hoev1")
                Me.grdBestelD.setColumnTabstop("bestd_waarde")
            Else
                Me.grdBestelD.setColumnTabstop("bestd_hoev1")
                Me.grdBestelD.setColumnTabstopFalse("bestd_waarde")
            End If
        End If

    End Sub
    Private Sub setKlantLbl()
        If Me.obzKlanten.record.KL_Actief Then
            Me.KlantLbl.Text = Me.klanttext
            Me.KlantLbl.ForeColor = Me.klantcolor
            Me.KlantLbl.Font = Me.klantFont
        Else
            Me.KlantLbl.Text = "Inactieve Klant"
            Me.KlantLbl.ForeColor = Color.Red
            Me.KlantLbl.Font = New Font(Me.KlantLbl.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.previousControl Is Me.grdBestelD Then
            Dim dontMoveUp As Boolean = False
            If cNvl(Me.grdBestelD.CurrentRow.Cells("Art_nr").FormattedValue) = "" Then
                dontMoveUp = True
            End If
            If Me.BestelDBS.Count = 1 Then
                Return
            End If
            Dim lSuccess As Boolean = True
            Try : Me.BestelDBS.RemoveCurrent() : Catch : lSuccess = False : End Try
            If lSuccess = False Then Return
            If dontMoveUp = True Then
                Me.calculate()
                Return
            End If
            While (cNvl(Me.grdBestelD.CurrentRow.Cells("Art_nr").FormattedValue) = "") And Me.grdBestelD.CurrentRow.Index > 0
                grdBestelD.CurrentCell = grdBestelD(grdBestelD.Columns("Bestd_hoev1").Index, grdBestelD.CurrentRow.Index - 1)
            End While
            Me.calculate()
        End If
    End Sub
#Region "SaveButton_Click"
    Private Function saveButton_ToBeDeleted() As Boolean
        Dim isLoaded As Boolean = False
        Try
            isLoaded = (BestelDS.BestH(0).BestH_Id <> 0)
        Catch ex As Exception
            ' Throw New ExceptionMG
        End Try
        Return (isLoaded) And (Val(cNvl(Me.Bestellinglijnen.Text)) = 0)
    End Function
    Private Sub saveButton_DeleteDocument()
        Dim obzBestel As New bzBestel
        obzBestel.doDelete(bzKlanten.kl_id(Me.KL_Nummer.Text), BestelDS.BestH(0).BestH_Id)
    End Sub
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        If saveButton_ToBeDeleted() = False Then
            If Me.diagnose = False Then
                Me.grdBestelD.Focus()
                Exit Sub
            End If
            Me.save()
            Me.report() ' MG 30/mrt/11
        Else
            saveButton_DeleteDocument()
        End If
        unlockSession(Me.nLogSession)
        Me.clear()
    End Sub
#End Region
    Private Function getAdresId() As Integer
        ' MG 19/feb/11
        Dim col As Integer = Me.AdresG.Columns("Kies").Index
        Dim line As Integer = -1
        For i As Integer = 0 To Me.AdresG.Rows.Count - 1
            If Me.AdresG(col, i).Value = True Then
                line = i
                Exit For
            End If
        Next
        If line = -1 Then Return 0
        col = Me.AdresG.Columns("Adr_id").Index
        Return Me.AdresG(col, line).Value
    End Function
    Private Sub InsertButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertButton.Click
        If Me.previousControl Is Me.grdBestelD Then
            Dim r As BestelDS.BestDRow = BestelDS.BestD.NewBestDRow
            Dim rIndex As Integer : rIndex = Me.grdBestelD.CurrentRow.Index
            Me.BestelDS.BestD.Rows.InsertAt(r, Me.grdBestelD.CurrentRow.Index)
            Dim col As Integer = Me.grdBestelD.Columns("ARt_nr").Index
            Me.grdBestelD.CurrentCell = Me.grdBestelD(col, rIndex)
            Me.grdBestelD.Focus()
        End If
    End Sub
    Function checkDuplicate() As Boolean
        ' MG 20/feb/11
        ' MG 18/mrt/11 - disabled
        'For Each r As DataRowView In Me.BestelDBS
        '    If nvl(r("Art_nr")) = Me.obzArtikel.Art_Nr Then
        '        If r IsNot Me.BestelDBS.Current Then Return True
        '    End If
        'Next
        Return False
    End Function
    Private Sub BestH_DocNr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BestH_Docnr.Validating
        ' MG 20/feb/11
        Dim input As String = Trim(cNvl(Me.BestH_Docnr.Text))
        If input = "" Then Return
        If obzBestel.existsDocnr(input) = False Then
            MsgBox("Document Nummer bestaat niet")
            e.Cancel = True
            Return
        End If
        Dim lCantLoad As Boolean = False
        loadBestel(lCantLoad)
        If lCantLoad Then e.Cancel = True
        Me.bestelTabpage.SelectTab(0)
        Me.bestelTabpage.Focus()
        Me.grdBestelD.Focus()

    End Sub
    Sub fillHeaderForParticulier(pk)
        Dim sql As String = "SELECT BestH.BEstH_DocNr, BestH.BestH_Klant, BestH.BestH_KomtHalen, BestH.BestH_Bediening, BestH.BestH_DatBest "
        sql &= ", BestH.BestH_DatLevering,BestH.BestH_UurLevering, BestH.BestH_DatVervoer, BestH.BestH_TijdVervoer, BestH.BestH_Adres "
        sql &= ",BestH.BestH_Info, BestH.BestH_Standaard,BestH.BestH_StToegepast, BestH.BestH_StType, BestH.BestH_Factuur "
        sql &= ",Klanten.KL_Nummer, Klanten.KL_Naam, Adres.Adr_Telefoon, BestH.BestH_Id "
        sql &= " FROM pH BestH, Klanten, Adres "
        sql &= " where kl_id = besth_Klant "
        sql &= " and adr_id = besth_adres "
        sql &= " and BestH.BestH_Id = " & pk
        Dim osql As New sqlClass
        osql.Execute(sql, Me.BestelDS.BestH)
    End Sub
    Function fillDetailForParticulier(pk) As Long
        Dim sql As String = "SELECT BestD.BestD_ID, BestD.BestD_BestH, BestD.BestD_IsStandaard, BestD.BestD_Artikel, BestD.BestD_Omschrijving, "
        sql &= "BestD.BestD_Snijden, BestD.BestD_Tour,BestD.BestD_Portie, BestD.BestD_Hoev, BestD.BestD_Hoev1, BestD.BestD_EenhPrijs, "
        sql &= "BestD.BestD_Waarde, BestD.BestD_Verwittigen, BestD.BestD_Opschrift, BestD.BestD_Boodschap, Artikel.Art_Nr, "
        sql &= "Artikel.Art_Omschrijving, Eenheden.Eenh_HoevInvoer, Eenheden.Eenh_omschrijving, BestD.bestd_voorafdrukken "
        sql &= "FROM (((pd BestD "
        sql &= "INNER JOIN Artikel ON BestD.BestD_Artikel = Artikel.ARt_Id) "
        sql &= "INNER JOIN Eenheden ON Artikel.Art_Eenheid = Eenheden.Eenh_id) "
        sql &= "INNER JOIN Kategorie ON Artikel.Art_Kategorie = Kategorie.Kat_ID) "
        sql &= "WHERE (BestD.BestD_BestH = " & pk & ") "
        sql &= "ORDER BY Kategorie.Kat_ProductiePlan, BestD.BestD_Omschrijving, BestD.BestD_ID"
        Dim osql As New sqlClass
        Return osql.Execute(sql, Me.BestelDS.BestD)
    End Function
    Sub loadBestel(ByRef lCantLoad As Boolean)
        Dim c As String
        Dim particulier As Boolean = bzKlanten.isParticulierFromDocument(obzBestel.oHeader("besth_docnr"))
        If particulier Then
            fillHeaderForParticulier(Me.obzBestel.pk)
        Else
            Me.BestelHCRUD.Fill(Me.BestelDS.BestH, Me.obzBestel.pk)
        End If
        Me.oToggle = IIf(Me.obzBestel.lIslevering, eToggle.eToggleLevering, eToggle.eToggleBestelling)
        Me.setToggle()
        Me.BestH_Docnr.Text = Me.obzBestel.oHeader("Besth_docnr")
        Me.txtBestH_DatBest2.Text = Format(Me.obzBestel.oHeader("BestH_DatBest"), modDutch.cDateFormat)
        Me.MonthCalendar1.SetDate(Me.obzBestel.oHeader("Besth_datlevering"))
        Me.obzKlanten.kl_nummer = Me.BestelHBS.Current("KL_nummer")
        SetBetaling(Me.obzKlanten.kl_nummer)
        Me.BetalingTextbox.Text = IIf(obzKlanten.record("kl_voldaan"), "Contant", "Per Overschrijving")
        Dim adLines = Me.BestelAdresTA.Fill(Me.BestelDS.Adres, Me.obzKlanten.record("Kl_id"))
        Dim idCol As Integer = Me.AdresG.Columns("Adr_id").Index
        Dim kiesCol As Integer = Me.AdresG.Columns("Kies").Index
        Me.bestelTabpage.SelectTab(2)
        Me.AdresG.Focus()
        For adLine As Integer = 0 To 3
            If adLine < adLines Then
                If nNvlI(Me.AdresG(idCol, adLine).Value) = Me.BestelHBS.Current("Besth_Adres") Then
                    Me.AdresG(kiesCol, adLine).Value = True
                Else
                    Me.AdresG(kiesCol, adLine).Value = False
                End If
            Else
                Me.AdresBS.AddNew()
            End If
        Next
        Me.AdresBS.MoveFirst()
        Me.bedieningO.bed_id = Me.BestelHBS.Current("besth_bediening") : Me.Bediening.Text = Me.bedieningO.bed_Naam
        Dim lines As Integer
        If particulier Then
            lines = Me.fillDetailForParticulier(Me.obzBestel.pk)
        Else
            lines = Me.BestelDCRUD.Fill(Me.BestelDS.BestD, Me.obzBestel.pk)
        End If
        ' MG 08/mrt/11
        Me.FormMode = ModeValues.RecordEntry
        MonthCalendar1.Enabled = False
        Me.filterHistory(Me.KL_Nummer.Text)
        Me.GridUpdate(lines)
        'Me.TpgBase1.Select()
        'For i As Integer = 1 To Me.TpgBase1.TabPages.Count
        '    Me.TpgBase1.SelectTab(i - 1)
        'Next
        Me.bestelTabpage.SelectTab(0)
        'Me.grdBestelD.Select()
        If lLock(Me.nLogSession, "Bestel", Me.obzBestel.pk) = False Then
            Me.clear()
            lCantLoad = True
            Exit Sub
        End If
        If Me.obzBestel.lMultipleInvoiced Then
            c = "Deze Bestelling werd reeds gefactureerd en heeft artikels met meerdere BTW Nummers.  Aanpassen van dit soort bestellingen wordt niet ondersteund."
            MsgBox(c)
            lCantLoad = True
            Exit Sub
        End If
        Me.TabPage1.Text = obzBestel.oHeader("BestH_Docnr")
        If Me.oToggle = eToggle.eToggleLevering Then
            Me.TxtNrLevering.Text = bzBestel.cNextNrLevering(Me.KL_Nummer.Text, CDate(Me.BestH_DatLevering.Text))
        End If
        Me.grdBestelD.CurrentCell = Me.grdBestelD(Me.grdBestelD.Columns("Art_Nr").Index, lines)
        ' Me.TpgBase1.TabPages(1).Text = Me.BestH_Docnr.Text
        ResetKl_Nummer()
    End Sub
    Sub GridUpdate(ByVal lines As Integer)
        ' MG 27/feb/11
        Dim c As String = ""
        For Each r As DataRowView In BestelDBS
            If cNvl(r("Art_nr")) <> "" Then
                c &= r("Bestd_ARtikel") & ","
            End If
        Next
        Dim oSql As New sqlClass
        If c = "" Then
            lines = 0
        Else
            c = Strings.Left(c, Len(c) - 1)
            Dim cSql As String = "select * from "
            cSql &= "Artikel "
            cSql &= "where art_id in (" & c & ") "
            oSql.Execute(cSql)
            Dim dt As DataTable = oSql.dt
        End If

        Dim colArt_Nr = Me.grdBestelD.Columns("Art_nr").Index

        For line As Integer = 0 To lines - 1
            Me.grdBestelD.CurrentCell = Me.grdBestelD(colArt_Nr, line)
            Me.grdBestelD.currentColumnValue("Art_Nr") = Me.grdBestelD.currentColumnValue("colArtNrBound")
            Dim cArt = Me.grdBestelD.currentColumnValue("Art_Nr")
            If cNvl(cArt) <> "" Then
                'Me.obzArtikel.Art_Nr = Me.BestelDG.currentColumnValue("Art_Nr")
                Me.grdBestelD.currentColumnEnable("Art_Nr", False)
                Me.grdBestelD.currentColumnEnable("omschrijving", Me.grdBestelD.CurrentRow.Cells("BestDIsStandaardDataGridViewCheckBoxColumn").Value = False)


                Dim rARt As DataRow = oSql.dt.Select("Art_Nr = '" & cArt & "'")(0)
                If rARt("art_snijden") = False Then
                    Me.grdBestelD.currentColumnEnable("bestd_snijden", False)
                End If
                If rARt("art_Uitzonderlijk") = False Then
                    Me.grdBestelD.currentColumnEnable("Bestd_Portie", False)
                    Me.grdBestelD.currentColumnEnable("bestd_Verwittigen", False)
                    Me.grdBestelD.currentColumnEnable("BestD_Opschrift", False)
                    Me.grdBestelD.currentColumnEnable("BestD_Boodschap", False)
                End If
                ' null out hoev1 if equal to hoev
                If Not (Me.grdBestelD(Me.grdBestelD.Columns("Standaard").Index, line).Value Is DBNull.Value) Then
                    If Me.grdBestelD(Me.grdBestelD.Columns("Standaard").Index, line).Value = gen.nNvlI(Me.grdBestelD(Me.grdBestelD.Columns("Bestd_Hoev1").Index, line).Value) Then
                        Me.grdBestelD(Me.grdBestelD.Columns("Bestd_Hoev1").Index, line).Value = DBNull.Value
                    End If
                    If Me.grdBestelD(Me.grdBestelD.Columns("Standaard").Index, line).Value = 0 Then
                        Me.grdBestelD(Me.grdBestelD.Columns("Standaard").Index, line).Value = DBNull.Value
                    End If
                End If
                If rARt("art_prijs") = 0 Then
                    Me.grdBestelD.currentColumnEnable("Bestd_Hoev1", False)
                Else
                    Me.grdBestelD.currentColumnEnable("Bestd_Hoev1", True)
                End If
            End If
        Next

        Dim Minimumgridlines As Long = 30
        If lines < Minimumgridlines Then
            For l As Integer = 1 To Minimumgridlines - lines
                Me.BestelDBS.AddNew()
            Next
        End If
        Me.calculate()
        Me.BestelDBS.MoveFirst()
        Me.grdBestelD.CurrentCell = Me.grdBestelD(colArt_Nr, lines)
        ' Me.BestelDBS.MoveFirst()
        ' Me.BestelDBS.Position = lines

    End Sub
    Sub calculate()
        ' MG 21/feb/11
        Dim c As String = ""
        For Each r As DataRowView In BestelDBS
            If cNvl(r("Art_nr")) <> "" Then
                c &= r("Bestd_ARtikel") & ","
            End If
        Next
        Dim lines As Integer = 0
        Dim t As Double = 0
        Dim tBTW As Double = 0
        If Trim(c) = "" Then
            Me.TotaalEur.Text = t.ToString("N")
            ' MG 23/feb/11
            Me.TotBTW.Text = tBTW.ToString("N")
            Me.Bestellinglijnen.Text = lines.ToString("N0")
            Exit Sub
        End If
        c = Strings.Left(c, Len(c) - 1)
        Dim oSql As New sqlClass
        Dim cSql As String = "select * from "
        cSql &= "Artikel "
        cSql &= "where art_id in (" & c & ") "
        oSql.Execute(cSql)
        Dim dt As DataTable = oSql.dt
        Dim oSql2 As New sqlClass
        cSql = "select * from KlantenKorting "
        cSql &= "where KK_Klant = " & obzKlanten.record.KL_ID
        oSql2.Execute(cSql)
        Dim dt2 As DataTable = oSql2.dt
        For Each r As DataRowView In BestelDBS
            If cNvl(r("Art_nr")) <> "" Then
                'Dim foundRows() As Data.DataRow
                'foundRows = DataSet1.Tables("Customers").Select("CompanyName Like 'A%'")
                Dim nPK As Long = r("Bestd_Artikel") : Dim rARt As DataRow = dt.Select("Art_id = " & nPK)(0)
                '--
                Dim lKK As Boolean = False : Dim nKK As Double = 0
                Dim nKKCount As Long = dt2.Select("KK_Artikel= " & nPK).Count
                If nKKCount <> 0 Then
                    lKK = True
                    nKK = dt2.Select("KK_Artikel = " & nPK)(0)("KK_KOrting")
                End If
                '--
                Dim nTB As Double
                Dim nKB As Double
                Dim nBTW As Double
                Dim nBel As Double
                Dim nT As Double
                Dim nKPct As Double
                bzPrice.QuickCompute(gen.nNvlD(r("bestd_Waarde")),
                                     obzKlanten.record.KL_BTWType,
                                     obzKlanten.record.KL_Korting,
                                     rARt("Art_BTW"),
                                     rARt("Art_Korting"),
                                     nKK,
                                     lKK,
                                     nTB, nKB, nBTW, nBel, nT, nKPct)
                t += nTB
                tBTW += nBTW
                lines += 1
            End If
        Next
        Me.TotaalEur.Text = t.ToString("N")
        ' MG 23/feb/11
        Me.TotBTW.Text = tBTW.ToString("N")
        Me.Bestellinglijnen.Text = lines.ToString("N0")
    End Sub
    Private Sub BestH_Standaard_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BestH_Standaard.Validating
        ' MG 27/feb/11
        Dim input As String = cNvl(Me.BestH_Standaard.Text)
        If input = "" Then Exit Sub
        If checkStandaardNr(input) Then Exit Sub
        MsgBox(StandaardNrErrMsg)
        e.Cancel = True
    End Sub
    Private Sub loadStandaard()
        ' MG 10/mrt/11
        If Me.BestH_StToegepast.cast = False Then Exit Sub
        ' MG 16/okt/11
        If Me.oToggle = eToggle.eToggleLevering Then Exit Sub
        ' MG 27/feb/11
        If Trim(Me.BestH_Docnr.Text) <> "" Then Exit Sub

        Dim sql As New sqlClass
        Dim cSql As String = "select sth_id from standaardh "
        cSql += "where sth_Klant = " & Me.obzKlanten.record.KL_ID
        cSql += " and sth_type = '" & Me.BestH_Standaard.Text & "'"
        cSql += " and sth_typsb = " & TypeSTBestFromOmschrijving(Me.StType.Text)
        Dim pk As Integer = sql.ExecuteScalar(cSql)
        If pk = 0 Then
            Me.BestH_StToegepast.Text = "Neen"
            Exit Sub
        End If
        BestelHBS(0)("BestH_StType") = TypeSTBestFromOmschrijving(Me.StType.Text)
        cSql = "select * from standaardD,Artikel,Eenheden,Kategorie"
        cSql &= " where art_id = std_artikel and Eenh_id = Art_Eenheid and art_Kategorie = kat_id and std_sth = " & pk & " and art_actief = True"
        cSql &= " order by Kat_ProductiePlan, Art_Omschrijving,std_id"
        Dim tally As Integer = sql.Execute(cSql)
        For line As Integer = 0 To tally - 1 + 30
            Me.BestelDBS.AddNew()
        Next
        For line As Integer = 0 To tally - 1
            Me.BestelDBS(line)("BestD_IsStandaard") = True
            Me.BestelDBS(line)("BestD_Omschrijving") = sql.dt(line)("Art_Omschrijving")
            Me.BestelDBS(line)("BestD_Snijden") = sql.dt(line)("std_Snijden")
            Me.BestelDBS(line)("BestD_Tour") = sql.dt(line)("std_Tour")
            Me.BestelDBS(line)("BestD_Hoev") = sql.dt(line)("std_Hoeveelheid")
            '            Me.BestelDBS(line)("BestD_Hoev1") = sql.dt(line)("std_Hoeveelheid") ' MG 11/apr/11
            Me.BestelDBS(line)("BestD_EenhPrijs") = sql.dt(line)("Art_Prijs")
            Me.BestelDBS(line)("BestD_Waarde") = sql.dt(line)("Art_Prijs") * sql.dt(line)("std_Hoeveelheid") * 10 ^ sql.dt(line)("Eenh_Exponent")
            Me.BestelDBS(line)("Art_nr") = sql.dt(line)("Art_nr")
            ' Me.BestelDBS(line)("Bestd_Omschrijving") = sql.dt(line)("std_ArtOmschrijving")
            Me.BestelDBS(line)("Eenh_omschrijving") = sql.dt(line)("Eenh_omschrijving")
            Me.BestelDBS(line)("Eenh_HoevInvoer") = sql.dt(line)("Eenh_HoevInvoer")
            Me.BestelDBS(line)("bestd_artikel") = sql.dt(line)("std_Artikel")
            Me.BestelDBS(line)("BestD_Verwittigen") = False
        Next
        ' MG 08/mrt/11
        Me.GridUpdate(tally)
        Me.grdBestelD.Select()
    End Sub
    Private Sub SaveAsStandaard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsStandaard.Click
        Dim o As New bzStandaarden
        Dim pk As Long = 0
        If o.Exists(obzKlanten.record.KL_ID, Me.BestH_Standaard.Text, TypeSTBestFromOmschrijving(Me.StType.Text)) Then
            If YesNO("Deze Standaard bestaat reeds en wordt hierdoor overschreven.") = False Then Exit Sub
            pk = o.pk
        End If
        Dim conn As New OleDbConnection(My.Settings.b040_beConnectionString) : conn.Open()
        Dim t As OleDbTransaction = conn.BeginTransaction
        Dim oSql As New sqlClass
        oSql.conn = conn
        Dim cSql As String : Dim n As Long
        Dim Description As String = Me.KL_Naam.Text & " " & Me.StType.Text & " " & Me.BestH_Standaard.Text
        If pk <> 0 Then
            cSql = "delete from standaardh where sth_id = " & pk
            n = oSql.ExecuteNonQuery(cSql, t)
            cSql = "delete from standaardd where std_sth = " & pk
            n = oSql.ExecuteNonQuery(cSql, t)
            nlog(Description, "frmBestel", LogType.logNormal, LogAction.logDelete, "Standaarden", pk)
        End If
        cSql = "insert into StandaardH (sth_Type,sth_TypSb,sth_Klant,sth_TimeStamp) "
        cSql &= "values ('" & Me.BestH_Standaard.Text & "',"
        cSql &= TypeSTBestFromOmschrijving(Me.StType.Text) & ","
        cSql &= obzKlanten.record.KL_ID & ","
        cSql &= "#" & Now & "#)"
        n = oSql.ExecuteNonQuery(cSql, t)
        pk = oSql.retrieveNewKey(t)
        Dim a As String : Dim std_Artikel As Long
        For Each r As DataRowView In Me.BestelDBS
            a = cNvl(r("Art_nr"))
            If a <> "" Then
                obzArtikel.Art_Nr = a
                std_Artikel = obzArtikel.Record.ARt_Id
                Dim h As Double = IIf(nNvlD(r("Bestd_Hoev1")) <> 0, r("Bestd_Hoev1"), nNvlD(r("Bestd_Hoev")))
                cSql = "insert into StandaardD (std_sth,std_Artikel,std_ArtOmschrijving,std_Hoeveelheid,std_Snijden,std_tour) "
                cSql &= " values (" & pk & "," & std_Artikel & ","
                cSql &= sqlClass.c(r("bestd_Omschrijving")) & ","
                cSql &= sqlClass.cDoubleForjet(h) & ","
                cSql &= r("bestd_Snijden") & ","
                cSql &= "'" & r("bestd_Tour") & "')"
                n = oSql.ExecuteNonQuery(cSql, t)
            End If
        Next
        nlog(Description, "frmBestel", LogType.logNormal, LogAction.logCreate, "Standaarden", pk)
        t.Commit()
        conn.Close()
        MsgBox("Deze Bestelling werd bewaard als Standaard (" & Description)
    End Sub
    Sub report()
        bzBestel.report(Me.BestH_Docnr.Text)
    End Sub
    Sub setKies()
        ' Dim l As Boolean = Me.AdresG.CurrentCell.Value
        Dim nCol As Integer = Me.AdresG.Columns("KIES").Index
        Dim nRow As Integer = Me.AdresG.CurrentRow.Index
        Dim nPkAdres As Long = Me.AdresG(Me.AdresG.Columns("Adr_id").Index, nRow).Value
        If Me.obzKlanten.lAdresExists(nPkAdres) = False Then
            Dim cAdres As String = cNvl(Me.AdresG(Me.AdresG.Columns("Adr_Adres").Index, nRow).Value)
            Dim cPostnr As String = cNvl(Me.AdresG(Me.AdresG.Columns("Adr_Postnummer").Index, nRow).Value)
            Dim cGemeente As String = cNvl(Me.AdresG(Me.AdresG.Columns("Adr_Gemeente").Index, nRow).Value)
            Dim cLand As String = cNvl(Me.AdresG(Me.AdresG.Columns("Adr_Land").Index, nRow).Value)
            Me.obzKlanten.insertAdres(cAdres, cPostnr, cGemeente, cLand, nPkAdres)
            Me.AdresG(Me.AdresG.Columns("Adr_id").Index, nRow).Value = nPkAdres
        End If

        For Each oRow As DataGridViewRow In Me.AdresG.Rows
            If oRow.Index <> Me.AdresG.CurrentRow.Index Then
                Me.AdresG(nCol, oRow.Index).Value = False
            Else
                Me.AdresG(nCol, oRow.Index).Value = True
            End If
        Next
    End Sub
    Private Sub BestelDG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdBestelD.KeyDown
        If Me.grdBestelD.CurrentCell Is Nothing Then Exit Sub

        If grdBestelD.CurrentCell.ColumnIndex <> grdBestelD.Columns("Art_Nr").Index Then Exit Sub
        If e.KeyCode <> Keys.Insert Then Exit Sub
        If cNvl(grdBestelD.CurrentCell.Value) <> "" Then Exit Sub
        Dim oFrm As New frmArtikel
        oFrm.eOpenMode = eFormOpen.eFromOpenNew
        oFrm.cParameter = ""
        oFrm.ModeShow = b040.ModeShow.Modal
        oFrm.ShowDialog()
        Me.grdBestelD.CurrentCell.Value = oFrm.cParameter
        Me.grdValidate("ART_NR", oFrm.cParameter)
        With grdBestelD
            .EnableCell(.CurrentCell, False)
        End With
    End Sub
    Private Sub BtnToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToggle.Click
        Me.oToggle = IIf(Me.oToggle = eToggle.eToggleBestelling, eToggle.eToggleLevering, eToggle.eToggleBestelling)
        Me.setToggle()
    End Sub
    Sub setToggle()
        If Me.oToggle = eToggle.eToggleLevering Then
            Me.Text = "Levering"
            Me.BtnToggle.Text = "Bestelling (^B)"
            '15/aug/12 disabled.   Datlevering remains active
            'Me.BestH_DatLevering.Enabled = False
            Me.lblDate.Text = "Levering"
            Me.BestH_DatLevering.Text = Format(bzBestel.dGetDefaultLeveringDatum, modDutch.cDateFormat)
            Me.PnlStandaard.Visible = False
            Me.LblNrLevering.Visible = True
            Me.TxtNrLevering.Visible = True
            Me.BestH_StToegepast.Text = "Neen"
            Me.SaveAsStandaard.nIO = IOValues.IOAlwaysDisable
            Dim ocolor As Color = Color.Bisque
            TabPage2.BackColor = ocolor
        Else
            Me.Text = "Bestelling"
            Me.BtnToggle.Text = "Levering (^L)"
            Me.BestH_DatLevering.Enabled = True
            Me.lblDate.Text = "Bestelling"
            ' Me.BestH_DatLevering.Text = Format(bzBestel.Leverdatum(Now), dateFormat)
            Me.BestH_StToegepast.Text = "Ja"
            Me.PnlStandaard.Visible = True
            Me.LblNrLevering.Visible = False
            Me.TxtNrLevering.Visible = False
            Me.SaveAsStandaard.nIO = IOValues.IORecordEntryEnable
            Dim ocolor As Color = Color.LightSkyBlue
            TabPage2.BackColor = ocolor
        End If
        Me.TabPage2.Text = Me.Text
        Me.DagLevering.Text = modDutch.cDagInDeWeek(CDate(Me.BestH_DatLevering.Text))
        Me.MonthCalendar1.SetDate(CDate(Me.BestH_DatLevering.Text))
    End Sub
    Private Sub BtnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
        Me.BestH_Info.Focus()
    End Sub
#Region "Form.KeyDown"
    Sub processAltK(sender As Object, e As KeyEventArgs)
        frmMain.preventExecution = True
        Dim f As New KlantenFrm
        f.operateAsChildform = True
        f.ShowDialog()
        If Trim(f.KL_Nummer.Text) = "" Then
            Exit Sub
        End If
        If obzKlanten.Kl_NummerExists(f.KL_Nummer.Text) = False Then
            Exit Sub
        End If
        KL_Nummer.Text = f.KL_Nummer.Text
        obzKlanten.kl_nummer = KL_Nummer.Text
        KL_Naam.Text = obzKlanten.record.KL_Naam
        KL_Nummer_Validated(KL_Nummer, e)
        grdBestelD.CurrentCell.Selected = True
    End Sub
    Private Sub Bestelfrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (Me.cActiveControlName = "GRDHISTORY") Or (Me.cActiveControlName = "PARTICULIERENOVERZICHTDATAGRIDVIEW") Then
            Exit Sub
        End If
        If e.KeyCode = Keys.End Then
            If Me.cActiveControlName = "GRDBESTELD" Then
                Dim nBestelLines As Integer = 0
                For Each oRow As DataGridViewRow In Me.grdBestelD.Rows
                    If Trim(oRow.Cells("Art_nr").Value) = "" Then
                        nBestelLines = oRow.Index
                        Exit For
                    End If
                Next
                Dim nCurrentLine As Long = Me.grdBestelD.CurrentCell.RowIndex
                Dim nCurrentColumn As Integer = Me.grdBestelD.CurrentCell.ColumnIndex
                If nCurrentLine = nBestelLines Then
                    If Me.SaveButton.Enabled = True Then
                        Me.SaveButton_Click(sender, e)
                    End If
                Else
                    PutCursorOnNextNewLine()
                    e.Handled = True
                End If
                Return
            End If
            If Me.cActiveControlName = "BESTH_INFO" Then
                Dim nBestelLines As Integer = 0
                For Each oRow As DataGridViewRow In Me.grdBestelD.Rows
                    If Trim(oRow.Cells("Art_nr").Value) = "" Then
                        nBestelLines = oRow.Index
                        Exit For
                    End If
                Next
                Dim nCurrentLine As Long = Me.grdBestelD.CurrentCell.RowIndex
                Dim nCurrentColumn As Integer = Me.grdBestelD.CurrentCell.ColumnIndex
                Me.grdBestelD.CurrentCell = Me.grdBestelD(Me.grdBestelD.Columns("Art_nr").Index, nBestelLines)
                Me.grdBestelD.Select()
                e.Handled = True
                Return
            End If
        End If
        If e.KeyCode = Keys.Delete Then
            If Me.cActiveControlName = "GRDBESTELD" Then
                If Me.grdBestelD.CurrentCell.ColumnIndex = grdBestelD.Columns("BestD_Hoev1").Index Then
                    Me.grdBestelD.CurrentCell.Value = DBNull.Value
                    Exit Sub
                End If
            End If
        End If
        If e.Control = True And e.KeyCode = Keys.S Then
            If Me.SaveAsStandaard.Enabled Then Me.SaveAsStandaard_Click(sender, e)
        End If
        If e.Control = True And e.KeyCode = Keys.B Then
            If Me.BtnToggle.Enabled And Me.oToggle = eToggle.eToggleLevering Then Me.BtnToggle_Click(sender, e)
        End If
        If e.Control = True And e.KeyCode = Keys.L Then
            If Me.BtnToggle.Enabled And Me.oToggle = eToggle.eToggleBestelling Then Me.BtnToggle_Click(sender, e)
        End If
        If e.Control = True And e.KeyCode = Keys.T Then
            If Me.InsertButton.Enabled Then Me.InsertButton_Click(sender, e)
        End If
        If e.KeyCode = Keys.F4 Then
            If Me.btnDelete.Enabled Then Me.btnDelete_Click(sender, e)
        End If
        If e.Control = True And e.KeyCode = Keys.I Then
            If Me.btnInfo.Enabled Then Me.BtnInfo_Click(sender, e)
        End If
        If e.Control = True And e.KeyCode = Keys.D Then
            If Me.BtnBewaarAndereDag.Enabled Then Me.BtnBewaarAndereDag_Click(sender, e)
        End If
        If e.Control = True And e.KeyCode = Keys.O Then
            Me.bestelTabpage.SelectedIndex = 3
        End If
        If e.Control = True And e.KeyCode = Keys.T Then
            Me.bestelTabpage.SelectedIndex = 4
        End If
        If e.Control = True And e.KeyCode = Keys.Z Then
            Me.setNulbestelling()
        End If
        If e.KeyCode = Keys.F5 Then
            If (Me.bestelTabpage.SelectedTab.Text = "Bestelling" Or Me.bestelTabpage.SelectedTab.Text = "Levering") = False Then Exit Sub
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            If Me.ActiveControl.Name = "grdBestelD" Then
                Me.setepson("A")
                e.Handled = True
                Return
            End If
        End If
        If e.KeyCode = Keys.F6 Then
            If (Me.bestelTabpage.SelectedTab.Text = "Bestelling" Or Me.bestelTabpage.SelectedTab.Text = "Levering") = False Then Exit Sub
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            If Me.ActiveControl.Name = "grdBestelD" Then
                Me.setepson("B")
                e.Handled = True
                Return
            End If
        End If
        If e.KeyCode = Keys.F7 Then
            If (Me.bestelTabpage.SelectedTab.Text = "Bestelling" Or Me.bestelTabpage.SelectedTab.Text = "Levering") = False Then Exit Sub
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            If Me.ActiveControl.Name = "grdBestelD" Then
                Me.setepson("C")
                e.Handled = True
                Return
            End If
        End If
        If e.KeyCode = Keys.F8 Then
            If (Me.bestelTabpage.SelectedTab.Text = "Bestelling" Or Me.bestelTabpage.SelectedTab.Text = "Levering") = False Then Exit Sub
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            If Me.ActiveControl.Name = "grdBestelD" Then
                Me.setepson("D")
                e.Handled = True
                Return
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If (Me.bestelTabpage.SelectedTab.Text = "Bestelling" Or Me.bestelTabpage.SelectedTab.Text = "Levering") = False Then Exit Sub
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            If Me.ActiveControl.Name = "grdBestelD" Then
                Me.setepsonall()
            End If
        End If
        If e.KeyCode = Keys.F10 Then
            If (Me.bestelTabpage.SelectedTab.Text = "Bestelling" Or Me.bestelTabpage.SelectedTab.Text = "Levering") = False Then Exit Sub
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            If Me.ActiveControl.Name = "grdBestelD" Then
                Me.do_direct_afdrukken()
                e.Handled = True
                Return
            End If
        End If
        If e.KeyCode = Keys.F12 Then
            If (Me.bestelTabpage.SelectedTab.Text = "Bestelling" Or Me.bestelTabpage.SelectedTab.Text = "Levering") = False Then Exit Sub
            If Me.FormMode <> ModeValues.RecordEntry Then Exit Sub
            If Me.ActiveControl.Name = "grdBestelD" Then Me.toggle_snijden()
        End If
        If e.Control = True AndAlso e.KeyCode = Keys.W Then
            Me.BewaarEnBlijf_Click(sender, e)
        End If
        If e.Alt = True AndAlso e.KeyCode = Keys.K Then
            If ActiveControl.Name <> "KL_Nummer" Then Exit Sub
            processAltK(sender, e)
        End If
        If e.KeyCode = Keys.Down Then
            If ActiveControl.Name = "grdBestelD" Then
                PutCursorOnArt_Nr()
            End If
        End If
    End Sub
#End Region
    Sub forcePageBinding()
        Dim currentPage As Integer = Me.bestelTabpage.SelectedIndex
        Dim pageCount As Integer = Me.bestelTabpage.TabPages.Count
        For i As Integer = 0 To pageCount - 1
            Me.bestelTabpage.SelectTab(i)
        Next
        Me.bestelTabpage.SelectTab(currentPage)
    End Sub
    Private Sub btnVerwijderDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerwijderDocument.Click
        Dim oSQL As New sqlClass
        If Trim(Me.BestH_Docnr.Text) = "" Then Exit Sub
        Dim oBestel As New bzBestel
        If oBestel.lExistsBestelling(Me.BestH_Docnr.Text) = False Then Exit Sub
        If nNvlD(oBestel.oHeader("besth_facth")) <> 0 Then
            MsgBox("Deze bestelling is gefactureerd ( " & oBestel.oHeader("besth_Facth") & ")")
            Exit Sub
        End If
        Dim cMsg As String = "Document Nr : " & Me.BestH_Docnr.Text
        cMsg &= vbCrLf
        cMsg &= "Levering : " & Me.BestH_DatLevering.Text
        cMsg &= vbCrLf
        cMsg &= "Type Transactie : " & Me.lblDate.Text
        cMsg &= vbCrLf
        cMsg &= vbCrLf
        cMsg &= "U weet toch zeker dat U dit document wenst te verwijderen."
        cMsg &= vbCrLf
        If YesNO(cMsg, ContentAlignment.MiddleLeft) = True Then
            cMsg = "Document Nr : " & Me.BestH_Docnr.Text
            cMsg &= vbCrLf
            cMsg &= "Levering : " & Me.BestH_DatLevering.Text
            cMsg &= vbCrLf
            cMsg &= "Type Transactie : " & Me.lblDate.Text
            cMsg &= vbCrLf
            cMsg &= vbCrLf
            cMsg &= "Document verwijderd."
            oBestel.doDelete()
            MsgBox(cMsg)
            Me.clear()
        End If
    End Sub
    Private Sub grdBestelD_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBestelD.Enter
        Me.grdBestelD.Columns("Art_Nr").DefaultCellStyle.SelectionBackColor = Color.LightPink
    End Sub
    Private Sub grdBestelD_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBestelD.Leave
        Me.grdBestelD.Columns("Art_Nr").DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorDisabled
    End Sub
    Private Sub BtnBewaarAndereDag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBewaarAndereDag.Click
        If Me.oToggle <> eToggle.eToggleBestelling Then Exit Sub
        Dim header As String = "BestH"
        Dim detail As String = "BestD"
        Dim klid As Long = bzKlanten.kl_id(Me.KL_Nummer.Text)
        If bzKlanten.isParticulier(klid) = True Then
            header = "PH"
            detail = "PD"
        End If
        Dim oFrm As New frmBestelAndereDag
        oFrm.dCurrentLeveringsdatum = CDate(Me.BestH_DatLevering.Text)
        oFrm.nKlid = klid
        If oFrm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim conn As New OleDbConnection(My.Settings.b040_beConnectionString) : conn.Open()
        Dim t As OleDbTransaction = conn.BeginTransaction
        Dim oSql As New sqlClass
        oSql.conn = conn
        Dim oB As New sqlClass.SqlBuilder
        oB.cTable = header
        Dim cDocnr As String = Me.obzBestel.nextDocnr(Me.obzKlanten.Zerofill(Me.KL_Nummer.Text) & Date.Parse(oFrm.TxtBaseDate1.Text).ToString("yyMMdd"), Me.oToggle = eToggle.eToggleLevering)
        oB.addInsert("BestH_Docnr", sqlClass.c(cDocnr))
        oB.addInsert("BestH_KLant", bzKlanten.kl_id(Me.KL_Nummer.Text))
        oB.addInsert("BestH_KomtHalen", sqlClass.cBoolean(Me.BestH_KomtHalen.Text = "Ja"))
        oB.addInsert("BestH_Bediening", bzBediening.id(Me.Bediening.Text))
        oB.addInsert("BestH_DatBest", sqlClass.cDateForJet(Today))
        oB.addInsert("besth_datlevering", sqlClass.cDateForJet(CDate(oFrm.TxtBaseDate1.Text)))
        oB.addInsert("besth_uurlevering", sqlClass.c(Me.BestH_UurLevering.Text))
        oB.addInsert("besth_datvervoer", sqlClass.cDateForJet(Today))
        oB.addInsert("besth_tijdvervoer", sqlClass.c(""))
        oB.addInsert("besth_adres", Me.getAdresId)
        oB.addInsert("besth_info", sqlClass.c(Me.BestH_Info.Text))
        oB.addInsert("besth_Standaard", sqlClass.c(Me.BestH_Standaard.Text))
        oB.addInsert("besth_StToegepast", sqlClass.cBoolean(Me.BestH_StToegepast.Text = "Ja"))
        oB.addInsert("besth_sttype", TypeSTBestModule.TypeSTBestFromOmschrijving(Me.StType.Text))
        oB.addInsert("Besth_factuur", sqlClass.c("0"))
        oB.addInsert("Besth_FActH", 0)
        oSql.ExecuteNonQuery(oB.cInsert, t)

        Dim nBestH As Long = oSql.retrieveNewKey(t)

        For Each r As DataRowView In Me.BestelDBS
            Dim cArtikel As String = cNvl(r("Art_nr"))
            If cArtikel <> "" Then
                obzArtikel.Art_Nr = cArtikel
                oB.cTable = detail
                oB.addInsert("Bestd_BestH", nBestH)
                oB.addInsert("Bestd_IsStandaard", sqlClass.cBoolean(Me.BestH_StToegepast.Text = "Ja"))
                oB.addInsert("Bestd_Artikel", obzArtikel.Record.ARt_Id)
                oB.addInsert("Bestd_Omschrijving", sqlClass.c(r("Bestd_Omschrijving")))
                oB.addInsert("Bestd_Snijden", r("bestd_snijden"))
                oB.addInsert("bestd_Tour", sqlClass.c(r("bestd_tour")))
                oB.addInsert("bestd_Portie", sqlClass.cDoubleForjet(nNvlD(r("bestd_portie"))))
                oB.addInsert("bestd_Hoev", sqlClass.cDoubleForjet(nNvlD(r("bestd_Hoev"))))
                Dim nHoev1 As Double = nNvlD(r("bestd_hoev1"))
                If nHoev1 = 0 Then
                    nHoev1 = nNvlD(r("Bestd_Hoev"))
                End If
                oB.addInsert("bestd_Hoev1", sqlClass.cDoubleForjet(nHoev1))
                oB.addInsert("bestd_EenhPrijs", sqlClass.cDoubleForjet(r("bestd_EenhPrijs")))
                oB.addInsert("bestd_Waarde", sqlClass.cDoubleForjet(r("bestd_Waarde")))
                Dim lVerwittigen As Boolean = bNvl(r("BestD_Verwittigen"))
                oB.addInsert("bestd_Verwittigen", sqlClass.cBoolean(lVerwittigen))
                oB.addInsert("Bestd_Boodschap", sqlClass.c(cNvl(r("BestD_Boodschap"))))
                oB.addInsert("Bestd_Opschrift", sqlClass.c(cNvl(r("BestD_Opschrift"))))
                oSql.ExecuteNonQuery(oB.cInsert, t)
            End If
        Next
        updateTotals(header, t, conn, nBestH)
        nlog(cDocnr & " as andere datum", "frmBestel", LogType.logNormal, LogAction.logCreate, "Bestel", nBestH)
        t.Commit()
        conn.Close()
        MsgBox("Deze Bestelling werd bewaard als andere datum (" & cDocnr & ")")
        bzBestel.report(cDocnr)
        Me.obzBestel.load(nBestH)

        Me.initializeHistory()

    End Sub
    Private Sub grdBestelD_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBestelD.CellEnter
        Me.grdBestelD.EditMode = DataGridViewEditMode.EditOnKeystroke
        Select Case Me.grdBestelD.CurrentCell.ColumnIndex
            Case Me.grdBestelD.Columns("Omschrijving").Index
                Me.grdBestelD.EditMode = DataGridViewEditMode.EditOnEnter
                Try
                    CType(grdBestelD.EditingControl, TextBox).SelectionStart = 0
                    CType(grdBestelD.EditingControl, TextBox).SelectionLength = 0
                Catch
                End Try
                'Case Me.grdBestelD.Columns("BestD_Hoev1").Index
                '    Me.grdBestelD.EditMode = DataGridViewEditMode.EditOnEnter
                '    Try
                '        CType(grdBestelD.EditingControl, TextBox).SelectionStart = 0
                '        CType(grdBestelD.EditingControl, TextBox).SelectionLength = 0
                '    Catch
                '    End Try
        End Select
    End Sub
    Private Sub btnKalender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim o As New frmBestelKalender
        o.Show()
    End Sub
    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim dOld As Date = CDate(Me.BestH_DatLevering.Text)
        Dim dNew As Date = e.Start
        If dNew = dOld Then Exit Sub
        If oToggle = eToggle.eToggleBestelling Then
            Do While bzBestel.lValidLeverdatum(dNew) = False
                dNew = dNew.AddDays(1)
            Loop
        End If
        If Trim(Me.KL_Nummer.Text) <> "" And Me.obzBestel.pk = 0 Then
            If oToggle = eToggle.eToggleBestelling Then
                If dNew <= Now() Then
                    If Me.obzBestel.lExistsBestelling(bzKlanten.kl_id(Me.KL_Nummer.Text), dNew) = False Then
                        Me.MonthCalendar1.SetDate(dOld)
                        MsgBox("Er is geen bestelling voor " & Me.KL_Naam.Text & " op " & Format(dNew, modDutch.cDateFormat) & ".")
                        Exit Sub
                    End If
                    Dim lCantLoad As Boolean = False
                    Me.loadBestel(lCantLoad)
                    If lCantLoad Then
                        ' Throw New InvalidOperationException("Bestelling kan niet geladen worden.")
                        Exit Sub
                    End If
                    unlockSession(Me.nLogSession)
                    Me.bestelTabpage.SelectTab(0)
                    Me.grdBestelD.Focus()
                    Me.MonthCalendar1.SetDate(dNew)
                    Exit Sub
                End If
            Else 'levering
                Dim nCount As Long
                nCount = Me.obzBestel.nCountLeveringen(bzKlanten.kl_id(Me.KL_Nummer.Text), dNew)
                If nCount <> 0 Then
                    Dim cSeq As String
                    cSeq = InputBox("Er zijn (is) " & nCount & " levering(en) voor " & Me.KL_Naam.Text & " op " & Format(dNew, modDutch.cDateFormat) & ". Gelieve een volgnummer in te geven.")
                    If Val(cSeq) <> 0 Then
                        If Me.obzBestel.lExistsBestelling(Me.obzBestel.cDocnrFormat(bzKlanten.kl_id(Me.KL_Nummer.Text), dNew, eToggle.eToggleLevering, cSeq)) Then
                            Dim lCantLoad As Boolean = False
                            Me.loadBestel(lCantLoad)
                            If lCantLoad Then
                                ' Throw New InvalidOperationException("Bestelling kan niet geladen worden.")
                                Exit Sub
                            End If
                            unlockSession(Me.nLogSession)
                            Me.bestelTabpage.SelectTab(0)
                            Me.grdBestelD.Focus()
                            Me.MonthCalendar1.SetDate(dNew)
                            Exit Sub
                        End If
                    End If
                Else
                    Me.MonthCalendar1.SetDate(dOld)
                    MsgBox("Er zijn geen levering voor " & Me.KL_Naam.Text & " op " & Format(dNew, modDutch.cDateFormat) & "." & vbCrLf & "Nieuwe levering ingegeven terwijl een document geladen is wordt niet ondersteund.")
                    Exit Sub
                End If
            End If
        End If
        Me.MonthCalendar1.SetDate(dNew)
        Me.BestH_DatLevering.Text = Format(dNew, modDutch.cDateFormat)
        Me.DagLevering.Text = modDutch.cDagInDeWeek(dNew)
        Me.StType.Text = Me.DagLevering.Text
        Me.KL_Nummer.Focus()
    End Sub
    Private Sub BestH_DatLevering_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles BestH_DatLevering.Validated
        Me.KL_Nummer.Focus()
    End Sub
    Private Sub BestH_DatLevering_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BestH_DatLevering.Validating
        If checkDate(Me.BestH_DatLevering.Text) = False Then
            MsgBox(Me.BestH_DatLevering.Text & " is niet geldig")
            e.Cancel = True
            Exit Sub
        End If
        If CDate(Me.BestH_DatLevering.Text).DayOfWeek = DayOfWeek.Saturday Then
            MsgBox("Leveren op zaterdag wordt niet ondersteund.")
            e.Cancel = True
            Exit Sub
        End If
        Me.DagLevering.Text = modDutch.cDagInDeWeek(CDate(Me.BestH_DatLevering.Text))
        Me.StType.Text = Me.DagLevering.Text
        Me.MonthCalendar1.SetSelectionRange(CDate(Me.BestH_DatLevering.Text), CDate(Me.BestH_DatLevering.Text))
    End Sub
    Private Sub TpgBase1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bestelTabpage.SelectedIndexChanged
        Dim groothandelPage As Integer = 3
        Dim particulierenPage As Integer = 4
        If Me.bestelTabpage.SelectedIndex = groothandelPage Then
            Me.grdHistory.Focus()
        End If
        If Me.bestelTabpage.SelectedIndex = particulierenPage Then
            Me.particulierenOverzichtDatagridview.Focus()
        End If
    End Sub
    Private Sub toggle_snijden()
        If Trim(Me.grdBestelD(Me.grdBestelD.Columns("Art_Nr").Index, Me.grdBestelD.CurrentRow.Index).FormattedValue) = "" Then Exit Sub
        Dim c As String = Me.grdBestelD(Me.grdBestelD.Columns("Art_Nr").Index, Me.grdBestelD.CurrentRow.Index).FormattedValue
        If Me.obzArtikel.SnijdenApplicable Then
            Dim snijden As Boolean = Me.grdBestelD.CurrentRow.Cells("bestd_snijden").Value
            Me.grdBestelD.CurrentRow.Cells("bestd_snijden").Value = IIf(snijden, False, True)
        End If
    End Sub
    Private Sub Snijdentoggle_Enter(sender As System.Object, e As System.EventArgs) Handles Snijdentoggle.Enter
        If Me.previousControl.Name = "grdBestelD" Then
            Me.toggle_snijden()
            Me.grdBestelD.Focus()
            Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
            Me.grdBestelD.CurrentCell.Selected = True
        End If
    End Sub
    Private Sub EpsonA_Click(sender As System.Object, e As System.EventArgs) Handles EpsonA.Click
        If Me.previousControl.Name = "grdBestelD" Then
            Me.setepson("A")
            Me.grdBestelD.Focus()
            Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
            Me.grdBestelD.CurrentCell.Selected = True
        End If
    End Sub
    Private Sub EpsonB_Click(sender As System.Object, e As System.EventArgs) Handles EpsonA.Click, EpsonB.Click
        If Me.previousControl.Name = "grdBestelD" Then
            Me.setepson("B")
            Me.grdBestelD.Focus()
            Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
            Me.grdBestelD.CurrentCell.Selected = True
        End If
    End Sub
    Private Sub EpsonC_Click(sender As System.Object, e As System.EventArgs) Handles EpsonA.Click, EpsonC.Click
        If Me.previousControl.Name = "grdBestelD" Then
            Me.setepson("C")
            Me.grdBestelD.Focus()
            Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
            Me.grdBestelD.CurrentCell.Selected = True
        End If
    End Sub
    Private Sub EpsonD_Click(sender As System.Object, e As System.EventArgs) Handles EpsonA.Click, EpsonD.Click
        If Me.previousControl.Name = "grdBestelD" Then
            Me.setepson("D")
            Me.grdBestelD.Focus()
            Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
            Me.grdBestelD.CurrentCell.Selected = True
        End If
    End Sub
    Private Sub setepson(epsonlist As String)
        If Trim(Me.grdBestelD(Me.grdBestelD.Columns("Art_Nr").Index, Me.grdBestelD.CurrentRow.Index).FormattedValue) = "" Then Exit Sub
        If Me.grdBestelD.CurrentRow.Cells("voorafdrukken").FormattedValue = epsonlist Then
            Me.grdBestelD.CurrentRow.Cells("voorafdrukken").Value = " "
        Else
            Me.grdBestelD.CurrentRow.Cells("voorafdrukken").Value = epsonlist
        End If
    End Sub
    Private Sub EpsonAlles_Click(sender As System.Object, e As System.EventArgs) Handles EpsonAlles.Click
        If Me.previousControl.Name = "grdBestelD" Then
            Me.setepsonall()
            Me.grdBestelD.Focus()
            Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
            Me.grdBestelD.CurrentCell.Selected = True
        End If
    End Sub
    Private Sub setepsonall()
        Dim Setall As Boolean = Me.grdBestelD.Rows(0).Cells("Voorafdrukken").FormattedValue <> "A"
        For Each gridrow As DataGridViewRow In Me.grdBestelD.Rows
            If Trim(gen.cNvl(gridrow.Cells("Art_Nr").Value)) <> "" Then
                gridrow.Cells("voorafdrukken").Value = If(Setall, "A", " ")
            End If
        Next
    End Sub
    Private Sub direct_afdrukken_Click(sender As System.Object, e As System.EventArgs) Handles direct_afdrukken.Click
        BewaarEnBlijf_Click(sender, e)
        do_direct_afdrukken()
        Me.grdBestelD.Focus()
        Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
        Me.grdBestelD.CurrentCell.Selected = True
    End Sub
    Private Sub do_direct_afdrukken()
        If gen.cNvl(Me.grdBestelD.CurrentRow.Cells("Art_Nr").FormattedValue) = "" Then
            Return
        End If
        Dim uitzonderlijkdocument As New bzUitzonderlijkDocument
        Dim adres As New sqlClass
        adres.Execute("select * from adres where adr_id = " & Me.getAdresId)
        Dim parameters As New bzUitzonderlijkDocument.uitzondelijkdocument_variabelen
        parameters.telefoon = "Tel: " & Me.Adr_Telefoon.Text
        parameters.komthalen = IIf(Me.BestH_KomtHalen.Text = "Ja", "Komt Halen", "Sturen")
        parameters.klant_naam = Me.KL_Naam.Text
        parameters.adres = adres.dt(0)("Adr_Adres")
        parameters.postnummer_en_gemeente = uitzonderlijkdocument.format_postnummer_adres(adres.dt(0)("Adr_postnummer"), adres.dt(0)("Adr_Gemeente"))
        parameters.tour = Me.grdBestelD.CurrentRow.Cells("Tour").Value
        ' not sure why this is needed, but 22/10/13 did not parse for some reason.   Is excel the culrprit, but it is not even instanciated here;
        parameters.datum_levering = uitzonderlijkdocument.format_date(modDutch.parse_date(Me.BestH_DatLevering.Text))
        parameters.klantNummer = "Klant: " & Me.KL_Nummer.Text
        If IsDBNull(Me.grdBestelD.CurrentRow.Cells("bestd_hoev1").Value) = False Then
            parameters.hoeveelheid = Me.grdBestelD.CurrentRow.Cells("bestd_hoev1").Value
        ElseIf IsDBNull(Me.grdBestelD.CurrentRow.Cells("standaard").Value) = False Then
            parameters.hoeveelheid = Me.grdBestelD.CurrentRow.Cells("standaard").Value
        Else
            Return
        End If
        parameters.artikel_omschrijving = Me.grdBestelD.CurrentRow.Cells("omschrijving").Value
        parameters.info = Me.BestH_Info.Text
        If IsDBNull(Me.grdBestelD.CurrentRow.Cells("voorafdrukken").Value) OrElse Trim(Me.grdBestelD.CurrentRow.Cells("voorafdrukken").Value) = "" Then
            Me.grdBestelD.CurrentRow.Cells("voorafdrukken").Value = "Z"
        End If
        parameters.voorafdrukken = Me.grdBestelD.CurrentRow.Cells("voorafdrukken").Value
        parameters.artikel = Me.grdBestelD.CurrentRow.Cells("BestDArtikelDataGridViewTextBoxColumn").Value
        uitzonderlijkdocument.print(parameters)
        Me.grdBestelD.Focus()
        Me.grdBestelD.DefaultCellStyle.SelectionBackColor = Me.grdBestelD.backColorSelection
        Me.grdBestelD.CurrentCell.Selected = True
    End Sub
    Sub setbackground(klantenNummer As String)
        Dim klantType As String = bzTypeFact.getKlantType(klantenNummer)
        frmMain.setBackgroundColor(klantType)
    End Sub
    Private Sub Bestelfrm_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Me.setbackground(Me.KL_Nummer.Text)
    End Sub
    Private Sub BestH_Info_KeyDown(sender As Object, e As KeyEventArgs) Handles BestH_Info.KeyDown
        If e.KeyCode = Keys.End Then
            grdBestelD.Focus()
        End If
    End Sub
    Private Sub Bestellinglijnen_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles Bestellinglijnen.MaskInputRejected

    End Sub
    Private Sub SetBetaling(klnummer As String)
        Dim o As New bzKlanten
        o.kl_nummer = klnummer
        Dim betaling As String = IIf(o.record("kl_voldaan"), "Contant", "Per Overschrijving")
        BetalingTextbox.Text = betaling
    End Sub
    Private Sub PutCursorOnNextNewLine()
        Me.grdBestelD.Rows.Item(0).Selected = True
        Dim lastLine As Integer = 0
        While Trim(cNvl(Me.grdBestelD(Me.grdBestelD.Columns("Art_nr").Index, lastLine).Value)) <> ""
            lastLine += 1
        End While
        Me.grdBestelD.Rows.Item(lastLine).Selected = True
        Me.grdBestelD.CurrentCell = Me.grdBestelD(Me.grdBestelD.Columns("Art_nr").Index, lastLine)
    End Sub
    Private Sub PutCursorOnArt_Nr()
        Try
            If cNvl(grdBestelD(grdBestelD.Columns("Art_Nr").Index, grdBestelD.CurrentRow.Index + 1).Value) = "" Then
                grdBestelD(grdBestelD.Columns("Art_Nr").Index, grdBestelD.CurrentRow.Index + 1).Selected = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ResetKl_Nummer()
        KL_Nummer.Width = normalKl_NummerWidth
        KL_Nummer.Mask = normalKL_NummerMask
    End Sub

    Private Sub Bestelfrm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '<PATCH> 
        BestH_Standaard.Text = "1"
    End Sub
End Class




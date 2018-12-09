Public Class frmIndexArtikels
    Public IndexForm As frmIndex
    Public cKl_Nummer As String
    Public nArt_BTW As Double
    Dim cellValue

    Private Sub frmIndexArtikels_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            sectionToggle()
        End If
    End Sub
    Private Sub sectionToggle()
        If Me.grdArtikelDetails.Focused = True Then
            Me.GrdArtikels.Focus()
            Me.GrdArtikels.CurrentRow.Selected = True
        Else
            Me.grdArtikelDetails.Focus()
            Dim nCol As Integer = Me.grdArtikelDetails.Columns("colHoevEP").Index
            Dim nRow As Integer = Me.grdArtikelDetails.CurrentRow.Index
            Me.grdArtikelDetails(nCol, nRow).Selected = True
        End If

    End Sub
    Private Sub frmIndexTransacties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormMode = ModeValues.RecordEntry
        For Each oCol As DataGridViewColumn In Me.GrdArtikels.Columns
            If oCol.Visible And oCol.GetType.Name = "DataGridViewTextBoxColumn" Then oCol.SortMode = DataGridViewColumnSortMode.Automatic
            Me.GrdArtikels.setColumnTabstopFalse(oCol.Name)
        Next
        For Each oCol As DataGridViewColumn In Me.grdArtikelDetails.Columns
            If oCol.Visible Then oCol.SortMode = DataGridViewColumnSortMode.Automatic
            Me.grdArtikelDetails.setColumnTabstopFalse(oCol.Name)
            Dim EnabledColumns As List(Of String) = New List(Of String)({"colHoevEP", "colBedragEP"})

            If EnabledColumns.Contains(oCol.Name) = False Then
                Me.grdArtikelDetails.setColumnDisabled(oCol.Name)
            End If
        Next
        Me.grdArtikelDetails.Columns("colHoevEP").DefaultCellStyle.BackColor = Color.White
        Me.grdArtikelDetails.setColumnTabstop("colHoevEP")
        Me.grdArtikelDetails.Columns("colBedragEP").DefaultCellStyle.BackColor = Color.White
        Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colHoevEP").Index, 0).Selected = True
        Me.GrdArtikels.Rows(0).Selected = True
    End Sub
    Public Sub createIndexArtikel()
        Me.txtRekening.BackColor = Me.IndexForm.GrdKlant.BackgroundColor
        Me.TxtBedrag.BackColor = Me.IndexForm.GrdKlant.BackgroundColor
        Me.txtPercent.BackColor = Me.IndexForm.GrdKlant.BackgroundColor
        Me.TxtDoel.BackColor = Me.IndexForm.GrdKlant.BackgroundColor
        Me.TxtExPost.BackColor = Me.IndexForm.GrdKlant.BackgroundColor
        Me.txtRekening.Text = Me.IndexForm.GrdKlant("Rekening", Me.IndexForm.GrdKlant.CurrentRow.Index).Value
        Me.TxtBedrag.Text = CType(Me.IndexForm.GrdKlant("Bedrag", Me.IndexForm.GrdKlant.CurrentRow.Index).Value, Double).ToString("#,##0.00")
        Me.txtPercent.Text = CType(Me.IndexForm.GrdKlant("Percent", Me.IndexForm.GrdKlant.CurrentRow.Index).Value, Double).ToString("0.00 %")
        Me.TxtDoel.Text = CType(Me.IndexForm.GrdKlant("Doel", Me.IndexForm.GrdKlant.CurrentRow.Index).Value, Double).ToString("#,##0.00")
        Me.TxtExPost.Text = CType(Me.IndexForm.GrdKlant("ExPost", Me.IndexForm.GrdKlant.CurrentRow.Index).Value, Double).ToString("#,##0.00")

        Me.GrdArtikels.BackgroundColor = Me.IndexForm.GrdTransaction.BackgroundColor
        Dim oColKat As New DataGridViewTextBoxColumn
        oColKat.Name = "colKat"
        oColKat.HeaderText = "Kat"
        oColKat.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        oColKat.Width = 80
        oColKat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.GrdArtikels.Columns.Add(oColKat)
        Dim oColEenh As New DataGridViewTextBoxColumn
        With oColEenh
            .Name = "colEenh"
            .HeaderText = "Eenh"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Width = 50
        End With
        Me.GrdArtikels.Columns.Add(oColEenh)
        Dim oColArt As New DataGridViewTextBoxColumn
        With oColArt
            .Name = "colArt"
            .HeaderText = "Art"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        Me.GrdArtikels.Columns.Add(oColArt)
        Dim oColOmschrijving As New DataGridViewTextBoxColumn
        With oColOmschrijving
            .Name = "colOmschrijving"
            .HeaderText = "Omschrijving"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        Me.GrdArtikels.Columns.Add(oColOmschrijving)
        Dim oColHoev As New DataGridViewTextBoxColumn
        With oColHoev
            .Name = "colHoev"
            .HeaderText = "Hoev"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "0"
        End With
        Me.GrdArtikels.Columns.Add(oColHoev)
        Dim oColBedrag As New DataGridViewTextBoxColumn
        With oColBedrag
            .Name = "colBedrag"
            .HeaderText = "Bedrag"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "0.00"
        End With
        Me.GrdArtikels.Columns.Add(oColBedrag)
        Dim oColArt_id As New DataGridViewTextBoxColumn
        With oColArt_id
            .Name = "colArt_id"
            .Visible = False
        End With
        Me.GrdArtikels.Columns.Add(oColArt_id)
        Dim oColKl_id As New DataGridViewTextBoxColumn
        With oColKl_id
            .Name = "colKl_id"
            .Visible = False
        End With
        Me.GrdArtikels.Columns.Add(oColKl_id)

        For Each oCol As DataGridViewColumn In Me.GrdArtikels.Columns
            oCol.DefaultCellStyle.BackColor = Me.GrdArtikels.BackgroundColor
            oCol.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        Me.GrdArtikels.AllowUserToAddRows = False
        Me.GrdArtikels.AllowUserToDeleteRows = False

        Dim osqlArtikels As New sqlClass
        Dim cSqlArtikels As String
        Dim cTableArtikels As String = "tmpGlobal"
        Dim nPkKlant As Long = Me.IndexForm.GrdKlant("Klant", Me.IndexForm.GrdKlant.CurrentRow.Index).Value
        Dim nPkKlantBTW As Double = Me.IndexForm.GrdKlant("BTW", Me.IndexForm.GrdKlant.CurrentRow.Index).Value
        cSqlArtikels = "select tmpGlobal.eenh_omschrijving, tmpGlobal.kat_productieplan, tmpGlobal.art_nr, tmpGlobal.art_omschrijving, "
        cSqlArtikels &= "Sum(tmpGlobal.expostHoev) AS Hoev, Sum(tmpGlobal.expostBedrag) AS Bedrag, tmpGlobal.besth_klant,bestd_Artikel "
        cSqlArtikels &= "FROM (tmpGlobal) "
        cSqlArtikels &= "WHERE (tmpGlobal.besth_klant = " & nPkKlant & ") And (tmpGlobal.art_BTW = " & sqlClass.cDoubleForjet(nPkKlantBTW) & ") "
        cSqlArtikels &= " GROUP BY tmpGlobal.eenh_omschrijving, tmpGlobal.kat_productieplan, tmpGlobal.art_nr, tmpGlobal.art_omschrijving, tmpGlobal.besth_klant, tmpGlobal.art_BTW,bestd_artikel "
        cSqlArtikels &= "ORDER BY tmpGlobal.eenh_omschrijving, tmpGlobal.kat_productieplan, tmpGlobal.art_omschrijving"
        osqlArtikels.Execute(cSqlArtikels)

        For Each oRowArtikel As DataRow In osqlArtikels.dt.Rows
            Dim nRow As Integer = Me.GrdArtikels.Rows.Add()
            Me.GrdArtikels("colEenh", nRow).Value = oRowArtikel("Eenh_omschrijving")
            Me.GrdArtikels("colKat", nRow).Value = oRowArtikel("Kat_ProductiePlan")
            Me.GrdArtikels("colArt", nRow).Value = oRowArtikel("Art_nr")
            Me.GrdArtikels("colOmschrijving", nRow).Value = oRowArtikel("art_Omschrijving")
            Me.GrdArtikels("colHoev", nRow).Value = oRowArtikel("Hoev")
            Me.GrdArtikels("colBedrag", nRow).Value = oRowArtikel("Bedrag")
            Me.GrdArtikels("colKl_id", nRow).Value = oRowArtikel("besth_Klant")
            Me.GrdArtikels("colArt_id", nRow).Value = oRowArtikel("bestd_Artikel")
        Next


        Me.cKl_Nummer = Me.IndexForm.GrdKlant("KL_Nummer", Me.IndexForm.GrdKlant.CurrentRow.Index).Value
        Me.nArt_BTW = Me.IndexForm.GrdKlant("BTW", Me.IndexForm.GrdKlant.CurrentRow.Index).Value
        'Dim oSql As New sqlClass
        'Dim cSql As String
        'cSql = "select besth_Docnr,besth_datlevering,sum(expostBedrag) as Bedrag"
        'cSql &= " from tmpGlobal"
        'cSql &= " where kl_Nummer = " & sqlClass.c(me.cKl_Nummer) & " and Art_BTW = " & sqlClass.cDoubleForjet(me.nArt_BTW)
        'cSql &= " group by besth_Docnr,besth_datlevering,BestD_BestH"
        'cSql &= " order by sum(expostbedrag)"
        'oSql.Execute(cSql)
        'For Each oRow As DataRow In oSql.dt.Rows
        '    Dim nRow As Integer = me.GrdTransacties.Rows.Add()
        '    me.GrdTransacties("txtType", nRow).Value = bzBestel.cDocType(oRow("bestH_Docnr"))
        '    me.GrdTransacties("txtDag", nRow).Value = modDutch.cDagInDeWeek(oRow("Besth_DatLevering"))
        '    me.GrdTransacties("txtDatum", nRow).Value = oRow("BestH_DatLevering")
        '    me.GrdTransacties("txtBedragCol", nRow).Value = oRow("Bedrag")
        '    me.GrdTransacties("colBestH_Docnr", nRow).Value = oRow("BestH_Docnr")
        '    me.GrdTransacties("chkVerwijder", nRow).Value = "Nul!"
        'Next
        Me.grdArtikelDetails.BackgroundColor = Me.IndexForm.grdDetail.BackgroundColor
        Dim o1 As New DataGridViewTextBoxColumn
        o1.Name = "colType"
        o1.HeaderText = "Type"
        o1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        o1.Width = 40
        o1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.grdArtikelDetails.Columns.Add(o1)
        Dim o2 As New DataGridViewTextBoxColumn
        o2.Name = "colVlg"
        o2.HeaderText = "Vlg"
        o2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        o2.Width = 40
        o2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.grdArtikelDetails.Columns.Add(o2)
        Dim o3 As New DataGridViewTextBoxColumn
        o3.Name = "colDatum"
        o3.HeaderText = "Datum"
        o3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        o3.DefaultCellStyle.Format = "dd/MM/yy"
        o2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.grdArtikelDetails.Columns.Add(o3)
        Dim oNewDetailCol4 As New DataGridViewTextBoxColumn
        oNewDetailCol4.Name = "colDag"
        oNewDetailCol4.HeaderText = "Dag"
        oNewDetailCol4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        oNewDetailCol4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Me.grdArtikelDetails.Columns.Add(oNewDetailCol4)
        Dim oNewDetailCol5 As New DataGridViewTextBoxColumn
        oNewDetailCol5.Name = "colTotaal"
        oNewDetailCol5.HeaderText = "Totaal"
        oNewDetailCol5.DefaultCellStyle.Format = "0.00"
        oNewDetailCol5.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.grdArtikelDetails.Columns.Add(oNewDetailCol5)
        Dim oNewDetailCol6 As New DataGridViewTextBoxColumn
        oNewDetailCol6.Name = "colHoev"
        oNewDetailCol6.HeaderText = "Hoev"
        oNewDetailCol6.DefaultCellStyle.Format = "0"
        oNewDetailCol6.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.grdArtikelDetails.Columns.Add(oNewDetailCol6)
        Dim oNewDetailCol7 As New DataGridViewTextBoxColumn
        oNewDetailCol7.Name = "colBedrag"
        oNewDetailCol7.HeaderText = "Bedrag"
        oNewDetailCol7.DefaultCellStyle.Format = "0.00"
        oNewDetailCol7.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.grdArtikelDetails.Columns.Add(oNewDetailCol7)
        Dim oNewDetailCol8 As New DataGridViewTextBoxColumn
        oNewDetailCol8.Name = "colHoevEP"
        oNewDetailCol8.HeaderText = "Hoev EP"
        oNewDetailCol8.DefaultCellStyle.Format = "0"
        oNewDetailCol8.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.grdArtikelDetails.Columns.Add(oNewDetailCol8)
        Dim oNewDetailCol9 As New DataGridViewTextBoxColumn
        oNewDetailCol9.Name = "colBedragEP"
        oNewDetailCol9.HeaderText = "Bedrag EP"
        oNewDetailCol9.DefaultCellStyle.Format = "0.00"
        oNewDetailCol9.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.grdArtikelDetails.Columns.Add(oNewDetailCol9)
        Dim nCol As Integer = Me.grdArtikelDetails.Columns.Add(New DataGridViewTextBoxColumn)
        Me.grdArtikelDetails.Columns(nCol).Name = "colBestD_id"
        Me.grdArtikelDetails.Columns(nCol).Visible = False

        'Dim oNewDetailCol10 As New DataGridViewTextBoxColumn
        'oNewDetailCol10.Name = "colBestd_id"
        'oNewDetailCol10.HeaderText = "Best_id"
        ''oNewDetailCol9.DefaultCellStyle.Format = "0.00"
        ''oNewDetailCol9.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'oNewDetailCol10.Visible = False
        'me.grdArtikelDetails.Columns.Add(oNewDetailCol10)

        For Each oCol As DataGridViewColumn In Me.grdArtikelDetails.Columns
            oCol.DefaultCellStyle.BackColor = Me.grdArtikelDetails.BackgroundColor
        Next
        Me.grdArtikelDetails.AllowUserToAddRows = False
        Me.grdArtikelDetails.AllowUserToDeleteRows = False

        Me.GrdArtikels.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.GrdArtikels.RowsDefaultCellStyle.SelectionBackColor = Me.grdArtikelDetails.BackgroundColor

        Me.populateDetails(0)
    End Sub
    Public Sub populateDetails(ByVal nCurrentRow As Integer)
        If Me.GrdArtikels.Rows.Count = 0 Then Return
        Dim osqlArtikelDetails As New sqlClass
        Dim cSqlArtikelDetails As String
        Dim cTableArtikelDetails As String = "tmpGlobal" ' careful, this should be coming from the main form
        Dim nPkArtikelDetailsKlant As Long = Me.GrdArtikels("colKl_id", nCurrentRow).Value
        Dim nPkArticleDetailsArtikel As Double = Me.GrdArtikels("colArt_Id", nCurrentRow).Value
        cSqlArtikelDetails = "select tmpGlobal.bestd_besth, tmpGlobal.besth_docnr, tmpGlobal.besth_datlevering, tmpGlobal.bestd_Hoev1, tmpGlobal.netto, tmpGlobal.expostHoev, "
        cSqlArtikelDetails &= "tmpGlobal.expostBedrag, tmpGlobal.bestd_id "
        cSqlArtikelDetails &= "FROM " & cTableArtikelDetails & " as tmpGlobal "
        cSqlArtikelDetails &= "WHERE (((tmpGlobal.besth_klant)= " & nPkArtikelDetailsKlant & ") AND ((tmpGlobal.bestd_Artikel)= " & nPkArticleDetailsArtikel & "))"
        osqlArtikelDetails.Execute(cSqlArtikelDetails)
        Me.grdArtikelDetails.Rows.Clear()
        For Each oRow As DataRow In osqlArtikelDetails.dt.Rows
            Dim nGrdRow As Integer = Me.grdArtikelDetails.Rows.Add
            Me.grdArtikelDetails("ColType", nGrdRow).Value = bzBestel.cDocType(oRow("Besth_Docnr"))
            Me.grdArtikelDetails("ColVlg", nGrdRow).Value = bzBestel.cDocSeq(oRow("Besth_Docnr"))
            Me.grdArtikelDetails("colDag", nGrdRow).Value = modDutch.cDagInDeWeek(oRow("Besth_datlevering"))
            Me.grdArtikelDetails("colDatum", nGrdRow).Value = oRow("besth_DatLevering")
            Me.grdArtikelDetails("colHoev", nGrdRow).Value = oRow("bestd_Hoev1")
            Me.grdArtikelDetails("colBedrag", nGrdRow).Value = oRow("Netto")
            Me.grdArtikelDetails("colHoevEP", nGrdRow).Value = oRow("expostHoev")
            Me.grdArtikelDetails("colBedragEP", nGrdRow).Value = oRow("expostBedrag")
            Me.grdArtikelDetails("colBestD_id", nGrdRow).Value = oRow("bestd_id")

            Dim osqlTotaal As New sqlClass
            Dim cSqlTotaal As String = "select sum(expostbedrag) from " & cTableArtikelDetails & " where bestd_besth = " & oRow("Bestd_BestH")
            Me.grdArtikelDetails("colTotaal", nGrdRow).Value = osqlTotaal.ExecuteScalar(cSqlTotaal)
        Next
    End Sub
    Private Sub GrdArtikels_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdArtikels.RowEnter
        populateDetails(e.RowIndex)
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub grdArtikelDetails_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdArtikelDetails.CellEnter
        Me.cellValue = Me.grdArtikelDetails.CurrentCell.Value
    End Sub
    Function nCurrentPrice() As Double
        Dim nHoev As Long = Me.GrdArtikels.CurrentRow.Cells("colHoev").Value
        Dim nBedrag As Double = Me.GrdArtikels.CurrentRow.Cells("colBedrag").Value
        If nHoev = 0 Then
            nHoev = Me.grdArtikelDetails.CurrentRow.Cells("colHoev").Value
            If nHoev = 0 Then
                Return 0
            End If
            nBedrag = Me.grdArtikelDetails.CurrentRow.Cells("colBedrag").Value
        End If
        Return nBedrag / nHoev
    End Function
    Private Sub GrdArtikelsDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdArtikelDetails.CellEndEdit
        Dim cCol As String = UCase(Me.grdArtikelDetails.Columns(Me.grdArtikelDetails.CurrentCell.ColumnIndex).Name)
        Dim nRow As Integer = Me.grdArtikelDetails.CurrentCell.RowIndex
        Dim lInvalidEntry As Boolean = False
        Dim nTotaal As Double = Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colTotaal").Index, nRow).Value
        Dim nBedragExAnte As Double = Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colBedragEp").Index, nRow).Value

        Select Case cCol
            Case "COLHOEVEP"
                If Me.nCurrentPrice() = 0 Then
                    MsgBox("Er is geen prijs voorhanden voor dit artikel.   De hoeveelheid kan hier niet veranderd worden.")
                    Me.grdArtikelDetails.CurrentCell.Value = Me.cellValue
                    Return
                End If
                Try
                    Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colBedragEp").Index, nRow).Value =
                            Me.grdArtikelDetails.CurrentCell.Value * Me.nCurrentPrice
                Catch
                    lInvalidEntry = True
                End Try

            Case "COLBEDRAGEP"
                If Me.nCurrentPrice() = 0 Then
                    MsgBox("Er is geen prijs voorhanden voor dit artikel.   De hoeveelheid kan hier niet veranderd worden.")
                    Me.grdArtikelDetails.CurrentCell.Value = Me.cellValue
                    Return
                End If
                Try
                    Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colHoevEp").Index, nRow).Value =
                                                    Me.grdArtikelDetails.CurrentCell.Value / Me.nCurrentPrice
                Catch
                    lInvalidEntry = True
                End Try


        End Select
        If lInvalidEntry = True Then
            MsgBox("De waarde die U ingaf is niet geldig.  Probeert U het opnieuw.")
            Me.grdArtikelDetails.CurrentCell.Value = Me.cellValue
            Return
        End If
        Dim nNewBedrag As Double = Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colBedragEP").Index, nRow).Value
        Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colTotaal").Index, nRow).Value =
            (nTotaal - nBedragExAnte + nNewBedrag).ToString("N2")
        implementChangeindex(nRow)
        refreshArtikellijn()
        refreshKlanttotaal()
    End Sub
    Sub implementChangeindex(nRowLijn As Integer)
        Dim nBestD_id As Long = Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colBestd_id").Index, nRowLijn).Value
        Dim nHoevEp As Long = Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colHoevEp").Index, nRowLijn).Value
        Dim nBedragEp As Long = Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colBedragEp").Index, nRowLijn).Value
        Me.grdArtikelDetails(Me.grdArtikelDetails.Columns("colBedragEp").Index, nRowLijn).Value = nBedragEp
        Dim oSql As New sqlClass
        Dim temp As String = "select bestd_besth from " & Me.IndexForm.cGlobalFilename
        temp &= " where bestd_id = " & nBestD_id
        Dim nBestH_id As Long = oSql.ExecuteScalar(temp)
        Dim nRowDocument As Long
        Dim grd As DataGridView = Me.IndexForm.GrdTransaction
        grd.ClearSelection()
        For Each row As DataGridViewRow In grd.Rows
            If row.Cells("colBestH_id").Value = nBestH_id Then
                nRowDocument = row.Index
                row.Selected = True
                Exit For
            End If
        Next
        Me.IndexForm.refreshDetail(nRowDocument)
        For Each row As DataGridViewRow In Me.IndexForm.grdDetail.Rows
            If row.Cells("colBestD_id").Value = nBestD_id Then
                row.Selected = True
                row.Cells("colHoevEP").Value = nHoevEp
                row.Cells("colBedragEP").Value = nBedragEp
                row.Cells("ColHoevEP").Selected = True
                Me.IndexForm.oSelectedDetail.recompute(row.Index)
                Me.IndexForm.computeTotalsforsession()
                Me.IndexForm.refreshKlantTotals()
                Exit For
            End If
        Next
    End Sub
    Sub refreshArtikellijn()
        Dim nH As Long = 0
        Dim nB As Long = 0
        For Each r As DataGridViewRow In Me.grdArtikelDetails.Rows
            If cNvl(r.Cells("colHoevEP").Value) = "" Then
                Exit For
            End If
            nH += r.Cells("colHoevEP").Value
            nB += r.Cells("colBedragEP").Value
        Next
        Me.GrdArtikels.CurrentRow.Cells("colHoev").Value = nH.ToString("N0")
        Me.GrdArtikels.CurrentRow.Cells("colBedrag").Value = nB.ToString("N2")
    End Sub
    Sub refreshKlanttotaal()
        Dim nB As Long = 0
        For Each r As DataGridViewRow In Me.GrdArtikels.Rows
            If cNvl(r.Cells("colBedrag").Value) = "" Then
                Exit For
            End If
            nB += r.Cells("colBedrag").Value
        Next
        Me.TxtExPost.Text = nB.ToString("N2")
    End Sub

    Private Sub BtnSectionToggle_Click(sender As System.Object, e As System.EventArgs) Handles BtnSectionToggle.Click
        Me.sectionToggle()
    End Sub
End Class

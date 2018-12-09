<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductiePlanOverzicht
    Inherits b040.frmB040

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New b040.btnBase()
        Me.tpgProductiePlanOverzicht = New b040.tpgBase()
        Me.TabPageProductiePlanOverzicht = New System.Windows.Forms.TabPage()
        Me.BtnSelectAll = New b040.btnBase()
        Me.GrdBestelling = New b040.grdBase()
        Me.colDatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colKl_Nummer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colKL_Naam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHoev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bestd_id = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GrdArtikel = New b040.grdBase()
        Me.colKat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colArtNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOmschrijving = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHoev1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEenh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colArt_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnSave = New b040.btnBase()
        Me.klantTypeCombobox = New b040.cboBase()
        Me.leveringsDatumsCombobox = New b040.cboBase()
        Me.tpgProductiePlanOverzicht.SuspendLayout()
        Me.TabPageProductiePlanOverzicht.SuspendLayout()
        CType(Me.GrdBestelling, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdArtikel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnClose.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnClose.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(903, 514)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.nIO = b040.IOValues.IORecordEntryEnable
        Me.btnClose.Size = New System.Drawing.Size(74, 24)
        Me.btnClose.TabIndex = 46
        Me.btnClose.Text = "Sluit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tpgProductiePlanOverzicht
        '
        Me.tpgProductiePlanOverzicht.Controls.Add(Me.TabPageProductiePlanOverzicht)
        Me.tpgProductiePlanOverzicht.Controls.Add(Me.TabPage2)
        Me.tpgProductiePlanOverzicht.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.tpgProductiePlanOverzicht.Location = New System.Drawing.Point(3, 6)
        Me.tpgProductiePlanOverzicht.Name = "tpgProductiePlanOverzicht"
        Me.tpgProductiePlanOverzicht.SelectedIndex = 0
        Me.tpgProductiePlanOverzicht.Size = New System.Drawing.Size(982, 509)
        Me.tpgProductiePlanOverzicht.TabIndex = 47
        Me.tpgProductiePlanOverzicht.TabStop = False
        '
        'TabPageProductiePlanOverzicht
        '
        Me.TabPageProductiePlanOverzicht.Controls.Add(Me.BtnSelectAll)
        Me.TabPageProductiePlanOverzicht.Controls.Add(Me.GrdBestelling)
        Me.TabPageProductiePlanOverzicht.Controls.Add(Me.GrdArtikel)
        Me.TabPageProductiePlanOverzicht.Location = New System.Drawing.Point(4, 25)
        Me.TabPageProductiePlanOverzicht.Name = "TabPageProductiePlanOverzicht"
        Me.TabPageProductiePlanOverzicht.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageProductiePlanOverzicht.Size = New System.Drawing.Size(974, 480)
        Me.TabPageProductiePlanOverzicht.TabIndex = 0
        Me.TabPageProductiePlanOverzicht.Text = "Productie Plan Overzicht"
        Me.TabPageProductiePlanOverzicht.UseVisualStyleBackColor = True
        '
        'BtnSelectAll
        '
        Me.BtnSelectAll.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.BtnSelectAll.Image = Global.b040.My.Resources.Resources.CANCEL
        Me.BtnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSelectAll.Location = New System.Drawing.Point(756, 454)
        Me.BtnSelectAll.Name = "BtnSelectAll"
        Me.BtnSelectAll.nIO = b040.IOValues.IORecordEntryEnable
        Me.BtnSelectAll.Size = New System.Drawing.Size(211, 23)
        Me.BtnSelectAll.TabIndex = 2
        Me.BtnSelectAll.Text = "Selecteren om te verwijderen"
        Me.BtnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSelectAll.UseVisualStyleBackColor = True
        '
        'GrdBestelling
        '
        Me.GrdBestelling.AllowUserToAddRows = False
        Me.GrdBestelling.AllowUserToDeleteRows = False
        Me.GrdBestelling.AllowUserToOrderColumns = True
        Me.GrdBestelling.AllowUserToResizeRows = False
        Me.GrdBestelling.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrdBestelling.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdBestelling.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdBestelling.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDatum, Me.colDag, Me.colKl_Nummer, Me.colKL_Naam, Me.colHoev, Me.colSel, Me.bestd_id})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdBestelling.DefaultCellStyle = DataGridViewCellStyle6
        Me.GrdBestelling.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.GrdBestelling.GridColor = System.Drawing.Color.LightGray
        Me.GrdBestelling.lKeepHighlightOnLostFocus = False
        Me.GrdBestelling.Location = New System.Drawing.Point(496, 3)
        Me.GrdBestelling.Name = "GrdBestelling"
        Me.GrdBestelling.nIO = b040.IOValues.IORecordEntryEnable
        Me.GrdBestelling.ReadOnly = True
        Me.GrdBestelling.RowHeadersVisible = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrdBestelling.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GrdBestelling.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GrdBestelling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdBestelling.Size = New System.Drawing.Size(476, 448)
        Me.GrdBestelling.TabIndex = 1
        '
        'colDatum
        '
        DataGridViewCellStyle2.Format = "dd/MM/yy"
        DataGridViewCellStyle2.NullValue = "dd/MM/yy"
        Me.colDatum.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDatum.HeaderText = "Datum"
        Me.colDatum.Name = "colDatum"
        Me.colDatum.ReadOnly = True
        Me.colDatum.Width = 63
        '
        'colDag
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colDag.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDag.HeaderText = "Dag"
        Me.colDag.Name = "colDag"
        Me.colDag.ReadOnly = True
        Me.colDag.Width = 75
        '
        'colKl_Nummer
        '
        Me.colKl_Nummer.HeaderText = "Kl Nr"
        Me.colKl_Nummer.Name = "colKl_Nummer"
        Me.colKl_Nummer.ReadOnly = True
        Me.colKl_Nummer.Width = 50
        '
        'colKL_Naam
        '
        Me.colKL_Naam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colKL_Naam.DefaultCellStyle = DataGridViewCellStyle4
        Me.colKL_Naam.HeaderText = "Naam"
        Me.colKL_Naam.Name = "colKL_Naam"
        Me.colKL_Naam.ReadOnly = True
        '
        'colHoev
        '
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colHoev.DefaultCellStyle = DataGridViewCellStyle5
        Me.colHoev.HeaderText = "Hoev"
        Me.colHoev.Name = "colHoev"
        Me.colHoev.ReadOnly = True
        Me.colHoev.Width = 58
        '
        'colSel
        '
        Me.colSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colSel.HeaderText = "Sel"
        Me.colSel.Name = "colSel"
        Me.colSel.ReadOnly = True
        Me.colSel.Width = 30
        '
        'bestd_id
        '
        Me.bestd_id.HeaderText = "Bestd_id"
        Me.bestd_id.Name = "bestd_id"
        Me.bestd_id.ReadOnly = True
        Me.bestd_id.Visible = False
        '
        'GrdArtikel
        '
        Me.GrdArtikel.AllowUserToAddRows = False
        Me.GrdArtikel.AllowUserToDeleteRows = False
        Me.GrdArtikel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.GrdArtikel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdArtikel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GrdArtikel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colKat, Me.colArtNr, Me.colOmschrijving, Me.colHoev1, Me.colEenh, Me.colArt_id})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdArtikel.DefaultCellStyle = DataGridViewCellStyle14
        Me.GrdArtikel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.GrdArtikel.GridColor = System.Drawing.Color.LightGray
        Me.GrdArtikel.lKeepHighlightOnLostFocus = True
        Me.GrdArtikel.Location = New System.Drawing.Point(7, 3)
        Me.GrdArtikel.MultiSelect = False
        Me.GrdArtikel.Name = "GrdArtikel"
        Me.GrdArtikel.nIO = b040.IOValues.IOAlwaysDisable
        Me.GrdArtikel.ReadOnly = True
        Me.GrdArtikel.RowHeadersVisible = False
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.GrdArtikel.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.GrdArtikel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GrdArtikel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdArtikel.Size = New System.Drawing.Size(487, 448)
        Me.GrdArtikel.TabIndex = 0
        '
        'colKat
        '
        Me.colKat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colKat.DefaultCellStyle = DataGridViewCellStyle9
        Me.colKat.HeaderText = "Kat"
        Me.colKat.Name = "colKat"
        Me.colKat.ReadOnly = True
        '
        'colArtNr
        '
        Me.colArtNr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colArtNr.DefaultCellStyle = DataGridViewCellStyle10
        Me.colArtNr.HeaderText = "Art Nr"
        Me.colArtNr.Name = "colArtNr"
        Me.colArtNr.ReadOnly = True
        Me.colArtNr.Width = 67
        '
        'colOmschrijving
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colOmschrijving.DefaultCellStyle = DataGridViewCellStyle11
        Me.colOmschrijving.HeaderText = "Omschrijving"
        Me.colOmschrijving.Name = "colOmschrijving"
        Me.colOmschrijving.ReadOnly = True
        Me.colOmschrijving.Width = 200
        '
        'colHoev1
        '
        Me.colHoev1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle12.Format = "#,##0"
        Me.colHoev1.DefaultCellStyle = DataGridViewCellStyle12
        Me.colHoev1.HeaderText = "Hoev"
        Me.colHoev1.Name = "colHoev1"
        Me.colHoev1.ReadOnly = True
        Me.colHoev1.Width = 60
        '
        'colEenh
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.Format = "#,##0.00"
        Me.colEenh.DefaultCellStyle = DataGridViewCellStyle13
        Me.colEenh.HeaderText = "Eenh"
        Me.colEenh.Name = "colEenh"
        Me.colEenh.ReadOnly = True
        Me.colEenh.Width = 57
        '
        'colArt_id
        '
        Me.colArt_id.HeaderText = "Art_id"
        Me.colArt_id.Name = "colArt_id"
        Me.colArt_id.ReadOnly = True
        Me.colArt_id.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(974, 480)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.BtnSave.Image = Global.b040.My.Resources.Resources.save
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.Location = New System.Drawing.Point(3, 517)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.nIO = b040.IOValues.IORecordEntryEnable
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 48
        Me.BtnSave.Text = "OK"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'klantTypeCombobox
        '
        Me.klantTypeCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.klantTypeCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.klantTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.klantTypeCombobox.Font = New System.Drawing.Font("Trebuchet MS", 10.0!, System.Drawing.FontStyle.Bold)
        Me.klantTypeCombobox.ForeColor = System.Drawing.Color.DarkBlue
        Me.klantTypeCombobox.FormattingEnabled = True
        Me.klantTypeCombobox.Items.AddRange(New Object() {"Alle klant types", "Groothandel", "Particulieren"})
        Me.klantTypeCombobox.Location = New System.Drawing.Point(96, 518)
        Me.klantTypeCombobox.Name = "klantTypeCombobox"
        Me.klantTypeCombobox.nIO = b040.IOValues.IOAlwaysEnable
        Me.klantTypeCombobox.setAutocomplete = True
        Me.klantTypeCombobox.Size = New System.Drawing.Size(162, 26)
        Me.klantTypeCombobox.TabIndex = 49
        '
        'leveringsDatumsCombobox
        '
        Me.leveringsDatumsCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.leveringsDatumsCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.leveringsDatumsCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.leveringsDatumsCombobox.Font = New System.Drawing.Font("Trebuchet MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.leveringsDatumsCombobox.ForeColor = System.Drawing.Color.DarkBlue
        Me.leveringsDatumsCombobox.FormattingEnabled = True
        Me.leveringsDatumsCombobox.Location = New System.Drawing.Point(267, 518)
        Me.leveringsDatumsCombobox.Name = "leveringsDatumsCombobox"
        Me.leveringsDatumsCombobox.nIO = b040.IOValues.IOAlwaysEnable
        Me.leveringsDatumsCombobox.setAutocomplete = True
        Me.leveringsDatumsCombobox.Size = New System.Drawing.Size(162, 26)
        Me.leveringsDatumsCombobox.TabIndex = 52
        '
        'frmProductiePlanOverzicht
        '
        Me.ClientSize = New System.Drawing.Size(987, 550)
        Me.Controls.Add(Me.leveringsDatumsCombobox)
        Me.Controls.Add(Me.klantTypeCombobox)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.tpgProductiePlanOverzicht)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmProductiePlanOverzicht"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productie Plan Overzicht"
        Me.tpgProductiePlanOverzicht.ResumeLayout(False)
        Me.TabPageProductiePlanOverzicht.ResumeLayout(False)
        CType(Me.GrdBestelling, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdArtikel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As b040.btnBase
    Friend WithEvents tpgProductiePlanOverzicht As b040.tpgBase
    Friend WithEvents TabPageProductiePlanOverzicht As System.Windows.Forms.TabPage
    Friend WithEvents GrdArtikel As b040.grdBase
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents BtnSelectAll As b040.btnBase
    Friend WithEvents colDatum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colKl_Nummer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colKL_Naam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHoev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents bestd_id As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BtnSave As b040.btnBase
    Friend WithEvents klantTypeCombobox As b040.cboBase
    Friend WithEvents leveringsDatumsCombobox As b040.cboBase
    Friend WithEvents colKat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colArtNr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOmschrijving As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHoev1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEenh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colArt_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrdBestelling As b040.grdBase

End Class

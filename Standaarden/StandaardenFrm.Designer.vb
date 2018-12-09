<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StandaardenFrm
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StandaardenFrm))
        Me.GrdBase1 = New b040.grdBase()
        Me.Art_NrCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.std_ArtOmschrijvingCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.std_HoeveelheidCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eenh_HoevInvoerCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.std_TourCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SnijdenCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.std_Snijden = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.StdidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StdsthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StdArtikelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Art_Snijden = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.STandaardDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StandaardenDS1 = New b040.StandaardenDS()
        Me.SaveButton = New b040.btnBase()
        Me.PnlBase1 = New b040.pnlBase()
        Me.telefoonLabel = New System.Windows.Forms.Label()
        Me.typeKlantLabel = New System.Windows.Forms.Label()
        Me.TypSB_OmschrijvingCTl = New b040.cboBase()
        Me.StandaardHBS = New System.Windows.Forms.BindingSource(Me.components)
        Me.KL_NaamCtl = New b040.txtBase()
        Me.LblBase3 = New b040.lblBase()
        Me.LblBase2 = New b040.lblBase()
        Me.Sth_TypeCtl = New b040.txtBase()
        Me.LblBase1 = New b040.lblBase()
        Me.KL_NummerCtl = New b040.txtBase()
        Me.CloseBtn = New b040.btnBase()
        Me.StandaardHTableAdapter1 = New b040.StandaardenDSTableAdapters.StandaardHTableAdapter()
        Me.STandaardDTableAdapter = New b040.StandaardenDSTableAdapters.STandaardDTableAdapter()
        Me.TableAdapterManager = New b040.StandaardenDSTableAdapters.TableAdapterManager()
        Me.deleteButton = New b040.btnBase()
        CType(Me.GrdBase1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STandaardDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StandaardenDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBase1.SuspendLayout()
        CType(Me.StandaardHBS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrdBase1
        '
        Me.GrdBase1.AllowUserToOrderColumns = True
        Me.GrdBase1.AutoGenerateColumns = False
        Me.GrdBase1.BackgroundColor = System.Drawing.Color.White
        Me.GrdBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdBase1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdBase1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Art_NrCol, Me.std_ArtOmschrijvingCol, Me.std_HoeveelheidCol, Me.Eenh_HoevInvoerCol, Me.std_TourCol, Me.SnijdenCol, Me.std_Snijden, Me.StdidDataGridViewTextBoxColumn, Me.StdsthDataGridViewTextBoxColumn, Me.StdArtikelDataGridViewTextBoxColumn, Me.Art_Snijden})
        Me.GrdBase1.DataSource = Me.STandaardDBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdBase1.DefaultCellStyle = DataGridViewCellStyle2
        Me.GrdBase1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.GrdBase1.Enabled = False
        Me.GrdBase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrdBase1.GridColor = System.Drawing.Color.Silver
        Me.GrdBase1.lKeepHighlightOnLostFocus = False
        Me.GrdBase1.Location = New System.Drawing.Point(3, 88)
        Me.GrdBase1.Name = "GrdBase1"
        Me.GrdBase1.nIO = b040.IOValues.IORecordEntryEnable
        Me.GrdBase1.RowHeadersVisible = False
        Me.GrdBase1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GrdBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GrdBase1.Size = New System.Drawing.Size(587, 495)
        Me.GrdBase1.TabIndex = 4
        '
        'Art_NrCol
        '
        Me.Art_NrCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Art_NrCol.DataPropertyName = "Art_Nr"
        Me.Art_NrCol.FillWeight = 5.0!
        Me.Art_NrCol.HeaderText = "Art. Nr"
        Me.Art_NrCol.Name = "Art_NrCol"
        Me.Art_NrCol.Width = 71
        '
        'std_ArtOmschrijvingCol
        '
        Me.std_ArtOmschrijvingCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.std_ArtOmschrijvingCol.DataPropertyName = "std_ArtOmschrijving"
        Me.std_ArtOmschrijvingCol.FillWeight = 20.0!
        Me.std_ArtOmschrijvingCol.HeaderText = "Art. Omschrijving"
        Me.std_ArtOmschrijvingCol.Name = "std_ArtOmschrijvingCol"
        '
        'std_HoeveelheidCol
        '
        Me.std_HoeveelheidCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.std_HoeveelheidCol.DataPropertyName = "std_Hoeveelheid"
        Me.std_HoeveelheidCol.FillWeight = 5.0!
        Me.std_HoeveelheidCol.HeaderText = "St./Gew."
        Me.std_HoeveelheidCol.Name = "std_HoeveelheidCol"
        Me.std_HoeveelheidCol.Width = 81
        '
        'Eenh_HoevInvoerCol
        '
        Me.Eenh_HoevInvoerCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Eenh_HoevInvoerCol.DataPropertyName = "Eenh_HoevInvoer"
        Me.Eenh_HoevInvoerCol.FillWeight = 9.0!
        Me.Eenh_HoevInvoerCol.HeaderText = "Eenh."
        Me.Eenh_HoevInvoerCol.Name = "Eenh_HoevInvoerCol"
        Me.Eenh_HoevInvoerCol.Width = 64
        '
        'std_TourCol
        '
        Me.std_TourCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.std_TourCol.DataPropertyName = "std_Tour"
        Me.std_TourCol.FillWeight = 5.0!
        Me.std_TourCol.HeaderText = "Tour"
        Me.std_TourCol.Name = "std_TourCol"
        Me.std_TourCol.Width = 58
        '
        'SnijdenCol
        '
        Me.SnijdenCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.SnijdenCol.HeaderText = "Snijden"
        Me.SnijdenCol.Name = "SnijdenCol"
        Me.SnijdenCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SnijdenCol.Width = 55
        '
        'std_Snijden
        '
        Me.std_Snijden.DataPropertyName = "std_Snijden"
        Me.std_Snijden.HeaderText = "std_Snijden"
        Me.std_Snijden.Name = "std_Snijden"
        Me.std_Snijden.Visible = False
        '
        'StdidDataGridViewTextBoxColumn
        '
        Me.StdidDataGridViewTextBoxColumn.DataPropertyName = "std_id"
        Me.StdidDataGridViewTextBoxColumn.HeaderText = "std_id"
        Me.StdidDataGridViewTextBoxColumn.Name = "StdidDataGridViewTextBoxColumn"
        Me.StdidDataGridViewTextBoxColumn.Visible = False
        '
        'StdsthDataGridViewTextBoxColumn
        '
        Me.StdsthDataGridViewTextBoxColumn.DataPropertyName = "std_sth"
        Me.StdsthDataGridViewTextBoxColumn.HeaderText = "std_sth"
        Me.StdsthDataGridViewTextBoxColumn.Name = "StdsthDataGridViewTextBoxColumn"
        Me.StdsthDataGridViewTextBoxColumn.Visible = False
        '
        'StdArtikelDataGridViewTextBoxColumn
        '
        Me.StdArtikelDataGridViewTextBoxColumn.DataPropertyName = "std_Artikel"
        Me.StdArtikelDataGridViewTextBoxColumn.HeaderText = "std_Artikel"
        Me.StdArtikelDataGridViewTextBoxColumn.Name = "StdArtikelDataGridViewTextBoxColumn"
        Me.StdArtikelDataGridViewTextBoxColumn.Visible = False
        '
        'Art_Snijden
        '
        Me.Art_Snijden.DataPropertyName = "Art_Snijden"
        Me.Art_Snijden.HeaderText = "Art_Snijden"
        Me.Art_Snijden.Name = "Art_Snijden"
        Me.Art_Snijden.Visible = False
        '
        'STandaardDBindingSource
        '
        Me.STandaardDBindingSource.DataMember = "STandaardD"
        Me.STandaardDBindingSource.DataSource = Me.StandaardenDS1
        '
        'StandaardenDS1
        '
        Me.StandaardenDS1.DataSetName = "StandaardenDS"
        Me.StandaardenDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SaveButton
        '
        Me.SaveButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Image = CType(resources.GetObject("SaveButton.Image"), System.Drawing.Image)
        Me.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveButton.Location = New System.Drawing.Point(3, 586)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 22
        Me.SaveButton.Text = "Bewaar"
        Me.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.telefoonLabel)
        Me.PnlBase1.Controls.Add(Me.typeKlantLabel)
        Me.PnlBase1.Controls.Add(Me.TypSB_OmschrijvingCTl)
        Me.PnlBase1.Controls.Add(Me.KL_NaamCtl)
        Me.PnlBase1.Controls.Add(Me.LblBase3)
        Me.PnlBase1.Controls.Add(Me.LblBase2)
        Me.PnlBase1.Controls.Add(Me.Sth_TypeCtl)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.KL_NummerCtl)
        Me.PnlBase1.Location = New System.Drawing.Point(3, 1)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(586, 82)
        Me.PnlBase1.TabIndex = 23
        '
        'telefoonLabel
        '
        Me.telefoonLabel.AutoSize = True
        Me.telefoonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.telefoonLabel.ForeColor = System.Drawing.Color.DarkBlue
        Me.telefoonLabel.Location = New System.Drawing.Point(403, 31)
        Me.telefoonLabel.Name = "telefoonLabel"
        Me.telefoonLabel.Size = New System.Drawing.Size(0, 13)
        Me.telefoonLabel.TabIndex = 10
        '
        'typeKlantLabel
        '
        Me.typeKlantLabel.AutoSize = True
        Me.typeKlantLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typeKlantLabel.ForeColor = System.Drawing.Color.Navy
        Me.typeKlantLabel.Location = New System.Drawing.Point(403, 10)
        Me.typeKlantLabel.Name = "typeKlantLabel"
        Me.typeKlantLabel.Size = New System.Drawing.Size(0, 13)
        Me.typeKlantLabel.TabIndex = 9
        '
        'TypSB_OmschrijvingCTl
        '
        Me.TypSB_OmschrijvingCTl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StandaardHBS, "TYPSB_OMSCHRIJVING", True))
        Me.TypSB_OmschrijvingCTl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.TypSB_OmschrijvingCTl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TypSB_OmschrijvingCTl.ForeColor = System.Drawing.Color.DarkBlue
        Me.TypSB_OmschrijvingCTl.FormattingEnabled = True
        Me.TypSB_OmschrijvingCTl.Location = New System.Drawing.Point(109, 50)
        Me.TypSB_OmschrijvingCTl.Name = "TypSB_OmschrijvingCTl"
        Me.TypSB_OmschrijvingCTl.nIO = b040.IOValues.IOKeyEntryEnable
        Me.TypSB_OmschrijvingCTl.setAutocomplete = False
        Me.TypSB_OmschrijvingCTl.Size = New System.Drawing.Size(276, 22)
        Me.TypSB_OmschrijvingCTl.TabIndex = 7
        '
        'StandaardHBS
        '
        Me.StandaardHBS.DataMember = "StandaardH"
        Me.StandaardHBS.DataSource = Me.StandaardenDS1
        '
        'KL_NaamCtl
        '
        Me.KL_NaamCtl.BackColor = System.Drawing.Color.White
        Me.KL_NaamCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StandaardHBS, "KL_Naam", True))
        Me.KL_NaamCtl.fieldLength = 0
        Me.KL_NaamCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.KL_NaamCtl.forceUppercase = True
        Me.KL_NaamCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_NaamCtl.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.KL_NaamCtl.lIsSearch = False
        Me.KL_NaamCtl.Location = New System.Drawing.Point(168, 4)
        Me.KL_NaamCtl.Name = "KL_NaamCtl"
        Me.KL_NaamCtl.nIO = b040.IOValues.IOAlwaysDisable
        Me.KL_NaamCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_NaamCtl.Size = New System.Drawing.Size(217, 21)
        Me.KL_NaamCtl.TabIndex = 6
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase3.Location = New System.Drawing.Point(4, 57)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(59, 16)
        Me.LblBase3.TabIndex = 5
        Me.LblBase3.Text = "Standaard"
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase2.Location = New System.Drawing.Point(4, 31)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(83, 16)
        Me.LblBase2.TabIndex = 3
        Me.LblBase2.Text = "Type (1, 2 of 3)"
        '
        'Sth_TypeCtl
        '
        Me.Sth_TypeCtl.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Sth_TypeCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StandaardHBS, "sth_Type", True))
        Me.Sth_TypeCtl.fieldLength = 0
        Me.Sth_TypeCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Sth_TypeCtl.forceUppercase = True
        Me.Sth_TypeCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Sth_TypeCtl.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.Sth_TypeCtl.lIsSearch = False
        Me.Sth_TypeCtl.Location = New System.Drawing.Point(109, 27)
        Me.Sth_TypeCtl.Name = "Sth_TypeCtl"
        Me.Sth_TypeCtl.nIO = b040.IOValues.IOKeyEntryEnable
        Me.Sth_TypeCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Sth_TypeCtl.Size = New System.Drawing.Size(275, 21)
        Me.Sth_TypeCtl.TabIndex = 2
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(4, 8)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(33, 16)
        Me.LblBase1.TabIndex = 1
        Me.LblBase1.Text = "Klant"
        '
        'KL_NummerCtl
        '
        Me.KL_NummerCtl.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.KL_NummerCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StandaardHBS, "KL_Nummer", True))
        Me.KL_NummerCtl.fieldLength = 0
        Me.KL_NummerCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.KL_NummerCtl.forceUppercase = True
        Me.KL_NummerCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_NummerCtl.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.KL_NummerCtl.lIsSearch = False
        Me.KL_NummerCtl.Location = New System.Drawing.Point(109, 4)
        Me.KL_NummerCtl.Name = "KL_NummerCtl"
        Me.KL_NummerCtl.nIO = b040.IOValues.IOKeyEntryEnable
        Me.KL_NummerCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_NummerCtl.Size = New System.Drawing.Size(60, 21)
        Me.KL_NummerCtl.TabIndex = 1
        '
        'CloseBtn
        '
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseBtn.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.CloseBtn.Image = CType(resources.GetObject("CloseBtn.Image"), System.Drawing.Image)
        Me.CloseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CloseBtn.Location = New System.Drawing.Point(514, 586)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.nIO = b040.IOValues.IOAlwaysEnable
        Me.CloseBtn.Size = New System.Drawing.Size(75, 23)
        Me.CloseBtn.TabIndex = 24
        Me.CloseBtn.Text = "Sluit"
        Me.CloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CloseBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'StandaardHTableAdapter1
        '
        Me.StandaardHTableAdapter1.ClearBeforeFill = True
        '
        'STandaardDTableAdapter
        '
        Me.STandaardDTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ArtikelTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.KlantenTableAdapter = Nothing
        Me.TableAdapterManager.STandaardDTableAdapter = Nothing
        Me.TableAdapterManager.StandaardHTableAdapter = Nothing
        Me.TableAdapterManager.TypeStBEstTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = b040.StandaardenDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'deleteButton
        '
        Me.deleteButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.deleteButton.Image = CType(resources.GetObject("deleteButton.Image"), System.Drawing.Image)
        Me.deleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.deleteButton.Location = New System.Drawing.Point(395, 586)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.deleteButton.Size = New System.Drawing.Size(118, 23)
        Me.deleteButton.TabIndex = 25
        Me.deleteButton.Text = "Verwijder (F4)"
        Me.deleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'StandaardenFrm
        '
        Me.CancelButton = Me.CloseBtn
        Me.ClientSize = New System.Drawing.Size(591, 611)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.PnlBase1)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.GrdBase1)
        Me.KeyPreview = True
        Me.Name = "StandaardenFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Standaard"
        CType(Me.GrdBase1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STandaardDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StandaardenDS1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        CType(Me.StandaardHBS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StandaardHTableAdapter1 As b040.StandaardenDSTableAdapters.StandaardHTableAdapter
    Friend WithEvents StandaardenDS1 As b040.StandaardenDS
    Friend WithEvents STandaardDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents STandaardDTableAdapter As b040.StandaardenDSTableAdapters.STandaardDTableAdapter
    Friend WithEvents TableAdapterManager As b040.StandaardenDSTableAdapters.TableAdapterManager
    Friend WithEvents GrdBase1 As b040.grdBase
    Friend WithEvents SaveButton As b040.btnBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents KL_NummerCtl As b040.txtBase
    Friend WithEvents LblBase3 As b040.lblBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents Sth_TypeCtl As b040.txtBase
    Friend WithEvents CloseBtn As b040.btnBase
    Friend WithEvents KL_NaamCtl As b040.txtBase
    Friend WithEvents StandaardHBS As System.Windows.Forms.BindingSource
    Friend WithEvents TypSB_OmschrijvingCTl As b040.cboBase
    Friend WithEvents ArtNrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdArtOmschrijvingDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdHoeveelheidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdTourDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deleteButton As b040.btnBase
    Friend WithEvents Art_NrCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents std_ArtOmschrijvingCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents std_HoeveelheidCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Eenh_HoevInvoerCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents std_TourCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SnijdenCol As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents std_Snijden As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents StdidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdsthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StdArtikelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Art_Snijden As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents telefoonLabel As System.Windows.Forms.Label
    Friend WithEvents typeKlantLabel As System.Windows.Forms.Label

End Class

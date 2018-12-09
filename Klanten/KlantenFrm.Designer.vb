<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KlantenFrm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KlantenFrm))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BS = New System.Windows.Forms.BindingSource(Me.components)
        Me.KlantenDS = New b040.KlantenDS()
        Me.AdresBS = New System.Windows.Forms.BindingSource(Me.components)
        Me.KlantenKortingBS = New System.Windows.Forms.BindingSource(Me.components)
        Me.KlantenCRUD = New b040.KlantenDSTableAdapters.KlantenCRUD()
        Me.TableAdapterManager = New b040.KlantenDSTableAdapters.TableAdapterManager()
        Me.KlantAdresCRUD = New b040.KlantenDSTableAdapters.KlantAdresCRUD()
        Me.KLantenKlantenKortingCRUD = New b040.KlantenDSTableAdapters.KLantenKlantenKortingCRUD()
        Me.BestelDS1 = New b040.BestelDS()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PnlBase11 = New b040.pnlBase()
        Me.AnnuleerKlantenKortingButton = New b040.btnBase()
        Me.LblBase21 = New b040.lblBase()
        Me.KlantenKortingG = New b040.grdBase()
        Me.PnlBase8 = New b040.pnlBase()
        Me.KL_Korting = New b040.txtBaseNumeric()
        Me.LblBase8 = New b040.lblBase()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.AdresG = New b040.grdBase()
        Me.adresColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.postnrColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gemeenteColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.landColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefoonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.factColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AdridDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdrKlantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PnlBase7 = New b040.pnlBase()
        Me.TxtBaseMultiline1 = New b040.txtBaseMultiline()
        Me.PnlBase4 = New b040.pnlBase()
        Me.laatsteBestellingBehoudenLabel = New b040.lblBase()
        Me.laatstebestellingBehoudenCheckbox = New b040.checkboxBase()
        Me.Bed_naam = New b040.cboBase()
        Me.KL_Komthalen = New b040.checkboxBase()
        Me.LblBase27 = New b040.lblBase()
        Me.LblBase19 = New b040.lblBase()
        Me.PnlBase3 = New b040.pnlBase()
        Me.LblBase20 = New b040.lblBase()
        Me.KL_Actief = New b040.checkboxBase()
        Me.KL_Code = New b040.txtBase()
        Me.LblBase2 = New b040.lblBase()
        Me.PnlBase2 = New b040.pnlBase()
        Me.KL_Fax = New b040.txtBase()
        Me.LblBase13 = New b040.lblBase()
        Me.LblBase18 = New b040.lblBase()
        Me.LblBase16 = New b040.lblBase()
        Me.land = New b040.txtBase()
        Me.LblBase11 = New b040.lblBase()
        Me.adres = New b040.txtBase()
        Me.LblBase14 = New b040.lblBase()
        Me.postnr = New b040.txtBase()
        Me.gemeente = New b040.txtBase()
        Me.LblBase15 = New b040.lblBase()
        Me.Telefoon = New b040.txtBase()
        Me.LblBase5 = New b040.lblBase()
        Me.KL_EMail = New b040.txtBase()
        Me.KL_Telefoon2 = New b040.txtBase()
        Me.KL_Titel = New b040.txtBase()
        Me.KL_GSM = New b040.txtBase()
        Me.KL_Voornaam = New b040.txtBase()
        Me.LblBase9 = New b040.lblBase()
        Me.LblBase7 = New b040.lblBase()
        Me.LblBase6 = New b040.lblBase()
        Me.LblBase4 = New b040.lblBase()
        Me.LblBase3 = New b040.lblBase()
        Me.KL_Naam = New b040.txtBase()
        Me.PnlBase1 = New b040.pnlBase()
        Me.LblBase17 = New b040.lblBase()
        Me.typeFacturatieControl = New b040.checkedListboxBase()
        Me.LblBase1 = New b040.lblBase()
        Me.KL_Nummer = New b040.txtBase()
        Me.PnlBase6 = New b040.pnlBase()
        Me.KL_Automatisch = New b040.checkboxBase()
        Me.LblBase24 = New b040.lblBase()
        Me.KL_Voldaan = New b040.checkboxBase()
        Me.LblBase22 = New b040.lblBase()
        Me.kl_btw = New b040.txtBase()
        Me.LblBase23 = New b040.lblBase()
        Me.BTW_Omschrijving = New b040.checkedListboxBase()
        Me.LblBase12 = New b040.lblBase()
        Me.Zoek = New b040.cboBase()
        Me.BedieningBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.B040_beDataSet1 = New b040.b040_beDataSet1()
        Me.TpgBase1 = New b040.tpgBase()
        Me.B040_beDataSet = New b040.b040_beDataSet()
        Me.B040beDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BedieningDS = New b040.BedieningDS()
        Me.BedieningDSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BedieningTableAdapter = New b040.b040_beDataSet1TableAdapters.BedieningTableAdapter()
        Me.Title = New b040.lblBase()
        Me.CloseBtn = New b040.btnBase()
        Me.zoekButton = New b040.btnBase()
        Me.SaveButton = New b040.btnBase()
        Me.BestelDS2 = New b040.BestelDS()
        Me.colArtSearch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Art_Omschrijving = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KKKortingDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KKIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KKArtikelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Art_Nr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.BS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KlantenDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdresBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KlantenKortingBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BestelDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.PnlBase11.SuspendLayout()
        CType(Me.KlantenKortingG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBase8.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.AdresG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.PnlBase7.SuspendLayout()
        Me.PnlBase4.SuspendLayout()
        Me.PnlBase3.SuspendLayout()
        Me.PnlBase2.SuspendLayout()
        Me.PnlBase1.SuspendLayout()
        Me.PnlBase6.SuspendLayout()
        CType(Me.BedieningBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B040_beDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpgBase1.SuspendLayout()
        CType(Me.B040_beDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B040beDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BedieningDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BedieningDSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BestelDS2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BS
        '
        Me.BS.DataMember = "Klanten"
        Me.BS.DataSource = Me.KlantenDS
        '
        'KlantenDS
        '
        Me.KlantenDS.DataSetName = "KlantenDS"
        Me.KlantenDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AdresBS
        '
        Me.AdresBS.DataMember = "Adres"
        Me.AdresBS.DataSource = Me.KlantenDS
        '
        'KlantenKortingBS
        '
        Me.KlantenKortingBS.DataMember = "KlantenKorting"
        Me.KlantenKortingBS.DataSource = Me.KlantenDS
        '
        'KlantenCRUD
        '
        Me.KlantenCRUD.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.KlantAdresCRUD = Nothing
        Me.TableAdapterManager.KlantenCRUD = Me.KlantenCRUD
        Me.TableAdapterManager.KLantenKlantenKortingCRUD = Nothing
        Me.TableAdapterManager.UpdateOrder = b040.KlantenDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'KlantAdresCRUD
        '
        Me.KlantAdresCRUD.ClearBeforeFill = True
        '
        'KLantenKlantenKortingCRUD
        '
        Me.KLantenKlantenKortingCRUD.ClearBeforeFill = True
        '
        'BestelDS1
        '
        Me.BestelDS1.DataSetName = "BestelDS"
        Me.BestelDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PnlBase11)
        Me.TabPage2.Controls.Add(Me.PnlBase8)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(752, 420)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Voorwaarden"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PnlBase11
        '
        Me.PnlBase11.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlBase11.BackColor = System.Drawing.Color.Silver
        Me.PnlBase11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase11.Controls.Add(Me.AnnuleerKlantenKortingButton)
        Me.PnlBase11.Controls.Add(Me.LblBase21)
        Me.PnlBase11.Controls.Add(Me.KlantenKortingG)
        Me.PnlBase11.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.PnlBase11.Location = New System.Drawing.Point(239, 16)
        Me.PnlBase11.Name = "PnlBase11"
        Me.PnlBase11.Size = New System.Drawing.Size(507, 389)
        Me.PnlBase11.TabIndex = 33
        '
        'AnnuleerKlantenKortingButton
        '
        Me.AnnuleerKlantenKortingButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.AnnuleerKlantenKortingButton.Image = Global.b040.My.Resources.Resources.DELETE
        Me.AnnuleerKlantenKortingButton.Location = New System.Drawing.Point(280, 357)
        Me.AnnuleerKlantenKortingButton.Name = "AnnuleerKlantenKortingButton"
        Me.AnnuleerKlantenKortingButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.AnnuleerKlantenKortingButton.Size = New System.Drawing.Size(213, 23)
        Me.AnnuleerKlantenKortingButton.TabIndex = 30
        Me.AnnuleerKlantenKortingButton.Text = "Annuleer Klanten Korting"
        Me.AnnuleerKlantenKortingButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AnnuleerKlantenKortingButton.UseVisualStyleBackColor = True
        '
        'LblBase21
        '
        Me.LblBase21.AutoSize = True
        Me.LblBase21.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase21.Location = New System.Drawing.Point(5, 5)
        Me.LblBase21.Name = "LblBase21"
        Me.LblBase21.Size = New System.Drawing.Size(140, 18)
        Me.LblBase21.TabIndex = 29
        Me.LblBase21.Text = "Kortingen per Artikel"
        '
        'KlantenKortingG
        '
        Me.KlantenKortingG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KlantenKortingG.AutoGenerateColumns = False
        Me.KlantenKortingG.BackgroundColor = System.Drawing.Color.White
        Me.KlantenKortingG.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.KlantenKortingG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.KlantenKortingG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.KlantenKortingG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colArtSearch, Me.Art_Omschrijving, Me.KKKortingDataGridViewTextBoxColumn, Me.KKIDDataGridViewTextBoxColumn, Me.KKArtikelDataGridViewTextBoxColumn, Me.Art_Nr})
        Me.KlantenKortingG.DataSource = Me.KlantenKortingBS
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.KlantenKortingG.DefaultCellStyle = DataGridViewCellStyle3
        Me.KlantenKortingG.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.KlantenKortingG.GridColor = System.Drawing.Color.LightGray
        Me.KlantenKortingG.lKeepHighlightOnLostFocus = False
        Me.KlantenKortingG.Location = New System.Drawing.Point(5, 22)
        Me.KlantenKortingG.Name = "KlantenKortingG"
        Me.KlantenKortingG.nIO = b040.IOValues.IORecordEntryEnable
        Me.KlantenKortingG.RowHeadersVisible = False
        Me.KlantenKortingG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.KlantenKortingG.Size = New System.Drawing.Size(491, 329)
        Me.KlantenKortingG.TabIndex = 21
        '
        'PnlBase8
        '
        Me.PnlBase8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PnlBase8.BackColor = System.Drawing.Color.Silver
        Me.PnlBase8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase8.Controls.Add(Me.KL_Korting)
        Me.PnlBase8.Controls.Add(Me.LblBase8)
        Me.PnlBase8.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.PnlBase8.Location = New System.Drawing.Point(4, 16)
        Me.PnlBase8.Name = "PnlBase8"
        Me.PnlBase8.Size = New System.Drawing.Size(233, 388)
        Me.PnlBase8.TabIndex = 32
        '
        'KL_Korting
        '
        Me.KL_Korting.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton
        Me.KL_Korting.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_Korting", True))
        Me.KL_Korting.fieldLength = 0
        Me.KL_Korting.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_Korting.forceUppercase = True
        Me.KL_Korting.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Korting.lIsSearch = False
        Me.KL_Korting.Location = New System.Drawing.Point(150, 3)
        Me.KL_Korting.Name = "KL_Korting"
        Me.KL_Korting.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Korting.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Korting.Size = New System.Drawing.Size(62, 31)
        Me.KL_Korting.TabIndex = 29
        Me.KL_Korting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblBase8
        '
        Me.LblBase8.AutoSize = True
        Me.LblBase8.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase8.Location = New System.Drawing.Point(13, 5)
        Me.LblBase8.Name = "LblBase8"
        Me.LblBase8.Size = New System.Drawing.Size(142, 18)
        Me.LblBase8.TabIndex = 28
        Me.LblBase8.Text = "Algemene Korting (%)"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.AdresG)
        Me.TabPage3.Location = New System.Drawing.Point(4, 27)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(752, 420)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Adressen"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'AdresG
        '
        Me.AdresG.AllowUserToOrderColumns = True
        Me.AdresG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdresG.AutoGenerateColumns = False
        Me.AdresG.BackgroundColor = System.Drawing.Color.White
        Me.AdresG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AdresG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.AdresG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AdresG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.adresColumn, Me.postnrColumn, Me.gemeenteColumn, Me.landColumn, Me.telefoonColumn, Me.factColumn, Me.AdridDataGridViewTextBoxColumn, Me.AdrKlantDataGridViewTextBoxColumn})
        Me.AdresG.DataSource = Me.AdresBS
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AdresG.DefaultCellStyle = DataGridViewCellStyle5
        Me.AdresG.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.AdresG.GridColor = System.Drawing.Color.LightGray
        Me.AdresG.lKeepHighlightOnLostFocus = False
        Me.AdresG.Location = New System.Drawing.Point(0, 3)
        Me.AdresG.Name = "AdresG"
        Me.AdresG.nIO = b040.IOValues.IORecordEntryEnable
        Me.AdresG.RowHeadersVisible = False
        Me.AdresG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.AdresG.Size = New System.Drawing.Size(744, 90)
        Me.AdresG.TabIndex = 19
        '
        'adresColumn
        '
        Me.adresColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.adresColumn.DataPropertyName = "Adr_Adres"
        Me.adresColumn.FillWeight = 4.0!
        Me.adresColumn.HeaderText = "Adres"
        Me.adresColumn.Name = "adresColumn"
        '
        'postnrColumn
        '
        Me.postnrColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.postnrColumn.DataPropertyName = "Adr_PostNummer"
        Me.postnrColumn.FillWeight = 8.0!
        Me.postnrColumn.HeaderText = "PostNr"
        Me.postnrColumn.Name = "postnrColumn"
        Me.postnrColumn.Width = 78
        '
        'gemeenteColumn
        '
        Me.gemeenteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gemeenteColumn.DataPropertyName = "Adr_Gemeente"
        Me.gemeenteColumn.FillWeight = 2.0!
        Me.gemeenteColumn.HeaderText = "Gemeente"
        Me.gemeenteColumn.Name = "gemeenteColumn"
        '
        'landColumn
        '
        Me.landColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.landColumn.DataPropertyName = "Adr_Land"
        Me.landColumn.FillWeight = 1.0!
        Me.landColumn.HeaderText = "Land"
        Me.landColumn.Name = "landColumn"
        '
        'telefoonColumn
        '
        Me.telefoonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.telefoonColumn.DataPropertyName = "Adr_Telefoon"
        Me.telefoonColumn.FillWeight = 2.0!
        Me.telefoonColumn.HeaderText = "Telefoon"
        Me.telefoonColumn.Name = "telefoonColumn"
        '
        'factColumn
        '
        Me.factColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.factColumn.DataPropertyName = "Adr_Facturatie"
        Me.factColumn.FalseValue = "false"
        Me.factColumn.FillWeight = 20.0!
        Me.factColumn.HeaderText = "Fact"
        Me.factColumn.Name = "factColumn"
        Me.factColumn.TrueValue = "true"
        Me.factColumn.Width = 41
        '
        'AdridDataGridViewTextBoxColumn
        '
        Me.AdridDataGridViewTextBoxColumn.DataPropertyName = "Adr_id"
        Me.AdridDataGridViewTextBoxColumn.HeaderText = "Adr_id"
        Me.AdridDataGridViewTextBoxColumn.Name = "AdridDataGridViewTextBoxColumn"
        Me.AdridDataGridViewTextBoxColumn.Visible = False
        '
        'AdrKlantDataGridViewTextBoxColumn
        '
        Me.AdrKlantDataGridViewTextBoxColumn.DataPropertyName = "Adr_Klant"
        Me.AdrKlantDataGridViewTextBoxColumn.HeaderText = "Adr_Klant"
        Me.AdrKlantDataGridViewTextBoxColumn.Name = "AdrKlantDataGridViewTextBoxColumn"
        Me.AdrKlantDataGridViewTextBoxColumn.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PnlBase7)
        Me.TabPage1.Controls.Add(Me.PnlBase4)
        Me.TabPage1.Controls.Add(Me.PnlBase3)
        Me.TabPage1.Controls.Add(Me.PnlBase2)
        Me.TabPage1.Controls.Add(Me.PnlBase1)
        Me.TabPage1.Controls.Add(Me.PnlBase6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(752, 420)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Klant"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PnlBase7
        '
        Me.PnlBase7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PnlBase7.BackColor = System.Drawing.Color.Silver
        Me.PnlBase7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase7.Controls.Add(Me.TxtBaseMultiline1)
        Me.PnlBase7.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.PnlBase7.Location = New System.Drawing.Point(390, 317)
        Me.PnlBase7.Name = "PnlBase7"
        Me.PnlBase7.Size = New System.Drawing.Size(356, 106)
        Me.PnlBase7.TabIndex = 5
        '
        'TxtBaseMultiline1
        '
        Me.TxtBaseMultiline1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "kl_info", True))
        Me.TxtBaseMultiline1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtBaseMultiline1.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtBaseMultiline1.Location = New System.Drawing.Point(9, 4)
        Me.TxtBaseMultiline1.Multiline = True
        Me.TxtBaseMultiline1.Name = "TxtBaseMultiline1"
        Me.TxtBaseMultiline1.nIO = b040.IOValues.IORecordEntryEnable
        Me.TxtBaseMultiline1.Size = New System.Drawing.Size(339, 87)
        Me.TxtBaseMultiline1.TabIndex = 0
        '
        'PnlBase4
        '
        Me.PnlBase4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PnlBase4.BackColor = System.Drawing.Color.Silver
        Me.PnlBase4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase4.Controls.Add(Me.laatsteBestellingBehoudenLabel)
        Me.PnlBase4.Controls.Add(Me.laatstebestellingBehoudenCheckbox)
        Me.PnlBase4.Controls.Add(Me.Bed_naam)
        Me.PnlBase4.Controls.Add(Me.KL_Komthalen)
        Me.PnlBase4.Controls.Add(Me.LblBase27)
        Me.PnlBase4.Controls.Add(Me.LblBase19)
        Me.PnlBase4.Location = New System.Drawing.Point(390, 248)
        Me.PnlBase4.Name = "PnlBase4"
        Me.PnlBase4.Size = New System.Drawing.Size(356, 68)
        Me.PnlBase4.TabIndex = 4
        '
        'laatsteBestellingBehoudenLabel
        '
        Me.laatsteBestellingBehoudenLabel.AutoSize = True
        Me.laatsteBestellingBehoudenLabel.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.laatsteBestellingBehoudenLabel.Location = New System.Drawing.Point(127, 40)
        Me.laatsteBestellingBehoudenLabel.Name = "laatsteBestellingBehoudenLabel"
        Me.laatsteBestellingBehoudenLabel.Size = New System.Drawing.Size(188, 18)
        Me.laatsteBestellingBehoudenLabel.TabIndex = 42
        Me.laatsteBestellingBehoudenLabel.Text = "Laatste Bestelling Behouden"
        '
        'laatstebestellingBehoudenCheckbox
        '
        Me.laatstebestellingBehoudenCheckbox.BackColor = System.Drawing.SystemColors.Window
        Me.laatstebestellingBehoudenCheckbox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BS, "kl_laatsteBestellingBehouden", True))
        Me.laatstebestellingBehoudenCheckbox.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.laatstebestellingBehoudenCheckbox.ForeColor = System.Drawing.Color.DarkBlue
        Me.laatstebestellingBehoudenCheckbox.Location = New System.Drawing.Point(281, 37)
        Me.laatstebestellingBehoudenCheckbox.Name = "laatstebestellingBehoudenCheckbox"
        Me.laatstebestellingBehoudenCheckbox.nIO = b040.IOValues.IORecordEntryEnable
        Me.laatstebestellingBehoudenCheckbox.Size = New System.Drawing.Size(21, 21)
        Me.laatstebestellingBehoudenCheckbox.TabIndex = 2
        Me.laatstebestellingBehoudenCheckbox.UseVisualStyleBackColor = False
        '
        'Bed_naam
        '
        Me.Bed_naam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bed_naam.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "BEd_naam", True))
        Me.Bed_naam.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Bed_naam.ForeColor = System.Drawing.Color.DarkBlue
        Me.Bed_naam.FormattingEnabled = True
        Me.Bed_naam.Location = New System.Drawing.Point(84, 0)
        Me.Bed_naam.Name = "Bed_naam"
        Me.Bed_naam.nIO = b040.IOValues.IORecordEntryEnable
        Me.Bed_naam.setAutocomplete = False
        Me.Bed_naam.Size = New System.Drawing.Size(258, 34)
        Me.Bed_naam.TabIndex = 0
        '
        'KL_Komthalen
        '
        Me.KL_Komthalen.BackColor = System.Drawing.SystemColors.Window
        Me.KL_Komthalen.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BS, "KL_KomtHalen", True))
        Me.KL_Komthalen.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.KL_Komthalen.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Komthalen.Location = New System.Drawing.Point(85, 36)
        Me.KL_Komthalen.Name = "KL_Komthalen"
        Me.KL_Komthalen.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Komthalen.Size = New System.Drawing.Size(21, 21)
        Me.KL_Komthalen.TabIndex = 1
        Me.KL_Komthalen.UseVisualStyleBackColor = False
        '
        'LblBase27
        '
        Me.LblBase27.AutoSize = True
        Me.LblBase27.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase27.Location = New System.Drawing.Point(9, 8)
        Me.LblBase27.Name = "LblBase27"
        Me.LblBase27.Size = New System.Drawing.Size(71, 18)
        Me.LblBase27.TabIndex = 40
        Me.LblBase27.Text = "Bediening"
        '
        'LblBase19
        '
        Me.LblBase19.AutoSize = True
        Me.LblBase19.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase19.Location = New System.Drawing.Point(9, 38)
        Me.LblBase19.Name = "LblBase19"
        Me.LblBase19.Size = New System.Drawing.Size(79, 18)
        Me.LblBase19.TabIndex = 38
        Me.LblBase19.Text = "Komt halen"
        '
        'PnlBase3
        '
        Me.PnlBase3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PnlBase3.BackColor = System.Drawing.Color.Silver
        Me.PnlBase3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase3.Controls.Add(Me.LblBase20)
        Me.PnlBase3.Controls.Add(Me.KL_Actief)
        Me.PnlBase3.Controls.Add(Me.KL_Code)
        Me.PnlBase3.Controls.Add(Me.LblBase2)
        Me.PnlBase3.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.PnlBase3.Location = New System.Drawing.Point(390, 7)
        Me.PnlBase3.Name = "PnlBase3"
        Me.PnlBase3.Size = New System.Drawing.Size(356, 83)
        Me.PnlBase3.TabIndex = 2
        '
        'LblBase20
        '
        Me.LblBase20.AutoSize = True
        Me.LblBase20.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase20.Location = New System.Drawing.Point(9, 44)
        Me.LblBase20.Name = "LblBase20"
        Me.LblBase20.Size = New System.Drawing.Size(47, 18)
        Me.LblBase20.TabIndex = 39
        Me.LblBase20.Text = "Actief"
        '
        'KL_Actief
        '
        Me.KL_Actief.BackColor = System.Drawing.SystemColors.Window
        Me.KL_Actief.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BS, "KL_Actief", True))
        Me.KL_Actief.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.KL_Actief.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Actief.Location = New System.Drawing.Point(85, 42)
        Me.KL_Actief.Name = "KL_Actief"
        Me.KL_Actief.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Actief.Size = New System.Drawing.Size(21, 21)
        Me.KL_Actief.TabIndex = 36
        Me.KL_Actief.UseVisualStyleBackColor = False
        '
        'KL_Code
        '
        Me.KL_Code.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_Code.AsciiOnly = True
        Me.KL_Code.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_Code", True))
        Me.KL_Code.fieldLength = 0
        Me.KL_Code.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_Code.forceUppercase = True
        Me.KL_Code.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Code.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.KL_Code.lIsSearch = False
        Me.KL_Code.Location = New System.Drawing.Point(84, 8)
        Me.KL_Code.Name = "KL_Code"
        Me.KL_Code.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Code.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Code.Size = New System.Drawing.Size(258, 31)
        Me.KL_Code.TabIndex = 34
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase2.Location = New System.Drawing.Point(9, 11)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(74, 18)
        Me.LblBase2.TabIndex = 35
        Me.LblBase2.Text = "Alphacode"
        '
        'PnlBase2
        '
        Me.PnlBase2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlBase2.BackColor = System.Drawing.Color.Silver
        Me.PnlBase2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase2.Controls.Add(Me.KL_Fax)
        Me.PnlBase2.Controls.Add(Me.LblBase13)
        Me.PnlBase2.Controls.Add(Me.LblBase18)
        Me.PnlBase2.Controls.Add(Me.LblBase16)
        Me.PnlBase2.Controls.Add(Me.land)
        Me.PnlBase2.Controls.Add(Me.LblBase11)
        Me.PnlBase2.Controls.Add(Me.adres)
        Me.PnlBase2.Controls.Add(Me.LblBase14)
        Me.PnlBase2.Controls.Add(Me.postnr)
        Me.PnlBase2.Controls.Add(Me.gemeente)
        Me.PnlBase2.Controls.Add(Me.LblBase15)
        Me.PnlBase2.Controls.Add(Me.Telefoon)
        Me.PnlBase2.Controls.Add(Me.LblBase5)
        Me.PnlBase2.Controls.Add(Me.KL_EMail)
        Me.PnlBase2.Controls.Add(Me.KL_Telefoon2)
        Me.PnlBase2.Controls.Add(Me.KL_Titel)
        Me.PnlBase2.Controls.Add(Me.KL_GSM)
        Me.PnlBase2.Controls.Add(Me.KL_Voornaam)
        Me.PnlBase2.Controls.Add(Me.LblBase9)
        Me.PnlBase2.Controls.Add(Me.LblBase7)
        Me.PnlBase2.Controls.Add(Me.LblBase6)
        Me.PnlBase2.Controls.Add(Me.LblBase4)
        Me.PnlBase2.Controls.Add(Me.LblBase3)
        Me.PnlBase2.Controls.Add(Me.KL_Naam)
        Me.PnlBase2.Location = New System.Drawing.Point(6, 92)
        Me.PnlBase2.Name = "PnlBase2"
        Me.PnlBase2.Size = New System.Drawing.Size(383, 331)
        Me.PnlBase2.TabIndex = 1
        '
        'KL_Fax
        '
        Me.KL_Fax.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_Fax.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_Fax", True))
        Me.KL_Fax.fieldLength = 0
        Me.KL_Fax.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_Fax.forceUppercase = True
        Me.KL_Fax.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Fax.lIsSearch = False
        Me.KL_Fax.Location = New System.Drawing.Point(87, 214)
        Me.KL_Fax.Name = "KL_Fax"
        Me.KL_Fax.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Fax.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Fax.Size = New System.Drawing.Size(284, 31)
        Me.KL_Fax.TabIndex = 8
        '
        'LblBase13
        '
        Me.LblBase13.AutoSize = True
        Me.LblBase13.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase13.Location = New System.Drawing.Point(9, 217)
        Me.LblBase13.Name = "LblBase13"
        Me.LblBase13.Size = New System.Drawing.Size(29, 18)
        Me.LblBase13.TabIndex = 25
        Me.LblBase13.Text = "Fax"
        '
        'LblBase18
        '
        Me.LblBase18.AutoSize = True
        Me.LblBase18.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase18.Location = New System.Drawing.Point(9, 140)
        Me.LblBase18.Name = "LblBase18"
        Me.LblBase18.Size = New System.Drawing.Size(48, 18)
        Me.LblBase18.TabIndex = 24
        Me.LblBase18.Text = "Postnr"
        '
        'LblBase16
        '
        Me.LblBase16.AutoSize = True
        Me.LblBase16.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase16.Location = New System.Drawing.Point(9, 192)
        Me.LblBase16.Name = "LblBase16"
        Me.LblBase16.Size = New System.Drawing.Size(38, 18)
        Me.LblBase16.TabIndex = 23
        Me.LblBase16.Text = "Land"
        '
        'land
        '
        Me.land.AllowDrop = True
        Me.land.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.land.fieldLength = 0
        Me.land.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.land.forceUppercase = False
        Me.land.ForeColor = System.Drawing.Color.DarkBlue
        Me.land.lIsSearch = False
        Me.land.Location = New System.Drawing.Point(87, 188)
        Me.land.Name = "land"
        Me.land.nIO = b040.IOValues.IORecordEntryEnable
        Me.land.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.land.Size = New System.Drawing.Size(284, 31)
        Me.land.TabIndex = 7
        '
        'LblBase11
        '
        Me.LblBase11.AutoSize = True
        Me.LblBase11.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase11.Location = New System.Drawing.Point(9, 166)
        Me.LblBase11.Name = "LblBase11"
        Me.LblBase11.Size = New System.Drawing.Size(74, 18)
        Me.LblBase11.TabIndex = 21
        Me.LblBase11.Text = "Gemeente"
        '
        'adres
        '
        Me.adres.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adres.AsciiOnly = True
        Me.adres.fieldLength = 0
        Me.adres.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adres.forceUppercase = True
        Me.adres.ForeColor = System.Drawing.Color.DarkBlue
        Me.adres.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.adres.lIsSearch = False
        Me.adres.Location = New System.Drawing.Point(87, 110)
        Me.adres.Name = "adres"
        Me.adres.nIO = b040.IOValues.IORecordEntryEnable
        Me.adres.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.adres.Size = New System.Drawing.Size(284, 31)
        Me.adres.TabIndex = 4
        '
        'LblBase14
        '
        Me.LblBase14.AutoSize = True
        Me.LblBase14.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase14.Location = New System.Drawing.Point(9, 114)
        Me.LblBase14.Name = "LblBase14"
        Me.LblBase14.Size = New System.Drawing.Size(44, 18)
        Me.LblBase14.TabIndex = 20
        Me.LblBase14.Text = "Adres"
        '
        'postnr
        '
        Me.postnr.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.postnr.fieldLength = 0
        Me.postnr.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.postnr.forceUppercase = False
        Me.postnr.ForeColor = System.Drawing.Color.DarkBlue
        Me.postnr.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.postnr.lIsSearch = False
        Me.postnr.Location = New System.Drawing.Point(87, 136)
        Me.postnr.Name = "postnr"
        Me.postnr.nIO = b040.IOValues.IORecordEntryEnable
        Me.postnr.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.postnr.Size = New System.Drawing.Size(284, 31)
        Me.postnr.TabIndex = 5
        '
        'gemeente
        '
        Me.gemeente.AllowDrop = True
        Me.gemeente.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gemeente.fieldLength = 0
        Me.gemeente.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gemeente.forceUppercase = False
        Me.gemeente.ForeColor = System.Drawing.Color.DarkBlue
        Me.gemeente.lIsSearch = False
        Me.gemeente.Location = New System.Drawing.Point(87, 162)
        Me.gemeente.Name = "gemeente"
        Me.gemeente.nIO = b040.IOValues.IORecordEntryEnable
        Me.gemeente.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.gemeente.Size = New System.Drawing.Size(284, 31)
        Me.gemeente.TabIndex = 6
        '
        'LblBase15
        '
        Me.LblBase15.AutoSize = True
        Me.LblBase15.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase15.Location = New System.Drawing.Point(9, 88)
        Me.LblBase15.Name = "LblBase15"
        Me.LblBase15.Size = New System.Drawing.Size(62, 18)
        Me.LblBase15.TabIndex = 16
        Me.LblBase15.Text = "Telefoon"
        '
        'Telefoon
        '
        Me.Telefoon.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Telefoon.fieldLength = 0
        Me.Telefoon.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Telefoon.forceUppercase = False
        Me.Telefoon.ForeColor = System.Drawing.Color.DarkBlue
        Me.Telefoon.lIsSearch = False
        Me.Telefoon.Location = New System.Drawing.Point(87, 84)
        Me.Telefoon.Name = "Telefoon"
        Me.Telefoon.nIO = b040.IOValues.IORecordEntryEnable
        Me.Telefoon.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Telefoon.Size = New System.Drawing.Size(284, 31)
        Me.Telefoon.TabIndex = 3
        '
        'LblBase5
        '
        Me.LblBase5.AutoSize = True
        Me.LblBase5.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase5.Location = New System.Drawing.Point(9, 62)
        Me.LblBase5.Name = "LblBase5"
        Me.LblBase5.Size = New System.Drawing.Size(70, 18)
        Me.LblBase5.TabIndex = 14
        Me.LblBase5.Text = "Voornaam"
        '
        'KL_EMail
        '
        Me.KL_EMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_EMail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_EMail", True))
        Me.KL_EMail.fieldLength = 0
        Me.KL_EMail.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_EMail.forceUppercase = False
        Me.KL_EMail.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_EMail.lIsSearch = False
        Me.KL_EMail.Location = New System.Drawing.Point(87, 292)
        Me.KL_EMail.Name = "KL_EMail"
        Me.KL_EMail.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_EMail.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_EMail.Size = New System.Drawing.Size(284, 31)
        Me.KL_EMail.TabIndex = 11
        '
        'KL_Telefoon2
        '
        Me.KL_Telefoon2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_Telefoon2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_Telefoon2", True))
        Me.KL_Telefoon2.fieldLength = 0
        Me.KL_Telefoon2.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_Telefoon2.forceUppercase = True
        Me.KL_Telefoon2.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Telefoon2.lIsSearch = False
        Me.KL_Telefoon2.Location = New System.Drawing.Point(87, 240)
        Me.KL_Telefoon2.Name = "KL_Telefoon2"
        Me.KL_Telefoon2.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Telefoon2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Telefoon2.Size = New System.Drawing.Size(284, 31)
        Me.KL_Telefoon2.TabIndex = 9
        '
        'KL_Titel
        '
        Me.KL_Titel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_Titel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_Titel", True))
        Me.KL_Titel.fieldLength = 0
        Me.KL_Titel.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_Titel.forceUppercase = False
        Me.KL_Titel.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Titel.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.KL_Titel.lIsSearch = False
        Me.KL_Titel.Location = New System.Drawing.Point(87, 32)
        Me.KL_Titel.Name = "KL_Titel"
        Me.KL_Titel.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Titel.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Titel.Size = New System.Drawing.Size(284, 31)
        Me.KL_Titel.TabIndex = 1
        '
        'KL_GSM
        '
        Me.KL_GSM.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_GSM.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_GSM", True))
        Me.KL_GSM.fieldLength = 0
        Me.KL_GSM.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_GSM.forceUppercase = True
        Me.KL_GSM.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_GSM.lIsSearch = False
        Me.KL_GSM.Location = New System.Drawing.Point(87, 266)
        Me.KL_GSM.Name = "KL_GSM"
        Me.KL_GSM.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_GSM.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_GSM.Size = New System.Drawing.Size(284, 31)
        Me.KL_GSM.TabIndex = 10
        '
        'KL_Voornaam
        '
        Me.KL_Voornaam.AllowDrop = True
        Me.KL_Voornaam.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_Voornaam.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_Voornaam", True))
        Me.KL_Voornaam.fieldLength = 0
        Me.KL_Voornaam.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_Voornaam.forceUppercase = False
        Me.KL_Voornaam.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Voornaam.lIsSearch = False
        Me.KL_Voornaam.Location = New System.Drawing.Point(87, 58)
        Me.KL_Voornaam.Name = "KL_Voornaam"
        Me.KL_Voornaam.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Voornaam.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Voornaam.Size = New System.Drawing.Size(284, 31)
        Me.KL_Voornaam.TabIndex = 2
        '
        'LblBase9
        '
        Me.LblBase9.AutoSize = True
        Me.LblBase9.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase9.Location = New System.Drawing.Point(9, 293)
        Me.LblBase9.Name = "LblBase9"
        Me.LblBase9.Size = New System.Drawing.Size(41, 18)
        Me.LblBase9.TabIndex = 9
        Me.LblBase9.Text = "EMail"
        '
        'LblBase7
        '
        Me.LblBase7.AutoSize = True
        Me.LblBase7.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase7.Location = New System.Drawing.Point(9, 269)
        Me.LblBase7.Name = "LblBase7"
        Me.LblBase7.Size = New System.Drawing.Size(35, 18)
        Me.LblBase7.TabIndex = 7
        Me.LblBase7.Text = "GSM"
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase6.Location = New System.Drawing.Point(9, 244)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(83, 18)
        Me.LblBase6.TabIndex = 6
        Me.LblBase6.Text = "Telefoon (2)"
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase4.Location = New System.Drawing.Point(9, 36)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(36, 18)
        Me.LblBase4.TabIndex = 4
        Me.LblBase4.Text = "Titel"
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase3.Location = New System.Drawing.Point(9, 10)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(42, 18)
        Me.LblBase3.TabIndex = 3
        Me.LblBase3.Text = "Naam"
        '
        'KL_Naam
        '
        Me.KL_Naam.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_Naam.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_Naam", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.KL_Naam.fieldLength = 0
        Me.KL_Naam.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_Naam.forceUppercase = False
        Me.KL_Naam.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Naam.lIsSearch = False
        Me.KL_Naam.Location = New System.Drawing.Point(87, 6)
        Me.KL_Naam.Name = "KL_Naam"
        Me.KL_Naam.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Naam.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Naam.Size = New System.Drawing.Size(284, 31)
        Me.KL_Naam.TabIndex = 0
        '
        'PnlBase1
        '
        Me.PnlBase1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.LblBase17)
        Me.PnlBase1.Controls.Add(Me.typeFacturatieControl)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.KL_Nummer)
        Me.PnlBase1.Location = New System.Drawing.Point(6, 7)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(383, 83)
        Me.PnlBase1.TabIndex = 0
        '
        'LblBase17
        '
        Me.LblBase17.AutoSize = True
        Me.LblBase17.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase17.Location = New System.Drawing.Point(9, 31)
        Me.LblBase17.Name = "LblBase17"
        Me.LblBase17.Size = New System.Drawing.Size(37, 18)
        Me.LblBase17.TabIndex = 24
        Me.LblBase17.Text = "Type"
        '
        'typeFacturatieControl
        '
        Me.typeFacturatieControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.typeFacturatieControl.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.BS, "TYPF_OMSCHRIJVING", True))
        Me.typeFacturatieControl.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typeFacturatieControl.ForeColor = System.Drawing.Color.DarkBlue
        Me.typeFacturatieControl.FormattingEnabled = True
        Me.typeFacturatieControl.IntegralHeight = False
        Me.typeFacturatieControl.Location = New System.Drawing.Point(87, 31)
        Me.typeFacturatieControl.Name = "typeFacturatieControl"
        Me.typeFacturatieControl.nIO = b040.IOValues.IORecordEntryEnable
        Me.typeFacturatieControl.Size = New System.Drawing.Size(284, 46)
        Me.typeFacturatieControl.TabIndex = 1
        '
        'LblBase1
        '
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblBase1.Location = New System.Drawing.Point(9, 8)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(72, 19)
        Me.LblBase1.TabIndex = 1
        Me.LblBase1.Text = "Nummer"
        '
        'KL_Nummer
        '
        Me.KL_Nummer.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KL_Nummer.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_Nummer", True))
        Me.KL_Nummer.fieldLength = 0
        Me.KL_Nummer.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL_Nummer.forceUppercase = True
        Me.KL_Nummer.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Nummer.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.KL_Nummer.lIsSearch = False
        Me.KL_Nummer.Location = New System.Drawing.Point(87, 4)
        Me.KL_Nummer.Name = "KL_Nummer"
        Me.KL_Nummer.nIO = b040.IOValues.IOKeyEntryEnable
        Me.KL_Nummer.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Nummer.Size = New System.Drawing.Size(284, 31)
        Me.KL_Nummer.TabIndex = 0
        '
        'PnlBase6
        '
        Me.PnlBase6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PnlBase6.BackColor = System.Drawing.Color.Silver
        Me.PnlBase6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase6.Controls.Add(Me.KL_Automatisch)
        Me.PnlBase6.Controls.Add(Me.LblBase24)
        Me.PnlBase6.Controls.Add(Me.KL_Voldaan)
        Me.PnlBase6.Controls.Add(Me.LblBase22)
        Me.PnlBase6.Controls.Add(Me.kl_btw)
        Me.PnlBase6.Controls.Add(Me.LblBase23)
        Me.PnlBase6.Controls.Add(Me.BTW_Omschrijving)
        Me.PnlBase6.Controls.Add(Me.LblBase12)
        Me.PnlBase6.Location = New System.Drawing.Point(390, 92)
        Me.PnlBase6.Name = "PnlBase6"
        Me.PnlBase6.Size = New System.Drawing.Size(354, 155)
        Me.PnlBase6.TabIndex = 3
        '
        'KL_Automatisch
        '
        Me.KL_Automatisch.BackColor = System.Drawing.SystemColors.Window
        Me.KL_Automatisch.Cursor = System.Windows.Forms.Cursors.PanWest
        Me.KL_Automatisch.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BS, "KL_Automatic", True))
        Me.KL_Automatisch.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.KL_Automatisch.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Automatisch.Location = New System.Drawing.Point(256, 122)
        Me.KL_Automatisch.Name = "KL_Automatisch"
        Me.KL_Automatisch.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Automatisch.Size = New System.Drawing.Size(21, 21)
        Me.KL_Automatisch.TabIndex = 43
        Me.KL_Automatisch.UseVisualStyleBackColor = False
        '
        'LblBase24
        '
        Me.LblBase24.AutoSize = True
        Me.LblBase24.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase24.Location = New System.Drawing.Point(9, 124)
        Me.LblBase24.Name = "LblBase24"
        Me.LblBase24.Size = New System.Drawing.Size(57, 18)
        Me.LblBase24.TabIndex = 42
        Me.LblBase24.Text = "Voldaan"
        '
        'KL_Voldaan
        '
        Me.KL_Voldaan.BackColor = System.Drawing.SystemColors.Window
        Me.KL_Voldaan.Cursor = System.Windows.Forms.Cursors.PanWest
        Me.KL_Voldaan.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BS, "KL_Voldaan", True))
        Me.KL_Voldaan.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.KL_Voldaan.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Voldaan.Location = New System.Drawing.Point(85, 122)
        Me.KL_Voldaan.Name = "KL_Voldaan"
        Me.KL_Voldaan.nIO = b040.IOValues.IORecordEntryEnable
        Me.KL_Voldaan.Size = New System.Drawing.Size(21, 21)
        Me.KL_Voldaan.TabIndex = 41
        Me.KL_Voldaan.UseVisualStyleBackColor = False
        '
        'LblBase22
        '
        Me.LblBase22.AutoSize = True
        Me.LblBase22.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase22.Location = New System.Drawing.Point(176, 124)
        Me.LblBase22.Name = "LblBase22"
        Me.LblBase22.Size = New System.Drawing.Size(88, 18)
        Me.LblBase22.TabIndex = 30
        Me.LblBase22.Text = "Automatisch"
        '
        'kl_btw
        '
        Me.kl_btw.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.kl_btw.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS, "KL_BTW", True))
        Me.kl_btw.fieldLength = 0
        Me.kl_btw.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kl_btw.forceUppercase = True
        Me.kl_btw.ForeColor = System.Drawing.Color.DarkBlue
        Me.kl_btw.lIsSearch = False
        Me.kl_btw.Location = New System.Drawing.Point(85, 93)
        Me.kl_btw.Name = "kl_btw"
        Me.kl_btw.nIO = b040.IOValues.IORecordEntryEnable
        Me.kl_btw.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.kl_btw.Size = New System.Drawing.Size(257, 31)
        Me.kl_btw.TabIndex = 27
        '
        'LblBase23
        '
        Me.LblBase23.AutoSize = True
        Me.LblBase23.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase23.Location = New System.Drawing.Point(9, 97)
        Me.LblBase23.Name = "LblBase23"
        Me.LblBase23.Size = New System.Drawing.Size(54, 18)
        Me.LblBase23.TabIndex = 26
        Me.LblBase23.Text = "BTW Nr"
        '
        'BTW_Omschrijving
        '
        Me.BTW_Omschrijving.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTW_Omschrijving.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.BS, "BTW_OMSCHRIJVING", True))
        Me.BTW_Omschrijving.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTW_Omschrijving.ForeColor = System.Drawing.Color.DarkBlue
        Me.BTW_Omschrijving.FormattingEnabled = True
        Me.BTW_Omschrijving.Location = New System.Drawing.Point(85, 5)
        Me.BTW_Omschrijving.Name = "BTW_Omschrijving"
        Me.BTW_Omschrijving.nIO = b040.IOValues.IORecordEntryEnable
        Me.BTW_Omschrijving.Size = New System.Drawing.Size(257, 82)
        Me.BTW_Omschrijving.TabIndex = 0
        '
        'LblBase12
        '
        Me.LblBase12.AutoSize = True
        Me.LblBase12.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase12.Location = New System.Drawing.Point(9, 5)
        Me.LblBase12.Name = "LblBase12"
        Me.LblBase12.Size = New System.Drawing.Size(69, 18)
        Me.LblBase12.TabIndex = 24
        Me.LblBase12.Text = "BTW Type"
        '
        'Zoek
        '
        Me.Zoek.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Zoek.DisplayMember = "KL_id"
        Me.Zoek.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Zoek.ForeColor = System.Drawing.Color.DarkBlue
        Me.Zoek.FormattingEnabled = True
        Me.Zoek.IntegralHeight = False
        Me.Zoek.Location = New System.Drawing.Point(483, 6)
        Me.Zoek.Name = "Zoek"
        Me.Zoek.nIO = b040.IOValues.IOKeyEntryEnable
        Me.Zoek.setAutocomplete = False
        Me.Zoek.Size = New System.Drawing.Size(267, 34)
        Me.Zoek.TabIndex = 0
        Me.Zoek.ValueMember = "KL_id"
        '
        'BedieningBindingSource
        '
        Me.BedieningBindingSource.DataMember = "Bediening"
        Me.BedieningBindingSource.DataSource = Me.B040_beDataSet1
        '
        'B040_beDataSet1
        '
        Me.B040_beDataSet1.DataSetName = "b040_beDataSet1"
        Me.B040_beDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TpgBase1
        '
        Me.TpgBase1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TpgBase1.Controls.Add(Me.TabPage1)
        Me.TpgBase1.Controls.Add(Me.TabPage2)
        Me.TpgBase1.Controls.Add(Me.TabPage3)
        Me.TpgBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.TpgBase1.Location = New System.Drawing.Point(16, 42)
        Me.TpgBase1.Name = "TpgBase1"
        Me.TpgBase1.SelectedIndex = 0
        Me.TpgBase1.Size = New System.Drawing.Size(760, 451)
        Me.TpgBase1.TabIndex = 1
        Me.TpgBase1.TabStop = False
        '
        'B040_beDataSet
        '
        Me.B040_beDataSet.DataSetName = "b040_beDataSet"
        Me.B040_beDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'B040beDataSetBindingSource
        '
        Me.B040beDataSetBindingSource.DataSource = Me.B040_beDataSet
        Me.B040beDataSetBindingSource.Position = 0
        '
        'BedieningDS
        '
        Me.BedieningDS.DataSetName = "BedieningDS"
        Me.BedieningDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BedieningDSBindingSource
        '
        Me.BedieningDSBindingSource.DataSource = Me.BedieningDS
        Me.BedieningDSBindingSource.Position = 0
        '
        'BedieningTableAdapter
        '
        Me.BedieningTableAdapter.ClearBeforeFill = True
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Garamond", 20.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Title.ForeColor = System.Drawing.Color.DarkBlue
        Me.Title.Location = New System.Drawing.Point(15, 8)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(86, 38)
        Me.Title.TabIndex = 44
        Me.Title.Text = "Title"
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseBtn.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.CloseBtn.Image = Global.b040.My.Resources.Resources.CLOSE
        Me.CloseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CloseBtn.Location = New System.Drawing.Point(697, 499)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.nIO = b040.IOValues.IOAlwaysEnable
        Me.CloseBtn.Size = New System.Drawing.Size(68, 25)
        Me.CloseBtn.TabIndex = 19
        Me.CloseBtn.TabStop = False
        Me.CloseBtn.Text = "Sluit"
        Me.CloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'zoekButton
        '
        Me.zoekButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.zoekButton.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zoekButton.Image = CType(resources.GetObject("zoekButton.Image"), System.Drawing.Image)
        Me.zoekButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.zoekButton.Location = New System.Drawing.Point(397, 10)
        Me.zoekButton.Name = "zoekButton"
        Me.zoekButton.nIO = b040.IOValues.IOKeyEntryEnable
        Me.zoekButton.Size = New System.Drawing.Size(80, 25)
        Me.zoekButton.TabIndex = 43
        Me.zoekButton.TabStop = False
        Me.zoekButton.Text = "Zoek (F2)"
        Me.zoekButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.zoekButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Image = CType(resources.GetObject("SaveButton.Image"), System.Drawing.Image)
        Me.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveButton.Location = New System.Drawing.Point(16, 498)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.SaveButton.Size = New System.Drawing.Size(75, 25)
        Me.SaveButton.TabIndex = 20
        Me.SaveButton.TabStop = False
        Me.SaveButton.Text = "Bewaar"
        Me.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'BestelDS2
        '
        Me.BestelDS2.DataSetName = "BestelDS"
        Me.BestelDS2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'colArtSearch
        '
        Me.colArtSearch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colArtSearch.DataPropertyName = "KK_Artikel"
        Me.colArtSearch.FillWeight = 5.0!
        Me.colArtSearch.HeaderText = "Artikel"
        Me.colArtSearch.MinimumWidth = 20
        Me.colArtSearch.Name = "colArtSearch"
        Me.colArtSearch.Width = 82
        '
        'Art_Omschrijving
        '
        Me.Art_Omschrijving.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Art_Omschrijving.DataPropertyName = "Art_Omschrijving"
        Me.Art_Omschrijving.FillWeight = 20.0!
        Me.Art_Omschrijving.HeaderText = "Omschrijving"
        Me.Art_Omschrijving.Name = "Art_Omschrijving"
        '
        'KKKortingDataGridViewTextBoxColumn
        '
        Me.KKKortingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.KKKortingDataGridViewTextBoxColumn.DataPropertyName = "KK_Korting"
        Me.KKKortingDataGridViewTextBoxColumn.FillWeight = 5.0!
        Me.KKKortingDataGridViewTextBoxColumn.HeaderText = "Korting (%)"
        Me.KKKortingDataGridViewTextBoxColumn.Name = "KKKortingDataGridViewTextBoxColumn"
        Me.KKKortingDataGridViewTextBoxColumn.Width = 113
        '
        'KKIDDataGridViewTextBoxColumn
        '
        Me.KKIDDataGridViewTextBoxColumn.DataPropertyName = "KK_ID"
        Me.KKIDDataGridViewTextBoxColumn.HeaderText = "KK_ID"
        Me.KKIDDataGridViewTextBoxColumn.Name = "KKIDDataGridViewTextBoxColumn"
        Me.KKIDDataGridViewTextBoxColumn.Visible = False
        '
        'KKArtikelDataGridViewTextBoxColumn
        '
        Me.KKArtikelDataGridViewTextBoxColumn.DataPropertyName = "KK_Artikel"
        Me.KKArtikelDataGridViewTextBoxColumn.HeaderText = "KK_Artikel"
        Me.KKArtikelDataGridViewTextBoxColumn.Name = "KKArtikelDataGridViewTextBoxColumn"
        Me.KKArtikelDataGridViewTextBoxColumn.Visible = False
        '
        'Art_Nr
        '
        Me.Art_Nr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Art_Nr.DataPropertyName = "Art_Nr"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Art_Nr.DefaultCellStyle = DataGridViewCellStyle2
        Me.Art_Nr.FillWeight = 5.0!
        Me.Art_Nr.HeaderText = "KK_Artikel"
        Me.Art_Nr.Name = "Art_Nr"
        Me.Art_Nr.Visible = False
        Me.Art_Nr.Width = 108
        '
        'KlantenFrm
        '
        Me.CancelButton = Me.CloseBtn
        Me.ClientSize = New System.Drawing.Size(781, 518)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.zoekButton)
        Me.Controls.Add(Me.TpgBase1)
        Me.Controls.Add(Me.Zoek)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.SaveButton)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1000, 565)
        Me.MinimumSize = New System.Drawing.Size(400, 540)
        Me.Name = "KlantenFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Klant"
        CType(Me.BS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KlantenDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdresBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KlantenKortingBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BestelDS1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.PnlBase11.ResumeLayout(False)
        Me.PnlBase11.PerformLayout()
        CType(Me.KlantenKortingG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBase8.ResumeLayout(False)
        Me.PnlBase8.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.AdresG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.PnlBase7.ResumeLayout(False)
        Me.PnlBase7.PerformLayout()
        Me.PnlBase4.ResumeLayout(False)
        Me.PnlBase4.PerformLayout()
        Me.PnlBase3.ResumeLayout(False)
        Me.PnlBase3.PerformLayout()
        Me.PnlBase2.ResumeLayout(False)
        Me.PnlBase2.PerformLayout()
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        Me.PnlBase6.ResumeLayout(False)
        Me.PnlBase6.PerformLayout()
        CType(Me.BedieningBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B040_beDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpgBase1.ResumeLayout(False)
        CType(Me.B040_beDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B040beDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BedieningDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BedieningDSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BestelDS2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BS As System.Windows.Forms.BindingSource
    Friend WithEvents KlantenDS As b040.KlantenDS
    Friend WithEvents KlantenCRUD As b040.KlantenDSTableAdapters.KlantenCRUD
    Friend WithEvents SaveButton As b040.btnBase
    Friend WithEvents CloseBtn As b040.btnBase
    Friend WithEvents TableAdapterManager As b040.KlantenDSTableAdapters.TableAdapterManager
    Friend WithEvents AdresBS As System.Windows.Forms.BindingSource
    Friend WithEvents KlantAdresCRUD As b040.KlantenDSTableAdapters.KlantAdresCRUD
    Friend WithEvents KlantenKortingBS As System.Windows.Forms.BindingSource
    Friend WithEvents KLantenKlantenKortingCRUD As b040.KlantenDSTableAdapters.KLantenKlantenKortingCRUD
    Friend WithEvents BestelDS1 As b040.BestelDS
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents AdresG As b040.grdBase
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PnlBase7 As b040.pnlBase
    Friend WithEvents LblBase20 As b040.lblBase
    Friend WithEvents KL_Actief As b040.checkboxBase
    Friend WithEvents PnlBase4 As b040.pnlBase
    Friend WithEvents KL_Komthalen As b040.checkboxBase
    Friend WithEvents LblBase27 As b040.lblBase
    Friend WithEvents LblBase19 As b040.lblBase
    Friend WithEvents PnlBase3 As b040.pnlBase
    Friend WithEvents KL_Code As b040.txtBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents PnlBase2 As b040.pnlBase
    Friend WithEvents LblBase18 As b040.lblBase
    Friend WithEvents LblBase16 As b040.lblBase
    Friend WithEvents land As b040.txtBase
    Friend WithEvents LblBase11 As b040.lblBase
    Friend WithEvents adres As b040.txtBase
    Friend WithEvents LblBase14 As b040.lblBase
    Friend WithEvents postnr As b040.txtBase
    Friend WithEvents gemeente As b040.txtBase
    Friend WithEvents LblBase15 As b040.lblBase
    Friend WithEvents Telefoon As b040.txtBase
    Friend WithEvents LblBase5 As b040.lblBase
    Friend WithEvents KL_EMail As b040.txtBase
    Friend WithEvents KL_Telefoon2 As b040.txtBase
    Friend WithEvents KL_Titel As b040.txtBase
    Friend WithEvents KL_GSM As b040.txtBase
    Friend WithEvents KL_Voornaam As b040.txtBase
    Friend WithEvents LblBase9 As b040.lblBase
    Friend WithEvents LblBase7 As b040.lblBase
    Friend WithEvents LblBase6 As b040.lblBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents LblBase3 As b040.lblBase
    Friend WithEvents KL_Naam As b040.txtBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents LblBase17 As b040.lblBase
    Friend WithEvents typeFacturatieControl As b040.checkedListboxBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents KL_Nummer As b040.txtBase
    Friend WithEvents PnlBase6 As b040.pnlBase
    Friend WithEvents KL_Automatisch As b040.checkboxBase
    Friend WithEvents LblBase24 As b040.lblBase
    Friend WithEvents KL_Voldaan As b040.checkboxBase
    Friend WithEvents LblBase22 As b040.lblBase
    Friend WithEvents kl_btw As b040.txtBase
    Friend WithEvents LblBase23 As b040.lblBase
    Friend WithEvents BTW_Omschrijving As b040.checkedListboxBase
    Friend WithEvents LblBase12 As b040.lblBase
    Friend WithEvents TpgBase1 As b040.tpgBase
    Friend WithEvents Zoek As b040.cboBase
    Friend WithEvents BedieningDSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BedieningDS As b040.BedieningDS
    Friend WithEvents B040_beDataSet As b040.b040_beDataSet
    Friend WithEvents B040beDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents B040_beDataSet1 As b040.b040_beDataSet1
    Friend WithEvents BedieningBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BedieningTableAdapter As b040.b040_beDataSet1TableAdapters.BedieningTableAdapter
    Friend WithEvents zoekButton As b040.btnBase
    Friend WithEvents Title As b040.lblBase
    Friend WithEvents Bed_naam As b040.cboBase
    Friend WithEvents PnlBase11 As b040.pnlBase
    Friend WithEvents LblBase21 As b040.lblBase
    Friend WithEvents KlantenKortingG As b040.grdBase
    Friend WithEvents PnlBase8 As b040.pnlBase
    Friend WithEvents KL_Korting As b040.txtBaseNumeric
    Friend WithEvents LblBase8 As b040.lblBase
    Friend WithEvents adresColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents postnrColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gemeenteColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents landColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents telefoonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents factColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AdridDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdrKlantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtBaseMultiline1 As b040.txtBaseMultiline
    Friend WithEvents laatsteBestellingBehoudenLabel As b040.lblBase
    Friend WithEvents laatstebestellingBehoudenCheckbox As b040.checkboxBase
    Friend WithEvents BestelDS2 As b040.BestelDS
    Friend WithEvents KL_Fax As b040.txtBase
    Friend WithEvents LblBase13 As b040.lblBase
    Friend WithEvents AnnuleerKlantenKortingButton As btnBase
    Friend WithEvents colArtSearch As DataGridViewTextBoxColumn
    Friend WithEvents Art_Omschrijving As DataGridViewTextBoxColumn
    Friend WithEvents KKKortingDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents KKIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents KKArtikelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Art_Nr As DataGridViewTextBoxColumn
End Class

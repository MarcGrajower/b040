<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bestelfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bestelfrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BestelHBS = New System.Windows.Forms.BindingSource(Me.components)
        Me.BestelDS = New b040.BestelDS()
        Me.AdresBS = New System.Windows.Forms.BindingSource(Me.components)
        Me.BestelDBS = New System.Windows.Forms.BindingSource(Me.components)
        Me.BestelAdresTA = New b040.BestelDSTableAdapters.BestelAdresTA()
        Me.BestelDCRUD = New b040.BestelDSTableAdapters.BestDCRUD()
        Me.BestelHCRUD = New b040.BestelDSTableAdapters.BestHCRUD()
        Me.BestelDCRUD1 = New b040.BestelDSTableAdapters.BestDCRUD()
        Me.EenhedenDS1 = New b040.EenhedenDS()
        Me.KlantenTableAdapter1 = New b040.StandaardenDSTableAdapters.KlantenTableAdapter()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.direct_afdrukken = New b040.btnBase()
        Me.EpsonAlles = New b040.btnBase()
        Me.Snijdentoggle = New b040.btnBase()
        Me.EpsonD = New b040.btnBase()
        Me.EpsonC = New b040.btnBase()
        Me.EpsonB = New b040.btnBase()
        Me.EpsonA = New b040.btnBase()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.NulBestelling = New b040.btnBase()
        Me.btnInfo = New b040.btnBase()
        Me.BestH_Info = New b040.txtBaseMultiline()
        Me.BtnBewaarAndereDag = New b040.btnBase()
        Me.PnlStandaard = New b040.pnlBase()
        Me.BestH_Standaard = New b040.txtBase()
        Me.BestH_StToegepast = New b040.cbobaseJaNeen()
        Me.StType = New b040.cboBase()
        Me.LblBase17 = New b040.lblBase()
        Me.LblBase18 = New b040.lblBase()
        Me.LblBase19 = New b040.lblBase()
        Me.PnlBase3 = New b040.pnlBase()
        Me.BetalingTextbox = New b040.txtBase()
        Me.LblBase3 = New b040.lblBase()
        Me.LblBase6 = New b040.lblBase()
        Me.VolgendeFeestdag = New b040.txtBase()
        Me.TotBTW = New b040.txtBase()
        Me.TotaalEur = New b040.txtBase()
        Me.LblBase7 = New b040.lblBase()
        Me.LblBase15 = New b040.lblBase()
        Me.Bestellinglijnen = New b040.txtBase()
        Me.LblBase16 = New b040.lblBase()
        Me.PnlBase2 = New b040.pnlBase()
        Me.KL_Nummer = New b040.txtBase()
        Me.LblBase11 = New b040.lblBase()
        Me.Bediening = New b040.cboBase()
        Me.LblBase10 = New b040.lblBase()
        Me.BestH_KomtHalen = New b040.cbobaseJaNeen()
        Me.Adr_Telefoon = New b040.txtBase()
        Me.LblBase9 = New b040.lblBase()
        Me.KL_Naam = New b040.txtBase()
        Me.LblBase8 = New b040.lblBase()
        Me.KlantLbl = New b040.lblBase()
        Me.SaveAsStandaard = New b040.btnBase()
        Me.PnlBase1 = New b040.pnlBase()
        Me.LblNrLevering = New b040.lblBase()
        Me.TxtNrLevering = New b040.txtBase()
        Me.LblBase5 = New b040.lblBase()
        Me.BestH_UurLevering = New b040.txtBase()
        Me.LblBase4 = New b040.lblBase()
        Me.BestH_DatLevering = New b040.txtBaseDate()
        Me.DagLevering = New b040.txtBase()
        Me.lblDag = New b040.lblBase()
        Me.grdBestelD = New b040.grdBase()
        Me.BestDIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestDBestHDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestDIsStandaardDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BestDArtikelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Art_Nr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Omschrijving = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestD_Snijden = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Tour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestD_Portie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Standaard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestD_Hoev1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eenh_HoevInvoer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestD_EenhPrijs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eenh_omschrijving = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestD_Waarde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.voorafdrukken = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BestD_Verwittigen = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BestD_Opschrift = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.BestD_Boodschap = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colArtNrBound = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DsOpschriftenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsOpschriften = New b040.dsOpschriften()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PnlBase5 = New b040.pnlBase()
        Me.LblBase2 = New b040.lblBase()
        Me.LblBase1 = New b040.lblBase()
        Me.txtBestH_DatBest2 = New b040.txtBaseDate()
        Me.lblDate = New b040.lblBase()
        Me.PnlBase4 = New b040.pnlBase()
        Me.btnVerwijderDocument = New b040.btnBase()
        Me.txtBestH_DatLeveing2 = New b040.txtBaseDate()
        Me.lblDatLeving = New b040.lblBase()
        Me.BestH_Docnr = New b040.txtBase()
        Me.LblBase20 = New b040.lblBase()
        Me.bestelTabpage = New b040.tpgBase()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.AdresG = New b040.grdBase()
        Me.Adr_Adres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Adr_PostNummer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Adr_Gemeente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Adr_Land = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdrFacturatieDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Adr_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kies = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.overzichtGobottomButton = New System.Windows.Forms.Button()
        Me.overzichtGotopButton = New System.Windows.Forms.Button()
        Me.grdHistory = New System.Windows.Forms.DataGridView()
        Me.particulierenTabPage = New System.Windows.Forms.TabPage()
        Me.particulierenOverzichtDatagridview = New System.Windows.Forms.DataGridView()
        Me.particulierenGobottomButton = New System.Windows.Forms.Button()
        Me.particulierenGotopButton = New System.Windows.Forms.Button()
        Me.CloseBtn = New b040.btnBase()
        Me.BtnToggle = New b040.btnBase()
        Me.InsertButton = New b040.btnBase()
        Me.btnDelete = New b040.btnBase()
        Me.SaveButton = New b040.btnBase()
        Me.BewaarEnBlijf = New b040.btnBase()
        Me.BestDCRUD1 = New b040.BestelDSTableAdapters.BestDCRUD()
        Me.BedieningTableAdapter1 = New b040.b040_beDataSet1TableAdapters.BedieningTableAdapter()
        CType(Me.BestelHBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BestelDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdresBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BestelDBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EenhedenDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.PnlStandaard.SuspendLayout()
        Me.PnlBase3.SuspendLayout()
        Me.PnlBase2.SuspendLayout()
        Me.PnlBase1.SuspendLayout()
        CType(Me.grdBestelD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsOpschriftenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsOpschriften, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.PnlBase5.SuspendLayout()
        Me.PnlBase4.SuspendLayout()
        Me.bestelTabpage.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.AdresG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.particulierenTabPage.SuspendLayout()
        CType(Me.particulierenOverzichtDatagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BestelHBS
        '
        Me.BestelHBS.DataMember = "BestH"
        Me.BestelHBS.DataSource = Me.BestelDS
        '
        'BestelDS
        '
        Me.BestelDS.DataSetName = "BestelDS"
        Me.BestelDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AdresBS
        '
        Me.AdresBS.DataMember = "Adres"
        Me.AdresBS.DataSource = Me.BestelDS
        '
        'BestelDBS
        '
        Me.BestelDBS.DataMember = "BestD"
        Me.BestelDBS.DataSource = Me.BestelDS
        '
        'BestelAdresTA
        '
        Me.BestelAdresTA.ClearBeforeFill = True
        '
        'BestelDCRUD
        '
        Me.BestelDCRUD.ClearBeforeFill = True
        '
        'BestelHCRUD
        '
        Me.BestelHCRUD.ClearBeforeFill = True
        '
        'BestelDCRUD1
        '
        Me.BestelDCRUD1.ClearBeforeFill = True
        '
        'EenhedenDS1
        '
        Me.EenhedenDS1.DataSetName = "EenhedenDS"
        Me.EenhedenDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KlantenTableAdapter1
        '
        Me.KlantenTableAdapter1.ClearBeforeFill = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.direct_afdrukken)
        Me.TabPage2.Controls.Add(Me.EpsonAlles)
        Me.TabPage2.Controls.Add(Me.Snijdentoggle)
        Me.TabPage2.Controls.Add(Me.EpsonD)
        Me.TabPage2.Controls.Add(Me.EpsonC)
        Me.TabPage2.Controls.Add(Me.EpsonB)
        Me.TabPage2.Controls.Add(Me.EpsonA)
        Me.TabPage2.Controls.Add(Me.MonthCalendar1)
        Me.TabPage2.Controls.Add(Me.NulBestelling)
        Me.TabPage2.Controls.Add(Me.btnInfo)
        Me.TabPage2.Controls.Add(Me.BestH_Info)
        Me.TabPage2.Controls.Add(Me.BtnBewaarAndereDag)
        Me.TabPage2.Controls.Add(Me.PnlStandaard)
        Me.TabPage2.Controls.Add(Me.PnlBase3)
        Me.TabPage2.Controls.Add(Me.PnlBase2)
        Me.TabPage2.Controls.Add(Me.SaveAsStandaard)
        Me.TabPage2.Controls.Add(Me.PnlBase1)
        Me.TabPage2.Controls.Add(Me.grdBestelD)
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1129, 674)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bestelling"
        '
        'direct_afdrukken
        '
        Me.direct_afdrukken.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.direct_afdrukken.Image = Global.b040.My.Resources.Resources.REPORT
        Me.direct_afdrukken.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.direct_afdrukken.Location = New System.Drawing.Point(967, 367)
        Me.direct_afdrukken.Name = "direct_afdrukken"
        Me.direct_afdrukken.nIO = b040.IOValues.IORecordEntryEnable
        Me.direct_afdrukken.Size = New System.Drawing.Size(153, 23)
        Me.direct_afdrukken.TabIndex = 106
        Me.direct_afdrukken.TabStop = False
        Me.direct_afdrukken.Text = "Direct Afdrukken (F10)"
        Me.direct_afdrukken.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.direct_afdrukken.UseVisualStyleBackColor = True
        '
        'EpsonAlles
        '
        Me.EpsonAlles.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.EpsonAlles.Image = Global.b040.My.Resources.Resources.REPORT
        Me.EpsonAlles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EpsonAlles.Location = New System.Drawing.Point(967, 328)
        Me.EpsonAlles.Name = "EpsonAlles"
        Me.EpsonAlles.nIO = b040.IOValues.IORecordEntryEnable
        Me.EpsonAlles.Size = New System.Drawing.Size(153, 23)
        Me.EpsonAlles.TabIndex = 105
        Me.EpsonAlles.TabStop = False
        Me.EpsonAlles.Text = "Epson (alles A) (F9)"
        Me.EpsonAlles.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EpsonAlles.UseVisualStyleBackColor = True
        '
        'Snijdentoggle
        '
        Me.Snijdentoggle.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.Snijdentoggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Snijdentoggle.Location = New System.Drawing.Point(967, 424)
        Me.Snijdentoggle.Name = "Snijdentoggle"
        Me.Snijdentoggle.nIO = b040.IOValues.IORecordEntryEnable
        Me.Snijdentoggle.Size = New System.Drawing.Size(153, 23)
        Me.Snijdentoggle.TabIndex = 101
        Me.Snijdentoggle.TabStop = False
        Me.Snijdentoggle.Text = "Snijden (F12)"
        Me.Snijdentoggle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Snijdentoggle.UseVisualStyleBackColor = True
        '
        'EpsonD
        '
        Me.EpsonD.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.EpsonD.Image = Global.b040.My.Resources.Resources.REPORT
        Me.EpsonD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EpsonD.Location = New System.Drawing.Point(967, 290)
        Me.EpsonD.Name = "EpsonD"
        Me.EpsonD.nIO = b040.IOValues.IORecordEntryEnable
        Me.EpsonD.Size = New System.Drawing.Size(153, 23)
        Me.EpsonD.TabIndex = 104
        Me.EpsonD.TabStop = False
        Me.EpsonD.Text = "Epson D (F8)"
        Me.EpsonD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EpsonD.UseVisualStyleBackColor = True
        '
        'EpsonC
        '
        Me.EpsonC.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.EpsonC.Image = Global.b040.My.Resources.Resources.REPORT
        Me.EpsonC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EpsonC.Location = New System.Drawing.Point(967, 267)
        Me.EpsonC.Name = "EpsonC"
        Me.EpsonC.nIO = b040.IOValues.IORecordEntryEnable
        Me.EpsonC.Size = New System.Drawing.Size(153, 23)
        Me.EpsonC.TabIndex = 103
        Me.EpsonC.TabStop = False
        Me.EpsonC.Text = "Epson C (F7)"
        Me.EpsonC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EpsonC.UseVisualStyleBackColor = True
        '
        'EpsonB
        '
        Me.EpsonB.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.EpsonB.Image = Global.b040.My.Resources.Resources.REPORT
        Me.EpsonB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EpsonB.Location = New System.Drawing.Point(967, 243)
        Me.EpsonB.Name = "EpsonB"
        Me.EpsonB.nIO = b040.IOValues.IORecordEntryEnable
        Me.EpsonB.Size = New System.Drawing.Size(153, 23)
        Me.EpsonB.TabIndex = 102
        Me.EpsonB.TabStop = False
        Me.EpsonB.Text = "Epson B (F6)"
        Me.EpsonB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EpsonB.UseVisualStyleBackColor = True
        '
        'EpsonA
        '
        Me.EpsonA.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.EpsonA.Image = Global.b040.My.Resources.Resources.REPORT
        Me.EpsonA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EpsonA.Location = New System.Drawing.Point(967, 219)
        Me.EpsonA.Name = "EpsonA"
        Me.EpsonA.nIO = b040.IOValues.IORecordEntryEnable
        Me.EpsonA.Size = New System.Drawing.Size(153, 23)
        Me.EpsonA.TabIndex = 101
        Me.EpsonA.TabStop = False
        Me.EpsonA.Text = "Epson A (F5)"
        Me.EpsonA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EpsonA.UseVisualStyleBackColor = True
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.MonthCalendar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.MonthCalendar1.Location = New System.Drawing.Point(1, 5)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 5
        Me.MonthCalendar1.TitleBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.MonthCalendar1.TrailingForeColor = System.Drawing.SystemColors.MenuHighlight
        '
        'NulBestelling
        '
        Me.NulBestelling.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.NulBestelling.Image = CType(resources.GetObject("NulBestelling.Image"), System.Drawing.Image)
        Me.NulBestelling.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NulBestelling.Location = New System.Drawing.Point(967, 540)
        Me.NulBestelling.Name = "NulBestelling"
        Me.NulBestelling.nIO = b040.IOValues.IORecordEntryEnable
        Me.NulBestelling.Size = New System.Drawing.Size(156, 23)
        Me.NulBestelling.TabIndex = 100
        Me.NulBestelling.TabStop = False
        Me.NulBestelling.Text = " NulBestelling (^Z)"
        Me.NulBestelling.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.NulBestelling.UseVisualStyleBackColor = True
        '
        'btnInfo
        '
        Me.btnInfo.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnInfo.Image = CType(resources.GetObject("btnInfo.Image"), System.Drawing.Image)
        Me.btnInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInfo.Location = New System.Drawing.Point(967, 165)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.nIO = b040.IOValues.IORecordEntryEnable
        Me.btnInfo.Size = New System.Drawing.Size(153, 23)
        Me.btnInfo.TabIndex = 34
        Me.btnInfo.TabStop = False
        Me.btnInfo.Text = "Info (^I)"
        Me.btnInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInfo.UseVisualStyleBackColor = True
        '
        'BestH_Info
        '
        Me.BestH_Info.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BestH_Info", True))
        Me.BestH_Info.Font = New System.Drawing.Font("Trebuchet MS", 13.0!, System.Drawing.FontStyle.Bold)
        Me.BestH_Info.ForeColor = System.Drawing.Color.DarkBlue
        Me.BestH_Info.Location = New System.Drawing.Point(729, 3)
        Me.BestH_Info.Multiline = True
        Me.BestH_Info.Name = "BestH_Info"
        Me.BestH_Info.nIO = b040.IOValues.IORecordEntryEnable
        Me.BestH_Info.Size = New System.Drawing.Size(399, 158)
        Me.BestH_Info.TabIndex = 1
        Me.BestH_Info.TabStop = False
        '
        'BtnBewaarAndereDag
        '
        Me.BtnBewaarAndereDag.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.BtnBewaarAndereDag.Image = Global.b040.My.Resources.Resources.save
        Me.BtnBewaarAndereDag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBewaarAndereDag.Location = New System.Drawing.Point(964, 564)
        Me.BtnBewaarAndereDag.Name = "BtnBewaarAndereDag"
        Me.BtnBewaarAndereDag.nIO = b040.IOValues.IORecordEntryEnable
        Me.BtnBewaarAndereDag.Size = New System.Drawing.Size(160, 23)
        Me.BtnBewaarAndereDag.TabIndex = 35
        Me.BtnBewaarAndereDag.TabStop = False
        Me.BtnBewaarAndereDag.Text = "als andere datum (^D)"
        Me.BtnBewaarAndereDag.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBewaarAndereDag.UseVisualStyleBackColor = True
        '
        'PnlStandaard
        '
        Me.PnlStandaard.BackColor = System.Drawing.Color.Silver
        Me.PnlStandaard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlStandaard.Controls.Add(Me.BestH_Standaard)
        Me.PnlStandaard.Controls.Add(Me.BestH_StToegepast)
        Me.PnlStandaard.Controls.Add(Me.StType)
        Me.PnlStandaard.Controls.Add(Me.LblBase17)
        Me.PnlStandaard.Controls.Add(Me.LblBase18)
        Me.PnlStandaard.Controls.Add(Me.LblBase19)
        Me.PnlStandaard.Location = New System.Drawing.Point(472, 5)
        Me.PnlStandaard.Name = "PnlStandaard"
        Me.PnlStandaard.Size = New System.Drawing.Size(255, 49)
        Me.PnlStandaard.TabIndex = 0
        '
        'BestH_Standaard
        '
        Me.BestH_Standaard.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BestH_StType", True))
        Me.BestH_Standaard.fieldLength = 0
        Me.BestH_Standaard.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BestH_Standaard.forceUppercase = True
        Me.BestH_Standaard.ForeColor = System.Drawing.Color.DarkBlue
        Me.BestH_Standaard.lIsSearch = False
        Me.BestH_Standaard.Location = New System.Drawing.Point(201, 21)
        Me.BestH_Standaard.Name = "BestH_Standaard"
        Me.BestH_Standaard.nIO = b040.IOValues.IOKeyEntryEnable
        Me.BestH_Standaard.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.BestH_Standaard.Size = New System.Drawing.Size(50, 28)
        Me.BestH_Standaard.TabIndex = 2
        Me.BestH_Standaard.TabStop = False
        '
        'BestH_StToegepast
        '
        Me.BestH_StToegepast.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BestH_StToegepast", True))
        Me.BestH_StToegepast.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.BestH_StToegepast.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BestH_StToegepast.ForeColor = System.Drawing.Color.DarkBlue
        Me.BestH_StToegepast.FormattingEnabled = True
        Me.BestH_StToegepast.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.BestH_StToegepast.Location = New System.Drawing.Point(2, 20)
        Me.BestH_StToegepast.Name = "BestH_StToegepast"
        Me.BestH_StToegepast.nIO = b040.IOValues.IOKeyEntryEnable
        Me.BestH_StToegepast.setAutocomplete = False
        Me.BestH_StToegepast.Size = New System.Drawing.Size(111, 29)
        Me.BestH_StToegepast.TabIndex = 0
        Me.BestH_StToegepast.TabStop = False
        '
        'StType
        '
        Me.StType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.StType.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.StType.ForeColor = System.Drawing.Color.DarkBlue
        Me.StType.FormattingEnabled = True
        Me.StType.Location = New System.Drawing.Point(114, 20)
        Me.StType.Name = "StType"
        Me.StType.nIO = b040.IOValues.IOKeyEntryEnable
        Me.StType.setAutocomplete = False
        Me.StType.Size = New System.Drawing.Size(87, 29)
        Me.StType.TabIndex = 1
        Me.StType.TabStop = False
        '
        'LblBase17
        '
        Me.LblBase17.AutoSize = True
        Me.LblBase17.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase17.Location = New System.Drawing.Point(196, 4)
        Me.LblBase17.Name = "LblBase17"
        Me.LblBase17.Size = New System.Drawing.Size(71, 22)
        Me.LblBase17.TabIndex = 8
        Me.LblBase17.Text = "Nr (1..3)"
        '
        'LblBase18
        '
        Me.LblBase18.AutoSize = True
        Me.LblBase18.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase18.Location = New System.Drawing.Point(111, 4)
        Me.LblBase18.Name = "LblBase18"
        Me.LblBase18.Size = New System.Drawing.Size(78, 22)
        Me.LblBase18.TabIndex = 6
        Me.LblBase18.Text = "Type Best"
        '
        'LblBase19
        '
        Me.LblBase19.AutoSize = True
        Me.LblBase19.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase19.Location = New System.Drawing.Point(-1, 4)
        Me.LblBase19.Name = "LblBase19"
        Me.LblBase19.Size = New System.Drawing.Size(176, 23)
        Me.LblBase19.TabIndex = 0
        Me.LblBase19.Text = "Standaard Toepassen"
        '
        'PnlBase3
        '
        Me.PnlBase3.BackColor = System.Drawing.Color.Silver
        Me.PnlBase3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase3.Controls.Add(Me.BetalingTextbox)
        Me.PnlBase3.Controls.Add(Me.LblBase3)
        Me.PnlBase3.Controls.Add(Me.LblBase6)
        Me.PnlBase3.Controls.Add(Me.VolgendeFeestdag)
        Me.PnlBase3.Controls.Add(Me.TotBTW)
        Me.PnlBase3.Controls.Add(Me.TotaalEur)
        Me.PnlBase3.Controls.Add(Me.LblBase7)
        Me.PnlBase3.Controls.Add(Me.LblBase15)
        Me.PnlBase3.Controls.Add(Me.Bestellinglijnen)
        Me.PnlBase3.Controls.Add(Me.LblBase16)
        Me.PnlBase3.Location = New System.Drawing.Point(172, 111)
        Me.PnlBase3.Name = "PnlBase3"
        Me.PnlBase3.Size = New System.Drawing.Size(556, 49)
        Me.PnlBase3.TabIndex = 2
        '
        'BetalingTextbox
        '
        Me.BetalingTextbox.fieldLength = 0
        Me.BetalingTextbox.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BetalingTextbox.forceUppercase = True
        Me.BetalingTextbox.ForeColor = System.Drawing.Color.DarkBlue
        Me.BetalingTextbox.lIsSearch = False
        Me.BetalingTextbox.Location = New System.Drawing.Point(239, 20)
        Me.BetalingTextbox.Name = "BetalingTextbox"
        Me.BetalingTextbox.nIO = b040.IOValues.IOAlwaysDisable
        Me.BetalingTextbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.BetalingTextbox.Size = New System.Drawing.Size(131, 28)
        Me.BetalingTextbox.TabIndex = 16
        Me.BetalingTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase3.Location = New System.Drawing.Point(274, 3)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(67, 22)
        Me.LblBase3.TabIndex = 15
        Me.LblBase3.Text = "Betaling"
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase6.Location = New System.Drawing.Point(369, 3)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(142, 22)
        Me.LblBase6.TabIndex = 14
        Me.LblBase6.Text = "Volgende Feestdag"
        '
        'VolgendeFeestdag
        '
        Me.VolgendeFeestdag.fieldLength = 0
        Me.VolgendeFeestdag.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolgendeFeestdag.forceUppercase = True
        Me.VolgendeFeestdag.ForeColor = System.Drawing.Color.DarkBlue
        Me.VolgendeFeestdag.lIsSearch = False
        Me.VolgendeFeestdag.Location = New System.Drawing.Point(369, 20)
        Me.VolgendeFeestdag.Name = "VolgendeFeestdag"
        Me.VolgendeFeestdag.nIO = b040.IOValues.IOAlwaysDisable
        Me.VolgendeFeestdag.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.VolgendeFeestdag.Size = New System.Drawing.Size(182, 28)
        Me.VolgendeFeestdag.TabIndex = 13
        '
        'TotBTW
        '
        Me.TotBTW.fieldLength = 0
        Me.TotBTW.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotBTW.forceUppercase = True
        Me.TotBTW.ForeColor = System.Drawing.Color.DarkBlue
        Me.TotBTW.lIsSearch = False
        Me.TotBTW.Location = New System.Drawing.Point(161, 20)
        Me.TotBTW.Name = "TotBTW"
        Me.TotBTW.nIO = b040.IOValues.IOAlwaysDisable
        Me.TotBTW.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TotBTW.Size = New System.Drawing.Size(78, 28)
        Me.TotBTW.TabIndex = 10
        Me.TotBTW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotaalEur
        '
        Me.TotaalEur.fieldLength = 0
        Me.TotaalEur.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotaalEur.forceUppercase = True
        Me.TotaalEur.ForeColor = System.Drawing.Color.DarkBlue
        Me.TotaalEur.lIsSearch = False
        Me.TotaalEur.Location = New System.Drawing.Point(84, 20)
        Me.TotaalEur.Name = "TotaalEur"
        Me.TotaalEur.nIO = b040.IOValues.IOAlwaysDisable
        Me.TotaalEur.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TotaalEur.Size = New System.Drawing.Size(78, 28)
        Me.TotaalEur.TabIndex = 9
        Me.TotaalEur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblBase7
        '
        Me.LblBase7.AutoSize = True
        Me.LblBase7.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase7.Location = New System.Drawing.Point(165, 3)
        Me.LblBase7.Name = "LblBase7"
        Me.LblBase7.Size = New System.Drawing.Size(90, 22)
        Me.LblBase7.TabIndex = 8
        Me.LblBase7.Text = "Totaal BTW"
        '
        'LblBase15
        '
        Me.LblBase15.AutoSize = True
        Me.LblBase15.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase15.Location = New System.Drawing.Point(89, 3)
        Me.LblBase15.Name = "LblBase15"
        Me.LblBase15.Size = New System.Drawing.Size(80, 22)
        Me.LblBase15.TabIndex = 6
        Me.LblBase15.Text = "Totaal Eur"
        '
        'Bestellinglijnen
        '
        Me.Bestellinglijnen.fieldLength = 0
        Me.Bestellinglijnen.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bestellinglijnen.forceUppercase = True
        Me.Bestellinglijnen.ForeColor = System.Drawing.Color.DarkBlue
        Me.Bestellinglijnen.lIsSearch = False
        Me.Bestellinglijnen.Location = New System.Drawing.Point(3, 20)
        Me.Bestellinglijnen.Name = "Bestellinglijnen"
        Me.Bestellinglijnen.nIO = b040.IOValues.IOAlwaysDisable
        Me.Bestellinglijnen.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Bestellinglijnen.Size = New System.Drawing.Size(78, 28)
        Me.Bestellinglijnen.TabIndex = 0
        Me.Bestellinglijnen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblBase16
        '
        Me.LblBase16.AutoSize = True
        Me.LblBase16.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBase16.Location = New System.Drawing.Point(3, 3)
        Me.LblBase16.Name = "LblBase16"
        Me.LblBase16.Size = New System.Drawing.Size(54, 22)
        Me.LblBase16.TabIndex = 0
        Me.LblBase16.Text = "Lijnen"
        '
        'PnlBase2
        '
        Me.PnlBase2.BackColor = System.Drawing.Color.Silver
        Me.PnlBase2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase2.Controls.Add(Me.KL_Nummer)
        Me.PnlBase2.Controls.Add(Me.LblBase11)
        Me.PnlBase2.Controls.Add(Me.Bediening)
        Me.PnlBase2.Controls.Add(Me.LblBase10)
        Me.PnlBase2.Controls.Add(Me.BestH_KomtHalen)
        Me.PnlBase2.Controls.Add(Me.Adr_Telefoon)
        Me.PnlBase2.Controls.Add(Me.LblBase9)
        Me.PnlBase2.Controls.Add(Me.KL_Naam)
        Me.PnlBase2.Controls.Add(Me.LblBase8)
        Me.PnlBase2.Controls.Add(Me.KlantLbl)
        Me.PnlBase2.Location = New System.Drawing.Point(172, 57)
        Me.PnlBase2.Name = "PnlBase2"
        Me.PnlBase2.Size = New System.Drawing.Size(557, 52)
        Me.PnlBase2.TabIndex = 1
        '
        'KL_Nummer
        '
        Me.KL_Nummer.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "KL_Nummer", True))
        Me.KL_Nummer.fieldLength = 0
        Me.KL_Nummer.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.KL_Nummer.forceUppercase = True
        Me.KL_Nummer.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Nummer.lIsSearch = False
        Me.KL_Nummer.Location = New System.Drawing.Point(5, 24)
        Me.KL_Nummer.Name = "KL_Nummer"
        Me.KL_Nummer.nIO = b040.IOValues.IOKeyEntryEnable
        Me.KL_Nummer.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Nummer.Size = New System.Drawing.Size(55, 28)
        Me.KL_Nummer.TabIndex = 0
        '
        'LblBase11
        '
        Me.LblBase11.AutoSize = True
        Me.LblBase11.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase11.Location = New System.Drawing.Point(434, 7)
        Me.LblBase11.Name = "LblBase11"
        Me.LblBase11.Size = New System.Drawing.Size(89, 23)
        Me.LblBase11.TabIndex = 22
        Me.LblBase11.Text = "Bediening"
        '
        'Bediening
        '
        Me.Bediening.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Bediening.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bediening.ForeColor = System.Drawing.Color.DarkBlue
        Me.Bediening.FormattingEnabled = True
        Me.Bediening.Location = New System.Drawing.Point(431, 23)
        Me.Bediening.Name = "Bediening"
        Me.Bediening.nIO = b040.IOValues.IORecordEntryEnable
        Me.Bediening.setAutocomplete = False
        Me.Bediening.Size = New System.Drawing.Size(121, 29)
        Me.Bediening.TabIndex = 20
        Me.Bediening.TabStop = False
        '
        'LblBase10
        '
        Me.LblBase10.AutoSize = True
        Me.LblBase10.Font = New System.Drawing.Font("Trebuchet MS", 7.0!)
        Me.LblBase10.Location = New System.Drawing.Point(376, 7)
        Me.LblBase10.Name = "LblBase10"
        Me.LblBase10.Size = New System.Drawing.Size(80, 18)
        Me.LblBase10.TabIndex = 21
        Me.LblBase10.Text = "Komt Halen"
        '
        'BestH_KomtHalen
        '
        Me.BestH_KomtHalen.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BestH_KomtHalen", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BestH_KomtHalen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.BestH_KomtHalen.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BestH_KomtHalen.ForeColor = System.Drawing.Color.DarkBlue
        Me.BestH_KomtHalen.FormattingEnabled = True
        Me.BestH_KomtHalen.Location = New System.Drawing.Point(375, 23)
        Me.BestH_KomtHalen.Name = "BestH_KomtHalen"
        Me.BestH_KomtHalen.nIO = b040.IOValues.IORecordEntryEnable
        Me.BestH_KomtHalen.setAutocomplete = False
        Me.BestH_KomtHalen.Size = New System.Drawing.Size(56, 29)
        Me.BestH_KomtHalen.TabIndex = 5
        '
        'Adr_Telefoon
        '
        Me.Adr_Telefoon.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "Adr_Telefoon", True))
        Me.Adr_Telefoon.fieldLength = 0
        Me.Adr_Telefoon.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Adr_Telefoon.forceUppercase = True
        Me.Adr_Telefoon.ForeColor = System.Drawing.Color.DarkBlue
        Me.Adr_Telefoon.lIsSearch = False
        Me.Adr_Telefoon.Location = New System.Drawing.Point(257, 24)
        Me.Adr_Telefoon.Name = "Adr_Telefoon"
        Me.Adr_Telefoon.nIO = b040.IOValues.IOKeyEntryEnable
        Me.Adr_Telefoon.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Adr_Telefoon.Size = New System.Drawing.Size(117, 28)
        Me.Adr_Telefoon.TabIndex = 6
        '
        'LblBase9
        '
        Me.LblBase9.AutoSize = True
        Me.LblBase9.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase9.Location = New System.Drawing.Point(256, 6)
        Me.LblBase9.Name = "LblBase9"
        Me.LblBase9.Size = New System.Drawing.Size(30, 22)
        Me.LblBase9.TabIndex = 19
        Me.LblBase9.Text = "Tel"
        '
        'KL_Naam
        '
        Me.KL_Naam.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "KL_Naam", True))
        Me.KL_Naam.fieldLength = 0
        Me.KL_Naam.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.KL_Naam.forceUppercase = True
        Me.KL_Naam.ForeColor = System.Drawing.Color.DarkBlue
        Me.KL_Naam.lIsSearch = False
        Me.KL_Naam.Location = New System.Drawing.Point(59, 24)
        Me.KL_Naam.Name = "KL_Naam"
        Me.KL_Naam.nIO = b040.IOValues.IOAlwaysDisable
        Me.KL_Naam.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.KL_Naam.Size = New System.Drawing.Size(198, 28)
        Me.KL_Naam.TabIndex = 18
        '
        'LblBase8
        '
        Me.LblBase8.AutoSize = True
        Me.LblBase8.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase8.Location = New System.Drawing.Point(59, 7)
        Me.LblBase8.Name = "LblBase8"
        Me.LblBase8.Size = New System.Drawing.Size(49, 22)
        Me.LblBase8.TabIndex = 17
        Me.LblBase8.Text = "Naam"
        '
        'KlantLbl
        '
        Me.KlantLbl.AutoSize = True
        Me.KlantLbl.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.KlantLbl.Location = New System.Drawing.Point(6, 6)
        Me.KlantLbl.Name = "KlantLbl"
        Me.KlantLbl.Size = New System.Drawing.Size(45, 22)
        Me.KlantLbl.TabIndex = 15
        Me.KlantLbl.Text = "Klant"
        '
        'SaveAsStandaard
        '
        Me.SaveAsStandaard.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.SaveAsStandaard.Image = Global.b040.My.Resources.Resources.save
        Me.SaveAsStandaard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveAsStandaard.Location = New System.Drawing.Point(964, 584)
        Me.SaveAsStandaard.Name = "SaveAsStandaard"
        Me.SaveAsStandaard.nIO = b040.IOValues.IORecordEntryEnable
        Me.SaveAsStandaard.Size = New System.Drawing.Size(160, 23)
        Me.SaveAsStandaard.TabIndex = 2
        Me.SaveAsStandaard.TabStop = False
        Me.SaveAsStandaard.Text = "als Standaard (^S)"
        Me.SaveAsStandaard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveAsStandaard.UseVisualStyleBackColor = True
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.LblNrLevering)
        Me.PnlBase1.Controls.Add(Me.TxtNrLevering)
        Me.PnlBase1.Controls.Add(Me.LblBase5)
        Me.PnlBase1.Controls.Add(Me.BestH_UurLevering)
        Me.PnlBase1.Controls.Add(Me.LblBase4)
        Me.PnlBase1.Controls.Add(Me.BestH_DatLevering)
        Me.PnlBase1.Controls.Add(Me.DagLevering)
        Me.PnlBase1.Controls.Add(Me.lblDag)
        Me.PnlBase1.Location = New System.Drawing.Point(171, 5)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(299, 49)
        Me.PnlBase1.TabIndex = 1
        '
        'LblNrLevering
        '
        Me.LblNrLevering.AutoSize = True
        Me.LblNrLevering.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblNrLevering.Location = New System.Drawing.Point(226, 4)
        Me.LblNrLevering.Name = "LblNrLevering"
        Me.LblNrLevering.Size = New System.Drawing.Size(109, 22)
        Me.LblNrLevering.TabIndex = 11
        Me.LblNrLevering.Text = "Volgende Lev."
        '
        'TxtNrLevering
        '
        Me.TxtNrLevering.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt
        Me.TxtNrLevering.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BestH_UurLevering", True))
        Me.TxtNrLevering.fieldLength = 0
        Me.TxtNrLevering.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtNrLevering.forceUppercase = True
        Me.TxtNrLevering.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtNrLevering.lIsSearch = False
        Me.TxtNrLevering.Location = New System.Drawing.Point(227, 21)
        Me.TxtNrLevering.Name = "TxtNrLevering"
        Me.TxtNrLevering.nIO = b040.IOValues.IOAlwaysDisable
        Me.TxtNrLevering.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtNrLevering.Size = New System.Drawing.Size(64, 28)
        Me.TxtNrLevering.TabIndex = 12
        Me.TxtNrLevering.TabStop = False
        Me.TxtNrLevering.ValidatingType = GetType(Date)
        '
        'LblBase5
        '
        Me.LblBase5.AutoSize = True
        Me.LblBase5.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase5.Location = New System.Drawing.Point(160, 4)
        Me.LblBase5.Name = "LblBase5"
        Me.LblBase5.Size = New System.Drawing.Size(101, 22)
        Me.LblBase5.TabIndex = 0
        Me.LblBase5.Text = "Uur Levering"
        '
        'BestH_UurLevering
        '
        Me.BestH_UurLevering.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BestH_UurLevering", True))
        Me.BestH_UurLevering.fieldLength = 0
        Me.BestH_UurLevering.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BestH_UurLevering.forceUppercase = True
        Me.BestH_UurLevering.ForeColor = System.Drawing.Color.DarkBlue
        Me.BestH_UurLevering.lIsSearch = False
        Me.BestH_UurLevering.Location = New System.Drawing.Point(161, 21)
        Me.BestH_UurLevering.Name = "BestH_UurLevering"
        Me.BestH_UurLevering.nIO = b040.IOValues.IORecordEntryEnable
        Me.BestH_UurLevering.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.BestH_UurLevering.Size = New System.Drawing.Size(64, 28)
        Me.BestH_UurLevering.TabIndex = 3
        Me.BestH_UurLevering.TabStop = False
        Me.BestH_UurLevering.ValidatingType = GetType(Date)
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.LblBase4.Location = New System.Drawing.Point(90, 4)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(107, 22)
        Me.LblBase4.TabIndex = 10
        Me.LblBase4.Text = "Dat. Levering"
        '
        'BestH_DatLevering
        '
        Me.BestH_DatLevering.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BestH_DatLevering", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BestH_DatLevering.fieldLength = 0
        Me.BestH_DatLevering.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BestH_DatLevering.forceUppercase = True
        Me.BestH_DatLevering.ForeColor = System.Drawing.Color.DarkBlue
        Me.BestH_DatLevering.HideSelection = False
        Me.BestH_DatLevering.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.BestH_DatLevering.lIsSearch = False
        Me.BestH_DatLevering.Location = New System.Drawing.Point(94, 21)
        Me.BestH_DatLevering.Name = "BestH_DatLevering"
        Me.BestH_DatLevering.nIO = b040.IOValues.IOAlwaysDisable
        Me.BestH_DatLevering.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.BestH_DatLevering.Size = New System.Drawing.Size(66, 28)
        Me.BestH_DatLevering.TabIndex = 0
        '
        'DagLevering
        '
        Me.DagLevering.fieldLength = 0
        Me.DagLevering.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DagLevering.forceUppercase = True
        Me.DagLevering.ForeColor = System.Drawing.Color.DarkBlue
        Me.DagLevering.lIsSearch = False
        Me.DagLevering.Location = New System.Drawing.Point(5, 21)
        Me.DagLevering.Name = "DagLevering"
        Me.DagLevering.nIO = b040.IOValues.IOAlwaysDisable
        Me.DagLevering.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.DagLevering.Size = New System.Drawing.Size(88, 28)
        Me.DagLevering.TabIndex = 1
        Me.DagLevering.TabStop = False
        '
        'lblDag
        '
        Me.lblDag.AutoSize = True
        Me.lblDag.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        Me.lblDag.Location = New System.Drawing.Point(4, 4)
        Me.lblDag.Name = "lblDag"
        Me.lblDag.Size = New System.Drawing.Size(103, 22)
        Me.lblDag.TabIndex = 8
        Me.lblDag.Text = "Dag Levering"
        '
        'grdBestelD
        '
        Me.grdBestelD.AutoGenerateColumns = False
        Me.grdBestelD.BackgroundColor = System.Drawing.Color.White
        Me.grdBestelD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdBestelD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdBestelD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBestelD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BestDIDDataGridViewTextBoxColumn, Me.BestDBestHDataGridViewTextBoxColumn, Me.BestDIsStandaardDataGridViewCheckBoxColumn, Me.BestDArtikelDataGridViewTextBoxColumn, Me.Art_Nr, Me.Omschrijving, Me.BestD_Snijden, Me.Tour, Me.BestD_Portie, Me.Standaard, Me.BestD_Hoev1, Me.Eenh_HoevInvoer, Me.BestD_EenhPrijs, Me.Eenh_omschrijving, Me.BestD_Waarde, Me.voorafdrukken, Me.BestD_Verwittigen, Me.BestD_Opschrift, Me.BestD_Boodschap, Me.colArtNrBound})
        Me.grdBestelD.DataSource = Me.BestelDBS
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBestelD.DefaultCellStyle = DataGridViewCellStyle8
        Me.grdBestelD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grdBestelD.GridColor = System.Drawing.Color.Silver
        Me.grdBestelD.lKeepHighlightOnLostFocus = False
        Me.grdBestelD.Location = New System.Drawing.Point(1, 167)
        Me.grdBestelD.MultiSelect = False
        Me.grdBestelD.Name = "grdBestelD"
        Me.grdBestelD.nIO = b040.IOValues.IORecordEntryEnable
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdBestelD.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grdBestelD.RowHeadersVisible = False
        Me.grdBestelD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdBestelD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdBestelD.Size = New System.Drawing.Size(969, 507)
        Me.grdBestelD.TabIndex = 4
        '
        'BestDIDDataGridViewTextBoxColumn
        '
        Me.BestDIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BestDIDDataGridViewTextBoxColumn.DataPropertyName = "BestD_ID"
        Me.BestDIDDataGridViewTextBoxColumn.FillWeight = 8.0!
        Me.BestDIDDataGridViewTextBoxColumn.HeaderText = "BestD_ID"
        Me.BestDIDDataGridViewTextBoxColumn.MaxInputLength = 10
        Me.BestDIDDataGridViewTextBoxColumn.Name = "BestDIDDataGridViewTextBoxColumn"
        Me.BestDIDDataGridViewTextBoxColumn.Visible = False
        Me.BestDIDDataGridViewTextBoxColumn.Width = 40
        '
        'BestDBestHDataGridViewTextBoxColumn
        '
        Me.BestDBestHDataGridViewTextBoxColumn.DataPropertyName = "BestD_BestH"
        Me.BestDBestHDataGridViewTextBoxColumn.HeaderText = "BestD_BestH"
        Me.BestDBestHDataGridViewTextBoxColumn.Name = "BestDBestHDataGridViewTextBoxColumn"
        Me.BestDBestHDataGridViewTextBoxColumn.Visible = False
        '
        'BestDIsStandaardDataGridViewCheckBoxColumn
        '
        Me.BestDIsStandaardDataGridViewCheckBoxColumn.DataPropertyName = "BestD_IsStandaard"
        Me.BestDIsStandaardDataGridViewCheckBoxColumn.HeaderText = "BestD_IsStandaard"
        Me.BestDIsStandaardDataGridViewCheckBoxColumn.Name = "BestDIsStandaardDataGridViewCheckBoxColumn"
        Me.BestDIsStandaardDataGridViewCheckBoxColumn.Visible = False
        '
        'BestDArtikelDataGridViewTextBoxColumn
        '
        Me.BestDArtikelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BestDArtikelDataGridViewTextBoxColumn.DataPropertyName = "BestD_Artikel"
        Me.BestDArtikelDataGridViewTextBoxColumn.FillWeight = 9.0!
        Me.BestDArtikelDataGridViewTextBoxColumn.HeaderText = "ArtikelPK"
        Me.BestDArtikelDataGridViewTextBoxColumn.Name = "BestDArtikelDataGridViewTextBoxColumn"
        Me.BestDArtikelDataGridViewTextBoxColumn.Visible = False
        '
        'Art_Nr
        '
        Me.Art_Nr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Art_Nr.DefaultCellStyle = DataGridViewCellStyle2
        Me.Art_Nr.FillWeight = 8.0!
        Me.Art_Nr.HeaderText = "Artikel"
        Me.Art_Nr.Name = "Art_Nr"
        Me.Art_Nr.Width = 75
        '
        'Omschrijving
        '
        Me.Omschrijving.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Omschrijving.DataPropertyName = "BestD_Omschrijving"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Omschrijving.DefaultCellStyle = DataGridViewCellStyle3
        Me.Omschrijving.FillWeight = 20.0!
        Me.Omschrijving.HeaderText = "Omschrijving"
        Me.Omschrijving.Name = "Omschrijving"
        '
        'BestD_Snijden
        '
        Me.BestD_Snijden.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.BestD_Snijden.DataPropertyName = "BestD_Snijden"
        Me.BestD_Snijden.FalseValue = "false"
        Me.BestD_Snijden.FillWeight = 5.210855!
        Me.BestD_Snijden.HeaderText = "Sn."
        Me.BestD_Snijden.IndeterminateValue = "false"
        Me.BestD_Snijden.Name = "BestD_Snijden"
        Me.BestD_Snijden.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BestD_Snijden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BestD_Snijden.TrueValue = "true"
        Me.BestD_Snijden.Width = 72
        '
        'Tour
        '
        Me.Tour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Tour.DataPropertyName = "BestD_Tour"
        Me.Tour.FillWeight = 5.210855!
        Me.Tour.HeaderText = "Tr"
        Me.Tour.Name = "Tour"
        Me.Tour.Width = 61
        '
        'BestD_Portie
        '
        Me.BestD_Portie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.BestD_Portie.DataPropertyName = "BestD_Portie"
        Me.BestD_Portie.FillWeight = 5.210855!
        Me.BestD_Portie.HeaderText = "Portie"
        Me.BestD_Portie.Name = "BestD_Portie"
        Me.BestD_Portie.Visible = False
        '
        'Standaard
        '
        Me.Standaard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Standaard.DataPropertyName = "BestD_Hoev"
        Me.Standaard.FillWeight = 10.42171!
        Me.Standaard.HeaderText = "Stand."
        Me.Standaard.Name = "Standaard"
        Me.Standaard.Width = 75
        '
        'BestD_Hoev1
        '
        Me.BestD_Hoev1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BestD_Hoev1.DataPropertyName = "BestD_Hoev1"
        Me.BestD_Hoev1.FillWeight = 10.42171!
        Me.BestD_Hoev1.HeaderText = "Bestel"
        Me.BestD_Hoev1.Name = "BestD_Hoev1"
        Me.BestD_Hoev1.Width = 75
        '
        'Eenh_HoevInvoer
        '
        Me.Eenh_HoevInvoer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Eenh_HoevInvoer.DataPropertyName = "Eenh_HoevInvoer"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eenh_HoevInvoer.DefaultCellStyle = DataGridViewCellStyle4
        Me.Eenh_HoevInvoer.FillWeight = 8.0!
        Me.Eenh_HoevInvoer.HeaderText = ""
        Me.Eenh_HoevInvoer.MaxInputLength = 10
        Me.Eenh_HoevInvoer.Name = "Eenh_HoevInvoer"
        Me.Eenh_HoevInvoer.Width = 40
        '
        'BestD_EenhPrijs
        '
        Me.BestD_EenhPrijs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BestD_EenhPrijs.DataPropertyName = "BestD_EenhPrijs"
        Me.BestD_EenhPrijs.FillWeight = 10.42171!
        Me.BestD_EenhPrijs.HeaderText = "  Prijs  "
        Me.BestD_EenhPrijs.Name = "BestD_EenhPrijs"
        Me.BestD_EenhPrijs.Width = 75
        '
        'Eenh_omschrijving
        '
        Me.Eenh_omschrijving.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Eenh_omschrijving.DataPropertyName = "Eenh_omschrijving"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Eenh_omschrijving.DefaultCellStyle = DataGridViewCellStyle5
        Me.Eenh_omschrijving.FillWeight = 8.0!
        Me.Eenh_omschrijving.HeaderText = ""
        Me.Eenh_omschrijving.MaxInputLength = 10
        Me.Eenh_omschrijving.Name = "Eenh_omschrijving"
        Me.Eenh_omschrijving.Width = 40
        '
        'BestD_Waarde
        '
        Me.BestD_Waarde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BestD_Waarde.DataPropertyName = "BestD_Waarde"
        Me.BestD_Waarde.FillWeight = 15.0!
        Me.BestD_Waarde.HeaderText = "   Waarde   "
        Me.BestD_Waarde.Name = "BestD_Waarde"
        '
        'voorafdrukken
        '
        Me.voorafdrukken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.voorafdrukken.DataPropertyName = "bestd_voorafdrukken"
        Me.voorafdrukken.HeaderText = "Epson"
        Me.voorafdrukken.Name = "voorafdrukken"
        Me.voorafdrukken.Width = 40
        '
        'BestD_Verwittigen
        '
        Me.BestD_Verwittigen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.BestD_Verwittigen.DataPropertyName = "BestD_Verwittigen"
        Me.BestD_Verwittigen.FillWeight = 5.210855!
        Me.BestD_Verwittigen.HeaderText = "Verwit."
        Me.BestD_Verwittigen.Name = "BestD_Verwittigen"
        Me.BestD_Verwittigen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BestD_Verwittigen.Visible = False
        '
        'BestD_Opschrift
        '
        Me.BestD_Opschrift.DataPropertyName = "BestD_Opschrift"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.BestD_Opschrift.DefaultCellStyle = DataGridViewCellStyle6
        Me.BestD_Opschrift.FillWeight = 20.0!
        Me.BestD_Opschrift.HeaderText = "Opschrift"
        Me.BestD_Opschrift.Name = "BestD_Opschrift"
        Me.BestD_Opschrift.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BestD_Opschrift.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BestD_Opschrift.Visible = False
        Me.BestD_Opschrift.Width = 200
        '
        'BestD_Boodschap
        '
        Me.BestD_Boodschap.DataPropertyName = "BestD_Boodschap"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.BestD_Boodschap.DefaultCellStyle = DataGridViewCellStyle7
        Me.BestD_Boodschap.FillWeight = 20.0!
        Me.BestD_Boodschap.HeaderText = "Boodschap"
        Me.BestD_Boodschap.Name = "BestD_Boodschap"
        Me.BestD_Boodschap.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BestD_Boodschap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BestD_Boodschap.Visible = False
        Me.BestD_Boodschap.Width = 5
        '
        'colArtNrBound
        '
        Me.colArtNrBound.DataPropertyName = "Art_Nr"
        Me.colArtNrBound.HeaderText = "colArtNrBound"
        Me.colArtNrBound.Name = "colArtNrBound"
        Me.colArtNrBound.Visible = False
        '
        'DsOpschriftenBindingSource
        '
        Me.DsOpschriftenBindingSource.DataSource = Me.DsOpschriften
        Me.DsOpschriftenBindingSource.Position = 0
        '
        'DsOpschriften
        '
        Me.DsOpschriften.DataSetName = "dsOpschriften"
        Me.DsOpschriften.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PnlBase5)
        Me.TabPage1.Controls.Add(Me.PnlBase4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 32)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1129, 674)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Document"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PnlBase5
        '
        Me.PnlBase5.BackColor = System.Drawing.Color.Silver
        Me.PnlBase5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase5.Controls.Add(Me.LblBase2)
        Me.PnlBase5.Controls.Add(Me.LblBase1)
        Me.PnlBase5.Controls.Add(Me.txtBestH_DatBest2)
        Me.PnlBase5.Controls.Add(Me.lblDate)
        Me.PnlBase5.Location = New System.Drawing.Point(879, 544)
        Me.PnlBase5.Name = "PnlBase5"
        Me.PnlBase5.Size = New System.Drawing.Size(253, 59)
        Me.PnlBase5.TabIndex = 39
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase2.Location = New System.Drawing.Point(3, 33)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(147, 23)
        Me.LblBase2.TabIndex = 8
        Me.LblBase2.Text = "Datum Document"
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase1.Location = New System.Drawing.Point(3, 10)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(133, 23)
        Me.LblBase1.TabIndex = 7
        Me.LblBase1.Text = "Type Transactie"
        '
        'txtBestH_DatBest2
        '
        Me.txtBestH_DatBest2.fieldLength = 0
        Me.txtBestH_DatBest2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtBestH_DatBest2.forceUppercase = True
        Me.txtBestH_DatBest2.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtBestH_DatBest2.lIsSearch = False
        Me.txtBestH_DatBest2.Location = New System.Drawing.Point(135, 26)
        Me.txtBestH_DatBest2.Name = "txtBestH_DatBest2"
        Me.txtBestH_DatBest2.nIO = b040.IOValues.IOAlwaysEnable
        Me.txtBestH_DatBest2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtBestH_DatBest2.Size = New System.Drawing.Size(100, 28)
        Me.txtBestH_DatBest2.TabIndex = 0
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.lblDate.Location = New System.Drawing.Point(135, 10)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(61, 23)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Datum"
        '
        'PnlBase4
        '
        Me.PnlBase4.BackColor = System.Drawing.Color.Silver
        Me.PnlBase4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase4.Controls.Add(Me.btnVerwijderDocument)
        Me.PnlBase4.Controls.Add(Me.txtBestH_DatLeveing2)
        Me.PnlBase4.Controls.Add(Me.lblDatLeving)
        Me.PnlBase4.Controls.Add(Me.BestH_Docnr)
        Me.PnlBase4.Controls.Add(Me.LblBase20)
        Me.PnlBase4.Location = New System.Drawing.Point(30, 18)
        Me.PnlBase4.Name = "PnlBase4"
        Me.PnlBase4.Size = New System.Drawing.Size(257, 86)
        Me.PnlBase4.TabIndex = 36
        '
        'btnVerwijderDocument
        '
        Me.btnVerwijderDocument.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnVerwijderDocument.Image = CType(resources.GetObject("btnVerwijderDocument.Image"), System.Drawing.Image)
        Me.btnVerwijderDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerwijderDocument.Location = New System.Drawing.Point(6, 51)
        Me.btnVerwijderDocument.Name = "btnVerwijderDocument"
        Me.btnVerwijderDocument.nIO = b040.IOValues.IORecordEntryEnable
        Me.btnVerwijderDocument.Size = New System.Drawing.Size(106, 23)
        Me.btnVerwijderDocument.TabIndex = 38
        Me.btnVerwijderDocument.TabStop = False
        Me.btnVerwijderDocument.Text = "Verwijderen Document"
        Me.btnVerwijderDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerwijderDocument.UseVisualStyleBackColor = True
        '
        'txtBestH_DatLeveing2
        '
        Me.txtBestH_DatLeveing2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BestH_DatLevering", True))
        Me.txtBestH_DatLeveing2.fieldLength = 0
        Me.txtBestH_DatLeveing2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtBestH_DatLeveing2.forceUppercase = True
        Me.txtBestH_DatLeveing2.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtBestH_DatLeveing2.lIsSearch = False
        Me.txtBestH_DatLeveing2.Location = New System.Drawing.Point(121, 25)
        Me.txtBestH_DatLeveing2.Name = "txtBestH_DatLeveing2"
        Me.txtBestH_DatLeveing2.nIO = b040.IOValues.IOAlwaysDisable
        Me.txtBestH_DatLeveing2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtBestH_DatLeveing2.Size = New System.Drawing.Size(125, 28)
        Me.txtBestH_DatLeveing2.TabIndex = 8
        '
        'lblDatLeving
        '
        Me.lblDatLeving.AutoSize = True
        Me.lblDatLeving.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.lblDatLeving.Location = New System.Drawing.Point(3, 28)
        Me.lblDatLeving.Name = "lblDatLeving"
        Me.lblDatLeving.Size = New System.Drawing.Size(135, 23)
        Me.lblDatLeving.TabIndex = 7
        Me.lblDatLeving.Text = "Datum Levering"
        '
        'BestH_Docnr
        '
        Me.BestH_Docnr.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BestelHBS, "BEstH_DocNr", True))
        Me.BestH_Docnr.fieldLength = 0
        Me.BestH_Docnr.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BestH_Docnr.forceUppercase = True
        Me.BestH_Docnr.ForeColor = System.Drawing.Color.DarkBlue
        Me.BestH_Docnr.lIsSearch = False
        Me.BestH_Docnr.Location = New System.Drawing.Point(121, 4)
        Me.BestH_Docnr.Name = "BestH_Docnr"
        Me.BestH_Docnr.nIO = b040.IOValues.IOKeyEntryEnable
        Me.BestH_Docnr.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.BestH_Docnr.Size = New System.Drawing.Size(125, 28)
        Me.BestH_Docnr.TabIndex = 0
        '
        'LblBase20
        '
        Me.LblBase20.AutoSize = True
        Me.LblBase20.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.LblBase20.Location = New System.Drawing.Point(3, 8)
        Me.LblBase20.Name = "LblBase20"
        Me.LblBase20.Size = New System.Drawing.Size(58, 23)
        Me.LblBase20.TabIndex = 0
        Me.LblBase20.Text = "DocNr"
        '
        'bestelTabpage
        '
        Me.bestelTabpage.Controls.Add(Me.TabPage2)
        Me.bestelTabpage.Controls.Add(Me.TabPage1)
        Me.bestelTabpage.Controls.Add(Me.TabPage3)
        Me.bestelTabpage.Controls.Add(Me.TabPage4)
        Me.bestelTabpage.Controls.Add(Me.particulierenTabPage)
        Me.bestelTabpage.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.bestelTabpage.Location = New System.Drawing.Point(5, 1)
        Me.bestelTabpage.Name = "bestelTabpage"
        Me.bestelTabpage.SelectedIndex = 0
        Me.bestelTabpage.Size = New System.Drawing.Size(1137, 710)
        Me.bestelTabpage.TabIndex = 99
        Me.bestelTabpage.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.AdresG)
        Me.TabPage3.Location = New System.Drawing.Point(4, 32)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1129, 674)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Adres"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'AdresG
        '
        Me.AdresG.AllowUserToOrderColumns = True
        Me.AdresG.AutoGenerateColumns = False
        Me.AdresG.BackgroundColor = System.Drawing.Color.White
        Me.AdresG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AdresG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.AdresG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AdresG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Adr_Adres, Me.Adr_PostNummer, Me.Adr_Gemeente, Me.Adr_Land, Me.AdrFacturatieDataGridViewCheckBoxColumn, Me.Adr_id, Me.Kies})
        Me.AdresG.DataSource = Me.AdresBS
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AdresG.DefaultCellStyle = DataGridViewCellStyle11
        Me.AdresG.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.AdresG.GridColor = System.Drawing.Color.LightGray
        Me.AdresG.lKeepHighlightOnLostFocus = False
        Me.AdresG.Location = New System.Drawing.Point(6, 6)
        Me.AdresG.Name = "AdresG"
        Me.AdresG.nIO = b040.IOValues.IORecordEntryEnable
        Me.AdresG.RowHeadersVisible = False
        Me.AdresG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.AdresG.Size = New System.Drawing.Size(548, 110)
        Me.AdresG.TabIndex = 24
        '
        'Adr_Adres
        '
        Me.Adr_Adres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Adr_Adres.DataPropertyName = "Adr_Adres"
        Me.Adr_Adres.FillWeight = 20.0!
        Me.Adr_Adres.HeaderText = "Adres"
        Me.Adr_Adres.Name = "Adr_Adres"
        '
        'Adr_PostNummer
        '
        Me.Adr_PostNummer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Adr_PostNummer.DataPropertyName = "Adr_PostNummer"
        Me.Adr_PostNummer.FillWeight = 9.0!
        Me.Adr_PostNummer.HeaderText = "PostNr"
        Me.Adr_PostNummer.Name = "Adr_PostNummer"
        '
        'Adr_Gemeente
        '
        Me.Adr_Gemeente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Adr_Gemeente.DataPropertyName = "Adr_Gemeente"
        Me.Adr_Gemeente.FillWeight = 20.0!
        Me.Adr_Gemeente.HeaderText = "Gemeente"
        Me.Adr_Gemeente.Name = "Adr_Gemeente"
        '
        'Adr_Land
        '
        Me.Adr_Land.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Adr_Land.DataPropertyName = "Adr_Land"
        Me.Adr_Land.FillWeight = 20.0!
        Me.Adr_Land.HeaderText = "Land"
        Me.Adr_Land.Name = "Adr_Land"
        '
        'AdrFacturatieDataGridViewCheckBoxColumn
        '
        Me.AdrFacturatieDataGridViewCheckBoxColumn.DataPropertyName = "Adr_Facturatie"
        Me.AdrFacturatieDataGridViewCheckBoxColumn.HeaderText = "Adr_Facturatie"
        Me.AdrFacturatieDataGridViewCheckBoxColumn.Name = "AdrFacturatieDataGridViewCheckBoxColumn"
        Me.AdrFacturatieDataGridViewCheckBoxColumn.Visible = False
        '
        'Adr_id
        '
        Me.Adr_id.DataPropertyName = "Adr_id"
        Me.Adr_id.HeaderText = "AdridDataGridViewTextBoxColumn"
        Me.Adr_id.Name = "Adr_id"
        Me.Adr_id.Visible = False
        '
        'Kies
        '
        Me.Kies.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Kies.FillWeight = 5.0!
        Me.Kies.HeaderText = "Kies"
        Me.Kies.Name = "Kies"
        Me.Kies.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Kies.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.overzichtGobottomButton)
        Me.TabPage4.Controls.Add(Me.overzichtGotopButton)
        Me.TabPage4.Controls.Add(Me.grdHistory)
        Me.TabPage4.Location = New System.Drawing.Point(4, 32)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1129, 674)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Overzicht (^O)"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'overzichtGobottomButton
        '
        Me.overzichtGobottomButton.BackColor = System.Drawing.Color.Transparent
        Me.overzichtGobottomButton.Image = Global.b040.My.Resources.Resources.down
        Me.overzichtGobottomButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.overzichtGobottomButton.Location = New System.Drawing.Point(173, 654)
        Me.overzichtGobottomButton.Name = "overzichtGobottomButton"
        Me.overzichtGobottomButton.Size = New System.Drawing.Size(189, 23)
        Me.overzichtGobottomButton.TabIndex = 47
        Me.overzichtGobottomButton.Text = "Naar Laatste Lijn ([^Dn)"
        Me.overzichtGobottomButton.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.overzichtGobottomButton.UseVisualStyleBackColor = False
        '
        'overzichtGotopButton
        '
        Me.overzichtGotopButton.Image = Global.b040.My.Resources.Resources.up
        Me.overzichtGotopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.overzichtGotopButton.Location = New System.Drawing.Point(6, 654)
        Me.overzichtGotopButton.Name = "overzichtGotopButton"
        Me.overzichtGotopButton.Size = New System.Drawing.Size(159, 23)
        Me.overzichtGotopButton.TabIndex = 46
        Me.overzichtGotopButton.Text = "Naar Eerste Lijn (^Up)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ")"
        Me.overzichtGotopButton.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.overzichtGotopButton.UseVisualStyleBackColor = True
        '
        'grdHistory
        '
        Me.grdHistory.AllowUserToAddRows = False
        Me.grdHistory.AllowUserToDeleteRows = False
        Me.grdHistory.BackgroundColor = System.Drawing.Color.Beige
        Me.grdHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.grdHistory.ColumnHeadersHeight = 21
        Me.grdHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Beige
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Beige
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdHistory.DefaultCellStyle = DataGridViewCellStyle13
        Me.grdHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grdHistory.GridColor = System.Drawing.Color.LightGray
        Me.grdHistory.Location = New System.Drawing.Point(0, 6)
        Me.grdHistory.MultiSelect = False
        Me.grdHistory.Name = "grdHistory"
        Me.grdHistory.RowHeadersVisible = False
        Me.grdHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdHistory.Size = New System.Drawing.Size(685, 642)
        Me.grdHistory.TabIndex = 41
        '
        'particulierenTabPage
        '
        Me.particulierenTabPage.Controls.Add(Me.particulierenOverzichtDatagridview)
        Me.particulierenTabPage.Controls.Add(Me.particulierenGobottomButton)
        Me.particulierenTabPage.Controls.Add(Me.particulierenGotopButton)
        Me.particulierenTabPage.Location = New System.Drawing.Point(4, 32)
        Me.particulierenTabPage.Name = "particulierenTabPage"
        Me.particulierenTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.particulierenTabPage.Size = New System.Drawing.Size(1129, 674)
        Me.particulierenTabPage.TabIndex = 4
        Me.particulierenTabPage.Text = "Particulieren (^T)"
        Me.particulierenTabPage.UseVisualStyleBackColor = True
        '
        'particulierenOverzichtDatagridview
        '
        Me.particulierenOverzichtDatagridview.AllowUserToAddRows = False
        Me.particulierenOverzichtDatagridview.AllowUserToDeleteRows = False
        Me.particulierenOverzichtDatagridview.BackgroundColor = System.Drawing.Color.Beige
        Me.particulierenOverzichtDatagridview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.particulierenOverzichtDatagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.particulierenOverzichtDatagridview.ColumnHeadersHeight = 21
        Me.particulierenOverzichtDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.Beige
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Beige
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.particulierenOverzichtDatagridview.DefaultCellStyle = DataGridViewCellStyle15
        Me.particulierenOverzichtDatagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.particulierenOverzichtDatagridview.GridColor = System.Drawing.Color.LightGray
        Me.particulierenOverzichtDatagridview.Location = New System.Drawing.Point(7, 6)
        Me.particulierenOverzichtDatagridview.MultiSelect = False
        Me.particulierenOverzichtDatagridview.Name = "particulierenOverzichtDatagridview"
        Me.particulierenOverzichtDatagridview.RowHeadersVisible = False
        Me.particulierenOverzichtDatagridview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.particulierenOverzichtDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.particulierenOverzichtDatagridview.Size = New System.Drawing.Size(685, 642)
        Me.particulierenOverzichtDatagridview.TabIndex = 46
        '
        'particulierenGobottomButton
        '
        Me.particulierenGobottomButton.BackColor = System.Drawing.Color.Transparent
        Me.particulierenGobottomButton.Image = Global.b040.My.Resources.Resources.down
        Me.particulierenGobottomButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.particulierenGobottomButton.Location = New System.Drawing.Point(164, 654)
        Me.particulierenGobottomButton.Name = "particulierenGobottomButton"
        Me.particulierenGobottomButton.Size = New System.Drawing.Size(161, 23)
        Me.particulierenGobottomButton.TabIndex = 45
        Me.particulierenGobottomButton.Text = "Naar Laatste Lijn (^Dn)"
        Me.particulierenGobottomButton.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.particulierenGobottomButton.UseVisualStyleBackColor = False
        '
        'particulierenGotopButton
        '
        Me.particulierenGotopButton.Image = Global.b040.My.Resources.Resources.up
        Me.particulierenGotopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.particulierenGotopButton.Location = New System.Drawing.Point(7, 654)
        Me.particulierenGotopButton.Name = "particulierenGotopButton"
        Me.particulierenGotopButton.Size = New System.Drawing.Size(151, 23)
        Me.particulierenGotopButton.TabIndex = 43
        Me.particulierenGotopButton.Text = "Naar Eerste Lijn (^Up)"
        Me.particulierenGotopButton.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.particulierenGotopButton.UseVisualStyleBackColor = True
        '
        'CloseBtn
        '
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.CloseBtn.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.CloseBtn.Image = CType(resources.GetObject("CloseBtn.Image"), System.Drawing.Image)
        Me.CloseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CloseBtn.Location = New System.Drawing.Point(1072, 714)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.nIO = b040.IOValues.IOAlwaysEnable
        Me.CloseBtn.Size = New System.Drawing.Size(68, 23)
        Me.CloseBtn.TabIndex = 27
        Me.CloseBtn.TabStop = False
        Me.CloseBtn.Text = "Sluit"
        Me.CloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'BtnToggle
        '
        Me.BtnToggle.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.BtnToggle.Image = Global.b040.My.Resources.Resources._1306699260_42
        Me.BtnToggle.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnToggle.Location = New System.Drawing.Point(270, 713)
        Me.BtnToggle.Name = "BtnToggle"
        Me.BtnToggle.nIO = b040.IOValues.IOKeyEntryEnable
        Me.BtnToggle.Size = New System.Drawing.Size(123, 23)
        Me.BtnToggle.TabIndex = 32
        Me.BtnToggle.TabStop = False
        Me.BtnToggle.Text = "Bestelling (^B)"
        Me.BtnToggle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnToggle.UseVisualStyleBackColor = True
        '
        'InsertButton
        '
        Me.InsertButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.InsertButton.Image = CType(resources.GetObject("InsertButton.Image"), System.Drawing.Image)
        Me.InsertButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InsertButton.Location = New System.Drawing.Point(396, 713)
        Me.InsertButton.Name = "InsertButton"
        Me.InsertButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.InsertButton.Size = New System.Drawing.Size(139, 23)
        Me.InsertButton.TabIndex = 29
        Me.InsertButton.TabStop = False
        Me.InsertButton.Text = "Tussenvoegen (^T)"
        Me.InsertButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.InsertButton.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(965, 714)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.nIO = b040.IOValues.IORecordEntryEnable
        Me.btnDelete.Size = New System.Drawing.Size(100, 23)
        Me.btnDelete.TabIndex = 28
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Verwijderen (F4)"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Image = CType(resources.GetObject("SaveButton.Image"), System.Drawing.Image)
        Me.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveButton.Location = New System.Drawing.Point(4, 713)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.SaveButton.Size = New System.Drawing.Size(114, 23)
        Me.SaveButton.TabIndex = 1
        Me.SaveButton.Text = "Bewaar (End)"
        Me.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'BewaarEnBlijf
        '
        Me.BewaarEnBlijf.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BewaarEnBlijf.Image = CType(resources.GetObject("BewaarEnBlijf.Image"), System.Drawing.Image)
        Me.BewaarEnBlijf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BewaarEnBlijf.Location = New System.Drawing.Point(124, 714)
        Me.BewaarEnBlijf.Name = "BewaarEnBlijf"
        Me.BewaarEnBlijf.nIO = b040.IOValues.IORecordEntryEnable
        Me.BewaarEnBlijf.Size = New System.Drawing.Size(142, 23)
        Me.BewaarEnBlijf.TabIndex = 100
        Me.BewaarEnBlijf.Text = "Bewaar en Blijf (^W)"
        Me.BewaarEnBlijf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BewaarEnBlijf.UseVisualStyleBackColor = True
        '
        'BestDCRUD1
        '
        Me.BestDCRUD1.ClearBeforeFill = True
        '
        'BedieningTableAdapter1
        '
        Me.BedieningTableAdapter1.ClearBeforeFill = True
        '
        'Bestelfrm
        '
        Me.CancelButton = Me.CloseBtn
        Me.ClientSize = New System.Drawing.Size(1144, 737)
        Me.Controls.Add(Me.BewaarEnBlijf)
        Me.Controls.Add(Me.bestelTabpage)
        Me.Controls.Add(Me.BtnToggle)
        Me.Controls.Add(Me.InsertButton)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.SaveButton)
        Me.KeyPreview = True
        Me.Name = "Bestelfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bestel"
        CType(Me.BestelHBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BestelDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdresBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BestelDBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EenhedenDS1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.PnlStandaard.ResumeLayout(False)
        Me.PnlStandaard.PerformLayout()
        Me.PnlBase3.ResumeLayout(False)
        Me.PnlBase3.PerformLayout()
        Me.PnlBase2.ResumeLayout(False)
        Me.PnlBase2.PerformLayout()
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        CType(Me.grdBestelD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsOpschriftenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsOpschriften, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.PnlBase5.ResumeLayout(False)
        Me.PnlBase5.PerformLayout()
        Me.PnlBase4.ResumeLayout(False)
        Me.PnlBase4.PerformLayout()
        Me.bestelTabpage.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.AdresG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.particulierenTabPage.ResumeLayout(False)
        CType(Me.particulierenOverzichtDatagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdresBS As System.Windows.Forms.BindingSource
    Friend WithEvents BestelHBS As System.Windows.Forms.BindingSource
    Friend WithEvents BestelDS As b040.BestelDS
    Friend WithEvents BestelAdresTA As b040.BestelDSTableAdapters.BestelAdresTA
    Friend WithEvents BestelDBS As System.Windows.Forms.BindingSource
    Friend WithEvents BestelDCRUD As b040.BestelDSTableAdapters.BestDCRUD
    Friend WithEvents BestelHCRUD As b040.BestelDSTableAdapters.BestHCRUD
    Friend WithEvents btnDelete As b040.btnBase
    Friend WithEvents CloseBtn As b040.btnBase
    Friend WithEvents SaveButton As b040.btnBase
    Friend WithEvents BestelDCRUD1 As b040.BestelDSTableAdapters.BestDCRUD
    Friend WithEvents BestDEenhPrijsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsertButton As b040.btnBase
    Friend WithEvents SaveAsStandaard As b040.btnBase
    Friend WithEvents EenhedenDS1 As b040.EenhedenDS
    Friend WithEvents BtnToggle As b040.btnBase
    Friend WithEvents btnInfo As b040.btnBase
    Friend WithEvents KlantenTableAdapter1 As b040.StandaardenDSTableAdapters.KlantenTableAdapter
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents BestH_Info As b040.txtBaseMultiline
    Friend WithEvents PnlStandaard As b040.pnlBase
    Friend WithEvents BestH_Standaard As b040.txtBase
    Friend WithEvents BestH_StToegepast As b040.cbobaseJaNeen
    Friend WithEvents StType As b040.cboBase
    Friend WithEvents LblBase17 As b040.lblBase
    Friend WithEvents LblBase18 As b040.lblBase
    Friend WithEvents LblBase19 As b040.lblBase
    Friend WithEvents PnlBase3 As b040.pnlBase
    Friend WithEvents TotBTW As b040.txtBase
    Friend WithEvents TotaalEur As b040.txtBase
    Friend WithEvents LblBase7 As b040.lblBase
    Friend WithEvents LblBase15 As b040.lblBase
    Friend WithEvents Bestellinglijnen As b040.txtBase
    Friend WithEvents LblBase16 As b040.lblBase
    Friend WithEvents grdBestelD As b040.grdBase
    Friend WithEvents PnlBase2 As b040.pnlBase
    Friend WithEvents LblBase11 As b040.lblBase
    Friend WithEvents Bediening As b040.cboBase
    Friend WithEvents LblBase10 As b040.lblBase
    Friend WithEvents BestH_KomtHalen As b040.cbobaseJaNeen
    Friend WithEvents Adr_Telefoon As b040.txtBase
    Friend WithEvents LblBase9 As b040.lblBase
    Friend WithEvents KL_Naam As b040.txtBase
    Friend WithEvents LblBase8 As b040.lblBase
    Friend WithEvents KL_Nummer As b040.txtBase
    Friend WithEvents KlantLbl As b040.lblBase
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents LblBase6 As b040.lblBase
    Friend WithEvents VolgendeFeestdag As b040.txtBase
    Friend WithEvents LblBase5 As b040.lblBase
    Friend WithEvents BestH_UurLevering As b040.txtBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents BestH_DatLevering As b040.txtBaseDate
    Friend WithEvents DagLevering As b040.txtBase
    Friend WithEvents lblDag As b040.lblBase
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents bestelTabpage As b040.tpgBase
    Friend WithEvents PnlBase4 As b040.pnlBase
    Friend WithEvents BestH_Docnr As b040.txtBase
    Friend WithEvents LblBase20 As b040.lblBase
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents grdHistory As System.Windows.Forms.DataGridView
    Friend WithEvents AdresG As b040.grdBase
    Friend WithEvents Adr_Adres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Adr_PostNummer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Adr_Gemeente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Adr_Land As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdrFacturatieDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Kies As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Adr_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsOpschriftenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsOpschriften As b040.dsOpschriften
    Friend WithEvents BtnBewaarAndereDag As b040.btnBase
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents LblNrLevering As b040.lblBase
    Friend WithEvents TxtNrLevering As b040.txtBase
    Friend WithEvents btnVerwijderDocument As b040.btnBase
    Friend WithEvents txtBestH_DatLeveing2 As b040.txtBaseDate
    Friend WithEvents lblDatLeving As b040.lblBase
    Friend WithEvents lblDate As b040.lblBase
    Friend WithEvents PnlBase5 As b040.pnlBase
    Friend WithEvents txtBestH_DatBest2 As b040.txtBaseDate
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents NulBestelling As b040.btnBase
    Friend WithEvents Snijdentoggle As b040.btnBase
    Friend WithEvents EpsonA As b040.btnBase
    Friend WithEvents EpsonD As b040.btnBase
    Friend WithEvents EpsonC As b040.btnBase
    Friend WithEvents EpsonB As b040.btnBase
    Friend WithEvents EpsonAlles As b040.btnBase
    Friend WithEvents BestDIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestDBestHDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestDIsStandaardDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BestDArtikelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Art_Nr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Omschrijving As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestD_Snijden As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Tour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestD_Portie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Standaard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestD_Hoev1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Eenh_HoevInvoer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestD_EenhPrijs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Eenh_omschrijving As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestD_Waarde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents voorafdrukken As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BestD_Verwittigen As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BestD_Opschrift As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents BestD_Boodschap As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ArtOmschrijvingDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colArtNrBound As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents direct_afdrukken As b040.btnBase
    Friend WithEvents particulierenTabPage As System.Windows.Forms.TabPage
    Friend WithEvents BewaarEnBlijf As b040.btnBase
    Friend WithEvents particulierenGotopButton As System.Windows.Forms.Button
    Friend WithEvents particulierenGobottomButton As System.Windows.Forms.Button
    Friend WithEvents overzichtGobottomButton As System.Windows.Forms.Button
    Friend WithEvents overzichtGotopButton As System.Windows.Forms.Button
    Friend WithEvents particulierenOverzichtDatagridview As System.Windows.Forms.DataGridView
    Friend WithEvents BestDCRUD1 As BestelDSTableAdapters.BestDCRUD
    Friend WithEvents BedieningTableAdapter1 As b040_beDataSet1TableAdapters.BedieningTableAdapter
    Friend WithEvents BetalingTextbox As txtBase
    Friend WithEvents LblBase3 As lblBase
End Class

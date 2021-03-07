<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArtikel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArtikel))
        Me.PnlBase1 = New b040.pnlBase()
        Me.TxtArtSearch = New b040.txtBase()
        Me.LblBase1 = New b040.lblBase()
        Me.txtArt_Nr = New b040.txtBase()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsArtikel1 = New b040.dsArtikel()
        Me.PnlBase2 = New b040.pnlBase()
        Me.MeelTextBase = New b040.txtBase()
        Me.LblBase12 = New b040.lblBase()
        Me.TxtArt_Alphacode = New b040.txtBase()
        Me.LblBase2 = New b040.lblBase()
        Me.Art_VerwittigenGewichtCtl = New b040.cbobaseJaNeen()
        Me.Art_KortingCtl = New b040.cbobaseJaNeen()
        Me.Art_PrijslijstCtl = New b040.txtBase()
        Me.Eenh_OmschrijvingCbo = New b040.cboBase()
        Me.Kat_Naamcbo = New b040.cboBase()
        Me.Art_BTW = New b040.txtBaseNumeric()
        Me.PrijsTxt = New b040.txtBaseNumeric()
        Me.LblBase11 = New b040.lblBase()
        Me.LblBase10 = New b040.lblBase()
        Me.LblBase9 = New b040.lblBase()
        Me.LblBase8 = New b040.lblBase()
        Me.LblBase7 = New b040.lblBase()
        Me.LblBase6 = New b040.lblBase()
        Me.LblBase5 = New b040.lblBase()
        Me.LblBase4 = New b040.lblBase()
        Me.LblBase3 = New b040.lblBase()
        Me.txtArt_omschrijving = New b040.txtBase()
        Me.PnlBase3 = New b040.pnlBase()
        Me.art_Uitzonderlijkctl = New b040.cbobaseJaNeen()
        Me.Art_PerpersoonCtl = New b040.cbobaseJaNeen()
        Me.Art_OpschriftCtl = New b040.txtBase()
        Me.Art_BestBoodschapCtl = New b040.txtBase()
        Me.LblBase16 = New b040.lblBase()
        Me.LblBase17 = New b040.lblBase()
        Me.LblBase18 = New b040.lblBase()
        Me.LblBase19 = New b040.lblBase()
        Me.LblBase20 = New b040.lblBase()
        Me.Art_PortieCtl = New b040.txtBaseNumeric()
        Me.ArtikelTableAdapter = New b040.dsArtikelTableAdapters.ArtikelTableAdapter()
        Me.SaveButton = New b040.btnBase()
        Me.CloseBtn = New b040.btnBase()
        Me.PnlBase4 = New b040.pnlBase()
        Me.Art_ACtiefCTl = New b040.cbobaseJaNeen()
        Me.LblBase21 = New b040.lblBase()
        Me.ARt_SnijdenCtl = New b040.cbobaseJaNeen()
        Me.PnlBase1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsArtikel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBase2.SuspendLayout()
        Me.PnlBase3.SuspendLayout()
        Me.PnlBase4.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBase1
        '
        Me.PnlBase1.BackColor = System.Drawing.Color.Silver
        Me.PnlBase1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase1.Controls.Add(Me.TxtArtSearch)
        Me.PnlBase1.Controls.Add(Me.LblBase1)
        Me.PnlBase1.Controls.Add(Me.txtArt_Nr)
        Me.PnlBase1.Location = New System.Drawing.Point(3, 3)
        Me.PnlBase1.Name = "PnlBase1"
        Me.PnlBase1.Size = New System.Drawing.Size(399, 33)
        Me.PnlBase1.TabIndex = 0
        '
        'TxtArtSearch
        '
        Me.TxtArtSearch.BackColor = System.Drawing.Color.LightPink
        Me.TxtArtSearch.fieldLength = 20
        Me.TxtArtSearch.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtArtSearch.forceUppercase = True
        Me.TxtArtSearch.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtArtSearch.lIsSearch = True
        Me.TxtArtSearch.Location = New System.Drawing.Point(109, 4)
        Me.TxtArtSearch.Name = "TxtArtSearch"
        Me.TxtArtSearch.nIO = b040.IOValues.IOKeyEntryEnable
        Me.TxtArtSearch.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtArtSearch.Size = New System.Drawing.Size(275, 21)
        Me.TxtArtSearch.TabIndex = 0
        '
        'LblBase1
        '
        Me.LblBase1.AutoSize = True
        Me.LblBase1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase1.Location = New System.Drawing.Point(4, 8)
        Me.LblBase1.Name = "LblBase1"
        Me.LblBase1.Size = New System.Drawing.Size(48, 16)
        Me.LblBase1.TabIndex = 1
        Me.LblBase1.Text = "Nummer"
        '
        'txtArt_Nr
        '
        Me.txtArt_Nr.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Nr", True))
        Me.txtArt_Nr.fieldLength = 20
        Me.txtArt_Nr.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtArt_Nr.forceUppercase = True
        Me.txtArt_Nr.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtArt_Nr.lIsSearch = False
        Me.txtArt_Nr.Location = New System.Drawing.Point(110, 4)
        Me.txtArt_Nr.Name = "txtArt_Nr"
        Me.txtArt_Nr.nIO = b040.IOValues.IOKeyEntryEnable
        Me.txtArt_Nr.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtArt_Nr.Size = New System.Drawing.Size(275, 21)
        Me.txtArt_Nr.TabIndex = 0
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "Artikel"
        Me.BindingSource1.DataSource = Me.DsArtikel1
        '
        'DsArtikel1
        '
        Me.DsArtikel1.DataSetName = "dsArtikel"
        Me.DsArtikel1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PnlBase2
        '
        Me.PnlBase2.BackColor = System.Drawing.Color.Silver
        Me.PnlBase2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase2.Controls.Add(Me.ARt_SnijdenCtl)
        Me.PnlBase2.Controls.Add(Me.MeelTextBase)
        Me.PnlBase2.Controls.Add(Me.LblBase12)
        Me.PnlBase2.Controls.Add(Me.TxtArt_Alphacode)
        Me.PnlBase2.Controls.Add(Me.LblBase2)
        Me.PnlBase2.Controls.Add(Me.Art_VerwittigenGewichtCtl)
        Me.PnlBase2.Controls.Add(Me.Art_KortingCtl)
        Me.PnlBase2.Controls.Add(Me.Art_PrijslijstCtl)
        Me.PnlBase2.Controls.Add(Me.Eenh_OmschrijvingCbo)
        Me.PnlBase2.Controls.Add(Me.Kat_Naamcbo)
        Me.PnlBase2.Controls.Add(Me.Art_BTW)
        Me.PnlBase2.Controls.Add(Me.PrijsTxt)
        Me.PnlBase2.Controls.Add(Me.LblBase11)
        Me.PnlBase2.Controls.Add(Me.LblBase10)
        Me.PnlBase2.Controls.Add(Me.LblBase9)
        Me.PnlBase2.Controls.Add(Me.LblBase8)
        Me.PnlBase2.Controls.Add(Me.LblBase7)
        Me.PnlBase2.Controls.Add(Me.LblBase6)
        Me.PnlBase2.Controls.Add(Me.LblBase5)
        Me.PnlBase2.Controls.Add(Me.LblBase4)
        Me.PnlBase2.Controls.Add(Me.LblBase3)
        Me.PnlBase2.Controls.Add(Me.txtArt_omschrijving)
        Me.PnlBase2.Location = New System.Drawing.Point(3, 38)
        Me.PnlBase2.Name = "PnlBase2"
        Me.PnlBase2.Size = New System.Drawing.Size(399, 249)
        Me.PnlBase2.TabIndex = 1
        '
        'MeelTextBase
        '
        Me.MeelTextBase.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Meel", True))
        Me.MeelTextBase.fieldLength = 0
        Me.MeelTextBase.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.MeelTextBase.forceUppercase = False
        Me.MeelTextBase.ForeColor = System.Drawing.Color.DarkBlue
        Me.MeelTextBase.lIsSearch = False
        Me.MeelTextBase.Location = New System.Drawing.Point(109, 213)
        Me.MeelTextBase.Name = "MeelTextBase"
        Me.MeelTextBase.nIO = b040.IOValues.IORecordEntryEnable
        Me.MeelTextBase.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.MeelTextBase.Size = New System.Drawing.Size(275, 21)
        Me.MeelTextBase.TabIndex = 20
        '
        'LblBase12
        '
        Me.LblBase12.AutoSize = True
        Me.LblBase12.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase12.Location = New System.Drawing.Point(4, 217)
        Me.LblBase12.Name = "LblBase12"
        Me.LblBase12.Size = New System.Drawing.Size(78, 16)
        Me.LblBase12.TabIndex = 19
        Me.LblBase12.Text = "Meel (in gram)"
        '
        'TxtArt_Alphacode
        '
        Me.TxtArt_Alphacode.AsciiOnly = True
        Me.TxtArt_Alphacode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_AlphaCode", True))
        Me.TxtArt_Alphacode.fieldLength = 0
        Me.TxtArt_Alphacode.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TxtArt_Alphacode.forceUppercase = True
        Me.TxtArt_Alphacode.ForeColor = System.Drawing.Color.DarkBlue
        Me.TxtArt_Alphacode.lIsSearch = False
        Me.TxtArt_Alphacode.Location = New System.Drawing.Point(109, 24)
        Me.TxtArt_Alphacode.Name = "TxtArt_Alphacode"
        Me.TxtArt_Alphacode.nIO = b040.IOValues.IORecordEntryEnable
        Me.TxtArt_Alphacode.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtArt_Alphacode.Size = New System.Drawing.Size(275, 21)
        Me.TxtArt_Alphacode.TabIndex = 3
        '
        'LblBase2
        '
        Me.LblBase2.AutoSize = True
        Me.LblBase2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase2.Location = New System.Drawing.Point(4, 28)
        Me.LblBase2.Name = "LblBase2"
        Me.LblBase2.Size = New System.Drawing.Size(58, 16)
        Me.LblBase2.TabIndex = 13
        Me.LblBase2.Text = "Alphacode"
        '
        'Art_VerwittigenGewichtCtl
        '
        Me.Art_VerwittigenGewichtCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_VerwittigenGewicht", True))
        Me.Art_VerwittigenGewichtCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_VerwittigenGewichtCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_VerwittigenGewichtCtl.FormattingEnabled = True
        Me.Art_VerwittigenGewichtCtl.Location = New System.Drawing.Point(109, 192)
        Me.Art_VerwittigenGewichtCtl.Name = "Art_VerwittigenGewichtCtl"
        Me.Art_VerwittigenGewichtCtl.nIO = b040.IOValues.IOAlwaysDisable
        Me.Art_VerwittigenGewichtCtl.setAutocomplete = False
        Me.Art_VerwittigenGewichtCtl.Size = New System.Drawing.Size(275, 26)
        Me.Art_VerwittigenGewichtCtl.TabIndex = 11
        '
        'Art_KortingCtl
        '
        Me.Art_KortingCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Korting", True))
        Me.Art_KortingCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_KortingCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_KortingCtl.FormattingEnabled = True
        Me.Art_KortingCtl.Location = New System.Drawing.Point(109, 129)
        Me.Art_KortingCtl.Name = "Art_KortingCtl"
        Me.Art_KortingCtl.nIO = b040.IOValues.IORecordEntryEnable
        Me.Art_KortingCtl.setAutocomplete = False
        Me.Art_KortingCtl.Size = New System.Drawing.Size(275, 26)
        Me.Art_KortingCtl.TabIndex = 8
        '
        'Art_PrijslijstCtl
        '
        Me.Art_PrijslijstCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Prijslijst", True))
        Me.Art_PrijslijstCtl.fieldLength = 0
        Me.Art_PrijslijstCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_PrijslijstCtl.forceUppercase = True
        Me.Art_PrijslijstCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_PrijslijstCtl.lIsSearch = False
        Me.Art_PrijslijstCtl.Location = New System.Drawing.Point(109, 150)
        Me.Art_PrijslijstCtl.Name = "Art_PrijslijstCtl"
        Me.Art_PrijslijstCtl.nIO = b040.IOValues.IORecordEntryEnable
        Me.Art_PrijslijstCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Art_PrijslijstCtl.Size = New System.Drawing.Size(275, 21)
        Me.Art_PrijslijstCtl.TabIndex = 9
        '
        'Eenh_OmschrijvingCbo
        '
        Me.Eenh_OmschrijvingCbo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Eenh_Omschrijving", True))
        Me.Eenh_OmschrijvingCbo.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Eenh_OmschrijvingCbo.ForeColor = System.Drawing.Color.DarkBlue
        Me.Eenh_OmschrijvingCbo.FormattingEnabled = True
        Me.Eenh_OmschrijvingCbo.Location = New System.Drawing.Point(109, 87)
        Me.Eenh_OmschrijvingCbo.Name = "Eenh_OmschrijvingCbo"
        Me.Eenh_OmschrijvingCbo.nIO = b040.IOValues.IORecordEntryEnable
        Me.Eenh_OmschrijvingCbo.setAutocomplete = False
        Me.Eenh_OmschrijvingCbo.Size = New System.Drawing.Size(275, 26)
        Me.Eenh_OmschrijvingCbo.TabIndex = 6
        '
        'Kat_Naamcbo
        '
        Me.Kat_Naamcbo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Kat_Naam", True))
        Me.Kat_Naamcbo.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Kat_Naamcbo.ForeColor = System.Drawing.Color.DarkBlue
        Me.Kat_Naamcbo.FormattingEnabled = True
        Me.Kat_Naamcbo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Kat_Naamcbo.Location = New System.Drawing.Point(109, 45)
        Me.Kat_Naamcbo.Name = "Kat_Naamcbo"
        Me.Kat_Naamcbo.nIO = b040.IOValues.IORecordEntryEnable
        Me.Kat_Naamcbo.setAutocomplete = False
        Me.Kat_Naamcbo.Size = New System.Drawing.Size(275, 26)
        Me.Kat_Naamcbo.TabIndex = 4
        '
        'Art_BTW
        '
        Me.Art_BTW.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_BTW", True))
        Me.Art_BTW.fieldLength = 0
        Me.Art_BTW.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_BTW.forceUppercase = True
        Me.Art_BTW.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_BTW.lIsSearch = False
        Me.Art_BTW.Location = New System.Drawing.Point(109, 108)
        Me.Art_BTW.Name = "Art_BTW"
        Me.Art_BTW.nIO = b040.IOValues.IORecordEntryEnable
        Me.Art_BTW.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Art_BTW.Size = New System.Drawing.Size(275, 21)
        Me.Art_BTW.TabIndex = 7
        '
        'PrijsTxt
        '
        Me.PrijsTxt.AllowDrop = True
        Me.PrijsTxt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Prijs", True))
        Me.PrijsTxt.fieldLength = 0
        Me.PrijsTxt.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PrijsTxt.forceUppercase = True
        Me.PrijsTxt.ForeColor = System.Drawing.Color.DarkBlue
        Me.PrijsTxt.lIsSearch = False
        Me.PrijsTxt.Location = New System.Drawing.Point(109, 66)
        Me.PrijsTxt.Name = "PrijsTxt"
        Me.PrijsTxt.nIO = b040.IOValues.IORecordEntryEnable
        Me.PrijsTxt.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.PrijsTxt.Size = New System.Drawing.Size(275, 21)
        Me.PrijsTxt.TabIndex = 5
        '
        'LblBase11
        '
        Me.LblBase11.AutoSize = True
        Me.LblBase11.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase11.Location = New System.Drawing.Point(4, 197)
        Me.LblBase11.Name = "LblBase11"
        Me.LblBase11.Size = New System.Drawing.Size(106, 16)
        Me.LblBase11.TabIndex = 11
        Me.LblBase11.Text = "Verwitigen Gewicht"
        '
        'LblBase10
        '
        Me.LblBase10.AutoSize = True
        Me.LblBase10.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase10.Location = New System.Drawing.Point(5, 176)
        Me.LblBase10.Name = "LblBase10"
        Me.LblBase10.Size = New System.Drawing.Size(44, 16)
        Me.LblBase10.TabIndex = 10
        Me.LblBase10.Text = "Snijden"
        '
        'LblBase9
        '
        Me.LblBase9.AutoSize = True
        Me.LblBase9.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase9.Location = New System.Drawing.Point(5, 134)
        Me.LblBase9.Name = "LblBase9"
        Me.LblBase9.Size = New System.Drawing.Size(45, 16)
        Me.LblBase9.TabIndex = 9
        Me.LblBase9.Text = "Korting"
        '
        'LblBase8
        '
        Me.LblBase8.AutoSize = True
        Me.LblBase8.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase8.Location = New System.Drawing.Point(5, 155)
        Me.LblBase8.Name = "LblBase8"
        Me.LblBase8.Size = New System.Drawing.Size(49, 16)
        Me.LblBase8.TabIndex = 8
        Me.LblBase8.Text = "Prijslijst"
        '
        'LblBase7
        '
        Me.LblBase7.AutoSize = True
        Me.LblBase7.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase7.Location = New System.Drawing.Point(5, 113)
        Me.LblBase7.Name = "LblBase7"
        Me.LblBase7.Size = New System.Drawing.Size(45, 16)
        Me.LblBase7.TabIndex = 7
        Me.LblBase7.Text = "Btw (%)"
        '
        'LblBase6
        '
        Me.LblBase6.AutoSize = True
        Me.LblBase6.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase6.Location = New System.Drawing.Point(5, 92)
        Me.LblBase6.Name = "LblBase6"
        Me.LblBase6.Size = New System.Drawing.Size(47, 16)
        Me.LblBase6.TabIndex = 6
        Me.LblBase6.Text = "Eenheid"
        '
        'LblBase5
        '
        Me.LblBase5.AutoSize = True
        Me.LblBase5.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase5.Location = New System.Drawing.Point(5, 71)
        Me.LblBase5.Name = "LblBase5"
        Me.LblBase5.Size = New System.Drawing.Size(60, 16)
        Me.LblBase5.TabIndex = 5
        Me.LblBase5.Text = "Prijs (EUR)"
        '
        'LblBase4
        '
        Me.LblBase4.AutoSize = True
        Me.LblBase4.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase4.Location = New System.Drawing.Point(5, 50)
        Me.LblBase4.Name = "LblBase4"
        Me.LblBase4.Size = New System.Drawing.Size(57, 16)
        Me.LblBase4.TabIndex = 4
        Me.LblBase4.Text = "Kategorie"
        '
        'LblBase3
        '
        Me.LblBase3.AutoSize = True
        Me.LblBase3.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase3.Location = New System.Drawing.Point(4, 7)
        Me.LblBase3.Name = "LblBase3"
        Me.LblBase3.Size = New System.Drawing.Size(74, 16)
        Me.LblBase3.TabIndex = 3
        Me.LblBase3.Text = "Omschrijving"
        '
        'txtArt_omschrijving
        '
        Me.txtArt_omschrijving.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Omschrijving", True))
        Me.txtArt_omschrijving.fieldLength = 0
        Me.txtArt_omschrijving.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtArt_omschrijving.forceUppercase = False
        Me.txtArt_omschrijving.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtArt_omschrijving.lIsSearch = False
        Me.txtArt_omschrijving.Location = New System.Drawing.Point(109, 3)
        Me.txtArt_omschrijving.Name = "txtArt_omschrijving"
        Me.txtArt_omschrijving.nIO = b040.IOValues.IORecordEntryEnable
        Me.txtArt_omschrijving.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtArt_omschrijving.Size = New System.Drawing.Size(275, 21)
        Me.txtArt_omschrijving.TabIndex = 2
        '
        'PnlBase3
        '
        Me.PnlBase3.BackColor = System.Drawing.Color.Silver
        Me.PnlBase3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase3.Controls.Add(Me.art_Uitzonderlijkctl)
        Me.PnlBase3.Controls.Add(Me.Art_PerpersoonCtl)
        Me.PnlBase3.Controls.Add(Me.Art_OpschriftCtl)
        Me.PnlBase3.Controls.Add(Me.Art_BestBoodschapCtl)
        Me.PnlBase3.Controls.Add(Me.LblBase16)
        Me.PnlBase3.Controls.Add(Me.LblBase17)
        Me.PnlBase3.Controls.Add(Me.LblBase18)
        Me.PnlBase3.Controls.Add(Me.LblBase19)
        Me.PnlBase3.Controls.Add(Me.LblBase20)
        Me.PnlBase3.Controls.Add(Me.Art_PortieCtl)
        Me.PnlBase3.Location = New System.Drawing.Point(3, 287)
        Me.PnlBase3.Name = "PnlBase3"
        Me.PnlBase3.Size = New System.Drawing.Size(400, 114)
        Me.PnlBase3.TabIndex = 12
        '
        'art_Uitzonderlijkctl
        '
        Me.art_Uitzonderlijkctl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Uitzonderlijk", True))
        Me.art_Uitzonderlijkctl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.art_Uitzonderlijkctl.ForeColor = System.Drawing.Color.DarkBlue
        Me.art_Uitzonderlijkctl.FormattingEnabled = True
        Me.art_Uitzonderlijkctl.Location = New System.Drawing.Point(109, 4)
        Me.art_Uitzonderlijkctl.Name = "art_Uitzonderlijkctl"
        Me.art_Uitzonderlijkctl.nIO = b040.IOValues.IOAlwaysDisable
        Me.art_Uitzonderlijkctl.setAutocomplete = False
        Me.art_Uitzonderlijkctl.Size = New System.Drawing.Size(275, 26)
        Me.art_Uitzonderlijkctl.TabIndex = 12
        '
        'Art_PerpersoonCtl
        '
        Me.Art_PerpersoonCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_PerPersoon", True))
        Me.Art_PerpersoonCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_PerpersoonCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_PerpersoonCtl.FormattingEnabled = True
        Me.Art_PerpersoonCtl.Location = New System.Drawing.Point(109, 25)
        Me.Art_PerpersoonCtl.Name = "Art_PerpersoonCtl"
        Me.Art_PerpersoonCtl.nIO = b040.IOValues.IOAlwaysDisable
        Me.Art_PerpersoonCtl.setAutocomplete = False
        Me.Art_PerpersoonCtl.Size = New System.Drawing.Size(275, 26)
        Me.Art_PerpersoonCtl.TabIndex = 13
        '
        'Art_OpschriftCtl
        '
        Me.Art_OpschriftCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Opschrift", True))
        Me.Art_OpschriftCtl.fieldLength = 0
        Me.Art_OpschriftCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_OpschriftCtl.forceUppercase = False
        Me.Art_OpschriftCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_OpschriftCtl.lIsSearch = False
        Me.Art_OpschriftCtl.Location = New System.Drawing.Point(109, 65)
        Me.Art_OpschriftCtl.Name = "Art_OpschriftCtl"
        Me.Art_OpschriftCtl.nIO = b040.IOValues.IOAlwaysDisable
        Me.Art_OpschriftCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Art_OpschriftCtl.Size = New System.Drawing.Size(275, 21)
        Me.Art_OpschriftCtl.TabIndex = 15
        '
        'Art_BestBoodschapCtl
        '
        Me.Art_BestBoodschapCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_BestBoodschap", True))
        Me.Art_BestBoodschapCtl.fieldLength = 0
        Me.Art_BestBoodschapCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_BestBoodschapCtl.forceUppercase = False
        Me.Art_BestBoodschapCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_BestBoodschapCtl.lIsSearch = False
        Me.Art_BestBoodschapCtl.Location = New System.Drawing.Point(109, 85)
        Me.Art_BestBoodschapCtl.Name = "Art_BestBoodschapCtl"
        Me.Art_BestBoodschapCtl.nIO = b040.IOValues.IOAlwaysDisable
        Me.Art_BestBoodschapCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Art_BestBoodschapCtl.Size = New System.Drawing.Size(275, 21)
        Me.Art_BestBoodschapCtl.TabIndex = 16
        '
        'LblBase16
        '
        Me.LblBase16.AutoSize = True
        Me.LblBase16.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase16.Location = New System.Drawing.Point(5, 91)
        Me.LblBase16.Name = "LblBase16"
        Me.LblBase16.Size = New System.Drawing.Size(59, 16)
        Me.LblBase16.TabIndex = 7
        Me.LblBase16.Text = "Instructie"
        '
        'LblBase17
        '
        Me.LblBase17.AutoSize = True
        Me.LblBase17.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase17.Location = New System.Drawing.Point(5, 70)
        Me.LblBase17.Name = "LblBase17"
        Me.LblBase17.Size = New System.Drawing.Size(56, 16)
        Me.LblBase17.TabIndex = 6
        Me.LblBase17.Text = "Opschrift"
        '
        'LblBase18
        '
        Me.LblBase18.AutoSize = True
        Me.LblBase18.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase18.Location = New System.Drawing.Point(5, 49)
        Me.LblBase18.Name = "LblBase18"
        Me.LblBase18.Size = New System.Drawing.Size(86, 16)
        Me.LblBase18.TabIndex = 5
        Me.LblBase18.Text = "Portie (in gram)"
        '
        'LblBase19
        '
        Me.LblBase19.AutoSize = True
        Me.LblBase19.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase19.Location = New System.Drawing.Point(5, 28)
        Me.LblBase19.Name = "LblBase19"
        Me.LblBase19.Size = New System.Drawing.Size(66, 16)
        Me.LblBase19.TabIndex = 4
        Me.LblBase19.Text = "Per Persoon"
        '
        'LblBase20
        '
        Me.LblBase20.AutoSize = True
        Me.LblBase20.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase20.Location = New System.Drawing.Point(5, 7)
        Me.LblBase20.Name = "LblBase20"
        Me.LblBase20.Size = New System.Drawing.Size(56, 16)
        Me.LblBase20.TabIndex = 3
        Me.LblBase20.Text = "Bijzonder"
        '
        'Art_PortieCtl
        '
        Me.Art_PortieCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Portie", True))
        Me.Art_PortieCtl.fieldLength = 0
        Me.Art_PortieCtl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_PortieCtl.forceUppercase = True
        Me.Art_PortieCtl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_PortieCtl.lIsSearch = False
        Me.Art_PortieCtl.Location = New System.Drawing.Point(109, 45)
        Me.Art_PortieCtl.Name = "Art_PortieCtl"
        Me.Art_PortieCtl.nIO = b040.IOValues.IOAlwaysDisable
        Me.Art_PortieCtl.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Art_PortieCtl.Size = New System.Drawing.Size(275, 21)
        Me.Art_PortieCtl.TabIndex = 14
        '
        'ArtikelTableAdapter
        '
        Me.ArtikelTableAdapter.ClearBeforeFill = True
        '
        'SaveButton
        '
        Me.SaveButton.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Image = CType(resources.GetObject("SaveButton.Image"), System.Drawing.Image)
        Me.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveButton.Location = New System.Drawing.Point(3, 438)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.nIO = b040.IOValues.IORecordEntryEnable
        Me.SaveButton.Size = New System.Drawing.Size(75, 25)
        Me.SaveButton.TabIndex = 21
        Me.SaveButton.Text = "Bewaar"
        Me.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'CloseBtn
        '
        Me.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseBtn.Font = New System.Drawing.Font("Trebuchet MS", 9.0!)
        Me.CloseBtn.Image = CType(resources.GetObject("CloseBtn.Image"), System.Drawing.Image)
        Me.CloseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CloseBtn.Location = New System.Drawing.Point(328, 438)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.nIO = b040.IOValues.IOAlwaysEnable
        Me.CloseBtn.Size = New System.Drawing.Size(75, 25)
        Me.CloseBtn.TabIndex = 22
        Me.CloseBtn.Text = "Sluit"
        Me.CloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CloseBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'PnlBase4
        '
        Me.PnlBase4.BackColor = System.Drawing.Color.Silver
        Me.PnlBase4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBase4.Controls.Add(Me.Art_ACtiefCTl)
        Me.PnlBase4.Controls.Add(Me.LblBase21)
        Me.PnlBase4.Location = New System.Drawing.Point(3, 401)
        Me.PnlBase4.Name = "PnlBase4"
        Me.PnlBase4.Size = New System.Drawing.Size(400, 34)
        Me.PnlBase4.TabIndex = 17
        '
        'Art_ACtiefCTl
        '
        Me.Art_ACtiefCTl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Actief", True))
        Me.Art_ACtiefCTl.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Art_ACtiefCTl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Art_ACtiefCTl.FormattingEnabled = True
        Me.Art_ACtiefCTl.Location = New System.Drawing.Point(109, 4)
        Me.Art_ACtiefCTl.Name = "Art_ACtiefCTl"
        Me.Art_ACtiefCTl.nIO = b040.IOValues.IORecordEntryEnable
        Me.Art_ACtiefCTl.setAutocomplete = False
        Me.Art_ACtiefCTl.Size = New System.Drawing.Size(275, 26)
        Me.Art_ACtiefCTl.TabIndex = 17
        '
        'LblBase21
        '
        Me.LblBase21.AutoSize = True
        Me.LblBase21.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblBase21.Location = New System.Drawing.Point(6, 7)
        Me.LblBase21.Name = "LblBase21"
        Me.LblBase21.Size = New System.Drawing.Size(38, 16)
        Me.LblBase21.TabIndex = 3
        Me.LblBase21.Text = "Actief"
        '
        'ARt_SnijdenCtl
        '
        Me.ARt_SnijdenCtl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ARt_SnijdenCtl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ARt_SnijdenCtl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Art_Snijden", True))
        Me.ARt_SnijdenCtl.FormattingEnabled = True
        Me.ARt_SnijdenCtl.Location = New System.Drawing.Point(109, 171)
        Me.ARt_SnijdenCtl.Name = "ARt_SnijdenCtl"
        Me.ARt_SnijdenCtl.nIO = b040.IOValues.IORecordEntryEnable
        Me.ARt_SnijdenCtl.setAutocomplete = False
        Me.ARt_SnijdenCtl.Size = New System.Drawing.Size(275, 21)
        Me.ARt_SnijdenCtl.TabIndex = 26
        '
        'frmArtikel
        '
        Me.CancelButton = Me.CloseBtn
        Me.ClientSize = New System.Drawing.Size(408, 468)
        Me.Controls.Add(Me.PnlBase4)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.PnlBase3)
        Me.Controls.Add(Me.PnlBase1)
        Me.Controls.Add(Me.PnlBase2)
        Me.ForeColor = System.Drawing.Color.Chocolate
        Me.KeyPreview = True
        Me.Name = "frmArtikel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artikel"
        Me.PnlBase1.ResumeLayout(False)
        Me.PnlBase1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsArtikel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBase2.ResumeLayout(False)
        Me.PnlBase2.PerformLayout()
        Me.PnlBase3.ResumeLayout(False)
        Me.PnlBase3.PerformLayout()
        Me.PnlBase4.ResumeLayout(False)
        Me.PnlBase4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlBase1 As b040.pnlBase
    Friend WithEvents txtArt_Nr As b040.txtBase
    Friend WithEvents LblBase1 As b040.lblBase
    Friend WithEvents DsArtikel1 As b040.dsArtikel
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ArtikelTableAdapter As b040.dsArtikelTableAdapters.ArtikelTableAdapter
    Friend WithEvents PnlBase2 As b040.pnlBase
    Friend WithEvents LblBase3 As b040.lblBase
    Friend WithEvents txtArt_omschrijving As b040.txtBase
    Friend WithEvents LblBase4 As b040.lblBase
    Friend WithEvents LblBase11 As b040.lblBase
    Friend WithEvents LblBase10 As b040.lblBase
    Friend WithEvents LblBase9 As b040.lblBase
    Friend WithEvents LblBase8 As b040.lblBase
    Friend WithEvents LblBase7 As b040.lblBase
    Friend WithEvents LblBase6 As b040.lblBase
    Friend WithEvents LblBase5 As b040.lblBase
    Friend WithEvents PnlBase3 As b040.pnlBase
    Friend WithEvents LblBase16 As b040.lblBase
    Friend WithEvents LblBase17 As b040.lblBase
    Friend WithEvents LblBase18 As b040.lblBase
    Friend WithEvents LblBase19 As b040.lblBase
    Friend WithEvents LblBase20 As b040.lblBase
    Friend WithEvents Art_OpschriftCtl As b040.txtBase
    Friend WithEvents Art_BestBoodschapCtl As b040.txtBase
    Friend WithEvents Eenh_OmschrijvingCbo As b040.cboBase
    Friend WithEvents Kat_Naamcbo As b040.cboBase
    '    Friend WithEvents KategorieDSBindingSource As System.Windows.Forms.BindingSource
    '    Friend WithEvents KategorieDS As b040.KategorieDS
    Friend WithEvents PrijsTxt As b040.txtBaseNumeric
    Friend WithEvents Art_BTW As b040.txtBaseNumeric
    Friend WithEvents Art_KortingCtl As b040.cbobaseJaNeen
    Friend WithEvents Art_PrijslijstCtl As b040.txtBase
    Friend WithEvents Art_VerwittigenGewichtCtl As b040.cbobaseJaNeen
    Friend WithEvents art_Uitzonderlijkctl As b040.cbobaseJaNeen
    Friend WithEvents Art_PerpersoonCtl As b040.cbobaseJaNeen
    Friend WithEvents Art_PortieCtl As b040.txtBaseNumeric
    Friend WithEvents SaveButton As b040.btnBase
    Friend WithEvents CloseBtn As b040.btnBase
    Friend WithEvents TxtArt_Alphacode As b040.txtBase
    Friend WithEvents LblBase2 As b040.lblBase
    Friend WithEvents PnlBase4 As b040.pnlBase
    Friend WithEvents Art_ACtiefCTl As b040.cbobaseJaNeen
    Friend WithEvents LblBase21 As b040.lblBase
    Friend WithEvents TxtArtSearch As b040.txtBase
    Friend WithEvents MeelTextBase As txtBase
    Friend WithEvents LblBase12 As lblBase
    Friend WithEvents ARt_SnijdenCtl As cbobaseJaNeen

End Class

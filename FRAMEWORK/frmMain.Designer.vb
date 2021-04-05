<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.waitingMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BestelLeverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArtikeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KlantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StandaardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeestdagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductiePlanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DagelijksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AanpassenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomatischBestellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAfdrukkenVervoerEnAfrekening = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfdrkenBestelDocumentenParticulierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturatieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverzichtBestellingenPartculierenStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CompactDBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OntgrendelStationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BestellingenAnnulerenVoorÉénDagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SysteemProgrammasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendMailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminalErrorTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestRawPrintingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AanpassenStandaardOmschrijvingenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JustTestingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblMessage = New b040.lblBase()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.waitingMessage, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 388)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(819, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'waitingMessage
        '
        Me.waitingMessage.BackColor = System.Drawing.Color.Yellow
        Me.waitingMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.waitingMessage.ForeColor = System.Drawing.Color.Maroon
        Me.waitingMessage.Name = "waitingMessage"
        Me.waitingMessage.Size = New System.Drawing.Size(223, 25)
        Me.waitingMessage.Text = "Uw Excel blad wordt nu geproduceerd"
        Me.waitingMessage.Visible = False
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripStatusLabel2.Text = "Application :"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(85, 17)
        Me.ToolStripStatusLabel1.Text = "Connected to :"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(101, 17)
        Me.ToolStripStatusLabel3.Text = "Regional Settings:"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(83, 17)
        Me.ToolStripStatusLabel4.Text = "Default Printer"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(66, 17)
        Me.ToolStripStatusLabel5.Text = "Bijz. Printer"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 24)
        Me.ToolStripProgressBar1.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BestelLeverToolStripMenuItem, Me.LeverToolStripMenuItem, Me.ArtikeToolStripMenuItem, Me.KlantToolStripMenuItem, Me.StandaardsToolStripMenuItem, Me.FeestdagenToolStripMenuItem, Me.ProductiePlanToolStripMenuItem, Me.HelpTab})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(819, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BestelLeverToolStripMenuItem
        '
        Me.BestelLeverToolStripMenuItem.Name = "BestelLeverToolStripMenuItem"
        Me.BestelLeverToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.BestelLeverToolStripMenuItem.Text = "&Bestel"
        '
        'LeverToolStripMenuItem
        '
        Me.LeverToolStripMenuItem.Name = "LeverToolStripMenuItem"
        Me.LeverToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.LeverToolStripMenuItem.Text = "&Lever"
        '
        'ArtikeToolStripMenuItem
        '
        Me.ArtikeToolStripMenuItem.Name = "ArtikeToolStripMenuItem"
        Me.ArtikeToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ArtikeToolStripMenuItem.Text = "&Artikel"
        '
        'KlantToolStripMenuItem
        '
        Me.KlantToolStripMenuItem.Name = "KlantToolStripMenuItem"
        Me.KlantToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.KlantToolStripMenuItem.Text = "&Klant"
        '
        'StandaardsToolStripMenuItem
        '
        Me.StandaardsToolStripMenuItem.Name = "StandaardsToolStripMenuItem"
        Me.StandaardsToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.StandaardsToolStripMenuItem.Text = "&Standaards"
        '
        'FeestdagenToolStripMenuItem
        '
        Me.FeestdagenToolStripMenuItem.Name = "FeestdagenToolStripMenuItem"
        Me.FeestdagenToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.FeestdagenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.FeestdagenToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.FeestdagenToolStripMenuItem.Text = "Feest&dagen"
        '
        'ProductiePlanToolStripMenuItem
        '
        Me.ProductiePlanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DagelijksToolStripMenuItem, Me.AanpassenToolStripMenuItem})
        Me.ProductiePlanToolStripMenuItem.Name = "ProductiePlanToolStripMenuItem"
        Me.ProductiePlanToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ProductiePlanToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.ProductiePlanToolStripMenuItem.Text = "&Productie Plan"
        '
        'DagelijksToolStripMenuItem
        '
        Me.DagelijksToolStripMenuItem.Name = "DagelijksToolStripMenuItem"
        Me.DagelijksToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.DagelijksToolStripMenuItem.Text = "Dagelijks Rapport"
        '
        'AanpassenToolStripMenuItem
        '
        Me.AanpassenToolStripMenuItem.Name = "AanpassenToolStripMenuItem"
        Me.AanpassenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AanpassenToolStripMenuItem.Text = "Overzicht"
        '
        'HelpTab
        '
        Me.HelpTab.AccessibleDescription = ""
        Me.HelpTab.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutomatischBestellenToolStripMenuItem, Me.tsmiAfdrukkenVervoerEnAfrekening, Me.AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem, Me.AfdrkenBestelDocumentenParticulierenToolStripMenuItem, Me.FacturatieToolStripMenuItem, Me.ToolStripMenuItem3, Me.ToolStripSeparator2, Me.ToolStripMenuItem2, Me.ToolStripMenuItem1, Me.OverzichtBestellingenPartculierenStripMenuItem, Me.ToolStripSeparator1, Me.CompactDBToolStripMenuItem, Me.OntgrendelStationToolStripMenuItem, Me.IndexToolStripMenuItem, Me.BestellingenAnnulerenVoorÉénDagToolStripMenuItem, Me.ToolStripSeparator3, Me.SysteemProgrammasToolStripMenuItem, Me.JustTestingToolStripMenuItem})
        Me.HelpTab.Name = "HelpTab"
        Me.HelpTab.Size = New System.Drawing.Size(119, 20)
        Me.HelpTab.Text = "Hulp Programma's"
        '
        'AutomatischBestellenToolStripMenuItem
        '
        Me.AutomatischBestellenToolStripMenuItem.Name = "AutomatischBestellenToolStripMenuItem"
        Me.AutomatischBestellenToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.AutomatischBestellenToolStripMenuItem.Text = "Automatisch Bestellen van Standaarden voor Winkels en Particulieren"
        '
        'tsmiAfdrukkenVervoerEnAfrekening
        '
        Me.tsmiAfdrukkenVervoerEnAfrekening.Name = "tsmiAfdrukkenVervoerEnAfrekening"
        Me.tsmiAfdrukkenVervoerEnAfrekening.Size = New System.Drawing.Size(439, 22)
        Me.tsmiAfdrukkenVervoerEnAfrekening.Text = "Afdrukken alle Vervoer en Leveringbonnen Winkels"
        '
        'AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem
        '
        Me.AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem.Name = "AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem"
        Me.AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem.Text = "Afdrukken Overzicht Lijst met Namen van Bestellingen Particulieren"
        '
        'AfdrkenBestelDocumentenParticulierenToolStripMenuItem
        '
        Me.AfdrkenBestelDocumentenParticulierenToolStripMenuItem.Name = "AfdrkenBestelDocumentenParticulierenToolStripMenuItem"
        Me.AfdrkenBestelDocumentenParticulierenToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.AfdrkenBestelDocumentenParticulierenToolStripMenuItem.Text = "Afdrukken Bestel Documenten Particulieren (op gewone printer)"
        '
        'FacturatieToolStripMenuItem
        '
        Me.FacturatieToolStripMenuItem.Name = "FacturatieToolStripMenuItem"
        Me.FacturatieToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.FacturatieToolStripMenuItem.Text = "&Facturatie"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(436, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(439, 22)
        Me.ToolStripMenuItem2.Text = "Overrzicht Operaties per Klant"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(439, 22)
        Me.ToolStripMenuItem1.Text = "Overzicht Facturen per Klant"
        '
        'OverzichtBestellingenPartculierenStripMenuItem
        '
        Me.OverzichtBestellingenPartculierenStripMenuItem.Name = "OverzichtBestellingenPartculierenStripMenuItem"
        Me.OverzichtBestellingenPartculierenStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.OverzichtBestellingenPartculierenStripMenuItem.Text = "Overzicht Bestelde Producten voor Particulieren"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(436, 6)
        '
        'CompactDBToolStripMenuItem
        '
        Me.CompactDBToolStripMenuItem.Name = "CompactDBToolStripMenuItem"
        Me.CompactDBToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.CompactDBToolStripMenuItem.Text = "Database Comprimeren"
        '
        'OntgrendelStationToolStripMenuItem
        '
        Me.OntgrendelStationToolStripMenuItem.Name = "OntgrendelStationToolStripMenuItem"
        Me.OntgrendelStationToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.OntgrendelStationToolStripMenuItem.Text = "Ontgrendel station"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.IndexToolStripMenuItem.Text = "Index"
        Me.IndexToolStripMenuItem.Visible = False
        '
        'BestellingenAnnulerenVoorÉénDagToolStripMenuItem
        '
        Me.BestellingenAnnulerenVoorÉénDagToolStripMenuItem.Name = "BestellingenAnnulerenVoorÉénDagToolStripMenuItem"
        Me.BestellingenAnnulerenVoorÉénDagToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.BestellingenAnnulerenVoorÉénDagToolStripMenuItem.Text = "Bestellingen Annuleren voor één dag"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(436, 6)
        '
        'SysteemProgrammasToolStripMenuItem
        '
        Me.SysteemProgrammasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArrangeWindow, Me.TestFormToolStripMenuItem, Me.SendMailToolStripMenuItem, Me.TerminalErrorTestToolStripMenuItem, Me.TestExcelToolStripMenuItem, Me.TestRawPrintingToolStripMenuItem, Me.AanpassenStandaardOmschrijvingenToolStripMenuItem, Me.PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem})
        Me.SysteemProgrammasToolStripMenuItem.Name = "SysteemProgrammasToolStripMenuItem"
        Me.SysteemProgrammasToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.SysteemProgrammasToolStripMenuItem.Text = "Systeem Programma's"
        '
        'ArrangeWindow
        '
        Me.ArrangeWindow.Name = "ArrangeWindow"
        Me.ArrangeWindow.Size = New System.Drawing.Size(471, 22)
        Me.ArrangeWindow.Text = "Schik Vensters"
        '
        'TestFormToolStripMenuItem
        '
        Me.TestFormToolStripMenuItem.Name = "TestFormToolStripMenuItem"
        Me.TestFormToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.TestFormToolStripMenuItem.Text = "Test Form"
        '
        'SendMailToolStripMenuItem
        '
        Me.SendMailToolStripMenuItem.Name = "SendMailToolStripMenuItem"
        Me.SendMailToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.SendMailToolStripMenuItem.Text = "send mail"
        '
        'TerminalErrorTestToolStripMenuItem
        '
        Me.TerminalErrorTestToolStripMenuItem.Name = "TerminalErrorTestToolStripMenuItem"
        Me.TerminalErrorTestToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.TerminalErrorTestToolStripMenuItem.Text = "Terminal Error Test"
        '
        'TestExcelToolStripMenuItem
        '
        Me.TestExcelToolStripMenuItem.Name = "TestExcelToolStripMenuItem"
        Me.TestExcelToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.TestExcelToolStripMenuItem.Text = "Test Excel"
        '
        'TestRawPrintingToolStripMenuItem
        '
        Me.TestRawPrintingToolStripMenuItem.Name = "TestRawPrintingToolStripMenuItem"
        Me.TestRawPrintingToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.TestRawPrintingToolStripMenuItem.Text = "Test Raw Printing"
        '
        'AanpassenStandaardOmschrijvingenToolStripMenuItem
        '
        Me.AanpassenStandaardOmschrijvingenToolStripMenuItem.Name = "AanpassenStandaardOmschrijvingenToolStripMenuItem"
        Me.AanpassenStandaardOmschrijvingenToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.AanpassenStandaardOmschrijvingenToolStripMenuItem.Text = "Aanpassen Standaard Omschrijvingen"
        '
        'PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem
        '
        Me.PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem.Name = "PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem"
        Me.PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem.Size = New System.Drawing.Size(471, 22)
        Me.PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem.Text = "Purge PDocuments (until last facturatie date, verwijderen last bestel = false)"
        '
        'JustTestingToolStripMenuItem
        '
        Me.JustTestingToolStripMenuItem.Name = "JustTestingToolStripMenuItem"
        Me.JustTestingToolStripMenuItem.Size = New System.Drawing.Size(439, 22)
        Me.JustTestingToolStripMenuItem.Text = "Just testing"
        '
        'LblMessage
        '
        Me.LblMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblMessage.AutoSize = True
        Me.LblMessage.Font = New System.Drawing.Font("Trebuchet MS", 8.25!)
        Me.LblMessage.Location = New System.Drawing.Point(3, 371)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(0, 16)
        Me.LblMessage.TabIndex = 9
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(439, 22)
        Me.ToolStripMenuItem3.Text = "E-mailen Facturen"
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(819, 410)
        Me.Controls.Add(Me.LblMessage)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kleinblatt 2.0 (B040)"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents BestelLeverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArtikeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KlantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StandaardsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeestdagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OntgrendelStationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProductiePlanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompactDBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblMessage As b040.lblBase
    Friend WithEvents LeverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DagelijksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AanpassenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutomatischBestellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAfdrukkenVervoerEnAfrekening As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BestellingenAnnulerenVoorÉénDagToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FacturatieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SysteemProgrammasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerminalErrorTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendMailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestRawPrintingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JustTestingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AanpassenStandaardOmschrijvingenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents waitingMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OverzichtBestellingenPartculierenStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AfdrkenBestelDocumentenParticulierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
End Class

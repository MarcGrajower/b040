Imports System
Imports System.Collections.Specialized
Imports System.Collections.ObjectModel
Imports System.Collections
Imports System.Text
Imports System.Configuration
Imports Microsoft.VisualBasic
Imports System.Globalization
Imports System.ComponentModel
Imports System.Data.OleDb


Public Class frmMain
    Dim mdiClient As MdiClient
    Dim eOpenMode As eFormOpen = eFormOpen.eFormOpenNormal
    Dim moduleTypeOfClient As eTypeKlant = eTypeKlant.Groothandel
    Dim particulierColor As Color = applicationColors.applicationParticulierColor
    ''' <summary>
    ''' Not used - Set by Bestel on Alt K to prevent frmKlant to show.
    ''' </summary>
    Public preventExecution As Boolean = False
    Public WriteOnly Property typeKlant As eTypeKlant
        Set(value As eTypeKlant)
            If value = eTypeKlant.Groothandel Then
                Me.changeMainBackcolor(Color.DarkBlue)
            Else
                Me.changeMainBackcolor(particulierColor)
            End If
        End Set
    End Property
    Public cParameter As String
    Sub changeMainBackcolor(color As Color)
        For Each ctl As Control In Me.Controls
            If (TypeOf ctl Is MdiClient) Then
                CType(ctl, MdiClient).BackColor = color
                mdiClient = CType(ctl, MdiClient)
            End If
        Next
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.typeKlant = eTypeKlant.Groothandel
        If lb040Config(Me) = False Then
            MsgBox("Configuration failed")
            Me.Close()
        End If
        If CultureInfo.CurrentCulture.Name <> "nl-BE" Then
            MsgBox("Uw instelling 'Regional Settings' staat niet op Dutch(Belgium).  De werking van deze software is niet uitdrukkelijk getest voor Uw huidige instelling, daarom is het aangeraden om deze software toepassing niet in deze omstandigheden te gebruiken.")
        End If
        Dim handler As ThreadExceptionHandler = _
             New ThreadExceptionHandler()
        AddHandler Application.ThreadException, _
            AddressOf handler.Application_ThreadException
        'http://www.astahost.com/info.php/Vbnet-Find-Application-Build-Version_t5147.html
        Me.ToolStripStatusLabel1.Text = "Connected to : " & My.Settings.b040_beConnectionString
        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        Me.ToolStripStatusLabel2.Text = "Application : " & Application.ExecutablePath & "-" & myBuildInfo.ProductBuildPart
        Me.ToolStripStatusLabel3.Text = "Regional Setting : " & CultureInfo.CurrentCulture.Name
        Me.ToolStripStatusLabel4.Text = "Default Printer : " & cDefaultPrinter()
        Me.ToolStripStatusLabel5.Text = "Bijz. Printer : " & cConfiguredUitzPrinter()

        Me.IndexToolStripMenuItem.Visible = frmIndex.lActive

    End Sub

    Private Sub Feestdagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FeestdagenToolStripMenuItem.Click
        Dim o As New frmFeestdagen
        o.MdiParent = Me
        o.Show()
    End Sub

    Private Sub ArrangeWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeWindow.Click
        mdiClient.LayoutMdi(MdiLayout.Cascade)
        For i As Integer = 0 To Me.MdiChildren.Count - 1
            Dim o As frmB040 = CType(Me.MdiChildren(i), frmB040)
            o.Width = o.designWidth
            o.Height = o.designHeight
        Next
    End Sub

    'Private Sub frmMain_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    '    'Me.WindowState = FormWindowState.Maximized
    'End Sub

    Private Sub TerminalErrorTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerminalErrorTestToolStripMenuItem.Click
        Throw New InvalidOperationException("Programma fout test.")

    End Sub

    Private Sub SendMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMailToolStripMenuItem.Click
        SendEmail("EMail Test", "Email Test", "b040Mail2@gmail.com", "p806@yahoo.com", "p806@yahoo.com")
    End Sub

    Private Sub ArtikeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArtikeToolStripMenuItem.Click
        Dim o As New frmArtikel
        o.MdiParent = Me
        o.Show()
    End Sub
    Private Sub TestFormToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TestFormToolStripMenuItem.Click
        Dim o As New TestForm
        o.MdiParent = Me
        o.Show()
    End Sub

    Private Sub StandaardsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandaardsToolStripMenuItem.Click
        Dim f As New StandaardenFrm
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub KlantToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlantToolStripMenuItem.Click
        If preventExecution = True Then
            preventExecution = False
            Return
        End If
        Dim f As New KlantenFrm
        If Me.eOpenMode = eFormOpen.eFromOpenNew Then
            f.eOpenMode = eFormOpen.eFromOpenNew
            f.ModeShow = ModeShow.Modal
            Dim n As Long = f.ShowDialog
            Me.cParameter = f.cParameter
            f.Close()
            f = Nothing
        Else
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub BestelLeverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BestelLeverToolStripMenuItem.Click
        Dim f As New Bestelfrm
        f.oToggle = Bestelfrm.eToggle.eToggleBestelling
        f.MdiParent = Me : f.Show()
    End Sub

    Private Sub OntgrendelStationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OntgrendelStationToolStripMenuItem.Click
        ' MG 23/feb/11
        unlockCurrentStation()
    End Sub


    Private Sub TestExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestExcelToolStripMenuItem.Click
        testExcel()
    End Sub

    Private Sub TestRawPrintingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestRawPrintingToolStripMenuItem.Click
        Dim o As New StringBuilder
        o.AppendLine("Dit werd afgedrukt om te testen.")
        o.AppendLine()
        o.AppendLine("Indien mogelijk, mag dit geëmailed worden ")
        o.AppendLine("naar p806@yahoo.com.")
        o.AppendLine()
        o.AppendLine("Reeds bedankt.")
        Dim l As Boolean = clsRawPrinter.SendStringToPrinter(cDefaultPrinter, o.ToString, "Test")
        MsgBox(o.ToString & " printing to " & cDefaultPrinter() & IIf(l, " succeeded", " failed"))

    End Sub

    Private Sub CompactDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompactDBToolStripMenuItem.Click
        Dim f As New frmDatabaseComprimeren
        f.MdiParent = Me
        f.Show()

    End Sub


    Private Sub LeverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeverToolStripMenuItem.Click
        Dim f As New Bestelfrm
        f.oToggle = Bestelfrm.eToggle.eToggleLevering
        f.MdiParent = Me : f.Show()
    End Sub

    Private Sub AutomatischBestellenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomatischBestellenToolStripMenuItem.Click
        Dim f As New frmAutomatischBestellen
        f.MdiParent = Me : f.Show()
    End Sub

    Private Sub IndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IndexToolStripMenuItem.Click
        Dim fp As New frmPaswoord
        If fp.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim f As New frmIndex
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub DagelijksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DagelijksToolStripMenuItem.Click
        Dim f As New frmProductiePlan
        f.MdiParent = Me
        f.Show()
    End Sub


    Private Sub AanpassenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AanpassenToolStripMenuItem.Click
        Dim f As New frmProductiePlanOverzicht
        f.MdiParent = Me
        f.Show()
    End Sub

 
    Private Sub tsmiAfdrukkenVervoerEnAfrekening_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAfdrukkenVervoerEnAfrekening.Click
        Dim f As New frmAfdrukkenVervoerEnAfrekiningen
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim f As New frmKlantOperaties
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim f As New frmKlantFacturen
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub BestellingenAnnulerenVoorÉénDagToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BestellingenAnnulerenVoorÉénDagToolStripMenuItem.Click
        Dim f As New frmBestellingenAnnulerenPerDag
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub FacturatieToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturatieToolStripMenuItem.Click
        Dim f As New frmBatchFacturatie
        f.MdiParent = Me
        f.Show()

    End Sub


    Private Sub BestelTotalennaConversieToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New frmBestelTotalen
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub AanpassenStandaardOmschrijvingenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AanpassenStandaardOmschrijvingenToolStripMenuItem.Click
        Dim f As New frmStandaardomschrijvingenAanpassen
        f.MdiParent = Me
        f.Show()
    End Sub
    Public Shared Sub setBackgroundColor(TypeKlant As String)
        Dim e As eTypeKlant = eTypeKlant.Groothandel
        If TypeKlant = "Particulier" Then
            e = eTypeKlant.Particulier
        End If
        frmMain.typeKlant = e
    End Sub
    Public Shared Sub resetBackgroundColor()
        frmMain.typeKlant = eTypeKlant.Groothandel
    End Sub
    Private Sub OverzichtBestellingenParticulierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OverzichtBestellingenPartculierenStripMenuItem.Click
        Dim dates() As Date = Nothing
        Dim nodates As Boolean
        ParticulierenBestellingen.getDates(dates, nodates)
        If nodates = True Then
            MsgBox("Er zijn op dit ogenblick geen bestellingen voor Particulieren")
            Return
        End If
        Dim f As New ParticulierenBestellingenForm
        f.validDates = dates
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub PurgePDocumentsuntilLastFacutratieDateVerwijderenLastBestelFalseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PirgePDcouemntsuntilLastFacutratieDateVerwijderenLastBestlFalseToolStripMenuItem.Click
        frmBatchFacturatie.particulierenPurge(False)
    End Sub

    Private Sub AfdrkenBestelDocumentenParticulierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfdrkenBestelDocumentenParticulierenToolStripMenuItem.Click
        Dim dates() As Date = Nothing
        Dim nodates As Boolean
        ParticulierenBestellingen.getDates(dates, nodates)
        If nodates = True Then
            MsgBox("Er zijn op dit ogenblick geen bestellingen voor Particulieren")
            Return
        End If
        Dim f As New frmAfdrukkenDocumentenParticulieren
        f.validDates = dates
        f.MdiParent = Me
        f.Show()

        'Dim d As Date = bzBestel.dGetDefaultLeveringDatum()
        'Using xl As New clsExcel
        '    frmAfdrukkenVervoerEnAfrekiningen.processParticulieren(xl, d)
        'End Using
        'MsgBox("De bestellingen van Particulieren werden afgedrukt.")
    End Sub

    Private Sub AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfdrukkenOverzichtLijstMetNamenVanBestellingenParticulierenToolStripMenuItem.Click
        Dim dates() As Date = Nothing
        Dim nodates As Boolean
        ParticulierenBestellingen.getDates(dates, nodates)
        If nodates = True Then
            MsgBox("Er zijn op dit ogenblik geen bestellingen voor Particulieren")
            Return
        End If
        Dim f As New frmAfdrukkenDocumentenParticulieren
        f.afdrukkenDocumenten = False
        f.validDates = dates
        f.MdiParent = Me
        f.Show()
    End Sub


End Class

Public Class BestelHardcopyRequestFrm
    Inherits frmB040
    Public lAfdrukkenTour As Boolean
    Public lUitzonderlijk As Boolean
    Public cUitzPrinter As String
    Public particulierMode As Boolean
    Public Sub initializeReporting()
        Dim pc As New PrinterClass
        pc.fillCbo(Me.cboPrinters)
        Me.cboPrinters.Text = pc.DefaultPrinterName
        Me.cboPrinters.Items.Add(PrinterClass.cPreview)
        For i As Integer = 0 To Me.cboPrinters.Items.Count - 1
            Me.UitzondelijkPrinter.Items.Add(Me.cboPrinters.Items(i))
        Next
        Me.Uitzonderlijk.Text = IIf(Me.lUitzonderlijk = True, "Ja", "Neen")
        Me.epson_button.nIO = IIf(Me.lUitzonderlijk, IOValues.IOAlwaysEnable, IOValues.IOAlwaysDisable)
        Me.epson_button.ioEnable(ModeValues.RecordEntry)
        Me.AfdrukkenTour.Text = IIf(Me.lAfdrukkenTour = True, "Ja", "Neen")
        Me.UitzondelijkPrinter.Text = Me.cUitzPrinter
        If Me.lUitzonderlijk Then
            Me.epson_button.Focus()
        Else
            Me.btnOK.Focus()
        End If
        Me.ParticulierJaNeen.Text = IIf(Me.particulierMode, "Ja", "Neen")
    End Sub
    Private Sub BestelHardcopyRequestFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initializeReporting()
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Sub setGeneric()
        If Me.Afrekening.Text = "" Then Me.Afrekening.Text = "0"
        If Me.Vervoer.Text = "" Then Me.Vervoer.Text = "0"
        If Me.Faktuur.Text = "" Then Me.Faktuur.Text = "0"
        Me.lAfdrukkenTour = (Me.AfdrukkenTour.Text = "Ja")
        Me.lUitzonderlijk = False
        Me.TourCtl.Text = Trim(Me.TourCtl.Text)
        If Me.TourCtl.Text = "" Then Me.TourCtl.Text = " "
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        setGeneric()
    End Sub
    Public Sub setEpson()
        Me.Afrekening.Text = "0"
        Me.Vervoer.Text = "0"
        Me.Faktuur.Text = "0"
        Me.lAfdrukkenTour = (Me.AfdrukkenTour.Text = "Ja")
        Me.lUitzonderlijk = (Me.Uitzonderlijk.Text = "Ja")
        Me.TourCtl.Text = Trim(Me.TourCtl.Text)
        If Me.TourCtl.Text = "" Then Me.TourCtl.Text = " "
    End Sub
    Private Sub epson_button_Click(sender As System.Object, e As System.EventArgs) Handles epson_button.Click
        setEpson()
    End Sub
End Class
Public Class printersCombobox
    Private Sub initialize()
        For Each printer In Printing.PrinterSettings.InstalledPrinters
            CboBase1.Items.Add(printer)
        Next
        Dim ps As New Printing.PrinterSettings
        CboBase1.Text = ps.PrinterName
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        initialize()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub printersCombobox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CboBase1.Left = Me.Left
        CboBase1.Width = Me.Width
        CboBase1.SelectionLength = 0
    End Sub
    Public Sub setPrinter(name As String)
        CboBase1.Text = name
    End Sub
End Class

Imports System.Drawing.Printing
Public Class PrinterClass
    Public Const previewPrinterConstant = "<PREVIEW>"
    Public Shared cPreview As String = "<PREVIEW>"
    Public Shared cNoPrinter As String = "<NOPRINTER>"
    Dim PS As New PrinterSettings
    Public Function DefaultPrinterName() As String
        Return PS.PrinterName
    End Function
    Public Sub fillCbo(ByVal cb As ComboBox)
        Dim n As Integer = PrinterSettings.InstalledPrinters.Count
        For i As Integer = 0 To n - 1
            cb.Items.Add(PrinterSettings.InstalledPrinters.Item(i))
        Next
    End Sub
    Public Shared Sub addPreview(printers As printersCombobox)
        printers.CboBase1.Items.Add(PrinterClass.cPreview)
    End Sub
End Class

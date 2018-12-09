Public Class ParticulierenBestellingenForm
    Public nodates As Boolean
    Public validDates() As Date
    Dim currentDate As Date
    Private Function getDefaultdate()
        Dim found As Boolean = False
        For i As Integer = 0 To UBound(validDates)
            If validDates(i) > Now() Then
                Return validDates(i)
            End If
        Next
        Return validDates(UBound(validDates) - 1)
    End Function
    Private Function formatDateForLabel(d As Date)
        Return modDutch.cDagInDeWeek(d) & ", " & Format(d, "dd-MM-yy")
    End Function
    Private Sub ParticulierenBestellingenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        leveringMonthCalendar.MonthlyBoldedDates = validDates
        Dim d As Date = getDefaultdate()
        leveringMonthCalendar.MinDate = validDates(0)
        leveringMonthCalendar.MaxDate = validDates(UBound(validDates) - 1)

        leveringMonthCalendar.SelectionStart = d
        leveringMonthCalendar.SelectionEnd = d
        leveringLabel.Text = formatDateForLabel(d)
        copijenTextBox.Text = 1
        PrinterClass.addPreview(printersCombobox1)
        printersCombobox1.setPrinter(modB040Config.cDefaultPrinter())
    End Sub
    Private Sub copijenTextBox_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles copijenTextBox.MaskInputRejected
        copijenTextBox.Text = Val(cNvl(copijenTextBox.Text))
    End Sub
    Private Sub leveringMonthCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles leveringMonthCalendar.DateChanged
        If validDates.Contains(leveringMonthCalendar.SelectionStart) <> True Then
            leveringMonthCalendar.SelectionStart = currentDate
            Return
        End If
        currentDate = leveringMonthCalendar.SelectionStart
        leveringLabel.Text = formatDateForLabel(leveringMonthCalendar.SelectionStart)
    End Sub
    Private Sub AnnulerenButton_Click(sender As Object, e As EventArgs) Handles AnnulerenButton.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim report As New ParticulierenBestellingen
        report.printer = printersCombobox1.CboBase1.Text
        report.copijen = Val(copijenTextBox.Text)
        report.datum = leveringMonthCalendar.SelectionStart
        report.report()
        MsgBox("Uw verslag werd afgedrukt")
    End Sub
End Class
Public Class frmAfdrukkenDocumentenParticulieren
    Public afdrukkenDocumenten As Boolean = True
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
    Private Function formatDateForLabel(d As Date) As String
        Return modDutch.cDagInDeWeek(d) & " " & d.Day
    End Function
    Private Sub frmAfdrukkenDocumentenParticulieren_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If afdrukkenDocumenten = False Then
            Text = "Afdrukken Overzicht Bestellingen Particulieren"
            Me.information.Text = "Drukt Overzicht (Namen) van Bestellingen Particulieren"
        End If
        MonthCalendar1.MonthlyBoldedDates = validDates
        Dim d As Date = getDefaultdate()
        MonthCalendar1.MinDate = validDates(0)
        MonthCalendar1.MaxDate = validDates(UBound(validDates) - 1)
        MonthCalendar1.SelectionStart = d
        MonthCalendar1.SelectionEnd = d
        dagLabel.Text = formatDateForLabel(d)
    End Sub
    Private Sub annuleren_Click(sender As Object, e As EventArgs) Handles annuleren.Click
        Close()
    End Sub
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        If validDates.Contains(MonthCalendar1.SelectionStart) <> True Then
            MonthCalendar1.SelectionStart = currentDate
            Return
        End If
        currentDate = MonthCalendar1.SelectionStart
        dagLabel.Text = formatDateForLabel(currentDate)
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Using xl As New clsExcel
            If afdrukkenDocumenten = True Then
                frmAfdrukkenVervoerEnAfrekiningen.processParticulieren(xl, currentDate)
            Else
                batchAfdrukkenParticulierenOverzicht.report(xl, currentDate, cDefaultPrinter)
            End If
        End Using
        If afdrukkenDocumenten = True Then
            MsgBox("De documenten van Particulieren werden afgedrukt.")
        Else
            MsgBox("Het overzicht is afgedrukt.")
        End If
    End Sub
End Class
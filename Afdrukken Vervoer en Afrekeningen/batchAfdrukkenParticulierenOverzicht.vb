''' <summary>
''' This is an per artikel
''' </summary>
''' <remarks></remarks>
Public Class batchAfdrukkenParticulierenOverzicht
    Shared Sub AddParameter(value As Object, type As DbType, ByRef sql As sqlClass)
        p = New OleDb.OleDbParameter
        p.Value = value
        p.DbType = type
        sql.parameterCollection.Add(p)
    End Sub
    Shared Sub getLijnen(ByRef dt As DataTable, datum As Date)
        Dim Sql As New sqlClass
        Sql.AddParameter(datum, DbType.Date)
        '        Sql.AddParameter(BzWinkelproductie.klId, DbType.Int32)
        Sql.Execute("qryBatchAfdrukkenParticulieren")
        dt = Sql.dt.Copy()
    End Sub
    Shared Sub moveToSheet(dt As DataTable, xl As clsExcel, komthalen As Boolean)
        Dim range As String = ""
        For Each dr As DataRow In dt.Rows
            If dr("BestH_KomtHalen") = komthalen Then
                range &= dr("Naam") & vbTab
                range &= dr("Telefoon") & vbTab
                range &= vbCrLf
            End If
        Next
        xl.pasteToRange("rngLijn1", range, 1)
    End Sub
    Shared Sub reportByKomtHalen(xl As clsExcel,
                                        komtHalen As Boolean,
                                        dt As DataTable,
                                        datum As Date,
                                        Optional printerName As String = PrinterClass.previewPrinterConstant)
        xl.openWorkbook(cXLSFolder() & "batchAfdrukkenParticulierenOverzicht.xls")
        xl.cPrinter = printerName
        xl.nCopies = 1
        xl.setString("rngLeveringsDatum", datum)
        komtHalenDescription = IIf(komtHalen, "Komt Halen", "Sturen")
        xl.setString("rngKomtHalen", komtHalenDescription)
        moveToSheet(dt, xl, komtHalen)
        xl.cXlsRoot = "bAPO_" & komtHalenDescription & "_" & Format(datum, "yyMMdd")
        xl.printOut()
    End Sub
    Public Shared Sub report(xl As clsExcel,
                             datum As Date,
                             Optional printername As String = PrinterClass.previewPrinterConstant)
        Dim dt As New DataTable
        getLijnen(dt, datum)
        reportByKomtHalen(xl, True, dt, datum, printername)
        reportByKomtHalen(xl, False, dt, datum, printername)
    End Sub
End Class

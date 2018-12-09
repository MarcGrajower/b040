Imports Microsoft.Office.Interop
Public Class clsExcel
    Implements IDisposable
    Public oApp As New Excel.Application
    Public oWBs As Excel.Workbooks
    Public oWB As Excel.Workbook
    Public Selection As Excel.Range

    Public originalCulture As System.Globalization.CultureInfo
    Dim thisThread As System.Threading.Thread
    Dim lQuit As Boolean = True
    Dim lDisposed As Boolean = False

    Public cPrinter As String
    Public nCopies As Integer
    Public cXlsRoot As String
    Sub New()
        Me.thisThread = System.Threading.Thread.CurrentThread
        Me.originalCulture = thisThread.CurrentCulture
        Me.thisThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Me.oWBs = Me.oApp.Workbooks
        Me.oApp.DisplayAlerts = False
    End Sub
    Sub Dispose() Implements IDisposable.Dispose
        If Me.lDisposed Then Exit Sub
        If lQuit Then Me.oApp.Quit()
        Me.releaseObject(Me.oWB)
        Me.releaseObject(Me.oWBs)
        Me.releaseObject(Me.oApp)
        Me.thisThread.CurrentCulture = Me.originalCulture
        Me.lDisposed = True
    End Sub
    Protected Overrides Sub finalize()
        Me.Dispose()
    End Sub
    Public Sub releaseObject(ByVal o As Object)
        If o Is Nothing Then Exit Sub
        Runtime.InteropServices.Marshal.FinalReleaseComObject(o)
        o = Nothing
    End Sub
    Public Function openWorkbook(ByVal cPath, Optional ByVal lReadonly = True) As Excel.Workbook
        Me.oWB = Me.oWBs.Open(cPath, , lReadonly)
        Return Me.oWB
    End Function
    Public Sub setString(ByVal cRng As String, ByVal cValue As String)
        Me.setString(cRng, cValue, 0)
    End Sub
    Public Sub setstring(ByVal cRng As String, ByVal cValue As String, ByVal nRow As Integer)
        Me.oApp.Range(cRng)(nRow + 1) = cValue
    End Sub
    'Public Sub setString(ByVal nRow As Long, ByVal nCol As Long, ByVal cValue As String)
    '    Me.oApp.Cells(nRow, nCol) = cValue
    'End Sub
    Public Sub setNum(ByVal cRng As String, ByVal n As Double)
        Me.setString(cRng, n, 0)
    End Sub
    Public Sub setNum(ByVal cRng As String, ByVal n As Double, ByVal nRow As Integer)
        Me.oApp.Range(cRng)(nRow + 1) = n
    End Sub
    Public Sub setVisible()
        Me.oApp.Range("A1").Select()
        Me.oApp.ActiveWindow.View = Excel.XlWindowView.xlNormalView
        Me.oApp.ActiveWindow.Zoom = 150
        Me.oApp.Visible = True
        Me.lQuit = False
    End Sub
    Public Sub printOut()
        ' MG(16 / apr / 11)
        'If My.Computer.Name = "NIETZSCHE" Then
        '    Me.saveAs()
        '    Exit Sub
        'End If
        If Me.cPrinter = PrinterClass.cPreview Then
            Me.setVisible()
            Me.saveAs()
            Exit Sub
        End If
        If Me.cPrinter = PrinterClass.cNoPrinter Then
            Me.saveAs()
            Exit Sub
        End If
        If Me.nCopies = 0 Then
            Exit Sub
        End If
        Me.oWB.PrintOut(, , Me.nCopies, False, Me.cPrinter)
    End Sub
    Public Sub saveAs()
        ' MG 16/apr/11
        If Me.oWB Is Nothing Then
            Return
        End If
        If modB040Config.lPreviewSaves = False Then Exit Sub
        Dim c As String = modB040Config.cDocsFolder & Me.cXlsRoot
        Dim c1 As String : c1 = c & ".xls"
        If IO.File.Exists(c1) Then
            Dim n As Integer : n = 1
            Do
                c1 = (c & "_" & Right("000" & n, 3) & ".xls")
                n += 1
            Loop Until IO.File.Exists(c1) = False
        End If

        Me.oWB.SaveAs(c1)
    End Sub
    Public Sub pasteToRange(ByVal cRange As String, ByVal c As String)
        ' MG 16/apr/11
        Me.pasteToRange(cRange, c, 2)
    End Sub
    Public Sub pasteToRange(ByVal cRange As String, ByVal c As String, ByVal nOffset As Integer)
        ' MG 16/apr/11
        ' assume cRange is the left most column's title cell
        ' needs to be overloaded with offset.  This should then call with offset 2
        If c = "" Then Exit Sub
        Clipboard.SetText(c)
        Me.oApp.Range(cRange)(nOffset).Select()
        Me.oApp.ActiveSheet.paste()
    End Sub
    Public Sub fmt2Dec(ByVal cRange As String, ByVal nLines As Integer)
        Dim nCol As Integer : nCol = Me.oApp.Range(cRange).Column
        Dim nRow As Integer : nRow = Me.oApp.Range(cRange).Row
        With Me.oApp
            .Range(.Cells(nRow + 1, nCol), .Cells(nRow + nLines, nCol)).NumberFormat = "#,##0.00"
        End With
    End Sub
    Public Sub fmt2Dec(ByVal cRange As String)
        Me.fmt2Dec(cRange, 0)
    End Sub
    Public Sub fmt2Dec()
        Me.Selection.NumberFormat = "#,##0.00"
    End Sub
    Public Function nUsedrangeRow()
        Return Me.oApp.ActiveSheet.usedrange.rows.count
    End Function
    Public Function nUsedRangeColumn()
        Return Me.oApp.ActiveSheet.usedrange.columns.count
    End Function
    Public Sub borderSingle()
        Dim nRow As Integer = Me.nUsedrangeRow
        Dim nCol As Integer = Me.nUsedRangeColumn
        With Me.oApp
            .Range(.Cells(nRow, 1), .Cells(nRow, nCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        End With
    End Sub
    Public Sub borderSingle(ByVal nRow)
        Dim nCol As Integer = Me.nUsedRangeColumn
        With Me.oApp
            .Range(.Cells(nRow, 1), .Cells(nRow, nCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        End With
    End Sub
    Public Sub borderDouble()
        Dim nRow As Integer = Me.nUsedrangeRow()
        Dim nCol As Integer = Me.nUsedRangeColumn()
        With Me.oApp
            .Range(.Cells(nRow, 1), .Cells(nRow, nCol)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range(.Cells(nRow, 1), .Cells(nRow, nCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
        End With
    End Sub
    Public Sub sumRange(ByVal cRange As String, ByVal nLines As Integer)
        Dim nCol As Integer : nCol = oApp.Range(cRange).Column
        Dim nRow As Integer : nRow = oApp.ActiveSheet.usedrange.rows.count + 1
        oApp.Cells(nRow, nCol).formular1c1 = "=sum(R[" & -nLines & "]C:R[-1]C)"
    End Sub
    Public Sub nameRange(ByVal cName As String, ByVal nRow As Integer, ByVal nCol As Integer)
        oApp.Cells(nRow, nCol).select()
        oApp.Names.Add(cName, oApp.Selection)
    End Sub
    Public Sub justifyRight(ByVal cRange As String, ByVal nOffset As Integer)
        oApp.Range(cRange)(nOffset + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
    End Sub
    Public Sub justifyRight()
        Me.Selection.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
    End Sub
    Public Sub fmtBold(ByVal cRange As String)
        oApp.Range(cRange).Font.Bold = True
    End Sub
    Public Sub fmtBold()
        Me.Selection.Font.Bold = True
    End Sub
    Public Sub fmtItalic()
        Me.Selection.Font.Italic = True
    End Sub
    Public Sub selectRange(ByVal nRow As Integer, ByVal nCol As Integer)
        Me.oApp.Cells(nRow, nCol).select()
        Me.Selection = Me.oApp.Selection
    End Sub
    Public Sub selectRange(ByVal nRow1 As Integer, ByVal nCol1 As Integer, ByVal nRow2 As Integer, ByVal nCol2 As Integer)
        With Me.oApp
            .Range(.Cells(nRow1, nCol1), .Cells(nRow2, nCol2)).Select()
        End With
        Me.Selection = Me.oApp.Selection
    End Sub
    Public Sub selectRange(ByVal cRange As String)
        With Me.oApp
            .Range(cRange).Select()
        End With
        Me.Selection = Me.oApp.Selection
    End Sub
    Public Sub selectRange(ByVal cRange As String, ByVal nRows As Integer)
        Dim nRow As Integer = Me.nRow(cRange) + nRows
        Dim nCol As Integer = Me.nColumn(cRange)
        Me.selectRange(nRow, nCol)
    End Sub
    Public Function nRow(ByVal cRange As String) As Integer
        ' MG 21/apr/11
        Return Me.oApp.Range(cRange).Row
    End Function
    Public Function nColumn(ByVal cRange As String) As Integer
        ' MG 21/apr/11
        Return Me.oApp.Range(cRange).Column
    End Function
    Public Sub insertRows(ByVal nRow As Integer, ByVal nRows As Integer)
        ' MG 21/apr/11
        Me.oApp.Rows(nRow + 1 & ":" & nRow + nRows).select()
        Me.oApp.Selection.insert(Excel.XlDirection.xlDown, 1)
    End Sub
    Sub fitLastPage(ByVal nMinLines As Integer)
        ' MG 21/apr/11
        Dim s As Excel.Worksheet = Me.oApp.ActiveSheet
        Dim nPageBreaks As Integer = s.HPageBreaks.Count
        If nPageBreaks = 0 Then Exit Sub
        Dim nLastPagebreak = s.HPageBreaks(nPageBreaks).Location.Row - 1
        Dim nUsedRows As Integer = Me.nUsedrangeRow - 1
        If nUsedRows - nLastPagebreak < nMinLines Then
            With s.PageSetup
                .Zoom = False
                .FitToPagesTall = nPageBreaks
            End With
        End If
    End Sub
    Sub selFmtAsLinenr()
        Me.oApp.Selection.NumberFormat = "0""."""
        Me.oApp.Selection.Font.Size = 8
    End Sub
    Sub fmtRed()
        'color.red was too simple.. MG 09/jul/11
        Me.oApp.Selection.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
    End Sub
    Public Function cGet(ByVal nRow As Long, ByVal nColumn As Long) As String
        Return Me.oApp.Cells(nRow, nColumn).value

    End Function
    Public Function nGetDouble(ByVal nRow As Long, ByVal nColumn As Long) As Double
        Return Me.oApp.Cells(nRow, nColumn).value
    End Function
    Public Sub selClear()
        Me.oApp.Selection.clear()
    End Sub
    Public Sub selPercent()
        Me.oApp.Selection.numberformat = "0.00%"
    End Sub
    Public Sub formatSelectionAsTotal()
        Dim selection As Excel.Range = Me.oApp.Selection
        With selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = Excel.XlBorderWeight.xlThin
        End With
        With selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
            .LineStyle = Excel.XlLineStyle.xlDouble
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = Excel.XlBorderWeight.xlThick
        End With
    End Sub
    Public Sub formatSelectionLineTop()
        Dim selection As Excel.Range = Me.oApp.Selection
        With selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .ColorIndex = 0
            .TintAndShade = 0
            .Weight = Excel.XlBorderWeight.xlThin
        End With
    End Sub
    Public Sub formatRangeRightJustify(rangeString As String)
        Me.oApp.Range(rangeString).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
    End Sub
    Public Sub SetBackgroundLightgreen()
        Dim selection As Excel.Range = Me.oApp.Selection
        With selection.Interior
            .Pattern = Excel.XlPattern.xlPatternSolid
            .PatternColorIndex = -4105 ' Excel.XlPattern.xlPatternAutomatic
            .ThemeColor = 7 'xlThemeColorAccent3
            .TintAndShade = 0.799981688894314
            .PatternTintAndShade = 0
        End With
    End Sub
End Class

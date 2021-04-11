using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace B040.ExcelAddin
{
    public class RibbonBase
    {
        public void Autofit()
        {
            _Xl.Selection.EntireColumn.AutoFit();
        }
        public double GetColumnWidth()
        {
            return _Xl.Selection.ColumnWidth;
        }
        public void Select(int row, string column)
        {
            _Ws.Range[column + row].Select();
        }
        public void Select(int row, int column)
        {
            _Ws.Cells[row, column].Select();
        }
        public void Select(string address)
        {
            _Ws.Range[address].Select();
        }
        public void Select(int row, int column, int row2, int column2)
        {
            _Ws.Range[_Ws.Cells[row, column], _Ws.Cells[row2, column2]].Select();
        }
        public void SetCaption(string caption)
        {
            _Ws.Name = caption;
        }
        public void SetColumnWidth(double columnWidth)
        {
            _Xl.Selection.ColumnWidth = columnWidth;
        }
        public void SetFormula(string formula)
        {
            _Xl.Selection.Formula = formula;
        }
        public void SetValue<T>(T v)
        {

            _Xl.Selection.Value2 = v;
            return;
        }
        public void FormatDecimal()
        {
            ((Range)_Xl.Selection).NumberFormat = "#,##0.00";
        }
        public void FormatH2()
        {
            _Xl.Selection.Font.Bold = true;
            _Xl.Selection.Font.Size = 14;
            _Xl.Selection.Font.ThemeColor = XlThemeColor.xlThemeColorAccent5;
            _Xl.Selection.Font.TintAndShade = -0.2499771011117893;
        }
        public void FormatTitle()
        {
            _Xl.Selection.Font.Bold = true;
            _Xl.Selection.Interior.ThemeColor = XlThemeColor.xlThemeColorDark1;
            _Xl.Selection.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            _Xl.Selection.Interior.TintAndShade = -0.149998474074526;
        }
        public void FormatTotals()
        {
            _Xl.Selection.Borders(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
            _Xl.Selection.Borders(XlBordersIndex.xlEdgeTop).ColorIndex = 0;
            _Xl.Selection.Borders(XlBordersIndex.xlEdgeTop).TintAndShade = 0;
            _Xl.Selection.Borders(XlBordersIndex.xlEdgeTop).Weight = XlBorderWeight.xlThin;
            _Xl.Selection.Borders(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlDouble;
            _Xl.Selection.Borders(XlBordersIndex.xlEdgeBottom).ColorIndex = 0;
            _Xl.Selection.Borders(XlBordersIndex.xlEdgeBottom).TintAndShade = 0;
            _Xl.Selection.Borders(XlBordersIndex.xlEdgeBottom).Weight = XlBorderWeight.xlThick;
            _Xl.Selection.Font.Bold = true;
        }
 
        public RibbonBase()
        {
            _Xl = Globals.ThisAddIn.Application;
            _Wb = _Xl.ActiveWorkbook;
            _Ws = _Xl.ActiveSheet;
        }
        internal Application _Xl;
        internal Worksheet _Ws;
        internal Workbook _Wb;
    }
}

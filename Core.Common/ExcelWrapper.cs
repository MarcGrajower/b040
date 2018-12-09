using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Windows;
namespace Core.Common
{
    public class ExcelWrapper : IDisposable
    {
        public enum Formats {decimal2,decimal0,date,text}
        public Excel.Application app;
        public Excel.Workbooks wbs;
        public Excel.Workbook wb;
        public Excel.Worksheets wss;
        public Excel.Worksheet ws;
        public Excel.Range rng;
        public bool mustQuit = true;
        CultureInfo originalCulture;
        Thread thread;
        
        bool disposed = false;
        #region "Dispose"
        public ExcelWrapper()
        {
            thread = Thread.CurrentThread;
            originalCulture = thread.CurrentCulture;
            app = new Excel.Application();
            app.DisplayAlerts = false;
            wbs = app.Workbooks;
        }
        void releaseObject(object o)
        {
            if (o == null) 
            {
                return;
            }
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o);
        }
        public void Dispose() {
            if (disposed){
                return;
            }
            // try { wb.Close(); } finally { }
            if (mustQuit) {
                app.Quit();
            }
            releaseObject(rng);
            releaseObject(ws);
            releaseObject(wss);
            releaseObject(wb);
            releaseObject(wbs);
            thread.CurrentCulture = originalCulture;
            disposed = true;
        }
        ~ExcelWrapper()
        {   
        	Dispose();
        }
        #endregion

        public string getString(long row,long column)
        {
            rng = ws.Cells[row, column];
            if (rng.Value2 == null)
            {
                return "";
            }
            return rng.get_Value().ToString();
        }
        public string getString(long row, string column)
        {
            rng = ws.Range[column + row];
            if (rng.Value2 == null)
            {
                return "";
            }
            return rng.get_Value().ToString();
        }
        public void SetValue(string value,long row,string column)
        {
            ws.Range[column + row].Value2 = value;
        }
        public void SetValue(decimal value, long row, string column)
        {
            ws.Range[column + row].Value2 = value;
        }
        public DateTime getDate(long row, string column)
        {
            rng = ws.Range[column + row];
            DateTime d;
            DateTime.TryParse(rng.Value2,out d);
            return d;
        }
        public decimal getDecimal(long row, string column)
        {
            rng = ws.Range[column + row];
            if (rng.Value2 == null)
            {
                return 0;
            }
            return (decimal) rng.Value2;
        }
        public long getUsedColumns()
        {
            rng = ws.UsedRange;
            return rng.Columns.Count;
        }
        public long getUsedRows()
        {
            rng = ws.UsedRange;
            return rng.Rows.Count;
        }
        public void loadRange(String Key,out Boolean isOK)
        {
            rng = app.Cells.Find(Key,LookAt: 1);
            isOK = !(rng == null);
        }
        public void formatTitle()
        {
            this.app.Selection.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            this.app.Selection.Font.Bold = true;
            this.app.Selection.Interior.ThemeColor = 1;
            this.app.Selection.Interior.TintAndShade = -0.149998474074526;
            this.app.Selection.AutoFilter();
        }
        public void formatTotals()
        {
            app.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlThin;
            app.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble;
            app.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThick;
            app.Selection.Font.Bold = true;
        }
        public void formatColumn(string column, Formats format)
        {
            switch (format)
            {
                case Formats.decimal2:
                    rng = ws.Columns[column];
                    rng.NumberFormat = "_ * #,##0.00_ ;[red]_ * -#,##0.00_ ;_ * \"-\"??_ ;_ @_ ";
                    break;
                case Formats.decimal0:
                    rng = ws.Columns[column];
                    rng.NumberFormat = "_ * #,##0_ ;[red]_ * -#,##0_ ;_ * \"-\"??_ ;_ @_ ";
                    break;
                case Formats.date:
                    rng = ws.Columns[column];
                    rng.NumberFormat = "dd-MMM-yy";
                    break;
            }
        }
        public void setColumnWidth()
        {
            ws.UsedRange.EntireColumn.AutoFit();
        }
        [STAThread]
        public void saveDatatable(DataTable dt, string filename)
        {
            wb = wbs.Add();
            int col = 0;
            foreach (DataColumn item in dt.Columns)
            {
                col++;
                wb.ActiveSheet.Cells(1, col).value = dt.Columns[col - 1].ColumnName;
            }
            // int exit = 10;
            int rowNumber = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow r in dt.Rows)
            {
                col = 0;
                rowNumber++;
                Debug.Print(string.Format("Row {0}", rowNumber));
                StringBuilder sb2 = new StringBuilder();

                foreach (DataColumn c in dt.Columns)
                {
                    col++;
                    sb2.Append(dt.Rows[rowNumber - 1][col - 1] + "\t");
                }
                sb.Append(sb2.ToString().Replace("\r\n","") + "\n");
            }
            System.Windows.Forms.Clipboard.SetText(sb.ToString());
            ws = wb.ActiveSheet;
            rng = ws.Range["A2"];
            rng.Select();
            ws = wb.ActiveSheet;
            ws.Paste();
            wb.SaveAs(filename);
        }
     }
}

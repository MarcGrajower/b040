using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using b040;
using Microsoft.Office.Interop.Excel;

namespace B040.ExcelAddin
{
    public class MaandelijkseFacturatieStatistiekenRibbon : RibbonBase    
    {
        public void Go()
        {
            MaandelijkseFacturatiStatistieken.GetData(2021, 2);
            Select(1, "A");
            SetValue("Periode");
            FormatH2();
            Select(1, "B");
            SetValue(MaandelijkseFacturatiStatistieken.GetMonthString());
            FormatH2();
            var titles = new string[] { "Categorie", "Artikel", "Art Nr", "Hoev", "Eenheid", "Prijs", "Gefactureerd (EUR)", "Netto(EUR)" };
            var dt = MaandelijkseFacturatiStatistieken.GetDataTable();
            int col = 0;
            foreach (var t in titles)
            {
                Select(3, ++col);
                SetValue(t);
                FormatTitle();
            }
            int rowNumber = 3;
            foreach (DataRow r in dt.Rows)
            {
                rowNumber++;
                int colNumber = 0;
                foreach (var f in r.ItemArray)
                {
                    Select(rowNumber, ++colNumber);
                    SetValue(f);
                }
            }
            int rowCount = dt.Rows.Count;
            int lastRow = rowCount + 3;
            Select(4, 6, lastRow, 8);
            FormatDecimal();
            int rowTotals = 4 + rowCount;
            Select(rowTotals, "G");
            SetFormula($"=sum(G4:G{lastRow})");
            Select(rowTotals, "H");
            SetFormula($"=sum(H4:H{lastRow})");
            Select(rowTotals, 1, rowTotals, 8);
            FormatTotals();
            Select(1, 1, 1, 8);
            Autofit();
            SetCaption("Details");
            AddPivotTable();

            SetCaption("Overzicht");
            Select("B1");
            double columnWidth = GetColumnWidth();
            Select("C1");
            SetColumnWidth(columnWidth);
            Select("D1");
            SetColumnWidth(columnWidth);
            Select("E1");
            SetColumnWidth(columnWidth);
        }
        public void AddPivotTable()
        {
            Range pivotData = _Ws.Range["a3:H343"];
            string pivotTableName = "Overzicht";
            Worksheet destinationSheet = _Wb.Sheets.Add();
            Range pivotDestination = destinationSheet.Range["A3", Type.Missing];
            _Wb.PivotTableWizard(
                    XlPivotTableSourceType.xlDatabase,
                    pivotData,
                    pivotDestination,
                    pivotTableName,
                    true,
                    true,
                    true,
                    true,
                    Type.Missing,
                    Type.Missing,
                    false,
                    false,
                    XlOrder.xlDownThenOver,
                    0,
                    Type.Missing,
                    Type.Missing
            );

            // Set variables used to manipulate the Pivot Table.
            PivotTable pivotTable = (PivotTable)destinationSheet.PivotTables(pivotTableName);

            PivotField categoriePivotField = (PivotField)pivotTable.PivotFields(1);
            PivotField gefactureerdPivotField1 = (PivotField)pivotTable.PivotFields(7);
            PivotField gefactureerdPivotField2 = (PivotField)pivotTable.PivotFields(7);
            PivotField netPivotField1 = (PivotField)pivotTable.PivotFields(8);
            PivotField netPivotField2 = (PivotField)pivotTable.PivotFields(8);

            // Format the Pivot Table.
            pivotTable.Format(XlPivotFormatType.xlReport10);
            //pivotTable.InGridDropZones = false;
            //pivotTable.SmallGrid = false;
            //pivotTable.ShowTableStyleRowStripes = true;
            //pivotTable.TableStyle2 = "PivotStyleLight1";
            // Row Fields
            categoriePivotField.Orientation = XlPivotFieldOrientation.xlRowField;

            // Data Field
            gefactureerdPivotField1.Orientation = XlPivotFieldOrientation.xlDataField;
            gefactureerdPivotField1.Function = XlConsolidationFunction.xlSum;
            gefactureerdPivotField1.NumberFormat = "#,##0.00";
            gefactureerdPivotField2.Orientation = XlPivotFieldOrientation.xlDataField;
            gefactureerdPivotField2.Function = XlConsolidationFunction.xlSum;
            gefactureerdPivotField2.Calculation = XlPivotFieldCalculation.xlPercentOfColumn;
            gefactureerdPivotField2.NumberFormat = "#,##0.0%";
            netPivotField1.Orientation = XlPivotFieldOrientation.xlDataField;
            netPivotField1.Function = XlConsolidationFunction.xlSum;
            netPivotField1.NumberFormat = "#,##0.00";
            netPivotField2.Orientation = XlPivotFieldOrientation.xlDataField;
            netPivotField2.Function = XlConsolidationFunction.xlSum;
            netPivotField2.Calculation = XlPivotFieldCalculation.xlPercentOfColumn;
            netPivotField2.NumberFormat = "#,##0.0%";
            gefactureerdPivotField1.Caption = "Gefactureerd [EUR]";
            gefactureerdPivotField2.Caption = "Gefactureerd (%)";
            netPivotField1.Caption = "Netto [EUR]";
            netPivotField2.Caption = "Netto (%)";
            destinationSheet.Select();
            _Ws = destinationSheet;
            Select("A3:E9");
            _Xl.Selection.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            Select("A3:E3");
            _Xl.Selection.Interior.ThemeColor = XlThemeColor.xlThemeColorAccent1;
            _Xl.Selection.Interior.TintAndShade = 0.8;
            Select("A9:E9");
            _Xl.Selection.Interior.ThemeColor = XlThemeColor.xlThemeColorAccent1;
            _Xl.Selection.Interior.TintAndShade = 0.8;



        }
    }

}

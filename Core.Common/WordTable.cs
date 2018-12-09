using System;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;

namespace Core.Common
{
    public class WordTable
    {
        WordWrapper w;
        Word.Paragraph p;
        Word.Table t;
        int columnCount;
        int nrRow = 1;
        public WordTable(WordWrapper w, String[] titles)
        {
            columnCount = titles.Count();
            this.w = w;
            p = w.Doc.Paragraphs.Last;
            t = p.Range.Tables.Add(w.Sel.Range, 1, columnCount);
            t.set_Style("Grid Table 4 - Accent 3");
            t.Range.Font.Size = w.Sel.Range.Font.Size - 2;
            for (int nrColumn = 0; nrColumn < columnCount; nrColumn++)
            {
                w.SetCell(titles[nrColumn], t, 1, nrColumn + 1, WordWrapper.EAlign.center);
            }
        }
        public void AddRow(params object[] values)
        {
            t.Rows.Add();
            nrRow++;
            int nrCol = 0;
            foreach (var item in values)
            {
                nrCol++;
                if (item is decimal) { w.SetCell((decimal)item, t, nrRow, nrCol); }
                else { w.SetCell((string)item, t, nrRow, nrCol); }
            }
        }
        public void TableClose(Boolean hasTotalRow = false)
        {
            t.ApplyStyleHeadingRows = true;
            t.ApplyStyleLastRow = hasTotalRow;
            t.ApplyStyleRowBands = false;
            t.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
            w.Doc.Paragraphs.Last.Range.Select();
        }
    }
}
//static void ProcessRoughLocations(WordWrapper w)
//{
//    Word.Paragraph p = w.Doc.Paragraphs.Last;
//    Word.Table t = p.Range.Tables.Add(w.Sel.Range, 1, 3);
//    t.set_Style("Grid Table 4 - Accent 3");
//    t.Range.Font.Size = w.Sel.Range.Font.Size - 2;
//    w.SetCell("Location", t, 1, 1, WordWrapper.EAlign.center);
//    w.SetCell("Weight", t, 1, 2, WordWrapper.EAlign.center);
//    w.SetCell("Value", t, 1, 3, WordWrapper.EAlign.center);
//    int nrRow = 1;
//    foreach (var item in RSRough.Locations)
//    {
//        t.Rows.Add();
//        nrRow++;
//        w.SetCell(item.Location, t, nrRow, 1);
//        w.SetCell(item.Weight, t, nrRow, 2);
//        w.SetCell(item.Value, t, nrRow, 3);
//    }
//    t.ApplyStyleHeadingRows = true;
//    t.ApplyStyleLastRow = false;
//    t.ApplyStyleRowBands = false;
//    t.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
//    w.Doc.Paragraphs.Last.Range.Select();
//}

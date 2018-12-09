using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;


namespace Core.Common
{
    public class WordWrapper : IDisposable
    {
        public Word.Application App;
        public Word.Documents Docs;
        public Word.Document Doc;
        public Word.Selection Sel;
        public bool MustQuit = true;
        public bool Zerohide = true;
        #region Dispose
        Thread thread;
        bool disposed = false;
        public WordWrapper()
        {
            thread = Thread.CurrentThread;
            App = new Word.Application();
            App.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;
            Docs = App.Documents;
        }
        void releaseObject(object o)
        {
            if (o == null)
            {
                return;
            }
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o);
        }
        public void Dispose()
        {
            if (disposed)
            {
                return;
            }
            // try { wb.Close(); } finally { }
            if (MustQuit)
            {
                App.Quit();
            }
            releaseObject(Doc);
            releaseObject(Docs);
            disposed = true;
        }
        ~WordWrapper()
        {
            Dispose();
        }
        #endregion
        public enum EAlign { left,center,right}
        public void SetNarrowMargins()
        {
            Doc.PageSetup.TopMargin = App.InchesToPoints(0.42f);
            Doc.PageSetup.BottomMargin = 10;
            Doc.PageSetup.LeftMargin = 30;
            Doc.PageSetup.RightMargin = 15;
            Doc.PageSetup.HeaderDistance = App.InchesToPoints(0.21f); 
            Doc.PageSetup.FooterDistance = App.InchesToPoints(0.2f);
            Sel.Font.Size = 8;
        }
        public void SetTitle(string s)
        {
            Sel.TypeText(s);
            var p = Sel.Paragraphs.Last;
            p.set_Style(Word.WdBuiltinStyle.wdStyleHeading1);
            Sel.TypeParagraph();          
        }
        public void SetHeading2(string s)
        {
            Sel.TypeText(s);
            var p = Sel.Paragraphs.Last;
            p.set_Style(Word.WdBuiltinStyle.wdStyleHeading2);
            Sel.TypeParagraph();
        }
        public void SetBoddy(string s)
        {
            Sel.TypeText(s);
            var p = Sel.Paragraphs.Last;
            p.set_Style(Doc.Styles["No Spacing"]);
            Sel.TypeParagraph();
        }
        public void SetBoddyRedBold(string s)
        {
            Sel.TypeText(s);
            var p = Sel.Paragraphs.Last;
            p.set_Style(Doc.Styles["No Spacing"]);           
            p.Range.Font.Color = Word.WdColor.wdColorDarkRed;
            p.Range.Font.Bold = (int) Word.WdConstants.wdToggle;
            Sel.TypeParagraph();
        }
        public void SetBoddySmall(string s)
        {
            Sel.TypeText(s);
            var p = Sel.Paragraphs.Last;
            p.set_Style(Doc.Styles["No Spacing"]);
            p.Range.Font.Size = p.Range.Font.Size - 2;
            Sel.TypeParagraph();
        }
        public void SetCell(String s, Word.Table t, int nrRow, int nrColumn, EAlign align = EAlign.left)
        {
            var c = t.Cell(nrRow, nrColumn);
            c.Range.Text = s;
            switch (align)
            {
                case EAlign.left:
                    c.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    break;
                case EAlign.center:
                    c.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    break;
                case EAlign.right:
                    c.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    break;
            }
        }
        public void SetCell(Decimal n, Word.Table t, int nrRow, int nrColumn, bool isNegativeRed = true)
        {
            if (n == 0) { if (Zerohide == true) { return; } }
            SetCell(n.ToString("N2"), t, nrRow, nrColumn, EAlign.right);
            var c = t.Cell(nrRow, nrColumn);
            if (isNegativeRed == true)
            {
                if (n < 0)
                {
                    c.Range.Font.Color = Word.WdColor.wdColorRed;
                }
            }
        }
        public void SetFooter(string s)
        {
            App.Visible = true;
            var sections = Doc.Sections;
            var footer = sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
            footer.Range.Select();
            footer.Range.Font.Size = footer.Range.Font.Size - 2;
            Object oMissing = System.Reflection.Missing.Value;
            Object TotalPages = Word.WdFieldType.wdFieldNumPages;
            Object CurrentPage = Word.WdFieldType.wdFieldPage;
            // TODO: - Word Blues - Footer - Curious sequence of insertion
            Word.Paragraph p = footer.Range.Paragraphs.Last;
            p.Range.Borders[Word.WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            p = footer.Range.Paragraphs.Add(p.Range);
            p.Range.Fields.Add(p.Range, TotalPages, oMissing, oMissing);
            p = footer.Range.Paragraphs.Add(p.Range);
            p.Range.Text = "/";
            p = footer.Range.Paragraphs.Add(p.Range);
            p.Range.Fields.Add(p.Range, CurrentPage, oMissing, oMissing);
            p = footer.Range.Paragraphs.Add(p.Range);
            p.Range.Text = ($"{s}\nPage ");
        }
    }
}

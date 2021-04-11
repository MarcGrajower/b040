using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B040.ExcelAddin
{
    public partial class RibbonB040
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void MaandelijkseFacturatieStatitiekButton_Click(object sender, RibbonControlEventArgs e)
        {
            var o = new MaandelijkseFacturatieStatistiekenRibbon();
            o.Go();
        }

        private void TestButton_Click(object sender, RibbonControlEventArgs e)
        {
            var o = new TestRibbon();
            o.Go();

        }
    }
}

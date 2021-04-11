using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B040.ExcelAddin
{
    public class TestRibbon:RibbonBase
    {
        public void Go()
        {
            _Xl.Workbooks.Open(@"c:\docs\test.xlsx");
            // AddPivotTable();
 
        }
    }
}

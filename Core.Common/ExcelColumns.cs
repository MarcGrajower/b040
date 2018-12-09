using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class ExcelColumnModel
    {
        public string title;
        public ExcelWrapper.Formats format;
        public int index;
        public string letter;
    }
    public class ExcelColumns
    {
        public Dictionary<string, ExcelColumnModel> _excelColumns = new Dictionary<string, ExcelColumnModel>();
        int _counter = 1;
        public void add(string title, ExcelWrapper.Formats format)
        {
            ExcelColumnModel column = new ExcelColumnModel();
            column.title = title;
            column.format = format;
            column.index = _counter;
            _excelColumns.Add(title,column);
            _counter++;
        }
    }
}

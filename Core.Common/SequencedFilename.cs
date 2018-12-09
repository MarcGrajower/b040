using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public static class SequencedFilename
    {
        static string getFilename(string root,string extension,int sequence)
        {
            return String.Format("{0}_{1}_{2}.{3}",
                            root,
                            DateTime.Today.ToString("yyMMdd"),
                           ("000" + sequence).right(3),
                           extension);
        }

        public static string get(string root, string extension)
        {
            root.Replace(".", "");
            int sequence = 1;
            string filename = getFilename(root,extension,sequence);
            while ((System.IO.File.Exists(getFilename(root,extension,sequence))) == true) { sequence++; }
            return getFilename(root, extension, sequence);
        }
    }
}

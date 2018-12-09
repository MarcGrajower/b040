using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Core.Common
{
    public class BackupWithVersioning
    {
        static string yymmdd() { return (DateTime.Now).ToString("yyMMdd"); }
        public static void backup(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);
            string dirBackup = dir + @"\backup\";
            if (Directory.Exists(dirBackup)==false)
            {
                Directory.CreateDirectory(dirBackup);
            }
            int seq = 1;
            while (File.Exists(dirBackup + filenameWithoutExtension + "_" + yymmdd() + "_" + ("000" + seq).right(3) + extension)) { seq++; };
            string target = dirBackup + filenameWithoutExtension + "_" + yymmdd() + "_" + ("000" + seq).right(3) + extension;
            File.Copy(path,target);
        }

    }
}

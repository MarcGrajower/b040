using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemiro.OAuth;
using System.Windows.Forms;
using System.IO;

namespace Core.Common
{
    public static class Dropbox
    {
        public static OperationResult or = new OperationResult();

         public static void uploadFile(string fullpath,string dropboxtoken,string targetfolder)
        {
            or.Success = true;
            or.MessageList.Clear();
            var file = new FileStream(fullpath,FileMode.OpenOrCreate);
            string filename = Path.GetFileName(fullpath);
            RequestResult requestresult;
            try
            {
                requestresult =  OAuthUtility.Put
                (
                    "https://content.dropboxapi.com/1/files_put/auto/",
                    new HttpParameterCollection
                    {
                        {"access_token",dropboxtoken},
                        {"path",System.IO.Path.Combine(targetfolder,filename).Replace("\\","/") },
                        {"overwrite","true" },
                        {"autorename","true"},
                        {file}
                    }
                );
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.AddMessage(ex.Message);
                return;
                throw;
            }
            var dict = requestresult.ToDictionary();
            or.AddMessage("{0},{1} bytes", dict["path"].ToString(), dict["bytes"].ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
// using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System.Data;
namespace B040
{ 
    public class Json
    {
        // public static Boolean isOK = true;
        public static void deserialize<T>(string filename,out T obj,out Boolean isOK, out string errorMessage)
        {
            isOK = true;
            errorMessage = "";
            obj = default(T);
            if (!System.IO.File.Exists(filename))
            {
                errorMessage = filename + " not found.";
                isOK = false;
                return;
            }
            string json = File.ReadAllText(filename);
            obj = (T)JsonConvert.DeserializeObject<T>(json);
        }
        public static void deserialize<T>(string filename, out T obj)
        {
            bool isOK = false;
            string message = "";
            deserialize<T>(filename, out obj, out isOK, out message);
        }

        public static void serialize<T>(T obj,string filename)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(filename, json);
        }

    }
}

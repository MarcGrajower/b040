using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class OperationResult
    {
        public bool Success { get; set; }

        public List<string> MessageList { get; private set; }

        public OperationResult()
        {
            MessageList = new List<string>();
            Success = true;
        }

        public void AddMessage(string message)
        {
            MessageList.Add(message);
        }
        public void AddMessage(string fmt, params object[] arg)
        {
            MessageList.Add(string.Format(fmt, arg));
        }
        public string dump()
        {
            var sb = new StringBuilder();
            foreach(var m in MessageList)
            {
                sb.AppendLine(m);
            }
            var s = sb.ToString();
            sb.Clear();
            return s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public static class  StringExtensions
    {
        public static string right(this string value, int length)
        {
            if (String.IsNullOrEmpty(value)) return string.Empty;
            return value.Length <= length ? value : value.Substring(value.Length - length);
        }
        public static string left(this string value, int length)
        {
            if (String.IsNullOrEmpty(value)) return string.Empty;
            return value.Length <= length ? value : value.Substring(0,length);
        }
    }
}

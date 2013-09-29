using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperFunctions
{
    public static class StringExtentions
    {
        public static bool IsNullOrWhiteSpace(this string sourse)
        {
            return string.IsNullOrWhiteSpace(sourse);
        }

        public static bool IsNullOrEmpty(this string sourse)
        {
            return string.IsNullOrEmpty(sourse);
        }

        public static string AppendString(this string sourse, string append)
        {
            return string.Format("{0}{1}", sourse, append);
        }

        public static string ToLowerSafely(this string sourse)
        {
            return sourse ?? "";
        }

    }
}

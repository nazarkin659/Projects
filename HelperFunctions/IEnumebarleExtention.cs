using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperFunctions
{
    public static class IEnumebarleExtention
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> sourse)
        {
            return (sourse == null & sourse.Count() == 0);
        }
    }
}
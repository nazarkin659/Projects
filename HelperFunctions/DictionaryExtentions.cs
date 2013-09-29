using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperFunctions
{
    public static class DictionaryExtentions
    {
        public static Dictionary<T, V> AddSafely<T, V>(this Dictionary<T, V> sourse, T key, V value)
        {
            if (sourse.IsNullOrEmpty())
                return null;

            if (!sourse.ContainsKey(key))
                sourse.Add(key, value);

            return sourse;
        }

    }
}

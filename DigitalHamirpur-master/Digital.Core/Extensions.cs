using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Core
{
    public static class Extensions
    {

        public static void AddOrReplace(this IDictionary<string, object> DICT, string key, object value)
        {
            if (DICT.ContainsKey(key))
                DICT[key] = value;
            else
                DICT.Add(key, value);
        }
        public static bool IsNotNullAndNotEmpty<T>(this ICollection<T> source)
        {
            return source != null && source.Count() > 0;
        }

        public static bool IsNotNullAndNotEmpty<T>(this IEnumerable<T> source)
        {
            return source != null && source.Count() > 0;
        }
    }
}

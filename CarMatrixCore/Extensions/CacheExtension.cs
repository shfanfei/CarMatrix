using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMatrixCore.Extensions
{
    public static class CacheExtension
    {
        public static T Get<T>(this ConcurrentDictionary<string, T> dictionary, string key, Func<T> func) where T : class
        {

            if (dictionary.ContainsKey(key))
                return dictionary[key];
            else
            {
                var result = func();
                dictionary.GetOrAdd(key, result);
                return result;
            }
        }
    }
}

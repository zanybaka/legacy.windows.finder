using System;
using System.Collections;
using System.Collections.Generic;

namespace Samples.Finder.Components.Common.CommonLibrary.Extensions
{
    public static class FrameworkTypeExtensions
    {
        public static IList<KeyValuePair<TKey, string>> ToList<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            IList<KeyValuePair<TKey, string>> result = new List<KeyValuePair<TKey, string>>();
            foreach (var item in items)
            {
                result.Add(new KeyValuePair<TKey, string>(item.Key, item.Value.ToString()));
            }
            return result;
        }

        public static IEnumerable<T> SelectRecursively<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childsDelegate)
        {
            if (source != null)
            {
                foreach (var mainItem in source)
                {
                    yield return mainItem;
                    IEnumerable recursiveSequence = (childsDelegate(mainItem) ?? new T[] { }).SelectRecursively(childsDelegate);
                    if (recursiveSequence != null)
                    {
                        foreach (var recursiveItem in recursiveSequence)
                        {
                            yield return (T)recursiveItem;
                        }
                    }
                }
            }
        }

    }
}
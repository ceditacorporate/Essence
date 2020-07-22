// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cedita.Essence.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static List<int> IndexOfAll(this string sourceString, string subString)
        {
            if (string.IsNullOrEmpty(sourceString))
                return new List<int>();
            return Regex.Matches(sourceString, subString).Cast<Match>().Select(m => m.Index).ToList();
        }

        public static int IndexOfValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value)
        {
            int i = 0;
            foreach (var pair in dictionary)
            {
                if (pair.Value.Equals(value))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public static int FirstIndexMatch<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> matchCondition)
        {
            var index = 0;
            foreach (var item in items)
            {
                if (matchCondition.Invoke(item))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
                yield return item;
            }
        }
    }
}

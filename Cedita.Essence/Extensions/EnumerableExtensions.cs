// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cedita.Essence.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Return a batch of items of size <paramref name="size"/> from <paramref name="source"/>.
        /// </summary>
        /// <remarks>If trying to batch Queryable, use Paginate.</remarks>
        /// <typeparam name="TItem">Type of item.</typeparam>
        /// <param name="source">Source item set.</param>
        /// <param name="size">Maximum Size of batch to return.</param>
        /// <returns>Batched items from <paramref name="source"/>.</returns>
        public static IEnumerable<IEnumerable<TItem>> Batch<TItem>(this IEnumerable<TItem> source, int size)
        {
            TItem[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                {
                    bucket = new TItem[size];
                }

                bucket[count++] = item;

                if (count != size)
                {
                    continue;
                }

                yield return bucket.Select(x => x);

                bucket = null;
                count = 0;
            }

            // Return the last bucket with all remaining elements
            if (bucket != null && count > 0)
            {
                Array.Resize(ref bucket, count);
                yield return bucket.Select(x => x);
            }
        }
    }
}

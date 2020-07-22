// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Linq;

namespace Cedita.Essence.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Return a paginated batch of items of size <paramref name="size"/> from <paramref name="source"/>.
        /// </summary>
        /// <remarks>This works best on a connected IQueryable for query-translation. Use Batch instead on IEnumerable if not query.</remarks>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="queryable">Item source queryable.</param>
        /// <param name="page">Current Page number.</param>
        /// <param name="perPage">Amount of items per page.</param>
        /// <param name="total">Total amount of items in the Queryable.</param.>
        /// <returns>Paginated items from <paramref name="source"/>.</returns>
        public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> queryable, int page, int perPage, out int total)
        {
            var baseQ = queryable;
            total = baseQ.Count();

            if (page > 1)
            {
                baseQ = baseQ.Skip((page - 1) * perPage);
            }

            return baseQ.Take(perPage);
        }
    }
}

﻿namespace ContactsBook.API.application
{
    /// <summary>
    /// OrderedQueryableExtension class.
    /// </summary>
    public static class QueryableExtension
    {
        /// <summary>
        /// Pagination extension method.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="query">Query.</param>
        /// <param name="pageableQuery">Paging criteria.</param>
        /// <returns>Paginated query.</returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, IPageableQuery pageableQuery)
        {
            var result = query.Skip(pageableQuery.PageSize * (pageableQuery.PageIndex - 1)).Take(pageableQuery.PageSize);
            return result;
        }
    }
}

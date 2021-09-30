using Demiray.Core.Pagination.Enum;
using SmartSchoolBus.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demiray.Core.Pagination.Util
{
    public static class QueryableExtension
    {
        /// <summary>
        /// Converts a entity to paged list
        /// </summary>
        /// <typeparam name="T">Type of the entity</typeparam>
        /// <param name="Query">Entity that has the extension method</param>
        /// <param name="pageable">Pageable instance</param>
        /// <param name="TotalCount">Total count of the result list</param>
        /// <returns>Pagitated list of the result set</returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> Query, Pageable pageable, int TotalCount)
        {
            return new PagedList<T>(Query, pageable, TotalCount);
        }

        /// <summary>
        /// This function orders by given direction
        /// </summary>
        /// <typeparam name="T">Type of the entity</typeparam>
        /// <typeparam name="TKey">Type of the property that is going to be ordered by that</typeparam>
        /// <param name="Query">Entity that has the extension method</param>
        /// <param name="OrderBy">OrderBy consumer function</param>
        /// <param name="Order">Direction of the sort order</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderByDirection<T,TKey>(this IQueryable<T> Query, Expression<Func<T, TKey>> OrderBy, EOrder Order)
        {
            if (Order.Equals(EOrder.ASC))
            {
                return Query.OrderBy(OrderBy);
            }
            else
            {
                return Query.OrderByDescending(OrderBy);
            }
        }
    }
}

using Demiray.Core.Pagination.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartSchoolBus.Helper.Pagination
{
    public interface IPageableRepository<T> 
    {
        /// <summary>
        /// This function simply pagitates entity without any restrictions
        /// </summary>
        /// <param name="pageable">Pageable instance coming from client</param>
        /// <returns>Collection of query result</returns>
        ICollection<T> Pagitate(Pageable pageable);

        /// <summary>
        /// This function applies Where function on the entity with the param where
        /// and pagitates it
        /// </summary>
        /// <param name="pageable">Pageable instance coming from client</param>
        /// <param name="where">Where consumer function of the entity</param>
        /// <returns>Collection of query result</returns>
        ICollection<T> Pagitate(Pageable pageable, Expression<Func<T, bool>> where);

        /// <summary>
        /// If this interface does not provide complex LINQ, you can use this function to 
        /// pagitate your restricted query
        /// </summary>
        /// <param name="pageable">Pageable instance coming from client</param>
        /// <param name="query">Query of the entity</param>
        /// <returns>Collection of query result</returns>
        ICollection<T> Pagitate(Pageable pageable, IQueryable<T> query);

        /// <summary>
        /// This function applies Where and OrderBy functions to the entity
        /// </summary>
        /// <typeparam name="TKey">Property of the entity that is going to be sorted by that</typeparam>
        /// <param name="pageable">Pageable instance coming from client</param>
        /// <param name="where">Where consumer function of the entity</param>
        /// <param name="orderby">OrderBy consumer function of the entity</param>
        /// <param name="order">Order of the OrderBy function</param>
        /// <returns>Collection of query result</returns>
        ICollection<T> Pagitate<TKey>(Pageable pageable, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, EOrder order);

        /// <summary>
        /// This function applies OrderBy functions to the entity
        /// </summary>
        /// <typeparam name="TKey">Property of the entity that is going to be sorted by that</typeparam>
        /// <param name="pageable">Pageable instance coming from client</param>
        /// <param name="orderby">OrderBy consumer function of the entity</param>
        /// <param name="order">Order of the OrderBy function</param>
        /// <returns>Collection of query result</returns>
        ICollection<T> Pagitate<TKey>(Pageable pageable, Expression<Func<T, TKey>> orderby, EOrder order);
    }

}

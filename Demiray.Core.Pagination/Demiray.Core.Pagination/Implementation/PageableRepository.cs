using Demiray.Core.Pagination.Enum;
using Demiray.Core.Pagination.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartSchoolBus.Helper.Pagination
{
    public class PageableRepository<T> : IPageableRepository<T> where T : class
    {
        public IQueryable<T> Entity { get; private set; }

        public PageableRepository(IQueryable<T> Entity)
        {
            this.Entity = Entity;
        }
        public ICollection<T> Pagitate(Pageable pageable)
        {
            if (!CheckPagilability(pageable))
            {
                return Entity.ToList();
            }

            var totalCount = Entity.Count();

            return Pagitate(Entity, pageable, totalCount);
        }
        public ICollection<T> Pagitate(Pageable pageable, IQueryable<T> query)
        {
            if (!CheckPagilability(pageable))
            {
                return query.ToList();
            }

            var totalCount = query.Count();

            return Pagitate(query, pageable, totalCount);
        }
        public ICollection<T> Pagitate(Pageable pageable, Expression<Func<T, bool>> where)
        {
            var restrictions = Entity.
                Where(where);

            if (!CheckPagilability(pageable))
            {
                return restrictions.ToList();
            }

            var totalCount = restrictions.Count();

            return Pagitate(restrictions, pageable, totalCount);
        }
        public ICollection<T> Pagitate<TKey>(Pageable pageable, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, EOrder order)
        {
            var restrictions = Entity.
                Where(where).
                OrderByDirection(orderby,order);

            if (!CheckPagilability(pageable))
            {
                return restrictions.ToList();
            }

            var totalCount = restrictions.Count();

            return Pagitate(restrictions, pageable, totalCount);
        }
        public ICollection<T> Pagitate<TKey>(Pageable pageable, Expression<Func<T, TKey>> orderby, EOrder order)
        {
            var restrictions = Entity.
                OrderByDirection(orderby,order);

            if (!CheckPagilability(pageable))
            {
                return restrictions.ToList();
            }

            var totalCount = restrictions.Count();

            return Pagitate(restrictions, pageable, totalCount);
        }

        private PagedList<T> Pagitate(IQueryable<T> Query, Pageable pageable, int TotalCount)
        {
            return Query.
                Skip((int)(pageable.PageNumber * pageable.PageSize)).
                Take((int)pageable.PageSize).
                ToPagedList(pageable, TotalCount);
        }

        private bool CheckPagilability(Pageable pageable)
        {
            return pageable != null && pageable.PageNumber != null && pageable.PageSize != null && pageable.PageNumber>=0 && pageable.PageSize>=1;
        }
    }
}

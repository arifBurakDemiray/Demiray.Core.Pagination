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

        public ICollection<T> Pagitate(Pageable? pageable)
        {
            if (!CheckPagilability(pageable))
            {
                return Entity.ToList();
            }

            var totalCount = Entity.Count();

            return Pagitate(Entity, pageable, totalCount);
        }

        public ICollection<T> Pagitate(IQueryable<T> Query, Pageable? pageable)
        {
            if (!CheckPagilability(pageable))
            {
                return Query.ToList();
            }

            var totalCount = Query.Count();

            return Pagitate(Query, pageable, totalCount);
        }

        public ICollection<T> Pagitate(Expression<Func<T, bool>> where, Pageable? pageable)
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

        public ICollection<T> Pagitate<TKey>(Expression<Func<T, bool>> where, Pageable? pageable, Expression<Func<T, TKey>> orderby)
        {
            var restrictions = Entity.
                Where(where).
                OrderBy(orderby);

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
                Skip((int)((pageable.PageNumber - 1) * pageable.PageSize)).
                Take((int)pageable.PageSize).
                ToPagedList(pageable, TotalCount);
        }

        private bool CheckPagilability(Pageable? pageable)
        {
            return pageable == null ? false : pageable.PageNumber != null && pageable.PageSize != null && pageable.PageNumber>=1;
        }
    }
}

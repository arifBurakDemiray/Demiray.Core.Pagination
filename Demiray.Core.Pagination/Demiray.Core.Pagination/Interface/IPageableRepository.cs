using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartSchoolBus.Helper.Pagination
{
    public interface IPageableRepository<T> 
    {
        public ICollection<T> Pagitate(Pageable? pageable);

        public ICollection<T> Pagitate(Expression<Func<T, bool>> where, Pageable? pageable);

        public ICollection<T> Pagitate(IQueryable<T> Query, Pageable? pageable);

        public ICollection<T> Pagitate<TKey>(Expression<Func<T, bool>> where, Pageable? pageable, Expression<Func<T, TKey>> orderby);
    }

}

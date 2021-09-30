using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchoolBus.Helper.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(IQueryable<T> Query, Pageable pageable, int totalCount)
        {
            AddRange(Query.ToList());
            TotalCount = totalCount;
            PageSize = (int)pageable.PageSize;
            CurrentPage = (int)pageable.PageNumber;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        }
       
    }
}

namespace SmartSchoolBus.Helper.Pagination
{
    public class Pageable
    {
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        /// <summary>
        /// This function creates a pageable instance by given pageNumber and pageSize
        /// - If you provide only page size it takes default 0 for the page number
        /// - If you provide only page number it takes default 10 for the page size
        /// - If you do not provide any input it takes defaults of above
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Pageable Of(int? pageNumber = 0, int? pageSize = 10)
        {
            return new Pageable()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}

namespace SwaggerAnnotationsExample.QueryCriteria
{
    public abstract class AbstractQueryCriteria : IQueryCriteria
    {
        /// <summary>
        /// This size of page. This is a property from an abstract class that was inherited by the SearchQueryCriteria.
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// This index to start with. This is also property from the abstract class that was inherited by the SearchQueryCriteria.
        /// </summary>
        public int PageIndex { get; set; }
    }
}

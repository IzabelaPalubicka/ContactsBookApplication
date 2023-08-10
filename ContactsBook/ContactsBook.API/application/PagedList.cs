namespace ContactsBook.API.application
{
    /// <summary>
    /// Class of collection response.
    /// </summary>
    public class PagedList<T>
    {
        /// <summary>
        /// List of items.
        /// </summary>
        public List<T> Items { get; set; } = null!;

        /// <summary> 
        /// Total count of items.
        /// </summary>
        public int TotalCount { get; set; }
    }
}

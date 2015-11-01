namespace DribbbleForWindowsPhone.Model
{
    /// <summary>
    /// Represents the answer of a API request to Dribbble.
    /// </summary>
    class DribbblePagination
    {
        #region Properties

        /// <summary>
        /// Represents the current page on pagination.
        /// </summary>
        public uint Page { get; set; }

        /// <summary>
        /// Represents the amount of a thing to be shown.
        /// </summary>
        public uint PerPage { get; set; }
        
        /// <summary>
        /// Represents the total of pages.
        /// </summary>
        public uint Pages { get; set; }

        /// <summary>
        /// Represents the total of the thing to be paginated.
        /// </summary>
        public uint Total { get; set; }

        #endregion Properties
    }
}

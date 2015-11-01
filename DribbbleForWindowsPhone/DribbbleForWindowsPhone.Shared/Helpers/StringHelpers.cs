namespace DribbbleForWindowsPhone.Helpers
{
    /// <summary>
    /// A class with a serie of helpers method to handle strings.
    /// </summary>
    static class StringHelpers
    {
        #region Methods

        #region Public

        /// <summary>
        /// Upper case the first letter of a string.
        /// </summary>
        /// <param name="input">The string to be changed.</param>
        /// <returns>A upper cased first letter string.</returns>
        public static string UpperFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            char[] c = input.ToCharArray();
            c[0] = char.ToUpper(c[0]);

            return new string(c);
        }

        #endregion Public

        #endregion Methods
    }
}

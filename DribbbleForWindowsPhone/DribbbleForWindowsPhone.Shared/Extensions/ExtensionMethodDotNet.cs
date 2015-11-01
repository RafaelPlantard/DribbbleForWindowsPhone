using System;

namespace DribbbleForWindowsPhone.Extensions
{
    /// <summary>
    /// Extensions methods by the website: http://www.extensionmethod.net.
    /// </summary>
    public static class ExtensionMethodDotNet
    {
        #region Methods

        #region Public

        /// <summary>
        /// Checks wether a specific value is between a <paramref name="from"/> and <paramref name="to"/> values.
        /// </summary>
        /// <typeparam name="T">Type of the value to compare.</typeparam>
        /// <param name="value">Value to be compared.</param>
        /// <param name="from">From value.</param>
        /// <param name="to">To value.</param>
        /// <returns></returns>
        public static bool Between<T>(this T value, T from, T to) where T : IComparable<T>
        {
            return value.CompareTo(from) >= 0 && value.CompareTo(to) <= 0;
        }

        #endregion Public

        #endregion Methods
    }
}

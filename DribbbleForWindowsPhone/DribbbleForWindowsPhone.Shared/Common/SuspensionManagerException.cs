using System;

namespace DribbbleForWindowsPhone.Common
{
    /// <summary>
    /// A exception that can occurs when the SuspensionManager it's manipulated.
    /// </summary>
    public class SuspensionManagerException : Exception
    {
        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public SuspensionManagerException()
        { }

        /// <summary>
        /// Initializes the object with a specific exception.
        /// </summary>
        /// <param name="e">The exception.</param>
        public SuspensionManagerException(Exception e)
            : base("SuspensionManager failed", e)
        { }

        #endregion Constructors
    }
}

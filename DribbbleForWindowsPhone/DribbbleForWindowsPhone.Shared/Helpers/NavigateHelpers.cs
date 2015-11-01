using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DribbbleForWindowsPhone.Helpers
{
    /// <summary>
    /// A helper class to Navigate operations.
    /// </summary>
    public static class NavigateHelpers
    {
        #region Fields

        /// <summary>
        /// The Window.Current.Content object.
        /// </summary>
        private static Frame _frame;

        #endregion Fields

        #region Methods

        #region Public

        /// <summary>
        /// A method that access the core dispatcher of the application and go to a specific page with or not parameters.
        /// </summary>
        /// <param name="page">The target page.</param>
        /// <param name="parameter">Any parameter to the target page.</param>
        public static void GoToPage(Type page, object parameter)
        {
            GoToPage(_frame, page, parameter);
        }

        /// <summary>
        /// A method that from the current frame go to a specific page with or not parameters.
        /// </summary>
        /// <param name="frame">The current frame to be used to navigate.</param>
        /// <param name="page">The target page.</param>
        /// <param name="parameter">Any parameter to the target page.</param>
        public static void GoToPage(Frame frame, Type page, object parameter)
        {
            if (!frame.Navigate(page, parameter))
            {
                string format = "Failed to navigate to page: {0}";

                string message = string.Format(format, page.Name);

                throw new Exception(message);
            }
        }

        /// <summary>
        /// Initialize the Frame property to provide access to it.
        /// </summary>
        public static void Initialize()
        {
            _frame = Window.Current.Content as Frame;
        }

        #endregion Public

        #endregion Methodss
    }
}

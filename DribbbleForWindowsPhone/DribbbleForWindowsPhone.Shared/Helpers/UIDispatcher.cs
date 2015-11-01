using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace DribbbleForWindowsPhone.Helpers
{
    /// <summary>
    /// Provide methods to execute a Action in the CoreDispatcher of the application out of the Application class.
    /// </summary>
    public static class UIDispatcher
    {
        #region Fields

        /// <summary>
        /// The core dispatcher.
        /// </summary>
        private static CoreDispatcher _dispatcher;

        #endregion Fields

        #region Methods

        #region Private

        /// <summary>
        /// A helper method to execute a action like asynchronous method.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private static async Task InnerExecute(Action action)
        {
            if (_dispatcher.HasThreadAccess)
                action();
            else
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());

        }

        #endregion Private

        #region Public

        /// <summary>
        /// Initialize the Dispatcher field.
        /// </summary>
        public static void Initialize()
        {
            _dispatcher = Window.Current.Dispatcher;
        }

        /// <summary>
        /// Begin to execute an action in the current thread or in another.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public static void BeginExecute(Action action)
        {
            if (_dispatcher.HasThreadAccess)
                action();
            else
#pragma warning disable 4014
                // TODO: Try fix the warning CS4014 with Extensions Methods.
                _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
#pragma warning restore 4014
        }

        /// <summary>
        /// Execute an action on synchronous mode.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public static void Execute(Action action)
        {
            InnerExecute(action).Wait();
        }

        #endregion Public

        #endregion Methods
    }
}

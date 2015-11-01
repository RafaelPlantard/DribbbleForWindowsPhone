using System;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace DribbbleForWindowsPhone.Behaviors
{
    partial class StatusBarBehavior
    {
        #region Fields

        private static StatusBar _statusBar;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>Initializes the status bar from the current view.</remarks>
        public StatusBarBehavior()
        {
            _statusBar = StatusBar.GetForCurrentView();
        }

        #endregion Constructors

        #region Methods

        #region Partial

        static partial void OnBackgroundOpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            _statusBar.BackgroundOpacity = (double)e.NewValue;
        }

        static partial void OnBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StatusBarBehavior behavior = (StatusBarBehavior)d;

            _statusBar.BackgroundColor = behavior.BackgroundColor;

            // If they have no set the opacity, we need to set to the new color is shown.
            if (behavior.BackgroundOpacity <= 0)
                behavior.BackgroundOpacity = 1;
        }

        static partial void OnForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            _statusBar.ForegroundColor = (Color)e.NewValue;
        }

        static async partial void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool isVisible = (bool)e.NewValue;

            if (isVisible)
                await _statusBar.ShowAsync();
            else
                await _statusBar.HideAsync();
        }

        #endregion Partial

        #endregion Methods
    }
}

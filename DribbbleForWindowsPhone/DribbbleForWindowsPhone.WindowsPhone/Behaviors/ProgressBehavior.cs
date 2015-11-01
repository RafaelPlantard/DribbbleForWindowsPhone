using DribbbleForWindowsPhone.Helpers;
using System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace DribbbleForWindowsPhone.Behaviors
{
    /// <summary>
    /// A behavior to control the state of the progress bar indicator.
    /// </summary>
    public partial class ProgressBehavior
    {
        #region Fields

        private static StatusBarProgressIndicator _progressIndicator;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>Initializes the progress indicator from the current view.</remarks>
        public ProgressBehavior()
        {
            _progressIndicator = StatusBar.GetForCurrentView().ProgressIndicator;
        }

        #endregion Constructors

        #region Methods

        #region Partial

        static partial void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool isVisible = (bool)e.NewValue;
            
            if (isVisible)
            {
                AsyncHelpers.RunSync(async () => await _progressIndicator.ShowAsync());
            }
            else
            {
                AsyncHelpers.RunSync(async () => await _progressIndicator.HideAsync());
            }
        }
        
        static partial void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string text = null;

            if (e.NewValue != null)
            {
                text = e.NewValue.ToString();
            }

            _progressIndicator.Text = text;
        }

        static partial void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                double value = (double)e.NewValue;

                _progressIndicator.ProgressValue = value;
            }            
        }

        #endregion Partial

        #endregion Methods
    }
}
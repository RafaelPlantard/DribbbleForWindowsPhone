using Windows.UI;
using Windows.UI.Xaml;

namespace DribbbleForWindowsPhone.Behaviors
{
    /// <summary>
    /// A behavior that allows us to control the status bar in XAML.
    /// </summary>
    partial class StatusBarBehavior : Behavior<DependencyObject>
    {
        #region Fields

        /// <summary>
        /// Using a <see cref="DependencyProperty"/> as the backing store for <see cref="BackgroundOpacity"/>.
        /// </summary>
        /// <remarks>This enables animation, styling, binding, etc...</remarks>
        public static readonly DependencyProperty BackgroundOpacityProperty =
            DependencyProperty.Register("BackgroundOpacity", typeof(double), typeof(StatusBarBehavior), new PropertyMetadata(0d, OnBackgroundOpacityChanged));

        /// <summary>
        /// Using a <see cref="DependencyProperty"/> as the backing store for <see cref="BackgroundColor"/>.
        /// </summary>
        /// <remarks>This enables animation, styling, binding, etc...</remarks>
        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(StatusBarBehavior), new PropertyMetadata(null, OnBackgroundColorChanged));

        /// <summary>
        /// Using a <see cref="DependencyProperty"/> as the backing store for <see cref="ForegroundColor"/>.
        /// </summary>
        /// <remarks>This enables animation, styling, binding, etc...</remarks>
        public static readonly DependencyProperty ForegroundColorProperty =
            DependencyProperty.Register("ForegroundColor", typeof(Color), typeof(StatusBarBehavior), new PropertyMetadata(null, OnForegroundColorChanged));

        /// <summary>
        /// Using a <see cref="DependencyProperty"/> as the backing store for <see cref="IsVisible"/>.
        /// </summary>
        /// <remarks>  This enables animation, styling, binding, etc...</remarks>
        public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.Register("IsVisible", typeof(bool), typeof(StatusBarBehavior), new PropertyMetadata(true, OnIsVisibleChanged));

        #endregion Fields

        #region Properties

        /// <summary>
        /// The attached property to change the StatusBar's Background property.
        /// </summary>
        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        /// <summary>
        /// The attached property to change the opacity for StatusBar's Background property.
        /// </summary>
        public double BackgroundOpacity
        {
            get { return (double)GetValue(BackgroundOpacityProperty); }
            set { SetValue(BackgroundOpacityProperty, value); }
        }

        /// <summary>
        /// The attached property to change the StatusBar's Foreground property.
        /// </summary>
        public Color ForegroundColor
        {
            get { return (Color)GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        /// <summary>
        /// The attached property to change the StatusBar's IsVisible property.
        /// </summary>
        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        #endregion Properties

        #region Methods

        #region Partial

        /// <summary>
        /// The <see cref="PropertyChangedCallback"/> method to <see cref="BackgroundColor"/> property.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">the dependecy property changed event arguments.</param>
        static partial void OnBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e);

        /// <summary>
        /// The <see cref="PropertyChangedCallback"/> method to <see cref="BackgroundOpacity"/> property.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">the dependecy property changed event arguments.</param>
        static partial void OnBackgroundOpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e);

        /// <summary>
        /// The <see cref="PropertyChangedCallback"/> method to <see cref="ForegroundColor"/> property.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">the dependecy property changed event arguments.</param>
        static partial void OnForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e);

        /// <summary>
        /// The PropertyChangedCallback method to <see cref="IsVisible"/> property.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">the dependecy property changed event arguments.</param>
        static partial void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e);

        #endregion Partial

        #endregion Methods
    }
}
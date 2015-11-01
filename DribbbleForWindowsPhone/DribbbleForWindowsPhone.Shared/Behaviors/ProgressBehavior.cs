using Windows.UI.Xaml;

namespace DribbbleForWindowsPhone.Behaviors
{
    /// <summary>
    /// A behavior to control the state of the progress bar indicator.
    /// </summary>
    public partial class ProgressBehavior : Behavior<DependencyObject>
    {
        #region Fields

            #region Public

        /// <summary>
        /// The dependency property to the property IsVisible.
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible", typeof(bool), typeof(ProgressBehavior), new PropertyMetadata(false, OnIsVisibleChanged));

        /// <summary>
        /// The dependency property to the property Text.
        /// </summary>
        public static readonly DependencyProperty TextProperty = 
            DependencyProperty.Register("Text", typeof(string), typeof(ProgressBehavior), new PropertyMetadata(null, OnTextChanged));

        /// <summary>
        /// The dependency property to the property Value.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(ProgressBehavior), new PropertyMetadata(0, OnValueChanged));

        #endregion Public

        #endregion Fields

        #region Properties

        /// <summary>
        /// The ProgressIndicator is visible?
        /// </summary>
        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        /// <summary>
        /// The text of the ProgressIndicator.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// A value to the progress value.
        /// </summary>
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion Properties

        #region Methods

        #region Partial

        static partial void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e);
        
        static partial void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e);

        static partial void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e);

        #endregion Partial

        #endregion Methods
    }
}
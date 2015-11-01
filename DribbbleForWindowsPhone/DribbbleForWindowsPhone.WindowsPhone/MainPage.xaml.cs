using Windows.UI.Xaml.Navigation;

namespace DribbbleForWindowsPhone
{
    /// <summary>
    ///The MainPage's code-behind.
    /// </summary>
    public sealed partial class MainPage
    {

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        #endregion Constructors

        #region Methods

        #region Protected

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        { }

        #endregion Protected

        #endregion Methods
    }
}

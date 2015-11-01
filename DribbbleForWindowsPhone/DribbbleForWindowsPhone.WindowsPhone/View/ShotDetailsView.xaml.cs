using Windows.UI.Xaml.Navigation;
using DribbbleForWindowsPhone.Model;
using DribbbleForWindowsPhone.ViewModel;

namespace DribbbleForWindowsPhone.View
{
    /// <summary>
    /// The ShotDetailsView's code behind.
    /// </summary>
    public sealed partial class ShotDetailsView
    {
        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public ShotDetailsView()
        {
            InitializeComponent();
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
        {
            // TODO: Without code-behind responsability.
            ((ShotDetailsViewModel) DataContext).Shot = e.Parameter as Shot;
        }

        #endregion

        #endregion Methods

    }
}

using DribbbleForWindowsPhone.Model;
using GalaSoft.MvvmLight;

namespace DribbbleForWindowsPhone.ViewModel
{
    /// <summary>
    /// Represents the ShotDetailsView's ViewModel.
    /// </summary>
    class ShotDetailsViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// The shot to show.
        /// </summary>
        private Shot _shot;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The choosen shot.
        /// </summary>
        public Shot Shot
        {
            get { return _shot; }
            set { Set(() => Shot, ref _shot, value); }
        }

        #endregion Properties
    }
}

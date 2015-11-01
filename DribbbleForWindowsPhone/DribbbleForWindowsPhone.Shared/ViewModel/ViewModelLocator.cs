using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace DribbbleForWindowsPhone.ViewModel
{
    /// <summary>
    /// The Locator of ViewModels and Setter of IoC.
    /// </summary>
    class ViewModelLocator
    {
        #region Properties

        /// <summary>
        /// Represents a AccelerometerHelpersViewModel object.
        /// </summary>
        public AccelerometerHelpersViewModel AccelerometerHelpers
        {
            get { return ServiceLocator.Current.GetInstance<AccelerometerHelpersViewModel>(); }
        }

        /// <summary>
        /// Represents a MainViewModel object.
        /// </summary>
        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        /// <summary>
        /// Represents a ShotDetailsViewModel object.
        /// </summary>
        public ShotDetailsViewModel ShotDetails
        {
            get { return ServiceLocator.Current.GetInstance<ShotDetailsViewModel>(); }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterViewModels();
        }

        #endregion Constructors

        #region Methods

        #region Private

        /// <summary>
        /// A list of calls to Register method from <see cref="SimpleIoc.Default"/> to set up all view models.
        /// </summary>
        private void RegisterViewModels()
        {
            SimpleIoc.Default.Register<AccelerometerHelpersViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ShotDetailsViewModel>();
        }

        #endregion Private

        #endregion Methods
    }
}

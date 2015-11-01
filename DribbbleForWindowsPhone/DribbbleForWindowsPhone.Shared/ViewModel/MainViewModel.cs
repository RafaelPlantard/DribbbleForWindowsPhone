using DribbbleForWindowsPhone.Helpers;
using DribbbleForWindowsPhone.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DribbbleForWindowsPhone.ViewModel
{
    /// <summary>
    /// Represents the MainPage's ViewModel.
    /// </summary>
    internal class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The maximum number of elements of pages in the paginator list.
        /// </summary>
        private const byte MaximumPagesInPaginator = 9;

        /// <summary>
        /// The data to show on list of results from the Dribbble API.
        /// </summary>
        private DribbbleCenter _data;

        /// <summary>
        /// The wrapper for possible error messages.
        /// </summary>
        private string _errorMessages;

        /// <summary>
        /// The list to show the pagination.
        /// </summary>
        private IList<string> _pagination;

        /// <summary>
        /// The response from the Dribbble API.
        /// </summary>
        public DribbbleCenter Data
        {
            get { return _data; }
            set { Set(() => Data, ref _data, value); }
        }

        /// <summary>
        /// Messages throwed for exceptions.
        /// </summary>
        public string ErrorMessages
        {
            get { return _errorMessages; }
            set { Set(() => ErrorMessages, ref _errorMessages, value); }
        }

        /// <summary>
        /// Represents the command that load shots available on Dribbble API.
        /// </summary>
        public ICommand LoadInitialShotsCommand { get; private set; }

        /// <summary>
        /// Represents the command that load shots available on Dribbble API.
        /// </summary>
        public ICommand LoadShotsCommand { get; private set; }

        /// <summary>
        /// The list to show to the user the current pagination.
        /// </summary>
        public IList<string> Pagination
        {
            get { return _pagination; }
            set { Set(() => Pagination, ref _pagination, value); }
        }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public MainViewModel()
        {
            LoadInitialShotsCommand = new AsyncRelayCommand(async p => await LoadInitialShots());

            LoadShotsCommand = new AsyncRelayCommand(async p => await LoadShots(p));

            Data = DribbbleCenter.Dribbble;
        }

        /// <summary>
        /// Load the list that show the pagination.
        /// </summary>
        private IList<string> GeneratePagination()
        {
            // First added the first and last pages and its separators.

            // TODO: Improve it.

            IList<string> pagesPagination = new List<string>();

            pagesPagination.Add("1");

            double d = MaximumPagesInPaginator / 2;

            double limitMin = 1 + Math.Round(d);
            double limitMax = Data.Pages - limitMin;

            if (Data.Page <= limitMin)
            {
                int index = pagesPagination.Count;
                int i = index + 1;

                pagesPagination.Add("...");
                pagesPagination.Add(Data.Pages.ToString());

                while (pagesPagination.Count < MaximumPagesInPaginator)
                {
                    pagesPagination.Insert(index, i.ToString());
                    i++;
                    index++;
                }
            }
            else if (Data.Page >= limitMax)
            {
                pagesPagination.Add("...");

                int index = pagesPagination.Count;

                long i = Data.Pages - (MaximumPagesInPaginator - (index + 1));

                while (pagesPagination.Count < MaximumPagesInPaginator)
                {
                    pagesPagination.Insert(index, i.ToString());

                    i++;
                    index++;
                }
            }
            else
            {
                pagesPagination.Add("...");

                int index = pagesPagination.Count;

                pagesPagination.Add("...");

                pagesPagination.Add(Data.Pages.ToString());

                uint i = Data.Page;

                while (pagesPagination.Count < MaximumPagesInPaginator)
                {
                    pagesPagination.Insert(index, i.ToString());
                    i++;
                    index++;
                }
            }

            return pagesPagination;
        }

        /// <summary>
        /// Responsible for load the shots on first load of app.
        /// </summary>
        private async Task LoadInitialShots()
        {
            if (Data.Shots == null)
                await LoadShots();
        }

        /// <summary>
        /// Load shots from Dribbble API.
        /// </summary>
        /// <param name="page">The page to load the shots.</param>
        private async Task LoadShots(object page = null)
        {
            uint? pageToLoad = null;

            try
            {
                if (page != null)
                {
                    pageToLoad = Convert.ToUInt32(page);
                }
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                await DribbbleCenter.Dribbble.LoadShots(pageToLoad);

                Data = null; // I must to clear the list to update the bindings.

                Data = DribbbleCenter.Dribbble;

                Pagination = GeneratePagination();

                ErrorMessages = null;
            }
            catch (Exception e)
            {
                ErrorMessages = e.Message;
            }
        }
    }
}
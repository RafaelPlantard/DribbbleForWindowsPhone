using DribbbleForWindowsPhone.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DribbbleForWindowsPhone.Model
{
    /// <summary>
    /// The singleton responsible for provides the access to the Shots on Dribbble.
    /// </summary>
    internal class DribbbleCenter : DribbblePagination
    {
        /// <summary>
        /// The singleton to access the Dribbble response.
        /// </summary>
        private static DribbbleCenter _dribbble;

        /// <summary>
        /// Represents the Dribbble API's response.
        /// </summary>
        /// <remarks>Pattern singleton in action.</remarks>
        public static DribbbleCenter Dribbble
        {
            get { return _dribbble ?? (_dribbble = new DribbbleCenter()); }
            private set { _dribbble = value; }
        }

        /// <summary>
        /// The shots from a request to Dribble API.
        /// </summary>
        public IList<Shot> Shots { get; set; }

        /// <summary>
        /// Load the Shots directly from Dribbble.com.
        /// </summary>
        /// <param name="page">Page to go on pagination process.</param>
        /// <param name="perPage">How many shots per page?</param>
        /// <returns>A task to tell about the completeness status.</returns>
        public async Task LoadShots(uint? page = null, uint? perPage = null)
        {
            // Check whether there are arguments on method.
            Page = page ?? ++Page;
            PerPage = perPage ?? PerPage;

            if (Page > Pages)
                Page = 1;

            Uri uri = DribbbleApiHelpers.GetShotsUri(Page, PerPage);

            string dataJson = await DribbbleApiHelpers.GetJsonResponseFromDribbbleApi(uri);

            Shots = JsonConvert.DeserializeObject<IList<Shot>>(dataJson);

            Pages = 99; // Set a manual number of pages, because, this value is not more returned for the API.
        }
    }
}
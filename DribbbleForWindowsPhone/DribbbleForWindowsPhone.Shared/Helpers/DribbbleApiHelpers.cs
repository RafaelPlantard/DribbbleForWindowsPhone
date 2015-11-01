using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace DribbbleForWindowsPhone.Helpers
{
    /// <summary>
    /// Helper for Dribbble Api access.
    /// </summary>
    static class DribbbleApiHelpers
    {
        #region Fields

        /// <summary>
        /// The path for Dribbble api access.
        /// </summary>
        private const string DribbbleApiUri = "https://api.dribbble.com/v1/";

        /// <summary>
        /// The client access token for Dribbble api.
        /// </summary>
        private const string DribbbleAccessToken = "7e5aba3a3f67620071d8b5c4dbc79eacd776d8ccfa4c76c0762430d8f670fd06";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the <see cref="UriBuilder"/> for the shots on Dribbble.
        /// </summary>
        /// <remarks>Results are sorted by popularity.</remarks>
        public static UriBuilder Shots
        {
            get
            {
                string format = "{0}{1}/";
                string shots = string.Format(format, DribbbleApiUri, "shots");

                return new UriBuilder(shots);
            }
        }

        #endregion Properties

        #region Methods

        #region Public

        /// <summary>
        /// Fix the JSON response.
        /// </summary>
        /// <remarks>The property name will be first letter upper cased and the underline (_) removed.</remarks>
        /// <param name="input">Json Response.</param>
        /// <returns>A fixed json response.</returns>
        [Deprecated("Insted of this method, use the JsonProperty annotation from Json.Newtonsoft", DeprecationType.Deprecate, 0)]
        public static string FixFormatDribbleJson(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            string response = input;

            string pattern = "\"(\\w+)\":";

            RegexOptions options = RegexOptions.Multiline;

            MatchCollection matches = Regex.Matches(input, pattern, options);

            string patternToReplace;
            string propertyToFix;

            foreach (Match match in matches)
            {
                propertyToFix = match.Groups[1].ToString();

                string[] piecesProperty = Regex.Split(propertyToFix, "_");

                string newPropertyName = string.Empty;

                foreach (string s in piecesProperty)
                {
                    newPropertyName += StringHelpers.UpperFirstLetter(s);
                }

                patternToReplace = string.Format("\"{0}\":", propertyToFix);
                newPropertyName = string.Format("\"{0}\":", newPropertyName);

                response = Regex.Replace(response, patternToReplace, newPropertyName);

                // Stop the process of replacement because, all another values already has been replaced.
                if (propertyToFix == "created_at")
                {
                    break;
                }
            }

            return response;
        }

        /// <summary>
        /// Generates the Uri for request shots from Dribbble API.
        /// </summary>
        /// <param name="page">The current page on pagination parameters.</param>
        /// <param name="perPage">The amount of elements per page on pagination parameters.</param>
        /// <remarks>This method also injects the api key as a query on the uri.</remarks>
        /// <returns>The Uri for request shots.</returns>
        public static Uri GetShotsUri(uint page = 1, uint perPage = 5)
        {
            // Fix the perPage argument.
            perPage = (perPage == 0) ? 5 : perPage;

            UriBuilder uriBuilder = Shots;

            string queryFormat = "page={0}&per_page={1}&access_token={2}";

            uriBuilder.Query = string.Format(queryFormat, page, perPage, DribbbleAccessToken);

            return uriBuilder.Uri;
        }

        /// <summary>
        /// Get the json response from the Dribble API.
        /// </summary>
        /// <param name="uri">The uri to be requested.</param>
        /// <returns>The json string.</returns>
        /// <exception cref="Exception">No internet connection, shake the device to try again :)</exception>
        public async static Task<string> GetJsonResponseFromDribbbleApi(Uri uri)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                    );

                return await httpClient.GetStringAsync(uri);
            }
            catch (HttpRequestException e)
            {
                string message = "No internet connection, shake the device to try again!";
                throw new Exception(message, e);
            }
            
        }

        #endregion Public

        #endregion Methods
    }
}

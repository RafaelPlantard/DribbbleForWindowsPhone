using Newtonsoft.Json;
using System;

namespace DribbbleForWindowsPhone.Model
{
    /// <summary>
    /// The links that it can be used to contact the user.
    /// </summary>
    [JsonObject]
    public class UserLink
    {
        /// <summary>
        /// The twitter.
        /// </summary>
        /// <example>https://twitter.com/maxvoltar</example>
        [JsonProperty("twitter")]
        public Uri Twiiter { get; set; }

        /// <summary>
        /// The website.
        /// </summary>
        /// <example>http://maxvoltar.com/</example>
        [JsonProperty("web")]
        public Uri WebSite { get; set; }
    }
}
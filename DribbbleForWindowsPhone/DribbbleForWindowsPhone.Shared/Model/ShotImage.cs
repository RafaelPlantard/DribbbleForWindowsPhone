using Newtonsoft.Json;
using System;

namespace DribbbleForWindowsPhone.Model
{
    /// <summary>
    /// The images that a shot contains.
    /// </summary>
    [JsonObject]
    public class ShotImage
    {
        /// <summary>
        /// The image url.
        /// </summary>
        /// <example>https://d13yacurqjgara.cloudfront.net/users/22/screenshots/1757954/tvd.png</example>
        [JsonProperty("hidpi")]
        public Uri HiDPI { get; set; }

        /// <summary>
        /// The url for 400px quality image.
        /// </summary>
        /// <example>https://d13yacurqjgara.cloudfront.net/users/22/screenshots/1757954/tvd_1x.png</example>
        [JsonProperty("normal")]
        public Uri Normal { get; set; }

        /// <summary>
        /// The image teaser url.
        /// </summary>
        /// <example>https://d13yacurqjgara.cloudfront.net/users/22/screenshots/1757954/tvd_teaser.png</example>
        [JsonProperty("teaser")]
        public Uri Teaser { get; set; }
    }
}
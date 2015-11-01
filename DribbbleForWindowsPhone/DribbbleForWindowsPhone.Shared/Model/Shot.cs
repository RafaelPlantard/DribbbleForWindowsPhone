using System;

namespace DribbbleForWindowsPhone.Model
{
    /// <summary>
    /// Represents a shot on Dribbble.
    /// </summary>
    class Shot
    {
        #region Properties

        /// <summary>
        /// The unique identifier.
        /// </summary>
        /// <example>1757954</example>
        public uint Id { get; set; }

        /// <summary>
        /// The title.
        /// </summary>
        /// <example>End of an era</example>
        public string Title { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        /// <example><p>After 5 years, I decided to retire the old \"Contact Card\" website. My HTML and CSS is rusty, but I managed to hack this page together and make it semi-responsive. Even includes @3x assets for those on an iPhone 6 Plus!</p>\n\n<p>http://timvandamme.com</p></example>
        public string Description { get; set; }

        /// <summary>
        /// The height.
        /// </summary>
        /// <example>600</example>
        public uint Height { get; set; }

        /// <summary>
        /// The width.
        /// </summary>
        /// <example>800</example>
        public uint Width { get; set; }

        /// <summary>
        /// The amount of likes.
        /// </summary>
        /// <example>428</example>
        public uint LikesCount { get; set; }

        /// <summary>
        /// The amount of comments.
        /// </summary>
        /// <example>47</example>
        public uint CommentsCount { get; set; }

        /// <summary>
        /// The amount of rebounds.
        /// </summary>
        /// <example>0</example>
        public uint ReboundsCount { get; set; }

        /// <summary>
        /// The url.
        /// </summary>
        /// <example>http://dribbble.com/shots/1757954-End-of-an-era</example>
        public Uri Url { get; set; }

        /// <summary>
        /// The short url.
        /// </summary>
        /// <example>http://drbl.in/mAgQ</example>
        public Uri ShortUrl { get; set; }

        /// <summary>
        /// The amount of views.
        /// </summary>
        /// <example>14360</example>
        public uint ViewsCount { get; set; }

        /// <summary>
        /// The rebound source's unique identifier.
        /// </summary>
        public uint? ReboundSourceId { get; set; }

        /// <summary>
        /// The image url.
        /// </summary>
        /// <example>https://d13yacurqjgara.cloudfront.net/users/22/screenshots/1757954/tvd.png</example>
        public Uri ImageUrl { get; set; }

        /// <summary>
        /// The image teaser url.
        /// </summary>
        /// <example>https://d13yacurqjgara.cloudfront.net/users/22/screenshots/1757954/tvd_teaser.png</example>
        public Uri ImageTeaserUrl { get; set; }

        /// <summary>
        /// The url for 400px quality image.
        /// </summary>
        /// <example>https://d13yacurqjgara.cloudfront.net/users/22/screenshots/1757954/tvd_1x.png</example>
        public Uri Image400Url { get; set; }

        /// <summary>
        /// The <see cref="User"/> that created this <see cref="Shot"/>.
        /// </summary>
        public User Player { get; set; }

        /// <summary>
        /// The date and time that it was created.
        /// </summary>
        /// <example>2014/10/08 18:44:19 -0400</example>
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}

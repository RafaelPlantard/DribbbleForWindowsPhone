using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DribbbleForWindowsPhone.Model
{
    /// <summary>
    /// Represents a shot on Dribbble.
    /// </summary>
    [JsonObject]
    public class Shot
    {
        /// <summary>
        /// The amount of attachments.
        /// </summary>
        /// <example>0</example>
        [JsonProperty("attachments_count")]
        public uint AttachmentsCount { get; set; }

        /// <summary>
        /// The url for the attachments.
        /// </summary>
        /// <example>https://api.dribbble.com/v1/shots/1757954/attachments</example>
        [JsonProperty("attachments_url")]
        public Uri AttachmentsUrl { get; set; }

        /// <summary>
        /// The amount of bucckets.
        /// </summary>
        /// <example>12</example>
        [JsonProperty("buckets_count")]
        public uint BucketsCount { get; set; }

        /// <summary>
        /// The url for the buckets.
        /// </summary>
        /// <example>https://api.dribbble.com/v1/shots/1757954/buckets</example>
        [JsonProperty("buckets_url")]
        public Uri BucketsUrl { get; set; }

        /// <summary>
        /// The amount of comments.
        /// </summary>
        /// <example>46</example>
        [JsonProperty("comments_count")]
        public uint CommentsCount { get; set; }

        /// <summary>
        /// The url for the comments.
        /// </summary>
        /// <example>https://api.dribbble.com/v1/shots/1757954/comments</example>
        [JsonProperty("comments_url")]
        public Uri CommentsUrl { get; set; }

        /// <summary>
        /// The date and time that it was created.
        /// </summary>
        /// <example>2014-10-08T22:44:19Z</example>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        /// <example><p>After 5 years, I decided to retire the old \"Contact Card\" website. My HTML and CSS is rusty, but I managed to hack this page together and make it semi-responsive. Even includes @3x assets for those on an iPhone 6 Plus!</p>\n\n<p>http://timvandamme.com</p></example>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The height.
        /// </summary>
        /// <example>300</example>
        [JsonProperty("height")]
        public uint Height { get; set; }

        /// <summary>
        /// The html url for this shot.
        /// </summary>
        /// <example>http://dribbble.com/shots/1757954-End-of-an-era</example>
        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        /// <summary>
        /// The unique identifier.
        /// </summary>
        /// <example>1757954</example>
        [JsonProperty("id")]
        public uint Id { get; set; }

        /// <summary>
        /// The set of images that are related with this shot.
        /// </summary>
        [JsonProperty("images")]
        public ShotImage Images { get; set; }

        /// <summary>
        /// Indicates whether the shot is a animation or not.
        /// </summary>
        /// <example>false</example>
        [JsonProperty("animated")]
        public bool IsAnimated { get; set; }

        /// <summary>
        /// The amount of likes.
        /// </summary>
        /// <example>446</example>
        [JsonProperty("likes_count")]
        public uint LikesCount { get; set; }

        /// <summary>
        /// The url for the likes.
        /// </summary>
        /// <example>https://api.dribbble.com/v1/shots/1757954/likes</example>
        [JsonProperty("likes_url")]
        public Uri LikesUrl { get; set; }

        /// <summary>
        /// The <see cref="User"/> that created this <see cref="Shot"/>.
        /// </summary>
        [JsonProperty("user")]
        public User Player { get; set; }

        /// <summary>
        /// The url for the projects.
        /// </summary>
        /// <example>https://api.dribbble.com/v1/shots/1757954/projects</example>
        [JsonProperty("projects_url")]
        public Uri ProjectsUrl { get; set; }

        /// <summary>
        /// The amount of rebounds.
        /// </summary>
        /// <example>0</example>
        [JsonProperty("rebounds_count")]
        public uint ReboundsCount { get; set; }

        /// <summary>
        /// The url for the rebounds.
        /// </summary>
        /// <example>https://api.dribbble.com/v1/shots/1757954/rebounds</example>
        [JsonProperty("rebounds_url")]
        public Uri ReboundsUrl { get; set; }

        /// <summary>
        /// The list of tags.
        /// </summary>
        /// <example>
        /// [ "dribbble", "exposure", "instagram", "personal", "timvandamme", "twitter", "vcard" ]
        /// </example>
        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// The team.
        /// </summary>
        /// <example>null</example>
        [JsonProperty("team")]
        public object Team { get; set; }

        /// <summary>
        /// The title.
        /// </summary>
        /// <example>End of an era</example>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The amount of views.
        /// </summary>
        /// <example>14360</example>
        [JsonProperty("views_count")]
        public uint ViewsCount { get; set; }

        /// <summary>
        /// The width.
        /// </summary>
        /// <example>800</example>
        [JsonProperty("width")]
        public uint Width { get; set; }
    }
}
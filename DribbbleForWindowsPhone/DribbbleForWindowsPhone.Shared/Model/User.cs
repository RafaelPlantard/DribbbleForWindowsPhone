using System;

namespace DribbbleForWindowsPhone.Model
{
    /// <summary>
    /// Represents the <see cref="User"/> related to a specific <see cref="Shot"/> on <see cref="DribbbleCenter"/>.
    /// </summary>
    class User
    {
        #region Properties

        /// <summary>
        /// The unique identifier.
        /// </summary>
        /// <example>22</example>
        public int Id { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        /// <example>Tim Van Damme</example>
        public string Name { get; set; }

        /// <summary>
        /// The location.
        /// </summary>
        /// <example>San Francisco, CA</example>
        public string Location { get; set; }

        /// <summary>
        /// The amount of followers.
        /// </summary>
        /// <example>33988</example>
        public uint FollowersCount { get; set; }

        /// <summary>
        /// The amount of draftees.
        /// </summary>
        /// <example>32</example>
        public uint DrafteesCount { get; set; }

        /// <summary>
        /// The amount of likes.
        /// </summary>
        /// <example>6751</example>
        public uint LikesCount { get; set; }

        /// <summary>
        /// The amount of likes was received.
        /// </summary>
        /// <example>25240</example>
        public uint LikesReceivedCount { get; set; }

        /// <summary>
        /// The amount of comments.
        /// </summary>
        /// <example>579</example>
        public uint CommentsCount { get; set; }

        /// <summary>
        /// The amount of comment was received.
        /// </summary>
        /// <example>2565</example>
        public uint CommentReceivedCount { get; set; }

        /// <summary>
        /// The amount of rebounds.
        /// </summary>
        /// <example>7</example>
        public uint ReboundsCount { get; set; }

        /// <summary>
        /// The amount rebounds was received.
        /// </summary>
        /// <example>29</example>
        public int ReboundsReceivedCount { get; set; }

        /// <summary>
        /// The url.
        /// </summary>
        /// <example>http://dribbble.com/maxvoltar</example>
        public Uri Url { get; set; }

        /// <summary>
        /// The avatar url.
        /// </summary>
        /// <example>https://d13yacurqjgara.cloudfront.net/users/22/avatars/normal/a5485ce6f3de5df6093fb271a89ba5b1.jpg?1427653634</example>
        public Uri AvatarUrl { get; set; }

        /// <summary>
        /// The user name.
        /// </summary>
        /// <example>maxvoltar</example>
        public string Username { get; set; }

        /// <summary>
        /// The Twitter screen name.
        /// </summary>
        /// <example>maxvoltar</example>
        public string TwitterScreenName { get; set; }

        /// <summary>
        /// The url of the website.
        /// </summary>
        /// <example>http://maxvoltar.com/</example>
        public Uri WebsiteUrl { get; set; }

        /// <summary>
        /// The player's unique identifier that drafted it.
        /// </summary>
        /// <example>1</example>
        public uint? DraftedByPlayerId { get; set; }

        /// <summary>
        /// The amount of shots.
        /// </summary>
        /// <example>109</example>
        public uint ShotsCount { get; set; }

        /// <summary>
        /// The amount of following count.
        /// </summary>
        /// <example>508</example>
        public uint FollowingCount { get; set; }

        /// <summary>
        /// The date and time that it was created.
        /// </summary>
        /// <example>2009/08/10 04:38:51 -0400</example>
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}
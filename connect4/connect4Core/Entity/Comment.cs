using System;

namespace connect4Core.Entity
{
    public class Comment
    {
        public string Player { get; set; }

        public string Feedback { get; set; }

        public DateTime CommentedAt { get; set; }

        /// <summary>
        /// Custom format od displaying.
        /// </summary>
        /// <returns>String in custom format</returns>
        public override string ToString()
        {
            return "Player: " + Player +
                   "Comment: " + Feedback +
                   "At: " + CommentedAt + "\n";
        }
    }
}

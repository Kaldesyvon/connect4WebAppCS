using System;

namespace connect4Core.Entity
{
    public class Comment
    {
        public string Player { get; set; }

        public string Feedback { get; set; }

        public DateTime CommentedAt { get; set; }
    }
}

using System;

namespace connect4Core.Entity
{
    public class Rating
    {
        public string Player { get; set; }

        public int Stars { get; set; }

        public DateTime RatedAt { get; set; }
    }
}

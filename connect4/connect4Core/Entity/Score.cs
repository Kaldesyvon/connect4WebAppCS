using System;

namespace connect4Core.Entity
{
    public class Score
    {
        public string Player { get; set; }

        public int Points { get; set; }

        public DateTime PlayedAt { get; set; }
    }
}

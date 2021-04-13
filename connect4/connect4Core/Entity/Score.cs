using System;

namespace connect4Core.Entity
{
    public class Score
    {
        public int Id { get; set; }

        public string Player { get; set; }

        public int Points { get; set; }

        public DateTime PlayedAt { get; set; }

        /// <summary>
        /// Custom format od displaying.
        /// </summary>
        /// <returns>String in custom format</returns>
        public override string ToString()
        {
            return "Player: " + Player +
                   "Points: " + Points +
                   "At: " + PlayedAt + "\n";
        }
    }
}

using System;

namespace connect4Core.Entity
{
    public class Rating
    {
        public int Id { get; set; }

        public string Player { get; set; }

        public int Stars { get; set; }

        public DateTime RatedAt { get; set; }

        /// <summary>
        /// Custom format od displaying.
        /// </summary>
        /// <returns>String in custom format</returns>
        public override string ToString()
        {
            return "Player: " + Player +
                   "Rating: " + Stars +
                   "At: " + RatedAt + "\n";
        }
    }
}

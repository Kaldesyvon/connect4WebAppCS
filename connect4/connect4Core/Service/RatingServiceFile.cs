using System.Collections.Generic;
using System.Linq;
using connect4Core.Entity;

namespace connect4Core.Service
{
    public class RatingServiceFile : IRatingService
    {
        private readonly IList<Rating> _ratings = new List<Rating>();

        /// <summary>
        /// Adds rating to list of rating.
        /// </summary>
        /// <param name="rating">Actual rating.</param>
        public void AddRating(Rating rating)
        {
            foreach (var r in _ratings)
            {
                if (r.Player != rating.Player) continue;

                r.Stars = rating.Stars;
                r.RatedAt = rating.RatedAt;
                return;
            }
            _ratings.Add(rating);
        }

        /// <summary>
        /// Searches in list for first occurrence of player's name
        /// </summary>
        /// <param name="name">Name of player.</param>
        /// <returns>Rating which user of 'name' rated, -1 if he did not.</returns>
        public int GetRating(string name)
        {
            foreach (var r in _ratings)
            {
                if (r.Player == name)
                {
                    return r.Stars;
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets a average of every rating.
        /// </summary>
        /// <returns>Average of every rating, -1 if list is empty</returns>
        public double GetAverageRating()
        {
            if (_ratings.Count == 0)
            {
                return -1;
            }
            return _ratings.Select(a => a.Stars).Average();
        }

        /// <summary>
        /// Clears list of rating.
        /// </summary>
        public void Reset()
        {
            _ratings.Clear();
        }
    }
}

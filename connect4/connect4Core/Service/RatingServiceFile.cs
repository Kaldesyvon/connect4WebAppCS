using System.Collections.Generic;
using System.Linq;
using connect4Core.Entity;

namespace connect4Core.Service
{
    public class RatingServiceFile : IRatingService
    {
        private readonly IList<Rating> _ratings = new List<Rating>();

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

        public double GetAverageRating()
        {
            return _ratings.Select(a => a.Stars).Average();
        }

        public void Reset()
        {
            _ratings.Clear();
        }
    }
}

using System.Collections.Generic;
using connect4Core.Entity;

namespace connect4Core.Service
{
    public interface IRatingService
    {
        void AddRating(Rating rating);

        int GetRating(string name);

        double GetAverageRating();

        IList<Rating> GetRatings();

        void Reset();
    }
}

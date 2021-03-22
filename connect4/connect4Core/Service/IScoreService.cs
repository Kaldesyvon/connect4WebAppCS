using System.Collections.Generic;
using connect4Core.Entity;

namespace connect4Core.Service
{
    public interface IScoreService
    {
        void AddScore(Score score);
        IList<Score> GetTopScores();
        void  Reset();
    }
}

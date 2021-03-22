using System;
using System.Collections.Generic;
using System.Text;
using connect4Core.Entity;

namespace connect4Core.Service
{
    public interface IScoreService
    {
        void AddScore();
        IList<Score> getTopScores();
        void reset();
    }
}

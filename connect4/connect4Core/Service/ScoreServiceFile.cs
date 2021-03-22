using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using connect4Core.Entity;

namespace connect4Core.Service
{
    public class ScoreServiceFile : IScoreService
    {
        private readonly IList<Score> _scores = new List<Score>();
        void IScoreService.AddScore(Score score)
        {
            _scores.Add(score);
        }

        IList<Score> IScoreService.GetTopScores()
        {
            return _scores.OrderByDescending(o => o.Points).Take(10).ToList();
        }

        void IScoreService.Reset()
        {
            _scores.Clear();
        }
    }
}

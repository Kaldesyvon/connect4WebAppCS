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

        /// <summary>
        /// Add score to list of score.
        /// </summary>
        /// <param name="score">Actual score.</param>
        void IScoreService.AddScore(Score score)
        {
            _scores.Add(score);
        }

        /// <summary>
        /// Get top score of game that all players played.
        /// </summary>
        /// <returns>List of top 10 scores.</returns>
        IList<Score> IScoreService.GetTopScores()
        {
            return _scores.OrderByDescending(o => o.Points).Take(10).ToList();
        }


        /// <summary>
        /// Clears list of scores.
        /// </summary>
        void IScoreService.Reset()
        {
            _scores.Clear();
        }
    }
}

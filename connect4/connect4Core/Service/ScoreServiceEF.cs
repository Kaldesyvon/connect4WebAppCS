using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using connect4Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace connect4Core.Service
{
    [Serializable]
    public class ScoreServiceEf : IScoreService
    {
        public void AddScore(Score score)
        {
            using var context = new Connect4DbContext();
            context.Scores.Add(score);
            context.SaveChanges();
        }

        public IList<Score> GetTopScores()
        {
            using var context = new Connect4DbContext();
            return (from s in context.Scores orderby s.Points descending select s).Take(10).ToList();
        }

        public void Reset()
        {
            using var context = new Connect4DbContext();
            context.Database.ExecuteSqlRaw("truncate table Scores");
        }
    }
}

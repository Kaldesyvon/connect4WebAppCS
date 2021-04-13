using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using connect4Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace connect4Core.Service
{
    public class RatingServiceEF : IRatingService
    {
        public void AddRating(Rating rating)
        {
            using var context = new Connect4DbContext();
            if (GetRating(rating.Player) == -1)
            {
                context.Ratings.Add(rating);
                context.SaveChanges();
            }
            else
            {
                foreach (var r in (from r in context.Ratings select r).ToList())
                {
                    if (rating.Player == r.Player)
                    {
                        r.Stars = rating.Stars;
                    }
                }
            }
            context.SaveChanges();
        }

        public int GetRating(string name)
        {
            using var context = new Connect4DbContext();
            var query = from r in context.Ratings
                where r.Player == name
                select r.Stars;
            return query.ToList().Count == 0 ? -1 : query.ToList()[0];
        }

        public double GetAverageRating()
        {
            using var context = new Connect4DbContext();
            return (from r in context.Ratings select r.Stars).Average();
        }

        public void Reset()
        {
            using var context = new Connect4DbContext();
            context.Database.ExecuteSqlRaw("truncate table Ratings");
        }
    }
}

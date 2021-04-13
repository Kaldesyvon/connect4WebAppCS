using System;
using System.Collections.Generic;
using System.Text;
using connect4Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace connect4Core.Service
{
    public class Connect4DbContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
        
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Connect4;Trusted_Connection=True;");
        }
    }
}

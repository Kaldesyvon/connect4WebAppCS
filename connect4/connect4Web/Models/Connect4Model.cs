using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using connect4Core.Core;
using connect4Core.Entity;
using connect4Core.Service;

namespace connect4Web.Models
{
    public class Connect4Model
    {
        public IScoreService ScoreService { get; set; }
        public Playfield Playfield { get; set; }
        public int Points { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace connect4Core.Core
{
    internal class Pair
    {
        public int Column { get; set; }

        public int Score { get; set; }

        public Pair(int column, int score)
        {
            Column = column;
            Score = score;
        }
    }
}

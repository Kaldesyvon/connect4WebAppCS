using System;
using System.Collections.Generic;
using System.Text;

namespace connect4Core.Core
{
    public class Player
    {
        private int points;
        private readonly Playfield playfield;
        public Player(string name, PlayerColor playerColor, Playfield playfield)
        {
            Name = name;
            PlayerColor = playerColor;
            this.playfield = playfield;
            points = 0;
        }

        public void AddPoints(int amount)
        {
            points += amount;
        }

        public int GetPoints => points;

        public string Name { get; }

        public PlayerColor PlayerColor { get; }

        public bool AddStone(int column)
        {
            var rowPosition = 0;

            if (playfield[0, column] != null)
            {
                return false;
            }

            var stone = new Tile(PlayerColor == PlayerColor.Red ? TileState.Red : TileState.Yellow, column);

            while (rowPosition < playfield.Height - 1)
            {
                if (playfield[rowPosition + 1, column] == null)
                {
                    rowPosition++;
                }
                else
                {
                    break;
                }
            }
            playfield[rowPosition, column] = stone;
            playfield[rowPosition, column].RowPosition = rowPosition;
            return true;
        }
    }
}
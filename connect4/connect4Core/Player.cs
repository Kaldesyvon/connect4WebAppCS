using System;
using System.Collections.Generic;
using System.Text;

namespace connect4Core
{
    public class Player
    {
        private int points = 0;
        private readonly Playfield playfield;
        public Player(string name, PlayerColor playerColor, Playfield playfield)
        {
            Name = name;
            PlayerColor = playerColor;
            this.playfield = playfield;
        }

        public void AddPoints(int amount)
        {
            points += amount;
        }

        public string Name { get; }

        public PlayerColor PlayerColor { get; }

        public bool AddStone(int column)
        {
            var tiles = playfield.Tiles;
            var rowPosition = 0;

            if (tiles[0,column] != null)
            {
                return false;
            }

            var stone = new Tile(PlayerColor == PlayerColor.Red ? TileState.Red : TileState.Yellow, column);

            while (rowPosition < playfield.Height - 1)
            {
                if (tiles[rowPosition + 1, column] == null)
                {
                    rowPosition++;
                }
                else
                {
                    break;
                }
            }
            tiles[rowPosition, column] = stone;
            tiles[rowPosition, column].RowPosition = rowPosition;
            return true;
        }
    }
}

using System;
using System.Runtime.InteropServices.ComTypes;

namespace connect4Core
{
    public class Playfield
    {
        public Playfield(int playfieldWidth, int playfieldHeight)
        {
            Width = playfieldWidth;
            Height = playfieldHeight;
            Tiles = new Tile[playfieldHeight, playfieldWidth];
        }

        public int Width { get; }
        public int Height { get; }

        public Tile[,] Tiles { get; }

        public bool CheckForWin()
        {
            for (var rowIndex = 0; rowIndex < Height; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < Width; columnIndex++)
                {
                    if (Tiles[rowIndex, columnIndex] == null) continue;

                    var stoneRowPosition = Tiles[rowIndex, columnIndex].RowPosition;
                    var stoneColumnPosition = Tiles[rowIndex, columnIndex].ColumnPosition;
                    var color = Tiles[rowIndex, columnIndex].StoneColor;
                    for (var deltaX = -1; deltaX <= 1; deltaX++)
                    {
                        for (var deltaY = -1; deltaY <= 1; deltaY++)
                        {
                            if (deltaX == 0 && deltaY != -1)
                            {
                                continue;
                            }
                            if (CheckDirection(stoneRowPosition, stoneColumnPosition, color, deltaX, deltaY))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private bool CheckDirection(int stoneRowPosition, int stoneColumnPosition, TileState color, int dx, int dy)
        {

            if ((dx == 1 && stoneColumnPosition > Width - 4)
                || (dx == -1 && stoneColumnPosition < 3)
                || (dy == -1 && stoneRowPosition < 3)
                || (dy == 1 && stoneRowPosition > Height - 4))
            {
                return false;
            }

            for (var i = 1; i <= 3; i++)
            {
                for (var j = 1; j <= 3; j++)
                {
                    if (Tiles[stoneRowPosition + dy * j, stoneColumnPosition + dx * j] != null)
                    {
                        if (Tiles[stoneRowPosition + dy * j, stoneColumnPosition + dx * j].StoneColor != color)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
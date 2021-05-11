using System;

namespace connect4Core.Core
{
    [Serializable]
    public class Playfield
    {
        public int Points { get; private set; }
        public Tile[,] Tiles { get; set; }
        public int Moves { get; private set; }

        /// <summary>
        /// Creates field which game is played on. Playfield is made of Tiles.
        /// </summary>
        /// <param name="playfieldWidth">Width od the field.</param>
        /// <param name="playfieldHeight">Height of the field.</param>
        public Playfield(int playfieldWidth, int playfieldHeight)
        {
            Width = playfieldWidth;
            Height = playfieldHeight;
            Tiles = new Tile[playfieldHeight, playfieldWidth];
            Moves = 0;
            Points = 0;
        }

        public void AddPoints(int amount)
        {
            Points += amount;
        }

        public int Width { get; }

        public int Height { get; }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i">Row position.</param>
        /// <param name="j">Column position.</param>
        /// <returns>Tile located at [i,j]</returns>
        public Tile this[int i, int j]
        {
            get => Tiles[i, j];
            set => Tiles[i, j] = value;
        }

        /// <summary>
        /// Player make action of adding stone to playfield.
        /// </summary>
        /// <param name="column">Indicates to which column stone has to fall.</param>
        /// <param name="color">Color if stone that will be added</param>
        /// <returns>true if stone was added successfully, otherwise false.</returns>
        public bool AddStone(int column, Color color)
        {
            var rowPosition = 0;

            if (Tiles[0, column] != null)
            {
                return false;
            }

            var stone = new Tile(color, column);

            while (rowPosition < Height - 1)
            {
                if (this[rowPosition + 1, column] == null)
                {
                    rowPosition++;
                }
                else
                {
                    break;
                }
            }
            this[rowPosition, column] = stone;
            this[rowPosition, column].RowPosition = rowPosition;
            Moves++;
            return true;
        }

        /// <summary>
        /// Checks if game is done by checking every eight directions of each stone.
        /// </summary>
        /// <returns>true if game is won, otherwise false</returns>
        public bool CheckForWin(Color color)
        {
            for (var rowIndex = 0; rowIndex < Height; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < Width; columnIndex++)
                {
                    if (this[rowIndex, columnIndex] == null || this[rowIndex, columnIndex].StoneColor != color)
                        continue;
                    var stoneRowPosition = this[rowIndex, columnIndex].RowPosition;
                    var stoneColumnPosition = this[rowIndex, columnIndex].ColumnPosition;
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

        private bool CheckDirection(int stoneRowPosition, int stoneColumnPosition, Color color, int dx, int dy)
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
                    if (this[stoneRowPosition + dy * j, stoneColumnPosition + dx * j] != null)
                    {
                        if (this[stoneRowPosition + dy * j, stoneColumnPosition + dx * j].StoneColor != color)
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

        public bool IsGameWon()
        {
            return CheckForWin(Color.Yellow) || CheckForWin(Color.Red);
        }
    }
}
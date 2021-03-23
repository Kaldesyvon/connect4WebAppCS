namespace connect4Core.Core
{
    public class Playfield
    {
        private readonly Tile[,] _tiles;

        /// <summary>
        /// Creates field which game is played on. Playfield is made of Tiles.
        /// </summary>
        /// <param name="playfieldWidth">Width od the field.</param>
        /// <param name="playfieldHeight">Height of the field.</param>
        public Playfield(int playfieldWidth, int playfieldHeight)
        {
            Width = playfieldWidth;
            Height = playfieldHeight;
            _tiles = new Tile[playfieldHeight, playfieldWidth];
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
            get => _tiles[i, j];
            set => _tiles[i, j] = value;
        }

        /// <summary>
        /// Checks if game is done by checking every eight directions of each stone.
        /// </summary>
        /// <returns>true if game is won, otherwise false</returns>
        public bool CheckForWin()
        {
            for (var rowIndex = 0; rowIndex < Height; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < Width; columnIndex++)
                {
                    if (this[rowIndex, columnIndex] == null) continue;

                    var stoneRowPosition = this[rowIndex, columnIndex].RowPosition;
                    var stoneColumnPosition = this[rowIndex, columnIndex].ColumnPosition;
                    var color = this[rowIndex, columnIndex].StoneColor;
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
    }
}
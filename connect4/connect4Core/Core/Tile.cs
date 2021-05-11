using System;

namespace connect4Core.Core
{
    [Serializable]
    public class Tile
    {
        public Tile(Color tileState, int columnPosition)
        {
            StoneColor = tileState;
            ColumnPosition = columnPosition;
            RowPosition = 0;
        }

        public Color StoneColor { get; }

        public int RowPosition { get; set; }

        public int ColumnPosition { get; }
    }
}
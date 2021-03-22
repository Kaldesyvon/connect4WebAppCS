namespace connect4Core.Core
{
    public class Tile
    {
        public Tile(TileState tileState, int columnPosition)
        {
            StoneColor = tileState;
            ColumnPosition = columnPosition;
            RowPosition = 0;
        }

        public TileState StoneColor { get; }
        public int RowPosition { get; set; }
        public int ColumnPosition { get; }
    }
}
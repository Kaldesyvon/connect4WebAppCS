namespace connect4Core
{
    public class Stone : Tile
    {
        public Stone(StoneColor stoneColor, int columnPosition)
        {
            StoneColor = stoneColor;
            ColumnPosition = columnPosition;
            RowPosition = 0;
        }
        public int RowPosition { get; set; }
        public int ColumnPosition { get; }
        public new StoneColor StoneColor { get; }
    }

}
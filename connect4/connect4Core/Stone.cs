namespace connect4Core
{
    public class Stone
    {
        private int RowPosition { get; set; }
        private int ColumnPosition { get; }
        private StoneColor StoneColor { get; }

        public Stone(StoneColor stoneColor, int columnPosition)
        {
            this.StoneColor = stoneColor;
            this.ColumnPosition = columnPosition;
        }
    }
}
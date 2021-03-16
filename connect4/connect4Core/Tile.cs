namespace connect4Core
{
    public class Tile
    {
        private StoneColor? stoneColor;

        public Tile()
        {
            stoneColor = null;
        }

        public StoneColor? GetStoneColor()
        {
            return stoneColor;
        }
    }
}
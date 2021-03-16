namespace connect4Core
{
    public class Tile
    {
        private StoneColor? _stoneColor;

        public Tile()
        {
            _stoneColor = null;
        }
        public StoneColor? StoneColor { get; set; }
    }
}
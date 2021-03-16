namespace connect4Core
{
    public class Playfield
    {
        private Stone stone;
        private Tile[,] tiles;
        public Playfield(int playfieldWidth, int playfieldHeight)
        {
            PlayfieldWidth = playfieldWidth;
            PlayfieldHeight = playfieldHeight;
            tiles = new Tile[playfieldHeight, playfieldWidth];
        }

        public int PlayfieldWidth { get; }
        public int PlayfieldHeight { get; }
        public Tile[,] Tiles { get; }


    }
}
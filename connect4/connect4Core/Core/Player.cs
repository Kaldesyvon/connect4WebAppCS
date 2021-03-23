namespace connect4Core.Core
{
    public class Player
    {
        private readonly Playfield _playfield;
        public Player(string name, Color playerColor, Playfield playfield)
        {
            Name = name;
            PlayerColor = playerColor;
            this._playfield = playfield;
            Points = 0;
        }

        /// <summary>
        /// Adds amount points to player.
        /// </summary>
        /// <param name="amount">amount of points.</param>
        public void AddPoints(int amount)
        {
            Points += amount;
        }

        public int Points { get; private set; }

        public string Name { get; }

        public Color PlayerColor { get; }

        /// <summary>
        /// Player make action of adding stone to playfield.
        /// </summary>
        /// <param name="column">Indicates to which column stone has to fall.</param>
        /// <returns>true if stone was added successfully, otherwise false.</returns>
        public bool AddStone(int column)
        {
            var rowPosition = 0;

            if (_playfield[0, column] != null)
            {
                return false;
            }

            var stone = new Tile(PlayerColor, column);

            while (rowPosition < _playfield.Height - 1)
            {
                if (_playfield[rowPosition + 1, column] == null)
                {
                    rowPosition++;
                }
                else
                {
                    break;
                }
            }
            _playfield[rowPosition, column] = stone;
            _playfield[rowPosition, column].RowPosition = rowPosition;
            return true;
        }
    }
}
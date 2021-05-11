using System;

namespace connect4Core.Core
{
    [Serializable]
    public class Player
    {
        /// <summary>
        /// Creates instance of player.
        /// </summary>
        /// <param name="name">Name of player.</param>
        /// <param name="playerColor">His color.</param>
        /// <param name="playfield">Playfield which players play on.</param>
        public Player(string name, Color playerColor)
        {
            Name = name;
            PlayerColor = playerColor;
        }

        public string Name { get; }

        public Color PlayerColor { get; }

        
    }
}
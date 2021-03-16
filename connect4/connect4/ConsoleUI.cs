using System;
using connect4Core;

namespace connect4Console
{
    public class ConsoleUI
    {
        private readonly Playfield _playfield;

        public ConsoleUI(Playfield playfield)
        {
            _playfield = playfield;
        }

        public void Play()
        {
            ShowPlayfield();
        }

        public void ShowPlayfield()
        {
            var tiles = _playfield.Tiles;

            for (var i = 0; i < _playfield.PlayfieldHeight; i++)
            {
                Console.Write(i);
                for (var j = 0; j < _playfield.PlayfieldWidth; j++)
                {

                    if (tiles[i, j] == null)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write((tiles[i, j].GetStoneColor() == StoneColor.Red) ? " R " : " Y ");
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < _playfield.PlayfieldWidth; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}
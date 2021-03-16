using System;
using connect4Core;

namespace connect4Console
{
    public class ConsoleUi
    {
        private readonly Playfield _playfield;
        

        public ConsoleUi(Playfield playfield)
        {
            _playfield = playfield;
        }

        public void Play()
        {
            var maxTurns = _playfield.PlayfieldHeight * _playfield.PlayfieldWidth;
            var turnsDone = 0;
            var player = 1;
            do
            {
                ShowPlayfield();
                var column = ProcessInput();

                if (!_playfield.AddStone((player == 1) ? StoneColor.Red : StoneColor.Yellow, column))
                {
                    Console.WriteLine("stone cannot be added on top");
                    continue;
                }
                
                player = SwitchPlayer(player);
                turnsDone++;
            } while (_playfield.CheckForWin() && turnsDone != maxTurns);
        }

        private static int SwitchPlayer(int player)
        {
            return -player;
        }

        public void ShowPlayfield()
        {
            for (var i = 0; i < _playfield.PlayfieldHeight; i++)
            {
                Console.Write(i);
                for (var j = 0; j < _playfield.PlayfieldWidth; j++)
                {
                    var tile = _playfield.GetTile(i, j);

                    if (tile == null)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write((tile.StoneColor == StoneColor.Red) ? " R " : " Y ");
                    }
                }
                Console.WriteLine();
            }

            for (var i = 0; i < _playfield.PlayfieldWidth; i++)
            {
                Console.Write("{0,3}", i);
            }
            Console.WriteLine();
        }
        private static int ProcessInput()
        {
            Console.Write("select column: ");
            return Int32.Parse(Console.ReadLine()!);
            //if (input < 0 || input > _playfield.PlayfieldWidth)
            //{
            //    ProcessInput();
            //}
        }
    }
}
using System;
using connect4Core.Core;

namespace connect4Console
{
    public class ConsoleUi
    {
        private readonly Playfield _playfield;
        private readonly Player _player1;
        private readonly Player _player2;

        public ConsoleUi(Playfield playfield)
        {
            _playfield = playfield;
            _player1 = CreatePlayer(PlayerColor.Red, playfield);
            _player2 = CreatePlayer(PlayerColor.Yellow, playfield);
        }

        private static Player CreatePlayer(PlayerColor color, Playfield playfield)
        {
            Console.WriteLine("Enter name of " + (color == PlayerColor.Red ? "RED" : "YELLOW") + " player: ");
            var line = Console.ReadLine();
            return new Player(line, color, playfield);
        }

        public void Play(PlayerColor firstPlayer)
        {
            var maxTurns = _playfield.Height * _playfield.Width;
            var turnsDone = 0;

            var playerOnTurn = firstPlayer == PlayerColor.Red ? _player1 : _player2;
            do
            {
                ShowPlayfield();
                var column = ProcessInput();

                if (!playerOnTurn.AddStone(column))
                {
                    Console.WriteLine("stone cannot be added on top");
                    continue;
                }

                playerOnTurn = SwitchPlayer(playerOnTurn);
                turnsDone++;
            } while (!_playfield.CheckForWin() && turnsDone != maxTurns);

            ShowPlayfield();


            if (turnsDone == maxTurns)
            {
                Tie(_player1, _player2);
            }
            else
            {
                CelebrateWinner(SwitchPlayer(playerOnTurn), playerOnTurn);
            }

            PrintScore();
        }

        private void PrintScore()
        {
            Console.WriteLine(_player1.GetPoints);
            Console.WriteLine(_player2.GetPoints);
        }

        private static void CelebrateWinner(Player winner, Player looser)
        {
            Console.WriteLine(winner.Name + " wins!");
            winner.AddPoints(10);
            looser.AddPoints(-5);
        }

        private static void Tie(Player player1, Player player2)
        {
            Console.WriteLine("Its a TIE!");
            player1.AddPoints(5);
            player2.AddPoints(5);
        }

        private Player SwitchPlayer(Player player)
        {
            return player.PlayerColor == PlayerColor.Red ? _player2 : _player1;
        }

        public void ShowPlayfield()
        {
            Console.Clear();
            for (var i = 0; i < _playfield.Height; i++)
            {
                Console.Write(i);
                for (var j = 0; j < _playfield.Width; j++)
                {
                    var tile = _playfield[i, j];

                    if (tile == null)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.ForegroundColor = tile.StoneColor == TileState.Red ? ConsoleColor.Red : ConsoleColor.Yellow;
                        Console.Write(" O ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }

            for (var i = 0; i < _playfield.Width; i++)
            {
                Console.Write("{0,3}", i);
            }
            Console.WriteLine();

        }

        private static int ProcessInput()
        {
            Console.Write("select column: ");
            return int.Parse(Console.ReadLine()!);
        }
    }
}
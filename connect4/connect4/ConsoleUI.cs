using connect4Core.Core;
using connect4Core.Entity;
using connect4Core.Service;
using System;

namespace connect4Console
{
    public class ConsoleUi
    {
        private static  Playfield _playfield;
        private readonly Player _player1;
        private readonly Player _player2;

        private static readonly IRatingService Rating = new RatingServiceFile();
        private static readonly ICommentService Comment = new CommentServiceFile();
        private static readonly IScoreService Score = new ScoreServiceFile();

        /// <summary>
        /// Create Console User Interface that handles user's input and prints game.
        /// </summary>
        /// <param name="playfield">Playfield which is game played on.</param>
        public ConsoleUi(Playfield playfield)
        {
            _playfield = playfield;
            _player1 = CreatePlayer(Color.Red, playfield);
            _player2 = CreatePlayer(Color.Yellow, playfield);
        }

        private static Player CreatePlayer(Color color, Playfield playfield)
        {
            Console.WriteLine("Enter name of " + (color == Color.Red ? "RED" : "YELLOW") + " player: ");
            var line = Console.ReadLine();
            return new Player(line, color, playfield);
        }

        /// <summary>
        /// Initialize game.
        /// </summary>
        /// <param name="firstPlayer">Color of player that take first turn.</param>
        public void Play(Color firstPlayer)
        {
            while (true)
            {
                var maxTurns = _playfield.Height * _playfield.Width;
                var turnsDone = 0;

                var playerOnTurn = firstPlayer == Color.Red ? _player1 : _player2;
                do
                {
                    ShowPlayfield();
                    PrintWhoseTurn(playerOnTurn);

                    var column = ProcessInput(playerOnTurn, SwitchPlayer(playerOnTurn));

                    if (!playerOnTurn.AddStone(column))
                    {
                        Console.WriteLine("Stone cannot be added on top");
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
                if (PlayAgain())
                {
                    firstPlayer = SwitchPlayer(firstPlayer);
                    continue;
                }
                break;
            }
        }

        private static Color SwitchPlayer(Color playerColor)
        {
            return playerColor == Color.Red ? Color.Yellow : Color.Red;
        }

        private Player SwitchPlayer(Player player)
        {
            return player.PlayerColor == Color.Red ? _player2 : _player1;
        }

        private static bool PlayAgain()
        {
            Console.WriteLine("Do you want to play again? [Y/n]");
            
            while (true)
            {
                var line = Console.ReadLine()?.ToLower();
                switch (line)
                {
                    case "y":
                        EmptyPlayfield();
                        return true;
                    case "n":
                        return false;
                }
                Console.WriteLine("Wrong input");
            }
        }

        private static void EmptyPlayfield()
        {
            for (var i = 0; i < _playfield.Height; i++)
            {
                for (var j = 0; j < _playfield.Width; j++)
                {
                    _playfield[i, j] = null;
                }
            }
        }

        private static void PrintWhoseTurn(Player playerOnTurn)
        {
            Console.WriteLine();
            Console.ForegroundColor = playerOnTurn.PlayerColor == Color.Red ? ConsoleColor.Red : ConsoleColor.Yellow;
            Console.Write(playerOnTurn.Name);
            Console.ResetColor();
            Console.Write("'s turn");
        }

        private void PrintScore()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_player1.Name + "'s points " + _player1.Points);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_player2.Name + "'s points " + _player2.Points);
            Console.ResetColor();
        }

        private static void CelebrateWinner(Player winner, Player looser)
        {
            Console.WriteLine();
            Console.WriteLine(winner.Name + " wins!");
            winner.AddPoints(10);
            looser.AddPoints(-5);
        }

        private static void Tie(Player player1, Player player2)
        {
            Console.WriteLine("It's a TIE!");
            player1.AddPoints(5);
            player2.AddPoints(5);
        }

        private static void ShowPlayfield()
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
                        Console.ForegroundColor = tile.StoneColor == Color.Red? ConsoleColor.Red : ConsoleColor.Yellow;
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
        }

        private static int ProcessInput(Player playerOnTurn, Player otherPlayer)
        {
            Console.WriteLine();
            string input;

            do
            {
                Console.WriteLine("Press x to exit, r to rate, f for feedback and t to see top score.");
                Console.WriteLine("Select column: ");
                input = Console.ReadLine();
                if (input != "x")
                {
                    if (input == "r")
                    {
                        Console.WriteLine("Rate this game (1,2,...,10)");
                        while (true)
                        {
                            int stars;
                            try
                            {
                                var line = Console.ReadLine();
                                stars = int.Parse(line!);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Bad input");
                                continue;
                            }
                            if (stars >= 1 && stars <= 10)
                            {
                                Rating.AddRating(new Rating()
                                    {Player = playerOnTurn.Name, Stars = stars, RatedAt = new DateTime()});
                                Console.WriteLine("Thank you for rating, here is average: " + Rating.GetAverageRating());
                                break;
                            }
                            Console.WriteLine("Wrong rating, rate from 1 to 10 integers");
                        }
                    }
                    else if (input == "f")
                    {
                        Console.WriteLine("Write what is on your heart");
                        var comment = Console.ReadLine();
                        Comment.AddComment(new Comment()
                            {Player = playerOnTurn.Name, Feedback = comment, CommentedAt = new DateTime()});
                        Console.WriteLine("Thank you for feedback");
                        
                    }
                    else if (input == "t")
                    {
                        Console.WriteLine("Here is list of 10 chads with highest score");
                        Console.WriteLine(Score.GetTopScores().ToString());
                    }
                    else
                    {
                        try
                        {
                            var columnInput = int.Parse(input!);
                            if (columnInput >= 0 && columnInput <= _playfield.Height - 1)
                            {
                                break;
                            }
                            Console.WriteLine("Invalid column");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Wrong input");
                        }
                    }
                }
                else if (input == "x")
                {
                    AddScore(playerOnTurn, otherPlayer);
                    Environment.Exit(0);
                }
                else
                {
                    return int.Parse(Console.ReadLine()!);
                }
            } while (true);
            return int.Parse(input);
        }

        private static void AddScore(Player playerOnTurn, Player otherPlayer)
        {
            Score.AddScore(new Score() {Player = playerOnTurn.Name, Points = playerOnTurn.Points, PlayedAt = new DateTime()} );
            Score.AddScore(new Score() {Player = otherPlayer.Name, Points = otherPlayer.Points, PlayedAt = new DateTime()} );
        }
    }
}
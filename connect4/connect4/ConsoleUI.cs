﻿using connect4Core.Core;
using connect4Core.Entity;
using connect4Core.Service;
using System;
using System.Linq;

namespace connect4Console
{
    public class ConsoleUi
    {
        private static  Playfield _playfield;
        private readonly Player _redPlayer;
        private readonly Player _yellowPlayer;

        private static readonly IRatingService Rating = new RatingServiceEf();
        private static readonly ICommentService Comment = new CommentServiceEf();
        private static readonly IScoreService Score = new ScoreServiceEf();

        /// <summary>
        /// Create Console User Interface that handles user's input and prints game.
        /// </summary>
        /// <param name="playfield">Playfield which is game played on.</param>
        public ConsoleUi(Playfield playfield)
        {
            _playfield = playfield;
            _redPlayer = CreatePlayer(Color.Red, playfield);
            _yellowPlayer = CreatePlayer(Color.Yellow, playfield);
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

                var playerOnTurn = firstPlayer == Color.Red ? _redPlayer : _yellowPlayer;
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
                    Tie(_redPlayer, _yellowPlayer);
                }
                else
                {
                    CelebrateWinner(SwitchPlayer(playerOnTurn), playerOnTurn);
                }

                PrintScore();

                if (PlayAgain())
                {
                    firstPlayer = SwitchPlayer(firstPlayer);
                    EmptyPlayfield();
                    continue;
                }
                AddScore(_redPlayer, _yellowPlayer);
                break;
            }
            Console.WriteLine("Thank you for playing!");
        }

        private static Player CreatePlayer(Color color, Playfield playfield)
        {
            Console.WriteLine("Enter name of " + (color == Color.Red ? "RED" : "YELLOW") + " player: ");
            var line = Console.ReadLine();
            return new Player(line, color, playfield);
        }

        private static Color SwitchPlayer(Color playerColor)
        {
            return playerColor == Color.Red ? Color.Yellow : Color.Red;
        }

        private Player SwitchPlayer(Player player)
        {
            return player.PlayerColor == Color.Red ? _yellowPlayer : _redPlayer;
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
            Console.WriteLine(_redPlayer.Name + "'s points " + _redPlayer.Points);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_yellowPlayer.Name + "'s points " + _yellowPlayer.Points);
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
                                    {Player = playerOnTurn.Name, Stars = stars, RatedAt = DateTime.Now});
                                Console.WriteLine("Thank you for rating, here is average: " + Rating.GetAverageRating());
                                break;
                            }
                            Console.WriteLine("Wrong rating, rate from 1 to 10 integers");
                        }
                    }
                    else if (input == "f")
                    {
                        while (true)
                        {
                            Console.WriteLine("Write what is on your heart. Type 'g' to see comments 'b' to go back");
                            var inputLine = Console.ReadLine();
                            if (inputLine == "g")
                            {
                                foreach (var comment in Comment.GetComments().Take(10))
                                {
                                    Console.WriteLine("{0} says: {1}", comment.Player, comment.Feedback);
                                }
                                break;
                            }
                            else if (inputLine == "b")
                            {
                                break;
                            }
                            Comment.AddComment(new Comment()
                                {Player = playerOnTurn.Name, Feedback = inputLine, CommentedAt = DateTime.Now});
                            Console.WriteLine("Thank you for feedback");
                            break;
                        }
                    }
                    else if (input == "t")
                    {
                        Console.WriteLine("Here is list of 10 chads with highest score");
                        foreach (var score in Score.GetTopScores())
                        {
                            Console.WriteLine("{0} has scored {1}", score.Player, score.Points);
                        }

                    }
                    else
                    {
                        try
                        {
                            var columnInput = int.Parse(input!);
                            if (columnInput >= 0 && columnInput <= _playfield.Height)
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

        private static void AddScore(Player player1, Player player2)
        {
            Score.AddScore(new Score() {Player = player1.Name, Points = player1.Points, PlayedAt = DateTime.Now} );
            Score.AddScore(new Score() {Player = player2.Name, Points = player2.Points, PlayedAt = DateTime.Now} );
        }
    }
}
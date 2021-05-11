using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using connect4Core.Core;
using connect4Core.Entity;
using connect4Core.Service;
using connect4Web.Models;
using Microsoft.AspNetCore.Http;

namespace connect4Web.Controllers
{
    public class Connect4Controller : Controller
    {
        private const string FieldSessionKey = "field";
        private const string ScoreSessionKey = "score";
        


        public IActionResult Index()
        {
            var playfield = new Playfield(7, 6);
            HttpContext.Session.SetObject(FieldSessionKey, playfield);

            var scoreService = new ScoreServiceEf();
            HttpContext.Session.SetObject(ScoreSessionKey, scoreService);

            var points = 0;
            HttpContext.Session.SetObject("points", points);

            return View("Index", CreateModel());
        }

        public IActionResult AddStone(int column)
        {
            var playfield = (Playfield)HttpContext.Session.GetObject(FieldSessionKey);
            var points = (int)HttpContext.Session.GetObject("points");
            if (!playfield.IsGameWon() && playfield.Moves != playfield.Height * playfield.Width)
            {
                while (!playfield.AddStone(column, Color.Red)) { }

                if (playfield.CheckForWin(Color.Red))
                {
                    points += 10;
                }
                var random = new Random();
                int move;
                do
                {
                    move = random.Next(7);
                } while (!playfield.AddStone(move, Color.Yellow));
                if (!playfield.CheckForWin(Color.Red) && playfield.CheckForWin(Color.Yellow))
                {
                    points -= 5;
                }
            }

            HttpContext.Session.SetObject(FieldSessionKey, playfield);
            HttpContext.Session.SetObject("points", points);
            return View("Index", CreateModel());
        }

        private Connect4Model CreateModel()
        {
            var playfield = (Playfield) HttpContext.Session.GetObject(FieldSessionKey);
            var scoreService = (ScoreServiceEf) HttpContext.Session.GetObject(ScoreSessionKey);
            var points = (int) HttpContext.Session.GetObject("points");
            var debug = points;
            return new Connect4Model{ ScoreService = scoreService, Playfield = playfield, Points = points};
        }

        public IActionResult NewGame()
        {
            HttpContext.Session.SetObject(FieldSessionKey, new Playfield(7,6));
            return View("Index", CreateModel());
        }

        public IActionResult Add(string name)
        {
            if(name.Equals("Your name"))
                return View("Index", CreateModel());
            var scoreService = (ScoreServiceEf)HttpContext.Session.GetObject(ScoreSessionKey);
            var points = (int)HttpContext.Session.GetObject("points");
            scoreService.AddScore(new Score{PlayedAt = DateTime.Now, Player = name, Points = points});
            return View("Index", CreateModel());
        }

        
    }
}

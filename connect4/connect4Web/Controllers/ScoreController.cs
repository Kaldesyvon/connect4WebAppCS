using Microsoft.AspNetCore.Mvc;
using System;
using connect4Core.Entity;
using connect4Core.Service;
using Microsoft.AspNetCore.Http;

namespace connect4Web.Controllers
{
    public class ScoreController : Controller
    {
        private const string ScoreSessionKey = "score";
        public IActionResult Index()
        {
            var scoreService = new ScoreServiceEf();
            HttpContext.Session.SetObject(ScoreSessionKey, scoreService);

            return View("Index", scoreService);
        }

        public IActionResult Add(Score score)
        {
            var scoreService = (ScoreServiceEf)HttpContext.Session.GetObject(ScoreSessionKey);
            score.PlayedAt = DateTime.Now;
            scoreService.AddScore(score);

            return View("Index", scoreService);
        }
    }
}

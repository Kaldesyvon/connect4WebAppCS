using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using connect4Core.Entity;
using connect4Core.Service;

namespace connect4Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService = new ScoreServiceEF();

        [HttpPost]
        public void AddScore(Score score)
        {
            _scoreService.AddScore(score);
        }

        [HttpGet]       
        public IEnumerable<Score> GetScores()
        {
            return _scoreService.GetTopScores();
        }
    }
}

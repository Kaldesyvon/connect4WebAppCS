using connect4Core.Core;
using Microsoft.AspNetCore.Mvc;
using connect4Core.Entity;
using connect4Core.Service;

namespace connect4Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService = new RatingServiceEF();

        [HttpPost]
        public void AddRating(Rating rating)
        {
            _ratingService.AddRating(rating);
        }

        [HttpGet]
        [Route("{player}")]
        public int GetRating(string player)
        {
            return _ratingService.GetRating(player);
        }

        [HttpGet]
        [Route("average")]
        public double GetAverageRating()
        {
            return _ratingService.GetAverageRating();
        }
    }
}

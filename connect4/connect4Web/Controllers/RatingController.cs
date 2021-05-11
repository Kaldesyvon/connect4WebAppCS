using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using connect4Core.Entity;
using connect4Core.Service;
using Microsoft.AspNetCore.Http;

namespace connect4Web.Controllers
{
    public class RatingController : Controller
    {
        private const string RatingSessionKey = "rating";
        public IActionResult Index()
        {
            var ratingService = new RatingServiceEf();
            HttpContext.Session.SetObject(RatingSessionKey, ratingService);

            return View("Index", ratingService);
        }

        public IActionResult Add(Rating rating)
        {
            var ratingService = (RatingServiceEf)HttpContext.Session.GetObject(RatingSessionKey);
            rating.RatedAt = DateTime.Now;
            ratingService.AddRating(rating);

            return View("Index", ratingService);
        }
    }
}

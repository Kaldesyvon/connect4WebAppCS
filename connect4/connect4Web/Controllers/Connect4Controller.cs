using Microsoft.AspNetCore.Mvc;
using connect4Core.Core;
using connect4Core.Service;
using connect4Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace connect4Web.Controllers
{
    public class Connect4Controller : Controller
    {
        private const string FieldSessionKey = "field";

        public IActionResult Index()
        {
            var playfield = new Playfield(7, 6);
            HttpContext.Session.SetObject(FieldSessionKey, playfield);


            return View("Index", playfield);
        }

        public IActionResult AddStone(int column)
        {
            var playfield = (Playfield)HttpContext.Session.GetObject(FieldSessionKey);
            playfield?.AddStone(column, Color.Red);
            HttpContext.Session.SetObject(FieldSessionKey, playfield);
            return View("Index", playfield);
        }
    }
}

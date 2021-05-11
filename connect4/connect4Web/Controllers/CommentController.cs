using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connect4Core.Entity;
using connect4Core.Service;
using connect4Web.Models;
using Microsoft.AspNetCore.Http;

namespace connect4Web.Controllers
{
    public class CommentController : Controller
    {
        private const string CommentSessionKey = "comment";

        public IActionResult Index()
        {
            var commentService = new CommentServiceEf();
            HttpContext.Session.SetObject(CommentSessionKey, commentService);

            return View("Index", commentService);
        }

        public IActionResult AddComment(Comment comment)
        {
            var commentService = (CommentServiceEf)HttpContext.Session.GetObject(CommentSessionKey);
            comment.CommentedAt = DateTime.Now;
            commentService.AddComment(comment);

            return View("Index", commentService);
        }
    }
}

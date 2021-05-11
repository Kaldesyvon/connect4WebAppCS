using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using connect4Core.Entity;
using connect4Core.Service;

namespace connect4Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService = new CommentServiceEf();

        [HttpPost]
        public void AddScore(Comment comment)
        {
            _commentService.AddComment(comment);
        }

        [HttpGet]
        public IEnumerable<Comment> GetScores()
        {
            return _commentService.GetComments();
        }
    }
}

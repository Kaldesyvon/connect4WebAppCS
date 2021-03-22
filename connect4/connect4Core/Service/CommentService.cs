using System;
using System.Collections.Generic;
using System.Linq;

using connect4Core.Entity;

namespace connect4Core.Service
{
    public class CommentService : ICommentService
    {
        private readonly IList<Comment> _comments = new List<Comment>();

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public IList<Comment> GetComments()
        {
            return _comments.OrderBy(o => o.Player).ToList();
        }

        public void Reset()
        {
            _comments.Clear();
        }
    }
}

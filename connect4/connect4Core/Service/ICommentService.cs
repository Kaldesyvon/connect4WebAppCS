using System.Collections.Generic;
using connect4Core.Entity;

namespace connect4Core.Service
{
    public interface ICommentService
    {
        void AddComment(Comment comment);

        IList<Comment> GetComments();

        void Reset();
    }
}

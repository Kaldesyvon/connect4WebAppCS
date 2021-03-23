using System.Collections.Generic;
using System.Linq;

using connect4Core.Entity;

namespace connect4Core.Service
{
    public class CommentServiceFile : ICommentService
    {
        private readonly IList<Comment> _comments = new List<Comment>();

        /// <summary>
        /// Adds a comment to list of comments.
        /// </summary>
        /// <param name="comment">Actual comment.</param>
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        /// <summary>
        /// Getter for list of comments.
        /// </summary>
        /// <returns>List of comments which are in alphabetical order by player.</returns>
        public IList<Comment> GetComments()
        {
            return _comments.OrderBy(o => o.Player).ToList();
        }

        /// <summary>
        /// Clears list of comments.
        /// </summary>
        public void Reset()
        {
            _comments.Clear();
        }
    }
}

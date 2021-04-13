using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using connect4Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace connect4Core.Service
{
    public class CommentServiceEF : ICommentService
    {
        public void AddComment(Comment comment)
        {
            using var context = new Connect4DbContext();
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public IList<Comment> GetComments()
        {
            using var context = new Connect4DbContext();
            return (from c in context.Comments orderby c.CommentedAt descending select c).Take(10).ToList();
        }

        public void Reset()
        {
            using var context = new Connect4DbContext();
            context.Database.ExecuteSqlRaw("truncate table Comments");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connect4Core.Entity;

namespace connect4Web.Models
{
    public class RatingCommentModel
    {
        public IList<Rating> Ratings { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}

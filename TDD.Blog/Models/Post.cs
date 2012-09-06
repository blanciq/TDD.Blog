using System.Collections.Generic;

namespace TDD.Blog.Models
{
    public class Post
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using TDD.Blog.Infrastructure;
using TDD.Blog.Models;

namespace TDD.Blog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static readonly BlogDbContext Context = new BlogDbContext();
            
        public IEnumerable<Post> GetAllPost()
        {
            return Context.Posts.ToList();
        }

        public Post Get(long id)
        {
            return Context.Posts.Find(id);
        }

        public IEnumerable<Comment> GetCommentsFor(long postid)
        {
            return Context.Comments.Where(x => x.PostId == postid).ToList();
        }

        public void AddComment(Comment comment)
        {
            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
    }
}
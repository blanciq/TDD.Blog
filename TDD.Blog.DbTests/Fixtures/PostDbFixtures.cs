using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using TDD.Blog.Infrastructure;
using TDD.Blog.Models;
using System.Data.Entity.Migrations;
using TDD.DbTestHelpers;
using TDD.DbTestHelpers.Core;

namespace TDD.Blog.DbTests.Fixtures
{
    public sealed class PostDbFixtures : DbFixture<BlogDbContext>
    {
        public PostDbFixtures()
        {
            RefillBeforeEachTest = false;
            UseTransactionScope = true;
        }

        public override void PrepareDatabase()
        {
            Context.Posts.ToList().ForEach(x => Context.Posts.Remove(x));
            Context.Comments.ToList().ForEach(x => Context.Comments.Remove(x));
            Context.SaveChanges();
        }

        public override void FillFixtures()
        {
            var post = new Post {Title = "First post"};
            var comment = new Comment {Author = "ja"};
            post.Comments = new List<Comment> { comment };
            Context.Posts.Add(post);
            Context.Posts.Add(new Post { Title = "Second post" });
            Context.SaveChanges();
        }
    }
}

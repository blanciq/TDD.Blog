using TDD.Blog.Infrastructure;
using TDD.Blog.Models;

namespace TDD.Blog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogDbContext context)
        {
            context.Posts.AddOrUpdate(x => x.Title, new Post { Title = "First post"}, new Post { Title = "Second posts"});
        }
    }
}

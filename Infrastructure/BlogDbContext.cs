using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TDD.Blog.Models;

namespace TDD.Blog.Infrastructure
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogDbContext()
            : base(ConfigurationManager.ConnectionStrings["TDDBlog"] != null ? ConfigurationManager.ConnectionStrings["TDDBlog"].ConnectionString : "name=TEST")
        {
        }
    }
}
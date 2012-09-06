using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD.Blog.Models;
using TDD.DbTestHelpers.Yaml;

namespace TDD.Blog.DbTests.Fixtures
{
    public class YamlFixtureModel
    {
        public FixtureTable<Post> Posts { get; set; }
        public FixtureTable<Comment> Comments { get; set; }
    }
}

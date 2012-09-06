using TDD.Blog.Models;
using TDD.DbTestHelpers.Yaml;

namespace TDD.Blog.FunctionalTests.Fixtures
{
    public class YamlFixtureModel
    {
        public FixtureTable<Post> Posts { get; set; }
//        public FixtureTable<Comment> Comments { get; set; }
    }
}

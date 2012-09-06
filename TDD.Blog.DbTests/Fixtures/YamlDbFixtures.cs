using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TDD.Blog.Infrastructure;
using TDD.Blog.Models;
using TDD.DbTestHelpers;
using TDD.DbTestHelpers.EF;
using TDD.DbTestHelpers.Yaml;

namespace TDD.Blog.DbTests.Fixtures
{
    public class YamlDbFixtures : YamlDbFixture<BlogDbContext, YamlFixtureModel>
    {
        public YamlDbFixtures()
        {
            UseTransactionScope = true;
            SetYamlFiles("posts.yaml", "comments.yaml");
        }
    }
}

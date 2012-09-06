using System.Linq;
using NUnit.Framework;
using TDD.Blog.DbTests.Fixtures;
using TDD.Blog.Models;
using TDD.Blog.Repositories;
using TDD.DbTestHelpers;
using TDD.DbTestHelpers.Core;

namespace TDD.Blog.DbTests
{
    [TestFixture]
    public class PostRepositoryTests : DbBaseTest<YamlDbFixtures>
    {
        private PostRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new PostRepository();
        }

        [Test]
        public void GetAllPosts_ShouldReturnTwoPosts()
        {
            var result = _repository.GetAllPost();

            Assert.AreEqual(2, result.Count());
        }


        [Test]
        public void AddComment_TwoPostAlready_ShouldReturnOneMoreAfterAdd()
        {
            var post = _repository.GetAllPost().FirstOrDefault(x => x.Title == "My first post from YAML");
            var commentsFor = _repository.GetCommentsFor(post.PostId);

            _repository.AddComment(new Comment() {Post = post, PostId = post.PostId});

            var commentsForAfter = _repository.GetCommentsFor(post.PostId);
            Assert.AreEqual(commentsFor.Count() + 1, commentsForAfter.Count());
        }

        [Test]
        public void GetAllComments_ForFirstPost_ShouldReturnTwoComments()
        {
            var post = _repository.GetAllPost().FirstOrDefault(x => x.Title == "My first post from YAML");

            var commentsFor = _repository.GetCommentsFor(post.PostId);

            Assert.AreEqual(2, commentsFor.Count());
        }
    }
}

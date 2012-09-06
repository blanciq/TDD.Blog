using System.Web;
using System.Web.Mvc;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Rhino.Mocks;
using TDD.Blog.Controllers;
using TDD.Blog.Infrastructure;
using TDD.Blog.Models;
using TDD.Blog.Repositories;
using TDD.Blog.ViewModel;

namespace TDD.Blog.Tests.Controllers
{
    [TestFixture]
    class PostControlleTests
    {
        private PostController _sut;
        private IPostRepository _repository;

        [SetUp]
        public void Before()
        {
            AutomapperConfiguration.Configure();
            _repository = MockRepository.GenerateStub<IPostRepository>();
            _sut = new PostController(_repository, new AutomapperWrapper());
        }

        [Test]
        [ExpectedException(typeof(HttpException))]
        public void Details_PostDontExists_ShouldReturn404()
        {
            var result = _sut.Details(0);
        }

        [Test]
        public void Details_PostExists_ShouldReturnModelWithPostTitle()
        {
            var post = new Fixture().Build<Post>().With(x => x.PostId, 1).Without(x => x.Comments).CreateAnonymous();
            _repository.Stub(x => x.Get(post.PostId)).Return(post);

            var result = _sut.Details(post.PostId) as ViewResult;

            Assert.AreEqual(post.Title, ((PostViewModel)(result.Model)).Title);
        }

    }
}

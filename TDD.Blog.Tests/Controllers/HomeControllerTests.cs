using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using TDD.Blog.Controllers;
using TDD.Blog.Infrastructure;
using TDD.Blog.Models;
using TDD.Blog.Repositories;
using TDD.Blog.ViewModel;

namespace TDD.Blog.Tests.Controllers
{
    [TestFixture]
    class HomeControllerTests
    {
        private HomeController _sut;
        private IPostRepository _postRepository;

        [SetUp]
        public void Before()
        {
            var builder = new TestControllerBuilder();
            _postRepository = MockRepository.GenerateStub<IPostRepository>();
            _postRepository.Stub(x => x.GetAllPost()).Return(new List<Post>());
            // using real automapper
            AutomapperConfiguration.Configure();

            _sut = new HomeController(_postRepository, new AutomapperWrapper());
            builder.InitializeController(_sut);
        }

        [Test]
        public void Index_ShouldReturnIndexView()
        {
            var result = _sut.Index();
            
            result.AssertViewRendered().ForView("");
        }

        [Test]
        public void Index_ZeroPosts_ShouldReturnModelWithEmptyList()
        {

            var result = _sut.Index() as ViewResult;

            var model = result.Model as HomePageViewModel;
            Assert.AreEqual(0, model.Posts.Count());
        }

        [Test]
        public void Index_TwoPosts_ShouldReturnModelWithTwoPosts()
        {
// The same as Repeat.Any()
//            _postRepository.BackToRecord();
//            _postRepository.Replay();
            _postRepository.Stub(x => x.GetAllPost()).Return(new List<Post> {new Post(), new Post()})
                .Repeat.Any();

            var result = _sut.Index() as ViewResult;

            var model = result.ViewData.Model as HomePageViewModel;
            Assert.AreEqual(2, model.Posts.Count());
        }

        [Test]
        public void Index_FirstEntry_ShouldReturnOneInShown()
        {
            var result = _sut.Index() as ViewResult;

            var model = result.Model as HomePageViewModel;
            Assert.AreEqual(1, model.Visits);
        }

        [Test]
        public void Index_FirstEntry_ShouldAddVisitsToSessionWithOne()
        {
            var result = _sut.Index() as ViewResult;

            Assert.AreEqual(1, _sut.Session["visits"]);
        }


        [Test]
        public void Index_FifthEntry_ShouldReturnFifthInShown()
        {
            _sut.Session["visits"] = 4;

            var result = _sut.Index() as ViewResult;

            var model = result.Model as HomePageViewModel;
            Assert.AreEqual(5, model.Visits);
        }

        [Test]
        public void Index_FifthEntry_ShouldAddFiveToSession()
        {
            _sut.Session["visits"] = 4;

            _sut.Index();

            Assert.AreEqual(5, _sut.Session["visits"]);
        }



    }
}

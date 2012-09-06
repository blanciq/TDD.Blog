using System.IO;
using System.Web;
using Castle.Windsor;
using NUnit.Framework;
using TDD.Blog.Controllers;
using TDD.Blog.Infrastructure;
using TDD.Blog.Repositories;

namespace TDD.Blog.Tests
{
    [TestFixture]
    class WindsorTests
    {
        private WindsorContainer _container;

        [TestFixtureSetUp]
        public void Register()
        {
            _container = new WindsorContainer();
            _container.Kernel.ComponentModelBuilder.AddContributor(new TransientLifeStyle());
            _container.Install(new WindsorInstaller());

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter())
                );
        }

        [Test]
        public void Resolve_HomeController()
        {
            Assert.IsNotNull(_container.Resolve<HomeController>());
        }

        [Test]
        public void Resolve_PostController()
        {
            Assert.IsNotNull(_container.Resolve<PostController>());
        }

        [Test]
        public void Resolve_PostRepository()
        {
            Assert.IsNotNull(_container.Resolve<IPostRepository>());
        }
    }
}

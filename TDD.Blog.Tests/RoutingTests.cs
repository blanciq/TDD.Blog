using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using TDD.Blog.Controllers;

namespace TDD.Blog.Tests
{
    [TestFixture]
    public class RoutingTests
    {
        [TestFixtureSetUp]
        public void RegisterRoutes()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void RootUrl_Home_Index()
        {
            "~/".ShouldMapTo<HomeController>(action => action.Index());
        }

        [Test]
        public void PostDetails_Post_Details_WithProperId()
        {
            "~/post/show/12".ShouldMapTo<PostController>(action => action.Details(12));
        }

        [Test]
        public void Month_Post_Month_WithProperMonth()
        {
            var builder = new TestControllerBuilder();
            builder.AppRelativeCurrentExecutionFilePath = "~/posts/january";

            var result = RouteTable.Routes.GetRouteData(builder.HttpContext);

            RoutesAsserts.ConntrollerAndActionAre(result.Values, "Post", "Month");
            Assert.AreEqual("january", result.Values["month"]);

            // doesn't work with model binder
            //"~/posts/january".ShouldMapTo<PostController>(action => action.Month(Month.January));
        }


        [Test]
        public void NotFound_Home_NotFound()
        {
            "~/not-found".ShouldMapTo<HomeController>(action => action.NotFound());
        }
    }

    public static class RoutesAsserts
    {
        public static void ConntrollerAndActionAre(RouteValueDictionary values, string controllerName, string actionName)
        {
            Assert.AreEqual(controllerName, values["controller"]);
            Assert.AreEqual(actionName, values["action"]);
        }
    }

}

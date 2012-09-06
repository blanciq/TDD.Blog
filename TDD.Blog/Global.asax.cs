using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Castle.Windsor;
using TDD.Blog.Infrastructure;

namespace TDD.Blog
{
    public class MvcApplication : HttpApplication
    {
        private readonly WindsorContainer _applicationWideWindsorContainer = new WindsorContainer();

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "NotFound",
                "not-found",
                new {controller = "Home", action = "NotFound"}
                );

            routes.MapRoute(
                "Details",
                "post/show/{id}",
                new {controller = "Post", action = "Details"}
                );

            routes.MapRoute(
                "Month",
                "posts/{month}",
                new {controller = "Post", action = "Month"});

            routes.MapRoute(
                "Homepage",
                "",
                new {controller = "Home", action = "Index"} // Parameter defaults
                );

            routes.MapRoute( // for actions
                "Default",
                "{controller}/{action}",
                new {  } // Parameter defaults
                );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            _applicationWideWindsorContainer.Install(new WindsorInstaller());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_applicationWideWindsorContainer));

            AutomapperConfiguration.Configure();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
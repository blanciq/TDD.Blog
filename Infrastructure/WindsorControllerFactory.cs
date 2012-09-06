using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace TDD.Blog.Infrastructure
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _windsorContainer;

        public WindsorControllerFactory(WindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return _windsorContainer.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;
            if (disposableController != null)
            {
                disposableController.Dispose();
            }

            _windsorContainer.Release(controller);
        }
    }
}
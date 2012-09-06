using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TDD.Blog.Repositories;

namespace TDD.Blog.Infrastructure
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromThisAssembly()
                    .BasedOn<Controller>()
                    .LifestyleTransient()
                );

            RegisterRepositories(container);
        }

        private void RegisterRepositories(IWindsorContainer container)
        {
            container.Register(
                Component.For<IPostRepository>().ImplementedBy<PostRepository>());
            container.Register(
                Component.For<AutomapperWrapper>().UsingFactoryMethod(() => new AutomapperWrapper()));
        }
    }
}
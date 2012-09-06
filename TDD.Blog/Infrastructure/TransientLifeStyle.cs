using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;

namespace TDD.Blog.Infrastructure
{
    public class TransientLifeStyle : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            model.LifestyleType = LifestyleType.Transient;
        }
    }
}
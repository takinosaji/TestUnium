using System;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using TestUnium.Core;

namespace TestUnium.Internal.Services.Implementations
{
    public class NinjectionService : IInjectionService
    {
        public void Inject(Action<IWindsorContainer> injections, params IWindsorContainer[] containers)
        {
            foreach (var container in containers)
            {
                injections(container);
            }
        }

        public IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();
          
            return container;
        }      
    }
}

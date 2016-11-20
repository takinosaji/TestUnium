using System;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using TestUnium.Core;
using TestUnium.Extensions.Ninject;

namespace TestUnium.Internal.Services.Implementations
{
    public class NinjectionService : IInjectionService
    {
        public void Inject(Action<IWindsorContainer> injections, params IWindsorContainer[] kernels)
        {
            foreach (var kernel in kernels)
            {
                injections(kernel);
            }
        }

        public IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();
          
            return container;
        }      
    }
}

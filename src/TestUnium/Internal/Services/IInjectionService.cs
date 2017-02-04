using System;
using Castle.Windsor;
using TestUnium.Core;

namespace TestUnium.Internal.Services
{
    public interface IInjectionService
    {
        void Inject(Action<IWindsorContainer> injections, params IWindsorContainer[] containers);

        IWindsorContainer CreateContainer();
    }
}
using System;
using Castle.Windsor;
using TestUnium.Core;
using TestUnium.Extensions.Ninject;

namespace TestUnium.Internal.Services
{
    public interface IInjectionService
    {
        void Inject(Action<IWindsorContainer> injections, params IWindsorContainer[] kernels);

        IWindsorContainer CreateContainer();
    }
}
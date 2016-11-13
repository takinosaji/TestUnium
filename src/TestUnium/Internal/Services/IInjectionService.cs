using System;
using Ninject;
using TestUnium.Core;
using TestUnium.Extensions.Ninject;

namespace TestUnium.Internal.Services
{
    public interface IInjectionService
    {
        void Inject(Action<IKernel> injections, params IKernel[] kernels);

        IKernel CreateKernel();
    }
}
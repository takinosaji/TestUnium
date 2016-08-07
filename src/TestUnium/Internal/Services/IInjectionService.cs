using System;
using Ninject;

namespace TestUnium.Internal.Services
{
    public interface IInjectionService
    {
        void Inject(Action<IKernel> injections, params IKernel[] kernels);

        IKernel CreateKernel();
    }
}
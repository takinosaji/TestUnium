using System;
using Ninject;
using Ninject.Extensions.ChildKernel;

namespace TestUnium.Common
{
    public static class InjectionHelper
    {
        public static void Inject(Action<IKernel> injections, params IKernel[] kernels)
        {
            foreach (var kernel in kernels)
            {
                injections(kernel);
            }
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new NinjectSettings
            {
                InjectNonPublic = true
            });

            return kernel;
        }

        public static IKernel CreateChildKernel(IKernel parentKernel)
        {
            var kernel = new ChildKernel(parentKernel, new NinjectSettings
            {
                InjectNonPublic = true
            });

            return kernel;
        }
    }
}

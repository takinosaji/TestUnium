﻿using System;
using Ninject;

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

        public static StandardKernel CreateKernel(Boolean selfBindable = false)
        {
            var kernel = new StandardKernel(new NinjectSettings
            {
                InjectNonPublic = true
            });
            if (selfBindable)
            {
                kernel.Bind<IKernel>().ToConstant(kernel);
            }

            return kernel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace TestUnium.Core
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

        public static StandardKernel CreateKernel()
        {
            return new StandardKernel(new NinjectSettings
            {
                InjectNonPublic = true
            });
        }
    }
}

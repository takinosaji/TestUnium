using Ninject;
using TestUnium.Common;

namespace TestUnium.Core
{
    public class KernelDrivenTest
    {
        protected IKernel Kernel;
        protected KernelDrivenTest()
        {
            Kernel = InjectionHelper.CreateKernel();
            Kernel.Bind<IKernel>().ToConstant(Kernel);
            Kernel.Bind<KernelDrivenTest>().ToConstant(this);
        }
    }
}

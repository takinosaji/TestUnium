using Ninject;
using TestUnium.Common;

namespace TestUnium.Core
{
    public class KernelDrivenTest
    {
        public IKernel Kernel;
        protected KernelDrivenTest()
        {
            Kernel = InjectionHelper.CreateKernel();
            Kernel.Bind<IKernel>().ToConstant(Kernel);
            Kernel.Bind<KernelDrivenTest>().ToConstant(this);
        }
    }
}

using Ninject;
using TestUnium.Common;

namespace TestUnium.Instantiation.Core
{
    public class KernelDrivenTest : IKernelDrivenTest
    {
        public IKernel Kernel { get; set; }
        protected KernelDrivenTest()
        {
            Kernel = InjectionHelper.CreateKernel();
            Kernel.Bind<IKernelDrivenTest>().ToConstant(this);
        }
    }
}

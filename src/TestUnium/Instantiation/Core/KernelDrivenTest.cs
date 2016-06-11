using Ninject;
using TestUnium.Bootstrapping;
using TestUnium.Common;
using TestUnium.Instantiation.Stepping;

namespace TestUnium.Instantiation.Core
{
    public class KernelDrivenTest : IKernelDrivenTest
    {
        public IKernel Kernel { get; set; }
        protected KernelDrivenTest()
        {
            Kernel = InjectionHelper.CreateKernel();
            Resolver.Instance.Kernel = Kernel;

            Kernel.Bind<IKernelDrivenTest>().ToConstant(this);
            Kernel.Bind<IStepModuleRegistrationStrategy>().To<BasicStepModuleRegistrationStrategy>();
        }
    }
}

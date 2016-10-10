using Ninject;
using Ninject.Parameters;
using TestUnium.Internal;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;
using TestUnium.Stepping;
using TestUnium.Stepping.Modules;

namespace TestUnium.Core
{
    public class KernelDrivenTest : IKernelDrivenTest
    {
        public IKernel Kernel { get; set; }

        protected readonly IInjectionService InjectionService;

        protected KernelDrivenTest()
        {
            InjectionService = Container.Instance.Kernel.Get<IInjectionService>();

            Kernel = InjectionService.CreateKernel();
            Resolver.Instance.Kernel = Kernel;

            Kernel.Bind<IKernelDrivenTest>().ToConstant(this);
            Kernel.Bind<IStepModuleRegistrationStrategy>().To<BasicStepModuleRegistrationStrategy>();
        }

        public IParameter GetKernelConstructorArg()
        {
            return new ConstructorArgument("kernel", Kernel);
        }
    }
}

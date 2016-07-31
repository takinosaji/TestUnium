using Ninject;
using Ninject.Parameters;
using TestUnium.Bootstrapping;
using TestUnium.Domain;
using TestUnium.Global;
using TestUnium.Instantiation.Stepping;
using TestUnium.Services;
using TestUnium.Services.Implementations;

namespace TestUnium.Instantiation.Core
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

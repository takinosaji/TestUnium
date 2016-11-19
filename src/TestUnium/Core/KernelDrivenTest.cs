using Ninject;
using Ninject.Parameters;
using TestUnium.Customization;
using TestUnium.Extensions.Ninject;
using TestUnium.Internal;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;

namespace TestUnium.Core
{
    public class KernelDrivenTest : CustomizationAttributeDrivenTest, IKernelDrivenTest
    {
        public IKernel Kernel { get; set; }

        protected readonly IInjectionService InjectionService;

        protected KernelDrivenTest()
        {
            ApplyCustomization(typeof(KernelDrivenTest));

            InjectionService = Container.Instance.Current.Get<IInjectionService>();

            if (Kernel == null)
            {
                Kernel = InjectionService.CreateKernel();
            }
            Resolver.Instance.Kernel = Kernel;

            Kernel.Bind<ICustomizationAttributeDrivenTest>().ToConstant(this);
            Kernel.Bind<IKernelDrivenTest>().ToConstant(this);
        }

        public IParameter GetKernelConstructorArg()
        {
            return new ConstructorArgument("kernel", Kernel);
        }
    }
}

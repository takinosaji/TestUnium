using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TestUnium.Customization;
using TestUnium.Extensions.Ninject;
using TestUnium.Internal;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;

namespace TestUnium.Core
{
    public class ContainerDrivenTest : CustomizationAttributeDrivenTest, IContainerDrivenTest
    {
        public IWindsorContainer Container { get; set; }

        protected readonly IInjectionService InjectionService;

        protected ContainerDrivenTest()
        {
            ApplyCustomization(typeof(ContainerDrivenTest));

            InjectionService = CoreContainer.Instance.Current.Resolve<IInjectionService>();

            if (Container == null)
            {
                Container = InjectionService.CreateContainer();
            }
            Resolver.Instance.CurrentContainer = Container;

            Container.Register(Component.For<ICustomizationAttributeDrivenTest>().Instance(this).Named("ICustomizationAttributeDrivenTest"));
            Container.Register(Component.For<IContainerDrivenTest>().Instance(this).Named("IContainerDrivenTest"));
        }
    }
}

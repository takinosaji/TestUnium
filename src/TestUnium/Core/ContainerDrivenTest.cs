using Castle.Windsor;
using TestUnium.Customization;
using TestUnium.Internal;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Bootstrapping.Castle;
using TestUnium.Internal.Services;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using Component = Castle.MicroKernel.Registration.Component;

namespace TestUnium.Core
{
    public class ContainerDrivenTest : CustomizationAttributeDrivenTest, IContainerDrivenTest
    {
        public IWindsorContainer Container { get; set; }

        protected readonly IInjectionService InjectionService;

        protected ContainerDrivenTest()
        {
            InjectionService = CoreContainer.Instance.Current.Resolve<IInjectionService>();

            ApplyCustomization(typeof(IContainerDrivenTest));
            if (Container == null)
            {
                Container = InjectionService.CreateContainer();
            }
            Resolver.Instance.CurrentContainer = Container;

            Container.Register(Component.For<ICustomizationAttributeDrivenTest>().Instance(this).Named("ICustomizationAttributeDrivenTest"));
            Container.Register(Component.For<IWindsorContainer>().Instance(Container).Named("IWindsorContainer"));
            Container.Register(Component.For<IContainerDrivenTest>().Instance(this).Named("IContainerDrivenTest"));
        }
    }
}

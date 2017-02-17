using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TestUnium.Selenium.WebDriving.Screenshots;

namespace TestUnium.Selenium.Internal.Bootstrapping.Modules
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMakeScreenshotStrategy>().ImplementedBy<DefaultMakeScreenshotStrategy>().LifestyleSingleton());
        }
    }
}

using Ninject.Modules;
using TestUnium.Internal.Services;
using TestUnium.Internal.Services.Implementations;
using TestUnium.Selenium.WebDriving;
using TestUnium.Selenium.WebDriving.Screenshots;
using TestUnium.Sessioning.Managing;

namespace TestUnium.Selenium.Internal.Bootstrapping.Modules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMakeScreenshotStrategy>().To<DefaultMakeScreenshotStrategy>().InSingletonScope();
        }
    }
}

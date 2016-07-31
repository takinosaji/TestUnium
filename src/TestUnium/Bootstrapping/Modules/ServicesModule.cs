using Ninject.Modules;
using TestUnium.Services;
using TestUnium.Services.Implementations;

namespace TestUnium.Bootstrapping.Modules
{
    class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IShellService>().To<ShellService>().InSingletonScope();
            Bind<IInjectionService>().To<NinjectionService>().InSingletonScope();
        }
    }
}

using Ninject.Modules;
using TestUnium.Internal.Services;
using TestUnium.Internal.Services.Implementations;
using TestUnium.Sessioning.Managing;

namespace TestUnium.Internal.Bootstrapping.Modules
{
    class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IShellService>().To<ShellService>().InSingletonScope();
            Bind<IInjectionService>().To<NinjectionService>().InSingletonScope();
            Bind<ISessionManagingService>().To<SessionManagingService>().InSingletonScope();
        }
    }
}

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TestUnium.Internal.Services;
using TestUnium.Internal.Services.Implementations;
using TestUnium.Sessioning.Managing;

namespace TestUnium.Internal.Bootstrapping.Modules
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IShellService>().ImplementedBy<ShellService>().LifestyleSingleton());
            container.Register(Component.For<IInjectionService>().ImplementedBy<NinjectionService>().LifestyleSingleton());
            container.Register(Component.For<ISessionManagingService>().ImplementedBy<SessionManagingService>().LifestyleSingleton());
            container.Register(Component.For<IReflectionService>().ImplementedBy<ReflectionService>().LifestyleSingleton());
        }
    }
}

using Castle.Windsor;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;

namespace TestUnium.Core.Configuration
{
    public class StandardContainerConfigurer : IContainerConfigurer
    {
        private readonly IInjectionService _injectionService;

        public StandardContainerConfigurer()
        {
            _injectionService = CoreContainer.Instance.Current.Resolve<IInjectionService>();
        }

        public IWindsorContainer GetContainer()
        {
            return _injectionService.CreateContainer();
        }
    }
}
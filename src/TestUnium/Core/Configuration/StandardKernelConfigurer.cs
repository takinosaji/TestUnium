using Ninject;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;

namespace TestUnium.Core.Configuration
{
    public class StandardKernelConfigurer : IKernelConfigurer
    {
        private readonly IInjectionService _injectionService;

        public StandardKernelConfigurer()
        {
            _injectionService = Container.Instance.Current.Get<IInjectionService>();
        }

        public IKernel GetKernel()
        {
            return _injectionService.CreateKernel();
        }
    }
}
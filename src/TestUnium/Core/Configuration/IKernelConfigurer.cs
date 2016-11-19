using Ninject;

namespace TestUnium.Core.Configuration
{
    public interface IKernelConfigurer
    {
        IKernel GetKernel();
    }
}
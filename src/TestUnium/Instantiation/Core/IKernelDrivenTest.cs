using Ninject;

namespace TestUnium.Instantiation.Core
{
    public interface IKernelDrivenTest
    {
        IKernel Kernel { get; set; }
    }
}
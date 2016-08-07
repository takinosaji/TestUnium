using Ninject;
using Ninject.Parameters;

namespace TestUnium.Core
{
    public interface IKernelDrivenTest
    {
        IKernel Kernel { get; set; }

        IParameter GetKernelConstructorArg();
    }
}
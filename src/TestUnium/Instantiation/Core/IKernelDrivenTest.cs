using Ninject;
using Ninject.Parameters;

namespace TestUnium.Instantiation.Core
{
    public interface IKernelDrivenTest
    {
        IKernel Kernel { get; set; }

        IParameter GetKernelConstructorArg();
    }
}
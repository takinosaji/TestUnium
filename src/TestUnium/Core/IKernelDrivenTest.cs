using Ninject;
using Ninject.Parameters;
using TestUnium.Customization;

namespace TestUnium.Core
{
    public interface IKernelDrivenTest : ICustomizationAttributeDrivenTest
    {
        IKernel Kernel { get; set; }

        IParameter GetKernelConstructorArg();
    }
}
using Ninject;
using TestUnium.Stepping.Steps.Core;

namespace TestUnium.Stepping.Steps.Kernel
{
    public class KernelDrivenStepCore : ExecutableStepCore
    {
        [Inject]
        public IKernel Kernel { get; set; }
    }
}
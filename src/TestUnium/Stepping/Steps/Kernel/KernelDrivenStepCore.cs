using Ninject;

namespace TestUnium.Stepping.Steps.Kernel
{
    public class KernelDrivenStepCore : ExecutableStepCore
    {
        [Inject]
        public IKernel Kernel { get; set; }
    }
}
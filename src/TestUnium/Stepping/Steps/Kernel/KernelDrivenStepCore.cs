using Castle.Windsor;
using TestUnium.Stepping.Steps.Core;

namespace TestUnium.Stepping.Steps.Kernel
{
    public class KernelDrivenStepCore : ExecutableStepCore
    {
        public IWindsorContainer Container { get; set; }
    }
}
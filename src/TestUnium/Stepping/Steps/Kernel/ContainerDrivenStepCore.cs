using Castle.Windsor;
using TestUnium.Stepping.Steps.Core;

namespace TestUnium.Stepping.Steps.Kernel
{
    public class ContainerDrivenStepCore : ExecutableStepCore
    {
        public IWindsorContainer Container { get; set; }
    }
}
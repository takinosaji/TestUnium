using System;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace Steps.Modules
{
    public class ThrowsExceptionModule : IStepModule
    {
        public void BeforeExecution(IStep step)
        {
            throw new InvalidOperationException();
        }

        public void AfterExecution(IStep step, StepState state)
        {
            throw new InvalidOperationException();
        }
    }
}

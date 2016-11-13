using System;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Pipeline.Conditions;
using TestUnium.Stepping.Steps;

namespace Steps.Modules
{
    [TargetStep(typeof(GoToUrlStep))]
    public class ConditionalStepModule : IStepModule
    {
        public void BeforeExecution(IStep step)
        {
            throw new Exception("This shouldn't ever happen!");
        }

        public void AfterExecution(IStep step, StepState state)
        {
            throw new Exception("Big Bang!");
        }
    }
}

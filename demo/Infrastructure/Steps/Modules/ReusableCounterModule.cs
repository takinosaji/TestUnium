using System;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace Steps.Modules
{
    [Reusable]
    public class ReusableCounterModule : IStepModule
    {
        private Int32 PositiveCounter { get; set; }
        private Int32 NegativeCounter { get; set; }
        public void BeforeExecution(IStep step)
        {
            PositiveCounter += 1;
        }

        public void AfterExecution(IStep step, StepState state)
        {
            NegativeCounter = -1;
        }
    }
}

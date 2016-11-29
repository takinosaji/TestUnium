using System;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace Steps.Modules
{
    public class UreusableSessionStepModule : IStepModule
    {
        private Boolean Flag { get; set; }
        public void BeforeExecution(IStep step)
        {
            if(Flag) throw new InvalidOperationException();
            Flag = true;
        }

        public void AfterExecution(IStep step, StepState state)
        {
        }
    }
}

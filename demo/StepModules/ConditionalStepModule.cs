using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StepModules.Conditions;
using Steps;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Pipeline.Conditions;
using TestUnium.Stepping.Steps;

namespace StepModules
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

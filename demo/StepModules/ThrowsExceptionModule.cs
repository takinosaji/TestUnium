using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace StepModules
{
    [Reusable]
    public class ThrowsExceptionModule : IStepModule
    {
        public void BeforeExecution(IStep step)
        {
            throw new InvalidOperationException();
        }

        public void AfterExecution(IStep step, StepExecutionResult result)
        {
            throw new InvalidOperationException();
        }
    }
}

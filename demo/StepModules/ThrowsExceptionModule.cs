using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Stepping;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace StepModules
{
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

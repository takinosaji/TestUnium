using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace StepModules
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

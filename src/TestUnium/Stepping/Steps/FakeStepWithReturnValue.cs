using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnium.Stepping.Steps
{
    public class FakeStepWithReturnValue<TResult> : ExecutableStep, IExecutableStep<TResult>
    {
        public Func<TResult> OperationsWithReturnValue;

        public FakeStepWithReturnValue(Func<TResult> operationsWithReturnValue)
        {
            OperationsWithReturnValue = operationsWithReturnValue;
        }

        TResult IExecutableStep<TResult>.Execute()
        {
            return OperationsWithReturnValue();
        }
    }
}

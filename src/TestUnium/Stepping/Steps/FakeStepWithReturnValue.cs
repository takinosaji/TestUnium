using System;

namespace TestUnium.Stepping.Steps
{
    public class FakeStepWithReturnValue<TResult> : ExecutableStepCore, IExecutableStep<TResult>
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

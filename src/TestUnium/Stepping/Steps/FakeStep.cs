using System;

namespace TestUnium.Stepping.Steps
{
    [FakeStep]
    class FakeStep : ExecutableStepCore, IExecutableStep
    {
        public Action Operations;

        public FakeStep(Action operations)
        {
            Operations = operations;
        }
        public FakeStep()  { }

        public void Execute()
        {
            //Operations?.Invoke();
            Operations();
        }
    }
}

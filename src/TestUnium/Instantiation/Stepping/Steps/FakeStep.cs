using System;

namespace TestUnium.Instantiation.Stepping.Steps
{
    [FakeStep]
    class FakeStep : ExecutableStep, IExecutableStep
    {
        public Action Operations;

        public FakeStep(Action operations)
        {
            Operations = operations;
        }

        public void Execute()
        {
            Operations();
        }
    }
}

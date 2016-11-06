using TestUnium.Stepping.Steps.Settings;

namespace TestUnium.Stepping.Steps.Core
{
    public abstract class ExecutableStep<T> : ExecutableStepCore, IExecutableStep<T>
    {
        public abstract T Execute();
    }

    public abstract class ExecutableStep : ExecutableStepCore, IExecutableStep
    {
        public abstract void Execute();
    }
}

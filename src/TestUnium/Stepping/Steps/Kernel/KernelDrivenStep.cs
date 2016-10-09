namespace TestUnium.Stepping.Steps.Kernel
{
    public abstract class KernelDrivenStep<T> : KernelDrivenStepCore, IExecutableStep<T>
    {
        public abstract T Execute();
    }

    public abstract class KernelDrivenStep : KernelDrivenStepCore, IExecutableStep
    {
        public abstract void Execute();
    }
}

namespace TestUnium.Stepping.Steps.Kernel
{
    public abstract class ContainerDrivenStep<T> : ContainerDrivenStepCore, IExecutableStep<T>
    {
        public abstract T Execute();
    }

    public abstract class ContainerDrivenStep : ContainerDrivenStepCore, IExecutableStep
    {
        public abstract void Execute();
    }
}

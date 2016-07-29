namespace TestUnium.Instantiation.Stepping.Steps
{
    public interface IExecutableStep<out T> : IStep
    {
        T Execute();
    }

    public interface IExecutableStep : IStep
    {
        void Execute();
    }
}
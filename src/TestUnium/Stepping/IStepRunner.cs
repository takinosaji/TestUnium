using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepRunner
    {
        void Run(IExecutableStep step);
        TResult RunWithReturnValue<TResult>(IExecutableStep<TResult> step);
        void BeforeExecution(IStep step);
        void AfterExecution(IStep step, StepExecutionResult result);
        void AddModules(params IStepModule[] modules);
        void RemoveModules(params IStepModule[] modules);
    }
}

using System;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepRunner
    {
        void Run(IExecutableStep step);
        void Run(Action operations);
        TResult RunWithReturnValue<TResult>(IExecutableStep<TResult> step);
        TResult RunWithReturnValue<TResult>(Func<TResult> operationsWithReturnValue);
        void BeforeExecution(IStep step);
        void AfterExecution(IStep step, StepExecutionResult result);
        void RegisterModules(params IStepModule[] modules);
        void UnregisterModules(params IStepModule[] modules);
    }
}

using System;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
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

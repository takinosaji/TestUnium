using System;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
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

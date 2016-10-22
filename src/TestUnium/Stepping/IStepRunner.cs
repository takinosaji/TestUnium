using System;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepRunner
    {
        void Run<TStep>(IStepExecutor executor, TStep step, Action<TStep> stepSetUpAction, StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep) 
            where TStep : IExecutableStep;
        TResult RunWithReturnValue<TStep, TResult>(IStepExecutor executor, TStep step, Action<TStep> stepSetUpAction,
            StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep)
            where TStep : IExecutableStep<TResult>;
        void BeforeExecution(IStep step);
        void AfterExecution(IStep step, StepState state);
        void AddModules(params IStepModule[] modules);
        void RemoveModules(params IStepModule[] modules);
    }
}

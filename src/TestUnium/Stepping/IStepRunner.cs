using System;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepRunner
    {
        void Run<TStep>(IStepExecutor executor, String callingMethodName, TStep step, Action<TStep> stepSetUpAction, StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep) 
            where TStep : IExecutableStep;
        TResult RunWithReturnValue<TStep, TResult>(IStepExecutor executor, String callingMethodName, TStep step, Action<TStep> stepSetUpAction,
            StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep)
            where TStep : IExecutableStep<TResult>;
        void AddModules(params IStepModule[] modules);
        void RemoveModules(params IStepModule[] modules);
    }
}

using System;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepExecutor
    {
        void Do<TStep>(Action<TStep> setSetUpAction = null,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow) where TStep : IExecutableStep;
        void Do<TStep>(StepExceptionHandlingMode exceptionHandlingMode) where TStep : IExecutableStep;

        TResult Do<TStep, TResult>(Action<TStep> setSetUpAction = null,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow) where TStep : IExecutableStep<TResult>;
        TResult Do<TStep, TResult>(StepExceptionHandlingMode exceptionHandlingMode)
            where TStep : IExecutableStep<TResult>;
        void Do(Action outOfStepOperations, StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow);
        TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow);
        TStep GetStep<TStep>(Action<TStep> stepSetupAction = null) where TStep : IStep;
    }
}
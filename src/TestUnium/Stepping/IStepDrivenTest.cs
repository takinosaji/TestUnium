using System;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepDrivenTest
    {
        void Do<TStep>(Action<TStep> setSetUpAction = null,
            StepExceptionMode exceptionHandlingMode = StepExceptionMode.Rethrow) where TStep : IExecutableStep;
        void Do<TStep>(StepExceptionMode exceptionHandlingMode) where TStep : IExecutableStep;

        TResult Do<TStep, TResult>(Action<TStep> setSetUpAction = null,
            StepExceptionMode exceptionHandlingMode = StepExceptionMode.Rethrow) where TStep : IExecutableStep<TResult>;
        TResult Do<TStep, TResult>(StepExceptionMode exceptionHandlingMode)
            where TStep : IExecutableStep<TResult>;
        void Do(Action outOfStepOperations, StepExceptionMode exceptionHandlingMode = StepExceptionMode.Rethrow);
        TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue,
            StepExceptionMode exceptionHandlingMode = StepExceptionMode.Rethrow);
        TStep Fill<TStep>(Action<TStep> stepSetupAction = null) where TStep : IStep;
    }
}
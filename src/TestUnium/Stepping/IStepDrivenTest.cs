using System;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepDrivenTest
    {
        void Do<TStep>(Action<TStep> action) where TStep : IExecutableStep;
        TResult Do<TStep, TResult>(Action<TStep> action) where TStep : IExecutableStep<TResult>;
        void Do(Action outOfStepOperations);
        TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue);
        TStep Fill<TStep>(Action<TStep> stepSetupAction = null) where TStep : IStep;
    }
}
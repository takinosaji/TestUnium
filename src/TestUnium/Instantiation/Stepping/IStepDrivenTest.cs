using System;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
{
    public interface IStepDrivenTest : IStepModuleRegistrator
    {
        void Do<TStep>(Action<TStep> action) where TStep : IExecutableStep;
        TResult Do<TStep, TResult>(Action<TStep> action) where TStep : IExecutableStep<TResult>;
        void Do(Action outOfStepOperations);
        TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue);
        TStep Fill<TStep>(Action<TStep> stepSetupAction = null) where TStep : IStep;
    }
}
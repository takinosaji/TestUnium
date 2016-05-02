using System;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepDrivenTest
    {
        void RegisterStepModule<TStepModule>(Boolean isReusable) where TStepModule : IStepModule;
        void UnregisterStepModule<TStepModule>() where TStepModule : IStepModule;
        void Do<TStep>(Action<TStep> action) where TStep : IExecutableStep;
        TResult Do<TStep, TResult>(Action<TStep> action) where TStep : IExecutableStep<TResult>;
        void Do(Action outOfStepOperations);
        TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue);
    }
}
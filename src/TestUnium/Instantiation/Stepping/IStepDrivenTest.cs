using System;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
{
    public interface IStepDrivenTest : ICustomizationAttributeDrivenTest
    {
        void RegisterStepModule<TStepModule>(Boolean isReusable) where TStepModule : IStepModule;
        void RegisterStepModules(Boolean isReusable, params Type[] moduleTypes);
        void UnregisterStepModule<TStepModule>() where TStepModule : IStepModule;
        void UnregisterStepModules(params Type[] moduleTypes);
        void Do<TStep>(Action<TStep> action) where TStep : IExecutableStep;
        TResult Do<TStep, TResult>(Action<TStep> action) where TStep : IExecutableStep<TResult>;
        void Do(Action outOfStepOperations);
        TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue);
    }
}
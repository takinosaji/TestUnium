using System;
using Ninject;
using TestUnium.Sessioning;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public class StepDrivenTest : SessionDrivenTest, IStepDrivenTest, IStepModuleRegistrator
    {
        private readonly IStepModuleRegistrationStrategy _moduleRegistrationStrategy;
        public StepDrivenTest()
        {
            _moduleRegistrationStrategy = Kernel.Get<IStepModuleRegistrationStrategy>();
            Kernel.Bind<IStepDrivenTest>().ToConstant(this);
        }

        public void RegisterStepModule<TStepModule>(Boolean makeReusable = false) where TStepModule : IStepModule
        {
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, String.Empty, makeReusable, typeof(TStepModule));
        }

        public void RegisterStepModules(params Type[] moduleTypes)
        {
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, String.Empty, false, moduleTypes);
        }
        public void RegisterStepModules(Boolean makeReusable, params Type[] moduleTypes)
        {
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, String.Empty, makeReusable, moduleTypes);
        }

        public void UnregisterStepModule<T>() where T : IStepModule
        {
            UnregisterStepModules(typeof(T));
        }

        public void UnregisterStepModules(params Type[] moduleTypes)
        {
            _moduleRegistrationStrategy.UnregisterStepModules(Kernel, moduleTypes);
        }

        public void Do<TStep>(Action<TStep> setSetUpAction = null) where TStep : IExecutableStep
        {
            var runner = Kernel.Get<IStepRunner>(GetKernelConstructorArg(), GetCurrentSessionIdConstructorArg());
            var step = Kernel.Get<TStep>();
            setSetUpAction?.Invoke(step);
            runner.Run(step);
        }
            
        public TResult Do<TStep, TResult>(Action<TStep> setSetUpAction = null) 
            where TStep : IExecutableStep<TResult>
        {
            var runner = Kernel.Get<IStepRunner>(GetKernelConstructorArg(), GetCurrentSessionIdConstructorArg());
            var step = Kernel.Get<TStep>();
            setSetUpAction?.Invoke(step);                        
            return runner.RunWithReturnValue(step);
        }

        public void Do(Action outOfStepOperations)
        {
            var runner = Kernel.Get<IStepRunner>(GetKernelConstructorArg(), GetCurrentSessionIdConstructorArg());
            var step = Kernel.Get<FakeStep>();
            step.Operations = outOfStepOperations;
            runner.Run(step);
        }

        public TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue)
        {
            var runner = Kernel.Get<IStepRunner>(GetKernelConstructorArg(), GetCurrentSessionIdConstructorArg());
            var step = Kernel.Get<FakeStepWithReturnValue<TResult>>();
            step.OperationsWithReturnValue = outOfStepFuncWithReturnValue;
            return runner.RunWithReturnValue(step);
        }

        public TStep Fill<TStep>(Action<TStep> stepSetupAction = null) where TStep : IStep
        {
            var step = Kernel.Get<TStep>();
            stepSetupAction?.Invoke(step);
            return step;
        }
    }
}

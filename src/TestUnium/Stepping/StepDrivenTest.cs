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

        public void RegisterStepModule<TStepModule>(Boolean makeReusable) where TStepModule : IStepModule =>
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, String.Empty, makeReusable, typeof(TStepModule));
       
        public void RegisterStepModule<TStepModule>() where TStepModule : IStepModule =>
            RegisterStepModule<TStepModule>(false);

        public void RegisterStepModules(params Type[] moduleTypes) =>
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, String.Empty, false, moduleTypes);
        
        public void RegisterStepModules(Boolean makeReusable, params Type[] moduleTypes) =>
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, String.Empty, makeReusable, moduleTypes);
      
        public void UnregisterStepModule<T>() where T : IStepModule =>
            UnregisterStepModules(typeof(T));

        public void UnregisterStepModules(params Type[] moduleTypes) =>
            _moduleRegistrationStrategy.UnregisterStepModules(Kernel, moduleTypes);
        
        public void Do<TStep>(Action<TStep> setSetUpAction = null, StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow) where TStep : IExecutableStep
        {
            var runner = Kernel.Get<IStepRunner>(GetKernelConstructorArg(), GetCurrentSessionIdConstructorArg());
            var step = Kernel.Get<TStep>();
            step.ExceptionHandlingMode = exceptionHandlingMode;
            setSetUpAction?.Invoke(step);
            runner.Run(step);
        }
        public void Do<TStep>(StepExceptionHandlingMode exceptionHandlingMode) where TStep : IExecutableStep =>
            Do((Action<TStep>)null, exceptionHandlingMode);
        
        public TResult Do<TStep, TResult>(Action<TStep> setSetUpAction = null, StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow) 
            where TStep : IExecutableStep<TResult>
        {
            var runner = Kernel.Get<IStepRunner>(GetKernelConstructorArg(), GetCurrentSessionIdConstructorArg());
            var step = Kernel.Get<TStep>();
            step.ExceptionHandlingMode = exceptionHandlingMode;
            setSetUpAction?.Invoke(step);                        
            return runner.RunWithReturnValue(step);
        }
        public TResult Do<TStep, TResult>(StepExceptionHandlingMode exceptionHandlingMode)
            where TStep : IExecutableStep<TResult> =>
            Do<TStep, TResult>(null, exceptionHandlingMode);
       
        public void Do(Action outOfStepOperations, StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow)
        {
            var runner = Kernel.Get<IStepRunner>(GetKernelConstructorArg(), GetCurrentSessionIdConstructorArg());
            var step = Kernel.Get<FakeStep>();
            step.Operations = outOfStepOperations;
            step.ExceptionHandlingMode = exceptionHandlingMode;
            runner.Run(step);
        }

        public TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue, StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow)
        {
            var runner = Kernel.Get<IStepRunner>(GetKernelConstructorArg(), GetCurrentSessionIdConstructorArg());
            var step = Kernel.Get<FakeStepWithReturnValue<TResult>>();
            step.OperationsWithReturnValue = outOfStepFuncWithReturnValue;
            step.ExceptionHandlingMode = exceptionHandlingMode;
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

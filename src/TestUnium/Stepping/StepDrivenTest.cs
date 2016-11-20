using System;
using System.Runtime.CompilerServices;
using Castle.MicroKernel.Registration;
using TestUnium.Sessioning;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    /// <summary>
    /// 
    /// </summary>
    public class StepDrivenTest : SessionDrivenTest, IStepDrivenTest
    {
        public StepDrivenTest()
        {
            Container.Register(Component.For<IStepExecutor>().Instance(this));
        }

        public void RegisterStepModule<TStepModule>(Action<TStepModule> stepSetUpAction = null, Boolean makeReusable = false) where TStepModule : IStepModule =>
            Container.Resolve<IStepModuleRegistrationStrategy>().RegisterStepModules(Container, String.Empty, makeReusable, typeof(TStepModule));
       
        public void RegisterStepModules(params Type[] moduleTypes) =>
            Container.Resolve<IStepModuleRegistrationStrategy>().RegisterStepModules(Container, String.Empty, false, moduleTypes);
        
        public void RegisterStepModules(Boolean makeReusable, params Type[] moduleTypes) =>
            Container.Resolve<IStepModuleRegistrationStrategy>().RegisterStepModules(Container, String.Empty, makeReusable, moduleTypes);
      
        public void UnregisterStepModule<T>() where T : IStepModule =>
            UnregisterStepModules(typeof(T));

        public void UnregisterStepModules(params Type[] moduleTypes) =>
            Container.Resolve<IStepModuleRegistrationStrategy>().UnregisterStepModules(Container, moduleTypes);
        
        public void Do<TStep>(Action<TStep> stepSetUpAction = null,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, Boolean validateStep = true, [CallerMemberName] String callingMethodName = "") 
            where TStep : IExecutableStep
        {
            Container.Resolve<IStepRunner>()
                .Run(this, callingMethodName,
                Container.Resolve<TStep>(), 
                stepSetUpAction,
                exceptionHandlingMode, validateStep);
        }
        public void Do<TStep>(StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep = true, [CallerMemberName] String callingMethodName = "") 
            where TStep : IExecutableStep =>
            Do((Action<TStep>)null, exceptionHandlingMode, validateStep);
        public void Do<TStep>(Boolean validateStep, [CallerMemberName] String callingMethodName = "")
            where TStep : IExecutableStep =>
            Do((Action<TStep>)null, StepExceptionHandlingMode.Rethrow, validateStep);


        public TResult Do<TStep, TResult>(Action<TStep> stepSetUpAction = null,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, Boolean validateStep = true, [CallerMemberName] String callingMethodName = "") 
            where TStep : IExecutableStep<TResult>
        {           
            return Container.Resolve<IStepRunner>()
                .RunWithReturnValue<TStep, TResult>(
                this, callingMethodName,
                Container.Resolve<TStep>(), 
                stepSetUpAction, 
                exceptionHandlingMode, validateStep);
        }
        public TResult Do<TStep, TResult>(StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep = true, [CallerMemberName] String callingMethodName = "")
            where TStep : IExecutableStep<TResult> =>
            Do<TStep, TResult>(null, exceptionHandlingMode, validateStep);
        public TResult Do<TStep, TResult>(Boolean validateStep, [CallerMemberName] String callingMethodName = "")
            where TStep : IExecutableStep<TResult> =>
            Do<TStep, TResult>(null, StepExceptionHandlingMode.Rethrow, validateStep);

        public void Do(Action outOfStepOperations, 
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, [CallerMemberName] String callingMethodName = "")
        {
            var runner = Container.Resolve<IStepRunner>();
            var step = Container.Resolve<FakeStep>();
            step.Operations = outOfStepOperations;
            runner.Run(this, callingMethodName, step, null, exceptionHandlingMode, false);
        }

        public TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue, 
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, [CallerMemberName] String callingMethodName = "")
        {
            var runner = Container.Resolve<IStepRunner>();
            var step = Container.Resolve<FakeStepWithReturnValue<TResult>>();
            step.OperationsWithReturnValue = outOfStepFuncWithReturnValue;
            return runner.RunWithReturnValue<FakeStepWithReturnValue<TResult>, TResult>(this, callingMethodName, step, null, exceptionHandlingMode, false);
        }

        public TStep GetStep<TStep>(Action<TStep> stepSetupAction = null) where TStep : IStep
        {
            var step = Container.Resolve<TStep>();
            stepSetupAction?.Invoke(step);
            return step;
        }
    }
}

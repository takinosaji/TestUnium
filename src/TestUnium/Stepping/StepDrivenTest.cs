using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        public void RegisterStepModule<TStepModule>(String stepModuleAlias, Action<TStepModule> stepModuleSetUpAction = null, bool makeReusable = false) where TStepModule : IStepModule =>
            Container.Resolve<IStepModuleRegistrationStrategy>(Internal.Bootstrapping.Castle.Component.Registration.Name.InTestStepModuleRegistrationStrategyName)
                .RegisterStepModules(Container, makeReusable, new KeyValuePair<String, Type>(stepModuleAlias, typeof(TStepModule)));

        public void RegisterStepModule<TStepModule>(Action<TStepModule> stepModuleSetUpAction = null, bool makeReusable = false) where TStepModule : IStepModule
        {
            Container.Resolve<IStepModuleRegistrationStrategy>(Internal.Bootstrapping.Castle.Component.Registration.Name.InTestStepModuleRegistrationStrategyName)
               .RegisterStepModules(Container, makeReusable, typeof(TStepModule));
        }

        public void RegisterStepModules(params Type[] stepModules)
        {
            //Contract.Requires<ArgumentException>(stepModules != null && stepModules.Length > 0, "StepModules argument is null or empty!");
            if(stepModules == null || stepModules.Length == 0)
                throw new ArgumentException("StepModules argument is null or empty!");

            Container.Resolve<IStepModuleRegistrationStrategy>(
                    Internal.Bootstrapping.Castle.Component.Registration.Name.InTestStepModuleRegistrationStrategyName)
                .RegisterStepModules(Container, false, stepModules);
        }

        public void RegisterStepModules(params KeyValuePair<String, Type>[] stepModules)
        {
            //Contract.Requires<ArgumentException>(stepModules != null && stepModules.Length > 0, "StepModules argument is null or empty!");
            if (stepModules == null || stepModules.Length == 0)
                throw new ArgumentException("StepModules argument is null or empty!");

            Container.Resolve<IStepModuleRegistrationStrategy>(
                    Internal.Bootstrapping.Castle.Component.Registration.Name.InTestStepModuleRegistrationStrategyName)
                .RegisterStepModules(Container, false, stepModules);
        }

        public void RegisterStepModules(Boolean makeReusable, params Type[] stepModules)
        {
            //Contract.Requires<ArgumentException>(stepModules != null && stepModules.Length > 0, "StepModules argument is null or empty!");
            if (stepModules == null || stepModules.Length == 0)
                throw new ArgumentException("StepModules argument is null or empty!");

            Container.Resolve<IStepModuleRegistrationStrategy>(
                    Internal.Bootstrapping.Castle.Component.Registration.Name.InTestStepModuleRegistrationStrategyName)
                .RegisterStepModules(Container, makeReusable, stepModules);
        }

        public void RegisterStepModules(Boolean makeReusable, params KeyValuePair<string, Type>[] stepModules)
        {
            //Contract.Requires<ArgumentException>(stepModules != null && stepModules.Length > 0, "StepModules argument is null or empty!");
            if (stepModules == null || stepModules.Length == 0)
                throw new ArgumentException("StepModules argument is null or empty!");

            Container.Resolve<IStepModuleRegistrationStrategy>(
                    Internal.Bootstrapping.Castle.Component.Registration.Name.InTestStepModuleRegistrationStrategyName)
                .RegisterStepModules(Container, makeReusable, stepModules);
        }

        public void UnregisterStepModules(params String[] stepModuleAliases)
        {
            //Contract.Requires<ArgumentException>(stepModuleAliases != null && stepModuleAliases.Length > 0, "StepModuleAliases argument is null or empty!");
            if (stepModuleAliases == null || stepModuleAliases.Length == 0)
                throw new ArgumentException("StepModuleAliases argument is null or empty!");

            Container.Resolve<IStepModuleRegistrationStrategy>().UnregisterStepModules(Container, stepModuleAliases);
        }
  
        public void Do<TStep>(Action<TStep> stepSetUpAction = null,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, Boolean validateStep = true, [CallerMemberName] String callingMethodName = "") 
            where TStep : class, IExecutableStep
        {
            if (!Container.Kernel.HasComponent(typeof(TStep)))
            {
                Container.Kernel.Register(Component.For<TStep>().ImplementedBy<TStep>().LifestyleTransient());
            }
            Container.Resolve<IStepRunner>()
                .Run(this, callingMethodName,
                Container.Resolve<TStep>(), 
                stepSetUpAction,
                exceptionHandlingMode, validateStep);
        }
        public void Do<TStep>(StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep = true, [CallerMemberName] String callingMethodName = "") 
            where TStep : class, IExecutableStep =>
            Do((Action<TStep>)null, exceptionHandlingMode, validateStep);
        public void Do<TStep>(Boolean validateStep, [CallerMemberName] String callingMethodName = "")
            where TStep : class, IExecutableStep =>
            Do((Action<TStep>)null, StepExceptionHandlingMode.Rethrow, validateStep);


        public TResult Do<TStep, TResult>(Action<TStep> stepSetUpAction = null,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, Boolean validateStep = true, [CallerMemberName] String callingMethodName = "") 
            where TStep : class, IExecutableStep<TResult>
        {
            if (!Container.Kernel.HasComponent(typeof(TStep)))
            {
                Container.Kernel.Register(Component.For<TStep>().ImplementedBy<TStep>().LifestyleTransient());
            }
            return Container.Resolve<IStepRunner>()
                .RunWithReturnValue<TStep, TResult>(
                this, callingMethodName,
                Container.Resolve<TStep>(), 
                stepSetUpAction, 
                exceptionHandlingMode, validateStep);
        }
        public TResult Do<TStep, TResult>(StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep = true, [CallerMemberName] String callingMethodName = "")
            where TStep : class, IExecutableStep<TResult> =>
            Do<TStep, TResult>(null, exceptionHandlingMode, validateStep);
        public TResult Do<TStep, TResult>(Boolean validateStep, [CallerMemberName] String callingMethodName = "")
            where TStep : class, IExecutableStep<TResult> =>
            Do<TStep, TResult>(null, StepExceptionHandlingMode.Rethrow, validateStep);

        public void Do(Action outOfStepOperations, 
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, [CallerMemberName] String callingMethodName = "")
        {
            var runner = Container.Resolve<IStepRunner>();
            if (!Container.Kernel.HasComponent(typeof(FakeStep)))
            {
                Container.Kernel.Register(Component.For<FakeStep>().ImplementedBy<FakeStep>());
            }
            var step = Container.Resolve<FakeStep>();
            step.Operations = outOfStepOperations;
            runner.Run(this, callingMethodName, step, null, exceptionHandlingMode, false);
        }

        public TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue, 
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, [CallerMemberName] String callingMethodName = "")
        {
            var runner = Container.Resolve<IStepRunner>();
            if (!Container.Kernel.HasComponent(typeof(FakeStepWithReturnValue<TResult>)))
            {
                Container.Kernel.Register(Component.For<FakeStepWithReturnValue<TResult>>().ImplementedBy<FakeStepWithReturnValue<TResult>>().LifestyleTransient());
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Ninject;
using Ninject.Activation;
using Ninject.Activation.Caching;
using Ninject.Parameters;
using Ninject.Planning;
using Ninject.Planning.Bindings;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
{
    [StepRunner(typeof(StepRunnerBase))]
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
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, makeReusable, typeof(TStepModule));
        }

        public void RegisterStepModules(params Type[] moduleTypes)
        {
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, false, moduleTypes);
        }
        public void RegisterStepModules(Boolean makeReusable, params Type[] moduleTypes)
        {
            _moduleRegistrationStrategy.RegisterStepModules(Kernel, makeReusable, moduleTypes);
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
            var kernel = GetActualKernel();
            var runner = kernel.Get<IStepRunner>();
            var step = kernel.Get<TStep>();
            setSetUpAction?.Invoke(step);
            runner.Run(step);
        }
            
        public TResult Do<TStep, TResult>(Action<TStep> setSetUpAction = null) 
            where TStep : IExecutableStep<TResult>
        {
            var kernel = GetActualKernel();
            var runner = kernel.Get<IStepRunner>();
            var step = kernel.Get<TStep>();
            setSetUpAction?.Invoke(step);                        
            return runner.RunWithReturnValue(step);
        }

        public void Do(Action outOfStepOperations)
        {
            var kernel = GetActualKernel();
            var runner = kernel.Get<IStepRunner>();
            var step = kernel.Get<FakeStep>();
            step.Operations = outOfStepOperations;
            runner.Run(step);
        }

        public TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue)
        {
            var kernel = GetActualKernel();
            var runner = kernel.Get<IStepRunner>();
            var step = kernel.Get<FakeStepWithReturnValue<TResult>>();
            step.OperationsWithReturnValue = outOfStepFuncWithReturnValue;
            return runner.RunWithReturnValue(step);
        }

        public TStep Fill<TStep>(Action<TStep> stepSetupAction = null) where TStep : IStep
        {
            var kernel = GetActualKernel();
            var step = kernel.Get<TStep>();
            stepSetupAction?.Invoke(step);
            return step;
        }

        private IKernel GetActualKernel()
        {
            ISession currentSession;
            return Sessions.TryGetValue(Thread.CurrentThread.ManagedThreadId, out currentSession)
                ? currentSession.GetSessionKernel()
                : Kernel;
        }
    }
}

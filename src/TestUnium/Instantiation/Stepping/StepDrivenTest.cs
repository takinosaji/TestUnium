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
    public class StepDrivenTest : SessionDrivenTest, IStepDrivenTest
    {
        public StepDrivenTest()
        {
            Kernel.Bind<IStepDrivenTest>().ToConstant(this);
        }

        public void RegisterStepModule<T>(Boolean makeReusable = false) where T : IStepModule
        {
            RegisterStepModule(typeof(T));
        }

        public void RegisterStepModule(Type moduleType, Boolean makeReusable = false)
        {
            if (!typeof(IStepModule).IsAssignableFrom(moduleType))
                throw new IncorrectInheritanceException(new[] { moduleType.Name }, new[] { nameof(IStepModule) });
            if (makeReusable || moduleType.GetCustomAttribute<ReusableAttribute>() != null)
            {
                Kernel.Bind<IStepModule>().To(moduleType).InSingletonScope();
                return;
            }
            Kernel.Bind<IStepModule>().To(moduleType);
        }

        public void RegisterStepModules(bool makeReusable = false, params Type[] moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                RegisterStepModule(moduleType);
            }
        }

        public void UnregisterStepModule<T>() where T : IStepModule
        {
            UnregisterStepModule(typeof(T));
        }

        public void UnregisterStepModule(Type moduleType)
        {
            IBinding targetBinding = null;
            Kernel.GetBindings(typeof(IStepModule))
                .ToList()
                .ForEach(
                    binding =>
                    {
                        if (binding.Target != BindingTarget.Type || binding.Target == BindingTarget.Self) return;
                        var req = Kernel.CreateRequest(moduleType, metadata => true, new IParameter[0], true, false);
                        var cache = Kernel.Components.Get<ICache>();
                        var planner = Kernel.Components.Get<IPlanner>();
                        var pipeline = Kernel.Components.Get<IPipeline>();
                        var provider = binding.GetProvider(new Context(Kernel, req, binding, cache, planner, pipeline));
                        if (provider.Type == moduleType)
                        {
                            targetBinding = binding;
                        }
                    });
            if (targetBinding != null)
            {
                Kernel.RemoveBinding(targetBinding);
            }
        }

        public void UnregisterStepModules(params Type[] moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                UnregisterStepModule(moduleType);
            }
        }

        public void Do<TStep>(Action<TStep> setSetUpAction = null) where TStep : IExecutableStep
        {
            var runner = Kernel.Get<IStepRunner>();

            runner.RegisterModules();
            var step = Kernel.Get<TStep>();
            setSetUpAction?.Invoke(step);
            runner.Run(step);
        }
            
        public TResult Do<TStep, TResult>(Action<TStep> setSetUpAction = null) 
            where TStep : IExecutableStep<TResult>
        {
            var runner = Kernel.Get<IStepRunner>();
            var step = Kernel.Get<TStep>();
            setSetUpAction?.Invoke(step);                        
            return runner.RunWithReturnValue(step);
        }

        public void Do(Action outOfStepOperations)
        {
            var runner = Kernel.Get<IStepRunner>();
            var step = Kernel.Get<FakeStep>();
            step.Operations = outOfStepOperations;
            runner.Run(step);
        }

        public TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue)
        {
            var runner = Kernel.Get<IStepRunner>();
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

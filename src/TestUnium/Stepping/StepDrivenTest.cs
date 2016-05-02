using System;
using System.Linq;
using Ninject;
using Ninject.Activation;
using Ninject.Activation.Caching;
using Ninject.Parameters;
using Ninject.Planning;
using Ninject.Planning.Bindings;
using TestUnium.Core;
using TestUnium.Customization;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Modules.Logging;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public abstract class StepDrivenTest : CustomizationAttributeDrivenTest, IStepDrivenTest
    {
        protected StepRunner StepRunner;

        protected StepDrivenTest()
        {
            Kernel.Bind<StepDrivenTest>().ToConstant(this);
        }

        public void RegisterStepModule<T>(Boolean isReusable = true) where T : IStepModule
        {
            if (isReusable)
            {
                Kernel.Bind<IStepModule>().To<T>().InSingletonScope();
                return;
            }
            Kernel.Bind<IStepModule>().To<T>();
        }

        public void UnregisterStepModule<T>() where T : IStepModule
        {
            IBinding targetBinding = null;
            Kernel.GetBindings(typeof (IStepModule))
                .ToList()
                .ForEach(
                    binding =>
                    {
                        if (binding.Target != BindingTarget.Type || binding.Target == BindingTarget.Self) return;
                        var req = Kernel.CreateRequest(typeof(T), metadata => true, new IParameter[0], true, false);
                        var cache = Kernel.Components.Get<ICache>();
                        var planner = Kernel.Components.Get<IPlanner>();
                        var pipeline = Kernel.Components.Get<IPipeline>();
                        var provider = binding.GetProvider(new Context(Kernel, req, binding, cache, planner, pipeline));
                        if (provider.Type == typeof (T))
                        {
                            targetBinding = binding;
                        }
                    });
            if (targetBinding != null)
            {
                Kernel.RemoveBinding(targetBinding);
            }
        }

        public void Do<TStep>(Action<TStep> setSetUpAction = null) where TStep : IExecutableStep
        {
            var step = Kernel.Get<TStep>();
            setSetUpAction?.Invoke(step);
            StepRunner.Run(step);
        }
            
        public TResult Do<TStep, TResult>(Action<TStep> setSetUpAction = null) 
            where TStep : IExecutableStep<TResult>
        {
            var step = Kernel.Get<TStep>();
            setSetUpAction?.Invoke(step);                        
            var result = StepRunner.RunWithReturnValue(step);
            return result;
        }

        public void Do(Action outOfStepOperations)
        {
            StepRunner.Run(outOfStepOperations);
        }

        public TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue)
        {
            return StepRunner.RunWithReturnValue(outOfStepFuncWithReturnValue);
        }

        protected T Fill<T>(Action<T> stepSetupAction = null) where T : IStep
        {
            var step = Kernel.Get<T>();
            stepSetupAction?.Invoke(step);
            return step;
        }
    }
}

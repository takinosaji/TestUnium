using System;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace TestUnium.Stepping.Pipeline
{
    public class BasicStepModuleRegistrationStrategy : IStepModuleRegistrationStrategy
    {
        public void RegisterStepModule<TStepModule>(IWindsorContainer container, String context, Boolean makeReusable = false) where TStepModule : IStepModule
        {
            RegisterStepModules(container, context, makeReusable, typeof(TStepModule));
        }

        public void RegisterStepModules(IWindsorContainer container, String context, params Type[] moduleTypes)
        {
          RegisterStepModules(container, context, false, moduleTypes);
        }

        public void RegisterStepModules(IWindsorContainer container, String context, Boolean makeReusable, params Type[] moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                if (!typeof(IStepModule).IsAssignableFrom(moduleType))
                    throw new IncorrectInheritanceException(new[] { moduleType.Name }, new[] { nameof(IStepModule) });
                if (makeReusable || moduleType.GetCustomAttribute<ReusableAttribute>() != null)
                {
                    container.Register(Component.For<IStepModule>().ImplementedBy(moduleType).LifestyleSingleton());
                    return;
                }
                container.Register(Component.For<IStepModule>().ImplementedBy(moduleType));
            }
        }

        public void UnregisterStepModule<T>(IWindsorContainer container) where T : IStepModule
        {
            UnregisterStepModules(container, typeof(T));
        }

        public void UnregisterStepModules(IWindsorContainer container, params Type[] moduleTypes)
        {
            //TODO: Somehow deal with this situation
            //foreach (var moduleType in moduleTypes)
            //{
            //    IBinding targetBinding = null;
            //    container.GetBindings(typeof(IStepModule))
            //        .ToList()
            //        .ForEach(
            //            binding =>
            //            {
            //                if (binding.Target != BindingTarget.Type || binding.Target == BindingTarget.Self) return;
            //                var req = container.CreateRequest(moduleType, metadata => true, new IParameter[0], true, false);
            //                var cache = container.Components.Get<ICache>();
            //                var planner = container.Components.Get<IPlanner>();
            //                var pipeline = container.Components.Get<IPipeline>();
            //                var provider = binding.GetProvider(new Context(container, req, binding, cache, planner, pipeline));
            //                if (provider.Type == moduleType)
            //                {
            //                    targetBinding = binding;
            //                }
            //            });
            //    if (targetBinding != null)
            //    {
            //        container.RemoveBinding(targetBinding);
            //    }
            //}
        }
    }
}

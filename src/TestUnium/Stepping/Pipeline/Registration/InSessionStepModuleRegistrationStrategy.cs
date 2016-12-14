using System;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TestUnium.Internal.Bootstrapping;

namespace TestUnium.Stepping.Pipeline.Registration
{
    public class InSessionStepModuleRegistrationStrategy : IStepModuleRegistrationStrategy
    {
        public void RegisterStepModule<TStepModule>(IWindsorContainer container, Boolean makeReusable = false)
            where TStepModule : IStepModule
        {
            RegisterStepModules(container, makeReusable, typeof(TStepModule));
        }

        public void RegisterStepModules(IWindsorContainer container, params Type[] moduleTypes)
        {
            RegisterStepModules(container, false, moduleTypes);
        }

        public void RegisterStepModules(IWindsorContainer container, Boolean makeReusable, params Type[] moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                if (!typeof(IStepModule).IsAssignableFrom(moduleType))
                    throw new IncorrectInheritanceException(new[] {moduleType.Name}, new[] {nameof(IStepModule)});
               
                container.Register(Component.For<IStepModule>().ImplementedBy(moduleType).LifestyleScoped<StepModuleLifeStyleScopeAccessor>());
            }
        }
    }
}

using System;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace TestUnium.Stepping.Pipeline.Registration
{
    public class InTestStepModuleRegistrationStrategy : IStepModuleRegistrationStrategy
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
                if (makeReusable || moduleType.GetCustomAttribute<ReusableAttribute>() != null)
                {
                    container.Register(Component.For<IStepModule>().ImplementedBy(moduleType).LifestyleSingleton());
                    return;
                }
                container.Register(Component.For<IStepModule>().ImplementedBy(moduleType));
            }
        }
    }
}

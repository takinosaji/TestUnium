using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace TestUnium.Stepping.Pipeline.Registration
{
    public class InTestStepModuleRegistrationStrategy : IStepModuleRegistrationStrategy
    { 
        public void RegisterStepModule<TStepModule>(IWindsorContainer container, Boolean makeReusable, String moduleAlias = null) where TStepModule : IStepModule
        {
            if (moduleAlias == null)
            {
                moduleAlias = Guid.NewGuid().ToString();
            }
            RegisterStepModules(container, makeReusable, new KeyValuePair<String, Type>(moduleAlias, typeof(TStepModule)));
        }

        public void RegisterStepModules(IWindsorContainer container, params Type[] moduleTypes)
        {
            RegisterStepModules(container, false, moduleTypes);
        }

        public void RegisterStepModules(IWindsorContainer container, params KeyValuePair<string, Type>[] moduleTypes)
        {
            RegisterStepModules(container, false, moduleTypes);
        }

        public void RegisterStepModules(IWindsorContainer container, Boolean makeReusable, params Type[] stepModules)
        {
            var keyValuePairs = new List<KeyValuePair<String, Type>>();
            foreach (var stepModuleType in stepModules)
            {
                keyValuePairs.Add(new KeyValuePair<String, Type>(Guid.NewGuid().ToString(), stepModuleType));
            }
            RegisterStepModules(container, makeReusable, keyValuePairs.ToArray());
        }


        public void RegisterStepModules(IWindsorContainer container, Boolean makeReusable, params KeyValuePair<String, Type>[] stepModules)
        {
            //Contract.Requires<ArgumentException>(stepModules != null && stepModules.Length > 0, "StepModules argument is null or empty!");
            if(stepModules == null || stepModules.Length == 0)
                throw new ArgumentException("StepModules argument is null or empty!");

            foreach (var stepModule in stepModules)
            {
                if (!typeof(IStepModule).IsAssignableFrom(stepModule.Value))
                    throw new IncorrectInheritanceException(new[] { stepModule.Value.Name }, new[] { nameof(IStepModule) });
                if (makeReusable || stepModule.Value.GetCustomAttribute<ReusableAttribute>() != null)
                {
                    container.Register(Component.For<IStepModule>().ImplementedBy(stepModule.Value).LifestyleSingleton().Named(stepModule.Key));
                    return;
                }
                container.Register(Component.For<IStepModule>().ImplementedBy(stepModule.Value).LifestyleTransient().Named(stepModule.Key));
            }
        }

        public void UnregisterStepModules(IWindsorContainer container, params String[] moduleAliases)
        {
            //Contract.Requires<ArgumentException>(moduleAliases != null && moduleAliases.Length > 0, "StepModules argument is null or empty!");
            if (moduleAliases == null || moduleAliases.Length == 0)
                throw new ArgumentException("StepModuleAliases argument is null or empty!");

            throw new NotImplementedException();
        }
    }
}

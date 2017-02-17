using System;
using System.Collections.Generic;
using Castle.Windsor;

namespace TestUnium.Stepping.Pipeline
{
    public interface IStepModuleRegistrationStrategy
    {
        void RegisterStepModule<TStepModule>(IWindsorContainer container, Boolean makeReusable, String moduleAlias = null) where TStepModule : IStepModule;
        void RegisterStepModules(IWindsorContainer container, params Type[] moduleTypes);
        void RegisterStepModules(IWindsorContainer container, params KeyValuePair<String, Type>[] stepModules);
        void RegisterStepModules(IWindsorContainer container, Boolean makeReusable, params KeyValuePair<String, Type>[] stepModules);
        void RegisterStepModules(IWindsorContainer container, Boolean makeReusable, params Type[] stepModules);
        void UnregisterStepModules(IWindsorContainer container, params String[] moduleAliases);
    }
}
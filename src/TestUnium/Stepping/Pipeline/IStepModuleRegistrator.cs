using System;
using System.Collections.Generic;

namespace TestUnium.Stepping.Pipeline
{
    public interface IStepModuleRegistrator
    {
        void RegisterStepModule<TStepModule>(String moduleAlias, Action<TStepModule> stepModuleSetUpAction = null, Boolean makeReusable = false) where TStepModule : IStepModule;
        void RegisterStepModule<TStepModule>(Action<TStepModule> stepModuleSetUpAction = null, Boolean makeReusable = false) where TStepModule : IStepModule;
        void RegisterStepModules(params Type[] stepModules);
        void RegisterStepModules(params KeyValuePair<String, Type>[] stepModules);
        void RegisterStepModules(Boolean makeReusable, params Type[] stepModules);
        void RegisterStepModules(Boolean makeReusable, params KeyValuePair<String, Type>[] stepModules);
        void UnregisterStepModules(params String[] stepModuleAliases);
    }
}
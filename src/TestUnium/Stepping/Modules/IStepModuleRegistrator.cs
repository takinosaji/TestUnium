using System;

namespace TestUnium.Stepping.Modules
{
    public interface IStepModuleRegistrator
    {
        void RegisterStepModule<TStepModule>(Action<TStepModule> stepModuleSetUpAction = null, Boolean makeReusable = false) where TStepModule : IStepModule;
        void RegisterStepModules(params Type[] moduleTypes);
        void RegisterStepModules(Boolean makeReusable, params Type[] moduleTypes);
        void UnregisterStepModule<TStepModule>() where TStepModule : IStepModule;
        void UnregisterStepModules(params Type[] moduleTypes);
    }
}
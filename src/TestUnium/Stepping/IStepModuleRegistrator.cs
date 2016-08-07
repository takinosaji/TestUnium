using System;
using TestUnium.Stepping.Modules;

namespace TestUnium.Stepping
{
    public interface IStepModuleRegistrator
    {
        void RegisterStepModule<TStepModule>(Boolean makeReusable) where TStepModule : IStepModule;
        void RegisterStepModules(params Type[] moduleTypes);
        void RegisterStepModules(Boolean makeReusable, params Type[] moduleTypes);
        void UnregisterStepModule<TStepModule>() where TStepModule : IStepModule;
        void UnregisterStepModules(params Type[] moduleTypes);
    }
}
using System;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
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
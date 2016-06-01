using System;
using Ninject;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
{
    public interface IStepModuleRegistrationStrategy
    {
        void RegisterStepModule<TStepModule>(IKernel kernel, Boolean makeReusable) where TStepModule : IStepModule;
        void RegisterStepModules(IKernel kernel, params Type[] moduleTypes);
        void RegisterStepModules(IKernel kernel, Boolean makeReusable, params Type[] moduleTypes);
        void UnregisterStepModule<TStepModule>(IKernel kernel) where TStepModule : IStepModule;
        void UnregisterStepModules(IKernel kernel, params Type[] moduleTypes);
    }
}
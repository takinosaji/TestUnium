using Ninject.Modules;
using TestUnium.Internal.Validation.StepModules;
using TestUnium.Stepping.Modules.Conditions;

namespace TestUnium.Internal.Bootstrapping.Modules
{
    public class StepModuleValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStepModuleValidator>().To<FakeStepOnlyModuleValidator>();
            Bind<IStepModuleValidator>().To<RealStepOnlyModuleValidator>();
            Bind<IStepModuleValidator>().To<StepConditionsModuleValidator>();
            Bind<IStepModuleValidator>().To<TargetStepsModuleValidator>();
            Bind<IStepModuleValidator>().To<ExcludedStepModuleValidator>();
        }
    }
}
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TestUnium.Internal.Validation.StepModules;

namespace TestUnium.Internal.Bootstrapping.Modules
{
    public class StepModuleValidationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IStepModuleValidator >().ImplementedBy<FakeStepOnlyModuleValidator>());
            container.Register(Component.For<IStepModuleValidator>().ImplementedBy<RealStepOnlyModuleValidator>());
            container.Register(Component.For<IStepModuleValidator>().ImplementedBy<StepConditionsModuleValidator>());
            container.Register(Component.For<IStepModuleValidator>().ImplementedBy<TargetStepsModuleValidator>());
            container.Register(Component.For<IStepModuleValidator>().ImplementedBy<ExcludedStepModuleValidator>());
        }
    }
}
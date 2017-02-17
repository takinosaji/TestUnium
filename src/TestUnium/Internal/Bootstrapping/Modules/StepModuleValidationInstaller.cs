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
            container.Register(Component.For<IStepModuleValidator >().ImplementedBy<FakeStepOnlyModuleValidator>().LifestyleSingleton());
            container.Register(Component.For<IStepModuleValidator>().ImplementedBy<RealStepOnlyModuleValidator>().LifestyleSingleton());
            container.Register(Component.For<IStepModuleValidator>().ImplementedBy<StepConditionsModuleValidator>().LifestyleSingleton());
            container.Register(Component.For<IStepModuleValidator>().ImplementedBy<TargetStepsModuleValidator>().LifestyleSingleton());
            container.Register(Component.For<IStepModuleValidator>().ImplementedBy<ExcludedStepModuleValidator>().LifestyleSingleton());
        }
    }
}
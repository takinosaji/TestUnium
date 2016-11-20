using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TestUnium.Internal.Validation.Step;
using TestUnium.Internal.Validation.StepModules;

namespace TestUnium.Internal.Bootstrapping.Modules
{
    public class StepValidationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IStepValidator>().ImplementedBy<RequiredMembersStepValidator>());
        }
    }
}
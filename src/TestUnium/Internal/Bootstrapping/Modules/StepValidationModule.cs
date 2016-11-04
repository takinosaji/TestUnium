using Ninject.Modules;
using TestUnium.Internal.Validation.Step;
using TestUnium.Internal.Validation.StepModules;

namespace TestUnium.Internal.Bootstrapping.Modules
{
    public class StepValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStepValidator>().To<RequiredMembersStepValidator>();
        }
    }
}
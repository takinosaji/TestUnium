using System;
using Castle.MicroKernel.Registration;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Stepping.Pipeline.Registration.Customization
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.StepModuleRegistrationStrategy)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseStepModulesRegistrationStrategyForSessionAttribute : UseStepModulesRegistrationStrategyForTestAttribute
    {
        public UseStepModulesRegistrationStrategyForSessionAttribute(Type stepModuleRegistrationStrategyType) 
            : base(stepModuleRegistrationStrategyType)
        {
        }  

        public override void Customize(IStepDrivenTest context)
        {
            AddBindings(context,
                Internal.Bootstrapping.Castle.Component.Registration.Name.InSessionStepModuleRegistrationStrategyName);
        }
    }
}
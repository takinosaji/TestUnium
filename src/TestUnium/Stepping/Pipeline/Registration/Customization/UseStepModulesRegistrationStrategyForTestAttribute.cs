using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Stepping.Pipeline.Registration.Customization
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.StepModuleRegistrationStrategy)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseStepModulesRegistrationStrategyForTestAttribute : CustomizationAttribute, ICustomizer<IStepDrivenTest>
    {
        protected readonly Type StepModuleRegistrationStrategyType;

        public UseStepModulesRegistrationStrategyForTestAttribute(Type stepModuleRegistrationStrategyType)
        {
            if (!typeof(IStepModuleRegistrationStrategy).IsAssignableFrom(stepModuleRegistrationStrategyType))
                throw new IncorrectInheritanceException(new List<String> { stepModuleRegistrationStrategyType.Name },
                    new List<String> { nameof(IStepModuleRegistrationStrategy) });
            StepModuleRegistrationStrategyType = stepModuleRegistrationStrategyType;
        }  

        public virtual void Customize(IStepDrivenTest context)
        {
            AddBindings(context,
                Internal.Bootstrapping.Castle.Component.Registration.Name.InTestStepModuleRegistrationStrategyName);
        }

        protected void AddBindings(IStepDrivenTest context, String bindingName)
        {
            context.Container.Register(Component.For<IStepModuleRegistrationStrategy>()
              .ImplementedBy(StepModuleRegistrationStrategyType)
                  .Named(bindingName));
        }
    }
}
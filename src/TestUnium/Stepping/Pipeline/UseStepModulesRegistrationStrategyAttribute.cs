using System;
using System.Collections.Generic;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;
using TestUnium.Sessioning;

namespace TestUnium.Stepping.Pipeline
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.StepModuleRegistrationStrategy)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseStepModulesRegistrationStrategyAttribute : CustomizationAttribute, ICustomizer<IStepDrivenTest>
    {
        protected readonly Type StepModuleRegistrationStrategyType;

        public UseStepModulesRegistrationStrategyAttribute(Type stepModuleRegistrationStrategyType)
        {
            if (!typeof(IStepModuleRegistrationStrategy).IsAssignableFrom(stepModuleRegistrationStrategyType))
                throw new IncorrectInheritanceException(new List<String> { stepModuleRegistrationStrategyType.Name },
                    new List<String> { nameof(IStepModuleRegistrationStrategy) });
            StepModuleRegistrationStrategyType = stepModuleRegistrationStrategyType;
        }  

        public virtual void Customize(IStepDrivenTest context)
        {
            context.Kernel.Bind<IStepModuleRegistrationStrategy>().To(StepModuleRegistrationStrategyType);
        }
    }
}
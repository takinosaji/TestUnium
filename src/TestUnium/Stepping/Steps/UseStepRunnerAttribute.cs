using System;
using System.Collections.Generic;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Stepping.Steps
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.StepRunner)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseStepRunnerAttribute : CustomizationAttribute, ICustomizer<StepDrivenTest>
    {
        protected readonly Type StepRunnerType;

        public UseStepRunnerAttribute(Type stepRunnerType)
        {
            if (!typeof(IStepRunner).IsAssignableFrom(stepRunnerType))
                throw new IncorrectInheritanceException(new List<String> { stepRunnerType.Name },
                    new List<String> { nameof(IStepRunner) });
            StepRunnerType = stepRunnerType;
        }

        public void Customize(StepDrivenTest context)
        {
            context.Kernel.Bind<IStepRunner>().To(StepRunnerType);
        }
    }
}

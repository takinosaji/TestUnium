using System;
using System.Collections.Generic;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Stepping
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.StepRunner)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseStepRunnerAttribute : CustomizationAttribute, ICustomizer<IStepDrivenTest>
    {
        private readonly Type _stepRunnerType;

        public UseStepRunnerAttribute(Type stepRunnerType)
        {
            if (!typeof(IStepRunner).IsAssignableFrom(stepRunnerType))
                throw new IncorrectInheritanceException(new List<String> { stepRunnerType.Name },
                    new List<String> { nameof(IStepRunner) });
            _stepRunnerType = stepRunnerType;
        }

        public void Customize(IStepDrivenTest context)
        {
            context.Kernel.Bind<IStepRunner>().To(_stepRunnerType);
        }
    }
}

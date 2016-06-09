using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Common;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;

namespace TestUnium.Instantiation.Stepping.Steps
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.StepRunner)]
    [AttributeUsage(AttributeTargets.Class)]
    class StepRunnerAttribute : CustomizationAttribute, ICustomizer<StepDrivenTest>
    {
        protected readonly Type StepRunnerType;

        public StepRunnerAttribute(Type stepRunnerType) : base(typeof(StepDrivenTest))
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

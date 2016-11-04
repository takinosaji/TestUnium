using System;
using System.Linq;
using System.Reflection;
using TestUnium.Stepping.Modules.Conditions;
using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation.StepModules
{
    public class ExcludedStepModuleValidator : IStepModuleValidator
    {
        public bool Validate(Type moduleType, IStep step)
        {
            var attributes = moduleType.GetCustomAttributes<ExcludedStepAttribute>().ToList();
            return attributes.Count <= 0 || attributes.SelectMany(stepConditionsAttribute =>
                stepConditionsAttribute.TargetSteps).All(stepType => 
                    stepType != step.GetType());
        }
    }
}
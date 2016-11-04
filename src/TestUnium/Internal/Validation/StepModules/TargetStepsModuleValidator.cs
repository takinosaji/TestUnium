using System;
using System.Linq;
using System.Reflection;
using TestUnium.Stepping.Modules.Conditions;
using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation.StepModules
{
    public class TargetStepsModuleValidator : IStepModuleValidator
    {
        public bool Validate(Type moduleType, IStep step)
        {
            var attributes = moduleType.GetCustomAttributes<TargetStepAttribute>().ToList();
            return attributes.Count <= 0 || attributes.SelectMany(stepConditionsAttribute =>
                    stepConditionsAttribute.TargetSteps).Any(stepType => 
                        stepType == step.GetType());
        }
    }
}
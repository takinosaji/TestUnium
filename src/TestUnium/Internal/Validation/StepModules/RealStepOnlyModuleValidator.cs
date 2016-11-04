using System;
using System.Reflection;
using TestUnium.Stepping.Modules.Conditions;
using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation.StepModules
{
    public class RealStepOnlyModuleValidator : IStepModuleValidator
    {
        public bool Validate(Type moduleType, IStep step)
        {
            var attribute = moduleType.GetCustomAttribute<RealStepOnlyAttribute>();
            return attribute == null || !step.IsFakeStep;
        }
    }
}
using System;
using System.Reflection;
using TestUnium.Stepping.Modules.Conditions;
using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation.StepModules
{
    public class FakeStepOnlyModuleValidator : IStepModuleValidator
    {
        public bool Validate(Type moduleType, IStep step)
        {
            var attribute = moduleType.GetCustomAttribute<FakeStepOnlyAttribute>();
            return attribute == null || step.IsFakeStep;
        }
    }
}
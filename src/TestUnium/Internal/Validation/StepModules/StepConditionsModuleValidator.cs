using System;
using System.Linq;
using System.Reflection;
using TestUnium.Stepping.Pipeline.Conditions;
using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation.StepModules
{
    public class StepConditionsModuleValidator : IStepModuleValidator
    {
        public bool Validate(Type moduleType, IStep step)
        {
            var attributes = moduleType.GetCustomAttributes<StepConditionsAttribute>();
            return attributes.All(stepConditionsAttribute =>
                stepConditionsAttribute.CheckerTypes.Select(checkerType =>
                    (IStepChecker)Activator.CreateInstance(checkerType)).All(checker =>
                       checker.Check(step)));
        }
    }
}
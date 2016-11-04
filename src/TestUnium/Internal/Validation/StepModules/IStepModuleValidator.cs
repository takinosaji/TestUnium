using System;
using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation.StepModules
{
    public interface IStepModuleValidator
    {
        Boolean Validate(Type moduleType, IStep step);
    }
}
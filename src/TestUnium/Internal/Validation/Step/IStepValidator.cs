using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation.Step
{
    public interface IStepValidator
    {
        IValidationResult Validate(IStep step);
    }
}

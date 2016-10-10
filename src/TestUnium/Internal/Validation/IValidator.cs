using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation
{
    public interface IValidator
    {
        IValidationResult Validate(IStep step);
    }
}

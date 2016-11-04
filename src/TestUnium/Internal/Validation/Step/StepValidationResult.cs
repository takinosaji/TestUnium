using System;

namespace TestUnium.Internal.Validation.Step
{
    public class StepValidationResult : IValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public StepValidationResult() : this(false, String.Empty) { }

        public StepValidationResult(Boolean isValid) : this(isValid, String.Empty) { }

        public StepValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}
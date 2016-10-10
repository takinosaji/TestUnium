using System;

namespace TestUnium.Internal.Validation
{
    public interface IValidationResult
    {
        Boolean IsValid { get; set; }
        String Message { get; set; }   
    }
}
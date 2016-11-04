using System;

namespace TestUnium.Stepping
{
    public class StepSetUpException : ApplicationException
    {
        public StepSetUpException(string message) : base(message)
        {
        }

        public StepSetUpException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
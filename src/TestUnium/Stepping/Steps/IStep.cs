using System;

namespace TestUnium.Stepping.Steps
{
    public interface IStep
    {
        Boolean IsFakeStep { get; }
        StepState State { get; set; }
        StepExceptionHandlingMode ExceptionHandlingMode { get; set; }
        Exception LastException { get; set; }
    }
}
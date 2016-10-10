using System;
using Ninject;

namespace TestUnium.Stepping.Steps
{
    public interface IStep
    {
        //IStepExecutor Executor { get; set; }
        Boolean IsFakeStep { get; }
        StepState State { get; set; }
        StepExceptionHandlingMode ExceptionHandlingMode { get; set; }
        Exception LastException { get; set; }
        void PreExecute();
    }
}
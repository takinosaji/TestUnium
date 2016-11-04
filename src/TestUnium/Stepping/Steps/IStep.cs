using System;
using Ninject;

namespace TestUnium.Stepping.Steps
{
    public interface IStep
    {
        IStepExecutor Executor { get; set; }
        String CallingMethodName { get; set; }
        String Name { get; }
        Boolean IsFakeStep { get; }
        StepState State { get; set; }
        StepExceptionHandlingMode ExceptionHandlingMode { get; set; }
        Exception LastException { get; set; }
        void PreExecute();
    }
}
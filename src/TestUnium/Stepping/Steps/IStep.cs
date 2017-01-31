using System;

namespace TestUnium.Stepping.Steps
{
    public interface IStep
    {
        IStepExecutor Executor { get; set; }
        /// <summary>
        /// Service method which is used by framework.
        /// </summary>
        String CallingMethodName { get; set; }
        String Name { get; }
        Boolean IsFakeStep { get; }
        StepState State { get; set; }
        /// <summary>
        /// Service property. Defines the way step runner will deal with exceptions arised in Step.
        /// It can consume exteption with continuation of test flow or rethrow it preventing program 
        /// from further execution if not intercepted by calling code. 
        /// </summary>
        StepExceptionHandlingMode ExceptionHandlingMode { get; set; }
        Exception LastException { get; set; }
        void PreExecute();
    }
}
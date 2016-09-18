using System;
using System.Reflection;

namespace TestUnium.Stepping.Steps
{
    public abstract class ExecutableStep
    {
        public StepState State { get; set; }
        public StepExceptionHandlingMode ExceptionHandlingMode {get; set; }
        public Exception LastException { get; set; }
        public Boolean IsFakeStep => GetType().GetCustomAttribute(typeof (FakeStepAttribute)) != null;

        protected ExecutableStep()
        {
            State = StepState.BeforeExecute;
        }
    }
}
using System;
using System.Reflection;
using Ninject;

namespace TestUnium.Stepping.Steps
{
    public abstract class ExecutableStepCore
    {
        public IStepExecutor Executor { get; set; }
        public String CallingMethodName { get; set; }
        public StepState State { get; set; }
        public StepExceptionHandlingMode ExceptionHandlingMode {get; set; }
        public Exception LastException { get; set; }
        public Boolean IsFakeStep => GetType().GetCustomAttribute(typeof (FakeStepAttribute)) != null;

        protected ExecutableStepCore()
        {
            State = StepState.BeforeExecute;
        }

        public virtual void PreExecute() { }
    }
}
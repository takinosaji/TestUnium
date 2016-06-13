using System;
using System.Configuration;
using System.Reflection;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class ExecutableStep
    {
        protected StepState State { get; set; }

        private Exception _excp;

        public Boolean IsFakeStep() => GetType().GetCustomAttribute(typeof (FakeStepAttribute)) != null;

        public Exception GetLastException() => _excp;

        public void SetException(Exception excp)
        {
            _excp = excp;
        }

        protected ExecutableStep()
        {
            State = StepState.BeforeExecute;
        }
    }
}
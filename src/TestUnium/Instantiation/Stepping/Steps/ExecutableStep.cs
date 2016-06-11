using System;
using System.Reflection;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class ExecutableStep
    {
        protected StepState State { get; set; }

        public Boolean IsFakeStep() => GetType().GetCustomAttribute(typeof (FakeStepAttribute)) != null;

        protected ExecutableStep()
        {
            State = StepState.BeforeExecute;
        }
    }
}
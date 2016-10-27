using System;
using System.Reflection;
using Ninject;
using TestUnium.Annotating;

namespace TestUnium.Stepping.Steps
{
    public abstract class ExecutableStepCore
    {
        public String Name
        {
            get
            {
                var nameAttr = (NameAttribute)GetType().GetCustomAttribute(typeof(NameAttribute));
                return nameAttr?.Name ?? GetType().Name;
            }
        } 

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
using System;

namespace TestUnium.Stepping.Pipeline.Conditions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExcludedStepAttribute : Attribute
    {
        public Type[] TargetSteps { get; set; }

        public ExcludedStepAttribute(params Type[] targetSteps)
        {
            TargetSteps = targetSteps;
        }
    }
}
using System;

namespace TestUnium.Stepping.Modules.Conditions
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
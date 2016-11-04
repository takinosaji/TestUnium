using System;

namespace TestUnium.Stepping.Modules.Conditions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TargetStepAttribute : Attribute
    {
        public Type[] TargetSteps { get; set; }

        public TargetStepAttribute(params Type[] targetSteps)
        {
            TargetSteps = targetSteps;
        }
    }
}
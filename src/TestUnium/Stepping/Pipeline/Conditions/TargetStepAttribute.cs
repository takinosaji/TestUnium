using System;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping.Pipeline.Conditions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TargetStepAttribute : Attribute
    {
        public Type[] TargetSteps { get; set; }

        public TargetStepAttribute(params Type[] targetSteps)
        {
            foreach (var targetStep in targetSteps)
            {
                if (!typeof(IStep).IsAssignableFrom(targetStep))
                    throw new ArgumentException($"TargetStepAttribute accepts only types that implement IStep interface. {targetStep.Name} doesn't implement IStep.");
            }
           
            TargetSteps = targetSteps;
        }
    }
}
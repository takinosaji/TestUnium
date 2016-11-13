using System;

namespace TestUnium.Stepping.Pipeline.Conditions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class StepConditionsAttribute : Attribute
    {
        public Type[] CheckerTypes { get; set; }
        public StepConditionsAttribute(params Type[] checkerTypes)
        {
            foreach (var type in checkerTypes)
            {
                if (!typeof(IStepChecker).IsAssignableFrom(type))
                    throw new IncorrectInheritanceException(new[] { type.Name }, new[] { nameof(IStepChecker) });
            }

            CheckerTypes = checkerTypes;
        }
    }
}
using System;

namespace TestUnium.Instantiation.Customization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class IgnoreIfAppliedAttribute : Attribute
    {
        private readonly Type _cancellationConditionType;

        public IgnoreIfAppliedAttribute(Type cancellationConditionType)
        {
            _cancellationConditionType = cancellationConditionType;
        }
    }
}
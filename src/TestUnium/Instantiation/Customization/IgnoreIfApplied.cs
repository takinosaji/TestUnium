using System;

namespace TestUnium.Instantiation.Customization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CancelIfAppliedAttribute : Attribute
    {
        private readonly Type _cancellationConditionType;

        public CancelIfAppliedAttribute(Type cancellationConditionType)
        {
            _cancellationConditionType = cancellationConditionType;
        }

        public Type GetCancelaltionType()
        {
            return _cancellationConditionType;
        }
    }
}
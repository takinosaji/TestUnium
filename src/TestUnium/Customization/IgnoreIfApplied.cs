using System;

namespace TestUnium.Customization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CancelIfAppliedAttribute : Attribute
    {
        private readonly Type[] _cancellationConditionTypes;

        public CancelIfAppliedAttribute(params Type[] cancellationConditionTypes)
        {
            _cancellationConditionTypes = cancellationConditionTypes;
        }

        public Type[] GetCancelaltionTypes()
        {
            return _cancellationConditionTypes;
        }
    }
}
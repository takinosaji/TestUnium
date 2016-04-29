using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestUnium.Instantiation.Prioritizing;

namespace TestUnium.Customization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class CustomizationBase : Attribute, IComparable<CustomizationBase>, ICancellable, ICustomizationAttribute
    {
        private readonly Type _targetType;
        public UInt16 Priority { get; set; }
        public Boolean Visible { get; set; }
        public List<Type> CancellationList { get; set; }

        protected CustomizationBase(Type targetType, IEnumerable<Type> cancellationCollection = null, UInt16 priority = 0)
        {
            if (cancellationCollection == null)
            {
                cancellationCollection = new List<Type>();
            }
            _targetType = targetType;
            Visible = true;        
            CancellationList = cancellationCollection.ToList();
            var attr = GetType().GetCustomAttribute(typeof(PriorityAttribute)) as PriorityAttribute;
            if (attr != null)
            {
                Priority = attr.Value;
                return;
            }
            Priority = priority;
        }

        public Boolean HasToBeCanceled(IEnumerable<Type> invocationList)
        {
            var result = false;
            CancellationList.ForEach(cancelItem =>
            {
                if (invocationList.Any(invItem => cancelItem.Name.Equals(invItem.Name)))
                {
                    result = true;
                }
            });
            return result;
        }

        /// <summary>
        /// Customiation attributes with priority == 0 are being processed at last turn inside each family.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CustomizationBase other)
        {
            var mineTargetType = GetCustomizationTargetType();
            var othersTargetType = other.GetCustomizationTargetType();
            if (!typeof(ICustomizationAttributeDrivenTest).IsAssignableFrom(mineTargetType))
                throw new IncorrectCustomizationTargetTypeException(mineTargetType.Name);
            if (!typeof(ICustomizationAttributeDrivenTest).IsAssignableFrom(othersTargetType))
                throw new IncorrectCustomizationTargetTypeException(othersTargetType.Name);
            if (mineTargetType.IsSubclassOf(othersTargetType)) return 1;
            if (othersTargetType.IsSubclassOf(mineTargetType)) return -1;
            return Priority == 0 ? 1 : other.Priority == 0 ? - 1 : Priority - other.Priority;
        }

        public Type GetCustomizationTargetType() => _targetType;
    }
}

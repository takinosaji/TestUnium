using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestUnium.Instantiation.Customization.Prioritizing;

namespace TestUnium.Instantiation.Customization
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class CustomizationAttribute : Attribute, IComparable<CustomizationAttribute>, ICancellable
    {
        //private readonly Type _targetType;
        public UInt16 Priority { get; set; }
        public Boolean Visible { get; set; }
        public List<Type> CancellationList { get; set; }

        protected CustomizationAttribute(UInt16 priority = 0) : this(null, priority) {}

        protected CustomizationAttribute(IEnumerable<Type> cancellationCollection, UInt16 priority = 0)
        {
            //if (!typeof(ICustomizationAttributeDrivenTest).IsAssignableFrom(targetType))
            //    throw new IncorrectInheritanceException(new[] { targetType.Name }, new[] { nameof(ICustomizationAttributeDrivenTest) });
            if (cancellationCollection == null)
            {
                cancellationCollection = new List<Type>();
            }
 
            Visible = true;        
            CancellationList = cancellationCollection.ToList();
            var attr = GetType().GetCustomAttribute<PriorityAttribute>();
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
        public int CompareTo(CustomizationAttribute other)
        {
            var mineTargetType = GetCustomizationTargetType();
            var othersTargetType = other.GetCustomizationTargetType();           
            if (mineTargetType.IsSubclassOf(othersTargetType)) return 1;
            if (othersTargetType.IsSubclassOf(mineTargetType)) return -1;
            return Priority == 0 ? 1 : other.Priority == 0 ? - 1 : Priority - other.Priority;
        }

        public Type GetCustomizationTargetType()
        {
            if (!typeof(ICustomizationAttributeDrivenTest).IsAssignableFrom(targetType))
                throw new IncorrectInheritanceException(new[] { targetType.Name }, new[] { nameof(ICustomizationAttributeDrivenTest) });
            return GetType().GetTypeInfo().GenericTypeArguments[0];
        }
    }
}

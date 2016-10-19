using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestUnium.Customization.Prioritizing;
using TestUnium.Extensions;
using TestUnium.Internal.Domain;

namespace TestUnium.Customization
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class CustomizationAttribute : Attribute, IComparable<CustomizationAttribute>, ICancellable
    {
        //private readonly Type _targetType;
        public UInt16 Priority { get; set; }
        public Boolean Visible { get; set; }
        public List<Type> CancellationList { get; set; }

        public Type TheOnlyRoot
        {
            get
            {
                var type = GetType();
                if (type.GetCustomAttribute<TheOnlyAttribute>() == null) return null;
                while (true)
                {
                    var baseType = type.BaseType;
                    var theOnly = baseType.GetCustomAttribute<TheOnlyAttribute>() != null;
                    if (!theOnly) break;
                    type = baseType;
                }

                return type;
            }
        }

        protected CustomizationAttribute(UInt16 priority = 0) : this(null, priority) {}

        protected CustomizationAttribute(IEnumerable<Type> cancellationCollection, UInt16 priority = 0)
        {
            Visible = true;
            CancellationCollectionInit(cancellationCollection);
            PriorityInit(priority);

        }

        private void CancellationCollectionInit(IEnumerable<Type> cancellationCollection)
        {
            CancellationList = new List<Type>();
            var cancellationAttrs = GetType().GetCustomAttributes<CancelIfAppliedAttribute>();
            if (cancellationAttrs != null)
            {
                foreach (var cancellationAttr in cancellationAttrs)
                {
                    CancellationList.AddRange(cancellationAttr.GetCancelaltionTypes());
                }
            }
            if (cancellationCollection != null)
            {
                CancellationList.AddRange(cancellationCollection);
            }
        }

        private void PriorityInit(UInt16 priority)
        {
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
            var mineType = GetType();
            var othersTType = other.GetType();
            var mineTargetType = GetCustomizationTargetType();
            var othersTargetType = other.GetCustomizationTargetType();           
            if (mineTargetType.IsSubclassOf(othersTargetType)) return Move.ToTheEnd.GetValue();
            if (othersTargetType.IsSubclassOf(mineTargetType)) return Move.ToTheHead.GetValue();
            if (mineType.IsSubclassOf(othersTType)) return Move.ToTheEnd.GetValue();
            if (othersTType.IsSubclassOf(mineType)) return Move.ToTheHead.GetValue();
            return Priority == 0 ? Move.ToTheEnd.GetValue() : other.Priority == 0 ? Move.ToTheHead.GetValue() : Priority - other.Priority;
        }

        public virtual void PostCustomize(Object context) { }

        public Type GetCustomizationTargetType()
        {
            var @interface = GetType().GetInterfaces().FirstOrDefault(i =>i.IsGenericType &&i.GetGenericTypeDefinition() == typeof(ICustomizer<>));
            if (@interface == null)
                throw new IncorrectInheritanceException(new[] { GetType().Name }, new[] { typeof(ICustomizer<>).Name });
            return @interface.GetGenericArguments()[0];
        }   
    }
}

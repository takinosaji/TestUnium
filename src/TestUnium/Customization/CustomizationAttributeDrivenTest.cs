using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TestUnium.Core;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;

namespace TestUnium.Customization
{
    public class CustomizationAttributeDrivenTest : ICustomizationAttributeDrivenTest
    {
        //Improve algorithm of avoiding initialization of customization attributes second and next times.
        private readonly List<Type> _invokedVisibleAttributes;
        private readonly List<Type> _invokedHiddenAttributes;

        protected readonly IReflectionService ReflectionService;

        protected CustomizationAttributeDrivenTest()
        {
            _invokedHiddenAttributes = new List<Type>();
            _invokedVisibleAttributes = new List<Type>();

            ReflectionService = CoreContainer.Instance.Current.Resolve<IReflectionService>();
        }

        /// <summary>
        /// Use this method in each derived class which contains members that could
        /// be configured via customization attributes.
        /// </summary>
        public void ApplyCustomization(Type targetType = null)
        {
            if (targetType == null)
            {
                targetType = GetType();
            }

            var attributeList = new List<CustomizationAttribute>(GetType().GetCustomAttributes<CustomizationAttribute>()
                .Where(a => a.GetType().GetInterfaces().Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(ICustomizer<>)))
                .Where(a => a.GetCustomizationTargetType().IsAssignableFrom(targetType))
                .Where(a => _invokedVisibleAttributes.All(i => i != a.GetType()) && _invokedHiddenAttributes.All(i => i != a.GetType())));
            if(attributeList.Count == 0) return;

            attributeList.Reverse();
            attributeList.Sort((f, s) => f.CompareTo(s));
            attributeList = ApplyTheOnlyPolicy(attributeList);
            attributeList.ForEach(a =>
            {
                if (a.HasToBeCanceled(_invokedVisibleAttributes)) return;
                ReflectionService.InvokeMethod(a, "Customize", this);
                ReflectionService.InvokeMethod(a, "PostCustomize", this);
                var visibilityAttr = a.GetType().GetCustomAttribute<VisibilityAttribute>();
                if (visibilityAttr == null || visibilityAttr.Visible || a.Visible)
                {
                    _invokedVisibleAttributes.Add(a.GetType());
                    return;
                }
                _invokedHiddenAttributes.Add(a.GetType());
            });
        }

        public List<CustomizationAttribute> ApplyTheOnlyPolicy(IEnumerable<CustomizationAttribute> customizationAttributes)
        {
            var attributeList = customizationAttributes.ToList();
            var theOnlys = attributeList.Where(attr => attr.GetType().GetCustomAttribute<TheOnlyAttribute>() != null).ToList();
            var theOnyLasts = theOnlys.GroupBy(t => t.TheOnlyRoot).Select(grp => grp.Last()).ToList();
            for (var i = attributeList.Count - 1; i >= 0 ; i--)
            {
                var attr = attributeList[i];
                if (theOnlys.Contains(attr) && !theOnyLasts.Contains(attr))
                {
                    attributeList.Remove(attr);
                }
            }

            return attributeList;
        }

        public List<Type> GetAppliedCustomizations() => _invokedHiddenAttributes; 
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TestUnium.Instantiation.Core;

namespace TestUnium.Instantiation.Customization
{
    public class CustomizationAttributeDrivenTest : KernelDrivenTest, ICustomizationAttributeDrivenTest
    {
        //Improve algorithm of avoiding initialization of customization attributes second and next times.
        private readonly List<Type> _invokedAttributes;
        private readonly List<Type> _hiddenAttributes;

        protected CustomizationAttributeDrivenTest()
        {
            _hiddenAttributes = new List<Type>();
            _invokedAttributes = new List<Type>();
            Kernel.Bind<ICustomizationAttributeDrivenTest>().ToConstant(this);
        }

        /// <summary>
        /// Use this method in each derived class which contains members that could
        /// be configured via customization attributes.
        /// </summary>
        public void ApplyCustomization()
        {
            var frame = new StackFrame(1);
            var callingMethod = frame.GetMethod();
            var targetType = callingMethod.DeclaringType ?? GetType();
            var attributeList = new List<CustomizationAttribute>(GetType().GetCustomAttributes<CustomizationAttribute>()
                .Where(a => a.GetType().GetInterfaces().Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(ICustomizer<>)))
                    .Where(a => targetType == a.GetCustomizationTargetType() || targetType.IsSubclassOf(a.GetCustomizationTargetType())));
            attributeList.Sort((f, s) => f.CompareTo(s));
            attributeList = ApplyTheOnlyPolicy(attributeList);
            attributeList.ForEach(a =>
            {
                if (_invokedAttributes.Any(i => i == a.GetType()) ||
                    _hiddenAttributes.Any(i => i == a.GetType())) return;
                if (a.HasToBeCanceled(_invokedAttributes)) return;
                var attrType = a.GetType();
                var method = attrType.GetMethod("Customize");
                if(method == null) throw new NullReferenceException($"Couldn't find Customize method in {attrType.FullName}");
                method.Invoke(a, new object[]{ this });
                var visibilityAttr = a.GetType().GetCustomAttribute<VisibilityAttribute>();
                if (visibilityAttr == null || visibilityAttr.Visible || a.Visible)
                {
                    _invokedAttributes.Add(a.GetType());
                    return;
                }
                _hiddenAttributes.Add(a.GetType());
            });
        }

        public List<CustomizationAttribute> ApplyTheOnlyPolicy(IEnumerable<CustomizationAttribute> customizationAttributes)
        {
            var attributeList = customizationAttributes.ToList();
            var theOnlys = attributeList.Where(attr => attr.GetType().GetCustomAttribute<TheOnlyAttribute>() != null).ToList();
            var theOnyLasts = theOnlys.GroupBy(t => t).Select(grp => grp.Last()).ToList();
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

        public List<Type> GetAppliedCustomizations() => _hiddenAttributes; 
    }
}
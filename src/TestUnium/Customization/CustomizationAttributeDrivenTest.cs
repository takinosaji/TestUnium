using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TestUnium.Bootstrapping;
using TestUnium.Instantiation.Prioritizing;
using TestUnium.Instantiation.WebDriving;
using TestUnium.Stepping;

namespace TestUnium.Customization
{
    public class CustomizationAttributeDrivenTest : StepDrivenTest, ICustomizationAttributeDrivenTest
    {
        protected readonly IEnumerable<Type> InvokedAttributes;
        private readonly IEnumerable<Type> _hiddenAttributes;

        protected CustomizationAttributeDrivenTest()
        {
            _hiddenAttributes = new List<Type>();
            InvokedAttributes = new List<Type>();
            Kernel.Bind<CustomizationAttributeDrivenTest>().ToConstant(this);
        }

        /// <summary>
        /// Use this method in each derived class which contains members that could
        /// be configured via customization attributes.
        /// </summary>
        public void ApplyCustomization()
        {
            var invList = (List<Type>)InvokedAttributes;
            var hidList = (List<Type>)_hiddenAttributes;
            var frame = new StackFrame(1);
            var callingMethod = frame.GetMethod();
            var targetType = callingMethod.DeclaringType ?? GetType();
            var attributeList = new List<CustomizationAttribute>(GetType().GetCustomAttributes(typeof(CustomizationAttribute))
                .Select(a => a as CustomizationAttribute)
                    .Where(a => a.GetType().GetInterfaces().Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(ICustomizationAttribute<>)))
                        .Where(a => a.GetCustomizationTargetType() == targetType || targetType.IsSubclassOf(a.GetCustomizationTargetType())));
            attributeList.Sort((f, s) => f.CompareTo(s));
            attributeList.ForEach(a =>
            {
                if (invList.Any(i => i == a.GetType()) ||
                    hidList.Any(i => i == a.GetType())) return;
                if (a.HasToBeCanceled(invList)) return;
                var attrType = a.GetType();
                var method = attrType.GetMethod("Customize");
                if(method == null) throw new NullReferenceException($"Couldn't find Customize method in {attrType.FullName}");
                method.Invoke(a, new object[]{ this });
                if (a.Visible)
                {
                    invList.Add(a.GetType());
                    return;
                }
                hidList.Add(a.GetType());
            });
        }
    }
}
using System;
using System.Collections.Generic;

namespace TestUnium.Customization
{
    public interface ICustomizationAttributeDrivenTest : ICustomizationTarget
    {
        /// <summary>
        /// Don't forget to pass targetType if you accept inheritance of test class where this method was invoked.
        /// </summary>
        /// <param name="targetType"></param>
        void ApplyCustomization(Type targetType = null);
        List<CustomizationAttribute> ApplyTheOnlyPolicy(IEnumerable<CustomizationAttribute> attributes);
        List<Type> GetAppliedCustomizations();
    }
}
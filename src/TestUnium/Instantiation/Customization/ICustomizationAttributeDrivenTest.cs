using System;
using System.Collections.Generic;

namespace TestUnium.Instantiation.Customization
{
    public interface ICustomizationAttributeDrivenTest
    {
        void ApplyCustomization();
        List<CustomizationAttribute> ApplyTheOnlyPolicy(IEnumerable<CustomizationAttribute> attributes);
        List<Type> GetAppliedCustomizations();
    }
}
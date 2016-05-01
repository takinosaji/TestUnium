using System;
using System.Collections.Generic;
using TestUnium.Customization;

namespace TestUnium.Instantiation.Prioritizing
{
    public interface ICustomizationAttributeDrivenTest
    {
        void ApplyCustomization();
        List<CustomizationAttribute> ApplyTheOnlyPolicy(IEnumerable<CustomizationAttribute> attributes);
        List<Type> GetAppliedCustomizations();
    }
}
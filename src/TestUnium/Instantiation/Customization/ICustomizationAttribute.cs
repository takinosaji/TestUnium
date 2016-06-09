using System;

namespace TestUnium.Instantiation.Customization
{
    public interface ICustomizationAttribute
    {
        Type GetCustomizationTargetType();
    }
}
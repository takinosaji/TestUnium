using System;

namespace TestUnium.Instantiation.Customization
{
    public interface ICustomizationAttribute<in TCustomizationTarget>
    {
        void Customize(TCustomizationTarget context);
    }

    public interface ICustomizationAttribute
    {
        Type GetCustomizationTargetType();
    }
}
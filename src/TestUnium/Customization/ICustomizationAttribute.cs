using System;

namespace TestUnium.Customization
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
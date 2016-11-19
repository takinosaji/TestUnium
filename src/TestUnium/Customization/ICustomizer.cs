using System;

namespace TestUnium.Customization
{
    public interface ICustomizer<in TCustomizationTarget>
        where TCustomizationTarget : ICustomizationTarget
    {
        Type TheOnlyRoot { get; }
        void PostCustomize(Object context);
        void Customize(TCustomizationTarget context);
        Type GetCustomizationTargetType();
    }
}
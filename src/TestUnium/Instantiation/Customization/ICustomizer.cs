using System;

namespace TestUnium.Instantiation.Customization
{
    public interface ICustomizer<in TCustomizationTarget>
        where TCustomizationTarget : ICustomizationAttributeDrivenTest
    {
        Type TheOnlyRoot { get; }
        void Customize(TCustomizationTarget context);
        Type GetCustomizationTargetType();
    }
}
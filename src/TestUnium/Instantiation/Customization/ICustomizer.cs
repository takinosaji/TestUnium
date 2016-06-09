using System;

namespace TestUnium.Instantiation.Customization
{
    public interface ICustomizer<in TCustomizationTarget>
        where TCustomizationTarget : ICustomizationAttributeDrivenTest
    {
        void Customize(TCustomizationTarget context);
    }
}
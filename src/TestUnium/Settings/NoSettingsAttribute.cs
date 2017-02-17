using System;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Settings
{   
    [Priority((UInt16)CustomizationAttributePriorities.NoSettings)]
    [AttributeUsage(AttributeTargets.Class)]
    public class NoSettingsAttribute : CustomizationAttribute, ICustomizer<ISettingsDrivenTest>
    {       
        public void Customize(ISettingsDrivenTest context) { }
    }
}
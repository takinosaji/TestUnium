using System;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Settings
{   
    [Priority((UInt16)CustomizationAttributePriorities.NoSettings)]
    [AttributeUsage(AttributeTargets.Class)]
    public class NoSettingsAttribute : CustomizationAttribute, ICustomizer<SettingsDrivenTest>
    {       
        public void Customize(SettingsDrivenTest context) { }
    }
}
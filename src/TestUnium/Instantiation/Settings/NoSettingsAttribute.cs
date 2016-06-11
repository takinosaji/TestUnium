using System;
using TestUnium.Common;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;

namespace TestUnium.Instantiation.Settings
{   
    [Priority((UInt16)CustomizationAttributePriorities.NoSettings)]
    [AttributeUsage(AttributeTargets.Class)]
    public class NoSettingsAttribute : CustomizationAttribute, ICustomizer<SettingsDrivenTest>
    {       
        public void Customize(SettingsDrivenTest context) { }
    }
}
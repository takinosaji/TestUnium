using System;
using System.Collections.Generic;
using TestUnium.Common;
using TestUnium.Customization;
using TestUnium.Instantiation.Prioritizing;

namespace TestUnium.Settings
{   
    [Priority((UInt16)CustomizationAttributePriorities.NoSettings)]
    [AttributeUsage(AttributeTargets.Class)]
    public class NoSettingsAttribute : CustomizationAttribute, ICustomizationAttribute<SettingsDrivenTest>
    {       
        public void Customize(SettingsDrivenTest context) { }

        public NoSettingsAttribute() : base(typeof(SettingsDrivenTest))
        {
        }
    }
}
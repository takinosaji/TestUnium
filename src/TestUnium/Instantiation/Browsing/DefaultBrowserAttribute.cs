using System;
using TestUnium.Common;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;
using TestUnium.Instantiation.WebDriving;

namespace TestUnium.Instantiation.Browsing
{
    [Priority((UInt16)CustomizationAttributePriorities.DefaultBrowser)]
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultBrowserAttribute : CustomizationAttribute, ICustomizer<WebDriverDrivenTest>
    {
        public Browser DefaultBrowser { get; set; }
        public DefaultBrowserAttribute(Browser defaultBrowser)
        {
            DefaultBrowser = defaultBrowser;
        }
        public void Customize(WebDriverDrivenTest context)
        {
            context.Browser = DefaultBrowser;
        }
    }
}

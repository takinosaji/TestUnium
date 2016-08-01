using System;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;
using TestUnium.Selenium.WebDriving;

namespace TestUnium.Selenium.Browsing
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

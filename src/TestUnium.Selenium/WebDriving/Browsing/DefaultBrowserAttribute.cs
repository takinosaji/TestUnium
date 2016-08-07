using System;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Selenium.WebDriving.Browsing
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

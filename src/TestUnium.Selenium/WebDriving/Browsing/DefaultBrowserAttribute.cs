using System;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Selenium.WebDriving.Browsing
{
    [Priority((UInt16)CustomizationAttributePriorities.DefaultBrowser)]
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultBrowserAttribute : CustomizationAttribute, ICustomizer<IWebDriverDrivenTest>
    {
        public Browser DefaultBrowser { get; set; }
        public DefaultBrowserAttribute(Browser defaultBrowser)
        {
            DefaultBrowser = defaultBrowser;
        }
        public void Customize(IWebDriverDrivenTest context)
        {
            context.Browser = DefaultBrowser;
        }
    }
}

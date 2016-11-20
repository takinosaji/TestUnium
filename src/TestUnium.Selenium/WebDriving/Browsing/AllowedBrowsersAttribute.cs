using System;
using System.Linq;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Selenium.WebDriving.Browsing
{
    [Priority((UInt16)CustomizationAttributePriorities.AllowedBrowsers)]
    [AttributeUsage(AttributeTargets.Class)]
    class AllowedBrowsersAttribute : CustomizationAttribute, ICustomizer<IWebDriverDrivenTest>
    {
    private readonly Browser[] _browsers;
        public AllowedBrowsersAttribute(params Browser[] browsers)
        {
            _browsers = browsers;
        }

        public void Customize(IWebDriverDrivenTest context)
        {
            if (_browsers.Length == 0) throw new NoAllowedBrowsersException();
            if (!_browsers.Any(b => b == context.Browser)) throw new BrowserNotAllowedException(context.Browser);
        }
    }
}

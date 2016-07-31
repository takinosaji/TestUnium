using System;
using System.Linq;
using TestUnium.Domain;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;
using TestUnium.Instantiation.WebDriving;

namespace TestUnium.Instantiation.Browsing
{
    [Priority((UInt16)CustomizationAttributePriorities.AllowedBrowsers)]
    [AttributeUsage(AttributeTargets.Class)]
    class AllowedBrowsersAttribute : CustomizationAttribute, ICustomizer<WebDriverDrivenTest>
    {
    private readonly Browser[] _browsers;
        public AllowedBrowsersAttribute(params Browser[] browsers)
        {
            _browsers = browsers;
        }

        public void Customize(WebDriverDrivenTest context)
        {
            if (_browsers.Length == 0) throw new NoAllowedBrowsersException();
            if (!_browsers.Any(b => b == context.Browser)) throw new BrowserNotAllowedException(context.Browser);
        }
    }
}

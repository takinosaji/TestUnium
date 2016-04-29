using System;
using System.Linq;
using TestUnium.Common;
using TestUnium.Customization;
using TestUnium.Instantiation.Prioritizing;
using TestUnium.Instantiation.WebDriving;

namespace TestUnium.Instantiation.Browsing
{
    [Priority((UInt16)CustomizationAttributePriorities.AllowedBrowsers)]
    [AttributeUsage(AttributeTargets.Class)]
    class AllowedBrowsersAttribute : CustomizationBase, ICustomizationAttribute<WebDriverDrivenTest>
    {
    private readonly Browser[] _browsers;
        public AllowedBrowsersAttribute(params Browser[] browsers) : base(typeof(WebDriverDrivenTest))
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

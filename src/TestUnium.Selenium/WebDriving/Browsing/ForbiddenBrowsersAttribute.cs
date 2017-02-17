using System;
using System.Linq;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Selenium.WebDriving.Browsing
{
    [Priority((UInt16)CustomizationAttributePriorities.ForbiddenBrowsers)]
    [AttributeUsage(AttributeTargets.Class)]
    public class ForbiddenBrowsersAttribute : CustomizationAttribute, ICustomizer<IWebDriverDrivenTest>
    {
        private readonly Browser[] _browsers;
        public ForbiddenBrowsersAttribute(params Browser[] browsers)
        {
            _browsers = browsers;
        }

        public void Customize(IWebDriverDrivenTest context)
        {
            var allBrowsers = Enum.GetValues(typeof(Browser));
            if (_browsers.Length == allBrowsers.Length) throw new NoAllowedBrowsersException();
            if (_browsers.Any(b => b == context.Browser)) throw new BrowserNotAllowedException(context.Browser);
        }
    }
}

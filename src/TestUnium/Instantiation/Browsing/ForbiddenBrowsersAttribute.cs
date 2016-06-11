using System;
using System.Linq;
using TestUnium.Common;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;
using TestUnium.Instantiation.WebDriving;

namespace TestUnium.Instantiation.Browsing
{
    [Priority((UInt16)CustomizationAttributePriorities.ForbiddenBrowsers)]
    [AttributeUsage(AttributeTargets.Class)]
    public class ForbiddenBrowsersAttribute : CustomizationAttribute, ICustomizer<WebDriverDrivenTest>
    {
        private readonly Browser[] _browsers;
        public ForbiddenBrowsersAttribute(params Browser[] browsers)
        {
            _browsers = browsers;
        }

        public void Customize(WebDriverDrivenTest context)
        {
            var allBrowsers = Enum.GetValues(typeof(Browser));
            if (_browsers.Length == allBrowsers.Length) throw new NoAllowedBrowsersException();
            if (_browsers.Any(b => b == context.Browser)) throw new BrowserNotAllowedException(context.Browser);
        }
    }
}

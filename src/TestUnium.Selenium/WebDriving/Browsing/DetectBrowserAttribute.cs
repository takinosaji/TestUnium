using System;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;
using TestUnium.Domain;

namespace TestUnium.Selenium.WebDriving.Browsing
{
    [Priority((UInt16)CustomizationAttributePriorities.DetectBrowser)]
    [AttributeUsage(AttributeTargets.Class)]
    class DetectBrowserAttribute : CustomizationAttribute, ICustomizer<WebDriverDrivenTest>
    {        
        public void Customize(WebDriverDrivenTest context)
        {
            var args = Environment.GetCommandLineArgs();
            var pos = Array.IndexOf(args, CommandLineArgsConstants.BrowserCmdArg);
            Browser browser;
            Enum.TryParse((pos != -1 && pos < args.Length - 1) ? args[pos + 1] : context.Browser.ToString(), out browser);
            context.Browser = browser;
        }
    }
}
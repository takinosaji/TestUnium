using System;
using System.Diagnostics.Contracts;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;
using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving.Browsing;

namespace TestUnium.Selenium.WebDriving
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.DefaultWebDriver)]
    public class WebDriverAttribute : CustomizationAttribute, ICustomizer<IWebDriverDrivenTest>
    {
        public virtual void Customize(IWebDriverDrivenTest context)
        {
            var settings = context.SettingsOfType<IWebSettings>();
            //Contract.Assert(context.Settings != null, $"Cannot initialize Chrome WebDriver in settingless test because of absence of IEDriverServer.exe filepath.");
            if (context.Settings == null)
                throw new InvalidOperationException($"Cannot initialize Chrome WebDriver in settingless test because of absence of IEDriverServer.exe filepath.");

            switch (context.Browser)
            {
                case Browser.Chrome:
                    var options = new ChromeOptions();
                    options.AddArgument("no-sandbox");
                    context.Driver =
                        new ChromeDriver(ChromeDriverService.CreateDefaultService(settings.ChromeDriverPath), options);
                    break;
                case Browser.InternetExplorer:
                    context.Driver =
                        new InternetExplorerDriver(
                            InternetExplorerDriverService.CreateDefaultService(settings.IeDriverPath));
                    break;
                case Browser.Firefox:
                default:
                    InitFirefoxDriver(context, settings);
                    break;
            }

            context.SmallWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(3));
            context.MediumWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(10));
            context.LongWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(30));
        }

        private void InitFirefoxDriver(IWebDriverDrivenTest context, IWebSettings settings)
        {
            var service = FirefoxDriverService.CreateDefaultService(settings.GeckoDriverPath);
            context.Driver = new FirefoxDriver(service);
        }
    }
}
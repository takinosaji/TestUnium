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
            switch (context.Browser)
            {
                case Browser.Firefox:  
                    var service = FirefoxDriverService.CreateDefaultService(settings.GeckoDriverPath);
                    context.Driver = new FirefoxDriver(service);       
                    break;
                case Browser.Chrome:
                    Contract.Assert(context.Settings != null, $"Cannot initialize Chrome WebDriver in settingless test because of absence of chromedriver.exe filepath.");
                    var options = new ChromeOptions();
                    options.AddArgument("no-sandbox");
                    context.Driver =
                        new ChromeDriver(ChromeDriverService.CreateDefaultService(settings.ChromeDriverPath), options);
                    break;
                case Browser.InternetExplorer:
                    Contract.Assert(context.Settings != null, $"Cannot initialize Chrome WebDriver in settingless test because of absence of IEDriverServer.exe filepath.");
                    context.Driver =
                        new InternetExplorerDriver(
                            InternetExplorerDriverService.CreateDefaultService(settings.IeDriverPath));
                    break;
                default:
                    context.Driver = new FirefoxDriver();
                    break;
            }

            context.SmallWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(3));
            context.MediumWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(10));
            context.LongWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(30));
        }
    }
}
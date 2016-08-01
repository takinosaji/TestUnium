using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;
using TestUnium.Selenium.Browsing;
using TestUnium.Selenium.Settings;

namespace TestUnium.Selenium.WebDriving
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.DefaultWebDriver)]
    public class WebDriverAttribute : CustomizationAttribute, ICustomizer<WebDriverDrivenTest>
    {
        public virtual void Customize(WebDriverDrivenTest context)
        {
            var settings = context.SettingsOfType<IWebSettings>();
            switch (context.Browser)
            {
                case Browser.Firefox:
                    context.Driver = new FirefoxDriver();
                    break;
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
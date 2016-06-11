using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using TestUnium.Instantiation.Browsing;
using TestUnium.Instantiation.Customization;

namespace TestUnium.Instantiation.WebDriving
{
    [TheOnly]
    public class WebDriverAttribute : CustomizationAttribute, ICustomizer<WebDriverDrivenTest>
    {
        public virtual void Customize(WebDriverDrivenTest context)
        {
            switch (context.Browser)
            {
                case Browser.Firefox:
                    context.Driver = new FirefoxDriver();
                    break;
                case Browser.Chrome:
                    context.Driver =
                        new ChromeDriver(ChromeDriverService.CreateDefaultService(context.Settings.ChromeDriverPath));
                    break;
                case Browser.InternetExplorer:
                    context.Driver =
                        new InternetExplorerDriver(
                            InternetExplorerDriverService.CreateDefaultService(context.Settings.IeDriverPath));
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
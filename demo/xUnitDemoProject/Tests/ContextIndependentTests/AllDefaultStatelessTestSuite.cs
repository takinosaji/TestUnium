using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using StepModules;
using Steps;
using TestUnium.Extensions;
using TestUnium.Instantiation.Browsing;
using TestUnium.Instantiation.WebDriving;
using Xunit;

namespace xUnitDemoProject.Tests.ContextIndependentTests
{
    /// <summary>
    /// TestSuite with default WebDriver initialization parameters.
    /// Pathes to InternetExplorerDriver and ChromeDriver and other settings are taken from defaults of SettingsBaseClass.
    /// </summary>
    //[DefaultBrowser(Browser.Chrome)] // Stating default browser to Chrome if applicable one hasn't been passed as command line argument.
    //[ForbiddenBrowsers(Browser.InternetExplorer)] // Filling up forbidden browsers for this test suite. If you try to run tests with forbidden browser, exception will be arised.  
    [WebDriverMobile]
    public class AllDefaultStatelessTestSuite : TestBase
    {
        public AllDefaultStatelessTestSuite()
        {
            // Registration and cancelling specific step modules
            RegisterStepModule<ThrowsExceptionModule>();
            UnregisterStepModule<ThrowsExceptionModule>();
        }

        [Fact]
        public void OpenGitHubTestCase()
        {
            Driver.Navigate().GoToUrl("http://github.com");
            var gitHubPage = Driver.GetPage<GitHubMainPage>();
            //Session.Include<UreusableSessionStepModule>(false).Start(context =>
            //{
            //    Do<GoToUrlStep>(s =>
            //    {
            //        s.Url = "http://github.com/takinosaji";
            //    });
            //    Do(() =>
            //    {
            //        Driver.Navigate().GoToUrl("http://github.com");
            //        var gitHubPage = Driver.GetPage<GitHubMainPage>();
            //        var stickyButton = gitHubPage.StikySignUpBtn();
            //        stickyButton.Click();
            //        Driver.Navigate().GoToUrl("http://github.com");
            //        stickyButton.Click();
            //    });
            //});
            //Do<GoToUrlStep>(s =>
            //{
            //    s.Url = "http://github.com/redheadTriss";
            //});
        }
    }
        public class WebDriverMobileAttribute : WebDriverAttribute
    {
        public override void Customize(WebDriverDrivenTest context)
        {
            switch (context.Browser)
            {
                case Browser.Firefox:
                    context.Driver = GetFirefoxDriver();
                    break;
                case Browser.Chrome:
                    var mobileEmulation = new Dictionary<String, String>();
                    mobileEmulation.Add("deviceName", "Samsung Galaxy S4");
                    var options = new ChromeOptions();
                    options.AddAdditionalCapability("mobileEmulation", mobileEmulation);
                    options.BinaryLocation = context.Settings.ChromeDriverPath;
                    //options.EnableMobileEmulation("Apple iPhone 5");
                    context.Driver = new ChromeDriver(options);
                    break;
                case Browser.InternetExplorer:
                    var optionsIe = new InternetExplorerOptions();
                    var mobileEmulationIe = new Dictionary<String, String>();
                    mobileEmulationIe.Add("deviceName", "Samsung Galaxy S4");
                    optionsIe.AddAdditionalCapability("mobileEmulation", mobileEmulationIe);
                    context.Driver = new InternetExplorerDriver(
                            InternetExplorerDriverService.CreateDefaultService(context.Settings.IeDriverPath), optionsIe);
                    break;
                default:
                    context.Driver = GetFirefoxDriver();
                    break;
            }

            context.SmallWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(3));
            context.MediumWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(10));
            context.LongWait = new WebDriverWait(context.Driver, TimeSpan.FromSeconds(30));
        }

        private IWebDriver GetFirefoxDriver()
        {
            var cap = DesiredCapabilities.Firefox();
            cap.SetCapability("browser", "Firefox");
            cap.SetCapability("platform", "MAC");
            cap.SetCapability("browserName", "iPhone");
            cap.SetCapability("device", "iPhone 5");
            return new FirefoxDriver(cap);
        }
    }
}

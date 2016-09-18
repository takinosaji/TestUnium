using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuztomizers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using StepModules;
using Steps;
using TestUnium.Selenium.Extensions;
using Xunit;

namespace xUnitDemoProject.Tests.ContextIndependentTests
{
    /// <summary>
    /// TestSuite with default WebDriver initialization parameters.
    /// Pathes to InternetExplorerDriver and ChromeDriver and other settings are taken from defaults of SettingsBaseClass.
    /// </summary>
    //[DefaultBrowser(Browser.Chrome)] // Stating default browser to Chrome if applicable one hasn't been passed as command line argument.
    //[ForbiddenBrowsers(Browser.InternetExplorer)] // Filling up forbidden browsers for this test suite. If you try to run tests with forbidden browser, exception will be arised.  
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
            Session.Include<UreusableSessionStepModule>(false).Start(context =>
            {
                Do<GoToUrlStep>(s =>
                {
                    s.Url = "http://github.com/takinosaji";
                });
                Do(() =>
                {
                    Driver.Navigate().GoToUrl("http://github.com");
                    var gitHubPage = Driver.GetPage<GitHubMainPage>();
                    if(!gitHubPage.IsLoaded) gitHubPage.Load(); //in case if our GitHubMainPage is lazy.
                    var stickyButton = gitHubPage.StickySignUpBtn();
                    stickyButton.Click();
                    Driver.Navigate().GoToUrl("http://github.com");
                    stickyButton.Click();
                });
            });
            Do<GoToUrlStep>(s =>
            {
                s.Url = "http://github.com/redheadTriss";
            });
        }
    }     
}
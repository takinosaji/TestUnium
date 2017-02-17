using PageObjects;
using Steps;
using Steps.Modules;
using TestUnium.Selenium.Extensions;
using TestUnium.Selenium.Stepping.Modules;
using Xunit;

namespace xUnitDemoProject.Tests.ContextIndependentTests
{
    /// <summary>
    /// TestSuite with default WebDriver initialization parameters.
    /// Pathes to InternetExplorerDriver and ChromeDriver and other settings are taken from defaults of SettingsBaseClass.
    /// </summary>
    // [DefaultBrowser(Browser.Chrome)] // Stating default browser to Chrome if applicable one hasn't been passed as command line argument.
    // [ForbiddenBrowsers(Browser.InternetExplorer)] // Filling up forbidden browsers for this test suite. If you try to run tests with forbidden browser, exception will be arised.  
    public class AllDefaultStatelessTestSuite : TestBase
    {
        public AllDefaultStatelessTestSuite()
        {
            // Registration and cancelling specific step modules
            RegisterStepModule<MakeScreenshotOnFailure>();
            //RegisterStepModule<ThrowsExceptionModule>();
            //UnregisterStepModule<ThrowsExceptionModule>();
        }

        [Fact]
        public void OpenGitHubTestCase()
        {
            Session.Include<UreusableSessionStepModule>().Start(context =>
            {
                Do<GoToUrlStep>(s =>
                {
                    s.Url = "http://github.com/takinosaji";
                });
                Do(() =>
                {
                    Driver.Navigate().GoToUrl("http://github.com");
                    var gitHubPage = Driver.GetPage<GitHubMainPage>();
                    if (!gitHubPage.IsLoaded) gitHubPage.Load(); //in case if our GitHubMainPage is lazy.
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
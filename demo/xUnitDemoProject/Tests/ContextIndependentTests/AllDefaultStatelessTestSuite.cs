using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObjects;
using TestUnium.Extensions;
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
        [Fact]
        public void OpenGitHubTestCase()
        {
            Driver.Navigate().GoToUrl("http://github.com");
            var gitHubPage = Driver.GetPageObject<GitHubMainPage>();
            var stickyButton = gitHubPage.StikySignUpBtn();
            stickyButton.Click();
            Driver.Navigate().GoToUrl("http://github.com");
            stickyButton.Click();
        }
    }
}

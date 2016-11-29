using System.Threading.Tasks;
using PageObjects;
using Steps;
using TestUnium.Global;
using TestUnium.Selenium.Extensions;
using TestUnium.Selenium.WebDriving.Browsing;
using TestUnium.Settings;
using Xunit;

namespace xUnitDemoProject.Tests.ContextIndependentTests.CustomSettingsTests
{
    /// <summary>
    /// TestSuite with default WebDriver initialization parameters.
    /// Browser may be configured via DefaultBrowser attributes.
    /// Path to ChromeDriver is overriden and is taken from known 'Settings' field fo CustomSettings type.
    /// </summary>
    [DefaultBrowser(Browser.Chrome)]
    [ForbiddenBrowsers(Browser.InternetExplorer)]
    [UseAppSettings(typeof(CustomSettings))]
    public class CustomAppSettingsTestSuite : TestBase
    {
        /// <summary>
        /// You may define new field of your custom settings type.
        /// </summary>
        public CustomSettings MySettings => Get.Settings<CustomSettings>();

        [Fact]
        public void OpenGitHubTestCase()
        {
            // You may retrieve a exact typed reference to your settings instance by invoking
            // Get.Settings<TSettingsType> where TSettingsType : SettingsBase method.
            var settings = Get.Settings<CustomSettings>(); 
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://github.com");
            var page = Driver.GetPage<GitHubMainPage>();            
            Driver.Navigate().GoToUrl("http://github.com" + settings.GitHubRepoSegment);
        }
    }
}

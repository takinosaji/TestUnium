using System;
using System.Collections.Generic;
using PageObjects;
using TestUnium.Bootstrapping;
using TestUnium.Extensions;
using TestUnium.Instantiation.Browsing;
using TestUnium.Instantiation.Settings;
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


    /// <summary>
    /// Custom settings class is being passed into TestBase class via type name surrounded with
    /// "typeof" operator as parameter to "Settings" attribute.
    /// </summary>
    public class CustomSettings : SettingsBase
    {
        public String GitHubRepoSegment { get; set; }
        /// <summary>
        /// Instantiating new settings entities. This instantiation code may appear useless 
        /// if exisitng settings file already has serialized values of your settings class fields.
        /// </summary>
        public CustomSettings()
        {
            GitHubRepoSegment = "/takinosaji/testunium";
        }
        /// <summary>
        /// Overriding some default settings values. Note that values filled up within a code in this method.
        /// </summary>
        public override void PostInitializationAction()
        {
            ChromeDriverPath = @"drivers";
        }
    }
    /// <summary>
    /// TestSuite with default WebDriver initialization parameters.
    /// Browser may be configured via DefaultBrowser attributes.
    /// Path to ChromeDriver is overriden and is taken from known 'Settings' field fo CustomSettings type.
    /// </summary>
    [DefaultBrowser(Browser.Chrome)]
    [ForbiddenBrowsers(Browser.InternetExplorer)]
    [Settings(typeof(CustomSettings))]
    public class CustomSettingsTestSuite : TestBase
    {
        /// <summary>
        /// You may define new field of your custom settings type to avoid using
        /// Get.Settings<TSettingsType> where TSettingsType : SettingsBase
        /// in each test method or step.
        /// </summary>
        public CustomSettings MySettings => Get.Settings<CustomSettings>();

        [Fact]
        public void OpenGitHubTestCase()
        {
            // You may retrieve a exact typed reference to your settings instance by invoking
            // Get.Settings<TSettingsType> where TSettingsType : SettingsBase method.
            var settings = Get.Settings<CustomSettings>(); 
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://github.com" + settings.GitHubRepoSegment);
        }
    }
}

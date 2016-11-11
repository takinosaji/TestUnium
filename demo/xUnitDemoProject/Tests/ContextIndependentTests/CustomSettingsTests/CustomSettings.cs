using System;
using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving.Browsing;

namespace xUnitDemoProject.Tests.ContextIndependentTests.CustomSettingsTests
{
    /// <summary>
    /// Custom settings class is being passed into TestBase class via type name surrounded with
    /// "typeof" operator as parameter to "Settings" attribute.
    /// </summary>
    public class CustomSettings : WebSettings
    {
        public Int32 SinsCount { get; set; }
        public Boolean ToBeOrNotToBe { get; set; }
        public Browser Browser { get; set; }
        public String GitHubRepoSegment { get; set; }
        /// <summary>
        /// Instantiating new settings entities. This instantiation code may appear useless 
        /// if exisitng settings file already has serialized values of your settings class fields.
        /// </summary>
        public CustomSettings()
        {
            GitHubRepoSegment = "/takinosaji/testunium";
        }
        public override void PostInitializeAction()
        {
            ChromeDriverPath = "drivers";
        }
    }
}

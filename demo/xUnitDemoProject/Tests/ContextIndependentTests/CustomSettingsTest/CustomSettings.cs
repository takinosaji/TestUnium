using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Selenium.Settings;

namespace xUnitDemoProject.Tests.ContextIndependentTests.CustomSettingsTest
{
    /// <summary>
    /// Custom settings class is being passed into TestBase class via type name surrounded with
    /// "typeof" operator as parameter to "Settings" attribute.
    /// </summary>
    public class CustomSettings : WebSettings
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
        public override void PostDeserializationAction()
        {
            ChromeDriverPath = "drivers";
        }
    }
}

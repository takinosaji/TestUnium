using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Instantiation.Settings;

namespace xUnitDemoProject.Tests.ContextIndependentTests.CustomSettingsTest
{
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
}

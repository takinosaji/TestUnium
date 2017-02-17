using TestUnium.Settings;
using Xunit;

namespace xUnitDemoProject.Tests.ContextIndependentTests.CustomSettingsTests
{
    /// <summary>
    /// TestSuite decorated with nosettings attribute doesn't load settings and ignores all customizations related to it. 
    /// </summary>
    [NoSettings]
    public class NoSettingsTestSuite : TestBase
    {
        //[Fact] //Doesnt make sense to execute this test since with Selenium 3 all browsers are accessible via driver executable.
        public void OpenGitHubTestCase()
        {
            // Settings field equals null in this case
           if (Settings != null) return;
           Driver.Manage().Window.Maximize();
           Driver.Navigate().GoToUrl("http://github.com");
        }
    }
}

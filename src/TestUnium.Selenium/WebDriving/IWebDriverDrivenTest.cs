using TestUnium.Selenium.WebDriving.Browsing;
using TestUnium.Settings;
using TestUnium.Stepping;

namespace TestUnium.Selenium.WebDriving
{
    public interface IWebDriverDrivenTest : IScreenshotMaker, IWebDriverContext, IBrowserContext, ISettingsDrivenTest
    {
        void ShutDownWebDriver();
    }
}
using TestUnium.Selenium.WebDriving.Browsing;

namespace TestUnium.Selenium.WebDriving
{
    public interface IWebDriverDrivenTest : IScreenshotMaker, IWebDriverContext, IBrowserContext
    {
        void ShutDownWebDriver();
    }
}
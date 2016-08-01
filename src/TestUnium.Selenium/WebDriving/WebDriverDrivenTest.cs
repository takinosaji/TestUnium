using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Settings;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Steps;
using TestUnium.Selenium.Browsing;
using TestUnium.Selenium.Extensions;
using TestUnium.Selenium.Paging;
using TestUnium.Selenium.Settings;

namespace TestUnium.Selenium.WebDriving
{
    public class WebDriverDrivenTest : SettingsDrivenTest, IWebDriverDrivenTest
    {
        public Browser Browser { get; set; }
        public IWebDriver Driver { get; set; }
        public IWait<IWebDriver> SmallWait { get; set; }
        public IWait<IWebDriver> MediumWait { get; set; }
        public IWait<IWebDriver> LongWait { get; set; }

        public WebDriverDrivenTest()
        {
            InjectionService.Inject(kernel =>
            {
                kernel.Bind<Browser>().ToMethod((ctx) => Browser);
                kernel.Bind<IWebDriverDrivenTest>().ToConstant(this);
                kernel.Bind<PageObject>().ToSelf();
                kernel.Bind<IWebDriver>().ToMethod(ctx => Driver);
                kernel.Bind<IWait<IWebDriver>>().ToMethod(ctx => SmallWait);
                kernel.Bind<IWait<IWebDriver>>().ToMethod(ctx => MediumWait);
                kernel.Bind<IWait<IWebDriver>>().ToMethod(ctx => LongWait);
            }, Kernel);
        }

        public void ShutDownWebDriver()
        {
            Driver?.Close();
        }
        public void MakeScreenshot()
        {
            if (Driver == null) throw new WebDriverHasNotBeenProperlyInitializedException();
            var ss = Driver.GetScreenshot();
            var screenshotName = "Screenshot_" +
                                 DateTime.Now.ToString(CultureInfo.InvariantCulture)
                                     .Replace(' ', '_')
                                     .Replace(':', '_') + ".png";
            ss.SaveAsFile(
                $"{Settings.ScreenshotSystemPath}{Path.PathSeparator}{GetType().FullName}{Path.PathSeparator}{screenshotName}",
                ImageFormat.Png);
        }
    }
}
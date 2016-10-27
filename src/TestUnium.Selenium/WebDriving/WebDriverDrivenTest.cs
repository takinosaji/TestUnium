using System;
using System.Diagnostics.Contracts;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Ninject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Selenium.Extensions;
using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving.Browsing;
using TestUnium.Selenium.WebDriving.Paging;
using TestUnium.Selenium.WebDriving.Screenshots;
using TestUnium.Settings;

namespace TestUnium.Selenium.WebDriving
{
    public class WebDriverDrivenTest : SettingsDrivenTest, IWebDriverDrivenTest, IScreenshotMaker
    {
        private readonly IMakeScreenshotStrategy _makeScreenshotStrategy;

        public Browser Browser { get; set; }
        public IWebDriver Driver { get; set; }
        public IWait<IWebDriver> SmallWait { get; set; }
        public IWait<IWebDriver> MediumWait { get; set; }
        public IWait<IWebDriver> LongWait { get; set; }

//#if DEBUG
        static WebDriverDrivenTest()
        {
            Container.Instance.Kernel.Load(Assembly.GetExecutingAssembly());
        }
//#endif

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
            _makeScreenshotStrategy = Container.Instance.Kernel.Get<IMakeScreenshotStrategy>();
        }

        public void ShutDownWebDriver()
        {
            Driver?.Quit();
        }

        public void MakeScreenshot([CallerMemberName] String callingMethodName = "")
        {
            Contract.Requires(Settings is IWebSettings, $"Type which is representing Settings in your test doesnt implement interface IWebSettings.");
            _makeScreenshotStrategy.MakeScreenshot(null, GetType(), callingMethodName, Driver, Settings as IWebSettings);
        }
    }
}
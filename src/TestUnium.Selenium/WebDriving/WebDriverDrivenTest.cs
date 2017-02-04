using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving.Browsing;
using TestUnium.Selenium.WebDriving.Paging;
using TestUnium.Selenium.WebDriving.Screenshots;
using TestUnium.Settings;

namespace TestUnium.Selenium.WebDriving
{
    public class WebDriverDrivenTest : SettingsDrivenTest, IWebDriverDrivenTest
    {
        private readonly IMakeScreenshotStrategy _makeScreenshotStrategy;

        public Browser Browser { get; set; }
        public IWebDriver Driver { get; set; }
        public IWait<IWebDriver> SmallWait { get; set; }
        public IWait<IWebDriver> MediumWait { get; set; }
        public IWait<IWebDriver> LongWait { get; set; }

#if DEBUG
        // This is very ugly. Need to think how to move this out.
        static WebDriverDrivenTest()
        {
            CoreContainer.Instance.Current.Install(FromAssembly.This());
        }
#endif

        public WebDriverDrivenTest()
        {
            InjectionService.Inject(container =>
            {
                container.Register(Component.For<IBrowserGetter>().UsingFactoryMethod(ctx => new BrowserGetterBase(this)).LifestyleSingleton());
                container.Register(Component.For<IWebDriverDrivenTest>().Instance(this).Named("IWebDriverDrivenTest"));
                container.Register(Component.For<PageObject>().ImplementedBy<PageObject>().LifestyleTransient());
                container.Register(Component.For<IWebDriver>().UsingFactoryMethod(ctx => Driver));
                container.Register(Component.For<IWait<IWebDriver>>().UsingFactoryMethod(ctx => SmallWait).Named("IWait<IWebDriver>_SmallWait"));
                container.Register(Component.For<IWait<IWebDriver>>().UsingFactoryMethod(ctx => MediumWait).Named("IWait<IWebDriver>_MediumWait"));
                container.Register(Component.For<IWait<IWebDriver>>().UsingFactoryMethod(ctx => LongWait).Named("IWait<IWebDriver>_LongWait"));
            }, Container);
            _makeScreenshotStrategy = CoreContainer.Instance.Current.Resolve<IMakeScreenshotStrategy>();
        }

        public void ShutDownWebDriver()
        {
            Driver?.Quit();
        }

        public String MakeScreenshot([CallerMemberName] String callingMethodName = "")
        {
            //Contract.Requires(Settings is IWebSettings, $"Type which is representing Settings in your test doesnt implement interface IWebSettings.");
            if(!(Settings is IWebSettings))
                throw new InvalidOperationException($"Type which is representing Settings in your test doesnt implement interface IWebSettings.");

            return _makeScreenshotStrategy.MakeScreenshot(null, GetType(), callingMethodName, Driver, Settings as IWebSettings);
        }
    }
}
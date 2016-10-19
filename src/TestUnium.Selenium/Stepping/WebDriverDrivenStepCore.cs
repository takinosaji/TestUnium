using System.Diagnostics.Contracts;
using Ninject;
using OpenQA.Selenium;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving;
using TestUnium.Selenium.WebDriving.Screenshots;
using TestUnium.Stepping.Steps.Settings;

namespace TestUnium.Selenium.Stepping
{
    public abstract class WebDriverDrivenStepCore : SettingsDrivenStepCore, IScreenshotMaker
    {
        private readonly IMakeScreenshotStrategy _makeScreenshotStrategy;

        [Inject]
        public IWebDriver Driver { get; set; }

        protected WebDriverDrivenStepCore()
        {
            _makeScreenshotStrategy = Container.Instance.Kernel.Get<IMakeScreenshotStrategy>();
        }

        public void MakeScreenshot()
        {
            Contract.Requires(Settings is IWebSettings, $"Type which is representing Settings in your test doesnt implement interface IWebSettings.");
            _makeScreenshotStrategy.MakeScreenshot(GetType(), Driver, Settings as IWebSettings);
        }
    }
}
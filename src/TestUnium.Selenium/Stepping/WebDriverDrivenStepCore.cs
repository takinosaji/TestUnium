using Ninject;
using OpenQA.Selenium;
using TestUnium.Stepping.Steps.Settings;

namespace TestUnium.Selenium.Stepping
{
    public abstract class WebDriverDrivenStepCore : SettingsDrivenStepCore
    {
        [Inject]
        public IWebDriver Driver { get; set; }
    }
}
using Ninject;
using OpenQA.Selenium;
using TestUnium.Instantiation.Settings;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class WebDriverStepCore : SettingsStep
    {
        [Inject]
        public IWebDriver Driver { get; set; }
    }
}
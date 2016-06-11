using Ninject;
using OpenQA.Selenium;
using TestUnium.Instantiation.Settings;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class WebDriverStepCore : SettingsBaseStep
    {
        [Inject]
        public IWebDriver Driver { get; set; }
    }
}
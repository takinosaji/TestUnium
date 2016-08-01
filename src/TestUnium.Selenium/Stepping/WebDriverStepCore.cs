using Ninject;
using OpenQA.Selenium;
using TestUnium.Instantiation.Stepping.Steps;
using TestUnium.Instantiation.Stepping.Steps.Settings;

namespace TestUnium.Selenium.Stepping
{
    public abstract class WebDriverStepCore : SettingsStep
    {
        [Inject]
        public IWebDriver Driver { get; set; }
    }
}
using Ninject;
using OpenQA.Selenium;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class WebDriverBaseStep : ExecutableStep
    {
        [Inject]
        public IWebDriver Driver { get; set; }
    }
}
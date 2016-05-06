using OpenQA.Selenium;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class WebDriverBaseStep : ExecutableStep
    {
        public IWebDriver Driver { get; set; }

        protected WebDriverBaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
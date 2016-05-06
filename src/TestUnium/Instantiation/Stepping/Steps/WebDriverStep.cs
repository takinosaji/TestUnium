using OpenQA.Selenium;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class WebDriverStep<T> : WebDriverBaseStep, IExecutableStep<T>
    {
        public abstract T Execute();

        protected WebDriverStep(IWebDriver driver) : base(driver) { }
    }

    public abstract class WebDriverStep : WebDriverBaseStep, IExecutableStep
    {
        public abstract void Execute();

        protected WebDriverStep(IWebDriver driver) : base(driver) { }
    }
}

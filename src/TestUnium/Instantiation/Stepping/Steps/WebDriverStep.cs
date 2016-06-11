using OpenQA.Selenium;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class WebDriverStep<T> : WebDriverStepCore, IExecutableStep<T>
    {
        public abstract T Execute();
    }

    public abstract class WebDriverStep : WebDriverStepCore, IExecutableStep
    {
        public abstract void Execute();
    }
}

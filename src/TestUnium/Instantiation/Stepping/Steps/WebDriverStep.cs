using OpenQA.Selenium;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class WebDriverStep<T> : WebDriverBaseStep, IExecutableStep<T>
    {
        public abstract T Execute();
    }

    public abstract class WebDriverStep : WebDriverBaseStep, IExecutableStep
    {
        public abstract void Execute();
    }
}

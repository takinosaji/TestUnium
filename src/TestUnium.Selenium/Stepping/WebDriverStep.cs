using TestUnium.Stepping.Steps;

namespace TestUnium.Selenium.Stepping
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

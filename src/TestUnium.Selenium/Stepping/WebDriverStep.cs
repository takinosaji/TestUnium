using TestUnium.Stepping.Steps;

namespace TestUnium.Selenium.Stepping
{
    public abstract class WebDriverStep<T> : WebDriverDrivenStepCore, IExecutableStep<T>
    {
        public abstract T Execute();
    }

    public abstract class WebDriverStep : WebDriverDrivenStepCore, IExecutableStep
    {
        public abstract void Execute();
    }
}

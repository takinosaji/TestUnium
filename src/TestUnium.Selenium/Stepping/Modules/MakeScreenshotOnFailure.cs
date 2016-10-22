using System.Diagnostics.Contracts;
using TestUnium.Selenium.WebDriving;
using TestUnium.Stepping;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace TestUnium.Selenium.Stepping.Modules
{
    [Reusable]
    public class MakeScreenshotOnFailure : IStepModule
    {
        public void BeforeExecution(IStep step) { }

        public void AfterExecution(IStep step, StepState state)
        {
            var executorMaker = step.Executor as IScreenshotMaker;
            var stepMaker = step as IScreenshotMaker;
            Contract.Assert(step != null || step.Executor != null, $"Type which is representing Step in your test doesnt implement interface IScreenshotMaker.");
            if (state != StepState.Failed) return;
            if (stepMaker != null)
            {
                stepMaker.MakeScreenshot(step.CallingMethodName);
                return;
            }
            executorMaker?.MakeScreenshot(step.CallingMethodName);
        }
    }
}
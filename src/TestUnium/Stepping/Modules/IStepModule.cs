using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping.Modules
{ 
    public interface IStepModule
    {
        void BeforeExecution(IStep step);
        void AfterExecution(IStep step, StepExecutionResult result);
    } 
}
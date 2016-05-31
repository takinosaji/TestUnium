using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping.Modules
{ 
    public interface IStepModule
    {
        Int32 ThreadId
        void BeforeExecution(IStep step);
        void AfterExecution(IStep step, StepExecutionResult result);
    } 
}
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping.Pipeline
{ 
    public interface IStepModule
    {
        void BeforeExecution(IStep step);
        void AfterExecution(IStep step, StepState state);
    } 
}
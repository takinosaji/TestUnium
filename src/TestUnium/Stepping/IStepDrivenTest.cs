using TestUnium.Customization;
using TestUnium.Sessioning;
using TestUnium.Stepping.Pipeline;

namespace TestUnium.Stepping
{
    public interface IStepDrivenTest : IStepExecutor, IStepModuleRegistrator, ISessionDrivenTest
    {
        
    }
}
using TestUnium.Sessioning;
using TestUnium.Settings;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace TestUnium
{
    [UseSessionContext(typeof(ContextBase))]
    [UseStepRunner(typeof(StepRunnerBase))]
    [UseStepModulesRegistrationStrategy(typeof(BasicStepModuleRegistrationStrategy))]
    public class TestCore : SettingsDrivenTest { }
}
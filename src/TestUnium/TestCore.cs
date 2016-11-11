using TestUnium.Sessioning;
using TestUnium.Settings;
using TestUnium.Stepping;
using TestUnium.Stepping.Steps;

namespace TestUnium
{
    [SessionContext(typeof(ContextBase))]
    [StepRunner(typeof(StepRunnerBase))]
    public class TestCore : SettingsDrivenTest { }
}
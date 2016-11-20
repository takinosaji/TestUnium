using TestUnium.Sessioning;
using TestUnium.Settings;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;

namespace TestUnium
{
    [UseSessionWithContext(typeof(SessionBase), typeof(ContextBase))]
    [UseStepRunner(typeof(StepRunnerBase))]
    [UseStepModulesRegistrationStrategy(typeof(BasicStepModuleRegistrationStrategy))]
    [UseAppSettings(typeof(SettingsBase))]
    public class TestCore : SettingsDrivenTest { }
}
using Ninject;
using TestUnium.Core;
using TestUnium.Core.Configuration;
using TestUnium.Sessioning;
using TestUnium.Settings;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace TestUnium
{
    [UseSessionWithContext(typeof(SessionBase), typeof(ContextBase))]
    [UseStepRunner(typeof(StepRunnerBase))]
    [UseStepModulesRegistrationStrategy(typeof(BasicStepModuleRegistrationStrategy))]
    [UseAppSettings(typeof(SettingsBase))]
    public class TestCore : SettingsDrivenTest { }
}
using TestUnium.Core;
using TestUnium.Core.Configuration;
using TestUnium.Sessioning;
using TestUnium.Settings;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Pipeline.Registration;
using TestUnium.Stepping.Pipeline.Registration.Customization;

namespace TestUnium
{
    [UseSessionWithContext(typeof(SessionBase), typeof(ContextBase))]
    [UseStepRunner(typeof(StepRunnerBase))]
    [UseStepModulesRegistrationStrategyForTest(typeof(InTestStepModuleRegistrationStrategy))]
    [UseAppSettings(typeof(SettingsBase))]
    [ConfigureContainer(typeof(StandardContainerConfigurer))]
    public class TestCore : SettingsDrivenTest { }
}
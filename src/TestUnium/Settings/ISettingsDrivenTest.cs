using TestUnium.Stepping;

namespace TestUnium.Settings
{
    public interface ISettingsDrivenTest : IStepDrivenTest, ISettingsContext
    {
        TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : class, ISettings;
    }
}
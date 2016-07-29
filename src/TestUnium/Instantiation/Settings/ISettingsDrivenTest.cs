using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Stepping;

namespace TestUnium.Instantiation.Settings
{
    public interface ISettingsDrivenTest
    {
        TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : ISettings;
    }
}
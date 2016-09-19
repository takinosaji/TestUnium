namespace TestUnium.Settings
{
    public interface ISettingsDrivenTest
    {
        TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : ISettings;
    }
}
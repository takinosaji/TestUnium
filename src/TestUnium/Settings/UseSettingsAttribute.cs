using TestUnium.Customization;

namespace TestUnium.Settings
{
    public abstract class UseSettingsAttribute : CustomizationAttribute, ICustomizer<SettingsDrivenTest>
    {
        protected UseSettingsAttribute() : base(new[]
        {
            typeof(NoSettingsAttribute)
        }) { }

        public abstract void Customize(SettingsDrivenTest context);
    }
}
using TestUnium.Customization;

namespace TestUnium.Settings
{
    public abstract class UseSettingsAttribute : CustomizationAttribute, ICustomizer<ISettingsDrivenTest>
    {
        protected UseSettingsAttribute() : base(new[]
        {
            typeof(NoSettingsAttribute)
        }) { }

        public abstract void Customize(ISettingsDrivenTest context);
    }
}
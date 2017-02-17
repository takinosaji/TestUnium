using Castle.MicroKernel.Registration;
using TestUnium.Internal.Settings;
using TestUnium.Stepping;

namespace TestUnium.Settings
{
    public class SettingsDrivenTest : StepDrivenTest, ISettingsDrivenTest
    {
        public ISettings Settings { get; set; }

        public SettingsDrivenTest()
        {
            Container.Register(Component.For<ISettings>().UsingFactoryMethod(s => Settings ?? new NullSettings()));
            Container.Register(Component.For<ISettingsDrivenTest>().Instance(this).Named("ISettingsDrivenTest"));
        }

        public TSettingsBase SettingsOfType<TSettingsBase>() 
            where TSettingsBase : class, ISettings
        {
            var settings = Container.Resolve<ISettings>();
            return settings.GetType().Name.Equals(nameof(NullSettings))
                ? null 
                :(TSettingsBase) settings;
        }
    }
}
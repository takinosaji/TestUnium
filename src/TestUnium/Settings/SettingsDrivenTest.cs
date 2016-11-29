using Castle.MicroKernel.Registration;
using TestUnium.Stepping;

namespace TestUnium.Settings
{
    public class SettingsDrivenTest : StepDrivenTest, ISettingsDrivenTest
    {
        public ISettings Settings { get; set; }

        public SettingsDrivenTest()
        {
            Container.Register(Component.For<ISettings>().UsingFactoryMethod(s => Settings));
            Container.Register(Component.For<ISettingsDrivenTest>().Instance(this).Named("ISettingsDrivenTest"));
        }

        public TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : ISettings => (TSettingsBase)Container.Resolve<ISettings>(); 
    }
}
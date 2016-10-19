using Ninject;
using TestUnium.Stepping;

namespace TestUnium.Settings
{
    public class SettingsDrivenTest : StepDrivenTest, ISettingsDrivenTest
    {
        public ISettings Settings { get; set; }

        public SettingsDrivenTest()
        {
            Kernel.Bind<ISettings>().ToMethod(ctx => Settings);
            Kernel.Bind<ISettingsDrivenTest>().ToConstant(this);
        }

        public TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : ISettings => (TSettingsBase)Kernel.Get<ISettings>(); 
    }
}
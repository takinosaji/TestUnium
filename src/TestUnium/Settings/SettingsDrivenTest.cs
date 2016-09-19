using Ninject;
using TestUnium.Stepping;

namespace TestUnium.Settings
{
    public class SettingsDrivenTest : StepDrivenTest, ISettingsDrivenTest
    {
        public ISettings Settings { get; set; }

        public SettingsDrivenTest()
        {
            InjectionService.Inject(kernel =>
            {
                kernel.Bind<ISettings>().ToMethod(ctx => Settings);
                Kernel.Bind<ISettingsDrivenTest>().ToConstant(this);
            }, Kernel);
        }

        public TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : ISettings => (TSettingsBase)Kernel.Get<ISettings>(); 
    }
}
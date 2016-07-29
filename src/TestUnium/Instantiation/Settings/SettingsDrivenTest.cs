using Ninject;
using TestUnium.Bootstrapping;
using TestUnium.Common;
using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Stepping;

namespace TestUnium.Instantiation.Settings
{
    [Settings(typeof(SettingsBase))]
    public class SettingsDrivenTest : StepDrivenTest, ISettingsDrivenTest
    {
        public ISettings Settings { get; set; }

        public SettingsDrivenTest()
        {
            InjectionHelper.Inject(kernel =>
            {
                kernel.Bind<ISettings>().ToMethod(ctx => Settings);
                Kernel.Bind<ISettingsDrivenTest>().ToConstant(this);
            }, Kernel);
        }

        public TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : ISettings => (TSettingsBase)Kernel.Get<ISettings>(); 
    }
}
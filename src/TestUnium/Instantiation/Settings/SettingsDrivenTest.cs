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
        public SettingsBase Settings { get; set; }

        public SettingsDrivenTest()
        {
            InjectionHelper.Inject(kernel =>
            {
                kernel.Bind<ISettingsSource>().ToMethod((ctx) => Settings);
            }, Resolver.Instance.Kernel, Kernel);
            Kernel.Bind<SettingsDrivenTest>().ToConstant(this);
        }

        public TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : ISettingsSource
        {
            return (TSettingsBase)Kernel.Get<ISettingsSource>();
        }
    }
}
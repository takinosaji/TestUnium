using Ninject;
using TestUnium.Bootstrapping;
using TestUnium.Instantiation.Sessioning;

namespace TestUnium.Instantiation.Settings
{
    [Settings(typeof(SettingsBase))]
    public class SettingsDrivenTest : SessionDrivenTest, ISettingsDrivenTest
    {
        public SettingsBase Settings { get; set; }

        public SettingsDrivenTest()
        {
            Kernel.Bind<ISettingsSource>().ToMethod((ctx) => Settings);
            Kernel.Bind<SettingsDrivenTest>().ToConstant(this);
            Resolver.Instance.Kernel.Bind<ISettingsSource>().ToMethod((ctx) => Settings);
        }

        public TSettingsBase SettingsOfType<TSettingsBase>() where TSettingsBase : ISettingsSource
        {
            return (TSettingsBase)Kernel.Get<ISettingsSource>();
        }
    }
}
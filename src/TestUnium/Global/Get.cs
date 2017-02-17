using Castle.Windsor;
using TestUnium.Internal;
using TestUnium.Settings;

namespace TestUnium.Global
{
    public static class Get
    {
        public static TSettingsBase Settings<TSettingsBase>() where TSettingsBase : ISettings
        {
            return (TSettingsBase)Resolver.Instance.CurrentContainer.Resolve<ISettings>();
        }

        public static IWindsorContainer TestContextContainer => Resolver.Instance.CurrentContainer;

        //public static TTest TestClassInstance<TTest>() where TTest : ICustomizationTarget
        //{
        //    return (TTest)Resolver.Instance.CurrentContainer.Get<ICustomizationTarget>();
        //}
    }
}

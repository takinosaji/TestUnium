using Ninject;
using TestUnium.Internal;
using TestUnium.Settings;

namespace TestUnium.Global
{
    public static class Get
    {
        public static TSettingsBase Settings<TSettingsBase>() where TSettingsBase : ISettings
        {
            return (TSettingsBase)Resolver.Instance.Kernel.Get<ISettings>();
        }

        public static IKernel TestContextKernel => Resolver.Instance.Kernel;

        //public static TTest TestClassInstance<TTest>() where TTest : ICustomizationTarget
        //{
        //    return (TTest)Resolver.Instance.Kernel.Get<ICustomizationTarget>();
        //}
    }
}

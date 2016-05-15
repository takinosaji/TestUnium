using Ninject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestUnium.Instantiation.Settings;
using TestUnium.Paging;

namespace TestUnium.Bootstrapping
{
    public static class Get
    {
        public static TSettingsBase Settings<TSettingsBase>() where TSettingsBase : ISettings
        {
            return (TSettingsBase)Resolver.Instance.Kernel.Get<ISettings>();
        }

        //public static TTest TestClassInstance<TTest>() where TTest : ICustomizationTarget
        //{
        //    return (TTest)Resolver.Instance.Kernel.Get<ICustomizationTarget>();
        //}
    }
}

using System;
using System.Configuration;
using Ninject;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;

namespace TestUnium.Settings
{
    public class AppSettingsAttribute : SettingsAttribute
    {
        private readonly IReflectionService _reflectionService;

        public AppSettingsAttribute(Type settingsType, bool loadFromFile = true, bool createFileIfNotExist = true)
            : base(settingsType, loadFromFile, createFileIfNotExist)
        {
            _reflectionService = Container.Instance.Kernel.Get<IReflectionService>();
        }

        public override void Customize(SettingsDrivenTest context)
        {
            context.Settings = (ISettings)Activator.CreateInstance(SettingsType);
            
        }
    }
}
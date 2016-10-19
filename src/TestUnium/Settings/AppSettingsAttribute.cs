using System;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Ninject;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;

namespace TestUnium.Settings
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.Settings)]
    [AttributeUsage(AttributeTargets.Class)]
    public class AppSettingsAttribute : CustomizationAttribute, ICustomizer<SettingsDrivenTest>
    {
        private readonly IReflectionService _reflectionService;

        protected ISettings Settings;
        protected readonly Type SettingsType;

        public AppSettingsAttribute(Type settingsType) 
            : base(new []
            {
                typeof(NoSettingsAttribute)
            })
        {
            if (!typeof(ISettings).IsAssignableFrom(settingsType))
                throw new IncorrectInheritanceException(new[] { settingsType.Name }, new[] { nameof(SettingsBase) });

            _reflectionService = Container.Instance.Kernel.Get<IReflectionService>();

            SettingsType = settingsType;
        }


        public virtual void Customize(SettingsDrivenTest context)
        {
            context.Settings = (ISettings)Activator.CreateInstance(SettingsType);        
            Settings = context.Settings;

            foreach (var property in _reflectionService.GetAllProperties(SettingsType, BindingFlags.Public | BindingFlags.Instance))
            {
                var appSettingsValue = $"{context.Settings.GetType().Name}.{property.Name}";
                if (!ConfigurationManager.AppSettings.AllKeys.Any(k => k.Equals(appSettingsValue))) continue;
                var method = property.PropertyType.GetMethod("Parse", new []{typeof(String)});
                Contract.Assert(property.PropertyType == typeof(String) || method != null || property.PropertyType.IsEnum, 
                    $"Cannot assign string value from AppSettings to a non-string property {property.Name} of type {property.PropertyType}.");
                if (property.PropertyType == typeof(String))
                {
                    property.SetValue(context.Settings, ConfigurationManager.AppSettings[appSettingsValue]);
                    continue;
                }
                property.SetValue(context.Settings, !property.PropertyType.IsEnum ? 
                    method.Invoke(null, new object[] { ConfigurationManager.AppSettings[appSettingsValue] })
                    : Enum.Parse(property.PropertyType, ConfigurationManager.AppSettings[appSettingsValue]));
            }
        }

        public override void PostCustomize(Object context)
        {
            Settings?.PostInitializeAction();
        }
    }
}
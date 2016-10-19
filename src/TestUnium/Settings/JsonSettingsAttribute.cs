﻿using System;
using System.IO;
using Newtonsoft.Json;
using Ninject;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Domain;
using TestUnium.Internal.Services;

namespace TestUnium.Settings
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.Settings)]
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingsAttribute : CustomizationAttribute, ICustomizer<SettingsDrivenTest>
    {
        protected readonly Type SettingsType;
        protected readonly Boolean LoadFromFile;
        protected readonly Boolean CreateFileIfNotExist;

        private readonly IShellService _shellService;

        public SettingsAttribute(Type settingsType, Boolean loadFromFile = true, Boolean createFileIfNotExist = true) 
            : base(new []
            {
                typeof(NoSettingsAttribute)
            })
        {
            if (!typeof(ISettings).IsAssignableFrom(settingsType))
                throw new IncorrectInheritanceException(new[] { settingsType.Name }, new [] { nameof(SettingsBase)});

            _shellService = Container.Instance.Kernel.Get<IShellService>();

            SettingsType = settingsType;
            LoadFromFile = loadFromFile;
            CreateFileIfNotExist = createFileIfNotExist;
        }  

        public virtual void Customize(SettingsDrivenTest context)
        {
            context.Settings = (ISettings)Activator.CreateInstance(SettingsType);

            var settingsFilePath = _shellService.TryGetArg(CommandLineArgsConstants.SettingsCmdArg, "settings.json");

            if (File.Exists(settingsFilePath))
            {
                if (LoadFromFile)
                {
                    context.Settings =
                        (ISettings) JsonConvert.DeserializeObject(File.ReadAllText(settingsFilePath), SettingsType);
                }
            }
            else
            {
                if (CreateFileIfNotExist)
                {
                    //context.Settings = (ISettings) Activator.CreateInstance(context.Settings.GetType());
                    File.WriteAllText(settingsFilePath,
                        JsonConvert.SerializeObject(context.Settings, Formatting.Indented));
                }
            }

            context.Settings.PostDeserializationAction();
        }
    }
}
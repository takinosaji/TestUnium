using System;
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
    public class JsonSettingsAttribute : AppSettingsAttribute
    {
        private readonly IShellService _shellService;
        protected readonly Boolean LoadFromFile;
        protected readonly Boolean CreateFileIfNotExist;

        public JsonSettingsAttribute(Type settingsType, bool loadFromFile = true, bool createFileIfNotExist = true)
            : base(settingsType)
        {
            _shellService = Container.Instance.Kernel.Get<IShellService>();

            LoadFromFile = loadFromFile;
            CreateFileIfNotExist = createFileIfNotExist;
        }

        public override void Customize(SettingsDrivenTest context)
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

            Settings = context.Settings;
        }
    }
}
using System;
using System.IO;
using Newtonsoft.Json;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Domain;
using TestUnium.Internal.Services;

namespace TestUnium.Settings
{
    public class UseJsonSettingsAttribute : UseAppSettingsAttribute
    {
        private readonly IShellService _shellService;
        protected readonly Boolean LoadFromFile;
        protected readonly Boolean CreateFileIfNotExist;

        public UseJsonSettingsAttribute(Type settingsType, bool loadFromFile = true, bool createFileIfNotExist = true)
            : base(settingsType)
        {
            _shellService = CoreContainer.Instance.Current.Resolve<IShellService>();

            LoadFromFile = loadFromFile;
            CreateFileIfNotExist = createFileIfNotExist;
        }

        public override void Customize(ISettingsDrivenTest context)
        {
            context.Settings = (ISettings)Activator.CreateInstance(SettingsType);

            Settings = context.Settings;
            Settings.Context = context;

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
        }
    }
}
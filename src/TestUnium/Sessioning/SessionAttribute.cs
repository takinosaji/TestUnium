using System;
using System.IO;
using Newtonsoft.Json;
using TestUnium.Common;
using TestUnium.Customization;
using TestUnium.Instantiation.Prioritizing;
using TestUnium.Sessioning;

namespace TestUnium.Settings
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.Settings)]
    [AttributeUsage(AttributeTargets.Class)]
    public class SessionAttribute : CustomizationBase, ICustomizationAttribute<SessionDrivenTest>
    {
        private readonly Type _sessionType;
        private readonly Type _sessionContextType;

        public SessionAttribute(Type sessionType, Type sessionContextType) 
        {
            if (!typeof(ISettingsSource).IsAssignableFrom(sessionType) || !typeof(ISessionContext).IsAssignableFrom(sessionType))
                throw new IncorrectCustomizationSourceTypeException(settingsType.Name, nameof(SettingsBase));
            _settingsType = settingsType;
            _loadFromFile = loadFromFile;
            _createFileIfNotExist = createFileIfNotExist;
        }  

        public virtual void Customize(SessionDrivenTest context)
        {
            context.Settings = (SettingsBase)Activator.CreateInstance(_settingsType);

            var args = Environment.GetCommandLineArgs();
            var pos = Array.IndexOf(args, CommandLineArgsConstants.SettingsCmdArg);
            var settingsFilePath = (pos != -1 && pos < args.Length - 1) ? args[pos + 1] : "settings.json";


            if (File.Exists(settingsFilePath))
            {
                if (_loadFromFile)
                {
                    context.Settings =
                        (SettingsBase) JsonConvert.DeserializeObject(File.ReadAllText(settingsFilePath), _settingsType);
                }
            }
            else
            {
                if (_createFileIfNotExist)
                {
                    context.Settings = (SettingsBase) Activator.CreateInstance(context.Settings.GetType());
                    File.WriteAllText(settingsFilePath,
                        JsonConvert.SerializeObject(context.Settings, Formatting.Indented));
                }
            }


            context.Settings.PostInitializationAction();
        }
    }
}
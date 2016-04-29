using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TestUnium.Common;
using TestUnium.Customization;
using TestUnium.Instantiation.Prioritizing;
using TestUnium.Sessioning;

namespace TestUnium.Settings
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.Session)]
    [AttributeUsage(AttributeTargets.Class)]
    public class SessionAttribute : CustomizationBase, ICustomizationAttribute<SessionDrivenTest>
    {
        private readonly Type _sessionType;
        private readonly Type _sessionContextType;

        public SessionAttribute(Type sessionType, Type sessionContextType) : base(typeof(SessionDrivenTest))
        {
            if (!typeof(ISettingsSource).IsAssignableFrom(sessionType) || !typeof(ISessionContext).IsAssignableFrom(sessionType))
                throw new IncorrectCustomizationSourceTypeException(new List<String> { sessionType.Name, sessionContextType.Name },
                    new List<String> { nameof(ISession), nameof(ISessionContext)});
            _sessionType = sessionType;
            _sessionContextType = sessionContextType;
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
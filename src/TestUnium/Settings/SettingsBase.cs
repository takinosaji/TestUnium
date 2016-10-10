using System;

namespace TestUnium.Settings
{
    [Serializable]
    public class SettingsBase : ISettings
    {
        public String LogSystemPath { get; set; }
        public String LogUrlPath { get; set; }
        public Int32 LogFolderCapacity { get; set; }

        //public static event Action<SettingsBase> PostDeserializationActions;
       
        public SettingsBase()
        {
            LogSystemPath = "logs";
            LogUrlPath = String.Empty;
            LogFolderCapacity = 50;
        }

        /// <summary>
        /// Override this method for performing settings changing 
        /// without modifying current settings file on a hard drive.
        /// </summary>
        public virtual void PostDeserializationAction(){}
        //public virtual void PostDeserializationAction() => PostDeserializationActions?.Invoke(this);
    }
}

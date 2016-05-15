using System;

namespace TestUnium.Instantiation.Settings
{
    [Serializable]
    public class SettingsBase : ISettings
    {
        public String MainUrl { get; set; }
        public Boolean MakeScreenshotOnError { get; set; }
        public String ScreenshotSystemPath { get; set; }
        public String ScreenshotUrlPath { get; set; }
        public Int32 ScreenshotFolderCapacity { get; set; }
        public String LogSystemPath { get; set; }
        public String LogUrlPath { get; set; }
        public Int32 LogFolderCapacity { get; set; }
        public String WebAppUrl { get; set; }
        public String ChromeDriverPath { get; set; }
        public String IeDriverPath { get; set; }
       

        public SettingsBase()
        {
            MainUrl = String.Empty;
            MakeScreenshotOnError = true;
            ScreenshotSystemPath = "screenshots";
            ScreenshotSystemPath = String.Empty;
            ScreenshotFolderCapacity = 50;
            LogSystemPath = "logs";
            LogUrlPath = String.Empty;
            LogFolderCapacity = 50;
            WebAppUrl = "localhost";
            ChromeDriverPath = @"drivers";
            IeDriverPath = @"drivers";
        }

        /// <summary>
        /// Override this method for performing settings changing 
        /// without modifying current settings file on a hard drive.
        /// </summary>
        public virtual void PostInitializationAction() { }
    }
}

using System;
using TestUnium.Settings;

namespace TestUnium.Selenium.Settings
{
    [Serializable]
    public class WebSettings : SettingsBase, IWebSettings
    {
        public String ScreenshotSystemPath { get; set; }
        public String ScreenshotUrlPath { get; set; }
        public Int32 ScreenshotFolderCapacity { get; set; }
        public Boolean MakeScreenshotOnError { get; set; }
        public String MainUrl { get; set; }
        public String WebAppUrl { get; set; }
        public String ChromeDriverPath { get; set; }
        public String IeDriverPath { get; set; }
       
        public WebSettings()
        {
            ScreenshotFolderCapacity = 50;
            ScreenshotSystemPath = "screenshots";
            ScreenshotUrlPath = String.Empty;
            MakeScreenshotOnError = true;
            MainUrl = String.Empty;
            WebAppUrl = "localhost";
            ChromeDriverPath = @"drivers";
            IeDriverPath = @"drivers";
        }
    }
}

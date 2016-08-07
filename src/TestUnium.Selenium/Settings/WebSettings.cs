using System;
using TestUnium.Settings;

namespace TestUnium.Selenium.Settings
{
    [Serializable]
    public class WebSettings : SettingsBase, IWebSettings
    {
        public Boolean MakeScreenshotOnError { get; set; }
        public String MainUrl { get; set; }
        public String WebAppUrl { get; set; }
        public String ChromeDriverPath { get; set; }
        public String IeDriverPath { get; set; }
       
        public WebSettings()
        {
            MakeScreenshotOnError = true;
            MainUrl = String.Empty;
            WebAppUrl = "localhost";
            ChromeDriverPath = @"drivers";
            IeDriverPath = @"drivers";
        }
    }
}

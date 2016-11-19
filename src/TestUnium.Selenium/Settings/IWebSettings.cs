using System;
using TestUnium.Selenium.WebDriving.Browsing;
using TestUnium.Settings;

namespace TestUnium.Selenium.Settings
{
    public interface IWebSettings : ISettings
    {
        String ScreenshotSystemPath { get; set; }
        String ScreenshotUrlPath { get; set; }
        Int32 ScreenshotFolderCapacity { get; set; }
        Boolean MakeScreenshotOnError { get; set; }
        String MainUrl { get; set; }
        String WebAppUrl { get; set; }
        String ChromeDriverPath { get; set; }
        String IeDriverPath { get; set; }
        Browser Browser { get; set; }
    }
}
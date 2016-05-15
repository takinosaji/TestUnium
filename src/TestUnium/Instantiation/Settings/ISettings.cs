using System;

namespace TestUnium.Instantiation.Settings
{
    public interface ISettings
    {
        String MainUrl { get; set; }
        Boolean MakeScreenshotOnError { get; set; }
        String ScreenshotSystemPath { get; set; }
        String ScreenshotUrlPath { get; set; }
        Int32 ScreenshotFolderCapacity { get; set; }
        String LogSystemPath { get; set; }
        String LogUrlPath { get; set; }
        Int32 LogFolderCapacity { get; set; }
        String WebAppUrl { get; set; }
        String ChromeDriverPath { get; set; }
        String IeDriverPath { get; set; }
        void PostInitializationAction();
    }
}
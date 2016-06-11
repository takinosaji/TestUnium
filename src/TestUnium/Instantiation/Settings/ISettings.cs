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
        /// <summary>
        /// Overriding some settings values set by default and loaded from file. 
        /// Note that changes made by following code dont affect settigns file content.
        /// </summary>
        void PostDeserializationAction();
    }
}
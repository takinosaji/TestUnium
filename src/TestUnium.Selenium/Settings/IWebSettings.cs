using System;
using TestUnium.Settings;

namespace TestUnium.Selenium.Settings
{
    public interface IWebSettings : ISettings
    {
        Boolean MakeScreenshotOnError { get; set; }
        String MainUrl { get; set; }
        String WebAppUrl { get; set; }
        String ChromeDriverPath { get; set; }
        String IeDriverPath { get; set; }
    }
}
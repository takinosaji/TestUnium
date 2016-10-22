using System;
using OpenQA.Selenium;
using TestUnium.Selenium.Settings;
using TestUnium.Settings;

namespace TestUnium.Selenium.WebDriving.Screenshots
{
    public interface IMakeScreenshotStrategy
    {
        void MakeScreenshot(Type testClassType, String callingMethodName, IWebDriver driver, IWebSettings settings);
    }
}
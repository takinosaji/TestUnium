using System;
using OpenQA.Selenium;
using TestUnium.Selenium.Settings;
using TestUnium.Settings;
using TestUnium.Stepping.Steps;

namespace TestUnium.Selenium.WebDriving.Screenshots
{
    public interface IMakeScreenshotStrategy
    {
        void MakeScreenshot(IStep stepType, Type testClassType, String callingMethodName, IWebDriver driver, IWebSettings settings);
    }
}
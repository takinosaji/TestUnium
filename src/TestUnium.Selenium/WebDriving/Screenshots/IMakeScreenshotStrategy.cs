using System;
using OpenQA.Selenium;
using TestUnium.Selenium.Settings;
using TestUnium.Settings;
using TestUnium.Stepping.Steps;

namespace TestUnium.Selenium.WebDriving.Screenshots
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMakeScreenshotStrategy
    {
        /// <summary>
        /// Method withc produces screenshot from IWebDriver.
        /// </summary>
        /// <param name="stepType"></param>
        /// <param name="testClassType"></param>
        /// <param name="callingMethodName"></param>
        /// <param name="driver"></param>
        /// <param name="settings"></param>
        /// <returns>Returns screenshot resource filepath or url.</returns>
        String MakeScreenshot(IStep stepType, Type testClassType, String callingMethodName, IWebDriver driver, IWebSettings settings);
    }
}
using System;
using System.Diagnostics.Contracts;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using OpenQA.Selenium;
using TestUnium.Selenium.Extensions;
using TestUnium.Selenium.Settings;
using TestUnium.Settings;
using TestUnium.Stepping.Steps;

namespace TestUnium.Selenium.WebDriving.Screenshots
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultMakeScreenshotStrategy : IMakeScreenshotStrategy
    {
        public String MakeScreenshot(IStep step, Type testClassType, String callingMethodName, IWebDriver driver, IWebSettings settings)
        {
            //Contract.Requires(!String.IsNullOrEmpty(settings.ScreenshotSystemPath), $"ScreenshotSystemPath can not be empty!");
            if(String.IsNullOrEmpty(settings.ScreenshotSystemPath))
                throw new ArgumentException($"ScreenshotSystemPath can not be empty!");

            if (driver == null) throw new WebDriverHasNotBeenProperlyInitializedException();
            var ss = driver.GetScreenshot();
            var screenshotName = (step?.GetType().Name ?? callingMethodName) + "_" + 
                DateTime.Now.ToString(CultureInfo.InvariantCulture)
                    .Replace('/', '_')
                    .Replace(' ', '_')

                    .Replace(':', '_') + ".png";
            var path =
                $"{settings.ScreenshotSystemPath}{Path.DirectorySeparatorChar}{testClassType}{Path.DirectorySeparatorChar}{callingMethodName}{Path.DirectorySeparatorChar}{screenshotName}";
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            ss.SaveAsFile(path, ImageFormat.Png);

            return path;
        }
    }
}
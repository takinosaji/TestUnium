using System;
using System.Collections.Generic;
using TestUnium.Selenium.WebDriving.Browsing;
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
        public Browser Browser { get; set; }

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
            Browser = Browser.Firefox;
        }

        public override void PostInitializeAction()
        {
            var browserContext = Context as IBrowserContext;
            if (browserContext == null)
                throw new IncorrectInheritanceException(new List<String> {nameof(Context.GetType)},
                    new List<String> {nameof(IBrowserContext)});
            browserContext.Browser = Browser;
        }
    }
}

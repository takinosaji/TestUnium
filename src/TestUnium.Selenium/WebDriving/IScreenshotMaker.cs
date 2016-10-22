using System;
using System.Runtime.CompilerServices;

namespace TestUnium.Selenium.WebDriving
{
    public interface IScreenshotMaker
    {
        void MakeScreenshot(String callingMethodName);
    }
}
using System;
using TestUnium.Instantiation.Settings;

namespace TestUnium.Instantiation.WebDriving
{
    public interface IWebDriverDrivenTest
    {
        void MakeScreenshot();
        void ShutDownWebDriver();
    }
}
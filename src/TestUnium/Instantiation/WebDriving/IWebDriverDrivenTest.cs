using System;
using TestUnium.Instantiation.Settings;

namespace TestUnium.Instantiation.WebDriving
{
    public interface IWebDriverDrivenTest : ISettingsDrivenTest
    {
        void MakeScreenshot();
        void ShutDownWebDriver();
    }
}
using System;

namespace TestUnium.Instantiation.WebDriving
{
    public interface IWebDriverDrivenTest
    {
        void MakeScreenshot();
        void ShutDownWebDriver();
    }
}
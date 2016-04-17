using System;

namespace TestUnium.Instantiation.WebDriving
{
    public interface IWebDriverDrivenTest
    {
        void ShutDownWebDriver(Boolean testFailed);
    }
}
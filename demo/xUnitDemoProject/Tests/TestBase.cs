using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StepModules;
using TestUnium;
using TestUnium.Selenium;

namespace xUnitDemoProject.Tests
{
    public class TestBase : SeleniumCore, IDisposable
    {
        public TestBase()
        {
            ApplyCustomization();

            // Registration of common step modules
            RegisterStepModule<ReusableCounterModule>();
        }
        public void Dispose()
        {
            ShutDownWebDriver();
        }
    }
}

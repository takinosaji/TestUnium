using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium;

namespace xUnitDemoProject.Tests
{
    public class TestBase : UniumCore, IDisposable
    {
        public TestBase()
        {
            ApplyCustomization();
        }
        public void Dispose()
        {
            ShutDownWebDriver();
        }
    }
}

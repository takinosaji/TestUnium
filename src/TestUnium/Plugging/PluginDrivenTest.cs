using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using TestUnium.Core;

namespace TestUnium.Plugging
{
    public class PluginDrivenTest : KernelDrivenTest, IPluginsDrivenTest
    {
        static PluginDrivenTest()
        {
#if DEBUG
            var plugins = new StaticPluginCompositionEngine(@"C:\GitHub\TestUnium\TestUnium.Specification\bin\Debug").GetComposedParts();
#else
            var plugins = new StaticPluginCompositionEngine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).GetComposedParts();
#endif
            foreach (var plugin in plugins)
            {
                plugin.PlugIn();
            }
        }

        protected PluginDrivenTest()
        {
            Kernel.Bind<IPluginsDrivenTest>().ToConstant(this);
        }
    }
}
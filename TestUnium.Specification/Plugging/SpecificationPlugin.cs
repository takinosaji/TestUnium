using System;
using System.ComponentModel.Composition;
using TestUnium.Extensibility;

namespace TestUnium.Specification.Plugging
{
    [Export(typeof(IStaticPlugin))]
    public class SpecificationPlugin : IStaticPlugin
    {
        public void PlugIn()
        {
            //Проверять на наличие всех тесткейсов в этом плагине
        }
    }
}

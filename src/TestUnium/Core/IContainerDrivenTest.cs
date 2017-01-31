using Castle.Windsor;
using TestUnium.Customization;

namespace TestUnium.Core
{
    public interface IContainerDrivenTest : ICustomizationAttributeDrivenTest
    {
        IWindsorContainer Container { get; set; }
    }
}
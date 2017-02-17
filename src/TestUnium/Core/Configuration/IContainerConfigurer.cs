using Castle.Windsor;

namespace TestUnium.Core.Configuration
{
    public interface IContainerConfigurer
    {
        IWindsorContainer GetContainer();
    }
}
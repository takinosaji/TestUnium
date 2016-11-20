using Castle.Windsor;

namespace TestUnium.Sessioning
{
    public interface ISessionContext
    {
        IWindsorContainer Container { get; set; }
    }
}

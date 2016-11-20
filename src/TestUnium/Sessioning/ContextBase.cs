using Castle.Windsor;

namespace TestUnium.Sessioning
{
    public class ContextBase : ISessionContext
    {
        public IWindsorContainer Container { get; set; }

        public ContextBase(IWindsorContainer container)
        {
            Container = container;
        }
    }
}

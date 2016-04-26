using Ninject;

namespace TestUnium.Sessioning
{
    public interface ISessionPlugin
    {
        void OnStart(ISessionContext context);

        void OnEnd(ISessionContext context);
    }
}

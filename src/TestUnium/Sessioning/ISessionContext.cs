using Ninject;

namespace TestUnium.Sessioning
{
    public interface ISessionContext
    {
        void AddSessionBindings(IKernel kernel);

        void RemoveSessionBindings(IKernel kernel);
    }
}

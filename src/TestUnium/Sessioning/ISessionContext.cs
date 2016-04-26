using Ninject;

namespace TestUnium.Sessioning
{
    public interface ISessionContext
    {
        IKernel Kernel { get; set; }
    }
}

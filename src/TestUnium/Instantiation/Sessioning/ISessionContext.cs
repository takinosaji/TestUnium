using Ninject;

namespace TestUnium.Instantiation.Sessioning
{
    public interface ISessionContext
    {
        IKernel Kernel { get; set; }
    }
}

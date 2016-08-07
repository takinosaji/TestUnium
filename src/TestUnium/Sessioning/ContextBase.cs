using Ninject;

namespace TestUnium.Sessioning
{
    public class ContextBase : ISessionContext
    {
        public IKernel Kernel { get; set; }

        public ContextBase(IKernel kernel)
        {
            Kernel = kernel;
        }
    }
}

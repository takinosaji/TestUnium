using Ninject;

namespace TestUnium.Sessioning
{
    public class BaseContext : ISessionContext
    {
        public IKernel Kernel { get; set; }

        public BaseContext(IKernel kernel)
        {
            Kernel = kernel;
        }
    }
}

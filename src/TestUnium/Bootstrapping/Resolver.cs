using Ninject;
using TestUnium.Common;

namespace TestUnium.Bootstrapping
{
    public class Resolver : Singleton<Resolver>
    {
        public IKernel Kernel { get; }
        private Resolver()
        {
            Kernel = new StandardKernel(new NinjectSettings
            {
                InjectNonPublic = true
            });
        }
    }
}

using Ninject;
using TestUnium.Domain;
using TestUnium.Internal.Bootstrapping.Modules;

namespace TestUnium.Internal.Bootstrapping
{
    internal class Container : Singleton<Container>
    {
        private readonly IKernel _kernel;

        private Container()
        {
            _kernel = new StandardKernel(new NinjectSettings
            {
                InjectNonPublic = true
            });
            _kernel.Bind<IKernel>().ToConstant(_kernel);
            _kernel.Load(new ServicesModule());
        }

        public IKernel Kernel => _kernel;
    }
}

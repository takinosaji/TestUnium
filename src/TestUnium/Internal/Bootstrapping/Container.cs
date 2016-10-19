using System;
using Ninject;
using TestUnium.Internal.Bootstrapping.Modules;
using TestUnium.Internal.Domain;

namespace TestUnium.Internal.Bootstrapping
{
    public class Container : Singleton<Container>
    {
        private readonly IKernel _kernel;

        private Container()
        {
            _kernel = new StandardKernel(new NinjectSettings
            {
                InjectNonPublic = true
            });
            _kernel.Bind<IKernel>().ToConstant(_kernel);
            _kernel.Load(AppDomain.CurrentDomain.GetAssemblies());
        }

        public IKernel Kernel => _kernel;
    }
}

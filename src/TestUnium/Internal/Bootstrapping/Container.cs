using System;
using System.IO;
using System.Reflection;
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
//#if DEBUG
            _kernel.Load(Assembly.GetExecutingAssembly());
/*#else
            _kernel.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
#endif*/
        }

        public IKernel Kernel => _kernel;
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Ninject;
using Ninject.Modules;
using TestUnium.Internal.Bootstrapping.Modules;
using TestUnium.Internal.Domain;

namespace TestUnium.Internal.Bootstrapping
{
    public class Container : Singleton<Container>
    {
        private readonly List<Type> _processedModules;
        public IKernel Current { get; set; }

        private Container()
        {
            _processedModules = new List<Type>();
            Current = new StandardKernel(new NinjectSettings
            {
                InjectNonPublic = true
            });
            Current.Bind<IKernel>().ToConstant(Current);
            //#if DEBUG
            Current.Load(Assembly.GetExecutingAssembly());
/*#Current
            _kernel.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
#endif*/
        }

        public void Load(params INinjectModule[] modules)
        {
            foreach (var module in modules)
            {
                var type = module.GetType();
                if (_processedModules.Contains(type)) return;
                Current.Load(module);
                _processedModules.Add(type);
            }
        }
    }
}

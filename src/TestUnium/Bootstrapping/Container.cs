using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using TestUnium.Bootstrapping.Modules;
using TestUnium.Domain;

namespace TestUnium.Bootstrapping
{
    internal class Container : Singleton<Container>
    {
        private readonly IKernel _kernel;

        private Container()
        {
            _kernel = new StandardKernel();
            _kernel.Load(new ServicesModule());
        }

        public IKernel Kernel => _kernel;
    }
}

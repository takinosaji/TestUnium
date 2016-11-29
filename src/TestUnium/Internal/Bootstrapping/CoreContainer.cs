using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using TestUnium.Internal.Bootstrapping.Modules;
using TestUnium.Internal.Domain;

namespace TestUnium.Internal.Bootstrapping
{
    public class CoreContainer : Singleton<CoreContainer>
    {
        private readonly List<Type> _processedInstallers;
        public IWindsorContainer Current { get; set; }

        private CoreContainer()
        {
            _processedInstallers = new List<Type>();
            Current = new WindsorContainer();
            Current.Register(Component.For<IWindsorContainer>().Instance(Current));
#if DEBUG
            Current.Install(FromAssembly.InThisApplication());
#else
            Current.Install(FromAssembly.InDirectory(new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory)));
#endif
        }

        public void Install(params IWindsorInstaller[] installers)
        {
            foreach (var installer in installers)
            {
                var type = installer.GetType();
                if (_processedInstallers.Contains(type)) return;
                Current.Install(installer);
                _processedInstallers.Add(type);
            }
        }
    }
}

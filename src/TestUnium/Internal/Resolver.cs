using System;
using System.Collections.Concurrent;
using System.Threading;
using Castle.Windsor;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Domain;
using TestUnium.Internal.Services;

namespace TestUnium.Internal
{
    public class Resolver : Singleton<Resolver>
    {
        private readonly ConcurrentDictionary<Int32, IWindsorContainer> _kernels;
        private readonly IInjectionService _injectionService;
        public IWindsorContainer CurrentContainer
        {
            get
            {
                return _kernels.GetOrAdd(Thread.CurrentThread.ManagedThreadId, _injectionService.CreateContainer());
            }
            set
            {
                _kernels.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, value, (i, kernel) => value);
            }
        }

        private Resolver()
        {
            _injectionService = CoreContainer.Instance.Current.Resolve<IInjectionService>();
            _kernels = new ConcurrentDictionary<Int32, IWindsorContainer>();
        }
    }
}

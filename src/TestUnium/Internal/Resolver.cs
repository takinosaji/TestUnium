using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Domain;
using TestUnium.Internal.Services;

namespace TestUnium.Internal
{
    public class Resolver : Singleton<Resolver>
    {
        private readonly ConcurrentDictionary<Int32, IKernel> _kernels;
        private readonly IInjectionService _injectionService;
        public IKernel Kernel
        {
            get
            {
                return _kernels.GetOrAdd(Thread.CurrentThread.ManagedThreadId, _injectionService.CreateKernel());
            }
            set
            {
                _kernels.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, value, (i, kernel) => value);
            }
        }

        private Resolver()
        {
            _injectionService = Bootstrapping.Container.Instance.Current.Get<IInjectionService>();
            _kernels = new ConcurrentDictionary<Int32, IKernel>();
        }
    }
}

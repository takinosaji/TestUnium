using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;
using TestUnium.Common;

namespace TestUnium.Bootstrapping
{
    public class Resolver : Singleton<Resolver>
    {
        private readonly ConcurrentDictionary<Int32, IKernel> _kernels;

        public IKernel Kernel
        {
            get
            {
                return _kernels[Thread.CurrentThread.ManagedThreadId];
            }
            set
            {
                _kernels.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, value, (i, kernel) => value);
            }
        }

        private Resolver()
        {
            _kernels = new ConcurrentDictionary<Int32, IKernel>();
        }
    }
}

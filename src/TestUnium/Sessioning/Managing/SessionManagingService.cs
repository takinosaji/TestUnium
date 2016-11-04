using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;

namespace TestUnium.Sessioning.Managing
{
    internal class SessionManagingService : ISessionManagingService
    {
        private readonly ConcurrentDictionary<Int32, SessionStoreContext> _sessions;

        public SessionManagingService()
        {
            _sessions = new ConcurrentDictionary<Int32, SessionStoreContext>();
        }

        //public ISession RegisterSession(IKernel kernel)
        //{
        //    //
        //    //var session = kernel.Get<ISession>();
        //    //_sessions.AddOrUpdate(Thread.CurrentThread.ManagedThreadId,
        //    //    new SessionStoreContext
        //    //    {
        //    //        ParentContext = null,
        //    //        Session = session
        //    //    }, (i, s) => session);
        //    //return session;
        //}
    }
}

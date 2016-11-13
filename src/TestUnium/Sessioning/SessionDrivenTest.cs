using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;
using Ninject.Parameters;
using TestUnium.Core;

namespace TestUnium.Sessioning
{
    public class SessionDrivenTest : KernelDrivenTest, ISessionDrivenTest, ISessionInvoker
    {
        public ConcurrentDictionary<Int32, ISession> Sessions { get; set; }
        protected SessionDrivenTest()
        {
            Sessions = new ConcurrentDictionary<int, ISession>();
            Kernel.Bind<ISessionDrivenTest>().ToConstant(this);
        }

        public ISession Session
        {
            get
            {
                var session = Kernel.Get<ISession>();
                session.Invoker = this;
                Sessions.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, 
                    session, (i, s) => session);
                return session;
            }
        }

        public String GetCurrentSessionId()
        {
            ISession currentSession;
            Sessions.TryGetValue(Thread.CurrentThread.ManagedThreadId, out currentSession);
            return currentSession?.GetSessionId();
        }

        public IParameter GetCurrentSessionIdConstructorArg()
        {
            return new ConstructorArgument("sessionId", GetCurrentSessionId());
        }
    }
}

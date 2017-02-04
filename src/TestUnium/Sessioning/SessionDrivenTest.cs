using System;
using System.Collections.Concurrent;
using System.Threading;
using Castle.MicroKernel.Registration;
using TestUnium.Core;

namespace TestUnium.Sessioning
{
    public class SessionDrivenTest : ContainerDrivenTest, ISessionDrivenTest
    {
        public ConcurrentDictionary<Int32, ISession> Sessions { get; set; }
        protected SessionDrivenTest()
        {
            Sessions = new ConcurrentDictionary<int, ISession>();
            Container.Register(Component.For<ISessionDrivenTest>().Instance(this).Named("ISessionDrivenTest"));
        }

        public ISession Session
        {
            get
            {
                var session = Container.Resolve<ISession>();
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
    }
}

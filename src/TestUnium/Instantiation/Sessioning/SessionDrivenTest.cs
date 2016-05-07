using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;
using TestUnium.Common;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Stepping;

namespace TestUnium.Instantiation.Sessioning
{
    [SessionContext(typeof(ContextBase))]
    public class SessionDrivenTest : CustomizationAttributeDrivenTest, ISessionDrivenTest
    {
        private readonly ConcurrentDictionary<Int32, ISession> _sessions;
        protected SessionDrivenTest()
        {
            _sessions = new ConcurrentDictionary<int, ISession>();
            Kernel.Bind<SessionDrivenTest>().ToConstant(this);
            ApplyCustomization();
        }

        public ISession Session
        {
            get
            {
                var session = InjectionHelper.CreateKernel(selfBindable: true).Get<ISession>();
                var id = Thread.CurrentThread.ManagedThreadId;
                _sessions.AddOrUpdate(id, session, (i, s) => session);
                return session;
            }
        }
    }
}

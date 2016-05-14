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
        public ConcurrentDictionary<Int32, ISession> Sessions { get; set; }
        protected SessionDrivenTest()
        {
            Sessions = new ConcurrentDictionary<int, ISession>();
            Kernel.Bind<ISessionDrivenTest>().ToConstant(this);
            ApplyCustomization();
        }

        public ISession Session
        {
            get
            {
                var session = InjectionHelper.CreateKernel(selfBindable: true).Get<ISession>();
                var id = Thread.CurrentThread.ManagedThreadId;
                Sessions.AddOrUpdate(id, session, (i, s) => session);
                return session;
            }
        }
    }
}

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
        }

        public ISession Session
        {
            get
            {
                var kernel = InjectionHelper.CreateKernel();
                kernel.Bind<ISession>().To(Kernel.Get<ISession>().GetType());
                kernel.Bind<ISessionContext>().To(Kernel.Get<ISessionContext>().GetType());
                var session = kernel.Get<ISession>();
                var id = Thread.CurrentThread.ManagedThreadId;
                Sessions.AddOrUpdate(id, session, (i, s) => session);
                return session;
            }
        }
    }
}

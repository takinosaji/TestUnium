using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;
using TestUnium.Common;
using TestUnium.Core;
using TestUnium.Settings;
using TestUnium.Stepping;

namespace TestUnium.Sessioning
{
    [Session(typeof(SessionBase), typeof(ContextBase))]
    public class SessionDrivenTest : StepDrivenTest, ISessionDrivenTest
    {
        private ConcurrentDictionary<String, ISession> _sessions;
        protected SessionDrivenTest()
        {
            ApplyCustomization();
        }

        public ISession Session
        {
            get
            {
                var session = Kernel.Get<ISession>();
                var c = Thread.CurrentContext;
                return session;
            }
        }
    }
}

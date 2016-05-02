﻿using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;
using TestUnium.Common;
using TestUnium.Core;
using TestUnium.Settings;
using TestUnium.Stepping;

namespace TestUnium.Sessioning
{
    [SessionContext(typeof(ContextBase))]
    public class SessionDrivenTest : StepDrivenTest, ISessionDrivenTest
    {
        private ConcurrentDictionary<Int32, ISession> _sessions;
        protected SessionDrivenTest()
        {
            Kernel.Bind<SessionDrivenTest>().ToConstant(this);
            ApplyCustomization();
        }

        public ISession Session
        {
            get
            {
                var session = Kernel.Get<ISession>();
                var  = Thread.CurrentContext;
                return session;
            }
        }
    }
}

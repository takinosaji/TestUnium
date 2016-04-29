using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;
using TestUnium.Common;
using TestUnium.Core;
using TestUnium.Stepping;

namespace TestUnium.Sessioning
{
    [ContextBase]
    public class SessionDrivenTest : StepDrivenTest, ISessionDrivenTest
    {
        private ConcurrentDictionary<String, ISession> _sessions;
        protected IKernel SessionKernel;
        protected SessionDrivenTest()
        {
            SessionKernel = InjectionHelper.CreateKernel();
            Kernel.Bind<ISessionContext>().To(взять тпи из атрибута);
            //SessionKernel.Bind<IStepRunner>().ToConstant(StepRunner);     //This is should be fixed die       
            Kernel.Bind<SessionDrivenTest>().ToConstant(this);
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

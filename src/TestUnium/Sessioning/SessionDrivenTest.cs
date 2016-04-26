using System;
using System.Collections.Concurrent;
using System.Threading;
using Ninject;
using TestUnium.Common;
using TestUnium.Core;
using TestUnium.Stepping;

namespace TestUnium.Sessioning
{
    public class SessionDrivenTest : StepDrivenTest
    {
        private ConcurrentDictionary<String, Session> _sessions; 
        protected IKernel SessionKernel;
        protected SessionDrivenTest()
        {
            SessionKernel = InjectionHelper.CreateKernel();
            SessionKernel.Bind<ISessionContext>().To(взять тпи из атрибута);            
            SessionKernel.Bind<IStepRunner>().ToConstant(StepRunner);     //This is should be fixed die       
            Kernel.Bind<SessionDrivenTest>().ToConstant(this);
        }

        public Session Session
        {
            get
            {
                var session = SessionKernel.Get<Session>();
                var c = Thread.CurrentContext;
                return session;
            }
        }
    }
}

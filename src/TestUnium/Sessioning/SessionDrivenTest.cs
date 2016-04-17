using Ninject;
using TestUnium.Core;
using TestUnium.Stepping;

namespace TestUnium.Sessioning
{
    public class SessionDrivenTest : StepDrivenTest
    {
        protected IKernel SessionKernel;
        protected SessionDrivenTest()
        {
            SessionKernel = InjectionHelper.CreateKernel();
            SessionKernel.Bind<IKernel>().ToConstant(SessionKernel);            
            SessionKernel.Bind<IStepRunner>().ToConstant(StepRunner);            
            Kernel.Bind<SessionDrivenTest>().ToConstant(this);
        }

        public ContextStepSession Session(params ISessionContext[] contexts)
        {
            return SessionKernel.Get<ContextStepSession>();
        }
    }
}

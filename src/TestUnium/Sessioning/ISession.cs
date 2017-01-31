using System;
using Castle.Windsor;
using TestUnium.Extensions.Ninject;
using TestUnium.Sessioning.Pipeline;
using TestUnium.Stepping.Pipeline;

namespace TestUnium.Sessioning
{
    public interface ISession
    {
        ISessionInvoker Invoker { get; set; }
        Guid SessionId { get; set; }
        #region Contexts
        ISession Using(params ISessionPlugin[] plugins);
        ISession Using<TPlugin>() where TPlugin : ISessionPlugin, new();
        #endregion
        #region StepModules
        IWindsorContainer GetSessionContainer();
        ISession Include(params Type[] moduleTypes);
        ISession Configure(Action<ISessionContext> contextSetUpAction);
        ISession ConfigureContainer(Action<IWindsorContainer> containerSetUpAction);
        ISession Include(Boolean makeReusable, params Type[] moduleTypes);
        ISession Include<TStepModule>(Boolean makeReusable = false) where TStepModule : IStepModule;
        #endregion
        //ISessionDrivenTest GetTestContext();
        String GetSessionId();
        void Start(Action<ISessionContext> operations);
        void End();
    }
}

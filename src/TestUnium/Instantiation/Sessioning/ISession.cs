using System;
using System.Collections.Generic;
using Ninject;
using TestUnium.Common;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public interface ISession
    {
        #region Contexts
        ISession Using(params ISessionPlugin[] plugins);
        ISession Using<TPlugin>() where TPlugin : ISessionPlugin, new();
        #endregion
        #region StepModules
        IKernel GetSessionKernel();
        ISession Include(params Type[] moduleTypes);
        ISession Include(Boolean makeReusable, params Type[] moduleTypes);
        ISession Include<TStepModule>(Boolean makeReusable) where TStepModule : IStepModule;
        #endregion
        //ISessionDrivenTest GetTestContext();
        String GetSessionId();
        void Start(Action<ISessionContext> operations);
        void End();
    }
}

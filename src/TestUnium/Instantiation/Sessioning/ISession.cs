using System;
using System.Collections.Generic;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public interface ISession
    {
        #region Contexts
        ISession Using(params ISessionPlugin[] plugins);
        ISession Using(IEnumerable<ISessionPlugin> contexts);
        ISession Using<TPlugin>() where TPlugin : ISessionPlugin, new();
        #endregion
        #region StepModules
        ISession Include(IEnumerable<Type> modules, Boolean reusable);
        ISession Include<TStepModule>(Boolean reusable) where TStepModule : IStepModule;
        #endregion
        ISessionDrivenTest GetTestContext();
        void Start(Action<ISessionContext> operations);
        void End();
    }
}

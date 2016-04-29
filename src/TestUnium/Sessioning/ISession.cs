using System;
using System.Collections.Generic;
using Ninject;
using TestUnium.Stepping.Modules;

namespace TestUnium.Sessioning
{
    public interface ISession
    {
        #region Contexts
        void AddContexts(params ISessionPlugin[] plugins);
        void AddContexts(IEnumerable<ISessionPlugin> contexts);
        ISession Using(params ISessionPlugin[] plugins);
        ISession Using(IEnumerable<ISessionPlugin> contexts);
        #endregion
        #region StepModules
        void AddModules(params IStepModule[] modules);
        void AddModules(IEnumerable<IStepModule> modules);
        ISession Include(params IStepModule[] modules);
        ISession Include(IEnumerable<IStepModule> modules);
        #endregion
        void Start(Action<ISessionContext> operations);
        void End();
    }
}

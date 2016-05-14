using System;
using System.Collections.Generic;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public interface ISession
    {
        #region Contexts
        void AddPlugins(params ISessionPlugin[] plugins);
        void AddPlugins(IEnumerable<ISessionPlugin> contexts);
        ISession Using(params ISessionPlugin[] plugins);
        ISession Using(IEnumerable<ISessionPlugin> contexts);
        #endregion
        #region StepModules
        void AddModules(Boolean reusable, params Type[] modules);
        void AddModules(IEnumerable<Type> modules, Boolean reusable);
        ISession Include(Boolean reusable, params Type[] modules);
        ISession Include(IEnumerable<Type> modules, Boolean reusable);
        ISession Include<TStepModule>(Boolean reusable) where TStepModule : IStepModule;
        #endregion
        void Start(Action<ISessionContext> operations);
        void End();
    }
}

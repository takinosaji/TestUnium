using System;
using System.Collections.Generic;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public interface ISession
    {
        ISessionDrivenTest TestContext { get; set; }
        #region Contexts
        void AddPlugins(params ISessionPlugin[] plugins);
        void AddPlugins(IEnumerable<ISessionPlugin> contexts);
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

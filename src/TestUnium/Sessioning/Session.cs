using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using TestUnium.Stepping;
using TestUnium.Stepping.Modules;

namespace TestUnium.Sessioning
{
    public class Session: ISession
    {
        private readonly IKernel _kernel;
        private readonly IStepRunner _runner;
        private ISessionContext[] _contexts;
        private IStepModule[] _stepModules;

        public Session(IKernel kernel, IStepRunner runner)
        {
            _kernel = kernel;
            _runner = runner;
            _contexts = new ISessionContext[0];
            _stepModules = new IStepModule[0];
        }

        private void AddContexts(params ISessionContext[] contexts)
        {
            var contextList = _contexts.ToList();
            foreach (var context in contexts)
            {
                context.OnStart(_kernel);
                contextList.Add(context);
            }
            _contexts = contextList.ToArray();
        }
        private void AddContexts(IEnumerable<ISessionContext> contexts)
        {
            AddContexts(contexts.ToArray());
        }

        private void AddModules(params IStepModule[] modules)
        {
            _stepModules = modules;
        }

        private void AddModules(IEnumerable<IStepModule> modules)
        {
            _stepModules = modules.ToArray();
        }

        public void Start(Action operations)
        {
            try { operations(); } finally { Dispose(); }
        }

        #region Contexts
        public Session Using(params ISessionContext[] contexts)
        {
            AddContexts(contexts); return this;
        }
        public Session Using(IEnumerable<ISessionContext> contexts)
        {
            AddContexts(contexts); return this;
        }
        #endregion

        #region StepModules
        public Session Include(params IStepModule[] modules)
        {
            AddModules(modules); return this;
        }
        public Session Include(IEnumerable<IStepModule> modules)
        {
            AddModules(modules); return this;
        }
        #endregion
        private void Dispose()
        {
            var contextList = _contexts.ToList();
            foreach (var context in contextList)
            {
                context.OnEnd(_kernel);

            }
            _contexts = contextList.ToArray();
            _runner.UnregisterModules(_stepModules);
        }
    }
}
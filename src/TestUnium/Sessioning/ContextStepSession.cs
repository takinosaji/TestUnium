using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using TestUnium.Stepping;
using TestUnium.Stepping.Modules;

namespace TestUnium.Sessioning
{
    public class ContextStepSession
    {
        private readonly IKernel _kernel;
        private readonly IStepRunner _runner;
        private ISessionContext[] _contexts;
        private IStepModule[] _stepModules;

        public ContextStepSession(IKernel kernel, IStepRunner runner)
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
                context.AddSessionBindings(_kernel);
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
        public ContextStepSession Using(params ISessionContext[] contexts)
        {
            AddContexts(contexts); return this;
        }
        public ContextStepSession Using(IEnumerable<ISessionContext> contexts)
        {
            AddContexts(contexts); return this;
        }
        #endregion

        #region StepModules
        public ContextStepSession Include(params IStepModule[] modules)
        {
            AddModules(modules); return this;
        }
        public ContextStepSession Include(IEnumerable<IStepModule> modules)
        {
            AddModules(modules); return this;
        }
        #endregion
        private void Dispose()
        {
            var contextList = _contexts.ToList();
            foreach (var context in contextList)
            {
                context.RemoveSessionBindings(_kernel);

            }
            _contexts = contextList.ToArray();
            _runner.UnregisterModules(_stepModules);
        }
    }
}
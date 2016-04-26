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
        private readonly ISessionContext _context;
        private ISessionPlugin[] _plugins;
        private IStepModule[] _stepModules;

        public Session(ISessionContext context)
        {
            _plugins = new ISessionPlugin[0];
            _stepModules = new IStepModule[0];
            _context = context;
        }

        private void AddContexts(params ISessionPlugin[] plugins)
        {
            var pluginList = _plugins.ToList();
            foreach (var plugin in plugins)
            {
                plugin.OnStart(_context);
                pluginList.Add(plugin);
            }
            _plugins = pluginList.ToArray();
        }
        private void AddContexts(IEnumerable<ISessionPlugin> contexts)
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

        public void Start(Action<ISessionContext> operations)
        {
            try { operations(_context); } finally { Dispose(); }
        }

        #region Contexts
        public Session Using(params ISessionPlugin[] plugins)
        {
            AddContexts(plugins); return this;
        }
        public Session Using(IEnumerable<ISessionPlugin> contexts)
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
            var pluginList = _plugins.ToList();
            foreach (var plugin in pluginList)
            {
                _context.OnEnd(_context);

            }
            _plugins = pluginList.ToArray();
            _runner.UnregisterModules(_stepModules);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using TestUnium.Stepping;
using TestUnium.Stepping.Modules;

namespace TestUnium.Sessioning
{
    public class SessionBase: ISession<ContextBase>
    {
        private readonly ISessionContext _context;
        private ISessionPlugin[] _plugins;
        private IStepModule[] _stepModules;

        public SessionBase(ISessionContext context)
        {
            _plugins = new ISessionPlugin[0];
            _stepModules = new IStepModule[0];
            _context = context;
        }

        public void AddContexts(params ISessionPlugin[] plugins)
        {
            _context.Kernel.GetAll()
            var pluginList = _plugins.ToList();
            foreach (var plugin in plugins)
            {
                plugin.OnStart(_context);
                pluginList.Add(plugin);
            }
            _plugins = pluginList.ToArray();
        }
        public void AddContexts(IEnumerable<ISessionPlugin> contexts)
        {
            AddContexts(contexts.ToArray());
        }

        public void AddModules(params IStepModule[] modules)
        {
            _stepModules = modules;
        }

        public void AddModules(IEnumerable<IStepModule> modules)
        {
            _stepModules = modules.ToArray();
        }

        public void Start(Action<ISessionContext> operations)
        {
            try { operations(_context); } finally { End(); }
        }

        #region Contexts
        public ISession Using(params ISessionPlugin[] plugins)
        {
            AddContexts(plugins); return this;
        }
        public ISession Using(IEnumerable<ISessionPlugin> contexts)
        {
            AddContexts(contexts); return this;
        }
        #endregion

        #region StepModules
        public ISession Include(params IStepModule[] modules)
        {
            AddModules(modules); return this;
        }
        public ISession Include(IEnumerable<IStepModule> modules)
        {
            AddModules(modules); return this;
        }
        #endregion
        public void End()
        {
            var pluginList = _plugins.ToList();
            foreach (var plugin in pluginList)
            {
                plugin.OnEnd(_context);

            }
            _plugins = pluginList.ToArray();
            _runner.UnregisterModules(_stepModules);
        }
    }
}
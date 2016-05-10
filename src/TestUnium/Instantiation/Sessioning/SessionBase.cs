using System;
using System.Collections.Generic;
using System.Linq;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public class SessionBase: ISession
    {
        public ISessionDrivenTest TestContext { get; set; }
        private readonly ISessionContext _context;
        private ISessionPlugin[] _plugins;
        private IStepModule[] _stepModules;

        public SessionBase(ISessionContext context, ISessionDrivenTest testContext)
        {
            _plugins = new ISessionPlugin[0];
            _stepModules = new IStepModule[0];
            _context = context;
            TestContext = testContext;
        }

        #region Plugins
        public void AddPlugins(params ISessionPlugin[] plugins)
        {
            // _context.Kernel.GetAll()
            var pluginList = _plugins.ToList();
            foreach (var plugin in plugins)
            {
                plugin.OnStart(_context);
                pluginList.Add(plugin);
            }
            _plugins = pluginList.ToArray();
        }
        public void AddPlugins(IEnumerable<ISessionPlugin> plugins)
        {
            AddPlugins(plugins.ToArray());
        }
        public ISession Using(params ISessionPlugin[] plugins)
        {
            AddPlugins(plugins); return this;
        }
        public ISession Using(IEnumerable<ISessionPlugin> plugins)
        {
            AddPlugins(plugins); return this;
        }
        #endregion

        #region StepModules
        public void AddModules(Boolean reusable, IEnumerable<Type> modules)
        {
            _stepModules = modules.ToArray();
        }
        public void AddModules(Boolean reusable, params IStepModule[] modules)
        {
            _stepModules = modules;
        }       
        public ISession Include(Boolean reusable, params IStepModule[] modules)
        {
            AddModules(modules); return this;
        }
        public ISession Include(Boolean reusable, IEnumerable<IStepModule> modules)
        {
            AddModules(modules); return this;
        }
        public void Start(Action<ISessionContext> operations)
        {
            try { operations(_context); } finally { End(); }
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
            TestContext.UnregisterModules(_stepModules);
        }
    }
}
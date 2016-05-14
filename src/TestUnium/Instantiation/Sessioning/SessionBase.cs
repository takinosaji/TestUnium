using System;
using System.Collections.Generic;
using System.Linq;
using TestUnium.Common;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public class SessionBase: ISession
    {
        private readonly ISessionContext _context;
        private ISessionPlugin[] _plugins;
        private readonly DubKeyDictionary<Type, Boolean> _stepModules;

        public SessionBase(ISessionContext context, ISessionDrivenTest testContext)
        {
            _plugins = new ISessionPlugin[0];
            _stepModules = new DubKeyDictionary<Type, Boolean>();
            _context = context;
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
        public void AddModules(Boolean reusable = false, params Type[] moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                _stepModules.Add(moduleType, reusable);
            }
        }
        public void AddModules(IEnumerable<Type> moduleTypes, Boolean reusable = false)
        {
            AddModules(reusable, moduleTypes.ToArray());
        }
        public ISession Include(Boolean reusable = false, params Type[] moduleTypes)
        {
            AddModules(reusable, moduleTypes); return this;
        }
        public ISession Include(IEnumerable<Type> moduleTypes, Boolean reusable = false)
        {
            AddModules(moduleTypes, reusable); return this;
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
        }
    }
}
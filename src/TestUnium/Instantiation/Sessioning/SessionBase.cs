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
        private readonly List<ISessionPlugin> _plugins;
        public readonly DubKeyDictionary<Type, Boolean> StepModules;

        public SessionBase(ISessionContext context)
        {
            _plugins = new List<ISessionPlugin>();
            StepModules = new DubKeyDictionary<Type, Boolean>();
            _context = context;
        }

        #region Plugins
        public void AddPlugins(params ISessionPlugin[] plugins) 
            => AddPlugins(plugins.ToList());
        public void AddPlugins(IEnumerable<ISessionPlugin> plugins) 
            => _plugins.AddRange(plugins);
        public ISession Using(params ISessionPlugin[] plugins)
        {
            AddPlugins(plugins); return this;
        }
        public ISession Using(IEnumerable<ISessionPlugin> plugins)
        {
            AddPlugins(plugins); return this;
        }

        public ISession Using<TPlugin>()
            where TPlugin : ISessionPlugin, new()
        {
            AddPlugins(Activator.CreateInstance<TPlugin>());
            return this;
        }
        #endregion

        #region StepModules
        public void AddModules(Boolean reusable = false, params Type[] moduleTypes) 
            => StepModules.AddRange(moduleTypes.Select(mt => new KeyValuePair<Type, Boolean>(mt, reusable)));
        public void AddModules(IEnumerable<Type> moduleTypes, Boolean reusable = false) 
            => AddModules(reusable, moduleTypes.ToArray());
        public ISession Include(Boolean reusable = false, params Type[] moduleTypes)
        {
            AddModules(reusable, moduleTypes); return this;
        }
        public ISession Include(IEnumerable<Type> moduleTypes, Boolean reusable = false)
        {
            AddModules(moduleTypes, reusable); return this;
        }

        public ISession Include<TStepModule>(Boolean reusable = false) where TStepModule : IStepModule
        {
            AddModules(reusable, typeof(TStepModule)); return this;
        }

        public void Start(Action<ISessionContext> operations)
        {
            try
            {
                _plugins.ForEach(sp => sp.OnStart(_context));
                operations(_context);
            }
            finally
            {
                End();
            }
        }
        #endregion
        public void End() => _plugins.ForEach(sp => sp.OnEnd(_context));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestUnium.Common;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public class SessionBase: ISession, IStepModuleRegistrator
    {
        private readonly ISessionDrivenTest _testContext;
        private readonly ISessionContext _context;
        private readonly List<ISessionPlugin> _plugins;
        public DubKeyDictionary<Type, Boolean> StepModules { get; set; }

        public SessionBase(ISessionDrivenTest testContext, ISessionContext context)
        {
            _plugins = new List<ISessionPlugin>();
            StepModules = new DubKeyDictionary<Type, Boolean>();
            _testContext = testContext;
            _context = context;
        }

        #region Plugins
        protected virtual void AddPlugins(params ISessionPlugin[] plugins) 
            => AddPlugins(plugins.ToList());
        protected virtual void AddPlugins(IEnumerable<ISessionPlugin> plugins) 
            => _plugins.AddRange(plugins);
        public ISession Using(params ISessionPlugin[] plugins)
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
        public ISession Include(params Type[] moduleTypes)
        {
            RegisterStepModules(false, moduleTypes); return this;
        }
        public ISession Include(Boolean makeReusable, params Type[] moduleTypes)
        {
            RegisterStepModules(makeReusable, moduleTypes); return this;
        }
        public ISession Include<TStepModule>(Boolean makeReusable = false) where TStepModule : IStepModule
        {
            RegisterStepModule<TStepModule>(makeReusable); return this;
        }
        public void RegisterStepModule<TStepModule>(Boolean makeReusable) where TStepModule : IStepModule
        {
            RegisterStepModules(makeReusable, typeof(TStepModule));
        }
        public void RegisterStepModules(params Type[] moduleTypes)
        {
            RegisterStepModules(false, moduleTypes);
        }
        public void RegisterStepModules(Boolean makeReusable, params Type[] moduleTypes)
        {
            moduleTypes.ToList().ForEach(mt => StepModules.Add(mt, makeReusable));
        }

        public void UnregisterStepModule<TStepModule>() where TStepModule : IStepModule
        {
            UnregisterStepModules(typeof(TStepModule));
        }

        public void UnregisterStepModules(params Type[] moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                StepModules.Remove(moduleType);
            }
        }
        #endregion

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
       
        public void End()
        {
            _plugins.ForEach(sp => sp.OnEnd(_context));
            ISession session;
            _testContext.Sessions.TryRemove(Thread.CurrentThread.ManagedThreadId, out session);
        }
    }
}
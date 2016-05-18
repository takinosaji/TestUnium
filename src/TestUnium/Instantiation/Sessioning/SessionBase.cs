using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestUnium.Common;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public class SessionBase: ISession
    {
        private readonly ISessionDrivenTest _testContext;
        private readonly ISessionContext _context;
        private readonly List<ISessionPlugin> _plugins;
        public readonly DubKeyDictionary<Type, Boolean> StepModules;

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
        protected virtual void AddModules(Boolean reusable = false, params Type[] moduleTypes) 
            => StepModules.AddRange(moduleTypes.Select(mt => new KeyValuePair<Type, Boolean>(mt, reusable)));
        protected virtual void AddModules(IEnumerable<Type> moduleTypes, Boolean reusable = false) 
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

        public ISessionDrivenTest GetTestContext()
        {
            return _testContext;
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

        public void End()
        {
            _plugins.ForEach(sp => sp.OnEnd(_context));
            ISession session;
            _testContext.Sessions.TryRemove(Thread.CurrentThread.ManagedThreadId, out session);
        } 
    }
}